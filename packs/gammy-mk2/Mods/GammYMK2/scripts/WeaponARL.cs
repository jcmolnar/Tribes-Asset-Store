//--------------------------------------

$AutoUse[ARL] = True;
$SellAmmo[MortarAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackItems[6] = MortarAmmo;
$WeaponAmmo[ARL] = MortarAmmo;

//--------------------------------------

$InvList[ARL] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[ARL] = 1;
$RemoteInvList[MortarAmmo] = 1;

//--------------------------------------

GrenadeData BomberShell
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.01;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 550;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
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

ItemImageData ARLImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = BomberShell;
	accuFire = false;
	reloadTime = 0.5;
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

function BomberShell::onAdd(%this)
{
	schedule("DeployBomblets(" @ %this @ " , 5);",1.0,%this);
}

function DeployBomblets(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
		
		%obj = newObject("","Mine","AntiPersonelMine");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,True);
		%obj = newObject("","Mine","HandGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
		%obj = newObject("","Mine","AntiPersonelMine");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6,True);
		%obj = newObject("","Mine","HandGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,8,True);
		%obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
		%obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6,True);
		
		%obj = newObject("","Mine","AntiPersonelMine");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4,True);
		%obj = newObject("","Mine","HandGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,True);
		%obj = newObject("","Mine","AntiPersonelMine");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,True);
		%obj = newObject("","Mine","HandGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,7,True);
		%obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
		                              
%count -= 1;
		schedule("DeployBomblets(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

ItemData ARL
{
	description = "Mister Death";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = ARLImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function ARL::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The Mister Death drops explosives when it is about to explode to make a nice Nuke effect.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
$AutoUse[LF2] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 10;
$AmmoPackItems[6] = PlasmaAmmo;
$WeaponAmmo[LF2] = PlasmaAmmo;

//--------------------------------------

$InvList[LF2] = 1;
$InvList[EnergyAmmo] = 1;
$RemoteInvList[LF2] = 1;
$RemoteInvList[EnergyAmmo] = 1;

//--------------------------------------

MineData Sparkle
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "HaCk2";
   shapeFile = "Paint";
   shadowDetailMask = 4;
   explosionId = PlasmaExp;
	explosionRadius = 15.0;
	damageValue = 1;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Sparkle::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",4.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


GrenadeData LF2SHELL
{
   bulletShapeName    = "Fusionex.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 200;
   totalTime          = 8.0;    // special meaning for grenades...
   liveTime           = 8.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "EnEx.dts";
};


//--------------------------------------
ItemImageData LF2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = LF2Shell;
	accuFire = false;
	reloadTime = 0.5;
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

function LF2Shell::onAdd(%this)
{
	schedule("DeploySparkle(" @ %this @ " , 5);",1.0,%this);
}

function DeploySparkle(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Sparkle");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
		
		%obj = newObject("","Mine","Sparkle");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
                                %obj = newObject("","Mine","Sparkle");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
		
		%obj = newObject("","Mine","Sparkle");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
		%obj = newObject("","Mine","Sparkle");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,True);
		
		%obj = newObject("","Mine","Sparkle");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,True);
                                %obj = newObject("","Mine","Sparkle");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,True);
		
		
                
		%count -= 1;
		schedule("DeploySparkle(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}


ItemData LF2
{
	description = "Death's Mini ME";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = LF2Image;
	price = 575;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function LF2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " Death's Mini ME is a single ball of energy that lets out many plasma like energy bombs. ", 10);Weapon::onUse(%player,%item);
}