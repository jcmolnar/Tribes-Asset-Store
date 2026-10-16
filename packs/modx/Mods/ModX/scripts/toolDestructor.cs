// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$ItemMax[larmor,Destructor]	= 1;
$ItemMax[lfemale,Destructor]	= 1;

AddWeapon(Destructor);
AddToInv(Destructor);

RepairEffectData destBolt
{
	bitmapName = "repairAdd.bmp";//"lightningNew.bmp"; //"antgrv04.bmp"; //"chainflash1.bmp"; //"lightningNewSub.bmp"; //"grn_blink4.bmp";//lightningNewSub.bmp";//lightningTemp.bmp";//fx_lensflare_5.bmp";//cphoenix.flag.bmp";	//grn_blink4.bmp";	//mort0000.bmp";	//repairadd.bmp";
	boltLength = 150;

	segmentDivisions = 0;
	beamWidth = 0.015;
	updateTime = 450;	//how fast beam oscilates
	skipPercent = 0.0001;	//0.6
	displaceBias = 0.15;	//0.15 //displaced side to side
	//lightRange = 3.0;
	//lightColor = { 0.85, 0.25, 0.25 };
    //lightRange = 3.0;
    //lightColor = { 0.85, 0.25, 0.25 };
};



ItemImageData DestructorImage
{
	shapeFile = "sniper"; //"mortargun";	//"tracer";
	//mountPoint = 0;
	//mountOffset = { -0.1, -0.3, -0.1 };
	//mountRotation = {0, 1.57, 0};
	mountPoint		= 0;
    mountRotation = { 0, 0.785, 0 };
    mountOffset = { 0, 0, 0 };
    
    weaponType = 0; // SingleShot
	//projectileType = Invalid;

    //spinUpTime = 0.0;
    //spinDownTime = 0.0;
    //fireTime = 0.0;
    accuFire = true;
    
	minEnergy = 3;
	maxEnergy = 0; //8 Energy used/sec for sustained weapons
	reloadTime = 0.2;
	//lightType = 3; // Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
    //lightColor = { 0.85, 0.25, 0.25 };
    sfxActivate		= SoundPickUpWeapon;
    //sfxReady = SoundJammerOn;
	//sfxActivate = SoundActivateAmmoStation;
	sfxFire = SoundPackUse;
};

