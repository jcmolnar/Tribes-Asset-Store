$TeamItemMax[FlameTurretPack] = 5;
$InvList[FlameTurretPack] = 1;
$RemoteInvList[FlameTurretPack] = 1;

$EmbedController[DeployableFlameTurret] = 1;
$CanAlwaysTeamDestroy[DeployableFlameTurret] = 1;

function deployFlameTurret::Initialize()
{
  $TeamItemCount[0 @ FlameTurretPack] = 0;
  $TeamItemCount[1 @ FlameTurretPack] = 0;
  $TeamItemCount[2 @ FlameTurretPack] = 0;
  $TeamItemCount[3 @ FlameTurretPack] = 0;
  $TeamItemCount[4 @ FlameTurretPack] = 0;
  $TeamItemCount[5 @ FlameTurretPack] = 0;
  $TeamItemCount[6 @ FlameTurretPack] = 0;
  $TeamItemCount[7 @ FlameTurretPack] = 0;
}

BulletData FlamerBolt2
{
  bulletShapeName = "plasmatrail.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.06;
  damageType = $PlasmaDamageType;
  explosionRadius = 4.0;
  muzzleVelocity = 30.0;
  totalTime = 0.30;
  liveTime = 0.20;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

ItemImageData FlameTurretPackImage 
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData FlameTurretPack
{
  description = "Flame Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = FlameTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 350;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function FlameTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function FlameTurretPack::onDeploy(%player,%item,%pos) 
{
  if (Turret::deployShape(%player, "Flame Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableFlameTurret, %item, $TurretLocGroundOnly))
    Player::decItemCount(%player,%item);
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function FlameTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableFlameTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableFlameTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableFlameTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Flame Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Flame Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "FlameTurretPack"]++;
								echo("MSG: ",%client," deployed a Flame Turret");
						      Client::setOwnedObject(%client, %turret);
						      Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

 //-=-=-=-

TurretData DeployableFlameTurret
{
  className = "Turret";
  shapeFile = "remoteturret";
  projectileType = FlamerBolt2;
  maxDamage = 1.0;
  maxEnergy = 95;
  minGunEnergy = 0;
  maxGunEnergy = 0;
  sequenceSound[0] = {"deploy", SoundActivateMotionSensor };
  reloadDelay = 0.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 10;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  activationSound = SoundPlasmaTurretOn;
  deactivateSound = SoundPlasmaTurretOff;
  whirSound = SoundPlasmaTurretTurn;
  explosionId = "";
  description = "Remote Flame Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableFlameTurret::onAdd(%this) 
{
  schedule("DeployableFlameTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.010;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Flame Turret");
}

function DeployableFlameTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableFlameTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableFlameTurret::onDestroyed(%this) 
{
  StaticShape::objectiveDestroyed(%this);
  %this.shieldStrength = 0;
  GameBase::setRechargeRate(%this,0);
  Turret::onDeactivate(%this);
  Turret::objectiveDestroyed(%this);
  CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
  $TeamItemCount[GameBase::getTeam(%this) @ "FlameTurretPack"]--;
}

function DeployableFlameTurret::onPower(%this,%power,%generator) 
{
}

function DeployableFlameTurret::onEnabled(%this) 
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}
