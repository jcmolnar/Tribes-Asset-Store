//###############
$InvList[ObeliskofLight] = 1; 
$RemoteInvList[ObeliskofLight] = 1; 
//###############
$TeamItemMax[ObeliskofLight] = 1;
//###############
$ItemMax[larmor, ObeliskofLight] = 0;
$ItemMax[lfemale, ObeliskofLight] = 0;
$ItemMax[marmor, ObeliskofLight] = 1;
$ItemMax[mfemale, ObeliskofLight] = 1;
$ItemMax[harmor, ObeliskofLight] = 0;
//###############
ItemImageData ObeliskofLightImage
{
	shapeFile = "shotgunex";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ObeliskofLight
{
	description = "Obelisk of Light";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "jTurret";
	imageType = ObeliskofLightImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 8000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskofLight::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}

function ObeliskofLight::onDeploy(%player,%item,%pos)
{
if (ObeliskofLight::deployShape(%player,%item)) {
Player::decItemCount(%player,%item);
}
}

function ObeliskofLight::deployShape(%player,%item)
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
if (%obj == "InteriorShape") {
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
%turret = newObject("remoteTurret","Turret",ObeliskofLightS,true);
addToSet("MissionCleanup", %turret);
GameBase::setTeam(%turret,GameBase::getTeam(%player));
GameBase::setRotation(%turret,%rot);
GameBase::setPosition(%turret,$los::position);
Gamebase::setMapName(%turret,"Obelisk of Light#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
Client::sendMessage(%client,0,"Deployed an obelisk of light");
playSound(SoundPickupBackpack,$los::position);
$TeamItemCount[GameBase::getTeam(%turret) @ "ObeliskofLight"]++;
echo("MSG: ",%client," deployed a Obelisk of Light");
Client::setOwnedObject(%client, %turret); 
Client::setOwnedObject(%client, %player);
return true;
}
}
else {
Client::sendMessage(%client,0,"Ehhehe, can only deploy me on a base...a hover pad would be better :)");
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

TurretData ObeliskofLightS
{
	className = "Turret";
	shapeFile = "remoteturret";
   	validateShape = true;
   	validateMaterials = true;
	projectileType = DemLaser;
	maxDamage = 18;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.01;
	speed = 2;
	speedModifier = 2;
	range = 300;
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
	description = "Obelisk of Light";
	damageSkinData = "objectDamageSkins";
};

function ObeliskofLightS::onAdd(%this)
{
	schedule("ObeliskofLightS::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Obelisk of Light");
	}
}

function ObeliskofLightS::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ObeliskofLightS::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ObeliskofLightS::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskofLight"]--;
}

function ObeliskofLightS::onPower(%this,%power,%generator) {}
function ObeliskofLightS::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//############################################

 
//############################################