ItemData Destructor
{
	description   = "Object Deletor";
	className     = "Tool";
	shapeFile     = "sniper";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType     = DestructorImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData Dest1Image
{
	shapeFile = "sensor_small";
	mountPoint = 0;
	mountOffset = { -0.1, -0.3, -0.1 };
	mountRotation = {0, 1.57, 0};
	weaponType = 0;
};

ItemData Dest1
{
	description = "--";
	className = "Weapon";
	shapeFile = "sensor_small";
	//hudIcon = "sniper";
	heading = "zInvalid";
	shadowDetailMask = 4;
	imageType = Dest1Image;
	price = 0;
	showWeaponBar = false;
};

function Destructor::onMount(%player,%item)
{
    Weapon::CompleteMount(%player,%item);
}

function Destructor::MountExtras(%player)
{
    Player::mountItem(%player,Dest1,7);
}

function Destructor::onUnmount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function DestructorImage::onFire(%player)
{
    %clientId = Player::getclient(%player);
    if(%clientId.CannotDeploy == true)
    {
        Client::sendMessage(%clientId,1,"Your tool-usage priviliges have been disabled.~waccess_denied.wav");
        return;
    }
    Destructor::DeleteGrab(%player);
}

function Destructor::DeleteGrab(%player)
{
   %ClientId = player::getclient(%player);
   %range = 100;

   if(GameBase::getLOSInfo(%player,%range))
   {
      %TempObj = $los::object;
      if(isObject(%TempObj) == false || %TempObj == "" || %TempObj.Del == true)
          return;
      %type = getObjectType(%TempObj);

    if(WorkingLayer::isInLayerScope(%clientId, %TempObj) == false)
    {
        bottomprint(%clientid,"<jc>Object Deletor: <f2>Object in non-active layer");
        return;
    }

      if (%type == "SimTerrain" || %type == "Player" || %type == "Flier")
      {
         bottomprint(%clientid,"<jc>Object Deletor: <f2>Nothing in range");
         if(!Player::isAiControlled(%TempObj))
            return;
      }
      
    if (%type != %ClientId.deltype && %ClientId.deltype != "all")
    {
        bottomprint(%clientid,"<jc>Object Deletor: <f2>Nothing in range");
        return;
    }

      %target = %TempObj;
      
    %targetMapName = GameBase::getMapName(%target);
    if (%targetMapName == "")
       %targetMapName = %target.Desc;
    if (%targetMapName == "")
       %targetMapName = "Object ID " @ %target;
    %succmsg = "\"Object Deleted: " @ escapeString(%targetMapName) @ "\""; // PORT: the map name holds the owner's player name

    if (%target.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
    {
       if (%target.Owner != "" || BuildGroup::IsInGroup(%clientId, %TempObj.Owner.buildgroup)) // If its not a mission obj or in same group, it's someone elses
          return;
    }

    //if(Player::isAiControlled(%TempObj))
    //    $DummyNumber[%target.Owner]--;

    if(%target.DontDel == true)
        return;

    if(%target.weld)
    {
        if(%target.weld == true)
        {
            bottomprint(%clientid,"<jc>Object Deletor: <f2>Object welded into place");
            return;
        }
    }

    if(%clientId.CurDelMode == 1)
    {
        NukeIt(%target, %player);
    }

    %TgtClientId = %target.Owner;

    if(%TgtClientId != "" || %TgtClientId != false || %TgtClientId != -1 || %target.Owner != "Aba")
    {
        %isCl = true;
        RemoveFromObjIndex(%TgtClientId, %target);

    }


    GameBase::setTeam(%target, -1);
    %target.Del = true;
    GameBase::setActive(%target, false);
    GameBase::generatePower(%target, false);
    schedule("Client::sendMessage(" @ %clientId @ ",0," @ %succmsg @ ");", 0.1, %target);
    schedule("deleteObject(" @ %target @ ");", 0.1, %target);
    
    if(GameBase::getDataName(%target).className != "ModXElevator")
    {
        if(isObject(%target.Child))
        {
            $TotalDeploys--;
            deleteObject(%target.Child);
            %target.Child = "";
        }
        if(isObject(%target.Mother))
        {
            $TotalDeploys--;
            deleteObject(%target.Mother);
            %target.Mother = "";
        }
    }
    else
    {
        for(%i = 0; isObject(%target.Child[%i]) != false; %i++)
        {
            $TotalDeploys--;
            deleteObject(%target.Child[%i]);
            %target.Child[%i] = "";
        }
    }
    
    %target.DontMove = true;
    %target.DontWeld = true;
    return;
   }
   bottomprint(%clientid,"<jc>Object Deletor: <f2>Nothing in range");
}

$DelMode::[0] = "Normal Deletion";
$DelMode::[1] = "Nuke Explosion Deletion";
$DelMode::[2] = "Radius Deletion";  //TO DO!

ExplosionData WickedBadExp
{
   shapeName = "mortarex.dts";//fiery
   soundId   = rocketExplosion;


	faceCamera=true;
	randomSpin = true;
	hasLight=true;
	lightRange=9.0;
	timeZero=0.300;
	timeOne=0.900;
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;


};

RocketData BabyNukeBomb
{
   bulletShapeName = "Shockwave_Large.dts";
   explosionTag    = WickedBadExp;

   collisionRadius = 3.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 0.0;

   muzzleVelocity   = 165.0;
   terminalVelocity = 180.0;
   acceleration     = 15.0;

   totalTime        = 0.1;
   liveTime         = 0.1;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

GrenadeData BabyNukeBomb::old
{	bulletShapeName = "Shockwave_Large.dts";
	explosionTag = WickedBadExp;	//LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;	2.2 -plas
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1;
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 6;
	liveTime = 6;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "paint.dts";
};

function BabyNukeBomb::onAdd(%this)
{}

MineData BombHalo
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Halo";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function BombHalo::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);	//0.2
}

function BombHalo(%this)
{
	%obj = newObject("","Mine","BombHalo");
	addToSet("MissionCleanup", %obj);
	//GameBase::throw(%obj,%this,1 ,false);
	//%pos = Vector::add(GameBase::getPosition(%this), "0 0 2");
	//GameBase::setPosition(%obj, %pos);
}


function NukeIt(%obj, %player)
{
	%trans = GameBase::GetMuzzleTransform(%player);//GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
    //echo("TRANS: "@%trans);
    //echo("PTRAN: "@GameBase::GetMuzzleTransform(%player));
    Projectile::spawnProjectile("BabyNukeBomb",%trans,%player,%vel,%player);
		for(%i=0; %i < 6.28; %i += 1.256)
		{
			%forceVel = Vector::getFromRot("0 0 " @ %i, 15, 40);
			%bomb = Projectile::spawnProjectile("NukeExplosion4",%trans,%player,%vel,%player);
			%bomb.forceVel = %forceVel;
		}
		%bomb = Projectile::spawnProjectile("NukeExplosion4",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 50";
		%bomb = Projectile::spawnProjectile("NukeExplosion3",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 40";
		%bomb = Projectile::spawnProjectile("NukeExplosion2",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 35";
		%bomb = Projectile::spawnProjectile("NukeExplosion2",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 30";
		%bomb = Projectile::spawnProjectile("NukeExplosion1",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 25";
		%bomb = Projectile::spawnProjectile("NukeExplosion1",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 20";
		%bomb = Projectile::spawnProjectile("NukeExplosion1",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 15";
		%bomb = Projectile::spawnProjectile("NukeExplosion0",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 10";
		%bomb = Projectile::spawnProjectile("NukeExplosion0",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 5";
}
function NukeExplosion0::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeExplosion1::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeExplosion2::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeExplosion3::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
	schedule("BombHalo(" @ %this @ ");",5.45);
}
function NukeExplosion4::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeSpread(%this)
{
	%forceVel = %this.forceVel;
	//%pos = Vector::add(GameBase::getPosition(%this), %padd);
	//GameBase::setPosition(%this, Vector::add(GameBase::getPosition(%this), "0 0 0.5"));
	Item::setVelocity(%this, %forceVel);

}


SoundData NukeWind
{
	wavFileName = "wind1.wav";
	profile = Profile3dLudicrouslyFar;
};
ExplosionData NukeCrownExp
{
   shapeName = "mortarex.dts";//fiery
   soundId   = NukeWind;


	faceCamera=true;
	randomSpin = true;
	hasLight=true;
	lightRange=9.0;
	timeZero=0.300;
	timeOne=0.900;
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;


};
SoundData NukeSound
{
	wavFileName = "turretexp.wav";
	profile = Profile3dLudicrouslyFar;
};
ExplosionData NukeExp
{
   shapeName = "mortarex.dts";//fiery
   soundId   = NukeSound;


	faceCamera=true;
	randomSpin = true;
	hasLight=true;
	lightRange=9.0;
	timeZero=0.300;
	timeOne=0.900;
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;


};


GrenadeData NukeExplosion0
{	bulletShapeName = "breath.dts";
	explosionTag = NukeExp;	//WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;	//1
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 0.01;
	liveTime = 0.01;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	   smokeName              = "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion1
{	bulletShapeName = "breath.dts";
	explosionTag = WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 0.15;
	liveTime = 0.15;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	   smokeName              = "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion2
{	bulletShapeName = "breath.dts";
	explosionTag = 	NukeCrownExp;	//WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.75;	//1
	damageType = $ShrapnelDamageType;
	explosionRadius = 60.0;	//40.0;
	kickBackStrength = 250;	//100.0;
	maxLevelFlightDist = 350;
	totalTime = 0.30;
	liveTime = 0.30;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	   smokeName              = "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion3
{	bulletShapeName = "breath.dts";
	explosionTag = NukeCrownExp;	//WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;	//1
	damageType = $ShrapnelDamageType;
	explosionRadius = 100.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 0.45;
	liveTime = 0.45;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	   smokeName              = "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion4
{	bulletShapeName = "breath.dts";
	explosionTag = NukeCrownExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 0.6;
	liveTime = 0.6;
	projSpecialTime = 10.0;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	   smokeName   = "breath.dts";	//plastrail.dts";//mortartrail
};
