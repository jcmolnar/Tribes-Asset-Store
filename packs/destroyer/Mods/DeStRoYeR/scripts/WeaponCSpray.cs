//--------------------------------------

$AutoUse[CSpray] = True;
$SellAmmo[Nitrogen] = 25;
$AmmoPackMax[Nitrogen] = 150;
$AmmoPackItems[8] = Nitrogen;
$WeaponAmmo[CSpray] = Nitrogen;

//--------------------------------------

$InvList[CSpray] = 1;
$InvList[Nitrogen] = 1;
$InvList[LNitroPack] = 1;
$RemoteInvList[CSpray] = 1;
$RemoteInvList[Nitrogen] = 1;
$RemoteInvList[LNitroPack] = 1;

$ItemMax[narmor, CSpray] = 0;
$ItemMax[aarmor, CSpray] = 1;
$ItemMax[darmor, CSpray] = 1;
$ItemMax[nfemale, CSpray] = 0;
$ItemMax[afemale, CSpray] = 1;
$ItemMax[warmor, CSpray] = 1;
$ItemMax[barmor, CSpray] = 1;
$ItemMax[sarmor, CSpray] = 1;
$ItemMax[avarmor, CSpray] = 1;
$ItemMax[wfemale, CSpray] = 1;
$ItemMax[bfemale, CSpray] = 1;

$ItemMax[narmor, LNitroPack] = 0;
$ItemMax[aarmor, LNitroPack] = 1;
$ItemMax[darmor, LNitroPack] = 1;
$ItemMax[nfemale, LNitroPack] = 0;
$ItemMax[afemale, LNitroPack] = 1;
$ItemMax[warmor, LNitroPack] = 1;
$ItemMax[barmor, LNitroPack] = 1;
$ItemMax[sarmor, LNitroPack] = 1;
$ItemMax[avarmor, LNitroPack] = 1;
$ItemMax[wfemale, LNitroPack] = 1;
$ItemMax[bfemale, LNitroPack] = 1;

$ItemMax[narmor, Nitrogen] = 0;
$ItemMax[aarmor, Nitrogen] = 100;
$ItemMax[darmor, Nitrogen] = 250;
$ItemMax[nfemale, Nitrogen] = 0;
$ItemMax[afemale, Nitrogen] = 100;
$ItemMax[warmor, Nitrogen] = 150;
$ItemMax[barmor, Nitrogen] = 200;
$ItemMax[sarmor, Nitrogen] = 500;
$ItemMax[avarmor, Nitrogen] = 250;
$ItemMax[wfemale, Nitrogen] = 150;
$ItemMax[bfemale, Nitrogen] = 200;

$DamageScale[narmor, $NitroDamageType] = 1.2;
$DamageScale[aarmor, $NitroDamageType] = 1.4;
$DamageScale[darmor, $NitroDamageType] = 0.5;
$DamageScale[warmor, $NitroDamageType] = 1.1;
$DamageScale[barmor, $NitroDamageType] = 1.0;
$DamageScale[avarmor, $NitroDamageType] = 0.8;
$DamageScale[nfemale, $NitroDamageType] = 1.2;
$DamageScale[afemale, $NitroDamageType] = 1.4;
$DamageScale[wfemale, $NitroDamageType] = 1.1;
$DamageScale[sarmor, $NitroDamageType] = 0.25;
$DamageScale[Scout, $NitroDamageType] = 1.5;
$DamageScale[Fighter, $NitroDamageType] = 1.5;
$DamageScale[Interceptor, $NitroDamageType] = 1.5;
$DamageScale[LAPC, $NitroDamageType] = 1.5;
$DamageScale[HAPC, $NitroDamageType] = 1.5;
//--------------------------------------

ItemData Nitrogen
{
	description = "Nitrogen";
	className = "Ammo";
	shapeFile = "plasammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData CSprayImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.3;

	ammoType = Nitrogen;
	projectileType = LiquidN;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData CSpray
{
	description = "Chemical Sprayer";
	className = "Weapon";
	shapeFile = "plasma";
   validateShape = true;
	hudIcon = "sniper";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = CSprayImage;
	price = 125;
	showWeaponBar = true;
};

function CSpray::onUse(%player,%item)
{
	if(Player::getItemCount(%player,LNitroPack) > 0)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Nitrogen Tank to use Chemical Sprayer.");
}

//--------------------------------------

ItemImageData LNitroPackImage
{
	shapeFile = "plasammo";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	firstPerson = false;
};

ItemData LNitroPack
{
	description = "Nitrogen Tank";
	shapeFile = "plasAmmo";
	className = "Backpack";
   	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = LNitroPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
  	validateShape = true;
  	validateMaterials = true;
};

function LNitroPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function LNitroPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function LNitroPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == CSpray)
		Player::unmountItem(%player,$WeaponSlot);
}
function CSpray::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Chemical Sprayer: <f2>Give your enemy a nice cold Liquid Nitrogen bath.");
}