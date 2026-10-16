$InvList[JailGun] = 1;
$MobileInvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;

$AutoUse[JailGun] = false;
$WeaponAmmo[JailGun] = "";

addWeapon(JailGun);

ItemImageData JailGunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 0;
	minEnergy = 5;
	maxEnergy = 80;
	reloadTime = 0.5;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 25;
	lightTime = 1.5;
	lightColor = { -1.0, -1.0, 1.0 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireLaser;
};

ItemData JailGun
{
	heading = $InvHead[ihWea];
	description = "SpotterLaser";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "energyrifle";
	hadowDetailMask = 4;
	imageType = JailGunImage;
	price = 150;
	showWeaponBar = true;
};

function Jailgun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Spotter Laser: Cluster Missile Part 1: <f2>Once a Destroyer shoots a missile, you can spot a target location for the missile with this laser. Max spotting range: 120 meters.");
}

staticshapedata DummyTarget
{
	damageSkinData = "objectDamageSkins";
	shapeFile = "Paint";
	maxDamage = 20.0;
	maxEnergy = 5;
	mapFilter = 2;
	visibleToSensor = false;
	explosionId = nullExp;
	debrisId = flashDebrisSmall;
	lightRadius = 6.0;
	lightType = 2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	description = "Targeted Location";
};

//this turret exists solely for the purpose of getting me the muzzletrans for the projectile spawning.
TurretData DummyAimer
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = PrettySplit;
	maxDamage = 20;
	maxEnergy = 1;
	minGunEnergy = 1.0;
	maxGunEnergy = 1.0;
	reloadDelay = 1;
	speed = 4.0;
	speedModifier = 1.5;
	range = 1;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPickUpBackpack;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Cluster Missile";
	damageSkinData = "objectDamageSkins";
};
//this turret should have ZERO functionality.
function DummyAimer::onAdd(%this) {}
function DummyAimer::deploy(%this) {}
function DummyAimer::onEndSequence(%this,%thread) {}
function DummyAimer::onDestroyed(%this) {}
function DummyAimer::onPower(%this,%power,%generator) {}
function DummyAimer::onEnabled(%this) {}
function DummyAimer::onDestroyed(%this) {}

function JailgunImage::onFire(%player, %slot)
{
//purely visual.
	%trans = gamebase::getmuzzletransform(%player);
	%vel = item::getvelocity(%player);
	Projectile::spawnProjectile("SpottingLaser", %trans, %player, %vel);
//now for the spotting elf. The rest of the function, the default LOS, will not run if TargetingPerson was set to a number due to a target being found.
	%player.TargetingPerson = 0;
	%player.CrowRailGunShooting = true;
	%obj = Projectile::spawnProjectile("ClusterMissileLockon",%trans,%player,%vel);
	schedule("deleteobject("@%obj@");",0.1);
	schedule("FireClusters("@%player@");", 0.1);
}

function ClusterMissileLockOn::damageTarget(%targetPl, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterPl)
{
//Tricky! %shooterpl is actually the CLIENT, even though %targetPl is the player.. thank you, dynamix..
//set things right
	%shooterPl = client::getownedobject(%shooterpl);
//I'll use the railgunshooting because you can't use railgun and clustermissiles at the same time, so this will work and will  save a couple resources
	if(%shooterPl.CrowRailGunShooting == false)
		return;
	%shooterPl.CrowRailGunShooting = false;
//now let the fireclusters function know the new target
	%shooterpl.TargetingPerson = %targetpl;
}

