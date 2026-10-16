
//Inferno Paintball
//--------------------------------------
BulletData InfernoBUllet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   aimDeflection      = 0.000209;
   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod = 1;
};
//--------------------------------------

ItemImageData O1Image
{
	shapeFile = "energygun";
	mountPoint = 0; 
	mountOffset = { 0, 0.10, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData O1
{
	description = "O1";
	className = "Weapon";
	shapeFile = "energygun";
	shadowDetailMask = 4;
	imageType = O1Image;
	showWeaponBar = false;
};

ItemImageData O2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.15, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData O2
{
	description = "O2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = O2Image;
	showWeaponBar = false;
};

ItemImageData O3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.20 }; //-  left-right, back-front, up-down
	mountRotation = { -3.15, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData O3
{
	description = "O3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = O3Image;
	showWeaponBar = false;
};

ItemImageData O4Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.40, -0.10 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData O4
{
	description = "O4";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = O4Image;
	showWeaponBar = false;
};

ItemData InfernoAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData InfernoImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = InfernoAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.121;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Inferno] = 2;
$LCDName[Inferno,1] = "Semi-Auto";
$LCDName[Inferno,2] = "Safety";

ItemData Inferno
{
	description = "StiNgRaY";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = InfernoImage;
	price = 190;
	showWeaponBar = true;
};
function InfernoImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Inferno]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,AutoCocker] == 1 || $LCDMode[%client,Inferno] == "")
		{
			Projectile::spawnProjectile("InfernoBullet",%trans,%player,%vel);
		GameBase::playSound(%player,SoundFireGrenade,0);
			Player::decItemCount(%player,InfernoAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Inferno] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function Inferno::onMount(%player,%item)
{

	Player::mountItem(%player, O1, 4);
	Player::mountItem(%player, O2, 5);
	Player::mountItem(%player, O3, 6);
	Player::mountItem(%player, O4, 7);
}

function Inferno::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Inferno] = 1;
$ItemMax[larmor, InfernoAmmo] = 350;
$ItemMax[lfemale, Inferno] = 1;
$ItemMax[lfemale, InfernoAmmo] = 350;
$InvList[Inferno] = 1;
$InvList[InfernoAmmo] = 0;
