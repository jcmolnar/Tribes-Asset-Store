//--------------------------------------

SeekingMissileData SpecialFollow
{
	bulletShapeName = "mortar.dts";
	explosionTag    = ShieldExp;
	collisionRadius = 0.0;
	mass            = 2.0;

	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 1.5;
	damageType       = $GuardDamageType;
	explosionRadius  = 9.5;
	kickBackStrength = 75.0;

	muzzleVelocity          = 500.0;
	totalTime               = 100;
	liveTime                = 100;
	seekingTurningRadius    = 2.0;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 5.5;
	smokeDist               = 3;

	lightRange       = 5.0;
	lightColor       = { 0.4, 0.4, 1.0 };

	inheritedVelocityScale = 0.01;

	soundId = SoundJetHeavy;
};

SeekingMissileData GuardFollow
{
	bulletShapeName = "mortar.dts";
	explosionTag    = ShieldExp;
	collisionRadius = 0.0;
	mass            = 2.0;

	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 1.0;
	damageType       = $GuardDamageType;
	explosionRadius  = 1.0;
	kickBackStrength = 75.0;

	muzzleVelocity          = 25.0;
	totalTime               = 100;
	liveTime                = 100;
	seekingTurningRadius    = 2.0;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 5.5;
	smokeDist               = 1;

	lightRange       = 5.0;
	lightColor       = { 0.4, 0.4, 1.0 };

	inheritedVelocityScale = 0.01;

	soundId = SoundJetHeavy;
};

//--------------------------------------

ItemData RAmmo
{
	description = "Raptor Shells";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData R1Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
//	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
//	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData R1
{
	description = "Raptor Part";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = R1Image;
	showWeaponBar = false;
};

ItemImageData RImage
{
	shapeFile = "disc";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 1.7;
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData R
{
	description = "Raptor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "reticle";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = RImage;
	price = 175;
	showWeaponBar = true;
};

//--------------------------------------//
//------------FUNCTION-STUFF------------//
//--------------------------------------//

function R::onMount(%player,%item)
{
	Player::mountItem(%player,R1,7);
}

function R::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function RImage::onFire(%player, %slot) 
{  
	%client = Player::getClient(%player);
	%AmmoCount = Player::getItemCount(%player,RAmmo);
	if(%AmmoCount > 0) {
		if(GameBase::getLOSInfo(%player,2000)) {
			echo(getObjectType($los::object));
			if($los::position == getBoxCenter($los::object))
				R::LockedOn(%player,$los::object,"<jc><f2>Special Lock: Direct Lock Acquired");
			else if(getObjectType($los::object) == "Player") {
				if(GetTeam($los::object,%player) != Same)
					R::LockedOn(%player,$los::object);
				else
					bottomprint(%client,"<jc><f5>Error Tracking... Wrong Team", 2);
			}			
			else if(getObjectType($los::object) == "Flier") {
				%LastPilot = $los::object.clLastMount;
				if(GetTeam(%LastPilot,%player) != Same && GetTeam(%LastPilot,%player) != You)
					R::LockedOn(%player,$los::object);
				else if(GetTeam(%LastPilot,%player) == You)
					bottomprint(%client,"<jc><f5>Error Tracking... Your Vehicle", 2);
				else
					bottomprint(%client,"<jc><f5>Error Tracking... Wrong Team", 2);
			}
			else if(getObjectType($los::object) == "SeekingRocket" || getObjectType($los::object) == "RocketDumb") {
				if(GameBase::getDataName($los::object) == "GuardFollow") {
					if(GetTeam($Shooter[$los::object],%player) != Same && GetTeam($Shooter[$los::object],%player) != You)
						R::LockedOn(%player,$los::object,"<jc><f2>Special Lock: Counter-Measures Acquired");
					else if(GetTeam($Shooter[$los::object],%player) == You)
						bottomprint(%client,"Error Tracking... Your Rocket", 2);
				}
				else
					R::LockedOn(%player,$los::object,"<jc><f2>Special Lock: Counter-Measures Acquired");
			}
			else
				bottomprint(%client,"<jc><f5>Could Not Acquire Lock", 2);
		}
		else
			bottomprint(%client,"<jc><f5>Could Not Acquire Lock", 2);
	}
	else
		bottomprint(%client,"<jc><f5>Out of Ammo", 2);
}

function R::LockedOn(%player,%object,%special)
{
	%client = Player::getClient(%player);
	%LockOnMSG = "<jc><f2>Lock Acquired";
	if(%special)
		%LockOnMSG = %special;
	bottomprint(%client,%LockOnMSG,2);
	//- You get a Perfect-Lock you deserve this sorta praise and this many points...
	if(%special == "<jc><f2>Special Lock: Direct Lock Acquired") {
		%UltraName = Client::getName(%Client);
		%proj = Projectile::spawnProjectile("SpecialFollow",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player),%object);
		messageAll(0,"Everyone give it up for "@%UltraName@", for pulling a Perfect LockOn!~explo3.wav");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if(%cl != %client) {
				%cl.bodytemp = Client::getOwnedObject(%cl);
				Client::setOwnedObject(%cl,-1);
				Client::setControlObject(%cl, Client::getObserverCamera(%cl));
				Observer::setOrbitObject(%cl, %player, 5, 5, 5);
				%cl.observerMode = "dead";
				schedule("R::SpecialLockBodyBack("@%cl@");",2.0);
			}
		}
		%client.score+=500;
	}
	else
		%proj = Projectile::spawnProjectile("GuardFollow",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player),%object);
	WarnLock(%object);
	$Shooter[%proj] = %player;
	$Target[%proj]  = %object;
}

