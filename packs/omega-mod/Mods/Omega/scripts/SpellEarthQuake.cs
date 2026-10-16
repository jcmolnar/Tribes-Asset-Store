//--------------------------------------

$AutoUse[EarthQuakeSpell] = True;
$WeaponAmmo[EarthQuakeSpell] = "";
//--------------------------------------

$InvList[EarthQuakeSpell] = 0;
$RemoteInvList[EarthQuakeSpell] = 0;

//--------------------------------------

RocketData EarthQuakeBlast
{
   bulletShapeName  = "breath.dts";
   explosionTag     = Ripple;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $EarthDamageType;

   explosionRadius  = 50.5;
   kickBackStrength = 300.0;
   muzzleVelocity   = 150.0;
   terminalVelocity = 150.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};


//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, EarthQuakeSpell] = 0;
$ItemMax[lfemale, EarthQuakeSpell] = 0;
$ItemMax[marmor, EarthQuakeSpell] = 0;
$ItemMax[mfemale, EarthQuakeSpell] = 0;
$ItemMax[harmor, EarthQuakeSpell] = 0;

//++++++++++++++++++++++++++++++++++++++

$DamageScale[larmor, $EarthDamageType] = 1;
$DamageScale[lfemale, $EarthDamageType] = 1;
$DamageScale[marmor, $EarthDamageType] = 1;
$DamageScale[mfemale, $EarthDamageType] = 1;
$DamageScale[harmor, $EarthDamageType] = 1;
//+++++++++++++++++++++++++++++++++++++++


ItemImageData EarthQuakeSpellImage
{
	shapeFile = "mrtwig";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 10.0;
	fireTime = 10.0;
	minEnergy = 60;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };

	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundDiscReady;
};

ItemData EarthQuakeSpell
{
	description = "Earth Quake Spell";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "yIndalacios Weapons";
	shadowDetailMask = 4;
	imageType = EarthQuakeSpellImage;
	price = 7500;
	showWeaponBar = true;
};

function FireEarthQuakeSpell(%player)
{
	if($FiringEarthQuakeSpell[%player] == True)
	{
		Projectile::spawnProjectile("EarthQuakeBlast",$EarthQuakeSpellTrans[%player],%player,$EarthQuakeSpellVel[%player]);
	}
	
	if($EarthQuakeSpellFired[%player] < 2)
	{
		$EarthQuakeSpellFired[%player]++;
		schedule("FireEarthQuakeSpell(" @ %player @ ");", 2.0);
	}
}

function EarthQuakeSpellImage::onFire(%player,%slot)
{
                messageAll(2,"[Earth Quake]");
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("EarthQuakeBlast",%trans,%player,%vel);

	$EarthQuakeSpellTrans[%player] = %trans;
	$EarthQuakeSpellVel[%player] = %vel;

	$FiringEarthQuakeSpell[%player] = True;
	$EarthQuakeSpellFired[%player] = 1;

	schedule("FireEarthQuakeSpell(" @ %player @ ");", 2.0);
}

function EarthQuakeSpell::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Summon earth demon to explode a piece of the earth in a magical ripple. Can affect flying enemies as well.");
}


//--------------------------------------


