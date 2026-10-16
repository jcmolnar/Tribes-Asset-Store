$ItemMax[narmor, FlameTurretPack] = 0;
$ItemMax[nfemale, FlameTurretPack] = 0;
$ItemMax[aarmor, FlameTurretPack] = 0;
$ItemMax[afemale, FlameTurretPack] = 0;
$ItemMax[darmor, FlameTurretPack] = 0;
$ItemMax[sarmor, FlameTurretPack] = 1;
$ItemMax[barmor, FlameTurretPack] = 1;
$ItemMax[bfemale, FlameTurretPack] = 1;
$ItemMax[avarmor, FlameTurretPack] = 0;

$InvList[FlameTurretPack] = 1;
$RemoteInvList[FlameTurretPack] = 1;

ExplosionData fireExp
{
   shapeName = "plasmaex.dts";
   soundId   = bigExplosion2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

RocketData FlameLarge
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = fireExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $FlameDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 10.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange         = 10.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};

$TeamItemMax[FlameTurretPack] = 2;

ItemImageData FlameTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData FlameTurretPack
{
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fDeployables";
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function FlameTurretPack::onUse(%player,%item)
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

function FlameTurretPack::onDeploy(%player,%item,%pos)
{
	if (FlameTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function FlameTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				%Set = newObject("set",SimSet);
				%Mask = $StaticObjectType;
				%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
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
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player);

							%turret = newObject("Flame Turret","Turret",FlameTurret,true);
     		           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Flame Turret " @ Client::getName(%client));

							%cyl = newObject("Flame Turret Fuel","StaticShape",Canister,true);
     		           				addToSet("MissionCleanup", %cyl);
							GameBase::setTeam(%cyl,GameBase::getTeam(%player));
							%backward = Vector::neg(Vector::getFromRot(%rot, 0.8));//meaning backwards a little bit.

							GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
							GameBase::setRotation(%cyl,%rot);
							Gamebase::setMapName(%cyl,"Flame Turret Fuel");

							%turret.cyl = %cyl;
							%cyl.turret = %turret;

							Client::sendMessage(%client,0,"Flame Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "FlameTurretPack"]++;
							echo("MSG: ",%client," deployed an Flame Turret");
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret);
							// Client::setOwnedObject(%client, %player);

							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							{
								GameBase::setDamageLevel(%turret, 0.7 * FlameTurret.maxDamage);
								GameBase::setDamageLevel(%cyl, 0.7 * Canister.maxDamage);
							}

							return true;
						}
						else
							Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
					}
					else
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else
					Client::sendMessage(%client,0,"You must be near your own base");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

StaticShapeData Canister
{
   description = "Flame Turret Fuel";
	shapeFile = "liqcyl";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 0.55;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;

};



function Canister::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40,
		0.1, 250, 100);

	GameBase::setDamageLevel(%this.turret, 0.6);
}

// Override base class just in case.
function Canister::onPower(%this,%power,%generator)
{
	if (%power)
		GameBase::playSequence(%this,0,"power");
	else
		GameBase::stopSequence(%this,0);
}


function Canister::onEnabled(%this)
{
	if (GameBase::isPowered(%this))
		GameBase::playSequence(%this,0,"power");
}

function Canister::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}
TurretData FlameTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = FlameLarge;
	maxDamage = 0.55;
	maxEnergy = 30;
	minGunEnergy = 3;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.02;
	speed = 4.0;
	speedModifier = 1.5;
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_Radar";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFlameTurret;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Flame Turret";
	damageSkinData = "objectDamageSkins";
};

function FlameTurret::onAdd(%this)
{
	schedule("FlameTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flame Turret");
	}
}

function FlameTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FlameTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function FlameTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlameTurretPack"]--;
	GameBase::setDamageLevel(%this.cyl, 0.6);
}

// Override base class just in case.
function FlameTurret::onPower(%this,%power,%generator) {}
function FlameTurret::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}