function R::SpecialLockBodyBack(%cl)
{
	echo("Giving "@%cl@" back their body");
	%cl.guiLock = "";
	%cl.dead = "";
	Client::setOwnedObject(%cl,%cl.bodytemp);
}

//-------------------------------------//
//-----------INVENTORY-STUFF-----------//
//-------------------------------------//

	$InvList[R] = 1;
	$InvList[RAmmo] = 1;
	$RemoteInvList[R] = 1;
	$RemoteInvList[RAmmo] = 1;

	$ItemMax[larmor, R] = 0;
	$ItemMax[marmor, R] = 0;
	$ItemMax[harmor, R] = 0;
	$ItemMax[qarmor, R] = 0;
	$ItemMax[tarmor, R] = 0;
	$ItemMax[sarmor, R] = 1;
	$ItemMax[srarmor, R] = 0;
	$ItemMax[parmor, R] = 0;
	$ItemMax[lfemale, R] = 0;
	$ItemMax[mfemale, R] = 0;
	$ItemMax[qfemale, R] = 0;
	$ItemMax[sfemale, R] = 1;
	$ItemMax[srfemale, R] = 0;
	$ItemMax[pfemale, R] = 0;

	$ItemMax[larmor, RAmmo] = 0;
	$ItemMax[marmor, RAmmo] = 0;
	$ItemMax[harmor, RAmmo] = 0;
	$ItemMax[qarmor, RAmmo] = 0;
	$ItemMax[tarmor, RAmmo] = 0;
	$ItemMax[sarmor, RAmmo] = 1;
	$ItemMax[srarmor, RAmmo] = 0;
	$ItemMax[parmor, RAmmo] = 0;
	$ItemMax[lfemale, RAmmo] = 0;
	$ItemMax[mfemale, RAmmo] = 0;
	$ItemMax[qfemale, RAmmo] = 0;
	$ItemMax[sfemale, RAmmo] = 1;
	$ItemMax[srfemale, RAmmo] = 0;
	$ItemMax[pfemale, RAmmo] = 0;	
	$ItemMax[psarmor, RAmmo] = 0;	
	$ItemMax[psfemale, RAmmo] = 0;	
