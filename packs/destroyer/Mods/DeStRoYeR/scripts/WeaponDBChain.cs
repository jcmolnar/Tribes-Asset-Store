$AutoUse[DBChain] = True;
$SellAmmo[DBChainAmmo] = 50;
$AmmoPackMax[DBChainAmmo] = 200;
$AmmoPackItems[10] = DBChainAmmo;
$WeaponAmmo[DBChain] = DBChainAmmo;
$InvList[DBChain] = 1;
$RemoteInvList[DBChain] = 1;

$ItemMax[narmor, DBChain] = 0;
$ItemMax[aarmor, DBChain] = 0;
$ItemMax[darmor, DBChain] = 1;
$ItemMax[nfemale, DBChain] = 0;
$ItemMax[afemale, DBChain] = 0;
$ItemMax[warmor, DBChain] = 0;
$ItemMax[barmor, DBChain] = 0;
$ItemMax[sarmor, DBChain] = 1;
$ItemMax[avarmor, DBChain] = 0;
$ItemMax[wfemale, DBChain] = 0;
$ItemMax[bfemale, DBChain] = 0;

$ItemMax[narmor, DBChainAmmo] = 0;
$ItemMax[aarmor, DBChainAmmo] = 0;
$ItemMax[darmor, DBChainAmmo] = 500;
$ItemMax[nfemale, DBChainAmmo] = 0;
$ItemMax[afemale, DBChainAmmo] = 0;
$ItemMax[warmor, DBChainAmmo] = 0;
$ItemMax[barmor, DBChainAmmo] = 0;
$ItemMax[sarmor, DBChainAmmo] = 500;
$ItemMax[avarmor, DBChainAmmo] = 0;
$ItemMax[wfemale, DBChainAmmo] = 0;
$ItemMax[bfemale, DBChainAmmo] = 0;

$DBChainSlotA=4;
$DBChainSlotB=7;

ItemData DBChainAmmo
{
	description = "Fletchets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DBChainImage
{
	shapeFile = "Breath";
	mountPoint = 0;
	mountOffset = {-0.575, -0.5, 0.2};
	mountRotation = {0, 0, 0};

	weaponType = 1;
	ammoType = DBChainAmmo;
	accuFire = False;
	SpinUpTime = 0.5;
	SpinDownTime = 2;
	reloadTime = 0;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;

};

ItemData DBChain
{
	description = "Double Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	validateShape = true;
	hudIcon = "chain";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = DBChainImage;
	price = 300;
	showWeaponBar = true;
};
ItemImageData DBChain2Image
{
	shapeFile = "Chaingun";
	mountPoint = 0;
	mountOffset = {0, 0, 0};
	mountRotation = {0, 0, 0};

	weaponType = 1;
	ammoType = DBChainAmmo;
	accuFire = False;
	SpinUpTime = 0.5;
	SpinDownTime = 2;
	reloadTime = 0;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;

};

ItemData DBChain2
{
	description = "Double Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	validateShape = true;
	hudIcon = "chain";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = DBChain2Image;
	price = 300;
	showWeaponBar = true;
};
ItemImageData DBChain3Image
{
	shapeFile = "Chaingun";
	mountPoint = 0;
	mountOffset = {-1.15, 0, 0};
	mountRotation = {0, 0, 0};

	weaponType = 1; // Single Shot
	ammoType = DBChainAmmo;
	accuFire = False;
	SpinUpTime = 0.5;
	SpinDownTime = 2;
	reloadTime = 0;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;

};

ItemData DBChain3
{
	description = "Double Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	validateShape = true;
	hudIcon = "chain";
	heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = DBChain3Image;
	price = 300;
	showWeaponBar = true;
};
function MDCheckDBChain(%client, %player)
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "DBChain"))
	{	Player::trigger(%player,$DBChainSlot,true);
		schedule("MDCheckDBChain(" @ %client @ "," @ %player @ ");",0.05);
		$MDFiringDBChain[%client] = true;
	}
	else
	{	Player::trigger(%player,$DBChainSlot,false);
		$MDFiringDBChain[%client] = false;
	}
}
function MDCheckDBChain(%client, %player)
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "DBChain"))
	{	Player::trigger(%player,$DBChainSlotA,true);
		Player::trigger(%player,$DBChainSlotB,true);
		schedule("MDCheckDBChain(" @ %client @ "," @ %player @ ");",0.1);
		$MDFiringDBChain[%client] = true;
	}
	else
	{	Player::trigger(%player,$DBChainSlotA,false);
		Player::trigger(%player,$DBChainSlotB,false);
		$MDFiringDBChain[%client] = false;
	}
}
function DBChainImage::onFire(%player, %slot)
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,DBChainAmmo,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel,%player);
	if(!$MDFiringDBChain[%client])
		MDCheckDBChain(%client, %player);
}
function DBChain::onDrop(%player,%item)
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
	{	Player::setItemCount(%player, DBChain2, 0);
		Player::setItemCount(%player, DBChain3, 0);
		Item::onDrop(%player,%item);
	}
}
function DBChain::onFire(%player)
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,DBChainAmmo,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
}
function DBChain::onMount(%player,%item)
{	Player::mountItem(%player,DBChain2,$DBChainSlotA);
	Player::mountItem(%player,DBChain3,$DBChainSlotB);
	%client = Player::getClient(%player);
	Bottomprint(%client, "Double Chaingun: <f2>Two chainguns mounted on your mechs arms.");
}
function DBChain::onUnmount(%player,%imageSlot)
{	Player::unmountItem(%player,$DBChainSlotA);
	Player::unmountItem(%player,$DBChainSlotB);
}