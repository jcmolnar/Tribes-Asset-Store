DamageSkinData armorDamageSkins
{
   bmpName[0] = "dskin1_armor";
   bmpName[1] = "dskin2_armor";
   bmpName[2] = "dskin3_armor";
   bmpName[3] = "dskin4_armor";
   bmpName[4] = "dskin5_armor";
   bmpName[5] = "dskin6_armor";
   bmpName[6] = "dskin7_armor";
   bmpName[7] = "dskin8_armor";
   bmpName[8] = "dskin9_armor";
   bmpName[9] = "dskin10_armor";
};
//------------------------------------------------------------------
// Death Angel Armor data:
//------------------------------------------------------------------

PlayerData DAarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "shield_medium";
   shieldShapeName = "shield_medium";
   damageSkinData = "armorDamageSkins";
	debrisId = WarDebris;
   shadowDetailMask = 1;
   validateShape = true;

   canCrouch = false;
   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 32;
   maxJetForwardVelocity = 60;
   minJetEnergy = 1;
   jetForce = 400;
   jetEnergyDrain = 0;

	maxDamage = 15.0;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 18;
   maxSideSpeed = 18;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 9999.0;
	maxEnergy = 200;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 130;
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
   animData[19] = { "jet", none, 1, true, false, true, false, 3 };
   

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

   jetSound = SoundFlyerActive;

   idleSound = SoundFlyerIdle;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
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

//----------------------------------------------------------------------------
// Phoenix Armor
//----------------------------------------------------------------------------
$DamageScale[DAarmor, $LandingDamageType] = 0.0;
$DamageScale[DAarmor, $ImpactDamageType] = 0.0;
$DamageScale[DAarmor, $CrushDamageType] = 0.0;
$DamageScale[DAarmor, $BulletDamageType] = 0.0;
$DamageScale[DAarmor, $PlasmaDamageType] = 0.0;
$DamageScale[DAarmor, $EnergyDamageType] = 0.0;
$DamageScale[DAarmor, $ExplosionDamageType] = 0.0;
$DamageScale[DAarmor, $MissileDamageType] = 0.0;
$DamageScale[DAarmor, $ShrapnelDamageType] = 0.0;
$DamageScale[DAarmor, $DebrisDamageType] = 0.0;
$DamageScale[DAarmor, $LaserDamageType] = 0.0;
$DamageScale[DAarmor, $MortarDamageType] = 0.0;
$DamageScale[DAarmor, $BlasterDamageType] = 0.0;
$DamageScale[DAarmor, $ElectricityDamageType] = 0.0;
$DamageScale[DAarmor, $MineDamageType] = 0.0;
$DamageScale[DAarmor, $SniperDamageType] = 0.0;
$DamageScale[DAarmor, $FlashDamageType] = 0.0;
$DamageScale[DAarmor, $MagneticDamageType] = 0; 
$DamageScale[DAarmor, $EMPDamageType] = 0;
$DamageScale[DAarmor, $FlamerDamageType] = 0;

$ItemMax[DAarmor, Flamer] = 1;
$ItemMax[DAarmor, Heal] = 1;
$ItemMax[DAarmor, Implode] = 1;
$ItemMax[DAarmor, Freeze] = 1;
$ItemMax[DAarmor, ESP] = 1;
$ItemMax[DAarmor, FireBall] = 1;
$ItemMax[DAarmor, DFA] = 1;
$ItemMax[DAarmor, PLA] = 1;
$ItemMax[DAarmor, GodTear] = 1;
$ItemMax[DAarmor, Quake] = 1;
$ItemMax[DAarmor, AB] = 1;
$ItemMax[DAarmor, WG] = 1;
$ItemMax[DAarmor, HM] = 1;
$ItemMax[DAarmor, MineAmmo] = 100;
$ItemMax[DAarmor, Grenade] = 100;
$ItemMax[DAarmor, Beacon] = 100;

$ItemMax[DAarmor, PhoenixPack] = 1;

$MaxWeapons[DAarmor] = 100;

//=========================================================================



ItemImageData SCFPackImage
{
	shapeFile = "paintgun";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0.2, 0.4, 0.32 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false;
};

ItemData SCFPack
{
	description = "logo";
	className = "Addon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = SCFPackImage;
	showWeaponBar = false;
	showInventory = false;
};

function SCFPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function SCFPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function SCFPack::onUnmount(%player,%item)
{
		Player::unmountItem(%player,$WeaponSlot);
}


ItemImageData SCPackImage
{
	shapeFile = "paintgun";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0.2, 0.4, 0.45 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false;
};

ItemData SCPack
{
	description = "logo";
	className = "Addon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = SCPackImage;
	showWeaponBar = false;
showInventory = false;
};

function SCPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function SCPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function SCPack::onUnmount(%player,%item)
{
		Player::unmountItem(%player,$WeaponSlot);
}


ItemImageData SyPackImage
{
	shapeFile = "logo";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SyPack
{
	description = "logo";
	className = "Addon";
	shapeFile = "mortarpack";
	shadowDetailMask = 4;
	imageType = SyPackImage;
	showWeaponBar = false;
showInventory = false;
};

function SyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function SyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function SyPack::onUnmount(%player,%item)
{
		Player::unmountItem(%player,$WeaponSlot);
}

ItemImageData MortarPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	firstPerson = false;
};

ItemData MortarPack
{
	description = "Mortarpack";
	className = "Addon";
	shapeFile = "mortarpack";
	shadowDetailMask = 4;
	imageType = MortarPackImage;
	showWeaponBar = false;
showInventory = false;
};

function MortarPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function MortarPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function MortarPack::onUnmount(%player,%item)
{
		Player::unmountItem(%player,$WeaponSlot);
}

//====================================
ItemImageData Booster1PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	firstPerson = false;
};

ItemData Booster1Pack
{
	description = "Booster1";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Booster1PackImage::onActivate(%player,%imageSlot){}
function Booster1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//===============================================

ItemImageData Booster2PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { -0.25, -0.1, 0.20 };
	mountRotation = { -1.57, -2.99, 0 }; 
	firstPerson = false;
};

ItemData Booster2Pack
{
	description = "Booster2";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//---------------------------------------------------
//	RIFLE PACK
//---------------------------------------------------
ItemImageData RiflePackImage
{
	shapeFile = "Sniper";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	firstPerson = false;
};

ItemData RiflePack
{
	description = "Rifle";
	className = "Addon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = RiflePackImage;
	showWeaponBar = false;
showInventory = false;
};

function RiflePackImage::onActivate(%player,%imageSlot){}
function RiflePackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}




ItemImageData RiflePack1Image
{
	shapeFile = "ammopack";
	weaponType = 0; 
	mountPoint = 2; 
	mountrotation = { 0, 0, -11 };
	mountOffset = { 0.2, -0.03, 0.2 };
	firstPerson = false;
};

ItemData RiflePack1
{
	description = "Rifle1";
	className = "Addon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = RiflePack1Image;
	showWeaponBar = false;
showInventory = false;
};

function RiflePack1Image::onActivate(%player,%imageSlot){}
function RiflePack1Image::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}



//====================================
ItemImageData AL1PackImage
{
	shapeFile = "grenadel";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	firstPerson = false;
};

ItemData AL1Pack
{
	description = "AL1";
	className = "Addon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = AL1PackImage;
	showWeaponBar = false;
showInventory = false;
};

function AL1PackImage::onActivate(%player,%imageSlot){}
function AL1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//===============================================

ItemImageData AL2PackImage
{
	shapeFile = "grenadel";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset = { -0.25, -0.1, 0.20 };
	mountRotation = { -1.57, -2.99, 0 }; 
	firstPerson = false;
};

ItemData AL2Pack
{
	description = "AL2Pack";
	className = "Addon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = AL2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function AL2PackImage::onActivate(%player,%imageSlot){}
function AL2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//====================================
ItemImageData Merc1PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset   = { 0.4, 0, 0.15 };
  	mountRotation = { -0.5, 0, 1.2 };
	firstPerson = false;
};

ItemData Merc1Pack
{
	description = "M1";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Merc1PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Merc1PackImage::onActivate(%player,%imageSlot){}
function Merc1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Merc2PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset   = { -0.4, 0, 0.15 };
  	mountRotation = { -0.5, 0, -1.2 };
	firstPerson = false;
};

ItemData Merc2Pack
{
	description = "M2";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Merc2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Merc2PackImage::onActivate(%player,%imageSlot){}
function Merc2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Merc3PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset   = { -0.4, 0, 0.3 };
  	mountRotation = { 0.1, 0, 0 };
	firstPerson = false;
};

ItemData Merc3Pack
{
	description = "M3";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Merc3PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Merc3PackImage::onActivate(%player,%imageSlot){}
function Merc3PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Merc4PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 2; 
	mountOffset   = { 0.4, 0, 0.3 };
  	mountRotation = { 0.1, 0, 0 };
	firstPerson = false;
};

ItemData Merc4Pack
{
	description = "M4";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = Merc4PackImage;
	showWeaponBar = false;
showInventory = false;
};

function Merc4PackImage::onActivate(%player,%imageSlot){}
function Merc4PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//==============================================
ItemImageData CY1PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 3; 
	mountOffset = { -0.27, 0.2, 2.2 }; 
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CY1Pack
{
	description = "CY1nPack";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = CY1PackImage;
	showWeaponBar = false;
showInventory = false;
};

