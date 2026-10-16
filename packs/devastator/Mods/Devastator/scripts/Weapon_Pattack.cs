//--------------------------------------
GrenadeData BigBoom
{
   bulletShapeName    = "paint.dts";
   explosionTag       = plasmaexp;
   collideWithOwner   = False;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $BoomDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "shotgunex.dts";
};

GrenadeData HealBoom
{
   bulletShapeName    = "paint.dts";
   explosionTag       = turretexp;
   collideWithOwner   = False;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -2.0;
   damageType         = $BoomDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "enex.dts";
};

//----------------------------------------------------------------------------

ItemData RageAmmo
{
	description = "Anger";
	className = "Ammo";
	shapeFile = "fusionbolt";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData PAttackImage
{
	shapeFile = "enex";
	mountPoint = 0;
	mountRotation = {0, 0, 0};
	weaponType = 0; 
	ammoType = RageAmmo;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 1.2;
	minEnergy = 1.0;
	maxEnergy = 3.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };	

	sfxFire     = SoundThrowItem;
	sfxActivate = SoundJetHeavy;
	sfxReady    = SoundLaserIdle;
};

ItemData PAttack
{
	description = "!RAGE¡";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "fear";
   	heading = "bEnergy-Based Weapons";
	shadowDetailMask = 4;
	imageType = PAttackImage;
	price = 175;
	showWeaponBar = true;
};

function PAttackImage::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%energy = GameBase::getEnergy(%player);
	%delta = Player::getItemCount(%player,"RageAmmo");
	if(%delta >= 1) {
		if(%energy >= Player::getArmor(%player).maxEnergy/2) {
			if($WeapMode[%client,PAttack] == 1||$WeapMode[%client,PAttack] == "")
				Weapon::onFire(%player,BigBoom,False);
			else if($WeapMode[%client,PAttack] == 2)
				Weapon::onFire(%player,HealBoom,False);
			Player::setAnimation(%player,19);
			%client.tempRageCount = %delta;
			Player::decItemCount(%player,"RageAmmo",%delta);
		}
		else
			bottomprint(%client,"<jc>You must have more than half energy to release your ¡Rage!", 1);
	}
	else
		bottomprint(%client,"<jc>You don't have any built up ¡Rage!", 1);
}

//--------------------------------------------------------
	$InvList[PAttack] = 1;
	$RemoteInvList[PAttack] = 0; //- we dont want this =)
	
	$ItemMax[larmor, PAttack] = 0;
	$ItemMax[marmor, PAttack] = 0;
	$ItemMax[harmor, PAttack] = 0;
	$ItemMax[qarmor, PAttack] = 0;
	$ItemMax[tarmor, PAttack] = 0;
	$ItemMax[sarmor, PAttack] = 0;
	$ItemMax[srarmor, PAttack] = 0;
	$ItemMax[parmor, PAttack] = 0;
	$ItemMax[psarmor, PAttack] = 1;
	$ItemMax[psfemale, PAttack] = 1;
	$ItemMax[lfemale, PAttack] = 0;
	$ItemMax[mfemale, PAttack] = 0;
	$ItemMax[qarmor, PAttack] = 0;
	$ItemMax[sarmor, PAttack] = 0;
	$ItemMax[srarmor, PAttack] = 0;
	$ItemMax[parmor, PAttack] = 0;
	
	$ItemMax[larmor, RageAmmo] = 100;
	$ItemMax[marmor, RageAmmo] = 100;
	$ItemMax[harmor, RageAmmo] = 100;
	$ItemMax[qarmor, RageAmmo] = 100;
	$ItemMax[tarmor, RageAmmo] = 100;
	$ItemMax[sarmor, RageAmmo] = 100;
	$ItemMax[srarmor, RageAmmo] = 100;
	$ItemMax[parmor, RageAmmo] = 100;
	$ItemMax[psarmor, RageAmmo] = 100;
	$ItemMax[psfemale, RageAmmo] = 100;
	$ItemMax[Icemor, RageAmmo] = 100;
	$ItemMax[lfemale, RageAmmo] = 100;
	$ItemMax[mfemale, RageAmmo] = 100;
	$ItemMax[qfemale, RageAmmo] = 100;
	$ItemMax[sfemale, RageAmmo] = 100;
	$ItemMax[srfemale, RageAmmo] = 100;
	$ItemMax[pfemale, RageAmmo] = 100;
