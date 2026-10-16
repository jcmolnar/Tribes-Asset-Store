//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(EnergyRifle);
$InvList[EnergyRifle] = 1;

$AutoUse[EnergyRifle] = True;
$WeaponAmmo[EnergyRifle] = "";

$ItemMax[larmor, EnergyRifle] = 0;	//Seraph
$ItemMax[lfemale, EnergyRifle] = 0;	//Seraph
$ItemMax[earmor, EnergyRifle] = 0;	//Slave
$ItemMax[efemale, EnergyRifle] = 0;	//Slave
$ItemMax[marmor, EnergyRifle] = 0;	//Pawn
$ItemMax[aarmor, EnergyRifle] = 0;	//Navigator
$ItemMax[darmor, EnergyRifle] = 0;	//Atomizer
$ItemMax[barmor, EnergyRifle] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

BulletData OmegaBolt 
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 2.0;
	damageType = $ElectricityDamageType;
	aimDeflection = 0.035;
	muzzleVelocity = 30.0;
	totalTime = 0.35;
	liveTime = 0.35;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	soundId = SoundJetLight;
}; 

//-------------

ItemImageData EnergyRifleImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, -0.065};
	weaponType = 0;
	reloadTime = 0.05;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = OmegaBolt;
	accuFire = false;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData EnergyRifleRImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountRotation = { 0, 1.57, 3.1416 };
	mountOffset = { 0.08, 0.3, -0.085};
	weaponType = 0;
	reloadTime = 0.05;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = OmegaBolt;
	accuFire = false;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData EnergyRifleLImage 
{
	shapeFile = "paintgun"; mountPoint = 0;
	mountRotation = { 0, -1.57, 3.1416 };
	mountOffset = { -0.08, 0.3, -0.085};
	weaponType = 0;
	reloadTime = 0.05;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = OmegaBolt;
	accuFire = false;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData PaintRImage 
{
	shapeFile = "paintgun"; mountPoint = 0;
	mountRotation = { 0, 3.1416, 3.1416 };
	mountOffset = { 0, 0.3
	, 0.045};
	weaponType = 0;
	reloadTime = 0.05;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = OmegaBolt;
	accuFire = false;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
}; 


ItemData EnergyRifle
{
	heading = "bWeapons";
	description = "Anti-Blastwall Torch";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	price = 777;
	showWeaponBar = true;
}; 

ItemData EnergyRifleR
{
	heading = "bWeapons";
	description = "Anti-Blastwall Torch";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = EnergyRifleRImage;
	price = 1;
	showWeaponBar = false;
	showInventory = false;
}; 

ItemData EnergyRifleL
{
	heading = "bWeapons";
	description = "Anti-Blastwall Torch";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = EnergyRifleLImage;
	price = 1;
	showWeaponBar = false;
	showInventory = false;
}; 


ItemData PaintR
{
	heading = "bWeapons";
	description = "Anti-Blastwall Torch";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PaintRImage;
	price = 1;
	showWeaponBar = false;
	showInventory = false;
}; 

$EnergyRifleSlotA=4;
$EnergyRifleSlotB=7;
$EnergyRifleSlotC=6;



function EnergyRifle::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Anti-Blastwall Torch");
	Player::mountItem(%player,EnergyRifleR,$EnergyRifleSlotA); 
	Player::mountItem(%player,EnergyRifleL,$EnergyRifleSlotB);
	Player::mountItem(%player,PaintR,$EnergyRifleSlotC); 
}

function EnergyRifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$EnergyRifleSlotA); 
	Player::unmountItem(%player,$EnergyRifleSlotB);
	Player::unmountItem(%player,$EnergyRifleSlotC); 
}