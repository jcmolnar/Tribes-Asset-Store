additem(LaserTurretPack);

//=========ArmorData.cs===============
$ItemMax[larmor, LaserTurretPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;
$ItemMax[harmor, LaserTurretPack] = 1;
$ItemMax[lfemale, LaserTurretPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
//====================================

//==========Station.cs===================================
$InvList[LaserTurretPack] = 1;
$RemoteInvList[LaserTurretPack] = 1;
//=======================================================



//=========Item.cs=============================================
$TeamItemMax[LaserTurretPack]= 10; // Max # A Team can buy/deploy

ItemImageData LaserTurretPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData LaserTurretPack
{
        description = "Laser Turret";
        shapeFile = "camera";
        className = "Backpack";
      heading = "dDeployables";
        imageType = TurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function LaserTurretPack::onUse(%player,%item)
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

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
        if (LaserTurretPack::deployShape(%player,%item))
        {
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


function LaserTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableLaser",%num) + CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
							    %playerPos = GameBase::getPosition(%player);
							    %flag = $teamFlag[GameBase::getTeam(%player)];
							    %flagpos = %flag.originalposition;
							    if(Vector::getDistance(%flagpos, %playerpos) < 200)
							    {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("LaserTurret","Turret",DeployableLaser,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Laser Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
								echo("MSG: ",%client," deployed a Laser Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							    }	
							    else
							    {
							          Client::sendMessage(%client,1,"You may only deploy this near your base.~wError_Message.wav");
								    return false;
							    }
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other Laser turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other Laser turrets in the area");
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
//=============================Turret.cs Data================

TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
   validateShape = true;
   validateMaterials = true;
	projectileType = SniperLaser;
	maxDamage = 2.5;
	maxEnergy = 100;
	minGunEnergy = 1;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.35;
	speed = 4.0;
	speedModifier = 1.5;
	range = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaser::onAdd(%this)
{
	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
	}
}

function DeployableLaser::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaser::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);	// PORT: was LaserTurret::onDestroyed -- no such function
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}
function DeployableLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


//=======Even more Item.cs Data(Reinit data)=========
$TeamItemCount[0 @ LaserTurretPack] = 0;
$TeamItemCount[1 @ LaserTurretPack] = 0;
$TeamItemCount[2 @ LaserTurretPack] = 0;
$TeamItemCount[3 @ LaserTurretPack] = 0;
$TeamItemCount[4 @ LaserTurretPack] = 0;
$TeamItemCount[5 @ LaserTurretPack] = 0;
$TeamItemCount[6 @ LaserTurretPack] = 0;
$TeamItemCount[7 @ LaserTurretPack] = 0;
//====================================================
