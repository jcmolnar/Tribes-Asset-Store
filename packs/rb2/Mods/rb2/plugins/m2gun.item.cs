

//Deploy data
//Mounted machinegun

$ItemMax[hlarmor, HeavyMGpack] = 0;
$ItemMax[hlfemale, HeavyMGpack] = 0;
$ItemMax[larmor, HeavyMGpack] = 0;
$ItemMax[lfemale, HeavyMGpack] = 0;
$ItemMax[earmor, HeavyMGpack] = 1;
$ItemMax[efemale, HeavyMGpack] = 1;
$ItemMax[marmor, HeavyMGpack] = 0;
$ItemMax[mfemale, HeavyMGpack] = 0;
$ItemMax[harmor, HeavyMGpack] = 0;
$ItemMax[uharmor, HeavyMGpack] = 0;
$HelpMessage[HeavyMGpack] = "An extremely heavy machinegun.  Can only be deployed on a gun mount.";
$InvList[HeavyMGpack] = 1;
$RemoteInvList[HeavyMGpack] = 1;


// Deadtaco's super cool mounted machinegun

ItemImageData HeavyMGPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData HeavyMGPack
{
        description = "M2 Mounted Gun";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "fTurrets";
        imageType = HeavyMGPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
        price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HeavyMGPack::onUse(%player,%item)
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

function HeavyMGPack::onDeploy(%player,%item,%pos)
{
        if (HeavyMGPack::deployShape(%player,%item))
        {
		Player::decItemCount(%player,%item);
	}
}

function HeavyMGPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
			
			%objtype = Gamebase::getDataName($los::object);
			
			%objnumber = $los::object;
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = 0;
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = 0;
				deleteObject(%set);
				if(0 == %num) 
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6)
						%rot = "0 0 " @ %zRot;
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
							%rot = "3.14159 0 " @ %zRot;
						else
							%rot = Vector::getRotation($los::normal);
					}
					if(%objtype == "MountPointShape")
					{


						%turret = newObject("M2 Machinegun","Turret",DeployableChainguns,true);
						Client::sendMessage(%client,0,"Heavy machinegun deployed");

						addToSet("MissionCleanup", %turret);
						%offset = "0 0 0.7";
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,Vector::add($los::position, %offset));
						GameBase::setRotation(%turret,%rot);

						%mgpole = newObject("Machinegun Mount","StaticShape",hmgPole,true);
						addToSet("MissionCleanup", %mgpole);
						GameBase::setTeam(%mgpole,GameBase::getTeam(%player));
						%offset = "0 -0.2 0.3";
						GameBase::setPosition(%mgpole,Vector::add($los::position, %offset));
						GameBase::setRotation(%mgpole,"1.07 0 0");
						Gamebase::setMapName(%mgpole,"Machinegun Mount1");

						%mgpole = newObject("Machinegun Mount","StaticShape",hmgPole,true);
						addToSet("MissionCleanup", %mgpole);
						GameBase::setTeam(%mgpole,GameBase::getTeam(%player));
						%offset = "0.2 0.0 0.3";
						GameBase::setPosition(%mgpole,Vector::add($los::position, %offset));
						GameBase::setRotation(%mgpole,"1.07 0 1.75");
						Gamebase::setMapName(%mgpole,"Machinegun Mount2");

						%mgpole = newObject("Machinegun Mount","StaticShape",hmgPole,true);
						addToSet("MissionCleanup", %mgpole);
						GameBase::setTeam(%mgpole,GameBase::getTeam(%player));
						%offset = "0.0 0.2 0.3";
						GameBase::setPosition(%mgpole,Vector::add($los::position, %offset));
						GameBase::setRotation(%mgpole,"1.07 0 3.25");
						Gamebase::setMapName(%mgpole,"Machinegun Mount3");

						%mgpole = newObject("Machinegun Mount","StaticShape",hmgPole,true);
						addToSet("MissionCleanup", %mgpole);
						GameBase::setTeam(%mgpole,GameBase::getTeam(%player));
						%offset = "-0.2 0.0 0.3";
						GameBase::setPosition(%mgpole,Vector::add($los::position, %offset));
						GameBase::setRotation(%mgpole,"1.07 0 4.75");
						Gamebase::setMapName(%mgpole,"Machinegun Mount3");

						%turret.mgpole = %mgpole;
						%mgpole.turret = %turret;

						if (%objtype != "LAPC")
						{
						Gamebase::setMapName(%turret,"Heavy Machinegun");
						}


						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "HeavyMGPack"]++;
						echo("MSG: ",%client," deployed a heavy machinegun");

						//	Remote turrets - kill points to player that deploy them
						Client::setOwnedObject(%client, %turret); 
						Client::setOwnedObject(%client, %player);
						return true;
					}
					else
					Client::sendMessage(%client,0,"Can only be placed on a heavy machinegun mount.");
				}	 
				else
					Client::sendMessage(%client,0,"Can only be placed on a heavy machinegun mount.");
			}
			else 
				Client::sendMessage(%client,0,"Interference from other turrets in the area");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}


