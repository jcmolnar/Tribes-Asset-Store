//--------------------------------------

$AutoUse[LF] = True;
$SellAmmo[MortarAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackItems[6] = MortarAmmo;
$WeaponAmmo[LF] = MortarAmmo;

//--------------------------------------

$InvList[LF] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[LF] = 1;
$RemoteInvList[MortarAmmo] = 1;

//--------------------------------------
ExplosionData SCloudExp
{
   shapeName = "flash_large.dts";
   soundId   = SoundFireGrenade;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeScale = 30.0;
   timeZero = 0.25; //0.0;
   timeOne  = 0.65; //0.5;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

MineData Bomb1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "Frisbee";
   shapeFile = "Grenade";
   shadowDetailMask = 4;
   explosionId = MortarExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};



MineData Bomb2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "HaCk";
   shapeFile = "Grenade";
   shadowDetailMask = 4;
   explosionId = MortarExp;
	explosionRadius = 15.0;
	damageValue = 1;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

GrenadeData LFSHELL
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 200;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "PlasmaEx.dts";
};


//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData LFImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = LFShell;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function LFShell::onAdd(%this)
{
	schedule("DeployBomb2(" @ %this @ " , 5);",1.0,%this);
}

function DeployBomb2(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
                                %obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
		%obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
                                %obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
		%obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
                                %obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
		%obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
                                %obj = newObject("","Mine","Bomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
		
		%obj = newObject("","Mine","Bomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-9,True);
			
                %count -= 1;
		schedule("DeployBomb2(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}


ItemData LF
{
	description = "Multi Boom";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = LFImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function LF::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The Multi Boom is a single shell jam packed with smaller bombs with highly compressed explosives. Proven to be one of the best weapons against Goliaths", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
$AutoUse[SK] = True;
$SellAmmo[SmokeAmmo] = 5;
$AmmoPackMax[SmokeAmmo] = 10;
$AmmoPackItems[6] = SmokeAmmo;
$WeaponAmmo[SK] = SmokeAmmo;

//--------------------------------------

$InvList[SK] = 1;
$InvList[SmokeAmmo] = 1;
$RemoteInvList[SK] = 1;
$RemoteInvList[SmokeAmmo] = 1;

//--------------------------------------
MineData SmokeBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "HandGrenade";
   description = "Smoke";
   shapeFile = "Tumult_Small";
   shadowDetailMask = 4;
   explosionId = SCloudExp;
	explosionRadius = 10.0;
	damageValue = 0.01;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

GrenadeData SmokeShell
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = SCloudExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 200;
   totalTime          = 6.0;    // special meaning for grenades...
   liveTime           = 6.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "Tumult_Small.dts";
};


//--------------------------------------

ItemData SmokeAmmo
{
	description = "Smoke Shells";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "Breath";
	shadowDetailMask = 4;
	price = 35;
};

ItemImageData SKImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SmokeAmmo;
	projectileType = SmokeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundDryfire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function SmokeShell::onAdd(%this)
{
	schedule("DeployBomb3(" @ %this @ " , 5);",5.0,%this);
}

function DeployBomb3(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
                                %obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,True);
		%obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,True);
                                %obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-4,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,True);
		%obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,7,True);
                                %obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-8,True);
		%obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-4,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,True);
                                %obj = newObject("","Mine","SmokeBomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2,True);
		
		%obj = newObject("","Mine","SmokeBomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,True);
                %count -= 1;
		schedule("DeployBomb3(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}


ItemData SK
{
	description = "Mass Smoker";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = SKImage;
	price = 395;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function SK::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Mass Smoker, Fires a projectile that creates a large amount of smoke", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------