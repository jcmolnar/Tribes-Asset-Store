
//Intimidator Paintball
//--------------------------------------
BulletData IntimidatorBUllet
{
   bulletShapeName    = "paint.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   aimDeflection      = 0.0009;
   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0;
};
//--------------------------------------

ItemImageData I1Image
{
	shapeFile = "plasma";
	mountPoint = 0; 
	mountOffset = { 0, 0.30, -0.10 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData I1
{
	description = "I1";
	className = "Weapon";
	shapeFile = "plasma";
	shadowDetailMask = 4;
	imageType = I1Image;
	showWeaponBar = false;
};

ItemImageData I2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.05, 0.20, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData I2
{
	description = "I2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = I2Image;
	showWeaponBar = false;
};

ItemImageData I3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0.20, -0.26 }; //-  left-right, back-front, up-down
	mountRotation = { -3.15, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData I3
{
	description = "I3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = I3Image;
	showWeaponBar = false;
};

ItemImageData I4Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.10 }; //-  left-right, back-front, up-down
	mountRotation = { -3.15, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData I4
{
	description = "I4";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = I4Image;
	showWeaponBar = false;
};

ItemData IntimidatorAmmo
{
	description = "Intimidator Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData IntimidatorImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = IntimidatorAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Intimidator] = 2;
$LCDName[Intimidator,1] = "Semi-Auto";
$LCDName[Intimidator,2] = "Safety";

ItemData Intimidator
{
	description = "Bob Long Intimidator GZ";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = IntimidatorImage;
	price = 1000;
	showWeaponBar = true;
};
function IntimidatorImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Intimidator]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,Intimidator] == 1 || $LCDMode[%client,Intimidator] == "")
		{
			Projectile::spawnProjectile("IntimidatorBullet",%trans,%player,%vel);
		GameBase::playSound(%player,bigExplosion4,0);
			Player::decItemCount(%player,IntimidatorAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Intimidator] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function Intimidator::onMount(%player,%item)
{
	Player::mountItem(%player, I1, 4);
	Player::mountItem(%player, I2, 5);
	Player::mountItem(%player, I3, 6);
	Player::mountItem(%player, I4, 7);
}

function Intimidator::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);

}

//Important Stuff
$ItemMax[larmor, Intimidator] = 1;
$ItemMax[larmor, IntimidatorAmmo] = 200;
$ItemMax[lfemale, Intimidator] = 1;
$ItemMax[lfemale, IntimidatorAmmo] = 200;
$InvList[Intimidator] = 1;
$InvList[IntimidatorAmmo] = 0;