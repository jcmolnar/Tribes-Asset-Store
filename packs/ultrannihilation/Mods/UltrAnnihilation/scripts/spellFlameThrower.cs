$InvList[SpellFlameThrower] = 1;
$MobileInvList[SpellFlameThrower] = 1;
$RemoteInvList[SpellFlameThrower] = 1;

$AutoUse[SpellFlameThrower] = False;
$WeaponAmmo[SpellFlameThrower] = "";

addWeapon(SpellFlameThrower);

ItemImageData SpellFlameThrowerImage 
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = SpellFlameThrowerGren;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SpellFlameThrower 
{
	description = "Spell: Flame Thrower";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "plasmabolt";
	heading = $InvHead[ihSpl];
	shadowDetailMask = 4;
	imageType = SpellFlameThrowerImage;
	price = 175;
	showWeaponBar = true;
};

function SpellFlameThrower::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Flame Thrower: <f2>Hurls fiery death.");
}
