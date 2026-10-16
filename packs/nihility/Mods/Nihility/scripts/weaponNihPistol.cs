//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Plasmaii);
$InvList[Plasmaii] = 1;
$InvList[MKIIAmmo] = 1;

$AutoUse[Plasmaii] = True;
$WeaponAmmo[Plasmaii] = MKIIAmmo;
$SellAmmo[PlasmaAmmo] = 5;

$WeaponAmmo[blasteri] = "";
$WeaponAmmo[blasterii] = "";
$WeaponAmmo[blasteriii] = "";

$ItemMax[larmor, Plasmaii] = 0;		//Seraph
$ItemMax[lfemale, Plasmaii] = 0;	//Seraph
$ItemMax[earmor, Plasmaii] = 0;		//Slave
$ItemMax[efemale, Plasmaii] = 0;	//Slave
$ItemMax[marmor, Plasmaii] = 0;		//Pawn
$ItemMax[aarmor, Plasmaii] = 0;		//Navigator
$ItemMax[darmor, Plasmaii] = 1;		//Atomizer
$ItemMax[barmor, Plasmaii] = 0;		//Paladin

$ItemMax[larmor, MKIIAmmo] = 0;		//Seraph
$ItemMax[lfemale, MKIIAmmo] = 0;	//Seraph
$ItemMax[earmor, MKIIAmmo] = 0;		//Slave
$ItemMax[efemale, MKIIAmmo] = 0;	//Slave
$ItemMax[marmor, MKIIAmmo] = 0;		//Pawn
$ItemMax[aarmor, MKIIAmmo] = 0;		//Navigator
$ItemMax[darmor, MKIIAmmo] = 5;		//Atomizer
$ItemMax[barmor, MKIIAmmo] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData MKIIAmmo
{
	description = "Nihility Cartridge";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
}; 



RocketData MKIIi
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1; 
   damageValue      = 0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 100;
   kickBackStrength = -1250.0;

   muzzleVelocity   = 17.0;
   terminalVelocity = 18.0;
   acceleration     = 0.0;

   totalTime        = 30.0;
   liveTime         = 29.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "fusionex.dts";
   	smokeDist = 1.0;
   soundId = SoundJetHeavy;

};

RocketData MKIIii
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = PlasmaExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1; 
   damageValue      = 3.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 45;
   kickBackStrength = 0.0;

   muzzleVelocity   = 17.0;
   terminalVelocity = 18.0;
   acceleration     = 0.0;

   totalTime        = 30.0;
   liveTime         = 29.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "plasmaex.dts";
   	smokeDist = 1.0;
   soundId = SoundJetHeavy;

};



ItemImageData blasteriImage
{
	shapeFile = "shotgun";//energygun
	mountPoint = 0;
	mountOffset = { -0.11, -0.05, -0.05 };  
	mountRotation = { 0, -2.0, 0 };

	weaponType = 0; // Single Shot
	//ammoType = MKIIAmmo;
	projectileType = breath;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

};

ItemImageData blasteriiImage
{
	shapeFile = "shotgun";//energygun
	mountPoint = 0;
	mountOffset = { 0.11, -0.05, -0.05 };
	mountRotation = { 0, 2.0, 0};

	weaponType = 0; // Single Shot
	//ammoType = MKIIAmmo;
	projectileType = breath;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

};

ItemImageData blasteriiiImage
{
	shapeFile = "shotgun";//shotgun
	mountPoint = 0;
	mountOffset = { 0, 0.05, 0.055 };
	mountRotation = { 0,  0, 3.1416};

	weaponType = 0; // Single Shot
	//ammoType = MKIIAmmo;
	projectileType = breath;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

};

	
ItemImageData PlasmaiiImage
{
	shapeFile = "shotgun";//plasma
	mountPoint = 0;
	mountOffset = { 0, -0.25, -0.065 };
	mountRotation = { 0,  3.1416, 0}; //3.1416
	
	weaponType = 0; // Single Shot
	ammoType = MKIIAmmo;
	//projectileType = breath;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 3.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;// FireMortar SoundMissileTurretFire
	sfxActivate = SoundPickUpWeapon;
	//sfxReady = SoundMortarIdle; 
	sfxReload = SoundDryFire;
};



ItemData blasteri
{
	description = "left hand blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = blasteriImage;
	price = 1;
	showWeaponBar = false;
	showinventory = false;
   validateShape = true;
};

ItemData blasterii
{
	description = "right hand blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = blasteriiImage;
	price = 1;
	showWeaponBar = false;
	showinventory = false;
   validateShape = true;
};

ItemData blasteriii
{
	description = "bottom blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = blasteriiiImage;
	price = 1;
	showWeaponBar = false;
	showinventory = false;
   validateShape = true;
};


ItemData Plasmaii
{
	description = "Nihility Pistol";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaiiImage;
	price = 777;
	showWeaponBar = true;
   	validateShape = true;
};

$PlasmaiiSlotA=4;
$PlasmaiiSlotB=7;
$PlasmaiiSlotC=6;

function Plasmaii::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Nihility Pistol");

	Player::mountItem(%player,blasteri,$PlasmaiiSlotA); 
	Player::mountItem(%player,blasterii,$PlasmaiiSlotB);
	Player::mountItem(%player,blasteriii,$PlasmaiiSlotC);

}

function Plasmaii::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$PlasmaiiSlotA); 
	Player::unmountItem(%player,$PlasmaiiSlotB); 
	Player::unmountItem(%player,$PlasmaiiSlotC); 
}



function PlasmaiiImage::onFire(%player,%slot) 
{	
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Plasmaii]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%smack = 10;
	if(%Ammo > 0)
	{
		//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));

		Player::decItemCount(%player,$WeaponAmmo[Plasmaii],1);
		Projectile::spawnProjectile("MKIIi",%trans,%player,%vel);
		Projectile::spawnProjectile("MKIIii",%trans,%player,%vel);
		WeaponKickBack(%player,%smack);
		//schedule("reload(" @ %player @ ");",5.5);

	}
	else
	{
		Client::sendMessage(Player::getClient(%player), 0,"The Nihility Pistol is out of ammo");
	}

}