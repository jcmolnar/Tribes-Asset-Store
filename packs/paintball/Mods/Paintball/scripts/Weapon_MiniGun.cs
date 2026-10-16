
//MiniGun Paintball
//--------------------------------------
BulletData MiniGunBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
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

ItemData MiniGunAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MiniGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down
        mountRotation = { 0, 3.15, 0 };//-  //- X= up-down , Y= roll-left-right , Z= left-right

	weaponType = 0; // Single Shot
	ammoType = MiniGunAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0009;

	sfxActivate = SoundWeaponSelect;
};

$LCDGroup[MiniGun] = 4;
$LCDName[MiniGun,1] = "Full-Auto";
$LCDName[MiniGun,2] = "3Shot-Burst";
$LCDName[MiniGun,3] = "6Shot-Burst";
$LCDName[MiniGun,4] = "Semi-Auto";
$LCDName[MiniGun,5] = "Safety";

ItemData MiniGun
{
	description = "MiniGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = MiniGunImage;
	price = 175;
	showWeaponBar = true;
};
function MiniGunImage::onFire(%player,%slot) 
{
	checkFireTime(%player);

	if (%player.waitFire)
		return;

	%ammo = Player::getItemCount(%player,$WeaponAmmo[MiniGun]);
	if(%ammo)
	{
		%client	= Player::getClient(%player);
		%trans	= GameBase::getMuzzleTransform(%client);
		%vel	= Item::getVelocity(%player);
		%mode	= %client.LCDMode[MiniGun];

		// Full-Auto
		if ((%mode == 1) || (%mode == ""))
		{
			Projectile::spawnProjectile(MiniGunBullet, %trans, %player, %vel);
			GameBase::playSound(%player, SoundFirePlasma, 0);
		 	Player::decItemCount(%player, MiniGunAmmo);
		}

		// 3-Shot or 6-Shot Burst
		else if ((%mode == 2) || (%mode == 3))
		{
			%player.waitFire = true;

			%shots = 3;
			if (%mode == 3)
				%shots = 6;

			if ((%ammo - %shots) < 0)
				%shots = %ammo;

			for (%a = 0; %a < %shots; %a++)
			{
                        	schedule("Projectile::spawnProjectile(MiniGunBullet, GameBase::getMuzzleTransform("@%player@"), "@%player@", Item::getVelocity("@%player@"));", %a * 0.1);
			 	schedule("GameBase::playSound("@%player@", SoundFirePlasma, 0);", %a * 0.1);
			 	schedule("Player::decItemCount("@%player@", MiniGunAmmo);", %a * 0.1);
			}
			schedule(%player @ ".waitFire = \"\";", %a * 0.1);
			Player::trigger(%player, $WeaponSlot, false);
		}

		// Semi-Auto
		else if (%mode == 4)
		{
			Projectile::spawnProjectile(MiniGunBullet, %trans, %player, %vel);
			GameBase::playSound(%player, SoundFirePlasma, 0);
		 	Player::decItemCount(%player, MiniGunAmmo);
			Player::trigger(%player, $WeaponSlot, false);
		}

		// Safety
		else
		{
			GameBase::playSound(%player,SoundWeaponSelect,1);
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
}

//Important Stuff
$ItemMax[larmor, MiniGun] = 0;
$ItemMax[larmor, MiniGunAmmo] = 999;
$ItemMax[lfemale, MiniGun] = 0;
$ItemMax[lfemale, MiniGunAmmo] = 999;
$InvList[MiniGun] = 0;
$InvList[MiniGunAmmo] = 0;