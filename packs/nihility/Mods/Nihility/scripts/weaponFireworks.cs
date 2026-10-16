//to mount on player
//type into console ==== firework("20xx");

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Nihility);
$InvList[Nihility] = 0;

$ItemMax[larmor, Nihility] = 1;		//Seraph
$ItemMax[lfemale, Nihility] = 1;	//Seraph
$ItemMax[earmor, Nihility] = 1;		//Slave
$ItemMax[efemale, Nihility] = 1;	//Slave
$ItemMax[marmor, Nihility] = 1;		//Pawn
$ItemMax[aarmor, Nihility] = 1;		//Navigator
$ItemMax[darmor, Nihility] = 1;		//Atomizer
$ItemMax[barmor, Nihility] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

GrenadeData RedSplit
{
   bulletShapeName    = "breath.dts";//grenade.dts
   explosionTag       = blasterExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 25;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass      = 1; 
   damageValue      = 0.0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0.0;
   
   maxLevelFlightDist = 1;
   totalTime          = 0.001;    // special meaning for grenades...
   liveTime           = 0.001; // grenade time live after contact
   projSpecialTime    = 0.05;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "shotgunex.dts";//smoke.dts
};

GrenadeData WhiteSplit
{
   bulletShapeName    = "breath.dts";//grenade.dts
   explosionTag       = LargeShockwave;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 25;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass      = 1; 
   damageValue      = 0.0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0.0;
   
   maxLevelFlightDist = 1;
   totalTime          = 0.001;    // special meaning for grenades...
   liveTime           = 0.001; // grenade time live after contact
   projSpecialTime    = 0.05;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "breath.dts";//smoke.dts
};

GrenadeData BlueSplit
{
   bulletShapeName    = "breath.dts";//grenade.dts
   explosionTag       = TurretExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 25;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass      = 1; 
   damageValue      = 0.0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0.0;
   
   maxLevelFlightDist = 1;
   totalTime          = 0.001;    // special meaning for grenades...
   liveTime           = 0.001; // grenade time live after contact
   projSpecialTime    = 0.05;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "enex.dts";//smoke.dts
};




GrenadeData RedSparks
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = BlasterExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.35;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ElectricityDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 2.0;     // grenade time live after contact
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "shotgunex.dts";//plasmaex.dts";//

};

GrenadeData WhiteSparks
{
   bulletShapeName    = "breath.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.35;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ElectricityDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 2.0;     // grenade time live after contact
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "shockwave_large.dts";//plasmaex.dts";//

};

GrenadeData BlueSparks
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = TurretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.35;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ElectricityDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 2.0;     // grenade time live after contact
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "enex.dts";//plasmaex.dts";//

};

RocketData RedBolt
{
   bulletShapeName = "shotgunbolt.dts";
   explosionTag    = BlasterExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1; 
   damageValue      = 0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 5.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "shotgunex.dts";
   smokeDist = 5;
   soundId = SoundJetHeavy;
};

RocketData WhiteBolt
{
   bulletShapeName = "breath.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1; 
   damageValue      = 0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 5.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "breath.dts";
   smokeDist = 5;
   soundId = SoundJetHeavy;
};

RocketData BlueBolt
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = TurretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1; 
   damageValue      = 0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 25;
   kickBackStrength = 0.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 5.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "enex.dts";
   smokeDist = 5;
   soundId = SoundJetHeavy;
};

//stanwood
//============================================================
//============================================================
SoundData SoundNihilityFire
{	wavFileName = "pda_on.wav";  
	profile = Profile3dFar;
};
  
ItemData NihilityShells
{	description = "NIHILITY Fuel";
	className = "Ammo";
	heading = "vCeremonial Items";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 11;
};