function FireClusters(%player)
{
//there are two possibilities: spotting an object and spotting a location.
%targetme = 0;
	if(%player.TargetingPerson > 0)
		%targetme = %player.targetingperson;
	else{
		if(!GameBase::getLOSInfo(%player, 120))
		{
			if($CrowNumMissiles > 0)
			{
				%client = Player::getclient(%player);
				client::sendmessage(%client, 0, "Targeted location too far away for a lock.");
			}
			return;
		}
		else{
//have to make a dummy object specifically to target in this case
			%targetme = newobject("DummyTarget", "StaticShape", DummyTarget, true);
			gamebase::setposition(%targetme, $los::position);
			schedule("deleteobject("@%targetme@");", 5);
		}
	}
//ok, now that it knows what to target, it must identify the missiles that will shoot, then actually shoot them.
for(%i = $CrowNumMissiles - 1; %i >= 0; %i--)
{
	%trans = gamebase::gettransform($CrowMissileArray[%i]);
	%rot = gamebase::getrotation($CrowMissileArray[%i]);
	%vel = item::getvelocity($CrowMissileArray[%i]);
	%pos = gamebase::getposition($CrowMissileArray[%i]);
	%DeleteThis = false;
	if($CrowMissileArray[%i].IsClusterMissile && gamebase::getteam($CrowOwnerArray[%i]) == gamebase::getteam(%player))//%trans != "0 0 0 0 0 0")
	{
//five missiles, all locked on to the target. Sprayed horizontal each direction, vertical each direction, random speeds of each missile except for first.
		%xrot = getword(%rot, 0);
		%yrot = getword(%rot, 1);
		%yrot = %yrot + getrandom() * 0.785; //randomize: can be an X or a + or anywhere between
		%zrot = getword(%rot, 2);
		%UpRot = ""@%xrot + 0.515@" "@%yrot@" "@%zrot;
		%DownRot = ""@%xrot - 0.515@" "@%yrot@" "@%zrot;
		%LeftRot = ""@%xrot@" "@%yrot@" "@%zrot + 0.515;
		%RightRot = ""@%xrot@" "@%yrot@" "@%zrot - 0.515;
//now that I have my directions, I need muzzletrans.  For that, I make a turret, and point it where I want my muzzletrans.
		%turret = newObject("camera", "Turret", DummyAimer, true);
		gamebase::setposition(%turret, %pos);

		gamebase::setrotation(%turret, %rot);
		%muzzletrans = gamebase::getmuzzletransform(%turret);
		gamebase::setrotation(%turret, %Uprot);
		%Upmuzzletrans = gamebase::getmuzzletransform(%turret);
		gamebase::setrotation(%turret, %Downrot);
		%Downmuzzletrans = gamebase::getmuzzletransform(%turret);
		gamebase::setrotation(%turret, %Leftrot);
		%Leftmuzzletrans = gamebase::getmuzzletransform(%turret);
		gamebase::setrotation(%turret, %Rightrot);
		%Rightmuzzletrans = gamebase::getmuzzletransform(%turret);

//going straight
		%obj = projectile::spawnprojectile("ClusterFast", %muzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		gamebase::setposition(%obj, %pos);
		gamebase::setrotation(%obj, %rot);
//going up
		%speed = floor(getrandom() * 3);
		if(%speed == 0) %obj = projectile::spawnprojectile("ClusterFast", %Upmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else if(%speed == 1) %obj = projectile::spawnprojectile("ClusterMedium", %Upmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else %obj = projectile::spawnprojectile("ClusterSlow", %Upmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
//going down
		%speed = floor(getrandom() * 3);
		if(%speed == 0) %obj = projectile::spawnprojectile("ClusterFast", %Downmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else if(%speed == 1) %obj = projectile::spawnprojectile("ClusterMedium", %Downmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else %obj = projectile::spawnprojectile("ClusterSlow", %Downmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
//going left
		%speed = floor(getrandom() * 3);
		if(%speed == 0) %obj = projectile::spawnprojectile("ClusterFast", %Leftmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else if(%speed == 1) %obj = projectile::spawnprojectile("ClusterMedium", %Leftmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else %obj = projectile::spawnprojectile("ClusterSlow", %Leftmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
//going right
		%speed = floor(getrandom() * 3);
		if(%speed == 0) %obj = projectile::spawnprojectile("ClusterFast", %Rightmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else if(%speed == 1) %obj = projectile::spawnprojectile("ClusterMedium", %Rightmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);
		else %obj = projectile::spawnprojectile("ClusterSlow", %Rightmuzzletrans, $CrowOwnerArray[%i], %vel, %targetme);

		%DeleteThis = true;
		deleteobject($CrowMissileArray[%i]);
		deleteobject(%turret);
	}
	if(%trans == "0 0 0 0 0 0")
		%DeleteThis = true;
	if(%DeleteThis)
	{
//shrink the array
		$CrowNumMissiles--;
		for(%j = %i; %j < $CrowNumMissiles; %j++)
		{
			$CrowMissileArray[%j] = $CrowMissileArray[%j + 1];
			$CrowOwnerArray[%j] = $CrowOwnerArray[%j + 1];
		}
	}
}
}