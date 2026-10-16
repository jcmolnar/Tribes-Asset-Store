//Infested  burst laser, Zerg, L-m
$InvList[InfOmega] = 1;
$AutoUse[InfOmega] = False;
$WeaponAmmo[InfOmega] = "";

addWeapon(InfOmega);
$CanAlwaysTeamDestroy[DeployableShockTurret] = 1;

function deployShockTurret::Initialize()
{
  $TeamItemCount[0 @ ShockTurretPack] = 0;
  $TeamItemCount[1 @ ShockTurretPack] = 0;
  $TeamItemCount[2 @ ShockTurretPack] = 0;
  $TeamItemCount[3 @ ShockTurretPack] = 0;
  $TeamItemCount[4 @ ShockTurretPack] = 0;
  $TeamItemCount[5 @ ShockTurretPack] = 0;
  $TeamItemCount[6 @ ShockTurretPack] = 0;
  $TeamItemCount[7 @ ShockTurretPack] = 0;
}

// Purpose of file:
// weapon fires a grenade
// grenade spawns mines
// mines give a position & turret spawns at mine

BulletData infestBolt
{
   bulletShapeName   = "paint.dts";
   explosionTag      = turretExp;
   damageType        = 0;
   damageValue       = 0.007;
   bulletholeIndex   = 0;
   baseDamageType    = $BulletDamageType;
   damageType        = $BulletDamageType;
   aimDeflection     = 0.009;
   liveTime          = 0.4;
   totalTime         = 0.4;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   muzzleVelocity    = 800.0;
   terminalVelocity  = 800.0;
   acceleration      = 20.0;
   inheritedVelocityScale = 0.2;
   detachFromShooter = false;
};

// 2) grenade spawns mines
// -----------------------

MineData placeholder
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "camera";
  shadowDetailMask = 4;
  explosionId = clawExp;
  explosionRadius = 0.0;
  damageValue = 0.0;
  damageType = $MineDamageType;
  kickBackStrength = 0;
  triggerRadius = 0.0;
  maxDamage = 100.0;
  shadowDetailMask = 0;
  destroyDamage = 1000.0;
  damageLevel = {1.0, 1.0};
};

function placeholder::onAdd(%this)
{
	placeholder::deployCheck(%this);
	return;
}

function placeholder::deployCheck(%this)
{
  if (GameBase::isAtRest(%this)) 
  {
	%set = newObject("set",SimSet);
	if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
	{
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	deleteObject(%set);
	schedule("spawnTurret(" @ %this @ ");",0.6,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.7,%this);
	}
	else schedule("placeholder::deployCheck(" @ %this @ ");", 3, %this);
}

// 3) Mine gives turret a position, turret appears
// -----------------------------------------------

function spawnTurret(%this)
{
	%team = Gamebase::getTeam(%this);
	if(%team.numTurrets < 2)
	{
	%pos = Gamebase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%vec = Vector::getFromRot(%rot, 500);
	%objSpringboard = newObject("Infestation", "Turret", DeployableShockTurret, true);
	addToSet("MissionCleanup", %objSpringboard);
	GameBase::setTeam(%objSpringboard,%team);
	GameBase::setPosition(%objSpringboard, %pos);
	GameBase::setRotation(%objSpringboard, %rot);
	Gamebase::setMapName(%objSpringboard, "Infestation");
	GameBase::startFadeIn(%objSpringboard);
	%team.numturrets++;
	return true;
	}
	else
	{
	}
}

TurretData DeployableShockTurret 
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = infestBolt;
  maxDamage = 0.3;
  maxEnergy = 800;
  minGunEnergy = 2;
  maxGunEnergy = 3;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.3;
  speed = 15.0;
  speedModifier = 0.5;
  range = 25;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundFireDisc;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Infestation Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableShockTurret::onAdd(%this) 
{
  schedule("DeployableShockTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,15);
  %this.shieldStrength = 0.0;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Scatter Las Turret");
}

function DeployableShockTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableShockTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableShockTurret::onDestroyed(%this) 
{
  %team = Gamebase::getTeam(%this);
  %team.numturrets--;
  Turret::onDestroyed(%this);
}

function DeployableShockTurret::onPower(%this,%power,%generator) 
{
}

function DeployableShockTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,15);
  GameBase::setActive(%this,true);
}

function InfOmegaImage::onFire(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%team = Gamebase::getTeam(%player);
		%obj = newObject("","Mine","placeholder");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%client,35,false);
		GameBase::setTeam(%obj,%team);
}

ItemImageData InfOmegaImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 2;
  fireTime = 3;
  minEnergy = 50;
  maxEnergy = 60;
  projectileType = undefined;
  accuFire = false;
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
};

ItemData InfOmega 
{
  heading = $InvHead[ihPsi];
  description = "SCV Builder Util";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = InfOmegaImage;
  price = 350;
  showWeaponBar = true;
};

function InfOmega::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "SCV Builder Utility: <f2> Will Build whatever turret you choose from the tab menu.");
}
