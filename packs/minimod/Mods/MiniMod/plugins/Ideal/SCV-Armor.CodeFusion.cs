$SCVDamageType         = 260651;

RepairEffectData SCVProjectile
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.25;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function SCVProjectile::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
      	%player.repairTarget = %target;
		%player.repairRate   = 0.05;
		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if(GameBase::getTeam(%player) == GameBase::getTeam(%player.repairTarget))
		{
			if (GameBase::getDamageLevel(%player.repairTarget) == 0)
			{
				Client::sendMessage(%client,0,%name @ " is not damaged");
				Player::trigger(%player,$WeaponSlot,false);
				%player.repairTarget = -1;
				return;
			}
			if (getObjectType(%player.repairTarget) == "Player")
			{
				Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
			}
			Client::sendMessage(%client,0,"Repairing " @ %name);
		}

	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SCVProjectile::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else if(GameBase::getTeam(%object) == GameBase::getTeam(%player))
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function SCVProjectile::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == SCVGun && %player.repairTarget != -1)
	{
		%object = %player.repairTarget;
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else if(GameBase::getTeam(%object) == GameBase::getTeam(%player))
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if(getObjectType(%player.repairTarget) == "Player")
			{
				if(Player::isDead(%object))
				{
					Player::trigger(%player,$WeaponSlot,false);
					return;
				}
			}
			else
			{
				if(GameBase::getDamageLevel(%object) == GameBase::getDataName(%object).maxDamage)
				{
					Player::trigger(%player,$WeaponSlot,false);
					return;
				}
			}
			
			%client = Player::getClient(%player);
			GameBase::applyDamage(%object, $SCVDamageType, 0.02, GameBase::getPosition(%object), Item::getVelocity(%player), "0 0 0", Client::getControlObject(%client));

			
			
		}
	}
}
$deathMsg[$SCVDamageType, 0]       = "%2 confuses everyone by letting %1, an SCV, kill him.";
$deathMsg[$SCVDamageType, 1]       = "%2 proves his infinite stupidity by being killed by %1's Nanite Assembler.";
$deathMsg[$SCVDamageType, 2]       = "%2 shows off his mad dying skills.";
$deathMsg[$SCVDamageType, 3]       = "%1 says, 'Sorry %2, I thought I was repairing you...'";
$DamageScale[larmor, $SCVDamageType] = 0.9;
$DamageScale[marmor, $SCVDamageType] = 1.0;
$DamageScale[harmor, $SCVDamageType] = 1.1;
$DamageScale[lfemale, $SCVDamageType] = 0.9;
$DamageScale[mfemale, $SCVDamageType] = 1.0;
$DamageScale[specarmor, $SCVDamageType] = 1.4;
$DamageScale[secrarmor, $SCVDamageType] = 1.0;
$DamageScale[tarmor, $SCVDamageType] = 1.3;
$DamageScale[scvarmor, $SCVDamageType] = 2.0;
$DamageScale[scvarmor, $ObeliskDamageType] = 1.0;
$DamageScale[scvarmor, $MarlinDamageType] = 1.0;

$DamageScale[scvarmor, $LCGDamageType] = 1.0;
$DamageScale[scvarmor, $NoDamageType] = 1.0;
$DamageScale[scvarmor, $SlowDamageType] = 1.0;
$DamageScale[scvarmor, $LandingDamageType] = 1.0;
$DamageScale[scvarmor, $ImpactDamageType] = 1.0;
$DamageScale[scvarmor, $CrushDamageType] = 1.0;
$DamageScale[scvarmor, $BulletDamageType] = 1.0;
$DamageScale[scvarmor, $PlasmaDamageType] = 1.0;
$DamageScale[scvarmor, $EnergyDamageType] = 1.0;
$DamageScale[scvarmor, $ExplosionDamageType] = 1.0;
$DamageScale[scvarmor, $MissileDamageType] = 1.0;
$DamageScale[scvarmor, $DebrisDamageType] = 1.0;
$DamageScale[scvarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[scvarmor, $LaserDamageType] = 1.0;
$DamageScale[scvarmor, $MortarDamageType] = 1.0;
$DamageScale[scvarmor, $BlasterDamageType] = 1.0;
$DamageScale[scvarmor, $ElectricityDamageType] = 1.0;
$DamageScale[scvarmor, $MineDamageType] = 1.0;


$MaxWeapons[scvarmor] = 1;

//------------------------------------------------------------------
// SCV Armor data:
//------------------------------------------------------------------

PlayerData scvarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 18;
   minJetEnergy = 1;
   jetForce = 420;
   jetEnergyDrain = 0.8;

	maxDamage = 0.55;
   maxForwardSpeed = 7.5;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 70;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 120;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

$ArmorType[Male, BuildingArmor] = scvarmor;
$ArmorType[Female, BuildingArmor] = scvarmor;
$ArmorName[scvarmor] = BuildingArmor;

ItemData BuildingArmor
{
   heading = "aArmor";
	description = "SCV";
	className = "Armor";
	price = 1500;
};

ItemImageData SCVGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = SCVProjectile;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 0, 0 };

	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SCVGun
{
	description = "Nanite Assembler";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SCVGunImage;
	price = 0;
	showWeaponBar = true;
};

ItemImageData SCVPackImage
{
	shapeFile = "mortarammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData SCVPack
{
	description = "SCV Building Pack";
	shapeFile = "mortarammo";
	className = "Backpack";
   heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = SCVPackImage;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SCVPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		%client = Player::getClient(%player);
		schedule(%client.deployable @ "::deployShape(" @ %player @ ", " @ %client.deployable @ ");", 0.1, %player);
	}
}


function PulseSensorPack::deployShape(%player, %item)
{
	if(Item::deployShape(%player, "Pulse Sensor", DeployablePulseSensor, %item))
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
}

function DeployableSensorJammerPack::deployShape(%player, %item)
{
	if(Item::deployShape(%player, "Sensor Jammer", DeployableSensorJammer, %item))
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
}

$InvList[SCVPack] = 1;
$ItemMax[scvarmor,SCVPack]=1;
$InvList[SCVGun] = 1;
$ItemMax[scvarmor,SCVGun]=1;