function CY1PackImage::onActivate(%player,%imageSlot){}
function CY1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData CY2PackImage
{
	shapeFile = "mortargun";
	weaponType = 0; 
	mountPoint = 3; 
	mountOffset = { 0.46, 0.2, 2.2 }; 
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CY2Pack
{
	description = "CY2nPack";
	className = "Addon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = CY2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function CY2PackImage::onActivate(%player,%imageSlot){}
function CY2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//====================================
ItemImageData DRPackImage
{
	shapeFile = "mineammo";
	weaponType = 0; 
	mountPoint = 2; 
mountOffset   = { -0.3, 0, 0.35 };
  mountRotation = { 0.75, -0.3, 0 };
	firstPerson = false;
};

ItemData DRPack
{
	description = "M1";
	className = "Addon";
	shapeFile = "mineammo";
	shadowDetailMask = 4;
	imageType = DRPackImage;
	showWeaponBar = false;
showInventory = false;
};

function DRPackImage::onActivate(%player,%imageSlot){}
function DRPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData DR2PackImage
{
	shapeFile = "mineammo";
	weaponType = 0; 
	mountPoint = 2; 
mountOffset   = { 0.3, 0, 0.35 };
  mountRotation = { 0.75, 0.3, 0 };
	firstPerson = false;
};

ItemData DR2Pack
{
	description = "M2";
	className = "Addon";
	shapeFile = "mineammo";
	shadowDetailMask = 4;
	imageType = DR2PackImage;
	showWeaponBar = false;
showInventory = false;
};

function DR2PackImage::onActivate(%player,%imageSlot){}
function DR2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData DR3PackImage
{
	shapeFile = "mineammo";
	weaponType = 0; 
	mountPoint = 2; 
  mountOffset   = { 0.5, 0, 0 };
  mountRotation = { 1.5, 0, 0 };
	firstPerson = false;
};

ItemData DR3Pack
{
	description = "M3";
	className = "Addon";
	shapeFile = "mineammo";
	shadowDetailMask = 4;
	imageType = DR3PackImage;
	showWeaponBar = false;
showInventory = false;
};

function DR3PackImage::onActivate(%player,%imageSlot){}
function DR3PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData DR4PackImage
{
	shapeFile = "mineammo";
	weaponType = 0; 
	mountPoint = 2; 
  mountOffset   = { -0.5, 0, 0 };
  mountRotation = { 1.5, 0, 0 };
	firstPerson = false;
};

ItemData DR4Pack
{
	description = "M4";
	className = "Addon";
	shapeFile = "mineammo";
	shadowDetailMask = 4;
	imageType = DR4PackImage;
	showWeaponBar = false;
showInventory = false;
};

function DR4PackImage::onActivate(%player,%imageSlot){}
function DR4PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//==============================================
$DamageScale[spyarmor, $RailDamageType] = 0.8; 
$DamageScale[spyfemale, $RailDamageType] = 0.8;  
$DamageScale[sarmor, $RailDamageType] = 0.8; 
$DamageScale[sfemale, $RailDamageType] = 0.8; 
$DamageScale[barmor, $RailDamageType] = 1.0; 
$DamageScale[bfemale, $RailDamageType] = 1.05; 
$DamageScale[aarmor, $RailDamageType] = 1.0; 
$DamageScale[afemale, $RailDamageType] = 1.0; 
$DamageScale[earmor, $RailDamageType] = 0.98; 
$DamageScale[efemale, $RailDamageType] = 0.98; 
$DamageScale[darmor, $RailDamageType] = 1.55; 
$DamageScale[dmarmor, $RailDamageType] = 1.05; 
$DamageScale[dmfemale, $RailDamageType] = 1.05;
$DamageScale[lfemale, $RailDamageType] = 0.8;
$DamageScale[larmor, $RailDamageType] = 0.8;
$DamageScale[mfemale, $RailDamageType] = 1.0;
$DamageScale[marmor, $RailDamageType] = 1.0;
$DamageScale[harmor, $RailDamageType] = 1.35;
//=============================================
$DamageScale[spyarmor, $FlameDamageType] = 1.0; 
$DamageScale[spyfemale, $FlameDamageType] = 1.0;  
$DamageScale[sarmor, $FlameDamageType] = 0.8; 
$DamageScale[sfemale, $FlameDamageType] = 0.8; 
$DamageScale[barmor, $FlameDamageType] = 0.3; 
$DamageScale[bfemale, $FlameDamageType] = 0.3; 
$DamageScale[aarmor, $FlameDamageType] = 1.4; 
$DamageScale[afemale, $FlameDamageType] = 1.4; 
$DamageScale[earmor, $FlameDamageType] = 0.8; 
$DamageScale[efemale, $FlameDamageType] = 0.8; 
$DamageScale[darmor, $FlameDamageType] = 0.6; 
$DamageScale[dmarmor, $FlameDamageType] = 0.8; 
$DamageScale[dmfemale, $FlameDamageType] = 0.8;
$DamageScale[lfemale, $FlameDamageType] = 0.7;
$DamageScale[larmor, $FlameDamageType] = 0.7;
$DamageScale[mfemale, $FlameDamageType] = 0.8;
$DamageScale[marmor, $FlameDamageType] = 0.8;
$DamageScale[harmor, $FlameDamageType] = 0.7;
//=============================================
$DamageScale[spyarmor, $TurretDamageType] = 1.0; 
$DamageScale[spyfemale, $TurretDamageType] = 1.0;  
$DamageScale[sarmor, $TurretDamageType] = 0.5; 
$DamageScale[sfemale, $TurretDamageType] = 0.5; 
$DamageScale[barmor, $TurretDamageType] = 1.0; 
$DamageScale[bfemale, $TurretDamageType] = 1.0; 
$DamageScale[aarmor, $TurretDamageType] = 0.4; 
$DamageScale[afemale, $TurretDamageType] = 0.4; 
$DamageScale[earmor, $TurretDamageType] = 1.0; 
$DamageScale[efemale, $TurretDamageType] = 1.0; 
$DamageScale[darmor, $TurretDamageType] = 0.8; 
$DamageScale[dmarmor, $TurretDamageType] = 1.0; 
$DamageScale[dmfemale, $TurretDamageType] = 1.0;
$DamageScale[lfemale, $TurretDamageType] = 0.9;
$DamageScale[larmor, $TurretDamageType] = 0.9;
$DamageScale[mfemale, $TurretDamageType] = 1.0;
$DamageScale[marmor, $TurretDamageType] = 1.0;
$DamageScale[harmor, $TurretDamageType] = 0.7;
//=============================================
$DamageScale[darmor, $TBulletDamageType] = 0.3;
$DamageScale[larmor, $TBulletDamageType] = 0.5; 
$DamageScale[marmor, $TBulletDamageType] = 0.5; 
$DamageScale[sarmor, $TBulletDamageType] = 0.8; 
$DamageScale[barmor, $TBulletDamageType] = 0.5; 
$DamageScale[spyarmor, $TBulletDamageType] = 0.5;
$DamageScale[earmor, $TBulletDamageType] = 0.4; 
$DamageScale[aarmor, $TBulletDamageType] = 1.2;
$DamageScale[dmarmor, $TBulletDamageType] = 0.8; 
$DamageScale[lfemale, $TBulletDamageType] = 0.5; 
$DamageScale[mfemale, $TBulletDamageType] = 0.5; 
$DamageScale[harmor, $TBulletDamageType] = 0.6;
$DamageScale[sfemale, $TBulletDamageType] = 0.8; 
$DamageScale[bfemale, $TBulletDamageType] = 0.5; 
$DamageScale[spyfemale, $TBulletDamageType] = 0.5;
$DamageScale[efemale, $TBulletDamageType] = 0.4; 
$DamageScale[afemale, $TBulletDamageType] = 1.2; 
$DamageScale[dmfemale, $TBulletDamageType] = 0.8; 
//=============================================
$DamageScale[darmor, $Vulcan2DamageType] = 0.3;
$DamageScale[darmor, $MagnumDamageType] = 0.6;
$DamageScale[larmor, $MagnumDamageType] = 0.9; 
$DamageScale[larmor, $Vulcan2DamageType] = 0.5; 
$DamageScale[marmor, $MagnumDamageType] = 1.0; 
$DamageScale[marmor, $Vulcan2DamageType] = 0.5; 
$DamageScale[sarmor, $MagnumDamageType] = 0.9;
$DamageScale[sarmor, $Vulcan2DamageType] = 0.8; 
$DamageScale[barmor, $MagnumDamageType] = 1.1; 
$DamageScale[barmor, $Vulcan2DamageType] = 0.5; 
$DamageScale[spyarmor, $MagnumDamageType] = 0.8; 
$DamageScale[spyarmor, $Vulcan2DamageType] = 0.5;
$DamageScale[earmor, $MagnumDamageType] = 1.0; 
$DamageScale[earmor, $Vulcan2DamageType] = 0.4; 
$DamageScale[aarmor, $MagnumDamageType] = 0.5; 
$DamageScale[aarmor, $Vulcan2DamageType] = 1.2; 
$DamageScale[dmarmor, $MagnumDamageType] = 1.0; 
$DamageScale[dmarmor, $Vulcan2DamageType] = 0.8; 
$DamageScale[lfemale, $MagnumDamageType] = 0.9; 
$DamageScale[lfemale, $Vulcan2DamageType] = 0.5; 
$DamageScale[mfemale, $MagnumDamageType] = 1.0; 
$DamageScale[mfemale, $Vulcan2DamageType] = 0.5; 
$DamageScale[harmor, $MagnumDamageType] = 0.8;
$DamageScale[harmor, $Vulcan2DamageType] = 0.7;
$DamageScale[sfemale, $MagnumDamageType] = 0.9;
$DamageScale[sfemale, $Vulcan2DamageType] = 0.8; 
$DamageScale[bfemale, $MagnumDamageType] = 1.1; 
$DamageScale[bfemale, $Vulcan2DamageType] = 0.5; 
$DamageScale[spyfemale, $MagnumDamageType] = 0.8; 
$DamageScale[spyfemale, $Vulcan2DamageType] = 0.5;
$DamageScale[efemale, $MagnumDamageType] = 1.0; 
$DamageScale[efemale, $Vulcan2DamageType] = 0.4; 
$DamageScale[afemale, $MagnumDamageType] = 0.5; 
$DamageScale[afemale, $Vulcan2DamageType] = 1.2; 
$DamageScale[dmfemale, $MagnumDamageType] = 1.0; 
$DamageScale[dmfemale, $Vulcan2DamageType] = 0.8; 
//================================================
$ItemMax[spyarmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[spyfemale, LargeForceFieldDoorPack] = 1;  
$ItemMax[sarmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[sfemale, LargeForceFieldDoorPack] = 1; 
$ItemMax[barmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[bfemale, LargeForceFieldDoorPack] = 1; 
$ItemMax[aarmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[afemale, LargeForceFieldDoorPack] = 1; 
$ItemMax[earmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[efemale, LargeForceFieldDoorPack] = 1; 
$ItemMax[darmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[dmarmor, LargeForceFieldDoorPack] = 1; 
$ItemMax[dmfemale, LargeForceFieldDoorPack] = 1;
$ItemMax[lfemale, LargeForceFieldDoorPack] = 1;
$ItemMax[larmor, LargeForceFieldDoorPack] = 1;
$ItemMax[mfemale, LargeForceFieldDoorPack] = 1;
$ItemMax[marmor, LargeForceFieldDoorPack] = 1;
$ItemMax[harmor, LargeForceFieldDoorPack] = 1;
//================================================
$ItemMax[spyarmor, ForceFieldDoorPack] = 1; 
$ItemMax[spyfemale, ForceFieldDoorPack] = 1;  
$ItemMax[sarmor, ForceFieldDoorPack] = 1; 
$ItemMax[sfemale, ForceFieldDoorPack] = 1; 
$ItemMax[barmor, ForceFieldDoorPack] = 1; 
$ItemMax[bfemale, ForceFieldDoorPack] = 1; 
$ItemMax[aarmor, ForceFieldDoorPack] = 1; 
$ItemMax[afemale, ForceFieldDoorPack] = 1; 
$ItemMax[earmor, ForceFieldDoorPack] = 1; 
$ItemMax[efemale, ForceFieldDoorPack] = 1; 
$ItemMax[darmor, ForceFieldDoorPack] = 1; 
$ItemMax[dmarmor, ForceFieldDoorPack] = 1; 
$ItemMax[dmfemale, ForceFieldDoorPack] = 1;
$ItemMax[lfemale, ForceFieldDoorPack] = 1;
$ItemMax[larmor, ForceFieldDoorPack] = 1;
$ItemMax[mfemale, ForceFieldDoorPack] = 1;
$ItemMax[marmor, ForceFieldDoorPack] = 1;
$ItemMax[harmor, ForceFieldDoorPack] = 1;
//================================================
$ItemMax[spyarmor, ImpulsePack] = 0; 
$ItemMax[spyfemale, ImpulsePack] = 0;  
$ItemMax[sarmor, ImpulsePack] = 0; 
$ItemMax[sfemale, ImpulsePack] = 0; 
$ItemMax[barmor, ImpulsePack] = 0; 
$ItemMax[bfemale, ImpulsePack] = 0; 
$ItemMax[aarmor, ImpulsePack] = 0; 
$ItemMax[afemale, ImpulsePack] = 0; 
$ItemMax[earmor, ImpulsePack] = 0; 
$ItemMax[efemale, ImpulsePack] = 0; 
$ItemMax[darmor, ImpulsePack] = 0; 
$ItemMax[dmarmor, ImpulsePack] = 0; 
$ItemMax[dmfemale, ImpulsePack] = 0;
$ItemMax[lfemale, ImpulsePack] = 0;
$ItemMax[larmor, ImpulsePack] = 0;
$ItemMax[mfemale, ImpulsePack] = 1;
$ItemMax[marmor, ImpulsePack] = 1;
$ItemMax[harmor, ImpulsePack] = 1;
//================================================
$ItemMax[spyarmor, FlameTurretPack] = 0; 
$ItemMax[spyfemale, FlameTurretPack] = 0;  
$ItemMax[sarmor, FlameTurretPack] = 0; 
$ItemMax[sfemale, FlameTurretPack] = 0; 
$ItemMax[barmor, FlameTurretPack] = 1; 
$ItemMax[bfemale, FlameTurretPack] = 1; 
$ItemMax[aarmor, FlameTurretPack] = 0; 
$ItemMax[afemale, FlameTurretPack] = 0; 
$ItemMax[earmor, FlameTurretPack] = 1; 
$ItemMax[efemale, FlameTurretPack] = 1; 
$ItemMax[darmor, FlameTurretPack] = 1; 
$ItemMax[dmarmor, FlameTurretPack] = 0; 
$ItemMax[dmfemale, FlameTurretPack] = 0;
$ItemMax[lfemale, FlameTurretPack] = 0;
$ItemMax[larmor, FlameTurretPack] = 0;
$ItemMax[mfemale, FlameTurretPack] = 0;
$ItemMax[marmor, FlameTurretPack] = 0;
$ItemMax[harmor, FlameTurretPack] = 1;
//================================================
$ItemMax[larmor, PlasmaCannon] = 0;
$ItemMax[lfemale, PlasmaCannon] = 0;
$ItemMax[marmor, PlasmaCannon] = 0;
$ItemMax[mfemale, PlasmaCannon] = 0;
$ItemMax[harmor, PlasmaCannon] = 0;
$ItemMax[sarmor, PlasmaCannon] = 0;
$ItemMax[sfemale, PlasmaCannon] = 0;
$ItemMax[spyarmor, PlasmaCannon] = 0;
$ItemMax[spyfemale, PlasmaCannon] = 0;
$ItemMax[barmor, PlasmaCannon] = 0;
$ItemMax[bfemale, PlasmaCannon] = 0;
$ItemMax[earmor, PlasmaCannon] = 0;
$ItemMax[efemale, PlasmaCannon] = 0;
$ItemMax[aarmor, PlasmaCannon] = 1;
$ItemMax[afemale, PlasmaCannon] = 1;
$ItemMax[darmor, PlasmaCannon] = 0;
//================================================
$ItemMax[spyarmor, HDiscLauncher] = 0; 
$ItemMax[spyfemale, HDiscLauncher] = 0;  
$ItemMax[sarmor, HDiscLauncher] = 0; 
$ItemMax[sfemale, HDiscLauncher] = 0; 
$ItemMax[barmor, HDiscLauncher] = 0; 
$ItemMax[bfemale, HDiscLauncher] = 0; 
$ItemMax[aarmor, HDiscLauncher] = 0; 
$ItemMax[afemale, HDiscLauncher] = 0; 
$ItemMax[earmor, HDiscLauncher] = 0; 
$ItemMax[efemale, HDiscLauncher] = 0; 
$ItemMax[darmor, HDiscLauncher] = 0; 
$ItemMax[dmarmor, HDiscLauncher] = 0; 
$ItemMax[dmfemale, HDiscLauncher] = 0;
$ItemMax[lfemale, HDiscLauncher] = 0;
$ItemMax[larmor, HDiscLauncher] = 0;
$ItemMax[mfemale, HDiscLauncher] = 1;
$ItemMax[marmor, HDiscLauncher] = 1;
$ItemMax[harmor, HDiscLauncher] = 0;
//================================================
$ItemMax[spyarmor, HDiscAmmo] = 0; 
$ItemMax[spyfemale, HDiscAmmo] = 0;  
$ItemMax[sarmor, HDiscAmmo] = 0; 
$ItemMax[sfemale, HDiscAmmo] = 0; 
$ItemMax[barmor, HDiscAmmo] = 0; 
$ItemMax[bfemale, HDiscAmmo] = 0; 
$ItemMax[aarmor, HDiscAmmo] = 0; 
$ItemMax[afemale, HDiscAmmo] = 0; 
$ItemMax[earmor, HDiscAmmo] = 0; 
$ItemMax[efemale, HDiscAmmo] = 0; 
$ItemMax[darmor, HDiscAmmo] = 0; 
$ItemMax[dmarmor, HDiscAmmo] = 0; 
$ItemMax[dmfemale, HDiscAmmo] = 0;
$ItemMax[lfemale, HDiscAmmo] = 0;
$ItemMax[larmor, HDiscAmmo] = 0;
$ItemMax[mfemale, HDiscAmmo] = 7;
$ItemMax[marmor, HDiscAmmo] = 7;
$ItemMax[harmor, HDiscAmmo] = 0;
//================================================
$ItemMax[spyarmor, TrackerMissilePack] = 0; 
$ItemMax[spyfemale, TrackerMissilePack] = 0;  
$ItemMax[sarmor, TrackerMissilePack] = 0; 
$ItemMax[sfemale, TrackerMissilePack] = 0; 
$ItemMax[barmor, TrackerMissilePack] = 0; 
$ItemMax[bfemale, TrackerMissilePack] = 0; 
$ItemMax[aarmor, TrackerMissilePack] = 0; 
$ItemMax[afemale, TrackerMissilePack] = 0; 
$ItemMax[earmor, TrackerMissilePack] = 0; 
$ItemMax[efemale, TrackerMissilePack] = 0; 
$ItemMax[darmor, TrackerMissilePack] = 1; 
$ItemMax[dmarmor, TrackerMissilePack] = 0; 
$ItemMax[dmfemale, TrackerMissilePack] = 0;
$ItemMax[lfemale, TrackerMissilePack] = 0;
$ItemMax[larmor, TrackerMissilePack] = 0;
$ItemMax[mfemale, TrackerMissilePack] = 0;
$ItemMax[marmor, TrackerMissilePack] = 0;
$ItemMax[harmor, TrackerMissilePack] = 0;
//================================================
$ItemMax[spyarmor, TrackerMissileAmmo] = 0; 
$ItemMax[spyfemale, TrackerMissileAmmo] = 0;  
$ItemMax[sarmor, TrackerMissileAmmo] = 0; 
$ItemMax[sfemale, TrackerMissileAmmo] = 0; 
$ItemMax[barmor, TrackerMissileAmmo] = 0; 
$ItemMax[bfemale, TrackerMissileAmmo] = 0; 
$ItemMax[aarmor, TrackerMissileAmmo] = 0; 
$ItemMax[afemale, TrackerMissileAmmo] = 0; 
$ItemMax[earmor, TrackerMissileAmmo] = 0; 
$ItemMax[efemale, TrackerMissileAmmo] = 0; 
$ItemMax[darmor, TrackerMissileAmmo] = 10; 
$ItemMax[dmarmor, TrackerMissileAmmo] = 0; 
$ItemMax[dmfemale, TrackerMissileAmmo] = 0;
$ItemMax[lfemale, TrackerMissileAmmo] = 0;
$ItemMax[larmor, TrackerMissileAmmo] = 0;
$ItemMax[mfemale, TrackerMissileAmmo] = 0;
$ItemMax[marmor, TrackerMissileAmmo] = 0;
$ItemMax[harmor, TrackerMissileAmmo] = 0;
//================================================
$ItemMax[spyarmor, TargetMarkLaser] = 0; 
$ItemMax[spyfemale, TargetMarkLaser] = 0;  
$ItemMax[sarmor, TargetMarkLaser] = 0; 
$ItemMax[sfemale, TargetMarkLaser] = 0; 
$ItemMax[barmor, TargetMarkLaser] = 0; 
$ItemMax[bfemale, TargetMarkLaser] = 0; 
$ItemMax[aarmor, TargetMarkLaser] = 0; 
$ItemMax[afemale, TargetMarkLaser] = 0; 
$ItemMax[earmor, TargetMarkLaser] = 0; 
$ItemMax[efemale, TargetMarkLaser] = 0; 
$ItemMax[darmor, TargetMarkLaser] = 1; 
$ItemMax[dmarmor, TargetMarkLaser] = 0; 
$ItemMax[dmfemale, TargetMarkLaser] = 0;
$ItemMax[lfemale, TargetMarkLaser] = 0;
$ItemMax[larmor, TargetMarkLaser] = 0;
$ItemMax[mfemale, TargetMarkLaser] = 0;
$ItemMax[marmor, TargetMarkLaser] = 0;
$ItemMax[harmor, TargetMarkLaser] = 0;
//================================================
$DamageScale[spyarmor, $VulcanDamageType] = 0.5; 
$DamageScale[spyfemale, $VulcanDamageType] = 0.5;  
$DamageScale[sarmor, $VulcanDamageType] = 0.5; 
$DamageScale[sfemale, $VulcanDamageType] = 0.5; 
$DamageScale[barmor, $VulcanDamageType] = 0.4; 
$DamageScale[bfemale, $VulcanDamageType] = 0.4; 
$DamageScale[aarmor, $VulcanDamageType] = 0.4; 
$DamageScale[afemale, $VulcanDamageType] = 0.4; 
$DamageScale[earmor, $VulcanDamageType] = 0.4; 
$DamageScale[efemale, $VulcanDamageType] = 0.4; 
$DamageScale[darmor, $VulcanDamageType] = 0.4; 
$DamageScale[dmarmor, $VulcanDamageType] = 0.5; 
$DamageScale[dmfemale, $VulcanDamageType] = 0.5;
$DamageScale[lfemale, $VulcanDamageType] = 0.5;
$DamageScale[larmor, $VulcanDamageType] = 0.5;
$DamageScale[mfemale, $VulcanDamageType] = 0.38;
$DamageScale[marmor, $VulcanDamageType] = 0.38;
$DamageScale[harmor, $VulcanDamageType] = 0.4;
//================================================
$DamageScale[spyarmor, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[spyfemale, $PlasmaCannonDamageType] = 0.7;  
$DamageScale[sarmor, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[sfemale, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[barmor, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[bfemale, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[aarmor, $PlasmaCannonDamageType] = 0.5; 
$DamageScale[afemale, $PlasmaCannonDamageType] = 0.5; 
$DamageScale[earmor, $PlasmaCannonDamageType] = 0.6; 
$DamageScale[efemale, $PlasmaCannonDamageType] = 0.6; 
$DamageScale[darmor, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[dmarmor, $PlasmaCannonDamageType] = 0.7; 
$DamageScale[dmfemale, $PlasmaCannonDamageType] = 0.7;
$DamageScale[lfemale, $PlasmaCannonDamageType] = 0.7;
$DamageScale[larmor, $PlasmaCannonDamageType] = 0.7;
$DamageScale[mfemale, $PlasmaCannonDamageType] = 0.7;
$DamageScale[marmor, $PlasmaCannonDamageType] = 0.7;
$DamageScale[harmor, $PlasmaCannonDamageType] = 0.7;
//================================================

//larmor = Male Sniper 

$DamageScale[larmor, $LandingDamageType] = 0.9; 
$DamageScale[larmor, $ImpactDamageType] = 1.0; 
$DamageScale[larmor, $CrushDamageType] = 1.0; 
$DamageScale[larmor, $BulletDamageType] = 0.5; 
$DamageScale[larmor, $PlasmaDamageType] = 0.8; 
$DamageScale[larmor, $EnergyDamageType] = 1.0; 
$DamageScale[larmor, $ExplosionDamageType] = 1.0; 
$DamageScale[larmor, $MissileDamageType] = 1.0;
$DamageScale[larmor, $DebrisDamageType] = 1.0; 
$DamageScale[larmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[larmor, $LaserDamageType] = 0.9; 
$DamageScale[larmor, $MortarDamageType] = 1.0; 
$DamageScale[larmor, $BlasterDamageType] = 1.0; 
$DamageScale[larmor, $ElectricityDamageType] = 1.0; 
$DamageScale[larmor, $MineDamageType] = 1.2; 
$DamageScale[larmor, $SniperDamageType] = 0.85; 
$DamageScale[larmor, $FlashDamageType] = 1.0; 
$DamageScale[larmor, $LowWarheadDamageType] = 1.0;
$DamageScale[larmor, $MedWarheadDamageType] = 1.0;
$DamageScale[larmor, $HighWarheadDamageType] = 1.3;
$DamageScale[larmor, $EMPWarheadDamageType] = 1.0;

$ItemMax[larmor, Blaster] = 1; 
$ItemMax[larmor, Chaingun] = 1; 
$ItemMax[larmor, Disclauncher] = 1; 
$ItemMax[larmor, GrenadeLauncher] = 1; 
$ItemMax[larmor, Mortar] = 0; 
$ItemMax[larmor, PlasmaGun] = 1; 
$ItemMax[larmor, LaserRifle] = 1; 
$ItemMax[larmor, EnergyRifle] = 1; 
$ItemMax[larmor, TargetingLaser] = 1; 
$ItemMax[larmor, MineAmmo] = 3; 
$ItemMax[larmor, Grenade] = 3;
$ItemMax[larmor, Beacon] = 3; 
$ItemMax[larmor, Boost] = 3; 
$ItemMax[larmor, Plastique] = 0; 
$ItemMax[larmor, RocketLauncher] = 0; 
$ItemMax[larmor, SniperRifle] = 1; 
$ItemMax[larmor, WaveGun] = 0; 
$ItemMax[larmor, Railgun] = 1; 
$ItemMax[larmor, Vulcan] = 0; 
$ItemMax[larmor, Vulcan2] = 0;
$ItemMax[larmor, Silencer] = 0; 
$ItemMax[larmor, Flamer] = 0; 
$ItemMax[larmor, IonGun] = 0; 
$ItemMax[larmor, Omega] = 0; 
$ItemMax[larmor, HyperB] = 0; 
$ItemMax[larmor, Fixit] = 0; 

$ItemMax[larmor, BulletAmmo] = 100; 
$ItemMax[larmor, PlasmaAmmo] = 30; 
$ItemMax[larmor, DiscAmmo] = 15; 
$ItemMax[larmor, GrenadeAmmo] = 10; 
$ItemMax[larmor, MortarAmmo] = 10; 
$ItemMax[larmor, SniperAmmo] = 15; 
$ItemMax[larmor, SilencerAmmo] = 25; 
$ItemMax[larmor, RailAmmo] = 10;

$ItemMax[larmor, EnergyPack] = 1; 
$ItemMax[larmor, RepairPack] = 1; 
$ItemMax[larmor, ShieldPack] = 1; 
$ItemMax[larmor, SensorJammerPack] = 1; 
$ItemMax[larmor, MotionSensorPack] = 1; 
$ItemMax[larmor, PulseSensorPack] = 1; 
$ItemMax[larmor, HeatSink] = 1;
$ItemMax[larmor, DeployableSensorJammerPack] = 1; 
$ItemMax[larmor, CameraPack] = 1; 
$ItemMax[larmor, TurretPack] = 0; 
$ItemMax[larmor, AmmoPack] = 1; 
$ItemMax[larmor, RepairKit] = 2;
$ItemMax[larmor, DeployableInvPack] = 0; 
$ItemMax[larmor, DeployableAmmoPack] = 0; 
$ItemMax[larmor, DeployableComPack] = 0; 
$ItemMax[larmor, LaserTurret] = 0; 
$ItemMax[larmor, ForceFieldPack] = 1; 
$ItemMax[larmor, RocketPack] = 0; 
$ItemMax[larmor, LaserPack] = 0; 
$ItemMax[larmor, CloakingDevice] = 0; 
$ItemMax[larmor, StealthShieldPack] = 0; 
$ItemMax[larmor, TreePack] = 1; 
$ItemMax[larmor, TargetPack] = 0; 
$ItemMax[larmor, MechPack] = 0; 
$ItemMax[larmor, ScoutPack] = 0; 
$ItemMax[larmor, Laptop] = 0; 
$ItemMax[larmor, ShockPack] = 0; 
$ItemMax[larmor, SpringPack] = 0; 
$ItemMax[larmor, TeleportPack] = 0; 
$ItemMax[larmor, TripwirePack] = 0; 
$ItemMax[larmor, SuicidePack] = 0; 
$ItemMax[larmor, HPCPack] = 0; 
$ItemMax[larmor, HoloPack] = 1; 
$ItemMax[larmor, OpticPack] = 1; 
$ItemMax[larmor, Vengeance] = 0; 
$ItemMax[larmor, RailTurret] = 0; 
$ItemMax[larmor, VulcanTurret] = 0; 
$ItemMax[larmor, TLaserPack] = 1;

$MaxWeapons[larmor] = 3; 

//marmor = Male Mercenary 

$DamageScale[marmor, $LandingDamageType] = 1.0; 
$DamageScale[marmor, $ImpactDamageType] = 1.0; 
$DamageScale[marmor, $CrushDamageType] = 1.0; 
$DamageScale[marmor, $BulletDamageType] = 0.5; 
$DamageScale[marmor, $PlasmaDamageType] = 0.8; 
$DamageScale[marmor, $EnergyDamageType] = 1.0; 
$DamageScale[marmor, $ExplosionDamageType] = 1.0; 
$DamageScale[marmor, $MissileDamageType] = 1.0; 
$DamageScale[marmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[marmor, $DebrisDamageType] = 1.0; 
$DamageScale[marmor, $LaserDamageType] = 1.0; 
$DamageScale[marmor, $MortarDamageType] = 0.9; 
$DamageScale[marmor, $BlasterDamageType] = 1.0; 
$DamageScale[marmor, $ElectricityDamageType] = 1.0; 
$DamageScale[marmor, $MineDamageType] = 1.0; 
$DamageScale[marmor, $SniperDamageType] = 1.2; 
$DamageScale[marmor, $FlashDamageType] = 1.0; 
$DamageScale[marmor, $LowWarheadDamageType] = 1.0;
$DamageScale[marmor, $MedWarheadDamageType] = 1.0;
$DamageScale[marmor, $HighWarheadDamageType] = 1.0;
$DamageScale[marmor, $EMPWarheadDamageType] = 1.0;

$ItemMax[marmor, Blaster] = 1; 
$ItemMax[marmor, Chaingun] = 1; 
$ItemMax[marmor, Disclauncher] = 1; 
$ItemMax[marmor, GrenadeLauncher] = 1; 
$ItemMax[marmor, Mortar] = 0; 
$ItemMax[marmor, PlasmaGun] = 1; 
$ItemMax[marmor, LaserRifle] = 0; 
$ItemMax[marmor, EnergyRifle] = 1; 
$ItemMax[marmor, TargetingLaser] = 1; 
$ItemMax[marmor, MineAmmo] = 3; 
$ItemMax[marmor, Grenade] = 6; 
$ItemMax[marmor, Beacon] = 3;
$ItemMax[marmor, Boost] = 3; 
$ItemMax[marmor, Plastique] = 0; 
$ItemMax[marmor, RocketLauncher] = 0; 
$ItemMax[marmor, SniperRifle] = 0; 
$ItemMax[marmor, WaveGun] = 0; 
$ItemMax[marmor, Railgun] = 0; 
$ItemMax[marmor, Vulcan] = 1; 
$ItemMax[marmor, Vulcan2] = 0;
$ItemMax[marmor, Silencer] = 0; 
$ItemMax[marmor, Flamer] = 1; 
$ItemMax[marmor, IonGun] = 0; 
$ItemMax[marmor, Omega] = 0; 
$ItemMax[marmor, HyperB] = 1; 
$ItemMax[marmor, Fixit] = 0; 
$ItemMax[marmor, BulletAmmo] = 250; 
$ItemMax[marmor, PlasmaAmmo] = 30; 
$ItemMax[marmor, DiscAmmo] = 15; 
$ItemMax[marmor, GrenadeAmmo] = 15; 
$ItemMax[marmor, SniperAmmo] = 15; 
$ItemMax[marmor, SilencerAmmo] = 30; 
$ItemMax[marmor, VulcanAmmo] = 150;
$ItemMax[marmor, FlamerAmmo] = 75; 

$ItemMax[marmor, EnergyPack] = 1; 
$ItemMax[marmor, RepairPack] = 1; 
$ItemMax[marmor, ShieldPack] = 1; 
$ItemMax[marmor, SensorJammerPack] = 1; 
$ItemMax[marmor, MotionSensorPack] = 1; 
$ItemMax[marmor, PulseSensorPack] = 1; 
$ItemMax[marmor, HeatSink] = 1;
$ItemMax[marmor, DeployableSensorJammerPack] = 1; 
$ItemMax[marmor, CameraPack] = 1; 
$ItemMax[marmor, TurretPack] = 1; 
$ItemMax[marmor, AmmoPack] = 1; 
$ItemMax[marmor, RepairKit] = 1; 
$ItemMax[marmor, DeployableInvPack] = 0; 
$ItemMax[marmor, DeployableAmmoPack] = 1; 
$ItemMax[marmor, DeployableComPack] = 0; 
$ItemMax[marmor, LaserTurret] = 0; 
$ItemMax[marmor, ForceFieldPack] = 1; 
$ItemMax[marmor, RocketPack] = 0; 
$ItemMax[marmor, LaserPack] = 0; 
$ItemMax[marmor, CloakingDevice] = 0; 
$ItemMax[marmor, StealthShieldPack] = 0; 
$ItemMax[marmor, TargetPack] = 0; 
$ItemMax[marmor, MechPack] = 0; 
$ItemMax[marmor, Laptop] = 0; 
$ItemMax[marmor, ShockPack] = 0; 
$ItemMax[marmor, TeleportPack] = 0; 
$ItemMax[marmor, TripwirePack] = 0; 
$ItemMax[marmor, TreePack] = 0; 
$ItemMax[marmor, SpringPack] = 0; 
$ItemMax[marmor, SuicidePack] = 0; 
$ItemMax[marmor, HPCPack] = 0; 
$ItemMax[marmor, HoloPack] = 1; 
$ItemMax[marmor, Pack] = 0; 
$ItemMax[marmor, LightningPack] = 0; 
$ItemMax[marmor, OpticPack] = 0; 
$ItemMax[marmor, Vengeance] = 0; 
$ItemMax[marmor, RailTurret] = 0; 
$ItemMax[marmor, VulcanTurret] = 0; 
$ItemMax[marmor, TLaserPack] = 1;

$MaxWeapons[marmor] = 5; 

//harmor = Cyborg

 $DamageScale[harmor, $LandingDamageType] = 0.7;
 $DamageScale[harmor, $ImpactDamageType] = 0.5;
 $DamageScale[harmor, $CrushDamageType] = 1.0;
 $DamageScale[harmor, $BulletDamageType] = 0.65;
 $DamageScale[harmor, $PlasmaDamageType] = 0.7;
 $DamageScale[harmor, $EnergyDamageType] = 0.7;
 $DamageScale[harmor, $ExplosionDamageType] = 0.6;
 $DamageScale[harmor, $MissileDamageType] = 0.8;
 $DamageScale[harmor, $DebrisDamageType] = 0.7;
 $DamageScale[harmor, $ShrapnelDamageType] = 0.8;
 $DamageScale[harmor, $LaserDamageType] = 0.8;
 $DamageScale[harmor, $MortarDamageType] = 0.7;
 $DamageScale[harmor, $BlasterDamageType] = 0.7;
 $DamageScale[harmor, $ElectricityDamageType] = 0.8;
 $DamageScale[harmor, $MineDamageType] = 0.8;
 $DamageScale[harmor, $SniperDamageType] = 0.75;
 $DamageScale[harmor, $FlashDamageType] = 1.0; 
 $DamageScale[harmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[harmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[harmor, $HighWarheadDamageType] = 0.7;
 $DamageScale[harmor, $EMPWarheadDamageType] = 1.0;

 $ItemMax[harmor, Blaster] = 1; 
 $ItemMax[harmor, Chaingun] = 1; 
 $ItemMax[harmor, Disclauncher] = 1; 
 $ItemMax[harmor, GrenadeLauncher] = 1; 
 $ItemMax[harmor, Mortar] = 1; 
 $ItemMax[harmor, PlasmaGun] = 1; 
 $ItemMax[harmor, LaserRifle] = 0; 
 $ItemMax[harmor, EnergyRifle] = 1; 
 $ItemMax[harmor, TargetingLaser] = 1; 
 $ItemMax[harmor, MineAmmo] = 3; 
 $ItemMax[harmor, Grenade] = 5; 
 $ItemMax[harmor, Beacon] = 3; 
 $ItemMax[harmor, Boost] = 5; 
 $ItemMax[harmor, Plastique] = 0; 
 $ItemMax[harmor, RocketLauncher] = 1; 
 $ItemMax[harmor, SniperRifle] = 0; 
 $ItemMax[harmor, WaveGun] = 0; 
 $ItemMax[harmor, Railgun] = 0; 
 $ItemMax[harmor, Vulcan] = 1; 
 $ItemMax[harmor, Vulcan2] = 0; 
 $ItemMax[harmor, Silencer] = 0; 
 $ItemMax[harmor, Flamer] = 1; 
 $ItemMax[harmor, IonGun] = 0; 
 $ItemMax[harmor, Omega] = 0; 
 $ItemMax[harmor, HyperB] = 1; 
 $ItemMax[harmor, Fixit] = 0; 
 $ItemMax[harmor, BulletAmmo] = 200; 
 $ItemMax[harmor, PlasmaAmmo] = 50; 
 $ItemMax[harmor, DiscAmmo] = 15; 
 $ItemMax[harmor, GrenadeAmmo] = 15; 
 $ItemMax[harmor, MortarAmmo] = 10; 
 $ItemMax[harmor, SniperAmmo] = 15; 
 $ItemMax[harmor, RailAmmo] = 10; 
 $ItemMax[harmor, SilencerAmmo] = 25; 
 $ItemMax[harmor, VulcanAmmo] = 250; 
 $ItemMax[harmor, FlamerAmmo] = 200; 
 $ItemMax[harmor, RocketAmmo] = 10;

 $ItemMax[harmor, EnergyPack] = 1; 
 $ItemMax[harmor, RepairPack] = 1; 
 $ItemMax[harmor, HeatSink] = 1;
 $ItemMax[harmor, ShieldPack] = 0; 
 $ItemMax[harmor, SensorJammerPack] = 1; 
 $ItemMax[harmor, MotionSensorPack] = 1; 
 $ItemMax[harmor, PulseSensorPack] = 1; 
 $ItemMax[harmor, DeployableSensorJammerPack] = 1; 
 $ItemMax[harmor, CameraPack] = 1; 
 $ItemMax[harmor, TurretPack] = 1; 
 $ItemMax[harmor, AmmoPack] = 1; 
 $ItemMax[harmor, RepairKit] = 1; 
 $ItemMax[harmor, DeployableInvPack] = 0; 
 $ItemMax[harmor, DeployableAmmoPack] = 1; 
 $ItemMax[harmor, DeployableComPack] = 1; 
 $ItemMax[harmor, LaserTurret] = 0; 
 $ItemMax[harmor, ForceFieldPack] = 1; 
 $ItemMax[harmor, RocketPack] = 0; 
 $ItemMax[harmor, LaserPack] = 0; 
 $ItemMax[harmor, CloakingDevice] = 0; 
 $ItemMax[harmor, StealthShieldPack] = 1; 
 $ItemMax[harmor, TargetPack] = 0; 
 $ItemMax[harmor, MechPack] = 0; 
 $ItemMax[harmor, Laptop] = 0; 
 $ItemMax[harmor, ShockPack] = 0; 
 $ItemMax[harmor, TeleportPack] = 0; 
 $ItemMax[harmor, TripwirePack] = 0; 
 $ItemMax[harmor, TreePack] = 0; 
 $ItemMax[harmor, SpringPack] = 0; 
 $ItemMax[harmor, SuicidePack] = 0; 
 $ItemMax[harmor, HPCPack] = 0; 
 $ItemMax[harmor, HoloPack] = 1; 
 $ItemMax[harmor, Vengeance] = 0; 
 $ItemMax[harmor, RailTurret] = 0; 
 $ItemMax[harmor, VulcanTurret] = 0; 
 $ItemMax[harmor, TLaserPack] = 1; 

$MaxWeapons[harmor] = 6;

//lfemale = Female Sniper 
 
$DamageScale[lfemale, $LandingDamageType] = 0.9; 
 $DamageScale[lfemale, $ImpactDamageType] = 1.0; 
 $DamageScale[lfemale, $CrushDamageType] = 1.0; 
 $DamageScale[lfemale, $BulletDamageType] = 0.5; 
 $DamageScale[lfemale, $PlasmaDamageType] = 0.8; 
 $DamageScale[lfemale, $EnergyDamageType] = 1.0; 
 $DamageScale[lfemale, $ExplosionDamageType] = 1.0; 
 $DamageScale[lfemale, $MissileDamageType] = 1.0; 
 $DamageScale[lfemale, $ShrapnelDamageType] = 1.0; 
 $DamageScale[lfemale, $DebrisDamageType] = 1.0; 
 $DamageScale[lfemale, $LaserDamageType] = 0.9; 
 $DamageScale[lfemale, $MortarDamageType] = 1.0; 
 $DamageScale[lfemale, $BlasterDamageType] = 1.0; 
 $DamageScale[lfemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[lfemale, $MineDamageType] = 1.2; 
 $DamageScale[lfemale, $SniperDamageType] = 0.85; 
 $DamageScale[lfemale, $FlashDamageType] = 1.0; 
 $DamageScale[lfemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[lfemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[lfemale, $HighWarheadDamageType] = 1.3;
 $DamageScale[lfemale, $EMPWarheadDamageType] = 1.0;

$ItemMax[lfemale, Blaster] = 1; 
 $ItemMax[lfemale, Chaingun] = 1; 
 $ItemMax[lfemale, Disclauncher] = 1; 
 $ItemMax[lfemale, GrenadeLauncher] = 1; 
 $ItemMax[lfemale, Mortar] = 0; 
 $ItemMax[lfemale, PlasmaGun] = 1; 
 $ItemMax[lfemale, LaserRifle] = 1; 
 $ItemMax[lfemale, EnergyRifle] = 1; 
 $ItemMax[lfemale, TargetingLaser] = 1; 
 $ItemMax[lfemale, MineAmmo] = 3; 
 $ItemMax[lfemale, Grenade] = 3; 
 $ItemMax[lfemale, Beacon] = 3; 
 $ItemMax[lfemale, Boost] = 3; 
 $ItemMax[lfemale, Plastique] = 0; 
 $ItemMax[lfemale, SniperRifle] = 1; 
 $ItemMax[lfemale, RocketLauncher] = 0; 
 $ItemMax[lfemale, WaveGun] = 0; 
 $ItemMax[lfemale, Railgun] = 1; 
 $ItemMax[lfemale, Gaussgun] = 0; 
 $ItemMax[lfemale, Vulcan] = 0; 
 $ItemMax[lfemale, Vulcan2] = 0;
 $ItemMax[lfemale, Silencer] = 0; 
 $ItemMax[lfemale, Flamer] = 0; 
 $ItemMax[lfemale, IonGun] = 0; 
 $ItemMax[lfemale, Omega] = 0; 
 $ItemMax[lfemale, HyperB] = 0; 
 $ItemMax[lfemale, Fixit] = 0; 

 $ItemMax[lfemale, BulletAmmo] = 100; 
 $ItemMax[lfemale, PlasmaAmmo] = 30; 
 $ItemMax[lfemale, DiscAmmo] = 15; 
 $ItemMax[lfemale, GrenadeAmmo] = 10; 
 $ItemMax[lfemale, SniperAmmo] = 15; 
 $ItemMax[lfemale, RailAmmo] = 10;
 
$ItemMax[lfemale, EnergyPack] = 1; 
 $ItemMax[lfemale, RepairPack] = 1; 
 $ItemMax[lfemale, ShieldPack] = 1; 
 $ItemMax[lfemale, HeatSink] = 1;
 $ItemMax[lfemale, SensorJammerPack] = 1; 
 $ItemMax[lfemale, MotionSensorPack] = 1; 
 $ItemMax[lfemale, PulseSensorPack] = 1; 
 $ItemMax[lfemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[lfemale, CameraPack] = 1; 
 $ItemMax[lfemale, TurretPack] = 0; 
 $ItemMax[lfemale, AmmoPack] = 1; 
 $ItemMax[lfemale, RepairKit] = 2; 
 $ItemMax[lfemale, DeployableInvPack] = 0; 
 $ItemMax[lfemale, DeployableAmmoPack] = 0; 
 $ItemMax[lfemale, DeployableComPack] = 0; 
 $ItemMax[lfemale, LaserTurret] = 0; 
 $ItemMax[lfemale, ForceFieldPack] = 1; 
 $ItemMax[lfemale, RocketPack] = 0; 
 $ItemMax[lfemale, LaserPack] = 0; 
 $ItemMax[lfemale, CloakingDevice] = 0; 
 $ItemMax[lfemale, StealthShieldPack] = 0; 
 $ItemMax[lfemale, TreePack] = 1; 
 $ItemMax[lfemale, TargetPack] = 0; 
 $ItemMax[lfemale, MechPack] = 0; 
 $ItemMax[lfemale, Laptop] = 0; 
 $ItemMax[lfemale, ShockPack] = 0; 
 $ItemMax[lfemale, TeleportPack] = 0; 
 $ItemMax[lfemale, TripwirePack] = 0; 
 $ItemMax[lfemale, SpringPack] = 0; 
 $ItemMax[lfemale, SuicidePack] = 0; 
 $ItemMax[lfemale, HPCPack] = 0; 
 $ItemMax[lfemale, HoloPack] = 1; 
 $ItemMax[lfemale, Vengeance] = 0; 
 $ItemMax[lfemale, RailTurret] = 0; 
 $ItemMax[lfemale, VulcanTurret] = 0; 
 $ItemMax[lfemale, TLaserPack] = 1;

$MaxWeapons[lfemale] = 3; 

//mfemale = Female Mercenary 
 
$DamageScale[mfemale, $LandingDamageType] = 1.0; 
 $DamageScale[mfemale, $ImpactDamageType] = 1.0; 
 $DamageScale[mfemale, $CrushDamageType] = 1.0; 
 $DamageScale[mfemale, $BulletDamageType] = 0.5; 
 $DamageScale[mfemale, $EnergyDamageType] = 1.0; 
 $DamageScale[mfemale, $PlasmaDamageType] = 0.8; 
 $DamageScale[mfemale, $ExplosionDamageType] = 1.0; 
 $DamageScale[mfemale, $MissileDamageType] = 1.0; 
 $DamageScale[mfemale, $ShrapnelDamageType] = 1.0; 
 $DamageScale[mfemale, $DebrisDamageType] = 1.0; 
 $DamageScale[mfemale, $LaserDamageType] = 1.0;
 $DamageScale[mfemale, $MortarDamageType] = 0.8; 
 $DamageScale[mfemale, $BlasterDamageType] = 1.0; 
 $DamageScale[mfemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[mfemale, $MineDamageType] = 1.0; 
 $DamageScale[mfemale, $SniperDamageType] = 1.2; 
 $DamageScale[mfemale, $FlashDamageType] = 1.0; 
 $DamageScale[mfemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[mfemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[mfemale, $HighWarheadDamageType] = 1.0;
 $DamageScale[mfemale, $EMPWarheadDamageType] = 1.0;

$ItemMax[mfemale, Blaster] = 1; 
 $ItemMax[mfemale, Chaingun] = 1; 
 $ItemMax[mfemale, Disclauncher] = 1; 
 $ItemMax[mfemale, GrenadeLauncher] = 1; 
 $ItemMax[mfemale, Mortar] = 0; 
 $ItemMax[mfemale, PlasmaGun] = 1; 
 $ItemMax[mfemale, LaserRifle] = 0; 
 $ItemMax[mfemale, EnergyRifle] = 1; 
 $ItemMax[mfemale, TargetingLaser] = 1; 
 $ItemMax[mfemale, MineAmmo] = 3; 
 $ItemMax[mfemale, Grenade] = 6; 
 $ItemMax[mfemale, Beacon] = 3; 
 $ItemMax[mfemale, Boost] = 3; 
 $ItemMax[mfemale, Plastique] = 0; 
 $ItemMax[mfemale, RocketLauncher] = 0; 
 $ItemMax[mfemale, SniperRifle] = 0; 
 $ItemMax[mfemale, WaveGun] = 0; 
 $ItemMax[mfemale, Railgun] = 0; 
 $ItemMax[mfemale, Gaussgun] = 0; 
 $ItemMax[mfemale, Vulcan] = 1; 
 $ItemMax[mfemale, Vulcan2] = 1;
 $ItemMax[mfemale, Silencer] = 0; 
 $ItemMax[mfemale, Flamer] = 0; 
 $ItemMax[mfemale, IonGun] = 1; 
 $ItemMax[mfemale, Omega] = 0; 
 $ItemMax[mfemale, HyperB] = 1; 
 $ItemMax[mfemale, Fixit] = 0; 
 $ItemMax[mfemale, BulletAmmo] = 150; 
 $ItemMax[mfemale, PlasmaAmmo] = 30; 
 $ItemMax[mfemale, DiscAmmo] = 15; 
 $ItemMax[mfemale, GrenadeAmmo] = 15; 
 $ItemMax[mfemale, VulcanAmmo] = 200; 
 $ItemMax[mfemale, FlamerAmmo] = 75; 
 
$ItemMax[mfemale, EnergyPack] = 1; 
 $ItemMax[mfemale, RepairPack] = 1; 
 $ItemMax[mfemale, ShieldPack] = 1; 
 $ItemMax[mfemale, SensorJammerPack] = 1; 
 $ItemMax[mfemale, MotionSensorPack] = 1; 
 $ItemMax[mfemale, PulseSensorPack] = 1; 
 $ItemMax[mfemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[mfemale, CameraPack] = 0; 
 $ItemMax[mfemale, TurretPack] = 1; 
 $ItemMax[mfemale, HeatSink] = 1;
 $ItemMax[mfemale, AmmoPack] = 1; 
 $ItemMax[mfemale, RepairKit] = 1; 
 $ItemMax[mfemale, DeployableInvPack] = 0; 
 $ItemMax[mfemale, DeployableAmmoPack] = 1; 
 $ItemMax[mfemale, DeployableComPack] = 0; 
 $ItemMax[mfemale, LaserTurret] = 0; 
 $ItemMax[mfemale, ForceFieldPack] = 1; 
 $ItemMax[mfemale, RocketPack] = 0; 
 $ItemMax[mfemale, LaserPack] = 0; 
 $ItemMax[mfemale, CloakingDevice] = 0; 
 $ItemMax[mfemale, StealthShieldPack] = 0; 
 $ItemMax[mfemale, TargetPack] = 0; 
 $ItemMax[mfemale, MechPack] = 0; 
 $ItemMax[mfemale, Laptop] = 0; 
 $ItemMax[mfemale, ShockPack] = 0; 
 $ItemMax[mfemale, TeleportPack] = 0; 
 $ItemMax[mfemale, TripwirePack] = 0; 
 $ItemMax[mfemale, TreePack] = 0; 
 $ItemMax[mfemale, SpringPack] = 0; 
 $ItemMax[mfemale, SuicidePack] = 0; 
 $ItemMax[mfemale, HPCPack] = 0; 
 $ItemMax[mfemale, HoloPack] = 1; 
 $ItemMax[mfemale, Vengeance] = 0; 
 $ItemMax[mfemale, RailTurret] = 0; 
 $ItemMax[mfemale, VulcanTurret] = 0; 
 $ItemMax[mfemale, TLaserPack] = 1; 

$MaxWeapons[mfemale] = 5; 

//sarmor = Male Scout 
 
$DamageScale[sarmor, $LandingDamageType] = 0.5; 
 $DamageScale[sarmor, $ImpactDamageType] = 0.5; 
 $DamageScale[sarmor, $CrushDamageType] = 0.5; 
 $DamageScale[sarmor, $BulletDamageType] = 0.8; 
 $DamageScale[sarmor, $PlasmaDamageType] = 0.8; 
 $DamageScale[sarmor, $EnergyDamageType] = 1.3; 
 $DamageScale[sarmor, $ExplosionDamageType] = 1.0; 
 $DamageScale[sarmor, $MissileDamageType] = 1.0; 
 $DamageScale[sarmor, $DebrisDamageType] = 1.2; 
 $DamageScale[sarmor, $ShrapnelDamageType] = 1.2; 
 $DamageScale[sarmor, $LaserDamageType] = 0.9; 
 $DamageScale[sarmor, $MortarDamageType] = 1.3; 
 $DamageScale[sarmor, $BlasterDamageType] = 1.3; 
 $DamageScale[sarmor, $ElectricityDamageType] = 1.0; 
 $DamageScale[sarmor, $MineDamageType] = 1.2; 
 $DamageScale[sarmor, $SniperDamageType] = 0.85;
 $DamageScale[sarmor, $FlashDamageType] = 1.0; 
 $DamageScale[sarmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[sarmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[sarmor, $HighWarheadDamageType] = 1.3;
 $DamageScale[sarmor, $EMPWarheadDamageType] = 1.0;

$ItemMax[sarmor, Blaster] = 1; 
 $ItemMax[sarmor, Chaingun] = 1; 
 $ItemMax[sarmor, Disclauncher] = 1; 
 $ItemMax[sarmor, GrenadeLauncher] = 1; 
 $ItemMax[sarmor, Mortar] = 0; 
 $ItemMax[sarmor, PlasmaGun] = 1; 
 $ItemMax[sarmor, LaserRifle] = 0; 
 $ItemMax[sarmor, EnergyRifle] = 1; 
 $ItemMax[sarmor, TargetingLaser] = 1; 
 $ItemMax[sarmor, MineAmmo] = 3; 
 $ItemMax[sarmor, Grenade] = 5; 
 $ItemMax[sarmor, Beacon] = 2; 
 $ItemMax[sarmor, Boost] = 5; 
 $ItemMax[sarmor, Plastique] = 0; 
 $ItemMax[sarmor, RocketLauncher] = 0; 
 $ItemMax[sarmor, SniperRifle] = 0; 
 $ItemMax[sarmor, WaveGun] = 0; 
 $ItemMax[sarmor, Railgun] = 0; 
 $ItemMax[sarmor, Gaussgun] = 0; 
 $ItemMax[sarmor, Vulcan] = 0; 
 $ItemMax[sarmor, Vulcan2] = 0; 
 $ItemMax[sarmor, Silencer] = 0; 
 $ItemMax[sarmor, Flamer] = 0; 
 $ItemMax[sarmor, IonGun] = 1; 
 $ItemMax[sarmor, Omega] = 0; 
 $ItemMax[sarmor, HyperB] = 1; 
 $ItemMax[sarmor, Fixit] = 0; 
 $ItemMax[sarmor, BulletAmmo] = 100;
 $ItemMax[sarmor, PlasmaAmmo] = 30;
 $ItemMax[sarmor, DiscAmmo] = 15;
 $ItemMax[sarmor, GrenadeAmmo] = 10;
 $ItemMax[sarmor, MortarAmmo] = 10;
 $ItemMax[sarmor, RocketAmmo] = 5;
 $ItemMax[sarmor, SniperAmmo] = 25;
 $ItemMax[sarmor, RailAmmo] = 10;
 $ItemMax[sarmor, SilencerAmmo] = 25;
 $ItemMax[sarmor, VulcanAmmo] = 200;
 $ItemMax[sarmor, FlamerAmmo] = 200;
 $ItemMax[sarmor, EnergyPack] = 1; 
 $ItemMax[sarmor, RepairPack] = 1; 
 $ItemMax[sarmor, ShieldPack] = 1; 
 $ItemMax[sarmor, SensorJammerPack] = 0; 
 $ItemMax[sarmor, MotionSensorPack] = 1; 
 $ItemMax[sarmor, PulseSensorPack] = 1; 
 $ItemMax[sarmor, DeployableSensorJammerPack] = 0; 
 $ItemMax[sarmor, CameraPack] = 1; 
 $ItemMax[sarmor, TurretPack] = 0; 
 $ItemMax[sarmor, AmmoPack] = 1; 
 $ItemMax[sarmor, RepairKit] = 2; 
 $ItemMax[sarmor, DeployableInvPack] = 0; 
 $ItemMax[sarmor, DeployableAmmoPack] = 0; 
 $ItemMax[sarmor, DeployableComPack] = 0; 
 $ItemMax[sarmor, LaserTurret] = 0; 
 $ItemMax[sarmor, ForceFieldPack] = 1; 
 $ItemMax[sarmor, RocketPack] = 0; 
 $ItemMax[sarmor, LaserPack] = 0; 
 $ItemMax[sarmor, CloakingDevice] = 0; 
 $ItemMax[sarmor, StealthShieldPack] = 0; 
 $ItemMax[sarmor, TargetPack] = 0; 
 $ItemMax[sarmor, MechPack] = 1; 
 $ItemMax[sarmor, Laptop] = 0; 
 $ItemMax[sarmor, HeatSink] = 1;
 $ItemMax[sarmor, ShockPack] = 0; 
 $ItemMax[sarmor, TeleportPack] = 0; 
 $ItemMax[sarmor, TripwirePack] = 0; 
 $ItemMax[sarmor, TreePack] = 0; 
 $ItemMax[sarmor, SpringPack] = 0; 
 $ItemMax[sarmor, SuicidePack] = 0; 
 $ItemMax[sarmor, ScoutPack] = 1; 
 $ItemMax[sarmor, HPCPack] = 1; 
 $ItemMax[sarmor, HoloPack] = 1; 
 $ItemMax[sarmor, Vengeance] = 0; 
 $ItemMax[sarmor, RailTurret] = 0; 
 $ItemMax[sarmor, VulcanTurret] = 0; 
 $ItemMax[sarmor, TLaserPack] = 1;
$MaxWeapons[sarmor] = 2; 

//barmor = Male Burster 
 
$DamageScale[barmor, $LandingDamageType] = 1.0; 
 $DamageScale[barmor, $ImpactDamageType] = 1.0; 
 $DamageScale[barmor, $CrushDamageType] = 1.0; 
 $DamageScale[barmor, $BulletDamageType] = 0.5; 
 $DamageScale[barmor, $PlasmaDamageType] = 0.3; 
 $DamageScale[barmor, $EnergyDamageType] = 1.1; 
 $DamageScale[barmor, $ExplosionDamageType] = 0.5; 
 $DamageScale[barmor, $MissileDamageType] = 0.5; 
 $DamageScale[barmor, $ShrapnelDamageType] = 0.5; 
 $DamageScale[barmor, $DebrisDamageType] = 1.0; 
 $DamageScale[barmor, $LaserDamageType] = 1.1; 
 $DamageScale[barmor, $MortarDamageType] = 0.5; 
 $DamageScale[barmor, $BlasterDamageType] = 1.2; 
 $DamageScale[barmor, $ElectricityDamageType] = 1.0; 
 $DamageScale[barmor, $MineDamageType] = 0.5; 
 $DamageScale[barmor, $SniperDamageType] = 1.5; 
 $DamageScale[barmor, $FlashDamageType] = 1.0; 
 $DamageScale[barmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[barmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[barmor, $HighWarheadDamageType] = 1.0;
 $DamageScale[barmor, $EMPWarheadDamageType] = 1.0;

$ItemMax[barmor, Blaster] = 0; 
 $ItemMax[barmor, Chaingun] = 0; 
 $ItemMax[barmor, Disclauncher] = 1; 
 $ItemMax[barmor, GrenadeLauncher] = 1; 
 $ItemMax[barmor, Mortar] = 1; 
 $ItemMax[barmor, PlasmaGun] = 1; 
 $ItemMax[barmor, LaserRifle] = 0; 
 $ItemMax[barmor, EnergyRifle] = 0; 
 $ItemMax[barmor, TargetingLaser] = 1; 
 $ItemMax[barmor, MineAmmo] = 6; 
 $ItemMax[barmor, Grenade] = 6; 
 $ItemMax[barmor, Beacon] = 2; 
 $ItemMax[barmor, Boost] = 4; 
 $ItemMax[barmor, Plastique] = 0; 
 $ItemMax[barmor, RocketLauncher] = 1; 
 $ItemMax[barmor, SniperRifle] = 0; 
 $ItemMax[barmor, WaveGun] = 0; 
 $ItemMax[barmor, Railgun] = 0; 
 $ItemMax[barmor, Vulcan] = 0; 
 $ItemMax[barmor, Vulcan2] = 0; 
 $ItemMax[barmor, Silencer] = 0; 
 $ItemMax[barmor, Flamer] = 1; 
 $ItemMax[barmor, IonGun] = 0; 
 $ItemMax[barmor, Omega] = 0; 
 $ItemMax[barmor, HyperB] = 0; 
 $ItemMax[barmor, Fixit] = 0; 
 $ItemMax[barmor, PlasmaAmmo] = 50; 
 $ItemMax[barmor, DiscAmmo] = 30; 
 $ItemMax[barmor, GrenadeAmmo] = 20; 
 $ItemMax[barmor, MortarAmmo] = 5; 
 $ItemMax[barmor, RocketAmmo] = 10; 
 $ItemMax[barmor, FlamerAmmo] = 100;  

$ItemMax[barmor, EnergyPack] = 1; 
 $ItemMax[barmor, RepairPack] = 1; 
 $ItemMax[barmor, ShieldPack] = 1; 
 $ItemMax[barmor, SensorJammerPack] = 1; 
 $ItemMax[barmor, MotionSensorPack] = 1; 
 $ItemMax[barmor, PulseSensorPack] = 1; 
 $ItemMax[barmor, DeployableSensorJammerPack] = 1; 
 $ItemMax[barmor, CameraPack] = 1; 
 $ItemMax[barmor, TurretPack] = 0; 
 $ItemMax[barmor, AmmoPack] = 1; 
 $ItemMax[barmor, RepairKit] = 1; 
 $ItemMax[barmor, DeployableInvPack] = 0; 
 $ItemMax[barmor, DeployableAmmoPack] = 1; 
 $ItemMax[barmor, DeployableComPack] = 0; 
 $ItemMax[barmor, LaserTurret] = 0; 
 $ItemMax[barmor, ForceFieldPack] = 1; 
 $ItemMax[barmor, RocketPack] = 1; 
 $ItemMax[barmor, LaserPack] = 0; 
 $ItemMax[barmor, HeatSink] = 1;
 $ItemMax[barmor, CloakingDevice] = 0; 
 $ItemMax[barmor, StealthShieldPack] = 0; 
 $ItemMax[barmor, TargetPack] = 0; 
 $ItemMax[barmor, MechPack] = 0; 
 $ItemMax[barmor, Laptop] = 0; 
 $ItemMax[barmor, ShockPack] = 0; 
 $ItemMax[barmor, TeleportPack] = 0; 
 $ItemMax[barmor, TripwirePack] = 0; 
 $ItemMax[barmor, TreePack] = 0; 
 $ItemMax[barmor, SpringPack] = 0; 
 $ItemMax[barmor, SuicidePack] = 1; 
 $ItemMax[barmor, HPCPack] = 0; 
 $ItemMax[barmor, HoloPack] = 1; 
 $ItemMax[barmor, Vengeance] = 0; 
 $ItemMax[barmor, RailTurret] = 0; 
 $ItemMax[barmor, VulcanTurret] = 0; 
 $ItemMax[barmor, TLaserPack] = 1;


$MaxWeapons[barmor] = 4; 
 
//darmor = Dragoon

 $DamageScale[darmor, $LandingDamageType] = 0.8;
 $DamageScale[darmor, $ImpactDamageType] = 0.8;
 $DamageScale[darmor, $CrushDamageType] = 0.8;
 $DamageScale[darmor, $BulletDamageType] = 0.3;
 $DamageScale[darmor, $PlasmaDamageType] = 0.6;
 $DamageScale[darmor, $EnergyDamageType] = 0.7;
 $DamageScale[darmor, $ExplosionDamageType] = 0.5;
 $DamageScale[darmor, $MissileDamageType] = 0.6;
 $DamageScale[darmor, $DebrisDamageType] = 0.8;
 $DamageScale[darmor, $ShrapnelDamageType] = 0.8; 
 $DamageScale[darmor, $LaserDamageType] = 0.6;
 $DamageScale[darmor, $MortarDamageType] = 0.7;
 $DamageScale[darmor, $BlasterDamageType] = 0.7;
 $DamageScale[darmor, $ElectricityDamageType] = 0.8;
 $DamageScale[darmor, $MineDamageType] = 0.8;
 $DamageScale[darmor, $SniperDamageType] = 0.7;
 $DamageScale[darmor, $FlashDamageType] = 1.0;
 $DamageScale[darmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[darmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[darmor, $HighWarheadDamageType] = 0.7;
 $DamageScale[darmor, $EMPWarheadDamageType] = 1.0; 

$ItemMax[darmor, Blaster] = 1; 
 $ItemMax[darmor, Chaingun] = 1; 
 $ItemMax[darmor, Disclauncher] = 1; 
 $ItemMax[darmor, GrenadeLauncher] = 1; 
 $ItemMax[darmor, Mortar] = 1; 
 $ItemMax[darmor, PlasmaGun] = 1; 
 $ItemMax[darmor, LaserRifle] = 0; 
 $ItemMax[darmor, EnergyRifle] = 1; 
 $ItemMax[darmor, TargetingLaser] = 1; 
 $ItemMax[darmor, MineAmmo] = 2; 
 $ItemMax[darmor, Grenade] = 3; 
 $ItemMax[darmor, Beacon] = 3; 
 $ItemMax[darmor, Boost] = 5; 
 $ItemMax[darmor, Plastique] = 0; 
 $ItemMax[darmor, RocketLauncher] = 1; 
 $ItemMax[darmor, SniperRifle] = 0; 
 $ItemMax[darmor, WaveGun] = 0; 
 $ItemMax[darmor, Railgun] = 0; 
 $ItemMax[darmor, Vulcan] = 0; 
 $ItemMax[darmor, Vulcan2] = 0; 
 $ItemMax[darmor, Silencer] = 0; 
 $ItemMax[darmor, Flamer] = 0; 
 $ItemMax[darmor, IonGun] = 0; 
 $ItemMax[darmor, Omega] = 0; 
 $ItemMax[darmor, HyperB] = 1; 
 $ItemMax[darmor, Fixit] = 0; 
 $ItemMax[darmor, BulletAmmo] = 350; 
 $ItemMax[darmor, PlasmaAmmo] = 75; 
 $ItemMax[darmor, DiscAmmo] = 20; 
 $ItemMax[darmor, GrenadeAmmo] = 20; 
 $ItemMax[darmor, MortarAmmo] = 15; 
 $ItemMax[darmor, RocketAmmo] = 15; 
 $ItemMax[darmor, SniperAmmo] = 15; 
 $ItemMax[darmor, RailAmmo] = 10; 
 $ItemMax[darmor, SilencerAmmo] = 25; 
 $ItemMax[darmor, VulcanAmmo] = 0; 
//$ItemMax[darmor, VengeanceAmmo] = 30;
 
$ItemMax[darmor, EnergyPack] = 1; 
 $ItemMax[darmor, RepairPack] = 1; 
 $ItemMax[darmor, ShieldPack] = 1; 
 $ItemMax[darmor, SensorJammerPack] = 1; 
 $ItemMax[darmor, MotionSensorPack] = 1; 
 $ItemMax[darmor, PulseSensorPack] = 1; 
 $ItemMax[darmor, DeployableSensorJammerPack] = 1; 
 $ItemMax[darmor, CameraPack] = 0; 
 $ItemMax[darmor, TurretPack] = 1; 
 $ItemMax[darmor, AmmoPack] = 1; 
 $ItemMax[darmor, RepairKit] = 1; 
 $ItemMax[darmor, DeployableInvPack] = 0; 
 $ItemMax[darmor, DeployableAmmoPack] = 1; 
 $ItemMax[darmor, DeployableComPack] = 1; 
 $ItemMax[darmor, HeatSink] = 1;
 $ItemMax[darmor, LaserTurret] = 1; 
 $ItemMax[darmor, ForceFieldPack] = 0; 
 $ItemMax[darmor, RocketPack] = 0; 
 $ItemMax[darmor, LaserPack] = 0; 
 $ItemMax[darmor, CloakingDevice] = 0; 
 $ItemMax[darmor, StealthShieldPack] = 0; 
 $ItemMax[darmor, TargetPack] = 1; 
 $ItemMax[darmor, MechPack] = 0; 
 $ItemMax[darmor, Laptop] = 0; 
 $ItemMax[darmor, ShockPack] = 0; 
 $ItemMax[darmor, TeleportPack] = 0; 
 $ItemMax[darmor, TripwirePack] = 0; 
 $ItemMax[darmor, TreePack] = 0; 
 $ItemMax[darmor, SpringPack] = 1; 
 $ItemMax[darmor, SuicidePack] = 0; 
 $ItemMax[darmor, HPCPack] = 0; 
 $ItemMax[darmor, HoloPack] = 0; 
 $ItemMax[darmor, Vengeance] = 1; 
 $ItemMax[darmor, RailTurret] = 1; 
 $ItemMax[darmor, VulcanTurret] = 1;  
 $ItemMax[darmor, TLaserPack] = 1; 

$MaxWeapons[darmor] = 6;

//sfemale = Female Scout 
 
$DamageScale[sfemale, $LandingDamageType] = 0.5; 
 $DamageScale[sfemale, $ImpactDamageType] = 0.5; 
 $DamageScale[sfemale, $CrushDamageType] = 0.5; 
 $DamageScale[sfemale, $BulletDamageType] = 0.8; 
 $DamageScale[sfemale, $PlasmaDamageType] = 0.8; 
 $DamageScale[sfemale, $EnergyDamageType] = 1.3; 
 $DamageScale[sfemale, $ExplosionDamageType] = 1.0; 
 $DamageScale[sfemale, $MissileDamageType] = 1.0; 
 $DamageScale[sfemale, $ShrapnelDamageType] = 1.2; 
 $DamageScale[sfemale, $DebrisDamageType] = 1.2; 
 $DamageScale[sfemale, $LaserDamageType] = 0.9; 
 $DamageScale[sfemale, $MortarDamageType] = 1.3; 
 $DamageScale[sfemale, $BlasterDamageType] = 1.3; 
 $DamageScale[sfemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[sfemale, $MineDamageType] = 1.2; 
 $DamageScale[sfemale, $SniperDamageType] = 0.85; 
 $DamageScale[sfemale, $FlashDamageType] = 1.0; 
 $DamageScale[sfemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[sfemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[sfemale, $HighWarheadDamageType] = 1.3;
 $DamageScale[sfemale, $EMPWarheadDamageType] = 1.0;  

$ItemMax[sfemale, Blaster] = 1; 
 $ItemMax[sfemale, Chaingun] = 1; 
 $ItemMax[sfemale, Disclauncher] = 1; 
 $ItemMax[sfemale, GrenadeLauncher] = 1; 
 $ItemMax[sfemale, Mortar] = 0; 
 $ItemMax[sfemale, PlasmaGun] = 1; 
 $ItemMax[sfemale, LaserRifle] = 0; 
 $ItemMax[sfemale, EnergyRifle] = 1; 
 $ItemMax[sfemale, TargetingLaser] = 1; 
 $ItemMax[sfemale, MineAmmo] = 3; 
 $ItemMax[sfemale, Grenade] = 5; 
 $ItemMax[sfemale, Beacon] = 2; 
 $ItemMax[sfemale, Boost] = 3; 
 $ItemMax[sfemale, Plastique] = 0; 
 $ItemMax[sfemale, SniperRifle] = 0; 
 $ItemMax[sfemale, RocketLauncher] = 0; 
 $ItemMax[sfemale, WaveGun] = 0; 
 $ItemMax[sfemale, Railgun] = 0; 
 $ItemMax[sfemale, Gaussgun] = 0; 
 $ItemMax[sfemale, Vulcan] = 0; 
 $ItemMax[sfemale, Vulcan2] = 0; 
 $ItemMax[sfemale, Silencer] = 0; 
 $ItemMax[sfemale, Flamer] = 0; 
 $ItemMax[sfemale, IonGun] = 1; 
 $ItemMax[sfemale, Omega] = 0; 
 $ItemMax[sfemale, HyperB] = 1; 
 $ItemMax[sfemale, Fixit] = 0; 
 $ItemMax[sfemale, BulletAmmo] = 100;
 $ItemMax[sfemale, PlasmaAmmo] = 30;
 $ItemMax[sfemale, DiscAmmo] = 15;
 $ItemMax[sfemale, GrenadeAmmo] = 10;
 $ItemMax[sfemale, MortarAmmo] = 10;
 $ItemMax[sfemale, SniperAmmo] = 25;
 $ItemMax[sfemale, RocketAmmo] = 5;
 $ItemMax[sfemale, RailAmmo] = 10;
 $ItemMax[sfemale, SilencerAmmo] = 25;
 $ItemMax[sfemale, VulcanAmmo] = 200;
 $ItemMax[sfemale, FlamerAmmo] = 20;
 
$ItemMax[sfemale, EnergyPack] = 1; 
 $ItemMax[sfemale, RepairPack] = 1; 
 $ItemMax[sfemale, ShieldPack] = 1; 
 $ItemMax[sfemale, SensorJammerPack] = 1; 
 $ItemMax[sfemale, MotionSensorPack] = 1; 
 $ItemMax[sfemale, PulseSensorPack] = 1; 
 $ItemMax[sfemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[sfemale, CameraPack] = 1; 
 $ItemMax[sfemale, TurretPack] = 0; 
 $ItemMax[sfemale, AmmoPack] = 1; 
 $ItemMax[sfemale, RepairKit] = 2; 
 $ItemMax[sfemale, DeployableInvPack] = 0; 
 $ItemMax[sfemale, DeployableAmmoPack] = 0; 
 $ItemMax[sfemale, DeployableComPack] = 0; 
 $ItemMax[sfemale, LaserTurret] = 0; 
 $ItemMax[sfemale, ForceFieldPack] = 1; 
 $ItemMax[sfemale, HeatSink] = 1; 
 $ItemMax[sfemale, RocketPack] = 0; 
 $ItemMax[sfemale, LaserPack] = 0; 
 $ItemMax[sfemale, CloakingDevice] = 0; 
 $ItemMax[sfemale, StealthShieldPack] = 0; 
 $ItemMax[sfemale, TargetPack] = 0; 
 $ItemMax[sfemale, MechPack] = 1; 
 $ItemMax[sfemale, Laptop] = 0; 
 $ItemMax[sfemale, ShockPack] = 0; 
 $ItemMax[sfemale, TeleportPack] = 0; 
 $ItemMax[sfemale, TripwirePack] = 0; 
 $ItemMax[sfemale, TreePack] = 0; 
 $ItemMax[sfemale, SpringPack] = 0; 
 $ItemMax[sfemale, SuicidePack] = 0; 
 $ItemMax[sfemale, ScoutPack] = 1; 
 $ItemMax[sfemale, HPCPack] = 1; 
 $ItemMax[sfemale, HoloPack] = 1; 
 $ItemMax[sfemale, Vengeance] = 0; 
 $ItemMax[sfemale, RailTurret] = 0; 
 $ItemMax[sfemale, VulcanTurret] = 0; 
 $ItemMax[sfemale, TLaserPack] = 1; 

$MaxWeapons[sfemale] = 2; 

//bfemale = Female Burster
 
$DamageScale[bfemale, $LandingDamageType] = 1.0; 
 $DamageScale[bfemale, $ImpactDamageType] = 1.0; 
 $DamageScale[bfemale, $CrushDamageType] = 1.0; 
 $DamageScale[bfemale, $BulletDamageType] = 0.5; 
 $DamageScale[bfemale, $PlasmaDamageType] = 0.3; 
 $DamageScale[bfemale, $EnergyDamageType] = 1.1; 
 $DamageScale[bfemale, $ExplosionDamageType] = 0.5; 
 $DamageScale[bfemale, $MissileDamageType] = 0.5; 
 $DamageScale[bfemale, $ShrapnelDamageType] = 0.5; 
 $DamageScale[bfemale, $DebrisDamageType] = 1.0; 
 $DamageScale[bfemale, $LaserDamageType] = 1.2; 
 $DamageScale[bfemale, $MortarDamageType] = 0.5; 
 $DamageScale[bfemale, $BlasterDamageType] = 1.2; 
 $DamageScale[bfemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[bfemale, $MineDamageType] = 0.5; 
 $DamageScale[bfemale, $SniperDamageType] = 1.5; 
 $DamageScale[bfemale, $FlashDamageType] = 1.0; 
 $DamageScale[bfemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[bfemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[bfemale, $HighWarheadDamageType] = 1.0;
 $DamageScale[bfemale, $EMPWarheadDamageType] = 1.0;
 
 $ItemMax[bfemale, Blaster] = 0; 
 $ItemMax[bfemale, Chaingun] = 0; 
 $ItemMax[bfemale, Disclauncher] = 1; 
 $ItemMax[bfemale, GrenadeLauncher] = 1; 
 $ItemMax[bfemale, Mortar] = 1; 
 $ItemMax[bfemale, PlasmaGun] = 1; 
 $ItemMax[bfemale, LaserRifle] = 0; 
 $ItemMax[bfemale, EnergyRifle] = 0; 
 $ItemMax[bfemale, TargetingLaser] = 1; 
 $ItemMax[bfemale, MineAmmo] = 6; 
 $ItemMax[bfemale, Grenade] = 6; 
 $ItemMax[bfemale, Beacon] = 2; 
 $ItemMax[bfemale, Boost] = 4; 
 $ItemMax[bfemale, Plastique] = 0; 
 $ItemMax[bfemale, RocketLauncher] = 1; 
 $ItemMax[bfemale, SniperRifle] = 0; 
 $ItemMax[bfemale, WaveGun] = 0; 
 $ItemMax[bfemale, Railgun] = 0; 
 $ItemMax[bfemale, Vulcan] = 0; 
 $ItemMax[bfemale, Vulcan2] = 0; 
 $ItemMax[bfemale, Silencer] = 0; 
 $ItemMax[bfemale, Flamer] = 1; 
 $ItemMax[bfemale, IonGun] = 0; 
 $ItemMax[bfemale, Omega] = 0; 
 $ItemMax[bfemale, HyperB] = 0; 
 $ItemMax[bfemale, Fixit] = 0; 
 $ItemMax[bfemale, PlasmaAmmo] = 50; 
 $ItemMax[bfemale, DiscAmmo] = 30; 
 $ItemMax[bfemale, GrenadeAmmo] = 20; 
 $ItemMax[bfemale, MortarAmmo] = 5; 
 $ItemMax[bfemale, RocketAmmo] = 10; 
 $ItemMax[bfemale, FlamerAmmo] = 100;
 
 
 
 
$ItemMax[bfemale, EnergyPack] = 1; 
 $ItemMax[bfemale, RepairPack] = 1; 
 $ItemMax[bfemale, ShieldPack] = 1; 
 $ItemMax[bfemale, SensorJammerPack] = 1; 
 $ItemMax[bfemale, MotionSensorPack] = 1; 
 $ItemMax[bfemale, PulseSensorPack] = 1; 
 $ItemMax[bfemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[bfemale, CameraPack] = 1; 
 $ItemMax[bfemale, TurretPack] = 0; 
 $ItemMax[bfemale, AmmoPack] = 1; 
 $ItemMax[bfemale, RepairKit] = 1; 
 $ItemMax[bfemale, DeployableInvPack] = 0; 
 $ItemMax[bfemale, DeployableAmmoPack] = 1; 
 $ItemMax[bfemale, DeployableComPack] = 0; 
 $ItemMax[bfemale, LaserTurret] = 0; 
 $ItemMax[bfemale, ForceFieldPack] = 1; 
 $ItemMax[bfemale, RocketPack] = 1; 
 $ItemMax[bfemale, HeatSink] = 1; 
 $ItemMax[bfemale, LaserPack] = 0; 
 $ItemMax[bfemale, CloakingDevice] = 0; 
 $ItemMax[bfemale, StealthShieldPack] = 0; 
 $ItemMax[bfemale, TargetPack] = 0; 
 $ItemMax[bfemale, MechPack] = 0; 
 $ItemMax[bfemale, Laptop] = 0; 
 $ItemMax[bfemale, ShockPack] = 0; 
 $ItemMax[bfemale, TeleportPack] = 0; 
 $ItemMax[bfemale, TripwirePack] = 0; 
 $ItemMax[bfemale, TreePack] = 0; 
 $ItemMax[bfemale, SpringPack] = 0; 
 $ItemMax[bfemale, SuicidePack] = 1; 
 $ItemMax[bfemale, HPCPack] = 0; 
 $ItemMax[bfemale, HoloPack] = 1; 
 $ItemMax[bfemale, Vengeance] = 0; 
 $ItemMax[bfemale, RailTurret] = 0; 
 $ItemMax[bfemale, VulcanTurret] = 0; 
 $ItemMax[bfemale, TLaserPack] = 1;
 
$MaxWeapons[bfemale] = 4; 
 
//spyarmor = Male Spy

$DamageScale[spyarmor, $LandingDamageType] = 1.0; 
 $DamageScale[spyarmor, $ImpactDamageType] = 1.0; 
 $DamageScale[spyarmor, $CrushDamageType] = 1.0; 
 $DamageScale[spyarmor, $BulletDamageType] = 0.5; 
 $DamageScale[spyarmor, $PlasmaDamageType] = 1.0; 
 $DamageScale[spyarmor, $EnergyDamageType] = 1.3; 
 $DamageScale[spyarmor, $ExplosionDamageType] = 1.2; 
 $DamageScale[spyarmor, $MissileDamageType] = 1.3; 
 $DamageScale[spyarmor, $DebrisDamageType] = 1.3; 
 $DamageScale[spyarmor, $ShrapnelDamageType] = 1.3; 
 $DamageScale[spyarmor, $LaserDamageType] = 0.8; 
 $DamageScale[spyarmor, $MortarDamageType] = 1.3; 
 $DamageScale[spyarmor, $BlasterDamageType] = 1.3; 
 $DamageScale[spyarmor, $ElectricityDamageType] = 1.0; 
 $DamageScale[spyarmor, $MineDamageType] = 1.2; 
 $DamageScale[spyarmor, $SniperDamageType] = 1.0; 
 $DamageScale[spyarmor, $FlashDamageType] = 1.0; 
 $DamageScale[spyarmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[spyarmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[spyarmor, $HighWarheadDamageType] = 1.3;
 $DamageScale[spyarmor, $EMPWarheadDamageType] = 1.0; 

$ItemMax[spyarmor, Blaster] = 1; 
 $ItemMax[spyarmor, Chaingun] = 1; 
 $ItemMax[spyarmor, Disclauncher] = 1; 
 $ItemMax[spyarmor, GrenadeLauncher] = 1; 
 $ItemMax[spyarmor, Mortar] = 0; 
 $ItemMax[spyarmor, PlasmaGun] = 1; 
 $ItemMax[spyarmor, LaserRifle] = 0; 
 $ItemMax[spyarmor, EnergyRifle] = 1; 
 $ItemMax[spyarmor, TargetingLaser] = 1; 
 $ItemMax[spyarmor, MineAmmo] = 1; 
 $ItemMax[spyarmor, Grenade] = 3; 
 $ItemMax[spyarmor, Beacon] = 3; 
 $ItemMax[spyarmor, Boost] = 3; 
 $ItemMax[spyarmor, Plastique] = 0; 
 $ItemMax[spyarmor, RocketLauncher] = 0; 
 $ItemMax[spyarmor, SniperRifle] = 0; 
 $ItemMax[spyarmor, WaveGun] = 0; 
 $ItemMax[spyarmor, Railgun] = 0; 
 $ItemMax[spyarmor, Gaussgun] = 0; 
 $ItemMax[spyarmor, Vulcan] = 0; 
 $ItemMax[spyarmor, Vulcan2] = 0; 
 $ItemMax[spyarmor, Silencer] = 1; 
 $ItemMax[spyarmor, Flamer] = 0; 
 $ItemMax[spyarmor, IonGun] = 0; 
 $ItemMax[spyarmor, Omega] = 0; 
 $ItemMax[spyarmor, HyperB] = 0; 
 $ItemMax[spyarmor, Fixit] = 0; 
 $ItemMax[spyarmor, BulletAmmo] = 100; 
 $ItemMax[spyarmor, PlasmaAmmo] = 30; 
 $ItemMax[spyarmor, DiscAmmo] = 15; 
 $ItemMax[spyarmor, GrenadeAmmo] = 10; 
 $ItemMax[spyarmor, MortarAmmo] = 10; 
 $ItemMax[spyarmor, RocketAmmo] = 5; 
 $ItemMax[spyarmor, SniperAmmo] = 15; 
 $ItemMax[spyarmor, RailAmmo] = 10; 
 $ItemMax[spyarmor, SilencerAmmo] = 15; 
 $ItemMax[spyarmor, VulcanAmmo] = 200; 
 
$ItemMax[spyarmor, EnergyPack] = 1; 
 $ItemMax[spyarmor, RepairPack] = 1; 
 $ItemMax[spyarmor, ShieldPack] = 1; 
 $ItemMax[spyarmor, SensorJammerPack] = 1; 
 $ItemMax[spyarmor, MotionSensorPack] = 1; 
 $ItemMax[spyarmor, PulseSensorPack] = 1; 
 $ItemMax[spyarmor, DeployableSensorJammerPack] = 1; 
 $ItemMax[spyarmor, CameraPack] = 1; 
 $ItemMax[spyarmor, TurretPack] = 0; 
 $ItemMax[spyarmor, AmmoPack] = 1; 
 $ItemMax[spyarmor, RepairKit] = 1; 
 $ItemMax[spyarmor, DeployableInvPack] = 0; 
 $ItemMax[spyarmor, DeployableAmmoPack] = 0; 
 $ItemMax[spyarmor, DeployableComPack] = 0; 
 $ItemMax[spyarmor, LaserTurret] = 0; 
 $ItemMax[spyarmor, HeatSink] = 1; 
 $ItemMax[spyarmor, ForceFieldPack] = 1; 
 $ItemMax[spyarmor, RocketPack] = 0; 
 $ItemMax[spyarmor, LaserPack] = 1; 
 $ItemMax[spyarmor, CloakingDevice] = 1; 
 $ItemMax[spyarmor, StealthShieldPack] = 0; 
 $ItemMax[spyarmor, Laptop] = 1; 
 $ItemMax[spyarmor, TargetPack] = 0; 
 $ItemMax[spyarmor, MechPack] = 0; 
 $ItemMax[spyarmor, ShockPack] = 0; 
 $ItemMax[spyarmor, TeleportPack] = 0; 
 $ItemMax[spyarmor, TripwirePack] = 0; 
 $ItemMax[spyarmor, TreePack] = 0; 
 $ItemMax[spyarmor, SpringPack] = 0; 
 $ItemMax[spyarmor, SuicidePack] = 0; 
 $ItemMax[spyarmor, HPCPack] = 0; 
 $ItemMax[spyarmor, HoloPack] = 1; 
 $ItemMax[spyarmor, Vengeance] = 0; 
 $ItemMax[spyarmor, RailTurret] = 0; 
 $ItemMax[spyarmor, VulcanTurret] = 0; 
 $ItemMax[spyarmor, TLaserPack] = 1;
 
$MaxWeapons[spyarmor] = 3; 

//spyfemale = Female Spy

 $DamageScale[spyfemale, $LandingDamageType] = 1.0; 
 $DamageScale[spyfemale, $ImpactDamageType] = 1.0; 
 $DamageScale[spyfemale, $CrushDamageType] = 1.0; 
 $DamageScale[spyfemale, $BulletDamageType] = 0.5; 
 $DamageScale[spyfemale, $PlasmaDamageType] = 1.0; 
 $DamageScale[spyfemale, $EnergyDamageType] = 1.3; 
 $DamageScale[spyfemale, $ExplosionDamageType] = 1.2; 
 $DamageScale[spyfemale, $MissileDamageType] = 1.3; 
 $DamageScale[spyfemale, $DebrisDamageType] = 1.3; 
 $DamageScale[spyfemale, $ShrapnelDamageType] = 1.3; 
 $DamageScale[spyfemale, $LaserDamageType] = 0.8;
 $DamageScale[spyfemale, $MortarDamageType] = 1.3; 
 $DamageScale[spyfemale, $BlasterDamageType] = 1.3; 
 $DamageScale[spyfemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[spyfemale, $MineDamageType] = 1.2; 
 $DamageScale[spyfemale, $SniperDamageType] = 1.0; 
 $DamageScale[spyfemale, $FlashDamageType] = 1.0; 
 $DamageScale[spyfemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[spyfemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[spyfemale, $HighWarheadDamageType] = 1.3;
 $DamageScale[spyfemale, $EMPWarheadDamageType] = 1.0; 

$ItemMax[spyfemale, Blaster] = 1; 
 $ItemMax[spyfemale, Chaingun] = 1; 
 $ItemMax[spyfemale, Disclauncher] = 1; 
 $ItemMax[spyfemale, GrenadeLauncher] = 1; 
 $ItemMax[spyfemale, Mortar] = 0; 
 $ItemMax[spyfemale, PlasmaGun] = 1; 
 $ItemMax[spyfemale, LaserRifle] = 0; 
 $ItemMax[spyfemale, EnergyRifle] = 1; 
 $ItemMax[spyfemale, TargetingLaser] = 1; 
 $ItemMax[spyfemale, MineAmmo] = 1; 
 $ItemMax[spyfemale, Grenade] = 3; 
 $ItemMax[spyfemale, Beacon] = 3; 
 $ItemMax[spyfemale, Boost] = 3; 
 $ItemMax[spyfemale, Plastique] = 0; 
 $ItemMax[spyfemale, RocketLauncher] = 0; 
 $ItemMax[spyfemale, SniperRifle] = 0; 
 $ItemMax[spyfemale, WaveGun] = 0; 
 $ItemMax[spyfemale, Railgun] = 0; 
 $ItemMax[spyfemale, Gaussgun] = 0; 
 $ItemMax[spyfemale, Vulcan] = 0; 
 $ItemMax[spyfemale, Vulcan2] = 0; 
 $ItemMax[spyfemale, Silencer] = 1; 
 $ItemMax[spyfemale, Flamer] = 0; 
 $ItemMax[spyfemale, IonGun] = 0; 
 $ItemMax[spyfemale, Omega] = 0; 
 $ItemMax[spyfemale, HyperB] = 0; 
 $ItemMax[spyfemale, Fixit] = 0; 
 $ItemMax[spyfemale, BulletAmmo] = 100; 
 $ItemMax[spyfemale, PlasmaAmmo] = 30; 
 $ItemMax[spyfemale, DiscAmmo] = 15; 
 $ItemMax[spyfemale, GrenadeAmmo] = 10; 
 $ItemMax[spyfemale, MortarAmmo] = 10; 
 $ItemMax[spyfemale, RocketAmmo] = 5; 
 $ItemMax[spyfemale, SniperAmmo] = 25; 
 $ItemMax[spyfemale, RailAmmo] = 10; 
 $ItemMax[spyfemale, SilencerAmmo] = 15; 
 $ItemMax[spyfemale, VulcanAmmo] = 200; 
 
$ItemMax[spyfemale, EnergyPack] = 1; 
 $ItemMax[spyfemale, RepairPack] = 1; 
 $ItemMax[spyfemale, ShieldPack] = 1; 
 $ItemMax[spyfemale, SensorJammerPack] = 1; 
 $ItemMax[spyfemale, MotionSensorPack] = 1; 
 $ItemMax[spyfemale, PulseSensorPack] = 1; 
 $ItemMax[spyfemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[spyfemale, CameraPack] = 1; 
 $ItemMax[spyfemale, TurretPack] = 0; 
 $ItemMax[spyfemale, AmmoPack] = 1; 
 $ItemMax[spyfemale, RepairKit] = 1; 
 $ItemMax[spyfemale, DeployableInvPack] = 0; 
 $ItemMax[spyfemale, DeployableAmmoPack] = 0; 
 $ItemMax[spyfemale, DeployableComPack] = 0; 
 $ItemMax[spyfemale, LaserTurret] = 0; 
 $ItemMax[spyfemale, ForceFieldPack] = 1; 
 $ItemMax[spyfemale, RocketPack] = 0; 
 $ItemMax[spyfemale, LaserPack] = 1; 
 $ItemMax[spyfemale, CloakingDevice] = 1; 
 $ItemMax[spyfemale, StealthShieldPack] = 0; 
 $ItemMax[spyfemale, HeatSink] = 1; 
 $ItemMax[spyfemale, Laptop] = 1; 
 $ItemMax[spyfemale, TargetPack] = 0; 
 $ItemMax[spyfemale, MechPack] = 0; 
 $ItemMax[spyfemale, ShockPack] = 0; 
 $ItemMax[spyfemale, TeleportPack] = 0; 
 $ItemMax[spyfemale, TripwirePack] = 0; 
 $ItemMax[spyfemale, TreePack] = 0; 
 $ItemMax[spyfemale, SpringPack] = 0; 
 $ItemMax[spyfemale, SuicidePack] = 0; 
 $ItemMax[spyfemale, HPCPack] = 0; 
 $ItemMax[spyfemale, HoloPack] = 1; 
 $ItemMax[spyfemale, Vengeance] = 0; 
 $ItemMax[spyfemale, RailTurret] = 0; 
 $ItemMax[spyfemale, VulcanTurret] = 0; 
 $ItemMax[spyfemale, TLaserPack] = 1;
 
$MaxWeapons[spyfemale] = 3;

//earmor = Male Engineer
 
 $DamageScale[earmor, $LandingDamageType] = 1.0; 
 $DamageScale[earmor, $ImpactDamageType] = 1.0; 
 $DamageScale[earmor, $CrushDamageType] = 1.0; 
 $DamageScale[earmor, $BulletDamageType] = 0.4; 
 $DamageScale[earmor, $PlasmaDamageType] = 0.8; 
 $DamageScale[earmor, $EnergyDamageType] = 1.0; 
 $DamageScale[earmor, $ExplosionDamageType] = 1.0; 
 $DamageScale[earmor, $MissileDamageType] = 1.0; 
 $DamageScale[earmor, $ShrapnelDamageType] = 1.0; 
 $DamageScale[earmor, $DebrisDamageType] = 1.0; 
 $DamageScale[earmor, $LaserDamageType] = 1.0; 
 $DamageScale[earmor, $MortarDamageType] = 1.0; 
 $DamageScale[earmor, $BlasterDamageType] = 1.0; 
 $DamageScale[earmor, $ElectricityDamageType] = 1.0; 
 $DamageScale[earmor, $MineDamageType] = 1.0; 
 $DamageScale[earmor, $SniperDamageType] = 0.9; 
 $DamageScale[earmor, $FlashDamageType] = 1.0; 
 $DamageScale[earmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[earmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[earmor, $HighWarheadDamageType] = 1.0;
 $DamageScale[earmor, $EMPWarheadDamageType] = 1.0;

$ItemMax[earmor, Blaster] = 1; 
 $ItemMax[earmor, Chaingun] = 1; 
 $ItemMax[earmor, Disclauncher] = 1; 
 $ItemMax[earmor, GrenadeLauncher] = 1; 
 $ItemMax[earmor, Mortar] = 0; 
 $ItemMax[earmor, PlasmaGun] = 1; 
 $ItemMax[earmor, LaserRifle] = 0; 
 $ItemMax[earmor, EnergyRifle] = 1; 
 $ItemMax[earmor, TargetingLaser] = 1; 
 $ItemMax[earmor, MineAmmo] = 6; 
 $ItemMax[earmor, Grenade] = 4; 
 $ItemMax[earmor, Beacon] = 2; 
 $ItemMax[earmor, Boost] = 4; 
 $ItemMax[earmor, Plastique] = 0; 
 $ItemMax[earmor, RocketLauncher] = 0; 
 $ItemMax[earmor, SniperRifle] = 0; 
 $ItemMax[earmor, WaveGun] = 1; 
 $ItemMax[earmor, Railgun] = 1; 
 $ItemMax[earmor, Gaussgun] = 0; 
 $ItemMax[earmor, Vulcan] = 0; 
 $ItemMax[earmor, Vulcan2] = 0; 
 $ItemMax[earmor, Silencer] = 0; 
 $ItemMax[earmor, Flamer] = 0; 
 $ItemMax[earmor, IonGun] = 0; 
 $ItemMax[earmor, Omega] = 0; 
 $ItemMax[earmor, HyperB] = 1; 
 $ItemMax[earmor, Fixit] = 1; 
 $ItemMax[earmor, SilencerAmmo] = 15;
 $ItemMax[earmor, BulletAmmo] = 150; 
 $ItemMax[earmor, PlasmaAmmo] = 40; 
 $ItemMax[earmor, DiscAmmo] = 15; 
 $ItemMax[earmor, GrenadeAmmo] = 10; 
 $ItemMax[earmor, MortarAmmo] = 10; 
 $ItemMax[earmor, RocketAmmo] = 5; 
 $ItemMax[earmor, SniperAmmo] = 15; 
 $ItemMax[earmor, RailAmmo] = 7; 
 $ItemMax[earmor, VulcanAmmo] = 200; 
 
 $ItemMax[earmor, EnergyPack] = 1; 
 $ItemMax[earmor, RepairPack] = 1; 
 $ItemMax[earmor, ShieldPack] = 0; 
 $ItemMax[earmor, SensorJammerPack] = 1; 
 $ItemMax[earmor, MotionSensorPack] = 1; 
 $ItemMax[earmor, PulseSensorPack] = 1; 
 $ItemMax[earmor, DeployableFieldSensorPack] = 1; 
 $ItemMax[earmor, DeployableSensorJammerPack] = 1; 
 $ItemMax[earmor, DeployableLRMotionSensorPack] = 1; 
 $ItemMax[earmor, CameraPack] = 1; 
 $ItemMax[earmor, TurretPack] = 1; 
 $ItemMax[earmor, AmmoPack] = 1; 
 $ItemMax[earmor, RepairKit] = 1; 
 $ItemMax[earmor, DeployableInvPack] = 1; 
 $ItemMax[earmor, DeployableAmmoPack] = 1; 
 $ItemMax[earmor, DeployableComPack] = 1; 
 $ItemMax[earmor, LaserTurret] = 1; 
 $ItemMax[earmor, ForceFieldPack] = 1; 
 $ItemMax[earmor, LargeForceFieldPack] = 1; 
 $ItemMax[earmor, RocketPack] = 1; 
 $ItemMax[earmor, LaserPack] = 1; 
 $ItemMax[earmor, CloakingDevice] = 0; 
 $ItemMax[earmor, StealthShieldPack] = 0; 
 $ItemMax[earmor, TeleportPack] = 1; 
 $ItemMax[earmor, HeatSink] = 1; 
 $ItemMax[earmor, TripwirePack] = 1; 
 $ItemMax[earmor, Laptop] = 1; 
 $ItemMax[earmor, ShockPack] = 1; 
 $ItemMax[earmor, PlatformPack] = 1; 
 $ItemMax[earmor, TreePack] = 1; 
 $ItemMax[earmor, TargetPack] = 1; 
 $ItemMax[earmor, MechPack] = 0; 
 $ItemMax[earmor, SuicidePack] = 0; 
 $ItemMax[earmor, HoloPack] = 1; 
 $ItemMax[earmor, SpringPack] = 1; 
 $ItemMax[earmor, Vengeance] = 0; 
 $ItemMax[earmor, HPCPack] = 1; 
 $ItemMax[earmor, RailTurret] = 1; 
 $ItemMax[earmor, VulcanTurret] = 1; 
 $ItemMax[earmor, TLaserPack] = 1;
 
$MaxWeapons[earmor] = 4; 

//efemale = Female Engineer

 $DamageScale[efemale, $LandingDamageType] = 1.0; 
 $DamageScale[efemale, $ImpactDamageType] = 1.0; 
 $DamageScale[efemale, $CrushDamageType] = 1.0; 
 $DamageScale[efemale, $BulletDamageType] = 0.4; 
 $DamageScale[efemale, $EnergyDamageType] = 1.0; 
 $DamageScale[efemale, $PlasmaDamageType] = 0.8; 
 $DamageScale[efemale, $ExplosionDamageType] = 1.0; 
 $DamageScale[efemale, $MissileDamageType] = 1.0; 
 $DamageScale[efemale, $ShrapnelDamageType] = 1.0; 
 $DamageScale[efemale, $DebrisDamageType] = 1.0; 
 $DamageScale[efemale, $LaserDamageType] = 1.0; 
 $DamageScale[efemale, $MortarDamageType] = 1.0; 
 $DamageScale[efemale, $BlasterDamageType] = 1.0; 
 $DamageScale[efemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[efemale, $MineDamageType] = 1.0; 
 $DamageScale[efemale, $SniperDamageType] = 0.9; 
 $DamageScale[efemale, $FlashDamageType] = 1.0; 
 $DamageScale[efemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[efemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[efemale, $HighWarheadDamageType] = 1.0;
 $DamageScale[efemale, $EMPWarheadDamageType] = 1.0;

$ItemMax[efemale, Blaster] = 1; 
 $ItemMax[efemale, Chaingun] = 1; 
 $ItemMax[efemale, Disclauncher] = 1; 
 $ItemMax[efemale, GrenadeLauncher] = 1; 
 $ItemMax[efemale, Mortar] = 0; 
 $ItemMax[efemale, PlasmaGun] = 1; 
 $ItemMax[efemale, LaserRifle] = 0; 
 $ItemMax[efemale, EnergyRifle] = 1; 
 $ItemMax[efemale, TargetingLaser] = 1; 
 $ItemMax[efemale, MineAmmo] = 6; 
 $ItemMax[efemale, Grenade] = 4; 
 $ItemMax[efemale, Beacon] = 2; 
 $ItemMax[efemale, Boost] = 4; 
 $ItemMax[efemale, Plastique] = 0; 
 $ItemMax[efemale, RocketLauncher] = 0; 
 $ItemMax[efemale, SniperRifle] = 0; 
 $ItemMax[efemale, WaveGun] = 1; 
 $ItemMax[efemale, Railgun] = 1; 
 $ItemMax[efemale, Gaussgun] = 0; 
 $ItemMax[efemale, Vulcan] = 0; 
 $ItemMax[efemale, Vulcan2] = 0; 
 $ItemMax[efemale, Silencer] = 0; 
 $ItemMax[efemale, Flamer] = 0; 
 $ItemMax[efemale, IonGun] = 0; 
 $ItemMax[efemale, Omega] = 0; 
 $ItemMax[efemale, HyperB] = 1; 
 $ItemMax[efemale, Fixit] = 1; 
 
$ItemMax[efemale, SilencerAmmo] = 15;
 $ItemMax[efemale, BulletAmmo] = 150; 
 $ItemMax[efemale, PlasmaAmmo] = 35; 
 $ItemMax[efemale, DiscAmmo] = 15; 
 $ItemMax[efemale, GrenadeAmmo] = 10; 
 $ItemMax[efemale, MortarAmmo] = 10; 
 $ItemMax[efemale, SniperAmmo] = 15; 
 $ItemMax[efemale, RocketAmmo] = 5; 
 $ItemMax[efemale, RailAmmo] = 7;
 $ItemMax[efemale, VulcanAmmo] = 200; 
 
$ItemMax[efemale, EnergyPack] = 1; 
 $ItemMax[efemale, RepairPack] = 1; 
 $ItemMax[efemale, ShieldPack] = 0;
 $ItemMax[efemale, SensorJammerPack] = 1; 
 $ItemMax[efemale, MotionSensorPack] = 1; 
 $ItemMax[efemale, PulseSensorPack] = 1; 
 $ItemMax[efemale, DeployableFieldSensorPack] = 1;
 $ItemMax[efemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[efemale, DeployableLRMotionSensorPack] = 1;
 $ItemMax[efemale, CameraPack] = 1; 
 $ItemMax[efemale, TurretPack] = 1; 
 $ItemMax[efemale, AmmoPack] = 1; 
 $ItemMax[efemale, HeatSink] = 1; 
 $ItemMax[efemale, RepairKit] = 1; 
 $ItemMax[efemale, DeployableInvPack] = 1; 
 $ItemMax[efemale, DeployableAmmoPack] = 1; 
 $ItemMax[efemale, DeployableComPack] = 1; 
 $ItemMax[efemale, LaserTurret] = 1; 
 $ItemMax[efemale, ForceFieldPack] = 1; 
 $ItemMax[efemale, LargeForceFieldPack] = 1; 
 $ItemMax[efemale, RocketPack] = 1; 
 $ItemMax[efemale, LaserPack] = 1; 
 $ItemMax[efemale, CloakingDevice] = 0; 
 $ItemMax[efemale, StealthShieldPack] = 0; 
 $ItemMax[efemale,TeleportPack] = 1; 
 $ItemMax[efemale,TripwirePack] = 1; 
 $ItemMax[efemale, Laptop] = 1; 
 $ItemMax[efemale, ShockPack] = 1; 
 $ItemMax[efemale, PlatformPack] = 1; 
 $ItemMax[efemale, TreePack] = 1; 
 $ItemMax[efemale, TargetPack] = 1; 
 $ItemMax[efemale, MechPack] = 0; 
 $ItemMax[efemale, SuicidePack] = 0; 
 $ItemMax[efemale, HPCPack] = 1; 
 $ItemMax[efemale, HoloPack] = 1; 
 $ItemMax[efemale, SpringPack] = 1; 
 $ItemMax[efemale, Vengeance] = 0; 
 $ItemMax[efemale, RailTurret] = 1; 
 $ItemMax[efemale, VulcanTurret] = 1; 
 $ItemMax[efemale, TLaserPack] = 1;
 
$MaxWeapons[efemale] = 4; 

//aarmor = Male Alien

 $DamageScale[aarmor, $LandingDamageType] = 0.4; 
 $DamageScale[aarmor, $ImpactDamageType] = 1.0; 
 $DamageScale[aarmor, $CrushDamageType] = 1.0; 
 $DamageScale[aarmor, $BulletDamageType] = 1.2; 
 $DamageScale[aarmor, $PlasmaDamageType] = 1.5; 
 $DamageScale[aarmor, $EnergyDamageType] = 1.0; 
 $DamageScale[aarmor, $ExplosionDamageType] = 1.0; 
 $DamageScale[aarmor, $MissileDamageType] = 1.0; 
 $DamageScale[aarmor, $ShrapnelDamageType] = 1.0; 
 $DamageScale[aarmor, $DebrisDamageType] = 1.0; 
 $DamageScale[aarmor, $LaserDamageType] = 0.5; 
 $DamageScale[aarmor, $MortarDamageType] = 1.2; 
 $DamageScale[aarmor, $BlasterDamageType] = 0.5; 
 $DamageScale[aarmor, $ElectricityDamageType] = 0.5; 
 $DamageScale[aarmor, $MineDamageType] = 1.0; 
 $DamageScale[aarmor, $SniperDamageType] = 1.5; 
 $DamageScale[aarmor, $FlashDamageType] = 2.0; 
 $DamageScale[aarmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[aarmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[aarmor, $HighWarheadDamageType] = 1.0;
 $DamageScale[aarmor, $EMPWarheadDamageType] = 1.0;

$ItemMax[aarmor, Blaster] = 1; 
 $ItemMax[aarmor, Chaingun] = 0; 
 $ItemMax[aarmor, Disclauncher] = 0; 
 $ItemMax[aarmor, GrenadeLauncher] = 0; 
 $ItemMax[aarmor, Mortar] = 0; 
 $ItemMax[aarmor, PlasmaGun] = 0; 
 $ItemMax[aarmor, LaserRifle] = 0; 
 $ItemMax[aarmor, EnergyRifle] = 1; 
 $ItemMax[aarmor, TargetingLaser] = 1; 
 $ItemMax[aarmor, MineAmmo] = 3; 
 $ItemMax[aarmor, Grenade] = 5; 
 $ItemMax[aarmor, Beacon] = 3; 
 $ItemMax[aarmor, Boost] = 4; 
 $ItemMax[aarmor, Plastique] = 0; 
 $ItemMax[aarmor, RocketLauncher] = 0; 
 $ItemMax[aarmor, SniperRifle] = 0; 
 $ItemMax[aarmor, WaveGun] = 1; 
 $ItemMax[aarmor, Railgun] = 0; 
 $ItemMax[aarmor, Vulcan] = 0; 
 $ItemMax[aarmor, Vulcan2] = 0; 
 $ItemMax[aarmor, Silencer] = 0; 
 $ItemMax[aarmor, Flamer] = 0; 
 $ItemMax[aarmor, IonGun] = 1; 
 $ItemMax[aarmor, Omega] = 1; 
 $ItemMax[aarmor, HyperB] = 1; 
 $ItemMax[aarmor, Fixit] = 0; 

 
$ItemMax[aarmor, BulletAmmo] = 150; 
 $ItemMax[aarmor, PlasmaAmmo] = 40; 
 $ItemMax[aarmor, DiscAmmo] = 15; 
 $ItemMax[aarmor, GrenadeAmmo] = 10; 
 $ItemMax[aarmor, MortarAmmo] = 10; 
 $ItemMax[aarmor, RocketAmmo] = 5; 
 $ItemMax[aarmor, SniperAmmo] = 15; 
 $ItemMax[aarmor, RailAmmo] = 10; 
 $ItemMax[aarmor, SilencerAmmo] = 25; 
 $ItemMax[aarmor, VulcanAmmo] = 300; 
 
$ItemMax[aarmor, EnergyPack] = 1; 
 $ItemMax[aarmor, RepairPack] = 1; 
 $ItemMax[aarmor, ShieldPack] = 1; 
 $ItemMax[aarmor, SensorJammerPack] = 0; 
 $ItemMax[aarmor, MotionSensorPack] = 1; 
 $ItemMax[aarmor, PulseSensorPack] = 1; 
 $ItemMax[aarmor, DeployableSensorJammerPack] = 1; 
 $ItemMax[aarmor, CameraPack] = 1; 
 $ItemMax[aarmor, TurretPack] = 1; 
 $ItemMax[aarmor, AmmoPack] = 1; 
 $ItemMax[aarmor, RepairKit] = 1; 
 $ItemMax[aarmor, DeployableInvPack] = 0; 
 $ItemMax[aarmor, DeployableAmmoPack] = 1; 
 $ItemMax[aarmor, DeployableComPack] = 0; 
 $ItemMax[aarmor, LaserTurret] = 0; 
 $ItemMax[aarmor, ForceFieldPack] = 1; 
 $ItemMax[aarmor, LargeForceFieldPack] = 1; 
 $ItemMax[aarmor, RocketPack] = 0; 
 $ItemMax[aarmor, LaserPack] = 0; 
 $ItemMax[aarmor, CloakingDevice] = 0; 
 $ItemMax[aarmor, StealthShieldPack] = 0; 
 $ItemMax[aarmor, TargetPack] = 0; 
 $ItemMax[aarmor, MechPack] = 0; 
 $ItemMax[aarmor, Laptop] = 0; 
 $ItemMax[aarmor, HeatSink] = 1; 
 $ItemMax[aarmor, ShockPack] = 0; 
 $ItemMax[aarmor, TeleportPack] = 0; 
 $ItemMax[aarmor, TripwirePack] = 0; 
 $ItemMax[aarmor, TreePack] = 0; 
 $ItemMax[aarmor, SpringPack] = 0; 
 $ItemMax[aarmor, SuicidePack] = 0; 
 $ItemMax[aarmor, HPCPack] = 0; 
 $ItemMax[aarmor, HoloPack] = 1; 
 $ItemMax[aarmor, Vengeance] = 0; 
 $ItemMax[aarmor, RailTurret] = 0; 
 $ItemMax[aarmor, VulcanTurret] = 0; 
 $ItemMax[aarmor, TLaserPack] = 1;
 
$MaxWeapons[aarmor] = 4;

//afemale = Female Alien
 
 $DamageScale[afemale, $LandingDamageType] = 0.4; 
 $DamageScale[afemale, $ImpactDamageType] = 1.0; 
 $DamageScale[afemale, $CrushDamageType] = 1.0; 
 $DamageScale[afemale, $BulletDamageType] = 1.2; 
 $DamageScale[afemale, $PlasmaDamageType] = 1.5; 
 $DamageScale[afemale, $EnergyDamageType] = 1.0; 
 $DamageScale[afemale, $ExplosionDamageType] = 1.0; 
 $DamageScale[afemale, $MissileDamageType] = 1.0; 
 $DamageScale[afemale, $ShrapnelDamageType] = 1.0; 
 $DamageScale[afemale, $DebrisDamageType] = 1.0; 
 $DamageScale[afemale, $LaserDamageType] = 0.5; 
 $DamageScale[afemale, $MortarDamageType] = 1.2; 
 $DamageScale[afemale, $BlasterDamageType] = 0.5; 
 $DamageScale[afemale, $ElectricityDamageType] = 0.5; 
 $DamageScale[afemale, $MineDamageType] = 1.0; 
 $DamageScale[afemale, $SniperDamageType] = 1.5; 
 $DamageScale[afemale, $FlashDamageType] = 2.0; 
 $DamageScale[afemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[afemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[afemale, $HighWarheadDamageType] = 1.0;
 $DamageScale[afemale, $EMPWarheadDamageType] = 1.0; 

$ItemMax[afemale, Blaster] = 1; 
 $ItemMax[afemale, Chaingun] = 0; 
 $ItemMax[afemale, Disclauncher] = 0; 
 $ItemMax[afemale, GrenadeLauncher] = 0; 
 $ItemMax[afemale, Mortar] = 0; 
 $ItemMax[afemale, PlasmaGun] = 0; 
 $ItemMax[afemale, LaserRifle] = 0; 
 $ItemMax[afemale, EnergyRifle] = 1; 
 $ItemMax[afemale, TargetingLaser] = 1; 
 $ItemMax[afemale, MineAmmo] = 3; 
 $ItemMax[afemale, Grenade] = 5; 
 $ItemMax[afemale, Beacon] = 3; 
 $ItemMax[afemale, Boost] = 4; 
 $ItemMax[afemale, Plastique] = 0; 
 $ItemMax[afemale, RocketLauncher] = 0; 
 $ItemMax[afemale, SniperRifle] = 0; 
 $ItemMax[afemale, WaveGun] = 1; 
 $ItemMax[afemale, Railgun] = 0; 
 $ItemMax[afemale, Vulcan] = 0; 
 $ItemMax[afemale, Vulcan2] = 0; 
 $ItemMax[afemale, Silencer] = 0; 
 $ItemMax[afemale, Flamer] = 0; 
 $ItemMax[afemale, IonGun] = 1; 
 $ItemMax[afemale, Omega] = 1; 
 $ItemMax[afemale, HyperB] = 1; 
 $ItemMax[afemale, Fixit] = 0; 
 
$ItemMax[afemale, BulletAmmo] = 150; 
 $ItemMax[afemale, PlasmaAmmo] = 40; 
 $ItemMax[afemale, DiscAmmo] = 15; 
 $ItemMax[afemale, GrenadeAmmo] = 10; 
 $ItemMax[afemale, MortarAmmo] = 10; 
 $ItemMax[afemale, RocketAmmo] = 5; 
 $ItemMax[afemale, SniperAmmo] = 15; 
 $ItemMax[afemale, RailAmmo] = 10; 
 $ItemMax[afemale, SilencerAmmo] = 25; 
 $ItemMax[afemale, VulcanAmmo] = 300; 
 
$ItemMax[afemale, EnergyPack] = 1; 
 $ItemMax[afemale, RepairPack] = 1; 
 $ItemMax[afemale, ShieldPack] = 1; 
 $ItemMax[afemale, SensorJammerPack] = 0; 
 $ItemMax[afemale, MotionSensorPack] = 1; 
 $ItemMax[afemale, PulseSensorPack] = 1; 
 $ItemMax[afemale, DeployableSensorJammerPack] = 1; 
 $ItemMax[afemale, CameraPack] = 1; 
 $ItemMax[afemale, TurretPack] = 1; 
 $ItemMax[afemale, AmmoPack] = 1; 
 $ItemMax[afemale, RepairKit] = 1; 
 $ItemMax[afemale, DeployableInvPack] = 0; 
 $ItemMax[afemale, DeployableAmmoPack] = 1; 
 $ItemMax[afemale, DeployableComPack] = 0; 
 $ItemMax[afemale, LaserTurret] = 0; 
 $ItemMax[afemale, ForceFieldPack] = 1; 
 $ItemMax[afemale, LargeForceFieldPack] = 1; 
 $ItemMax[afemale, RocketPack] = 0; 
 $ItemMax[afemale, HeatSink] = 1; 
 $ItemMax[afemale, LaserPack] = 0; 
 $ItemMax[afemale, CloakingDevice] = 0; 
 $ItemMax[afemale, StealthShieldPack] = 0; 
 $ItemMax[afemale, TargetPack] = 0; 
 $ItemMax[afemale, MechPack] = 0; 
 $ItemMax[afemale, Laptop] = 0; 
 $ItemMax[afemale, ShockPack] = 0; 
 $ItemMax[afemale, TeleportPack] = 0; 
 $ItemMax[afemale, TripwirePack] = 0; 
 $ItemMax[afemale, TreePack] = 0; 
 $ItemMax[afemale, SpringPack] = 0; 
 $ItemMax[afemale, SuicidePack] = 0; 
 $ItemMax[afemale, HPCPack] = 0; 
 $ItemMax[afemale, HoloPack] = 1; 
 $ItemMax[afemale, Vengeance] = 0; 
 $ItemMax[afemale, RailTurret] = 0; 
 $ItemMax[afemale, VulcanTurret] = 0; 
 $ItemMax[afemale, TLaserPack] = 1;

$MaxWeapons[afemale] = 4;

//dmarmor = Male Death Match 
 
 $DamageScale[dmarmor, $LandingDamageType] = 1.0; 
 $DamageScale[dmarmor, $ImpactDamageType] = 1.0; 
 $DamageScale[dmarmor, $CrushDamageType] = 1.0; 
 $DamageScale[dmarmor, $BulletDamageType] = 0.8; 
 $DamageScale[dmarmor, $PlasmaDamageType] = 0.8; 
 $DamageScale[dmarmor, $EnergyDamageType] = 1.0; 
 $DamageScale[dmarmor, $ExplosionDamageType] = 1.0; 
 $DamageScale[dmarmor, $MissileDamageType] = 1.0; 
 $DamageScale[dmarmor, $ShrapnelDamageType] = 1.0; 
 $DamageScale[dmarmor, $DebrisDamageType] = 1.0; 
 $DamageScale[dmarmor, $LaserDamageType] = 1.0; 
 $DamageScale[dmarmor, $MortarDamageType] = 1.0; 
 $DamageScale[dmarmor, $BlasterDamageType] = 1.0; 
 $DamageScale[dmarmor, $ElectricityDamageType] = 1.0; 
 $DamageScale[dmarmor, $MineDamageType] = 1.0; 
 $DamageScale[dmarmor, $SniperDamageType] = 1.0; 
 $DamageScale[dmarmor, $FlashDamageType] = 1.0; 
 $DamageScale[dmarmor, $LowWarheadDamageType] = 1.0;
 $DamageScale[dmarmor, $MedWarheadDamageType] = 1.0;
 $DamageScale[dmarmor, $HighWarheadDamageType] = 1.0;
 $DamageScale[dmarmor, $EMPWarheadDamageType] = 1.0; 

$ItemMax[dmarmor, Blaster] = 1; 
 $ItemMax[dmarmor, Chaingun] = 1; 
 $ItemMax[dmarmor, Disclauncher] = 1; 
 $ItemMax[dmarmor, GrenadeLauncher] = 1; 
 $ItemMax[dmarmor, Mortar] = 0; 
 $ItemMax[dmarmor, PlasmaGun] = 1; 
 $ItemMax[dmarmor, LaserRifle] = 1; 
 $ItemMax[dmarmor, EnergyRifle] = 1; 
 $ItemMax[dmarmor, TargetingLaser] = 1; 
 $ItemMax[dmarmor, MineAmmo] = 3; 
 $ItemMax[dmarmor, Grenade] = 6; 
 $ItemMax[dmarmor, Beacon] = 1; 
 $ItemMax[dmarmor, Boost] = 4; 
 $ItemMax[dmarmor, Plastique] = 1; 
 $ItemMax[dmarmor, RocketLauncher] = 1; 
 $ItemMax[dmarmor, SniperRifle] = 0; 
 $ItemMax[dmarmor, WaveGun] = 0; 
 $ItemMax[dmarmor, Railgun] = 1; 
 $ItemMax[dmarmor, Vulcan] = 1; 
 $ItemMax[dmarmor, Vulcan2] = 1;
 $ItemMax[dmarmor, Silencer] = 0; 
 $ItemMax[dmarmor, Flamer] = 1; 
 $ItemMax[dmarmor, IonGun] = 1; 
 $ItemMax[dmarmor, Omega] = 1; 
 $ItemMax[dmarmor, HyperB] = 1; 
 $ItemMax[dmarmor, Fixit] = 0; 
 $ItemMax[dmarmor, Bolt] = 1; 
 
$ItemMax[dmarmor, BulletAmmo] = 150; 
 $ItemMax[dmarmor, PlasmaAmmo] = 40; 
 $ItemMax[dmarmor, DiscAmmo] = 15; 
 $ItemMax[dmarmor, GrenadeAmmo] = 10; 
 $ItemMax[dmarmor, MortarAmmo] = 10; 
 $ItemMax[dmarmor, RocketAmmo] = 5; 
 $ItemMax[dmarmor, SniperAmmo] = 15; 
 $ItemMax[dmarmor, RailAmmo] = 10; 
 $ItemMax[dmarmor, SilencerAmmo] = 25; 
 $ItemMax[dmarmor, VulcanAmmo] = 200; 
 
$ItemMax[dmarmor, EnergyPack] = 1; 
 $ItemMax[dmarmor, RepairPack] = 1; 
 $ItemMax[dmarmor, ShieldPack] = 1; 
 $ItemMax[dmarmor, SensorJammerPack] = 0; 
 $ItemMax[dmarmor, MotionSensorPack] = 0; 
 $ItemMax[dmarmor, PulseSensorPack] = 0; 
 $ItemMax[dmarmor, DeployableSensorJammerPack] = 0; 
 $ItemMax[dmarmor, CameraPack] = 0; 
 $ItemMax[dmarmor, TurretPack] = 0; 
 $ItemMax[dmarmor, AmmoPack] = 1; 
 $ItemMax[dmarmor, RepairKit] = 1; 
 $ItemMax[dmarmor, DeployableInvPack] = 1; 
 $ItemMax[dmarmor, DeployableAmmoPack] = 0; 
 $ItemMax[dmarmor, DeployableComPack] = 0; 
 $ItemMax[dmarmor, LaserTurret] = 1; 
 $ItemMax[dmarmor, ForceFieldPack] = 1; 
 $ItemMax[dmarmor, RocketPack] = 0; 
 $ItemMax[dmarmor, LaserPack] = 0; 
 $ItemMax[dmarmor, CloakingDevice] = 0; 
 $ItemMax[dmarmor, StealthShieldPack] = 0; 
 $ItemMax[dmarmor, HeatSink] = 1; 
 $ItemMax[dmarmor, TargetPack] = 0; 
 $ItemMax[dmarmor, MechPack] = 0; 
 $ItemMax[dmarmor, Laptop] = 0; 
 $ItemMax[dmarmor, ShockPack] = 0; 
 $ItemMax[dmarmor, TeleportPack] = 1; 
 $ItemMax[dmarmor, TripwirePack] = 0; 
 $ItemMax[dmarmor, TreePack] = 0; 
 $ItemMax[dmarmor, SpringPack] = 1; 
 $ItemMax[dmarmor, SuicidePack] = 0; 
 $ItemMax[dmarmor, HPCPack] = 0; 
 $ItemMax[dmarmor, HoloPack] = 1; 
 $ItemMax[dmarmor, Vengeance] = 1; 
 $ItemMax[dmarmor, RailTurret] = 1; 
 $ItemMax[dmarmor, VulcanTurret] = 1; 
 $ItemMax[dmarmor, PlatformPack] = 1; 
 $ItemMax[dmarmor, TLaserPack] = 1; 

$MaxWeapons[dmarmor] = 4;

//dmfemale = Female Death Match
 
 $DamageScale[dmfemale, $LandingDamageType] = 1.0; 
 $DamageScale[dmfemale, $ImpactDamageType] = 1.0; 
 $DamageScale[dmfemale, $CrushDamageType] = 1.0; 
 $DamageScale[dmfemale, $BulletDamageType] = 0.8; 
 $DamageScale[dmfemale, $PlasmaDamageType] = 0.8;
 $DamageScale[dmfemale, $EnergyDamageType] = 1.0; 
 $DamageScale[dmfemale, $ExplosionDamageType] = 1.0; 
 $DamageScale[dmfemale, $MissileDamageType] = 1.0; 
 $DamageScale[dmfemale, $ShrapnelDamageType] = 1.0; 
 $DamageScale[dmfemale, $DebrisDamageType] = 1.0; 
 $DamageScale[dmfemale, $LaserDamageType] = 1.0; 
 $DamageScale[dmfemale, $MortarDamageType] = 1.0; 
 $DamageScale[dmfemale, $BlasterDamageType] = 1.0; 
 $DamageScale[dmfemale, $ElectricityDamageType] = 1.0; 
 $DamageScale[dmfemale, $MineDamageType] = 1.0; 
 $DamageScale[dmfemale, $SniperDamageType] = 1.0; 
 $DamageScale[dmfemale, $FlashDamageType] = 1.0; 
 $DamageScale[dmfemale, $LowWarheadDamageType] = 1.0;
 $DamageScale[dmfemale, $MedWarheadDamageType] = 1.0;
 $DamageScale[dmfemale, $HighWarheadDamageType] = 1.0;
 $DamageScale[dmfemale, $EMPWarheadDamageType] = 1.0; 

$ItemMax[dmfemale, Blaster] = 1; 
 $ItemMax[dmfemale, Chaingun] = 1; 
 $ItemMax[dmfemale, Disclauncher] = 1; 
 $ItemMax[dmfemale, GrenadeLauncher] = 1; 
 $ItemMax[dmfemale, Mortar] = 0; 
 $ItemMax[dmfemale, PlasmaGun] = 1; 
 $ItemMax[dmfemale, LaserRifle] = 1; 
 $ItemMax[dmfemale, EnergyRifle] = 1; 
 $ItemMax[dmfemale, TargetingLaser] = 1; 
 $ItemMax[dmfemale, MineAmmo] = 3; 
 $ItemMax[dmfemale, Grenade] = 6; 
 $ItemMax[dmfemale, Beacon] = 1; 
 $ItemMax[dmfemale, Boost] = 4; 
 $ItemMax[dmfemale, Plastique] = 1; 
 $ItemMax[dmfemale, RocketLauncher] = 1; 
 $ItemMax[dmfemale, SniperRifle] = 0; 
 $ItemMax[dmfemale, WaveGun] = 0; 
 $ItemMax[dmfemale, Railgun] = 1; 
 $ItemMax[dmfemale, Vulcan] = 1; 
 $ItemMax[dmfemale, Vulcan2] = 1;
 $ItemMax[dmfemale, Silencer] = 0; 
 $ItemMax[dmfemale, Flamer] = 1; 
 $ItemMax[dmfemale, IonGun] = 1; 
 $ItemMax[dmfemale, Omega] = 1; 
 $ItemMax[dmfemale, HyperB] = 1; 
 $ItemMax[dmfemale, Fixit] = 0; 
 $ItemMax[dmfemale, Bolt] = 1; 
 
$ItemMax[dmfemale, BulletAmmo] = 150; 
 $ItemMax[dmfemale, PlasmaAmmo] = 40; 
 $ItemMax[dmfemale, DiscAmmo] = 15; 
 $ItemMax[dmfemale, GrenadeAmmo] = 10; 
 $ItemMax[dmfemale, MortarAmmo] = 10; 
 $ItemMax[dmfemale, RocketAmmo] = 3; 
 $ItemMax[dmfemale, SniperAmmo] = 15; 
 $ItemMax[dmfemale, RailAmmo] = 10; 
 $ItemMax[dmfemale, SilencerAmmo] = 25; 
 $ItemMax[dmfemale, VulcanAmmo] = 200; 

 
$ItemMax[dmfemale, EnergyPack] = 1; 
 $ItemMax[dmfemale, RepairPack] = 1; 
 $ItemMax[dmfemale, ShieldPack] = 1; 
 $ItemMax[dmfemale, SensorJammerPack] = 0; 
 $ItemMax[dmfemale, MotionSensorPack] = 0; 
 $ItemMax[dmfemale, PulseSensorPack] = 0; 
 $ItemMax[dmfemale, DeployableSensorJammerPack] = 0; 
 $ItemMax[dmfemale, CameraPack] = 0; 
 $ItemMax[dmfemale, TurretPack] = 0; 
 $ItemMax[dmfemale, AmmoPack] = 1; 
 $ItemMax[dmfemale, RepairKit] = 1; 
 $ItemMax[dmfemale, DeployableInvPack] = 1; 
 $ItemMax[dmfemale, DeployableAmmoPack] = 0; 
 $ItemMax[dmfemale, DeployableComPack] = 0; 
 $ItemMax[dmfemale, LaserTurret] = 1; 
 $ItemMax[dmfemale, ForceFieldPack] = 1; 
 $ItemMax[dmfemale, HeatSink] = 1; 
 $ItemMax[dmfemale, RocketPack] = 0; 
 $ItemMax[dmfemale, LaserPack] = 0; 
 $ItemMax[dmfemale, CloakingDevice] = 0; 
 $ItemMax[dmfemale, StealthShieldPack] = 0; 
 $ItemMax[dmfemale, TargetPack] = 0; 
 $ItemMax[dmfemale, MechPack] = 0; 
 $ItemMax[dmfemale, Laptop] = 0; 
 $ItemMax[dmfemale, ShockPack] = 0; 
 $ItemMax[dmfemale, TeleportPack] = 1; 
 $ItemMax[dmfemale, TripwirePack] = 0; 
 $ItemMax[dmfemale, TreePack] = 0; 
 $ItemMax[dmfemale, SpringPack] = 1; 
 $ItemMax[dmfemale, SuicidePack] = 0; 
 $ItemMax[dmfemale, HPCPack] = 0; 
 $ItemMax[dmfemale, HoloPack] = 1; 
 $ItemMax[dmfemale, Vengeance] = 1; 
 $ItemMax[dmfemale, RailTurret] = 1; 
 $ItemMax[dmfemale, VulcanTurret] = 1; 
 $ItemMax[dmfemale, PlatformPack] = 1; 
 $ItemMax[dmfemale, TLaserPack] = 1;
 $MaxWeapons[dmfemale] = 4;

//------------------------------------------------------------------
// Sniper armor data:
//------------------------------------------------------------------


PlayerData larmor
{
   className = "Armor";
   shapeFile = "larmor";
   
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "dustplume";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

 	maxDamage = 0.70;
   validateShape = true;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
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


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Mercenary Armor data:
//------------------------------------------------------------------

PlayerData marmor
{
   className = "Armor";
   shapeFile = "marmor";
   
   flameShapeName = "smoke";
   shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = 1;
   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
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

//------------------------------------------------------------------
// Spawn Armor data:
//------------------------------------------------------------------

PlayerData spnmale
{
   className = "Armor";
   shapeFile = "harmor";
   
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 3.0;
   maxJetForwardVelocity = 30;
   minJetEnergy = 1;
   jetForce = 400;
   jetEnergyDrain = 0.9;

	maxDamage = 1.0;
   maxForwardSpeed = 8.5;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 6.0;
   groundForce = 35 * 10.0;
   mass = 18.0;
   groundTraction = 3.0;
	
	maxEnergy = 150;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 200;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
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

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//------------------------------------------------------------------
// Cyborg Armor data:
//------------------------------------------------------------------

 PlayerData harmor 
{
 className = "armor";
 shapeFile = "harmor";
 validateshape = true;
 flameShapeName = "hflame";
 shieldShapeName = "shield";
 damageSkinData = "armorDamageSkins";
 debrisId = playerDebris;
 shadowDetailMask = 1;
 visibleToSensor = True;
 mapFilter = 1;
 mapIcon = "M_player";
 maxJetSideForceFactor = 1.0;
 maxJetForwardVelocity = 15;
 minJetEnergy = 1;
 jetForce = 385;
 jetEnergyDrain = 1.1;
 maxDamage = 1.55;
 maxForwardSpeed = 7.5;
 maxBackwardSpeed = 7.5;
 maxSideSpeed = 7.0;
 groundForce = 55 * 27;
 groundTraction = 4.5;
 mass = 18.5;
 maxEnergy = 165;
 drag = 1500.0;
 density = 2.5;
 canCrouch = false;
 minDamageSpeed = 25;
 damageScale = 0.005;
 jumpImpulse = 150;
 jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
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

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//------------------------------------------------------------------
// Sniper female data:
//------------------------------------------------------------------

PlayerData lfemale
{
   className = "Armor";
   shapeFile = "lfemale";
    
   flameShapeName = "dustplume";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.70;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


//------------------------------------------------------------------
// Mercenary female data:
//------------------------------------------------------------------

PlayerData mfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   
   flameShapeName = "smoke";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Spawn female data:
//------------------------------------------------------------------

PlayerData spnfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
//Scout Armor Data:
//------------------------------------------------------------------

PlayerData sarmor
{
   className = "Armor";
   shapeFile = "larmor";
   
   damageSkinData = "armorDamageSkins";
   debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

 visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
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


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//---------------------------------------------------
//Burster Armor
//---------------------------------------------------

PlayerData barmor
{
   className = "Armor";
   shapeFile = "marmor";
   
   flameShapeName = "plastrail";
   shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
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

//---------------------------------------------------
//Dragoon Armor Data
//---------------------------------------------------

PlayerData darmor
{
className = "armor";
shapeFile = "harmor";

flameShapeName = "shield_large";
shieldShapeName = "shield";
damageSkinData = "armorDamageSkins";
debrisId = playerDebris;
shadowDetailMask = 1;
visibleToSensor = True;
mapFilter = 1;
mapIcon = "M_player";
maxJetSideForceFactor = 0.8;
maxJetForwardVelocity = 10;
minJetEnergy = 1;
jetForce = 385;
jetEnergyDrain = 1.0;
maxDamage = 1.70;
maxForwardSpeed = 7.3;
maxBackwardSpeed = 6.3;
maxSideSpeed = 6.0;
groundForce = 55 * 32;
groundTraction = 4.5;
mass = 20.2;
maxEnergy = 170;
drag = 3.0;
density = 2.5;
canCrouch = false;
minDamageSpeed = 25;
damageScale = 0.006;
jumpImpulse = 175;
jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
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

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//---------------------------------------------------------------
//Scout Armor Female Data
//---------------------------------------------------------------
PlayerData sfemale
{
	className = "Armor";
   shapeFile = "lfemale";
   
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//---------------------------------------------------
//Burster Armor Female
//---------------------------------------------------
PlayerData bfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   
   flameShapeName = "plastrail";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
   debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//----------------------------------------------------
//SpyArmor Data
//----------------------------------------------------
PlayerData spyarmor
{
	className = "Armor";
   shapeFile = "larmor";
   
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "rsmoke";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
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


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


//----------------------------------------------------
//SpyArmor Female Data
//----------------------------------------------------
PlayerData spyfemale
{
	className = "Armor";
   shapeFile = "lfemale";
   validateShape = true;
   flameShapeName = "rsmoke";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//-------------------------------------------------
//Engineer Armor
//-------------------------------------------------
PlayerData earmor
{
	className = "Armor";
   shapeFile = "marmor";
   
   flameShapeName = "paint";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
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
//------------------------------------------------------
//Engineer Armor Female
//------------------------------------------------------
PlayerData efemale
{
	className = "Armor";
   shapeFile = "mfemale";
   validateShape = true;
   flameShapeName = "paint";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------
//Alien Armor data
//------------------------------------------------------
PlayerData aarmor
{
	className = "Armor";
   shapeFile = "marmor";
   
   flameShapeName = "fusionex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;
repairRate = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
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
//----------------------------------------------------------
//Alien Armor Female
//----------------------------------------------------------
PlayerData afemale
{
	className = "Armor";
   shapeFile = "mfemale";
   
   flameShapeName = "fusionex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;
repairRate = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//----------------------------------------------------------
//Deathmatch Armor
//----------------------------------------------------------
PlayerData dmarmor
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
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 13.0;
   maxBackwardSpeed = 12.0;
   maxSideSpeed = 12.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 100;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
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
//----------------------------------------------------
//Deathmatch Armor Female
//----------------------------------------------------
PlayerData dmfemale
{
	className = "Armor";
   shapeFile = "mfemale";
   
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 13.0;
   maxBackwardSpeed = 12.0;
   maxSideSpeed = 12.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 100;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
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
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};