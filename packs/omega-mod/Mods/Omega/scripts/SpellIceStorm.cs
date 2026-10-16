//this is a funny AIM conversation for anyone who decrypted my shit and can read this.... rofl
//Variable4tribes: so
//Variable4tribes: i jack with 1
//farthead147: i need big hands for my big dick
//farthead147: :
//farthead147: :D
//Variable4tribes: thats all i need
//Variable4tribes: 1 hand
//farthead147: 2
//Variable4tribes: stroke
//farthead147: LMAO
//Variable4tribes: shit
//--------------------------------------

$AutoUse[IceStormSpell] = True;
$WeaponAmmo[IceStormSpell] = "";
//--------------------------------------

$InvList[IceStormSpell] = 0;
$RemoteInvList[IceStormSpell] = 0;

//--------------------------------------

BulletData IceBolt
{
   bulletShapeName    = "chainspk.dts";
   validateShape      = true;
   explosionTag       = IceExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $IceDamageType;

   explosionRadius  = 7;
   aimDeflection      = 0.1;
   muzzleVelocity     = 700.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, IceStormSpell] = 0;
$ItemMax[lfemale, IceStormSpell] = 0;
$ItemMax[marmor, IceStormSpell] = 0;
$ItemMax[mfemale, IceStormSpell] = 0;
$ItemMax[harmor, IceStormSpell] = 0;

//++++++++++++++++++++++++++++++++++++++
$DamageScale[larmor, $IceDamageType] = 1;
$DamageScale[lfemale, $IceDamageType] = 1;
$DamageScale[marmor, $IceDamageType] = 1;
$DamageScale[mfemale, $IceDamageType] = 1;
$DamageScale[harmor, $IceDamageType] = 1;
//+++++++++++++++++++++++++++++++++++++++

ItemImageData IceStormSpellImage 
{
	shapeFile = "fusionbolt";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 3.14159, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 1.5;
	minEnergy = 20;
	maxEnergy = 20;


	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData IceStormSpell
{
	description = "Ice Storm Spell";
	className = "Weapon";
	shapeFile = "fusionex";
	hudIcon = "plasma";
        heading = "yIndalacios Weapons";
	shadowDetailMask = 4;
	imageType = IceStormSpellImage;
   validateShape = false;
   validateMaterials = false;
	price = 2500;
	showWeaponBar = true;
};

function IceStormSpellImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 32; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("IceBolt",%trans,%player,%vel);
	}
}

function IceStormSpell::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Summon ice to rain on ur foes.");
}

//--------------------------------------


