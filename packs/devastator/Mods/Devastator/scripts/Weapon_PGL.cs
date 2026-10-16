//--------------------------------------

GrenadeData PGLShot1
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ProtonDamageType;

   explosionRadius    = 7;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "fusionbolt.dts";
};

//--------------------------------------

GrenadeData PGLShot2
{
   bulletShapeName    = "MortarTrail.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ProtonDamageType;

   explosionRadius    = 5;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "Mortartrail.dts";
};

ItemImageData PGL1Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { -0.08, 0, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -3.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData PGL1
{
	description = "PGL1";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = PGL1Image;
	showWeaponBar = false;
};

ItemImageData PGL2Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { 0.08, 0, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData PGL2
{
	description = "PGL2";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = PGL2Image;
	showWeaponBar = false;
};

//----------------------------------------------------------------------------

ItemData PGLAmmo
{
	description = "Proton Grenades";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PGLImage
{
	shapeFile = "GrenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PGLAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PGL
{
	description = "Proton Gren. Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenadeL";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = PGLImage;
	price =   50;
	showWeaponBar = true;
};

function PGL::onMount(%player,%item)
{
	Player::mountItem(%player, PGL1, 6);
	Player::mountItem(%player, PGL2, 7);
}

function PGL::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}


function PGLImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[PGL]);
	if(%AmmoCount > 0)
	{
		%client = player::getclient(%player);
		%clientName = client::GetName(%client);
		%trans = GameBase::getMuzzleTransform(%player); 
		%vel = Item::getVelocity(%player); 
		Weapon::onFire(%player,PGLShot1);
		Weapon::onFire(%player,PGLShot2,False);
	}
}


//--------------------------------------------------------------------------------
// INVENTORY STUFF
//--------------------------------------------------------------------------------

$AutoUse[PGL] = True;
$InvList[PGL] = 1;
$InvList[PGLAmmo] = 1;
$RemoteInvList[PGL] = 1;
$RemoteInvList[PGLAmmo] = 1;

$ItemMax[larmor, PGL] = 0;
$ItemMax[larmor, PGLAmmo] = 0;
$ItemMax[qarmor, PGL] = 1;
$ItemMax[qarmor, PGLAmmo] = 10;
$ItemMax[sarmor, PGL] = 0;
$ItemMax[sarmor, PGLAmmo] = 0;
$ItemMax[srarmor, PGL] = 0;
$ItemMax[srarmor, PGLAmmo] = 0;
$ItemMax[marmor, PGL] = 0;
$ItemMax[marmor, PGLAmmo] = 0;
$ItemMax[parmor, PGL] = 0;
$ItemMax[parmor, PGLAmmo] = 0;
$ItemMax[tarmor, PGL] = 0;
$ItemMax[tarmor, PGLAmmo] = 0;
$ItemMax[harmor, PGL] = 0;
$ItemMax[harmor, PGLAmmo] = 0;
$ItemMax[lfemale, PGL] = 0;
$ItemMax[lfemale, PGLAmmo] = 0;
$ItemMax[qfemale, PGL] = 1;
$ItemMax[qfemale, PGLAmmo] = 10;
$ItemMax[sfemale, PGL] = 0;
$ItemMax[sfemale, PGLAmmo] = 0;
$ItemMax[srfemale, PGL] = 0;
$ItemMax[srfemale, PGLAmmo] = 0;
$ItemMax[mfemale, PGL] = 0;
$ItemMax[mfemale, PGLAmmo] = 0;
$ItemMax[pfemale, PGL] = 0;
$ItemMax[pfemale, PGLAmmo] = 0;

$DamageScale[larmor, $ProtonDamageType] = 0.5;
$DamageScale[qarmor, $ProtonDamageType] = 0.5;
$DamageScale[srarmor, $ProtonDamageType] = 1.0;
$DamageScale[sarmor, $ProtonDamageType] = 0.5;
$DamageScale[marmor, $ProtonDamageType] = 0.5;
$DamageScale[parmor, $ProtonDamageType] = 0.5;
$DamageScale[harmor, $ProtonDamageType] = 0.5;
$DamageScale[tarmor, $ProtonDamageType] = 0.5;
$DamageScale[lfemale, $ProtonDamageType] = 0.5;
$DamageScale[qfemale, $ProtonDamageType] = 0.5;
$DamageScale[srfemale, $ProtonDamageType] = 1.0;
$DamageScale[sfemale, $ProtonDamageType] = 0.5;
$DamageScale[mfemale, $ProtonDamageType] = 0.5;
$DamageScale[pfemale, $ProtonDamageType] = 0.5;