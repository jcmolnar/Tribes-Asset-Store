
//Psycho Paintball
//--------------------------------------
BulletData PsychoBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = redpaintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   aimDeflection      = 0.001;
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

ItemImageData P1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0.10, -0.20, 0.10 }; //-  left-right, back-front, up-down
	mountRotation = { -3.15, 1.55, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData P1
{
	description = "P1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = P1Image;
	showWeaponBar = false;
};

ItemImageData P2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0.10, 0.10, 0.20 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData P2
{
	description = "P2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = P2Image;
	showWeaponBar = false;
};

ItemImageData P3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0.20, -0.30 }; //-  left-right, back-front, up-down
	mountRotation = { -1.55, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData P3
{
	description = "P3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = P3Image;
	showWeaponBar = false;
};

ItemImageData P4Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.40, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3.15, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData P4
{
	description = "P4";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = P4Image;
	showWeaponBar = false;
};

ItemData PsychoAmmo
{
	description = "Psycho Paintballs";
   heading = $InvHead[ihPbs];
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData PsychoImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = PsychoAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.074;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[Psycho] = 2;
$LCDName[Psycho,1] = "Semi-Auto";
$LCDName[Psycho,2] = "Safety";

ItemData Psycho
{
	description = "PsychoBallistic Lightning";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "paintgun";
   heading = $InvHead[ihGun];
	shadowDetailMask = 4;
	imageType = PsychoImage;
	price = 0;
	showWeaponBar = true;
};
function PsychoImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Psycho]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = LabRat::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if($LCDMode[%client,Psycho] == 1 || $LCDMode[%client,Psycho] == "")
		{
			%proj = Projectile::spawnProjectile("PsychoBullet",%trans,%player,%vel);
		GameBase::playSound(%player,SoundMortarTurretFire,0);
			Player::decItemCount(%player,PsychoAmmo);
			Player::trigger(%player,$WeaponSlot,false);
		}
		else if($LCDMode[%client,Psycho] == 2)
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
}

//Mounts

function Psycho::onMount(%player,%item)
{
	Player::mountItem(%player, P1, 4);
	Player::mountItem(%player, P2, 5);
	Player::mountItem(%player, P3, 6);
	Player::mountItem(%player, P4, 7);
}

function Psycho::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

//Important Stuff
$ItemMax[larmor, Psycho] = 1;
$ItemMax[larmor, PsychoAmmo] = 250;
$ItemMax[lfemale, Psycho] = 1;
$ItemMax[lfemale, PsychoAmmo] = 250;
$InvList[Psycho] = 1;
$InvList[PsychoAmmo] = 0;