$InvList[ParticleBeamWeapon] = 1;
$MobileInvList[ParticleBeamWeapon] = 1;
$RemoteInvList[ParticleBeamWeapon] = 1;

$AutoUse[ParticleBeamWeapon] = False;
$WeaponAmmo[ParticleBeamWeapon] = "";

addWeapon(ParticleBeamWeapon);

//----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------

ItemImageData ParticleBeamWeaponImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
      mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 1.5, 0 }; 

	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = DeathRayLaser;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireLaser;
	sfxReady = SoundEnergyPackOn;
};

ItemData ParticleBeamWeapon
{
	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage;
	price = 4450;
	showWeaponBar = true;
};

function ParticleBeamWeapon::onMount(%player,%item)
{	

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Particle Beam Weapon: <f2>Mounted");
}




