// This is a MiniMod Plugin.
// This plugin is the Nuclear Turret from the Ideal mod.
// Ported by Dewy.

MiniMod::MonitorFile(start, "Nuclear Turret.CodeFusion.cs", "Nuclear Turret Plugin");
MiniMod::Turbo::Class(NuclearTurretPack, 24);
MiniMod::Turbo::Class(NuclearTurretPack, 29);

$DamageScale[larmor, $FlameDamageType] = 0.9;
$DamageScale[lfemale, $FlameDamageType] = 0.9;
$DamageScale[marmor, $FlameDamageType] = 1.0;
$DamageScale[mfemale, $FlameDamageType] = 1.0;
$DamageScale[harmor, $FlameDamageType] = 1.1;
$DamageScale[sarmor, $FlameDamageType] = 1.4;
$DamageScale[sfemale, $FlameDamageType] = 1.4;
$DamageScale[spyarmor, $FlameDamageType] = 1.4;
$DamageScale[spyfemale, $FlameDamageType] = 1.4;
$DamageScale[barmor, $FlameDamageType] = 1.0;
$DamageScale[bfemale, $FlameDamageType] = 1.0;
$DamageScale[earmor, $FlameDamageType] = 1.0;
$DamageScale[efemale, $FlameDamageType] = 1.0;
$DamageScale[aarmor, $FlameDamageType] = 1.0;
$DamageScale[afemale, $FlameDamageType] = 1.0;
$DamageScale[barmor, $FlameDamageType] = 1.0;
$DamageScale[bfemale, $FlameDamageType] = 1.0;
$DamageScale[darmor, $FlameDamageType] = 1.0;
$DamageScale[tarmor, $FlameDamageType] = 1.3;
$DamageScale[scvarmor, $FlameDamageType] = 1.0;

RocketData NukeTurret
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 75;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 500.0;

   muzzleVelocity   = 90.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

$TeamItemMax[NuclearTurretPack] = 1;

ItemImageData NuclearTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData NuclearTurretPack
{
	description = "Nuclear Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = NuclearTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function NuclearTurretPack::onUse(%player,%item)
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

function NuclearTurretPack::onDeploy(%player,%item,%pos)
{
	if (NuclearTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function NuclearTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("NuclearremoteTurret","Turret",NuclearDeployableTurret,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Nuclear Turret " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Nuclear Turret deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "NuclearTurretPack"]++;
						echo("MSG: ",%client," deployed a Nuclear Turret");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %turret); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%turret, 0.7 * NuclearDeployableTurret.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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

$InvList[NuclearTurretPack] = 1;

TurretData NuclearDeployableTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = NukeTurret;
	maxDamage = 5;
	maxEnergy = 40;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireMortar;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Nuclear Turret";
	damageSkinData = "objectDamageSkins";
};

function NuclearDeployableTurret::onAdd(%this)
{
	schedule("NuclearDeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Nuclear Turret");
	}
}

function NuclearDeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function NuclearDeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function NuclearDeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "NuclearTurretPack"]--;
}

// Override base class just in case.
function NuclearDeployableTurret::onPower(%this,%power,%generator) {}
function NuclearDeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

MiniMod::MonitorFile(stop, "Nuclear Turret.CodeFusion.cs", "Nuclear Turret Plugin");
