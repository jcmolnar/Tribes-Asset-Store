//================================================================
//Assassin Turret
//================================================================
$InvList[AssassinTurretPack] = 1;
$RemoteInvList[AssassinTurretPack] = 1;
//=======================================================
$DamageScale[larmor, $DepturRaptorDamageType] = 5.0;
$DamageScale[lfemale, $DepturRaptorDamageType] = 5.0;
$DamageScale[marmor, $DepturRaptorDamageType] = 5.0;
$DamageScale[mfemale, $DepturRaptorDamageType] = 5.0;
$DamageScale[harmor, $DepturRaptorDamageType] = 5.0;
//================================================================	
$ItemMax[larmor, AssassinTurretPack] = 0;
$ItemMax[lfemale, AssassinTurretPack] = 0;
$ItemMax[marmor, AssassinTurretPack] = 0;
$ItemMax[mfemale, AssassinTurretPack] = 0;
$ItemMax[harmor, AssassinTurretPack] = 1;
//================================================================
$TeamItemMax[AssassinTurretPack] = 1;
//================================================================
SoundData SoundTurRaptor
{
   wavFileName = "deptur_raptor.wav";
   profile = Profile3dMed;
};
//================================================================
//================================================================
RocketData TurretRaptorproj
{
	bulletShapeName = "proj_raptor.dts";
	explosionTag = IXSniperExp;

	collisionRadius = 0.0;
	mass = 2.0;

	damageClass = 0;
	damageValue = 3;
	damageType = $DepturRaptorDamageType;
	explosionRadius = 0.5;
	kickBackStrength = 150.0;

	muzzleVelocity = 100.0;
	terminalVelocity = 500.0;
	acceleration = 300.0;
	totalTime = 4.0;
	liveTime = 5.0;

	lightRange = 5.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;

	trailType = 1;
	trailLength = 25;
	trailWidth = 0.35;
	//soundId = SoundWhizRaptor;
};
//================================================================
ItemImageData AssassinTurretPackImage
{
        shapeFile = "deptur_raptor";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData AssassinTurretPack
{
        description = "Assassin Turret";
        shapeFile = "deptur_raptor";
        className = "Backpack";
      heading = "LTurrets";
        imageType = AssassinTurretPackImage;
        shadowDetailMask = 4;
        mass = 3.0;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function AssassinTurretPack::onUse(%player,%item)
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

function AssassinTurretPack::onDeploy(%player,%item,%pos)
{
        if (AssassinTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function AssassinTurretPack::deployShape(%player,%item)
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

                                                        %turret = newObject("AssassinTurret","Turret",AssassinTurret,true);
                                                                addToSet("MissionCleanup", %turret);
                                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%turret,$los::position);
                                                        GameBase::setRotation(%turret,%rot);
                                                        Gamebase::setMapName(%turret,"Flame Turret " @ Client::getName(%client));


                                                        %backward = Vector::neg(Vector::getFromRot(%rot, 0.8));//meaning backwards a little bit.

                                                        GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
                                                        GameBase::setRotation(%cyl,%rot);
                                                        Gamebase::setMapName(%cyl,"AssassinTurret");

                                                        %turret.cyl = %cyl;
                                                        %cyl.turret = %turret;

                                                        Client::sendMessage(%client,0,"Assassin Turret deployed");
                                                        playSound(SoundPickupBackpack,$los::position);
                                                        $TeamItemCount[GameBase::getTeam(%player) @ "AssassinTurretPack"]++;
                                                        echo("MSG: ",%client," deployed an Assassin Turret");
                                                        //        Remote turrets - kill points to player that deploy them
                                                        // Client::setOwnedObject(%client, %turret);
                                                        // Client::setOwnedObject(%client, %player);

                                                        if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
                                                        {
                                                                GameBase::setDamageLevel(%turret, 0.7 * AssassinTurret.maxDamage);
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
//-------------------------------------------------------------------------------------------------------------------
TurretData AssassinTurret
{
	className = "Turret";
	shapeFile = "deptur_raptor";
	projectileType = TurretRaptorproj;
	maxDamage = 3;
	maxEnergy = 30;
	minGunEnergy = 3;
	maxGunEnergy = 2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.75;
	speed = 2.0;
	speedModifier = 2.0;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundTurRaptor;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Assassin Turret";
	damageSkinData = "objectDamageSkins";
};

function AssassinTurret::onAdd(%this)
{
	schedule("AssassinTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "AssassinTurret");
	}
}

function AssassinTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AssassinTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AssassinTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "AssassinTurretPack"]--;
	GameBase::setDamageLevel(%this.cyl, 0.6);
}

// Override base class just in case.
function AssassinTurret::onPower(%this,%power,%generator) {}
function AssassinTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//================================================================