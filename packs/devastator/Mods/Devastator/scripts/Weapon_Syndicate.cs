ExplosionData SynExp
{
   shapeName = "mortartrail.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.0;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.3, 0.0,  0.0 };
   colors[1]  = { 0.3, 0.0, 0.0 };
   colors[2]  = { 0.3, 0.0, 0.0 };
   radFactors = { 0.3, 0.0, 0.0 };
};

//--------------------------------------

SeekingMissileData SyndicateBugg
{
	bulletShapeName = "mine.dts";
	explosionTag    = SynExp;
	collisionRadius = 0.0;
	mass            = 2.0;

	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.2;
	damageType       = $SynDamageType;
	explosionRadius  = 3.5;
	kickBackStrength = 10.0;

	muzzleVelocity          = 15.0;
	terminalVelocity        = 15.0;
	totalTime               = 100;
	liveTime                = 100;
	seekingTurningRadius    = 0.01;
	nonSeekingTurningRadius = 0.01;
	proximityDist           = 0.5;
//-Make an extremely large tail to have no tail at all
//	smokeDist               = 0.01;
	smokeDist               = 50.0;

	lightRange       = 5.0;
	lightColor       = { 0.3, 0, 0 };

	inheritedVelocityScale = 1.00;
	smokeName              = "breath.dts";
	soundId = SoundRepairItem;
};

//--------------------------------------

BulletData SyndicateBuggInit
{
	bulletShapeName = "mine.dts";
	explosionTag    = SynExp;
	collisionRadius = 0.0;
	mass            = 2.0;

	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.2;
	damageType       = $SynDamageType;
	
	aimDeflection      = 0.01;
   	muzzleVelocity          = 15.0;
	totalTime               = 1.0;
	smokeDist               = 0.005;
	isVisible  		= true;

	lightRange       = 5.0;
	lightColor       = { 0.3, 0, 0 };

	tracerPercentage   = 0.0;
	inheritedVelocityScale = 1.00;
	smokeName              = "breath.dts";
	soundId = SoundRepairItem;
};

//--------------------------------------

ItemImageData Syn1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -0.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	projectileType = SyndicateBugg;
};

ItemImageData Syn2Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -0.5, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	projectileType = SyndicateBugg;
};

ItemImageData Syn3Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -0.5, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	projectileType = SyndicateBugg;
};

ItemData Syn1
{
	description = "Syndicate Part";
	className = "Weapon";
	shapeFile = "Force";
	shadowDetailMask = 4;
	imageType = Syn1Image;
	showInventory = false;
	showWeaponBar = false;
};

ItemData Syn2
{
	description = "Syndicate Part";
	className = "Weapon";
	shapeFile = "Force";
	shadowDetailMask = 4;
	imageType = Syn2Image;
	showInventory = false;
	showWeaponBar = false;
};

ItemData Syn3
{
	description = "Syndicate Part";
	className = "Weapon";
	shapeFile = "Force";
	shadowDetailMask = 4;
	imageType = Syn3Image;
	showInventory = false;
	showWeaponBar = false;
};

ItemData SynAmmo
{
	description = "Syndicate Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 30;
};

ItemImageData SynImage
{
	shapeFile = "breath";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.3, 0, 0 };
	sfxFire = SoundMissileTurretOn;
	sfxActivate = SoundWeaponSelect;
};

ItemData Syn
{
	description = "Syndicate";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "reticle";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = SynImage;
	price = 175;
	showWeaponBar = true;
};

ItemImageData Syn0Image
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.3, 0, 0 };
};

ItemData Syn0
{
	description = "Syndicate";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "reticle";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = Syn0Image;
	showInventory = false;
	showWeaponBar = false;
};

//--------------------------------------//
//------------FUNCTION-STUFF------------//
//--------------------------------------//

function Syn::onMount(%player,%item)
{
	Player::mountItem(%player,Syn0,4);
	Player::mountItem(%player,Syn1,5);
	Player::mountItem(%player,Syn2,6);
	Player::mountItem(%player,Syn3,7);
}

