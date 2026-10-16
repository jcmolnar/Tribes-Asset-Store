//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(PlasmaGun);
$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;

$SellAmmo[PlasmaAmmo] = 10;
$AutoUse[PlasmaGun] = True;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

$ItemMax[larmor, PlasmaGun] = 1;	//Seraph
$ItemMax[lfemale, PlasmaGun] = 1;	//Seraph
$ItemMax[earmor, PlasmaGun] = 1;	//Slave
$ItemMax[efemale, PlasmaGun] = 1;	//Slave
$ItemMax[marmor, PlasmaGun] = 1;	//Pawn
$ItemMax[aarmor, PlasmaGun] = 0;	//Navigator
$ItemMax[darmor, PlasmaGun] = 0;	//Atomizer
$ItemMax[barmor, PlasmaGun] = 1;	//Paladin

$ItemMax[larmor, PlasmaAmmo] = 30;	//Seraph
$ItemMax[lfemale, PlasmaAmmo] = 30;	//Seraph
$ItemMax[earmor, PlasmaAmmo] = 35;	//Slave
$ItemMax[efemale, PlasmaAmmo] = 35;	//Slave
$ItemMax[marmor, PlasmaAmmo] = 40;	//Pawn
$ItemMax[aarmor, PlasmaAmmo] = 0;	//Navigator
$ItemMax[darmor, PlasmaAmmo] = 0;	//Atomizer
$ItemMax[barmor, PlasmaAmmo] = 35;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData PlasmaGunImage 
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmaAmmo;
	//projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.08;
	fireTime = 0.3;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
}; 

ItemData PlasmaGun 
{
	description = "Plasma Blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 77;
	showWeaponBar = true;
};

function PlasmaGunImage::onFire(%player,%slot) 
{	
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	//%smack = 10;
	if(%Ammo > 0)
	{
		//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));

		Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
		Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
		Projectile::spawnProjectile("PlasmaBolt2",%trans,%player,%vel);
		//WeaponKickBack(%player,%smack);
		//schedule("reload(" @ %player @ ");",5.5);

	}
	else
	{
		Client::sendMessage(Player::getClient(%player), 0,"The Plasma Blaster is out of ammo");
	}

}


function PlasmaGun::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Plasma Blaster", 2); }