ItemImageData NihilityImage
{	shapeFile = "rocket";
	mountPoint = 0;
	//mountRotation = { 0, 3.1416, 3.1416 };
	mountPoint = 0;
	weaponType = 0; // Single Shot
	//ammoType = NihilityShells;
	//projectileType = NihilityBolt;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 1.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	//SoundNihilityFire
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundNihilityFire;
	sfxReload = SoundSensorPower;
	sfxReady = SoundMortarIdle; //SoundBeaconActive  SoundsRepairItem
};




ItemData Nihility
{	description = "Fireworks";
	className = "tool";
	shapeFile = "plasma";
	hudIcon = "ammopack";
	heading = "vCeremonial Items";
	shadowDetailMask = 4;
	imageType = NihilityImage;
	price = 777;
	showWeaponBar = true;
};




function NihilityImage::onFire(%this) 
{ 
	%client = GameBase::getOwnerClient(%this);
	//%AmmoCount = (Player::getItemCount(%client,NihilityShells));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	//if(%AmmoCount){
	//Player::decItemCount(%client,NihilityShells);
	if(GameBase::getLOSInfo(%this,800)){
		%Dist=Vector::getDistance(GameBase::getPosition(%this),$los::position);
		if(%Dist == 0)  %time = 0.50;
		else	%time=(%Dist/180)-0.05;
 		%newObj = Projectile::spawnProjectile("RedBolt", %trans, %this, %vel);
		schedule("SpawnRed(" @ %newObj @ ", " @ %this @ ");", %time);
		%newObj = Projectile::spawnProjectile("RedBolt", %trans, %this, %vel);
		schedule("SpawnRed(" @ %newObj @ ", " @ %this @ ");", %time);
		%newObj = Projectile::spawnProjectile("BlueBolt", %trans, %this, %vel);
		schedule("SpawnBlue(" @ %newObj @ ", " @ %this @ ");", %time);
		%newObj = Projectile::spawnProjectile("BlueBolt", %trans, %this, %vel);
		schedule("SpawnBlue(" @ %newObj @ ", " @ %this @ ");", %time);
		//%newObj = Projectile::spawnProjectile("WhiteBolt", %trans, %this, %vel);
		//schedule("SpawnWhite(" @ %newObj @ ", " @ %this @ ");", %time);
		
	}
	else{
		%time = 0.50; 
		%newObj = Projectile::spawnProjectile("RedBolt", %trans, %this, %vel);
		schedule("SpawnRed(" @ %newObj @ ", " @ %this @ ");", %time);
		%newObj = Projectile::spawnProjectile("RedBolt", %trans, %this, %vel);
		schedule("SpawnRed(" @ %newObj @ ", " @ %this @ ");", %time);
		%newObj = Projectile::spawnProjectile("BlueBolt", %trans, %this, %vel);
		schedule("SpawnBlue(" @ %newObj @ ", " @ %this @ ");", %time);
		%newObj = Projectile::spawnProjectile("BlueBolt", %trans, %this, %vel);
		schedule("SpawnBlue(" @ %newObj @ ", " @ %this @ ");", %time);
		//%newObj = Projectile::spawnProjectile("WhiteBolt", %trans, %this, %vel);
		//schedule("SpawnWhite(" @ %newObj @ ", " @ %this @ ");", %time);
	//}
	}
}

function SpawnRed(%newobj,%this){
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);


	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("RedSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);


if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 60) -30;

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("RedSparks", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);

	Item::setVelocity(%obj, %forceVel);

		}
	deleteobject(%newObj);
	}
	
}

function SpawnBlue(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("BlueSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);


if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 60) -30;

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("BlueSparks", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);

	Item::setVelocity(%obj, %forceVel);

		}
	deleteobject(%newObj);
	}
	
}

function SpawnWhite(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("WhiteSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);


if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 60) -30;

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("WhiteSparks", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);

	Item::setVelocity(%obj, %forceVel);

		}
	deleteobject(%newObj);
	}
	
}

//$NihilitySlotA=4;
//$NihilitySlotB=7;
//$NihilitySlotC=6;

function Nihility::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>This is weapon does no damage - its just for looks");

