$InvList[ParticleBeamWeapon] = 1;
$MobileInvList[ParticleBeamWeapon] = 1;
$RemoteInvList[ParticleBeamWeapon] = 1;

$AutoUse[ParticleBeamWeapon] = True;

addweapon(ParticleBeamWeapon);

ItemImageData ParticleBeamWeaponImage 
{	shapeFile = "grenammo";
	mountPoint = 0;
	weaponType = 0; 
	minEnergy = 70;
	maxEnergy = 120;
        projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	sfxFire = SoundParticleBeamFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundParticleBeamRecharge;
};

ItemData ParticleBeamWeapon
{	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "grenammo";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage;
	price = 2500;
	showWeaponBar = true;
};

function ParticleBeamWeapon::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Particle Beam: <f2>An super accelerated particle weapon.");
}