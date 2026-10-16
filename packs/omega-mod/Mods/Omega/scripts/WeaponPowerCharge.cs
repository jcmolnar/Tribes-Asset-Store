//--------------------------------------

$AutoUse[PBC] = True;
$SellAmmo[PBC] = 1;
$AmmoPackMax[PBCAmmo] = 0;
$AmmoPackItems[1] = PBCAmmo;
$WeaponAmmo[PBC] = PBCAmmo;
//--------------------------------------

$InvList[PBC] = 1;
$InvList[PBCAmmo] = 1;
$RemoteInvList[PBC] = 1;
$RemoteInvList[PBCAmmo] = 1;

//--------------------------------------
//--------------------------------------
RocketData PowerBlastlvl1
{
   bulletShapeName  = "enex.dts";
   explosionTag     = PBExp1;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 1.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "chainspk.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData PowerBlastlvl2
{
   bulletShapeName  = "shotgunex.dts";
   explosionTag     = PBExp2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};
//--------------------------------------
//--------------------------------------
RocketData PowerBlastlvl3
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = PBExp3;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl4
{
   bulletShapeName  = "fusionex.dts";
   explosionTag     = PBExp4;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl5
{
   bulletShapeName  = "shield_medium.dts";
   explosionTag     = PBExp5;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 12.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl6
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = PBExp6;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl7
{
   bulletShapeName  = "tumult_large.dts";
   explosionTag     = PBExp7;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "dustplume.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl8
{
   bulletShapeName  = "mortarex.dts";
   explosionTag     = PBExp8;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.1;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 17.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "flash_small.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl9
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = PBExp9;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.3;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 19.0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 5.0;

   soundId = SoundJetHeavy;
};

RocketData PowerBlastlvl10 //boom
{
   bulletShapeName  = "plasmawall.dts";
   explosionTag     = PBExp10;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 25.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "zap.dts";
   smokeDist   = 5.0;

   soundId = SoundJetHeavy;
};
//--------------------------------------

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, PBC] = 1;
$ItemMax[lfemale, PBC] = 1;
$ItemMax[marmor, PBC] = 1;
$ItemMax[mfemale, PBC] = 1;
$ItemMax[harmor, PBC] = 1;

//++++++++++++++++++++++++++++++++++++++

$ItemMax[larmor, PBCAmmo] = 10;
$ItemMax[lfemale, PBCAmmo] = 10;
$ItemMax[marmor, PBCAmmo] = 10;
$ItemMax[mfemale, PBCAmmo] = 10;
$ItemMax[harmor, PBCAmmo] = 10;

//+++++++++++++++++++++++++++++++++++++++

ItemData PBCAmmo
{
	description = "PBC Ammo";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData PBCImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PBCAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundEnergyTurretTurn;
	sfxActivate = SoundChainTurretOn;
	sfxReload = SoundDryFire;
};

ItemData PBC
{
	description = "Power Blast Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PBCImage;
	price = 1000;
	showWeaponBar = true;
};

function RechargePBCAmmo(%player)
{
	if(Player::getItemCount(%player,PBC) > 0 && $FiringPBC[%player] == False && $ChargingPBC[%player] == True)
	{
		if(Player::getItemCount(%player,PBCAmmo) < 10)
		{
			Player::incItemCount(%player,PBCAmmo,1);

			schedule("RechargePBCAmmo(" @ %player @ ");", 2);
		}
		else
			$PBCRecharging[%player] = False;
	}
}

function FirePBC(%player)
{
	if($FiringPBC[%player] == True && $PBCFired[%player] < $PBCToFire[%player])
	{
		if(Player::getItemCount(%player,PBCAmmo) == 1)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl1",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,PBCAmmo) == 2)
		{
			bottomprint(%clientId, "<jc>Testing");
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl2",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,PBCAmmo) == 3)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl3",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,PBCAmmo) == 4)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl4",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,PBCAmmo) == 5)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl5",%trans,%player,%vel);
		}
                                else if(Player::getItemCount(%player,PBCAmmo) == 6)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl6",%trans,%player,%vel);
		}
                                else if(Player::getItemCount(%player,PBCAmmo) == 7)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl7",%trans,%player,%vel);
		}
                                else if(Player::getItemCount(%player,PBCAmmo) == 8)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl8",%trans,%player,%vel);
		}
                                else if(Player::getItemCount(%player,PBCAmmo) == 9)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl9",%trans,%player,%vel);
		}
                                else if(Player::getItemCount(%player,PBCAmmo) == 10)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PowerBlastLvl10",%trans,%player,%vel);
		}
	}
	
	if($PBCFired[%player] < $PBCToFire[%player])
	{
		$PBCFired[%player]++;
		schedule("FirePBC(" @ %player @ ");", 1/$PBCToFire[%player]);
	}
	else
	{
		Player::setItemCount(%player,$WeaponAmmo[PBC],1);
		$FiringPBC[%player] = False;
	}
}

function PBCImage::onFire(%player,%slot)
{
	if($ChargingPBC[%player] == True)
	{
		$ChargingPBC[%player] = False;

		$FiringPBC[%player] = True;
		$PBCFired[%player] = 0;

		if(Player::getItemCount(%player, PBCAmmo) == 1)
		{
			$PBCToFire[%player] = 0;
		}
		else if(Player::getItemCount(%player, PBCAmmo) == 2)
		{
			$PBCToFire[%player] = 20;
		}
		else if(Player::getItemCount(%player, PBCAmmo) == 3)
		{
			$PBCToFire[%player] = 15;
		}
		else if(Player::getItemCount(%player, PBCAmmo) == 4)
		{
			$PBCToFire[%player] = 13;
		}
		else if(Player::getItemCount(%player, PBCAmmo) == 5)
		{
			$PBCToFire[%player] = 11;
		}
                                else if(Player::getItemCount(%player, PBCAmmo) == 6)        
		{
			$PBCToFire[%player] = 10;
		}
                                else if(Player::getItemCount(%player, PBCAmmo) == 7)      
		{
			$PBCToFire[%player] = 10;
		}
                                
                                else if(Player::getItemCount(%player, PBCAmmo) == 8)        
		{
			$PBCToFire[%player] = 10;
		}
                                
                                else if(Player::getItemCount(%player, PBCAmmo) == 9)        
		{
			$PBCToFire[%player] = 10;
		}
                                
                                else if(Player::getItemCount(%player, PBCAmmo) == 10)        
		{
			$PBCToFire[%player] = 10;
		}
                                
                                
                               FirePBC(%player);
	}
	else if($FiringPBC[%player] == False)
	{
		$ChargingPBC[%player] = True;

		schedule("RechargePBCAmmo(" @ %player @ ");", 2);
	}
}

function PBC::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);

	Player::setItemCount(%player,$WeaponAmmo[PBC],1);
	$FiringPBC[%player] = False;
	$ChargingPBC[%player] = False;

      Bottomprint(%client,"The PBC, or Power Blast Cannon, has 10 levels of charge - 2) Drived Dominion Blast. 3) Electro-plasmic-combustion 4) Argon Blasting 5) Strontium Oxygen combustion 6) High Explosive 7) Hell Storm blast 8) Micro-Napalm 9) Explosive Barrage. 10) Mini Nuke -> {MA} Sword   ");
}
//--------------------------------------