//	Player::mountItem(%player,Nihilityi,$NihilitySlotA); 
//	Player::mountItem(%player,Nihilityii,$NihilitySlotB);
//	Player::mountItem(%player,Nihilityiii,$NihilitySlotC);

}

function Nihility::onUnmount(%player,%imageSlot)
{
//	Player::unmountItem(%player,$NihilitySlotA); 
//	Player::unmountItem(%player,$NihilitySlotB); 
//	Player::unmountItem(%player,$NihilitySlotC); 
}


//ItemImageData NihilityyImage
////{	shapeFile = "Shotgun";
////	mountRotation = { 0, 3.1416, 0 };
////	mountOffset = { 0 , -0.45, -0.06 };
//{	shapeFile = "shotgun";
//	mountRotation = { 0, 3.1416, 0 };
//	mountOffset = { 0 , -0.45, -0.06 };
//	mountPoint = 0;
//	weaponType = 0; // Single Shot
//	ammoType = NihilityShells;
//	//projectileType = NihilityBolt;
//	accuFire = true;
//	reloadTime = 3.0;
//	fireTime = 4.0;
//	lightType = 3;  // Weapon Fire
//	lightRadius = 3;
//	lightTime = 1;
//	lightColor = { 0.6, 1, 1.0 };
//	sfxFire = SoundPlasmaTurretFire;
//	sfxActivate = SoundNihilityFire;
//	sfxReload = SoundSensorPower;
//	sfxReady = SoundMortarIdle; //SoundBeaconActive  SoundsRepairItem
//};
//
//ItemData Nihilityy
//{	description = "NIHILITY v1.0";
//	className = "Weapon";
//	shapeFile = "plasma";
//	hudIcon = "ammopack";
//	heading = "bWeapons";
//	shadowDetailMask = 4;
//	imageType = NihilityyImage;
//	price = 777;
//	showWeaponBar = true;
//};
//
//function NihilityyImage::onFire(%player,%slot) 
//{	
//	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Nihilityy]);
//	%armor = Player::getArmor(%player);
//	%playerId = Player::getClient(%player);
//	%client = GameBase::getOwnerClient(%player);
//	%trans = GameBase::getMuzzleTransform(%player);
//	%vel = Item::getVelocity(%player);
//	%weapon = Player::getMountedItem(%client,$WeaponSlot);
//	if(%Ammo > 0)
//	{
//		//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
//		Player::decItemCount(%player,$WeaponAmmo[Nihilityy],1);
//		Projectile::spawnProjectile("NihilityBolti",%trans,%player,%vel);
//		Projectile::spawnProjectile("NihilityBoltii",%trans,%player,%vel);
//
//	}
//	else
//	{
//		Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for NIHILITY*");
//	}
//}
//
//$NihilityySlotA=4;
//$NihilityySlotB=7;
//$NihilityySlotC=6;
//
//function Nihilityy::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	%client = Player::getclient(%player);
//        bottomprint(%client, "<jc><f2>NIHILITY v1.0");
//
//	Player::mountItem(%player,Nihilityi,$NihilityySlotA); 
//	Player::mountItem(%player,Nihilityii,$NihilityySlotB);
//	Player::mountItem(%player,Nihilityiii,$NihilityySlotC);
//
//}
//
//function Nihilityy::onUnmount(%player,%imageSlot)
//{
//	Player::unmountItem(%player,$NihilityySlotA); 
//	Player::unmountItem(%player,$NihilityySlotB); 
//	Player::unmountItem(%player,$NihilityySlotC); 
//}
//
////function Nihility::onUse(%player,%item)
////{
////        Weapon::onUse(%player,%item);
////	%client = GameBase::getOwnerClient(%player);
////	if (!%client.Nihility || %client.rocket == 0)
////	{
////	        bottomprint(%client, "<jc><f2>NIHILITY<f1> Standard Mode", 2);
////	}
////	if (%client.Nihility == 1)
////	{
////	        bottomprint(%client, "<jc><f2>NIHILITY<f1> Fireworks Mode", 2);
////	}         
////}


