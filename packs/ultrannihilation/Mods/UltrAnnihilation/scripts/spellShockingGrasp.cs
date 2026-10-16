$InvList[ShockingGrasp] = 1;
$MobileInvList[ShockingGrasp] = 1;
$RemoteInvList[ShockingGrasp] = 1;

$AutoUse[ShockingGrasp] = False;
$WeaponAmmo[ShockingGrasp] = "";

addWeapon(ShockingGrasp);

ItemImageData ShockingGraspImage
{
	shapeFile = "mrtwig";
	mountPoint = 2;
	mountOffset = { 0.2, 0.4, 0.0 };
	mountRotation = { -1.5, 0, 0 };
	weaponType = 2; // Sustained
	projectileType = ShockingGraspBolt;
	minEnergy = 1;
	maxEnergy = 8; // Energy used/sec for sustained weapons
	reloadTime = 0.2;
	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxReady = SoundJammerOn;
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};

ItemData ShockingGrasp
{
	className = "Weapon";
	description = "Spell: Shocking Grasp";
	heading = $InvHead[ihSpl];
	hudIcon = "mrtwig";
	imageType = ShockingGraspImage;
	price = 350;
	shadowDetailMask = 4;
	shapeFile = "mrtwig";
	showWeaponBar = true;
};

function ShockingGrasp::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Shocking Grasp: <f2>This spell drains a target's energy while inflicting electrical damage rendering shields, jetpacks, and energy weapons useless.");
}