function Syn::onUnMount(%player,%item)
{
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function SynImage::onFire(%player, %slot) 
{  
	%client = Player::getClient(%player);
	%AmmoCount = Player::getItemCount(%player,SynAmmo);
	if(%AmmoCount > 0) {
		if(GameBase::getLOSInfo(%player,2000)) {
			echo(getObjectType($los::object));
			if(getObjectType($los::object) == "Player") {
				if(GetTeam($los::object,%player) != Same)
					Syndicate::LockedOn(%player,$los::object);
				else
					bottomprint(%client,"<jc><f5>Error Tracking... Wrong Team", 2);
			}			
			else if(getObjectType($los::object) == "Flier") {
				%LastPilot = $los::object.clLastMount;
				if(GetTeam(%LastPilot,%player) != Same && GetTeam(%LastPilot,%player) != You)
					Syndicate::LockedOn(%player,$los::object);
				else if(GetTeam(%LastPilot,%player) == You)
					bottomprint(%client,"<jc><f5>Error Tracking... Your Vehicle", 2);
				else
					bottomprint(%client,"<jc><f5>Error Tracking... Wrong Team", 2);
			}
			else if(getObjectType($los::object) == "SeekingRocket" || getObjectType($los::object) == "RocketDumb") {
				if(GameBase::getDataName($los::object) == "SyndicateBugg") {
					if(GetTeam($los::object.Shooter,%player) != Same && GetTeam($los::object.Shooter,%player) != You)
						Syndicate::LockedOn(%player,$los::object,"<jc><f2>Special Lock Counter-Measures Acquired");
					else if(GetTeam($los::object.Shooter,%player) == You)
						bottomprint(%client,"Error Tracking... Your Syndicates", 2);
				}
				else
					Syndicate::LockedOn(%player,$los::object,"<jc><f2>Special Lock Counter-Measures Acquired");
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

//-Trying to only spawn 3 REAL proj's and their swarm-mates for a 'Fake' 12 bug effect, alot less lag
function Syndicate::LockedOn(%player,%object,%special)
{
	%client = Player::getClient(%player);
	%LockOnMSG = "<jc><f2>Lock Acquired";
	if(%special)
		%LockOnMSG = %special;
	bottomprint(%client,%LockOnMSG,2);
	%x = getword(%pos,0);
	%y = getword(%pos,1);
	%z = getword(%pos,2);
	%pos1 = %X+1.0@" "@%Y@" "@%Z;
	%pos2 = %X-1.0@" "@%Y@" "@%Z;
	%pos3 = %X@" "@%Y@" "@%Z+0.5;
//	%trans1 = Vector::add(GameBase::getMuzzleTransform(%player),"0 0 0 0 0 0 0 0 0 "@%pos1);
//	%trans2 = Vector::add(GameBase::getMuzzleTransform(%player),"0 0 0 0 0 0 0 0 0 "@%pos2);
//	%trans3 = Vector::add(GameBase::getMuzzleTransform(%player),"0 0 0 0 0 0 0 0 0 "@%pos3);
	%trans1 = GameBase::getMuzzleTransform(%player);
	%trans2 = GameBase::getMuzzleTransform(%player);
	%trans3 = GameBase::getMuzzleTransform(%player);
	%proj1 = Projectile::spawnProjectile("SyndicateBuggInit",%trans1,%player,Item::getVelocity(%player),%object);
	%proj2 = Projectile::spawnProjectile("SyndicateBuggInit",%trans2,%player,Item::getVelocity(%player),%object);
	%proj3 = Projectile::spawnProjectile("SyndicateBuggInit",%trans3,%player,Item::getVelocity(%player),%object);
	echo(%proj1@" "@%proj2@" "@%proj3);
//	%proj4 = Projectile::spawnProjectile("SyndicateBuggInit",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player),%object);
//	%proj5 = Projectile::spawnProjectile("SyndicateBuggInit",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player),%object);
//	%proj6 = Projectile::spawnProjectile("SyndicateBuggInit",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player),%object);
	$Shooter[%proj1] = %player;
	$Shooter[%proj2] = %player;
	$Shooter[%proj3] = %player;
//	$Shooter[%proj4] = %player;
//	$Shooter[%proj5] = %player;
//	$Shooter[%proj6] = %player;
	$Target[%proj1]  = %object;
	$Target[%proj2]  = %object;
	$Target[%proj3]  = %object;
//	$Target[%proj4]  = %object;
//	$Target[%proj5]  = %object;
//	$Target[%proj6]  = %object;
	WarnLock(%object);
}

function SyndicateBuggInit::onAdd(%this)
{
	%this.shooter = $Shooter[%this];
	%this.target  =  $Target[%this];
	schedule("Projectile::SetStraight("@%this@");",0.08,%this.shooter);
	echo($SwarmCount[%this]);
	if($SwarmCount[%this] >= 5)
		schedule("Syndicate::ProjSwap("@%this@");",1.0,%this);
	else
		schedule("Syndicate::ProjSwap("@%this@");",1.0,%this);
}

function Projectile::SetStraight(%this,%type)
{
	//-Keeps projs from crashin into the ground onAdd (Might only work on grenades though...)
	%vel = Item::getVelocity(%this);
	%x = getword(%vel,0);
	%y = getword(%vel,1);
	%z = getword(%vel,2);
	if(%z < 0) {
		%newVel = %x@" "@%y@" 0";
		if(%type == "Hov")
			%newVel = %x@" "@%y@" -"@%z;
		Item::setVelocity(%this,%newVel);
	}
}

function Syndicate::ProjSwap(%this)
{
	%this.shooter = $Shooter[%this];
	%this.target  =  $Target[%this];
	if(%this)
		%proj = Projectile::spawnProjectile("SyndicateBugg","0 0 0 0 0 0 0 0 0 "@GameBase::getPosition(%this),%this.shooter,Item::getVelocity(%this),%this.target);
	$Shooter[%proj] = %this.shooter;
	$Target[%proj]  =  %this.target;
	GameBase::StartFadeOut(%this);
}

//-------------------------------------//
//-----------INVENTORY-STUFF-----------//
//-------------------------------------//

	$AutoUse[Syn] = True;
	$SellAmmo[SynAmmo] = 2;
	$WeaponAmmo[Syn] = SynAmmo;	

	$InvList[Syn] = 1;
	$RemoteInvList[Syn] = 1;

	$InvList[SynAmmo] = 1;
	$RemoteInvList[SynAmmo] = 1;
	
	$ItemMax[larmor, Syn] = 0;
	$ItemMax[marmor, Syn] = 0;
	$ItemMax[harmor, Syn] = 0;
	$ItemMax[qarmor, Syn] = 0;
	$ItemMax[tarmor, Syn] = 0;
	$ItemMax[sarmor, Syn] = 1;
	$ItemMax[srarmor, Syn] = 0;
	$ItemMax[parmor, Syn] = 0;
	$ItemMax[lfemale, Syn] = 0;
	$ItemMax[mfemale, Syn] = 0;
	$ItemMax[qfemale, Syn] = 0;
	$ItemMax[sfemale, Syn] = 1;
	$ItemMax[srfemale, Syn] = 0;
	$ItemMax[pfemale, Syn] = 0;

	$ItemMax[larmor, SynAmmo] = 0;
	$ItemMax[marmor, SynAmmo] = 0;
	$ItemMax[harmor, SynAmmo] = 0;
	$ItemMax[qarmor, SynAmmo] = 0;
	$ItemMax[tarmor, SynAmmo] = 0;
	$ItemMax[sarmor, SynAmmo] = 8;
	$ItemMax[srarmor, SynAmmo] = 0;
	$ItemMax[parmor, SynAmmo] = 0;
	$ItemMax[lfemale, SynAmmo] = 0;
	$ItemMax[mfemale, SynAmmo] = 0;
	$ItemMax[qfemale, SynAmmo] = 0;
	$ItemMax[sfemale, SynAmmo] = 8;
	$ItemMax[srfemale, SynAmmo] = 0;
	$ItemMax[pfemale, SynAmmo] = 0;
