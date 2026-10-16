//--------------------------------------

$AutoUse[Railgun] = True;
$SellAmmo[RailBolts] = 5;
$AmmoPackMax[RailBolts] = 5;
$AmmoPackItems[0] = RailBolts;
$WeaponAmmo[Railgun] = RailBolts;

//--------------------------------------

$InvList[Railgun] = 1;
$InvList[RailBolts] = 1;
$RemoteInvList[Railgun] = 1;
$RemoteInvList[RailBolts] = 1;

$ItemMax[narmor, Railgun] = 0;
$ItemMax[aarmor, Railgun] = 0;
$ItemMax[darmor, Railgun] = 0;
$ItemMax[nfemale, Railgun] = 0;
$ItemMax[afemale, Railgun] = 0;
$ItemMax[warmor, Railgun] = 0;
$ItemMax[barmor, Railgun] = 1;
$ItemMax[sarmor, Railgun] = 1;
$ItemMax[avarmor, Railgun] = 0;
$ItemMax[wfemale, Railgun] = 0;
$ItemMax[bfemale, Railgun] = 1;

$ItemMax[narmor, RailBolts] = 0;
$ItemMax[aarmor, RailBolts] = 0;
$ItemMax[darmor, RailBolts] = 0;
$ItemMax[nfemale, RailBolts] = 0;
$ItemMax[afemale, RailBolts] = 0;
$ItemMax[warmor, RailBolts] = 0;
$ItemMax[barmor, RailBolts] = 20;
$ItemMax[sarmor, RailBolts] = 500;
$ItemMax[avarmor, RailBolts] = 0;
$ItemMax[wfemale, RailBolts] = 0;
$ItemMax[bfemale, RailBolts] = 20;

$DamageScale[narmor, $RailDamageType] = 1.5;
$DamageScale[aarmor, $RailDamageType] = 1.9;
$DamageScale[darmor, $RailDamageType] = 1.3;
$DamageScale[warmor, $RailDamageType] = 1.5;
$DamageScale[barmor, $RailDamageType] = 1.5;
$DamageScale[sarmor, $RailDamageType] = 0.25;
$DamageScale[avarmor, $RailDamageType] = 1.2;
$DamageScale[nfemale, $RailDamageType] = 1.5;
$DamageScale[afemale, $RailDamageType] = 1.9;
$DamageScale[wfemale, $RailDamageType] = 1.5;
$DamageScale[bfemale, $RailDamageType] = 1.5;
$DamageScale[Fighter, $RailDamageType] = 1.5;
$DamageScale[Interceptor, $RailDamageType] = 1.5;
$DamageScale[Scout, $RailDamageType] = 1.5;
$DamageScale[LAPC, $RailDamageType] = 1.5;
$DamageScale[HAPC, $RailDamageType] = 1.5;
//--------------------------------------

ItemData RailBolts
{
	description = "Rail Bolts";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData RailgunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 1.0;

	ammoType = RailBolts;
	projectileType = Railbolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = true;
	hudIcon = "sniper";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 125;
	showWeaponBar = true;
};

function Railgun::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Railgun: <f2>Pop a shot into your enemys head from many meters away!");
}
