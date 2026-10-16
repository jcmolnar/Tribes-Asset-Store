//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Diablo);
$InvList[Diablo] = 1;
$InvList[DiabloAmmo] = 1;

$SellAmmo[DiabloAmmo] = 10;
$AutoUse[Diablo] = True;
$WeaponAmmo[Diablo] = DiabloAmmo;

$ItemMax[larmor, Diablo] = 0;		//Seraph
$ItemMax[lfemale, Diablo] = 0;		//Seraph
$ItemMax[earmor, Diablo] = 0;		//Slave
$ItemMax[efemale, Diablo] = 0;		//Slave
$ItemMax[marmor, Diablo] = 0;		//Pawn
$ItemMax[aarmor, Diablo] = 0;		//Navigator
$ItemMax[darmor, Diablo] = 1;		//Atomizer
$ItemMax[barmor, Diablo] = 0;		//Paladin

$ItemMax[larmor, DiabloAmmo] = 0;	//Seraph
$ItemMax[lfemale, DiabloAmmo] = 0;	//Seraph
$ItemMax[earmor, DiabloAmmo] = 0;	//Slave
$ItemMax[efemale, DiabloAmmo] = 0;	//Slave
$ItemMax[marmor, DiabloAmmo] = 0;	//Pawn
$ItemMax[aarmor, DiabloAmmo] = 0;	//Navigator
$ItemMax[darmor, DiabloAmmo] = 10;	//Atomizer
$ItemMax[barmor, DiabloAmmo] = 0;	//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

SoundData SoundFireDiablo
{	wavFileName = "flyer_fly.wav";
	profile = Profile3dMedium;
};



GrenadeData DiabloSplit
{
   bulletShapeName    = "Mortar.dts";//grenade.dts
   explosionTag       = GrenadeExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $PlasmaDamageType;//$PlasmaDamageType;//

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";//smoke.dts
};

GrenadeData DiabloShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $PlasmaDamageType; //$MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 20.0;
   liveTime           = 20.0; // grenade time live after contact
   projSpecialTime    = 0.01; // smoke interval

   inheritedVelocityScale = 0.5;
   smokeName     = "plastrail.dts";
//plasmaex.dts,fusionex.dts
//enbolt.dts,mortartrail,plastrail,breath
//fusionbolt.dts
//enex.dts
};

GrenadeData DiabloFire
{
   bulletShapeName    = "mortar.dts";//mortar
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	//5.0
   elasticity         = 0.45;	//0.1

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.22;
   damageType         = $PlasmaDamageType; //$MortarDamageType;

   explosionRadius    = 45.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; // grenade time live after contact
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";//breath.dts";//mortartrail,plastrail
};

ItemData DiabloAmmo
{
	description = "Diablo Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData DiabloImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = DiabloAmmo;
	//projectileType = BomberShell;//mortarshell
	accuFire = false;
	mountRotation = { 0, 1.57, 0 };
	//mountOffset = {-0.065, 0, 0.07}; 
	reloadTime = 0.75;
	fireTime = 2.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = bigExplosion3; //SoundsFireDiablo
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData Diablo 
{
	description = "El Diablo";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiabloImage;
	price = 777;
	showWeaponBar = true;
};

//====

function DiabloImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,DiabloAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,DiabloAmmo);

 		%newObj = Projectile::spawnProjectile("DiabloShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("DiabloSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("DiabloFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	//%rnd = (floor(getRandom()*20)/80);
		//schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
//function SetMines(%newobj,%this){
//
//	if (GameBase::getPosition(%newObj)){
//		%Pos = GameBase::getPosition(%newobj); 
//   		%vel = Item::getVelocity(%newobj);
//		%Mine = newObject("","Mine","antipersonelMine");
//		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
// 		addToSet("MissionCleanup", %Mine);
//      	GameBase::throw(%Mine,%this,-1,true);
//		GameBase::setPosition(%Mine, %pos);
//		Item::setVelocity(%Mine, %vel);
//	deleteobject(%newObj);
//	}
//}

//====


function Diablo::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>El Diablo || Firing function - Plasmatic", 2); }
