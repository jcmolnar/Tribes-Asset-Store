// This is a MiniMod Plugin.
// This plugin is the GuardDog (Shockwave) Turret from the hvTactical mod.
// Ported by PeterT.

MiniMod::MonitorFile(start, "GuardDogTurret.CodeFusion.cs", "GuardDog Turret Plugin");

MiniMod::Turbo::Class(AGravPack, 24);
MiniMod::Turbo::Class(AGravPack, 29);

RocketData Watch
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.06;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 10;//1.8

   soundId = SoundJetHeavy;
};

$TeamItemMax[ConPack] = 2;

ItemImageData GuardDogImage //image name while a pack
{
	shapeFile = "remoteturret";//name of shape file, same as in turret.cs
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ConPack //ItemData name, used below in item.cs
{
	description = "Guard Dog";
	shapeFile = "remoteturret";//"chainturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = GuardDogImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 425;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ConPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ConPack::onDeploy(%player,%item,%pos)
{
	if (ConPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
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

function ConPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableConTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableConTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableConTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Guard Dog#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Guard Dog deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ConPack"]++;
								echo("MSG: ",%client," deployed a Guard Dog");
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

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

TurretData DeployableConTurret //TurretData name, used in item.cs 3 times
{
	className = "Turret";//type classification
	shapeFile = "chainturret"; //"remoteturret";  shape, texture used
	projectileType = Watch;//projectile fired
	maxDamage = 1.5;//stamina of unshielded turret
	maxEnergy = 300;//amount of turret energy
	minGunEnergy = 75;//?
	maxGunEnergy = 10;//?
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 1.5;//0.05,delay between shots (sec)
	speed = 2.0;//4.0; traverse speed?
	speedModifier = 1.5;//?
	range = 150;//sensor range of turret
	visibleToSensor = true;//shows up on command screen (y,n)
	shadowDetailMask = 4;//?
	dopplerVelocity = 1; //2; 0=free attack, 2=motion sensitive?
	castLOS = true;//tracks when target not visible?
	supression = false;//acts as sensor jammer, true=yes
	suppressable = false;//can be jammed, true=yes?
	pinger = false;//?
	mapFilter = 2;//?
	mapIcon = "M_turret";//icon as appears on command screen
	debrisId = flashDebrisLarge;//debris graphic
	shieldShapeName = "shield";//shield type?
	fireSound = SoundPlasmaTurretFire;//sound when firing
	activationSound = SoundChainTurretOn;//sound when on
	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;//explosion graphic
	description = "Guard Dog";//description pertaining to ? file
	damageSkinData = "objectDamageSkins";//damage graphic
};

function DeployableConTurret::onAdd(%this)
{
	schedule("DeployableConTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Guard Dog");
	}
}

function DeployableConTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableConTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableConTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ConPack"]--;
}

// Override base class just in case.
function DeployableConTurret::onPower(%this,%power,%generator) {}
function DeployableConTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

$InvList[ConPack] = 1; //GuardDog Turret
$RemoteInvList[ConPack] = 1; //GuardDog Turret

MiniMod::MonitorFile(start, "GuardDogTurret.CodeFusion.cs", "GuardDog Turret Plugin");
