$InvList[SpeedyModemPack] = 1;
$RemoteInvList[SpeedyModemPack] = 1;
//-----teams---//
$TeamItemMax[SpeedyModemPack] = 30;
//---@rm0rD@T@ :) 
$ItemMax[larmor, SpeedyModemPack] = 0;
$ItemMax[lfemale, SpeedyModemPack] = 0;
$ItemMax[marmor, SpeedyModemPack] = 1;
$ItemMax[mfemale, SpeedyModemPack] = 1;
$ItemMax[harmor, SpeedyModemPack] = 0;
//-------things that make it work :P 
function deploySpeedyModem::Initialize()
{
	$TeamItemCount[0 @ SpeedyModemPack] = 0;
	$TeamItemCount[1 @ SpeedyModemPack] = 0;
	$TeamItemCount[2 @ SpeedyModemPack] = 0;
	$TeamItemCount[3 @ SpeedyModemPack] = 0;
	$TeamItemCount[4 @ SpeedyModemPack] = 0;
	$TeamItemCount[5 @ SpeedyModemPack] = 0;
	$TeamItemCount[6 @ SpeedyModemPack] = 0;
	$TeamItemCount[7 @ SpeedyModemPack] = 0;
}

ItemImageData SpeedyModemPackImage 
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	lightType = 2;   // Pulsing
	lightRadius = 2;
	lightTime = 1.5;
	lightColor = { 1.0, 0, 0 };
	firstPerson = false;
};

ItemData SpeedyModemPack 
{
	description = "Dial-up Modem";
	shapeFile = "radar_small";
	className = BackPack;
   	heading = "dDeployable";
	imageType = SpeedyModemPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function speedyModemPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SpeedyModemPack::onDeploy(%player,%item,%pos)
{
	if (SpeedyModemPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "SpeedyModemPack"]++;
	}
}

//	if (Item::deployShape(%player,"Fuck this shit",SpeedyModem,%item)) {
function SpeedyModemPack::deployShape(%player,%item)
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
					%mSensor = newObject("","Sensor",SpeedyModem,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Dial-up Modem");
					Client::sendMessage(%client,1,"Connected to your teams ISP at 256kbps");
					playSound(SoundBeaconUse,$los::position);
					echo("MSG: ",%client," deployed a Dial-up Modem");
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

SensorData SpeedyModem
{
	description = "Dial-up Modem";
	className = "DeployableSensor";
	shapeFile = "radar_small";
	lightType = 2;   // Pulsing
	lightRadius = 2;
	lightTime = 1.5;
	lightColor = { 0, 1, 0 };
	shadowDetailMask = 4;
	visibleToSensor = true;
   validateShape = true;
   validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundDeploySensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 15.0;
//   explosionId = DebrisExp;
	debrisId = flashDebrisSmall;
	range = 500;
	castLOS = true;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
};
