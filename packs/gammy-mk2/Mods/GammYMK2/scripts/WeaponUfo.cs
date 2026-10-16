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
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

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
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "Frisbee";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData HG
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "Heavy Grenade";
   shapeFile = "Rocket";
   shadowDetailMask = 4;
   explosionId = AcidExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
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
        soundId = SoundJetHeavy;
};

function UfoMissile::onAdd(%this)
{
	schedule("DeployUfoBomb(" @ %this @ " , 20);",5.0,%this);
}

function DeployUfoBomb(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4,True);
		
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,True);
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4,True); 
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,True);
		
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,7,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,8,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,10,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,11,True);
		%obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,10,True);
                %obj = newObject("","Mine","Frisbee");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9,True);                 
		%count -= 1;
		schedule("DeployUfoBomb(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

ItemData Ufo
{
	description = "Mini Ufo Spawner";
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
	bottomprint(Player::getClient(%player), "If the Mini Ufo Spawner Disc is left to fly it will explode into Multiple UFO Grenades:) (Wheeps Wht a Site).......", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------