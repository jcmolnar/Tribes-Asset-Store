$InvList[Beacon] = 1;
$RemoteInvList[Beacon] = 1;

$SellAmmo[Beacon] = 5;

addDeployable(Beacon, 40);

addAmmo(HandAmmo, Beacon, 3);

ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = $InvHead[iMisc];
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

SensorData DefaultBeacon
{
	description = "Narc";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//	explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 50;
	dopplerVelocity = 1;
	castLOS = false;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};

function Beacon::onUse(%player,%item)
{
	if (Beacon::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "Beacon"]++;
	}
}

//function Beacon::onEndSequence(%this,%thread)
//{
//	GameBase::setActive(%this,true);
//	GameBase::playSequence(%this,0,"power");
//}

function Beacon::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
// GetLOSInfo sets the following globals:
// los::position
// los::normal
// los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
// Try to stick it straight up or down, otherwise
// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%mSensor = newObject("Narc","Sensor",DefaultBeacon,true);
					addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Narc");
					Client::sendMessage(%client,0,"Narc deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Narc");
					return true;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}