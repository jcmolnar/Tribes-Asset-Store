$InvList[DisarmerSpell] = 1;
$MobileInvList[DisarmerSpell] = 1;
$RemoteInvList[DisarmerSpell] = 1;

$AutoUse[DisarmerSpell] = True;
$WeaponAmmo[DisarmerSpell] = "";

addWeapon(DisarmerSpell);

ItemImageData DisarmerSpellImage
{	shapeFile = "mortartrail";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 1.5;
	fireTime = 0.3;
	minEnergy = 10;
	maxEnergy = 20;
	projectileType = DisarmBolt;
	accuFire = true;
	sfxFire = SoundParticleBeamRecharge;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DisarmerSpell 
{	heading = $InvHead[ihSpl];
	description = "Spell: Disarm";
	className = "Weapon";
	shapeFile = "mortartrail";
	hudIcon = "mortartrail";
	shadowDetailMask = 4;
	imageType = DisarmerSpellImage;
	price = 250;
	showWeaponBar = true;
};

function DisarmerSpell::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Disarmer Spell: <f2>This spell disarms all caught in its blast.");
}