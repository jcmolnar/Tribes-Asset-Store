//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[VulcanTurret] = 1;

$ItemMax[larmor, VulcanTurret] = 0;	//Seraph
$ItemMax[lfemale, VulcanTurret] = 0;	//Seraph
$ItemMax[earmor, VulcanTurret] = 1;	//Slave
$ItemMax[efemale, VulcanTurret] = 1;	//Slave
$ItemMax[marmor, VulcanTurret] = 1;	//Pawn
$ItemMax[aarmor, VulcanTurret] = 0;	//Navigator
$ItemMax[darmor, VulcanTurret] = 0;	//Atomizer
$ItemMax[barmor, VulcanTurret] = 0;	//Paladin

$TeamItemMax[VulcanTurret] = 5;

function deployVulcanTurret::Initialize()
{	$TeamItemCount[0 @ VulcanTurret] = 0;
	$TeamItemCount[1 @ VulcanTurret] = 0;
	$TeamItemCount[2 @ VulcanTurret] = 0;
	$TeamItemCount[3 @ VulcanTurret] = 0;
	$TeamItemCount[4 @ VulcanTurret] = 0;
	$TeamItemCount[5 @ VulcanTurret] = 0;
	$TeamItemCount[6 @ VulcanTurret] = 0;
	$TeamItemCount[7 @ VulcanTurret] = 0;
}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


TurretData DeployableVulcan 
{ className = "Turret"; shapeFile = "hellfiregun"; projectileType = TurretBullet; accuFire = false; maxDamage = 4.0; maxEnergy = 300; minGunEnergy = 4; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.00001; speed = 4.0; speedModifier = 1.5; range = 0; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; fireSound = SoundFireMortar; activationSound = SoundPlasmaTurretOn; deactivateSound = SoundPlasmaTurretOff; whirSound = SoundPlasmaTurretTurn; explosionId = flashExpMedium; description = "Vulcan Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableVulcan::onAdd(%this) { schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,10); %this.shieldStrength = 0.005; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Vulcan Turret"); } } function DeployableVulcan::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableVulcan::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableVulcan::onDestroyed(%this) { StaticShape::objectiveDestroyed(%this); %this.shieldStrength = 0; GameBase::setRechargeRate(%this,0); Turret::onDeactivate(%this); CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); $TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurret"]--; } function DeployableVulcan::onPower(%this,%power,%generator) {} function DeployableVulcan::onEnabled(%this) { GameBase::setRechargeRate(%this,100); GameBase::setActive(%this,true); } 


ItemImageData VulcanTurretImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData VulcanTurret 
{ description = "Vulcan Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "gDeployable Turrets"; imageType = VulcanTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 800; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function VulcanTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function VulcanTurret::onDeploy(%player,%item,%pos) { if (VulcanTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function VulcanTurret::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "The Vulcan Turret has no auto-sensor and must be controlled manually to fire."); } function CountObjects(%set,%name,%num) { %count = 0; for(%i=0;%i<%num;%i++) { %obj=Group::getObject(%set,%i); if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } return %count; } function VulcanTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableVulcan",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployableVulcan,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Vulcan Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Vulcan Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurret"]++;echo("MSG: ",%client," deployed a Vulcan Turret");  return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 
