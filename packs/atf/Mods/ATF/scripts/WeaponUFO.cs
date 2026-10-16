//--------------------------------------

$AutoUse[Ufo] = True;
$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 10;
$AmmoPackItems[6] = DiscAmmo;
$WeaponAmmo[Ufo] = DiscAmmo;

//--------------------------------------

$InvList[Ufo] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[Ufo] = 1;
$RemoteInvList[DiscAmmo] = 1;
//--------------------------------------


RocketData UfoMissile
{
   bulletShapeName = "Discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 30.5;
   kickBackStrength = 0;

   muzzleVelocity   = 10.0;
   terminalVelocity = 20.0;
   acceleration     = 50.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 0;                // smoke trail
   trailString = "disc.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};


MineData Frisbee
{
   mass = 0;
   drag = 10;
   density = 10;
	elasticity = 0.15;
	friction = 10;
	className = "HandGrenade";
   description = "Frisbee";
   shapeFile = "Shockwave_Large";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 30.0;
	damageValue = 0.9;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 1.5;
	maxDamage = 0.1;
};

//--------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData UfoImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = DiscAmmo;
	projectileType = UfoMissile;
	accuFire = false;
	reloadTime = 6.5;
	fireTime = 6.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundMortarIdle;
        soundId = SoundJetHeavy;
};


function UfoMissile::onAdd(%this)
{
	%startSlurping = 4.0;
	%boomTime = 20.0;
	for (%timeCounter=%startSlurping; %timeCounter <= %boomTime; %timeCounter = %timeCounter + 0.1)
	{ schedule("UfoMissile::VortexFun(" @ %this @ "," @ %timeCounter @ ");",%timeCounter,%this); }
	schedule("DeployUfoBomb(" @ %this @ " , 20);",5.0,%this);
}

function UfoMissile::VortexFun(%this, %timeCounter)
{
	%grenadePos=GameBase::getPosition(%this);
  	%grenadeSet=newObject("grendadeSet",SimSet);
	%numObjects=containerBoxFillSet(%grenadeSet,$SimPlayerObjectType | $VehicleObjectType,%grenadePos,70,70,70,0);
	for (%objCounter=0; %objCounter <= %numObjects; %objCounter++)
		{
		%target=Group::getObject(%grenadeSet, %objCounter);
		%targetPos=GameBase::getPosition(%target);

		%grenadeX=getWord(%grenadePos, 0);
		%grenadeY=getWord(%grenadePos, 1);
		%grenadeZ=getWord(%grenadePos, 2);
		%targetX=getWord(%targetPos, 0);
		%targetY=getWord(%targetPos, 1);
		%targetZ=getWord(%targetPos, 2);
		%wayPointOne=%grenadeX+(0-((%timeCounter-1.5)*0)) @ " " @ %grenadeY+(0-((%timeCounter-1.5)*0)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointTwo=%grenadeX+(0-((%timeCounter-1.5)*0)) @ " " @ %grenadeY-(0-((%timeCounter-1.5)*0)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointThree=%grenadeX-(0-((%timeCounter-1.5)*0)) @ " " @ %grenadeY-(0-((%timeCounter-1.5)*0)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointFour=%grenadeX-(0-((%timeCounter-1.5)*0)) @ " " @ %grenadeY+(0-((%timeCounter-1.5)*0)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";

		if(%targetX-%grenadeX>=0 && %targetY-%grenadeY>=0)
			%targetWayPoint=%wayPointTwo;
		if(%targetX-%grenadeX>=0 && %targetY-%grenadeY<0)
			%targetWayPoint=%wayPointThree;
		if(%targetX-%grenadeX<0 && %targetY-%grenadeY<0)
			%targetWayPoint=%wayPointFour;
		if(%targetX-%grenadeX<0 && %targetY-%grenadeY>=0)
			%targetWayPoint=%wayPointOne;

		%distanceToWayPoint=Vector::getDistance(%targetPos, %targetWayPoint);
		%force=1.9;
		%targetVector=Vector::sub(%targetWayPoint, %targetPos);
		%targetNewVector=getWord(%targetVector, 0) * %force @ " " @ getWord(%targetVector, 1) * %force @ " " @ getWord(Vector, 2) * %force @ " "; 
		Item::setVelocity(%target, %targetNewVector);
		}
		
	deleteObject(%grenadeSet);
}


function DeployUfoBomb(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
		%count -= 1;
		schedule("DeployUfoBomb(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

ItemData Ufo
{
	description = "Alien Object Launcher";
	className = "Weapon";
	shapeFile = "Disc";
	hudIcon = "mortar";
   heading = "cDisc Launchers";
	shadowDetailMask = 4;
	imageType = UfoImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function Ufo::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Alein Object Launcher was found after a battle on the planet of Atf'eron 3, if the disk is left to fly it will explode into another alien object......", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

function Frisbee::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Frisbee::Detonate(" @ %this @ ");",2.0,%this);
}

function Frisbee::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Frisbee::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
//--------------------------------------