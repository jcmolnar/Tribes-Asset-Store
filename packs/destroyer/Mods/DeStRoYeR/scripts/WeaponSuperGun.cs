//--------------------------------------

$AutoUse[SuperGun] = True;
$WeaponAmmo[SuperGun] = "";

//--------------------------------------

$InvList[SuperGun] = 0;
$RemoteInvList[SuperGun] = 0;

$ItemMax[narmor, SuperGun] = 0;
$ItemMax[aarmor, SuperGun] = 0;
$ItemMax[darmor, SuperGun] = 0;
$ItemMax[nfemale, SuperGun] = 0;
$ItemMax[afemale, SuperGun] = 0;
$ItemMax[warmor, SuperGun] = 0;
$ItemMax[barmor, SuperGun] = 0;
$ItemMax[avarmor, SuperGun] = 0;
$ItemMax[wfemale, SuperGun] = 0;
$ItemMax[bfemale, SuperGun] = 0;

$DamageScale[narmor, $SuperDamageType] = 2.0;
$DamageScale[aarmor, $SuperDamageType] = 2.0;
$DamageScale[darmor, $SuperDamageType] = 2.0;
$DamageScale[warmor, $SuperDamageType] = 2.0;
$DamageScale[barmor, $SuperDamageType] = 2.0;
$DamageScale[sarmor, $SuperDamageType] = 0.5;
$DamageScale[avarmor, $SuperDamageType] = 2.0;
$DamageScale[nfemale, $SuperDamageType] = 2.0;
$DamageScale[afemale, $SuperDamageType] = 2.0;
$DamageScale[wfemale, $SuperDamageType] = 2.0;
$DamageScale[bfemale, $SuperDamageType] = 2.0;
$DamageScale[Fighter, $SuperDamageType] = 2.0;
$DamageScale[Interceptor, $SuperDamageType] = 2.0;
$DamageScale[Scout, $SuperDamageType] = 2.0;
$DamageScale[LAPC, $SuperDamageType] = 2.0;
$DamageScale[HAPC, $SuperDamageType] = 2.0;
//--------------------------------------

ItemImageData SuperGunImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.4;

	projectileType = SuperBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SuperGun
{
	description = "Super Gun!!";
	className = "Weapon";
	shapeFile = "mortar";
   validateShape = true;
	hudIcon = "mortar";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = SuperGunImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function SuperGun::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Super Gun: <f2>A deadly Super gun you won gambling.");
}