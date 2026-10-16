// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Light" (And Power source) from
// the Ideal mod. Ported by Dewy.

MiniMod::MonitorFile(start, "Obelisk Of Light.CodeFusion.cs", "Obelisk Of Light Plugin");
MiniMod::Turbo::Class(ObeliskPowerPack, 24);
MiniMod::Turbo::Class(ObeliskPowerPack, 29);
MiniMod::Turbo::Class(ObeliskPack, 24);
MiniMod::Turbo::Class(ObeliskPack, 29);

SoundData SoundBuzz
{
   wavFileName = "targetlaser.wav";
   profile = Profile3dMediumLoop;
};

LaserData ObeliskBeam
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0125;
   damageType    = $ObeliskDamageType;

   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

$TeamItemMax[ObeliskPack] = 2;

$TeamItemMax[ObeliskPowerPack] = 2;

ItemImageData ObeliskPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPack
{
	description = "Obelisk of Light";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ObeliskPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ObeliskPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%Set = newObject("set",SimSet); 
			%Mask = $StaticObjectType; 
			%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
			for(%i; %i < %num; %i++)
			{
				%gen = Group::getObject(%Set, %i);
				if(%gen.obeliskpower && %gen.obelisk == "")
				{
					%powered = true;
					break;
				}
			}
			deleteObject(%Set);
			if(%powered)
			{
				%obj = getObjectType($los::object);
				if (%obj != "InteriorShape")
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 

							%turret2 = newObject("ObeliskBarrel","Turret",RealObeliskOfLight,true);
	                 				addToSet("MissionCleanup", %turret2);
							GameBase::setTeam(%turret2,GameBase::getTeam(%player));
							GameBase::setPosition(%turret2,Vector::add($los::position, "0 0 11.5"));
							GameBase::setRotation(%turret2,%rot);

							%turret = newObject("Obelisk","StaticShape",ObeliskOfLight,true);
      	           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);

							%turret.realGun = %turret2; //referencing variables
							%turret.gen = %gen;
							%gen.obelisk = %turret2;

							Gamebase::setMapName(%turret,"Obelisk of Light " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Obelisk of Light deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPack"]++;
							echo("MSG: ",%client," deployed an Obelisk of Light. Turret is:" @ %turret @ " and Turret2 is: " @ %turret2);
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);
							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
								GameBase::setDamageLevel(%turret, 0.7 * ObeliskOfLight.maxDamage);

							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else 
					Client::sendMessage(%client,0,"Cannot deploy in buildings");
			}
			else
				Client::sendMessage(%client, 0, "Must be within range of an Obelisk Power Source");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemImageData ObeliskPowerPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -1.0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPowerPack
{
	description = "Obelisk Power Source";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ObeliskPowerPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPowerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ObeliskPowerPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPowerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPowerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 

						%generator = newObject("ObeliskPower","StaticShape",ObeliskPower,true);
                 				addToSet("MissionCleanup", %generator );
						GameBase::setTeam(%generator ,GameBase::getTeam(%player));
						GameBase::setPosition(%generator,$los::position);
						GameBase::setRotation(%generator,%rot);

						%generator.obeliskpower = true;

						Gamebase::setMapName(%turret,"Obelisk Power Source " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Obelisk Power Source deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPowerPack"]++;
						echo("MSG: ",%client," deployed an Obelisk Power Source");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %generator); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%generator, 0.7 * ObeliskPower.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function ObeliskPower::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}

function ObeliskPower::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down
}

function ObeliskPower::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPowerPack"]--;
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
}

function ObeliskPower::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
}

function ObeliskPower::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down

}

StaticShapeData ObeliskPower
{
   description = "Obelisk Power Source";
	shapeFile = "solar";
	className = "Generator";
	debrisId = flashDebrisLarge;
	maxDamage = 1.5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};


StaticShapeData ObeliskOfLight
{
   description = "Obelisk of Light";
	shapeFile = "anten_med";
	className = "Decoration";
	debrisId = flashDebrisLarge;
	maxDamage = 5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;

   sfxAmbient = SoundBuzz;

};



function ObeliskOfLight::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 

	%realGun = %this.realGun;
	GameBase::setDamageLevel(%realGun, 10);
	%gen = %this.gen;
	%gen.obelisk = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPack"]--;
}

// Override base class just in case.
function ObeliskOfLight::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}


function ObeliskOfLight::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function ObeliskOfLight::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}


$InvList[ObeliskPowerPack] = 1;
$InvList[ObeliskPack] = 1;
$RemoteInvList[ObeliskPowerPack] = 0;
$RemoteInvList[ObeliskPack] = 0;

TurretData RealObeliskOfLight
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = ObeliskBeam;
	maxDamage = 5;
	maxEnergy = 80;
	minGunEnergy = 80;
	maxGunEnergy = 80;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200; //100;
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundLaserHit;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "";
	damageSkinData = "objectDamageSkins";
};

function RealObeliskOfLight::onAdd(%this)
{
	schedule("RealObeliskOfLight::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	playSound(SoundBuzz,GameBase::getPosition(%this));
}

function RealObeliskOfLight::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RealObeliskOfLight::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RealObeliskOfLight::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RealObeliskOfLight::onPower(%this,%power,%generator) {}
function RealObeliskOfLight::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

MiniMod::MonitorFile(stop, "Obelisk Of Light.CodeFusion.cs", "Obelisk Of Light Plugin");
