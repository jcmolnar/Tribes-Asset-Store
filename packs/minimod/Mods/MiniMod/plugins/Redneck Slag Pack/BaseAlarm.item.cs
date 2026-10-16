// This is a MiniMod Plugin.
// This is the Base Alarm from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    BaseAlarm.ArmorData.cs
//    BaseAlarm.item.cs
//    BaseAlarm.reinitData.cs
//    BaseAlarm.staticshape.cs
//    BaseAlarm.station.cs
//
// to your MiniMod/plugins directory.
$TeamItemMax[BaseAlarm] = 10;

$totalNumAlarms[-1] = 0;
$totalNumAlarms[0] = 0;
$totalNumAlarms[1] = 0;
$totalNumAlarms[2] = 0;
$totalNumAlarms[3] = 0;
$totalNumAlarms[4] = 0;
$totalNumAlarms[5] = 0;
$totalNumAlarms[6] = 0;
$totalNumAlarms[7] = 0;

ItemImageData BaseAlarmImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData BaseAlarm
{
   description = "Base Alarm";
   shapeFile = "sensor_small";
   className = "Backpack";
   heading = "dDeployables";
   shadowDetailMask = 4;
   imageType = BaseAlarmImage;
   mass = 2.0;
   elasticity = 0.2;
   price = 50;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function BaseAlarm::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BaseAlarm::onDeploy(%player,%item,%pos)
{
	if (BaseAlarm::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function BaseAlarm::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if (GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		if (%obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position)) {
				%alarm = newObject("","StaticShape", "AlarmKit",true);
 	 			addToSet("MissionCleanup", %alarm);
				GameBase::setTeam(%alarm,GameBase::getTeam(%player));
				GameBase::setRotation(%alarm,%rot);
				GameBase::setPosition(%alarm,$los::position);
				Gamebase::setMapName(%alarm,%name);
				Gamebase::setMapName(%alarm,"Base Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)]++);
				Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
				$TeamItemCount[GameBase::getTeam(%SGen) @ "BaseAlarm"]++;
				return true;
			}
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}

	return false;
}

	$TeamItemCount[0 @ BaseAlarm] = 0;
	$TeamItemCount[1 @ BaseAlarm] = 0;
	$TeamItemCount[2 @ BaseAlarm] = 0;
	$TeamItemCount[3 @ BaseAlarm] = 0;
	$TeamItemCount[4 @ BaseAlarm] = 0;
	$TeamItemCount[5 @ BaseAlarm] = 0;
	$TeamItemCount[6 @ BaseAlarm] = 0;
	$TeamItemCount[7 @ BaseAlarm] = 0;

