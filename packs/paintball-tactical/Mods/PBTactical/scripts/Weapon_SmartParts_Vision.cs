
//SmartParts Paintball
//--------------------------------------
BulletData SmartPartsBUllet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = bluepaintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   aimDeflection      = 0.0000999;
   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.0, 0.0, 50.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------
ItemImageData SP1Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, -0.1, 0.3 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.18 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SP1
{
	description = "SP1";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = SP1Image;
	showWeaponBar = false;
};

ItemImageData SP2Image
{
	shapeFile = "plasma";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SP2
{
	description = "SP2";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = SP2Image;
	showWeaponBar = false;
};

ItemImageData SP3Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SP3
{
	description = "SP3";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = SP3Image;
	showWeaponBar = false;
};

ItemImageData SP4Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.15, -0.26 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SP4
{
	description = "SP4";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = SP4Image;
	showWeaponBar = false;
};

ItemData SmartPartsAmmo
{
	description = "SmartParts Paintballs";
   heading = $InvHead[ihPbs];
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData SmartPartsImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.3, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right

	weaponType = 0; // Single Shot
	ammoType = SmartPartsAmmo;
	accuFire = false;
	reloadTime = 0.0;
	fireTime = 0.09;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[SmartParts] = 2;
$LCDName[SmartParts,1] = "Semi-Auto";
$LCDName[SmartParts,2] = "Safety";

ItemData SmartParts
{
	description = "Smart Parts Vision";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = $InvHead[ihGun];
	shadowDetailMask = 4;
	imageType = SmartPartsImage;
	price = 0;
	showWeaponBar = true;
};
function SmartPartsImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[SmartParts]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = LabRat::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,SmartParts] == 1 || $LCDMode[%client,SmartParts] == "")
		{
			%proj = Projectile::spawnProjectile("SmartPartsBullet",%trans,%player,%vel);
		GameBase::playSound(%player,SoundMortarTurretFire,0);
			Player::decItemCount(%player,SmartPartsAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,SmartParts] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function SmartParts::onMount(%player,%item)
{
	Player::mountItem(%player, SP1, 4);
	Player::mountItem(%player, SP2, 5);
	Player::mountItem(%player, SP3, 6);
	Player::mountItem(%player, SP4, 7);
}

function SmartParts::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, SmartParts] = 1;
$ItemMax[larmor, SmartPartsAmmo] = 250;
$ItemMax[lfemale, SmartParts] = 1;
$ItemMax[lfemale, SmartPartsAmmo] = 250;
$InvList[SmartParts] = 1;
$InvList[SmartPartsAmmo] = 0;