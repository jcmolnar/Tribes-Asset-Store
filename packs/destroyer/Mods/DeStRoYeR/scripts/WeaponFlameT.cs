//--------------------------------------

$AutoUse[FlameT] = True;
$SellAmmo[Fuel] = 25;
$AmmoPackMax[Fuel] = 150;
$AmmoPackItems[9] = Fuel;
$WeaponAmmo[FlameT] = Fuel;

//--------------------------------------

$InvList[FlameT] = 1;
$InvList[Fuel] = 1;
$InvList[FuelPack] = 1;
$RemoteInvList[FlameT] = 1;
$RemoteInvList[Fuel] = 1;
$RemoteInvList[FuelPack] = 1;

$ItemMax[narmor, FlameT] = 0;
$ItemMax[aarmor, FlameT] = 1;
$ItemMax[darmor, FlameT] = 1;
$ItemMax[nfemale, FlameT] = 0;
$ItemMax[afemale, FlameT] = 1;
$ItemMax[warmor, FlameT] = 1;
$ItemMax[barmor, FlameT] = 1;
$ItemMax[sarmor, FlameT] = 1;
$ItemMax[avarmor, FlameT] = 1;
$ItemMax[wfemale, FlameT] = 1;
$ItemMax[bfemale, FlameT] = 1;

$ItemMax[narmor, FuelPack] = 0;
$ItemMax[aarmor, FuelPack] = 1;
$ItemMax[darmor, FuelPack] = 1;
$ItemMax[nfemale, FuelPack] = 0;
$ItemMax[afemale, FuelPack] = 1;
$ItemMax[warmor, FuelPack] = 1;
$ItemMax[barmor, FuelPack] = 1;
$ItemMax[sarmor, FuelPack] = 1;
$ItemMax[avarmor, FuelPack] = 1;
$ItemMax[wfemale, FuelPack] = 1;
$ItemMax[bfemale, FuelPack] = 1;

$ItemMax[narmor, Fuel] = 0;
$ItemMax[aarmor, Fuel] = 100;
$ItemMax[darmor, Fuel] = 300;
$ItemMax[nfemale, Fuel] = 0;
$ItemMax[afemale, Fuel] = 100;
$ItemMax[warmor, Fuel] = 150;
$ItemMax[barmor, Fuel] = 200;
$ItemMax[sarmor, Fuel] = 500;
$ItemMax[avarmor, Fuel] = 250;
$ItemMax[wfemale, Fuel] = 150;
$ItemMax[bfemale, Fuel] = 200;

$DamageScale[narmor, $FlameDamageType] = 1.0;
$DamageScale[aarmor, $FlameDamageType] = 1.2;
$DamageScale[darmor, $FlameDamageType] = 0.7;
$DamageScale[warmor, $FlameDamageType] = 1.1;
$DamageScale[barmor, $FlameDamageType] = 1.0;
$DamageScale[sarmor, $FlameDamageType] = 0.25;
$DamageScale[avarmor, $FlameDamageType] = 0.8;
$DamageScale[nfemale, $FlameDamageType] = 1.2;
$DamageScale[afemale, $FlameDamageType] = 1.0;
$DamageScale[wfemale, $FlameDamageType] = 1.1;
$DamageScale[bfemale, $FlameDamageType] = 1.0;
$DamageScale[Fighter, $FlameDamageType] = 1.5;
$DamageScale[Interceptor, $FlameDamageType] = 1.5;
$DamageScale[Scout, $FlameDamageType] = 1.5;
$DamageScale[LAPC, $FlameDamageType] = 1.5;
$DamageScale[HAPC, $FlameDamageType] = 1.5;
//--------------------------------------

ItemData Fuel
{
	description = "Fuel";
	className = "Ammo";
	shapeFile = "plasammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData FlameTImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	mountRotation = { 0, 1.57, 0 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.3;

	ammoType = Fuel;
	projectileType = Flame;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlameT
{
	description = "Flame Thrower";
	className = "Weapon";
	shapeFile = "plasma";
   validateShape = true;
	hudIcon = "sniper";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = FlameTImage;
	price = 125;
	showWeaponBar = true;
};

function FlameT::onUse(%player,%item)
{
	if(Player::getItemCount(%player,FuelPack) > 0)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Fuel Tank to use Flame Thrower.");
}

//--------------------------------------

ItemImageData FuelPackImage
{
	shapeFile = "plasammo";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	firstPerson = false;
};

ItemData FuelPack
{
	description = "Fuel Tank";
	shapeFile = "plasammo";
	className = "Backpack";
   	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = FuelPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
  	validateShape = true;
  	validateMaterials = true;
};

function FuelPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FuelPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FuelPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == FlameT)
		Player::unmountItem(%player,$WeaponSlot);
}
function FlameT::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Flame Thrower: <f2>Melt Your enemys with this weapon.");
}