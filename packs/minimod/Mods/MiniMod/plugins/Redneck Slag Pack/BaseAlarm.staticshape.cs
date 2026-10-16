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

StaticShapeData AlarmKit
{
	description = "Base Alarm";
	shapeFile = "sensor_small";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundBeaconActive;
	maxDamage = 1.0;
	mapIcon = "M_marker";
	damageSkinData = "objectDamageSkins";
	visibleToSensor = true;
	triggerRadius = 10.0;
};

function AlarmKit::onCollision(%this, %object)
{
	%type = getObjectType(%object);

	if (%type == "Player" && !$pause) {
		$pause = 1;
		schedule("$pause = 0;",10,%this);
		%name = Player::getClient(%object);
		%name = Client::getName(%name);
		%team = GameBase::getTeam(%object);
		%itemTeam = GameBase::getTeam(%this);

		if(%team != %itemTeam) {
			TeamMessages(1, %itemTeam,GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name @ "~wLeftMissionArea.wav");
			echo(GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name);
		}
	}		
}

function AlarmKit::onAdd(%this)
{	
}
																						 
function AlarmKit::onEnabled(%this)
{
}

function AlarmKit::onDisabled(%this)
{
}

function AlarmKit::onDestroyed(%this)
{
    $TeamItemCount[GameBase::getTeam(%this) @ "BaseAlarm"]--;
	TeamMessages(1, GameBase::getTeam(%this),GameBase::GetMapName(%this) @  " has been destroyed! ~wLeftMissionArea.wav");
}
