
//TipmannS Paintball
//--------------------------------------
BulletData TipmannSBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   aimDeflection      = 0.000677;
   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------

ItemImageData TS1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.20, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 3.15, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData TS1
{
	description = "TS1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = TS1Image;
	showWeaponBar = false;
};

ItemImageData TS2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.05, 0, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -0.30, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData TS2
{
	description = "TS2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = TS2Image;
	showWeaponBar = false;
};

ItemImageData TS3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.13, -0.20 }; //-  left-right, back-front, up-down
	mountRotation = { -3.15, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData TS3
{
	description = "TS3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = TS3Image;
	showWeaponBar = false;
};

ItemData TipmannSAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData TipmannSImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = TipmannSAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[TipmannS] = 2;
$LCDName[TipmannS,1] = "Semi-Auto";
$LCDName[TipmannS,2] = "Safety";

ItemData TipmannS
{
	description = "Tippmann 98 Sniper";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = TipmannSImage;
	price = 350;
	showWeaponBar = true;
};
function TipmannSImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[TipmannS]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,TipmannS] == 1 || $LCDMode[%client,TipmannS] == "")
		{
			Projectile::spawnProjectile("TipmannSBullet",%trans,%player,%vel);
		GameBase::playSound(%player,SoundMortarTurretFire,0);
			Player::decItemCount(%player,TipmannSAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,TipmannS] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function TipmannS::onMount(%player,%item)
{
	Player::mountItem(%player, TS1, 5);
	Player::mountItem(%player, TS2, 6);
	Player::mountItem(%player, TS3, 7);
}

function TipmannS::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, TipmannS] = 1;
$ItemMax[larmor, TipmannSAmmo] = 200;
$ItemMax[lfemale, TipmannS] = 1;
$ItemMax[lfemale, TipmannSAmmo] = 200;
$InvList[TipmannS] = 1;
$InvList[TipmannSAmmo] = 0;