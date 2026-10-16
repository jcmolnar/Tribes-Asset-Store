//--------------------------------------

$SellAmmo[BF2] = 5;
$AmmoPackMax[BF2] = 10;
$AmmoPackItems[4] = B1;

//--------------------------------------

$InvList[BF2] = 1;
$RemoteInvList[BF2] = 1;

//--------------------------------------

ItemData BF2
{
   description = "Enemy Displacer Bomb";
   shapeFile = "Magcargo";
   heading = "rHaCk's Tools";
   hudIcon = "sniper";   
   shadowDetailMask = 4;
   price = 500;
	className = "HandAmmo";
   showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function BF2::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","B2");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData B2
{
   mass = 3;
   drag = 1.0;
   density = 3.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "Enemy Displacer Bomb";
   shapeFile = "MagCargo";
   shadowDetailMask = 4;
   explosionId = FlashExpLarge;
	explosionRadius = 300.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 2000;
	triggerRadius = 0.5;
	maxDamage = 9;
};

function B2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",20.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.02;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
	
}

//--------------------------------------

$AutoUse[AS] = True;
$WeaponAmmo[AS] = "";

//--------------------------------------

$InvList[AS] = 1;
$RemoteInvList[AS] = 1;

//--------------------------------------

LaserData ASLaser
{
   laserBitmapName   = "ForceField.bmp";
   hitName           = "plasmaex.dts";

   damageConversion  = 0.03;
   baseDamageType    = $ShockDamageType;

   beamTime          = 8.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = True;
   hitSoundId        = SoundTankCrash;
};

//--------------------------------------

ItemImageData ASImage
{
	shapeFile = "PaintGun";
	mountPoint = 0;
                 mountoffset = { 0, 0, -0.1 };
                 mountrotation = { 0, 2.3, 0 };
	weaponType = 0; // Single Shot
	projectileType = ASLaser;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 2;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AS
{
	description = "Neutron Beam";
	className = "Weapon";
	shapeFile = "PaintGun";
	hudIcon = "sniper";
   heading = "h:(Snipers Gear:(";
	shadowDetailMask = 4;
	imageType = ASImage;
	price = 30;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

//--------------------------------------
function AS::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Hmmm...even though this gun has little damage to it....it still has plenty of uses...try finding what you can do with it", 10);Weapon::onUse(%player,%item);
}
//---------------------------

LaserData ASLaser2
{
   laserBitmapName   = "ForceField.bmp";
   hitName           = "laserpulse.dts";

   damageConversion  = 0.03;
   baseDamageType    = $PhantomDamageType;

   beamTime          = 2.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = False;
   hitSoundId        = SoundTankActive;
};


ItemImageData ASImage2
{
	shapeFile = "PaintGun";
	mountPoint = 0;
                 mountoffset = { 0, 0, -0.1 };
                 mountrotation = { 0, 2.3, 0 };
	weaponType = 0; // Single Shot
	projectileType = ASLaser2;
	accuFire = true;
	reloadTime = 0;
	fireTime = 1.0;
	minEnergy = 2;
	maxEnergy = 3;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AS2
{
	description = "Phantom Beam";
	className = "Weapon";
	shapeFile = "PaintGun";
	hudIcon = "sniper";
   heading = "h:(Snipers Gear:(";
	shadowDetailMask = 4;
	imageType = ASImage;
	price = 30;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

//--------------------------------------
function AS2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Phantom Beam, that turns whoever touches it into a ghost for a little while....", 10);Weapon::onUse(%player,%item);
}
//---------------------------