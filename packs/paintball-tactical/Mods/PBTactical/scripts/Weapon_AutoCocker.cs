
//AutoCocker Paintball
//--------------------------------------
BulletData AutocockerBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = RedPaintSplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;

   aimDeflection      = 0.0009;
   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 51.0, 0.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------

ItemImageData C1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData C1
{
	description = "C1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = C1Image;
	showWeaponBar = false;
};

ItemImageData C2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.05, 0.20, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData C2
{
	description = "C2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = C2Image;
	showWeaponBar = false;
};

ItemImageData C3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.40 }; //-  left-right, back-front, up-down
	mountRotation = { -1.55, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData C3
{
	description = "C3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = C3Image;
	showWeaponBar = false;
};

ItemImageData C4Image
{
	shapeFile = "plasma";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData C4
{
	description = "C4";
	className = "Weapon";
	shapeFile = "plasma";
	shadowDetailMask = 4;
	imageType = C4Image;
	showWeaponBar = false;
};

ItemData AutoCockerAmmo
{
	description = "Paintballs";
   heading = $InvHead[ihPbs];
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData AutoCockerImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = AutoCockerAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[AutoCocker] = 2;
$LCDName[AutoCocker,1] = "Semi-Auto";
$LCDName[AutoCocker,2] = "Safety";

ItemData AutoCocker
{
	description = "Shocktech Autococker";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "paintgun";
   heading = $InvHead[ihGun];
	shadowDetailMask = 4;
	imageType = AutoCockerImage;
	price = 0;
	showWeaponBar = true;
};
function AutoCockerImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[AutoCocker]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = LabRat::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,AutoCocker] == 1 || $LCDMode[%client,AutoCocker] == "")
		{
			%proj = Projectile::spawnProjectile("AutoCockerBullet",%trans,%player,%vel);
		GameBase::playSound(%player,bigExplosion4,0);
			Player::decItemCount(%player,AutoCockerAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,AutoCocker] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function AutoCocker::onMount(%player,%item)
{
	Player::mountItem(%player, C1, 4);
	Player::mountItem(%player, C2, 5);
	Player::mountItem(%player, C3, 6);
	Player::mountItem(%player, C4, 7);
}

function AutoCocker::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, AutoCocker] = 1;
$ItemMax[larmor, AutoCockerAmmo] = 250;
$ItemMax[lfemale, AutoCocker] = 1;
$ItemMax[lfemale, AutoCockerAmmo] = 250;
$InvList[AutoCocker] = 1;
$InvList[AutoCockerAmmo] = 0;