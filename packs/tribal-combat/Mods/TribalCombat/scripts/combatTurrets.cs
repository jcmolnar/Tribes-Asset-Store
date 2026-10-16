//**********************
// TRIBAL COMBAT TURRETS
//**********************
$ItemMax[larmor, MRL] = 0;
$ItemMax[carmor, MRL] = 0;
$ItemMax[marmor, MRL] = 1;
$ItemMax[harmor, MRL] = 0;
$ItemMax[darmor, MRL] = 1;
$ItemMax[lfemale, MRL] = 0;
$ItemMax[fcarmor, MRL] = 0;
$ItemMax[mfemale, MRL] = 1;

function checkDeployArea(%client,%pos)
{
  	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape") 
	{ 
		%obj = Group::getObject(%set,0);
		%objname = GameBase::getDataName(%obj);
        if(%objname == "ssFloatingPad" || %objname == "ssBarricade")
		 {
			deleteObject(%set);
			return 1;
		 }
		else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{ 
		%obj = Group::getObject(%set,0);
		%objname = GameBase::getDataName(%obj);
		if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{
	%obj=Group::getObject(%set,%i);
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
	}
	return %count;
}

function horzDeployTurret(%player,%item,%shape,%data,%name,%sound)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if(GameBase::getLOSInfo(%player,3))
  {
   %obj = getObjectType($los::object);
    %objname = GameBase::getDataName($los::object);
	if(%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad") 
   {
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%num = CountObjects(%set,%shape,%num);
	deleteObject(%set);
	if($MaxNumTurretsInBox > %num)
	{
	 %set = newObject("set",SimSet);
	 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	 %num = CountObjects(%set,%shape,%num);
	 deleteObject(%set);
	 if(0 == %num)
	 {
	  if(Vector::dot($los::normal,"0 0 1") > 0.7)
	  {
	   if(checkDeployArea(%client,$los::position))
	   {
		%rot = GameBase::getRotation(%player); 
		%object = newObject(%name,%data,%shape,true);
	    addToSet("MissionCleanup",%object);
		GameBase::setTeam(%object,GameBase::getTeam(%player));
		GameBase::setPosition(%object,$los::position);
		GameBase::setRotation(%object,%rot);
		Gamebase::setMapName(%object,%name@$totalNumTurrets++@" "@Client::getName(%client));
		Client::sendMessage(%client,0,%name@" deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%player)@%name]++;
        echo("MSG: ",%client," deployed a "@%name);
	    return true;
	   }
	  }
      else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
     } 
     else Client::sendMessage(%client,0,"Frequency Overload - Too close to other "@%name@"s");
    }
    else Client::sendMessage(%client,0,"Interference from other "@%name@"s in the area");
   }
   else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
  }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for "@%name@"s");
 return false;
}

function radDeployTurret(%player,%item,%shape,%data,%name,%sound)
{
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player)@%item] < $TeamItemMax[%item]) 
 {
  if(GameBase::getLOSInfo(%player,3)) 
   {
	%obj = getObjectType($los::object);
    %objname = GameBase::getDataName($los::object);
	if(%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad" || %objname == "ssBarricade") 
	{
	 %set = newObject("set",SimSet);
	 if(%shape == LaserTurret  || %shape == DeployableChaingun) %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$LaserBoxMaxLength,$LaserBoxMaxWidth,$LaserBoxMaxHeight,0);
	 else %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	 %num = CountObjects(%set,%shape,%num);
	 deleteObject(%set);
	 if(%shape == LaserTurret  || %shape == DeployableChaingun) %maxTurrets = $MaxNumLasersInBox;
	 else %maxTurrets = $MaxNumTurretsInBox;
	 if(%maxTurrets > %num)
	 {
	  %set = newObject("set",SimSet);
	  if(%shape == LaserTurret || %shape == DeployableChaingun) %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$LaserBoxMinLength,$LaserBoxMinWidth,$LaserBoxMinHeight,0);
	  else %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	  %num = CountObjects(%set,%shape,%num);
	  deleteObject(%set);
	  if(0 == %num)
	  {
	   %prot = GameBase::getRotation(%player);
	   %zRot = getWord(%prot,2);
	   if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 "@%zRot;
	   else
	   {
	    if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 "@%zRot;
		else %rot = Vector::getRotation($los::normal);
       }
	   if(checkDeployArea(%client,$los::position))
	   {
	    %object = newObject(%name,%data,%shape,true);
	   	addToSet("MissionCleanup",%object);
		GameBase::setTeam(%object,GameBase::getTeam(%player));
		GameBase::setRotation(%object,%rot);
		GameBase::setPosition(%object,$los::position);
		Gamebase::setMapName(%object,%name@$totalNumTurrets++@" "@Client::getName(%client));
		Client::sendMessage(%client,0,%name@" deployed");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%object)@%name]++;
		echo("MSG: ",%client," deployed a "@%name);
		return true;
	   }

	  } 
	  else Client::sendMessage(%client,0,"Frequency Overload - Too close to other turrets");
     }
	 else Client::sendMessage(%client,0,"Interference from other "@%name@"s in the area");
	}
	else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
   }
   else Client::sendMessage(%client,0,"Deploy position out of range");
  }
  else Client::sendMessage(%client,0,"Deployable Item limit reached for "@%name@"s");
  return false;
}

