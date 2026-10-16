
//Dragun Paintball
//--------------------------------------
BulletData DragunBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   aimDeflection      = 0.000999;
   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------

ItemImageData D1Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.20, -0.20 }; //-  left-right, back-front, up-down
	mountRotation = { -3.10, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData D1
{
	description = "D1";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = D1Image;
	showWeaponBar = false;
};

ItemImageData D2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.05, 0.20, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData D2
{
	description = "D2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = D2Image;
	showWeaponBar = false;
};

ItemImageData D3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.15, -0.26 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData D3
{
	description = "D3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = D3Image;
	showWeaponBar = false;
};

ItemData DragunAmmo
{
	description = "Dragun Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DragunImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = DragunAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.09;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Dragun] = 2;
$LCDName[Dragun,1] = "Semi-Auto";
$LCDName[Dragun,2] = "Safety";

ItemData Dragun
{
	description = "M3 Dragun LCD";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = DragunImage;
	price = 210;
	showWeaponBar = true;
};
function DragunImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Dragun]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,Dragun] == 1 || $LCDMode[%client,Dragun] == "")
		{
			Projectile::spawnProjectile("DragunBullet",%trans,%player,%vel);
		GameBase::playSound(%player,SoundMortarTurretFire,0);
			Player::decItemCount(%player,DragunAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Dragun] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function Dragun::onMount(%player,%item)
{
	Player::mountItem(%player, D1, 5);
	Player::mountItem(%player, D2, 6);
	Player::mountItem(%player, D3, 7);
}

function Dragun::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Dragun] = 1;
$ItemMax[larmor, DragunAmmo] = 200;
$ItemMax[lfemale, Dragun] = 1;
$ItemMax[lfemale, DragunAmmo] = 200;
$InvList[Dragun] = 1;
$InvList[DragunAmmo] = 0;