//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
    heading = $InvHeading[Deployables];
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::deployItem(%player, %item); }
}

function MotionSensorPack::onDeploy(%player, %item, %pos)
{
	if(MotionSensorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

function MotionSensorPack::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if(GameBase::getLOSInfo(%player,3))
		{
			%client.score = %client.score +2;
			BottomPrint(%client, "<jl><Bskull_big.bmp><jr><Bskull_big.bmp><jc><f0>You Recieve <f2>2 <f0>Points For Being Smart Enough To Use A \n<f1>"@ %item.description @"\n<jc><f0>DeathCount: <f2>"@ %client.scoreKills @"   <f0>Kill Count: <f2>"@ %client.scoreKills @"\n<f0>Current Score: <f2>"@ %client.score @"  <f0>Kill\Death Ratio: "@ %client.ratio @"", 7);
			Game::refreshClientScore(%client);
			%Set = newObject("set",SimSet);
			%Mask = $StaticObjectType;
			%num = containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
			for(%i; %i < %num; %i++)
			{
				%thing = Group::getObject(%Set, %i);
				if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				{ %inbase= true; break; }
			}
			deleteObject(%Set);
			
			if(%inbase)
			{
				%obj = getObjectType($los::object);
				if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "StaticShape" || %obj == "Turret")
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if(Vector::dot($los::normal,"0 0 1") > 0.6)
					{ %rot = "0 0 " @ %zRot; }
					else
					{
						if(Vector::dot($los::normal,"0 0 -1") > 0.6)
						{ %rot = "3.14159 0 " @ %zRot; }
						else
						{ %rot = Vector::getRotation($los::normal); }
					}
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	            addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				}
				else 
				{
					Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
				}
			}
			else
			{ bottomprint(%client, "<jc>Fair play distance exceeded for " @ %item.description @ "s", 3); }
		}
		else
		{ Client::sendMessage(%client,0,"Deploy position out of range"); }
	}
	else
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for "@ %item.description @"s"); }
	return false;
}
//===========================================================================================

ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
	heading = $InvHeading[Deployables];
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function PulseSensorPack::onDeploy(%player, %item, %pos)
{ if(Item::deployShape(%player, "Pulse Sensor", DeployablePulseSensor, %item)){ Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++; } }
//===========================================================================================

ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
  	heading = $InvHeading[Deployables];
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if(Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}