//***************************
ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
    heading = "kSensors";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CameraPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function CameraPack::onDeploy(%player,%item,%pos)
{
 if(radDeployTurret(%player,%item,CameraTurret,Turret,Camera)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//***************************																			
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "iTurret";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function TurretPack::onDeploy(%player,%item,%pos)
{
 if(radDeployTurret(%player,%item,DeployableTurret,Turret,TurretPack)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//********************************
ItemImageData LaserTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
    heading = "iTurret";
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
 if(radDeployTurret(%player,%item,LaserTurret,Turret,LaserTurretPack)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//*******************************
ItemImageData ChaingunTurretImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ChaingunTurret
{
	description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "iTurret";
	imageType = ChaingunTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChaingunTurret::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function ChaingunTurret::onDeploy(%player,%item,%pos)
{
 if(radDeployTurret(%player,%item,DeployableChaingun,Turret,ChaingunTurret)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//**************************
ItemImageData RemoteELFImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RemoteELF
{
	description = "ELF Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "iTurret";
	imageType = RemoteELFImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RemoteELF::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function RemoteELF::onDeploy(%player,%item,%pos)
{
 if(radDeployTurret(%player,%item,DeployableELFTurret,Turret,RemoteELF)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//*********************************
ItemImageData RemoteAutoCannonImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RemoteAutoCannon
{
	description = "Remote AutoCannon";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "jEmplacements";
	imageType = RemoteAutoCannonImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RemoteAutoCannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function RemoteAutoCannon::onDeploy(%player,%item,%pos)
{
 if(horzDeployTurret(%player,%item,DeployableAutoCannon,Turret,RemoteAutoCannon)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//*******************************
ItemImageData RemoteAACannonImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RemoteAACannon
{
	description = "Anti Aircraft Cannon";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "jEmplacements";
	imageType = RemoteAACannonImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RemoteAACannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function RemoteAACannon::onDeploy(%player,%item,%pos)
{
 if(horzDeployTurret(%player,%item,AACannon,Turret,RemoteAACannon)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//***********************************
ItemImageData RemotePlasmaTurretImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RemotePlasmaTurret
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "jEmplacements";
	imageType = RemotePlasmaTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RemotePlasmaTurret::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function RemotePlasmaTurret::onDeploy(%player,%item,%pos)
{
 if(horzDeployTurret(%player,%item,DeployablePlasmaTurret,Turret,RemotePlasmaTurret)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//******************************
ItemImageData MissileTurretImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData MissileTurret
{
	description = "Missile Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "jEmplacements";
	imageType = MissileTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MissileTurret::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function MissileTurret::onDeploy(%player,%item,%pos)
{
 if(horzDeployTurret(%player,%item,DeployableMissileTurret,Turret,MissileTurret)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//******************************
ItemImageData MRLImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData MRL
{
	description = "MRL";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "jEmplacements";
	imageType = MRLImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MRL::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function MRL::onDeploy(%player,%item,%pos)
{
 if(horzDeployTurret(%player,%item,tdMRL,Turret,MRL)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

//********************************
TurretData tdMRL
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 6;
	maxGunEnergy = 6;
	range = 145;
	gunRange = 145;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 20.0;
	speedModifier = 2.0;
	projectileType = miniRocket;
	reloadDelay = 0.9;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
    targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "MRL";
};

function tdMRL::onAdd(%this)
{
	schedule("tdMRL::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,14);
	%this.shieldStrength = 0.008;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "MRL");
}

function tdMRL::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function tdMRL::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function tdMRL::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MRL"]--;
}

// Override base class just in case.
function tdMRL::onPower(%this,%power,%generator) {}
function tdMRL::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,14);
	GameBase::setActive(%this,true);
}	

//*********************
TurretData tdSniperNest
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = GaussBullet;
	maxDamage = 4.0;
	maxEnergy = 100;
	minGunEnergy = 100;
	maxGunEnergy = 100;
	reloadDelay = 4.5;
	speed = 15.0;
	speedModifier = 1.0;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockExplosion;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Remote Sniper";
};

function tdSniperNest::onAdd(%this)
{
	schedule("tdSniperNest::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Remote Sniper");
}

function tdSniperNest::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function tdSniperNest::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function tdSniperNest::onDestroyed(%this)
{
  	$TeamItemCount[GameBase::getTeam(%this) @ "SniperNest"]--;
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function tdSniperNest::onPower(%this,%power,%generator) {}
function tdSniperNest::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,14);
	GameBase::setActive(%this,true);
}	

//***************************
$ItemMax[larmor,SniperNest] = 0;
$ItemMax[carmor,SniperNest] = 0;
$ItemMax[marmor,SniperNest] = 1;
$ItemMax[harmor,SniperNest] = 0;
$ItemMax[darmor,SniperNest] = 1;
$ItemMax[lfemale,SniperNest] = 0;
$ItemMax[fcarmor,SniperNest] = 0;
$ItemMax[mfemale,SniperNest] = 1;
										
ItemImageData SniperNestImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SniperNest
{
	description = "Remote Sniper";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "iTurret";
	imageType = SniperNestImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SniperNest::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function SniperNest::onDeploy(%player,%item,%pos)
{
 if(radDeployTurret(%player,%item,tdSniperNest,Turret,SniperNest)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}
