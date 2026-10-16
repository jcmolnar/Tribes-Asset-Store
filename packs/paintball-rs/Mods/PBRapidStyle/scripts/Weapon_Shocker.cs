
//Shocker Paintball
//--------------------------------------
BulletData ShockerBUlletAuto
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.00029;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData ShockerBUlletSemi
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   aimDeflection      = 0.0007;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------

ItemImageData Shocker1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.05, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Shocker1
{
	description = "Shocker1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Shocker1Image;
	showWeaponBar = false;
};

ItemImageData Shocker2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.15, 0.35 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Shocker2
{
	description = "Shocker2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Shocker2Image;
	showWeaponBar = false;
};

ItemImageData Shocker3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.15 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Shocker3
{
	description = "Shocker3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = Shocker3Image;
	showWeaponBar = false;
};

ItemImageData Shocker4Image
{
	shapeFile = "energygun";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.10 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Shocker4
{
	description = "Shocker4";
	className = "Weapon";
	shapeFile = "energygun";
	shadowDetailMask = 4;
	imageType = Shocker4Image;
	showWeaponBar = false;
};

ItemData ShockerAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ShockerImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = ShockerAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.12;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Shocker] = 3;
$LCDName[Shocker,1] = "Full-Auto";
$LCDName[Shocker,2] = "Semi-Auto";
$LCDName[Shocker,3] = "Safety";

ItemData Shocker
{
	description = "A1 ShoCkEr";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = ShockerImage;
	price = 180;
	showWeaponBar = true;
};
function ShockerImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Shocker]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,Shocker] == 1 || $LCDMode[%client,Shocker] == "")
		{
			Projectile::spawnProjectile("ShockerBulletAuto",%trans,%player,%vel);
			GameBase::playSound(%player,bigExplosion4,0);
		 	Player::decItemCount(%player,ShockerAmmo);
		}
		else if($LCDMode[%client,Shocker] == 2)
		{
			Projectile::spawnProjectile("ShockerBulletSemi",%trans,%player,%vel);
			GameBase::playSound(%player,bigExplosion4,0);
		 	Player::decItemCount(%player,ShockerAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Shocker] == 3)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
}

//Mounts

function Shocker::onMount(%player,%item)
{

	Player::mountItem(%player, Shocker1, 4);
	Player::mountItem(%player, Shocker2, 5);
	Player::mountItem(%player, Shocker3, 6);
	Player::mountItem(%player, Shocker4, 7);
}

function Shocker::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Shocker] = 1;
$ItemMax[larmor, ShockerAmmo] = 450;
$ItemMax[lfemale, Shocker] = 1;
$ItemMax[lfemale, ShockerAmmo] = 450;
$InvList[Shocker] = 1;
$InvList[ShockerAmmo] = 0;
