//=========================================================================================================================================
// Deployables.cs
//=========================================================================================================================================

$TeamItemMax[PlasmaTurretPack] = 8;
$TeamItemMax[ForceFieldPack] = 8;
$TeamItemMax[LargeForceFieldPack] = 8;

$InvList[PlasmaTurretPack] = 1;
$InvList[ForceFieldPack] = 1;
$InvList[LargeForceFieldPack] = 1;

$RemoteInvList[PlasmaTurretPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
$RemoteInvList[LargeForceFieldPack] = 1;

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Plasma Turret
//
//  
//  Created by Ross Cheetham
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-


ItemImageData PlasmaTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmaTurretPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dDeployables";
	imageType = PlasmaTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function PlasmaTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlasmaTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
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
					%DeployablePlasma = newObject("PlasmaTurretPack","Turret",DeployablePlasma,true);
	   	      addToSet("MissionCleanup", %DeployablePlasma);
					GameBase::setTeam(%DeployablePlasma,GameBase::getTeam(%player));
					GameBase::setRotation(%DeployablePlasma,%rot);
					GameBase::setPosition(%DeployablePlasma,$los::position);
					Gamebase::setMapName(%DeployablePlasma,"DeployablePlasma#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Plasma Turrent deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%DeployablePlasma) @ "PlasmaTurretPack"]++;
					echo("MSG: ",%client," deployed a DeployablePlasma");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}


TurretData DeployablePlasma
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FusionBolt;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{

	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret");
	}
}

function DeployablePlasma::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasma::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployablePlasma::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Small ForceField
//
//  
//  Created by Ross Cheetham
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

ItemImageData ForceFieldPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData ForceFieldPack 
{ 
	description = "Force Field"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
   heading = "dDeployables";
	imageType = ForceFieldPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 30; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function ForceFieldPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function ForceFieldPack::onDeploy(%player,%item,%pos) 
{ 
	if (ForceFieldPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);

} 

function ForceFieldPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objForceField = newObject("","StaticShape",DeployableForceField,true); 
	addToSet("MissionCleanup", %objForceField); 
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objForceField,$los::position); 
	GameBase::setRotation(%objForceField,%rot); 
	Gamebase::setMapName(%objForceField,"Force Field"); 
	Client::sendMessage(%client,0,"Force Field Deployed"); 
	GameBase::startFadeIn(%objForceField); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++; 
//        reportDeploy(%objForceField, %client);
	echo("MSG: ",%client," deployed a Force Field");
	return true; 
} 

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Large ForceField
//
//  
//  Created by Ross Cheetham
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

ItemImageData LargeForceFieldPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData LargeForceFieldPack 
{ 
	description = "Large Force Field"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
   heading = "dDeployables";
	imageType = LargeForceFieldPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 75; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function LargeForceFieldPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item);
} 

function LargeForceFieldPack::onDeploy(%player,%item,%pos) 
{ 
	if (LargeForceFieldPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);  
} 

function LargeForceFieldPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	// %obj = getObjectType($los::object); 
	// %set = newObject("set",SimSet); 
	// %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); 
	// %num = CountObjects(%set,"DeployableForceField",%num); 
	// deleteObject(%set); 

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objForceField = newObject("","StaticShape",LargeForceField,true); 
	addToSet("MissionCleanup", %objForceField); 
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objForceField,$los::position); 
	GameBase::setRotation(%objForceField,%rot); 
	Gamebase::setMapName(%objForceField,"Force Field"); 
	Client::sendMessage(%client,0,"Force Field Deployed"); 
	GameBase::startFadeIn(%objForceField); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++; 
//        reportDeploy(%objForceField, %client);
	echo("MSG: ",%client," deployed a Force Field");
	return true; 
} 