// ------------------------------------Turret--------------------------------------

//----------------------------------------------------------------------------
//---------------------------------------------------



StaticShapeData hmgPole
{
	description = "Heavy Gun Mount";
	shapeFile = "grenadel";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 8.55;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;

};


// HMGTurret
//---------------------------------------------------


BulletData HMGBullet 
{ 
	bulletShapeName = "bullet.DTS"; 
	explosionTag = BigbulletExp; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.8; 
	damageType = $BulletDmgType31;
 
	aimDeflection = 0.001; 
	muzzleVelocity = 1000; 
	totaltime = 3.0;  //change this value if you have a slow bullet.  Make it larger. 
	inheritedVelocityScale = 0.5; 
	isVisible = False; 
     	soundId = SoundJetHeavy;
	tracerPercentage = 0.3; 
	tracerLength = 10; 
}; 

BulletData HMGFlash 
{ 
	bulletShapeName = "rocket.DTS"; 
	explosionTag = BigbulletExp; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.0; 
	damageType = $BulletDmgType31;
 
	aimDeflection = 0.001; 
	muzzleVelocity = 0; 
	totaltime = 0.02;   
	inheritedVelocityScale = 0.0; 
	isVisible = true; 
 
	tracerPercentage = 0.3; 
	tracerLength = 10; 
}; 

BulletData HMGFlame
{ 
	bulletShapeName = "smoke.DTS"; 
	explosionTag = BigbulletExp; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.0; 
	damageType = $BulletDmgType31;
 
	aimDeflection = 0.001; 
	muzzleVelocity = 300; 
	totaltime = 0.05;   
	inheritedVelocityScale = 0.0; 
	isVisible = true; 
 
	tracerPercentage = 0.0; 
	tracerLength = 10; 
}; 

GrenadeData HMGShell
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bigbulletexp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.61;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PacificationDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 0;
   totalTime          = 1.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.5;

   inheritedVelocityScale = 2.5;

   smokeName              = "breath.dts";
};

function HMGFlash::onAdd(%this)
{
		%prot = GameBase::getRotation(%this);
		%zRot = getWord(%prot,2);

		%thisrot = GameBase::getRotation(%this);
		%thisxrot = getWord(%thisrot,0);
		%thisyrot = getWord(%thisrot,1);
	     // GameBase::setRotation(%this,%thisxrot @ " " @ %thisyrot @ " " @ %zrot);
		GameBase::setRotation(%this,"0 0 0");
}

TurretData DeployableChainguns
{
	className = "Turret";
	shapeFile = "remoteturret";
        // projectileType = HMGBullet;
	maxDamage = 5.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.1;
	speed = 4.0;
	speedModifier = 1.5;
        range = 1;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundDturretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "M2 Heavy Machinegun";
	damageSkinData = "objectDamageSkins";
};

function DeployableChainguns::onAdd(%this)
{
        schedule("DeployableChainguns::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
                GameBase::setMapName (%this, "M2 Machinegun");
	}
}

function DeployableChainguns::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableChainguns::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableChainguns::onCollision (%this, %object)
{
	if (getObjectType (%object) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%client = Player::getClient(%object);
			GameBase::setActive(%this,true);
		if(Client::getControlObject(%client) == %object)
		{
			echo("Client " @ %client @ " taking control of turret #" @ %this);
			Client::sendMessage(%client,0,"Controlling Turret. Press 'C' and move backwards, then C again to cease control.");
			Client::getOwnedObject(%client).CommandTag = 1;
			Client::takeControl(%client, %this);
			%this.Disabled = true;
			Client::getOwnedObject(%client).CommandTag = "";
		}
	}

}

function DeployableChainguns::Reenable(%this)
{
        %this.disabled = false;
}

function DeployableChainguns::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		%obj = newObject("","Mine","KamikazeBomb");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.0,false);


}

// Override base class just in case.
function DeployableChainguns::onPower(%this,%power,%generator)
{
}

function DeployableChainguns::onEnabled(%this) 
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	


function DeployableChainguns::onFire(%this, %slot)
{

  	%gunjam = floor(getRandom() * 200);

	%AmmoCount = GameBase::getEnergy(%this);

	%xrand = getRandom() * 2;
		 if (%AmmoCount >= 30)
		 {

                 GameBase::setRechargeRate(%this,10);



			//DEADTACO'S UBER-COOL MUZZLE FLASH ON THE M2 MACHINEGUN

		 playSound(SoundDturretFire,GameBase::getPosition(%this));
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 GameBase::setEnergy(%this, 29);

		if (%gunjam == 50)
		{
			GameBase::setEnergy(%this, 0);
			%client = GameBase::getControlClient(%this);
			bottomprint(%client,"The gun jammed!  Working on unjamming it...", 3);
			GameBase::setRechargeRate(%this,4);

		}
		 Projectile::spawnProjectile("HMGBullet",%trans,%this,"0 0 0");
		 Projectile::spawnProjectile("HMGFlash",%trans,%this,"0 0 0");

		 }
}

//---------------------------------------------------

