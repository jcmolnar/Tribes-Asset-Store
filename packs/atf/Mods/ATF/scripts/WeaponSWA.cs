//--------------------------------------

$AutoUse[SWA] = True;
$SellAmmo[GAmmo] = 5;
$AmmoPackMax[GAmmo] = 30;
$AmmoPackItems[1] = GAmmo;
$WeaponAmmo[SWA] = GAmmo;


//--------------------------------------

$InvList[SWA] = 1;
$InvList[GAmmo] = 1;
$RemoteInvList[SWA] = 1;
$RemoteInvList[GAmmo] = 1;
$InvList[SentinelAmmo] = 1;
$RemoteInvList[SentinelAmmo] = 1;
//--------------------------------------
RocketData SWAWave
{
   bulletShapeName    = "Shield_large.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 60.0;
   acceleration     = 50.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_medium.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

RocketData Bullet4
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = Turretexp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.00;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 530.0;

   muzzleVelocity   = 650.0;
   terminalVelocity = 700.0;
   acceleration     = 30.0;

   totalTime        = 8.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Rsmoke.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};
//--------------------------------------


ItemData GAmmo
{
	description = "G. Objects";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 200;
};



ItemImageData SWAImage
{
	shapeFile = "MortarGun";
	mountPoint = 0;
	mountoffset = { 0, 0, -0.2 };
                mountrotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	ammoType = GAmmo;
	projectileType = Alicia;
	accuFire = true;
	reloadTime = 0.2;
	SpinupTime = 0.5;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
                sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
                sfxReady = SoundTankIdle;
};


ItemData SentinelAmmo
{
	description = "Sentinel Ammo";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};


function SWAImage::onFire(%player, %this) 
{
				

				%client = Player::getClient(%player);
				
				Player::decItemCount(%player,$WeaponAmmo[SWA],1);
				%Sensor3 = newObject("Camera","Turret",RocketTurret3,true); 
	   			addToSet("MissionCleanup", %sensor3);
				gameBase::setRotation(%sensor3,"0 0 0");// %rot
				gameBase::setPosition(%sensor3,GameBase::getPosition(%player));
				gamebase::setMapName(%sensor3,"GrappleObject#" @ $totalNumGobjects++ @ " " @  Client::getName(%client));
				client::sendMessage(%client,3,"G Object Placed");
				playSound(SoundPickupBackpack,$los::position);
				
	
}



ItemData SWA
{
	description = "G.Object Placer";
	className = "Weapon";
	shapeFile = "MortarGun";
	hudIcon = "plasma";
   heading = "rHaCk's Tools";
	shadowDetailMask = 4;
	imageType = SWAImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function SWA::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The G.Object Placer places G.Object.....what the HELL is a G.Object!!! It doesn't seem to do anything....", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

$AutoUse[SWA2] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[SWA2] = PlasmaAmmo;

//--------------------------------------

$InvList[SWA2] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[SWA2] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------
RocketData SWAWavePh
{
   bulletShapeName    = "Paint.dts";
   explosionTag       = shockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.1;
   damageType       = $PhantomDamageType;

   explosionRadius  = 3.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 160.0;
   acceleration     = 150.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

//--------------------------------------


ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SWA2Image
{
	shapeFile = "Sniper";
	mountPoint = 0;
	mountoffset = { 0, 0, -0.2 };
                mountrotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = SWAWavePh;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
                sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
                sfxReady = SoundTankIdle;
};

ItemData SWA2
{
	description = "Phoenix Rifle";
	className = "Weapon";
	shapeFile = "MortarGun";
	hudIcon = "plasma";
   heading = "h:(Snipers Gear:(";
	shadowDetailMask = 4;
	imageType = SWA2Image;
	price = 875;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function SWA2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Phoenix Rifle was invented by the Famous scientist Phoenix88...she prides this weapon to be the strongest sniper rifle out there...so strong that upon impact it still does damage a few feet away...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------