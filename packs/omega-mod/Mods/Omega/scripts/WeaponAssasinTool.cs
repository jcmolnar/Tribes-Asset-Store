//--------------------------------------

$AutoUse[AssasinTool] = True;
$SellAmmo[AssasinToolAmmo] = 5;
$AmmoPackMax[AssasinToolAmmo] = 30;
$AmmoPackItems[1] = AssasinToolAmmo;
$WeaponAmmo[AssasinTool] = AssasinToolAmmo;
AddWeapon(AssasinTool);
//--------------------------------------

$InvList[AssasinTool] = 1;
$InvList[AssasinToolAmmo] = 1;
$RemoteInvList[AssasinTool] = 1;
$RemoteInvList[AssasinToolAmmo] = 1;

//--------------------------------------

BulletData BloodShot
{
   bulletShapeName    = "chainspk.dts";
   validateShape      = true;
   explosionTag       = BloodExp;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.33;
   damageType         = $SRDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 100.0;
   totalTime          = 0.1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, AssasinTool] = 1;
$ItemMax[lfemale, AssasinTool] = 1;
$ItemMax[marmor, AssasinTool] = 0;
$ItemMax[mfemale, AssasinTool] = 0;
$ItemMax[harmor, AssasinTool] = 0;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, AssasinToolAmmo] = 50;
$ItemMax[lfemale, AssasinToolAmmo] = 50;
$ItemMax[marmor, AssasinToolAmmo] = 0;
$ItemMax[mfemale, AssasinToolAmmo] = 0;
$ItemMax[harmor, AssasinToolAmmo] = 0;

//+++++++++++++++++++++++++++++++++++++++



ItemData AssasinToolAmmo 
{
	description = "Body Blenders";
	className = "Ammo";
	heading = xAmmunition;
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 900;
};

ItemImageData AssasinToolImage 
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	ammoType = AssasinToolAmmo;
	accuFire = true;
	projectileType = BloodShot; 
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundButtonPDAHard;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AssasinTool
{
	description = "H.S.C";
	className = "Weapon";
	shapeFile = "Mortar";
	hudIcon = "sniper";
	heading = zSpecial;
	shadowDetailMask = 4;
	imageType = AssasinToolImage;
   	validateShape = false;
   	validateMaterials = false;
	price = 5000;
	showWeaponBar = true;
};

function AssasinTool::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "________---_____Insufficient Data____---_______");
}

//--------------------------------------