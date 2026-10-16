//----------------------------------------------------------------------------
//-------------------------------Light Allied Plane---------------------------
RocketData yFighterbullet
{
	bulletShapeName = "breath.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.59;
	damageType = $AlliedFighterGun;		
	explosionRadius = 0.1;
	kickBackStrength = 100.0;
	muzzleVelocity = 1000.0;
	terminalVelocity = 1200.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightrange = 1.0;
	lightColor = { 1, 1, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

GrenadeData yFighterBomb
{	bulletShapeName = "grenammo.dts";
	explosionTag = BombExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.001;
	mass = 1.0;
	elasticity = 0.05;
	damageClass = 4;
	damageValue = 4;
	damageType = $AlliedFighterBomb;
	explosionRadius = 8;
	kickBackStrength = 60;
	maxLevelFlightDist = 10;
	totalTime = 8;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 1.5;
	soundid = SoundFireSeeking;
};

FlierData AlliedFighter
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
  // shieldShapeName = "shield_large";
   mass = 0.01;
   drag = 0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 100; //1
   maxSpeed = 60;
   minSpeed = -0.6;
	lift = 0.8;
	maxAlt = 15;
	maxVertical = 0.5;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.2;

	groundDamageScale = 2;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	//dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	minDamageSpeed = 1;
	visibleDriver = true;
	driverPose = 23;
	description = "Allied Light Plane";
};

function AlliedFighter::onAdd(%this)
{
%pl = spawnplayer(soldier, "0 0 0", "0 0 0");
gamebase::setteam(%pl, gamebase::getteam(%this));
%this.shturman = %pl;
gamebase::setrotation(%pl, vector::multiply(gamebase::getrotation(%this), "1 1 1")); 
player::mountitem(%pl, PlaneSetup, 0);
player::mountitem(%pl, planesetup2, 4);
player::mountitem(%pl, planesetup3, 5);
%pl.isvehicle = 1;
schedule("player::setmountobject(" @ %pl @ ", " @ %this @ ", 1);",0.2);
%pl.pidar = %this;
schedule("vehicle::onAdd(" @ %this @ ", 1);", 0.1);
}

function AlliedFighter::onFire(%this)
{
if(%this.cantfire) return;

%vel = Item::getVelocity(%this);
%cl = GameBase::getControlClient(%this);
%pl = Client::getownedObject(%cl);
%trans = GameBase::GetMuzzleTransform(%this);
%t0 = getWord(%trans, 0);
%t1 = getWord(%trans, 1);
%t2 = getWord(%trans, 2);
%t3 = getWord(%trans, 3);
%t4 = getWord(%trans, 4);
%t5 = getWord(%trans, 5);
%t6 = getWord(%trans, 6);
%t7 = getWord(%trans, 7);
%t8 = getWord(%trans, 8);
%t9 = getWord(%trans, 9);
%t10 = getWord(%trans, 10);
%t11 = getWord(%trans, 11);
%right = %t0 @ " " @ %t1 @ " " @ %t2;
%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11;
%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
%aimvector1 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.03 0.03 0.03")));
%aimvector2 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.03 0.03 0.03")));
%transBomb = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %t3 @ " " @ %t4 @ " " @ %t5 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %t9 @ " " @ %t10 @ " " @ %t11-3.2;
%velx = vector::multiply(%vel, "3 3 3");
%transGun1 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector1 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(%right, "1 1 1")), "0 0 1");
%transGun2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector2 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(vector::neg(%right), "1 1 1")), "0 0 1");


if(%this.weaponmode == 0) 
	{
	Projectile::spawnProjectile("yFighterbullet", %transGun1, %pl, "0 0 0"); 
	Projectile::spawnProjectile("yFighterbullet", %transGun2, %pl, "0 0 0"); 
	//Projectile::spawnProjectile("MG42Fire", %transGun1, %pl, %Vel); 
	//Projectile::spawnProjectile("MG42Fire", %transGun2, %pl, %Vel); 
	GameBase::PlaySound(%this, debrisMediumExplosion, 2);	
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 0.11);
	}
else 
	{
	Projectile::spawnProjectile("yFighterBomb", %transBomb, %pl, %Vel); 
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 4);
	}
}

function AlliedFighter::isDamage(%this, %type,%val)
{
%dlevel = gameBase::getDamageLevel(%this);
if(getdamagetype(%type) == "bullet") %val = %val/6;
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel);
if(%dlevel > 0.9) %this.controlcorrupt = 3;
else if(%dlevel > 0.7) %this.controlcorrupt = 2;
else if(%dlevel > 0.5) %this.controlcorrupt = 1;

}

function alliedfighter::isDestroyed(%this)
{
%pl = client::getownedobject(%this.lastcontrolobject);

%vel = item::getvelocity(%this);
%trans = gamebase::getmuzzletransform(%this);

%right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);

%trans1 = "0 0 1 " @ %right @ " 0 1 0 " @ %muzzlepos;
%trans2 = "0 0 1 " @ vector::neg(%right) @ " 0 1 0 " @ %muzzlepos;

Projectile::spawnProjectile("PlaneWing1", %trans1, %pl, %Vel); 
Projectile::spawnProjectile("PlaneWing1", %trans2, %pl, %Vel); 

for(%x = 0; %x < 9; %x++)
	Projectile::spawnProjectile("Fragexp" @ 1+floor(getrandom()*6), "0 1 0 " @ vector::getrandom() @ " 1 0 1 " @ getboxcenter(%this), %pl, %Vel); 

}
function axisfighter::isDestroyed(%this)
{
%pl = client::getownedobject(%this.lastcontrolobject);

%vel = item::getvelocity(%this);
%trans = gamebase::getmuzzletransform(%this);

%right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);

%trans1 = "0 0 1 " @ %right @ " 0 1 0 " @ %muzzlepos;
%trans2 = "0 0 1 " @ vector::neg(%right) @ " 0 1 0 " @ %muzzlepos;

Projectile::spawnProjectile("PlaneWing1", %trans1, %pl, %Vel); 
Projectile::spawnProjectile("PlaneWing1", %trans2, %pl, %Vel); 

for(%x = 0; %x < 9; %x++)
	Projectile::spawnProjectile("Fragexp" @ 1+floor(getrandom()*6), "0 1 0 " @ vector::getrandom() @ " 1 0 1 " @ getboxcenter(%this), %pl, %Vel); 

}
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//-------------------------------Light Axis Plane---------------------------
RocketData xFighterbullet
{
	bulletShapeName = "breath.dts";
	explosionTag = mediumbullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.4;
	damageType = $AxisFighterGun;		
	explosionRadius = 0.1;
	kickBackStrength = 100.0;
	muzzleVelocity = 1200.0;
	terminalVelocity = 1500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightrange = 1.0;
	lightColor = { 1,1,1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

GrenadeData xFighterBomb
{	bulletShapeName = "grenammo.dts";
	explosionTag = BombExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.001;
	mass = 1.0;
	elasticity = 0.05;
	damageClass = 4;
	damageValue = 3.5;
	damageType = $AxisFighterBomb;
	explosionRadius = 11;
	kickBackStrength = 60;
	maxLevelFlightDist = 20;
	totalTime = 8;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 0.5;
	soundid = SoundFireSeeking;
};

FlierData AxisFighter
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
  // shieldShapeName = "shield_large";
   mass = 0.01;
   drag = 0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 60;
   minSpeed = -0.6;
	lift = 0.8;
	maxAlt = 15;
	maxVertical = 0.5;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.2;

	groundDamageScale = 2;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	//dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	minDamageSpeed = 1;
	visibleDriver = true;
	driverPose = 23;
	description = "Axis Light Plane";
};

function AxisFighter::onAdd(%this)
{
%pl = spawnplayer(soldier, "0 0 0", "0 0 0");
gamebase::setteam(%pl, gamebase::getteam(%this));
%this.shturman = %pl;
gamebase::setrotation(%pl, vector::multiply(gamebase::getrotation(%this), "1 1 1")); 
player::mountitem(%pl, PlaneSetup, 0);
player::mountitem(%pl, planesetup2, 4);
player::mountitem(%pl, planesetup3, 5);
%pl.isvehicle = 1;
schedule("player::setmountobject(" @ %pl @ ", " @ %this @ ", 1);",0.2);
%pl.pidar = %this;
schedule("vehicle::onAdd(" @ %this @ ", 1);", 0.1);
}

function AxisFighter::onFire(%this)
{
if(%this.cantfire) return;

%vel = Item::getVelocity(%this);
%cl = GameBase::getControlClient(%this);
%pl = Client::getownedObject(%cl);
%trans = GameBase::GetMuzzleTransform(%this);
%t0 = getWord(%trans, 0);
%t1 = getWord(%trans, 1);
%t2 = getWord(%trans, 2);
%t3 = getWord(%trans, 3);
%t4 = getWord(%trans, 4);
%t5 = getWord(%trans, 5);
%t6 = getWord(%trans, 6);
%t7 = getWord(%trans, 7);
%t8 = getWord(%trans, 8);
%t9 = getWord(%trans, 9);
%t10 = getWord(%trans, 10);
%t11 = getWord(%trans, 11);
%right = %t0 @ " " @ %t1 @ " " @ %t2;
%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11;
%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
%aimvector1 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.03 0.03 0.03")));
%aimvector2 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.03 0.03 0.03")));
%transBomb = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %t3 @ " " @ %t4 @ " " @ %t5 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %t9 @ " " @ %t10 @ " " @ %t11-3.2;
%velx = vector::multiply(%vel, "3 3 3");
%transGun1 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector1 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(%right, "1 1 1")), "0 0 1");
%transGun2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector2 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(vector::neg(%right), "1 1 1")), "0 0 1");


if(%this.weaponmode == 0) 
	{
	Projectile::spawnProjectile("xFighterBullet", %transGun1, %pl, "0 0 0"); 
	Projectile::spawnProjectile("xFighterBullet", %transGun2, %pl, "0 0 0"); 
	//Projectile::spawnProjectile("BrowningFire", %transGun1, %pl, %Vel); 
	//Projectile::spawnProjectile("BrowningFire", %transGun2, %pl, %Vel); 
	GameBase::PlaySound(%this, debrisSmallExplosion, 2);	
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 0.08);
	}
else 
	{
	Projectile::spawnProjectile("xFighterBomb", %transBomb, %pl, %Vel); 
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 4);
	}
}

function AxisFighter::isDamage(%this, %type, %val)
{
%dlevel = gameBase::getDamageLevel(%this);
if(getdamagetype(%type) == "bullet") %val = %val/6;
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel);
if(%dlevel > 0.9) %this.controlcorrupt = 3;
else if(%dlevel > 0.7) %this.controlcorrupt = 2;
else if(%dlevel > 0.5) %this.controlcorrupt = 1;

}


//--------------------------------------------------------
//------------------Allied Bomber Plane-------------------
//--------------------------------------------------------

RocketData yBomberbullet
{
	bulletShapeName = "breath.dts";
	explosionTag = mediumbullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.5;
	damageType = $AlliedBomberGun;		
	explosionRadius = 0.1;
	kickBackStrength = 100.0;
	muzzleVelocity = 800.0;
	terminalVelocity = 600.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 1.0;
	lightColor = { 1,1,1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

GrenadeData yBomberBomb
{	bulletShapeName = "grenammo.dts";
	explosionTag = BigBombExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.001;
	mass = 1.0;
	elasticity = 0.05;
	damageClass = 4;
	damageValue = 5;
	damageType = $AlliedBomberBomb;
	explosionRadius = 18;
	kickBackStrength = 60;
	maxLevelFlightDist = 20;
	totalTime = 8;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 0.5;
	soundid = SoundFireSeeking;
};
FlierData AlliedBomber
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
  // shieldShapeName = "shield_large";
   mass = 0.01;
   drag = 0;
   density = 1.2;
   maxBank = 0.7;
   maxPitch = 0.6;
   maxSpeed = 48;
   minSpeed = -0.6;
	lift = 0.8;
	maxAlt = 15;
	maxVertical = 0.5;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.1;

	groundDamageScale = 2;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	//dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	minDamageSpeed = 1;
	visibleDriver = true;
	driverPose = 23;
	description = "Allied Bomber Plane";
};

function AlliedBomber::onAdd(%this)
{
%pl = spawnplayer(soldier, "0 0 0", "0 0 0");
gamebase::setteam(%pl, gamebase::getteam(%this));
%this.shturman = %pl;
gamebase::setrotation(%pl, vector::multiply(gamebase::getrotation(%this), "1 1 1")); 
player::mountitem(%pl, PlaneSetup, 0);
player::mountitem(%pl, Bombersetup2, 4);
player::mountitem(%pl, Bombersetup3, 5);
%pl.isvehicle = 1;
schedule("player::setmountobject(" @ %pl @ ", " @ %this @ ", 1);",0.2);
%pl.pidar = %this;
schedule("vehicle::onAdd(" @ %this @ ", 1);", 0.1);
}

function AlliedBomber::onFire(%this)
{
if(%this.cantfire) return;

%vel = Item::getVelocity(%this);
%cl = GameBase::getControlClient(%this);
%pl = Client::getownedObject(%cl);
%trans = GameBase::GetMuzzleTransform(%this);
%t0 = getWord(%trans, 0);
%t1 = getWord(%trans, 1);
%t2 = getWord(%trans, 2);
%t3 = getWord(%trans, 3);
%t4 = getWord(%trans, 4);
%t5 = getWord(%trans, 5);
%t6 = getWord(%trans, 6);
%t7 = getWord(%trans, 7);
%t8 = getWord(%trans, 8);
%t9 = getWord(%trans, 9);
%t10 = getWord(%trans, 10);
%t11 = getWord(%trans, 11);
%right = %t0 @ " " @ %t1 @ " " @ %t2;
%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11;
%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
%aimvector1 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.045 0.045 0.045")));
%aimvector2 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.045 0.045 0.045")));
%transBomb = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %t3 @ " " @ %t4 @ " " @ %t5 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %t9 @ " " @ %t10 @ " " @ %t11-3.2;
%velx = vector::multiply(%vel, "3 3 3");
%transGun1 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector1 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(%right, "1 1 1")), "0 0 1");
%transGun2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector2 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(vector::neg(%right), "1 1 1")), "0 0 1");


if(%this.weaponmode == 0) 
	{
	Projectile::spawnProjectile("yBomberBullet", %transGun1, %pl, "0 0 0"); 
	Projectile::spawnProjectile("yBomberBullet", %transGun2, %pl, "0 0 0"); 
	//Projectile::spawnProjectile("BrowningFire", %transGun1, %pl, %Vel); 
	//Projectile::spawnProjectile("BrowningFire", %transGun2, %pl, %Vel); 
	GameBase::PlaySound(%this, debrisSmallExplosion, 2);	
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 0.09);
	}
else 
	{
	Projectile::spawnProjectile("yBomberBomb", %transBomb, %pl, %Vel); 
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 3.5);
	}
}

function AlliedBomber::isDamage(%this, %type, %val)
{
%dlevel = gameBase::getDamageLevel(%this);
if(getdamagetype(%type) == "bullet") %val = %val/7;
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel);
if(%dlevel > 0.9) %this.controlcorrupt = 3;
else if(%dlevel > 0.7) %this.controlcorrupt = 2;
else if(%dlevel > 0.5) %this.controlcorrupt = 1;

}

function alliedBomber::isDestroyed(%this)
{
%pl = client::getownedobject(%this.lastcontrolobject);

%vel = item::getvelocity(%this);
%trans = gamebase::getmuzzletransform(%this);

%right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);

%trans1 = "0 0 1 " @ %right @ " 0 1 0 " @ %muzzlepos;
%trans2 = "0 0 1 " @ vector::neg(%right) @ " 0 1 0 " @ %muzzlepos;
%trans3 = "0 0 1 " @ vector::neg(getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5)) @ " 0 1 0 " @ %muzzlepos;

Projectile::spawnProjectile("PlaneWing2", %trans1, %pl, %Vel); 
Projectile::spawnProjectile("PlaneWing2", %trans2, %pl, %Vel); 
Projectile::spawnProjectile("PlaneWing1", %trans3, %pl, %Vel);

for(%x = 0; %x < 15; %x++)
	Projectile::spawnProjectile("Fragexp" @ 1+floor(getrandom()*6), "0 1 0 " @ vector::getrandom() @ " 1 0 1 " @ getboxcenter(%this), %pl, %Vel); 

}

//--------------------------------------------------------
//------------------Axis Bomber Plane-------------------
//--------------------------------------------------------

RocketData xBomberbullet
{
	bulletShapeName = "breath.dts";
	explosionTag = mediumbullet;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.5;
	damageType = $AxisBomberGun;		
	explosionRadius = 0.1;
	kickBackStrength = 100.0;
	muzzleVelocity = 800.0;
	terminalVelocity = 600.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 1.0;
	lightColor = { 1,1,1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

GrenadeData xBomberBomb
{	bulletShapeName = "grenammo.dts";
	explosionTag = BigBombExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.001;
	mass = 1.0;
	elasticity = 0.05;
	damageClass = 4;
	damageValue = 4.7;
	damageType = $AxisBomberBomb;
	explosionRadius = 20;
	kickBackStrength = 60;
	maxLevelFlightDist = 20;
	totalTime = 8;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 0.5;
	soundid = SoundFireSeeking;
};

FlierData AxisBomber
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
  // shieldShapeName = "shield_large";
   mass = 0.01;
   drag = 0;
   density = 1.2;
   maxBank = 0.7;
   maxPitch = 0.6;
   maxSpeed = 48;
   minSpeed = -0.6;
	lift = 0.8;
	maxAlt = 15;
	maxVertical = 0.5;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.1;

	groundDamageScale = 2;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	//dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	minDamageSpeed = 1;
	visibleDriver = true;
	driverPose = 23;
	description = "Axis Bomber Plane";
};

function AxisBomber::onAdd(%this)
{
%pl = spawnplayer(soldier, "0 0 0", "0 0 0");
gamebase::setteam(%pl, gamebase::getteam(%this));
%this.shturman = %pl;
gamebase::setrotation(%pl, vector::multiply(gamebase::getrotation(%this), "1 1 1")); 
player::mountitem(%pl, PlaneSetup, 0);
player::mountitem(%pl, Bombersetup2, 4);
player::mountitem(%pl, Bombersetup3, 5);
%pl.isvehicle = 1;
schedule("player::setmountobject(" @ %pl @ ", " @ %this @ ", 1);",0.2);
%pl.pidar = %this;
schedule("vehicle::onAdd(" @ %this @ ", 1);", 0.1);
}

function AxisBomber::onFire(%this)
{
if(%this.cantfire) return;

%vel = Item::getVelocity(%this);
%cl = GameBase::getControlClient(%this);
%pl = Client::getownedObject(%cl);
%trans = GameBase::GetMuzzleTransform(%this);
%t0 = getWord(%trans, 0);
%t1 = getWord(%trans, 1);
%t2 = getWord(%trans, 2);
%t3 = getWord(%trans, 3);
%t4 = getWord(%trans, 4);
%t5 = getWord(%trans, 5);
%t6 = getWord(%trans, 6);
%t7 = getWord(%trans, 7);
%t8 = getWord(%trans, 8);
%t9 = getWord(%trans, 9);
%t10 = getWord(%trans, 10);
%t11 = getWord(%trans, 11);
%right = %t0 @ " " @ %t1 @ " " @ %t2;
%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11;
%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
%aimvector1 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.045 0.045 0.045")));
%aimvector2 = vector::normalize(vector::add(%aimvector, vector::multiply(vector::getrandom(), "0.045 0.045 0.045")));
%transBomb = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %t3 @ " " @ %t4 @ " " @ %t5 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %t9 @ " " @ %t10 @ " " @ %t11-3.2;
%velx = vector::multiply(%vel, "3 3 3");
%transGun1 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector1 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(%right, "1 1 1")), "0 0 1");
%transGun2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector2 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(vector::add(%muzzlepos, vector::multiply(vector::neg(%right), "1 1 1")), "0 0 1");


if(%this.weaponmode == 0) 
	{
	Projectile::spawnProjectile("xBomberBullet", %transGun1, %pl, "0 0 0"); 
	Projectile::spawnProjectile("xBomberBullet", %transGun2, %pl, "0 0 0"); 
	//Projectile::spawnProjectile("BrowningFire", %transGun1, %pl, %Vel); 
	//Projectile::spawnProjectile("BrowningFire", %transGun2, %pl, %Vel); 
	GameBase::PlaySound(%this, debrisSmallExplosion, 2);	
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 0.09);
	}
else 
	{
	Projectile::spawnProjectile("xBomberBomb", %transBomb, %pl, %Vel); 
	%this.cantfire = true;
	schedule(%this @ ".cantfire = false;", 3.5);
	}
}

function AxisBomber::isDamage(%this, %type, %val)
{
%dlevel = gameBase::getDamageLevel(%this);
if(getdamagetype(%type) == "bullet") %val = %val/7;
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel);
if(%dlevel > 0.9) %this.controlcorrupt = 3;
else if(%dlevel > 0.7) %this.controlcorrupt = 2;
else if(%dlevel > 0.5) %this.controlcorrupt = 1;

}

function axisBomber::isDestroyed(%this)
{
%pl = client::getownedobject(%this.lastcontrolobject);

%vel = item::getvelocity(%this);
%trans = gamebase::getmuzzletransform(%this);

%right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);

%trans1 = "0 0 1 " @ %right @ " 0 1 0 " @ %muzzlepos;
%trans2 = "0 0 1 " @ vector::neg(%right) @ " 0 1 0 " @ %muzzlepos;
%trans3 = "0 0 1 " @ vector::neg(getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5)) @ " 0 1 0 " @ %muzzlepos;

Projectile::spawnProjectile("PlaneWing2", %trans1, %pl, %Vel); 
Projectile::spawnProjectile("PlaneWing2", %trans2, %pl, %Vel); 
Projectile::spawnProjectile("PlaneWing1", %trans3, %pl, %Vel);

for(%x = 0; %x < 15; %x++)
	Projectile::spawnProjectile("Fragexp" @ 1+floor(getrandom()*6), "0 1 0 " @ vector::getrandom() @ " 1 0 1 " @ getboxcenter(%this), %pl, %Vel); 

}
//--------------------------------------------------------
function plane::loop(%this)
{
if(!isObject(%this)) return; 
if(%this.weaponmode == 0) %weap = "Dual machineguns";
else %weap = "Heavy bomb";
if(GameBase::getdamagelevel(%this) >= GameBase::getdataname(%this).maxdamage) return;
if(%this.controlCorrupt > 0) 
	{
	Vehicle::CorruptControl(%this); //no more gamebase::virtual
	schedule("plane::loop(" @ %this @ ");", 0.2);
	%cl = GameBase::getcontrolClient(%this);
	%vel = Item::GetVelocity(%this);
	%speed = sqrt(getword(%vel,0)*getword(%vel,0)+getword(%vel,1)*getword(%vel,1)+getword(%vel,2)*getword(%vel,2));
	if(%cl > 0) bottomprint(GameBase::getcontrolClient(%this), "<jc>Velocity: <f2>" @ %speed*3.6 @ "km/h     <f0>Weapon:" @ %weap @ "\n<f2>Switch weapon key switches vehicles weapon.", 0.2,PLANE);		
	return;
	}
%vel = Item::GetVelocity(%this);
%speed = sqrt(getword(%vel,0)*getword(%vel,0)+getword(%vel,1)*getword(%vel,1)+getword(%vel,2)*getword(%vel,2));
if(%speed > 45) { Vehicle::CrashFix(%this); %cl = GameBase::getcontrolClient(%this); if(%cl > 0) bottomprint(GameBase::getcontrolClient(%this), "<jc>Velocity: <f2>" @ %speed*3.6 @ "km/h     <f0>Weapon:" @ %weap @ "\n<f2>Switch weapon key switches vehicles weapon.", 0.2,PLANE); schedule("plane::loop(" @ %this @ ");", 0.2); return; }
if(%speed < 6 && !GameBase::getLOSInfo(%this, 10, "-1.57079 0 0")) GameBase::SetDamageLevel(%this, GameBase::getDataname(%this).maxDamage);
%rot = GameBase::getRotation(%this);
if(GameBase::GetLosInfo(%this, 10, "-1.57079 0 0")) //Landing & Take off Sequence
	{
	%rotX = getword(%rot, 0);
	%rotY = getword(%rot, 1);
	%rotZ = getword(%rot, 2);
	if(%speed < 10) %newrot = "0.001 " @ %rotY @ " " @ %rotZ;
	else if(%speed < 50) %newrot = %rotX*0.9-%rotX*0.05 @ " " @ %rotY @ " " @ %rotZ;
	%dist = vector::getdistance(%newrot, %rot);
	if(%dist < 1.5) GameBase::SetRotation(%this, %newrot);
	}
else 
	{
	%rotX = getword(%rot, 0);
	%rotY = getword(%rot, 1);
	%rotZ = getword(%rot, 2);
	%x = (50 - %speed)/4;
	%newrot = (%rotX - %x/470) @ " " @ %rotY @ " " @ %rotZ;
	%dist = vector::getdistance(%newrot, %rot);
	if(%dist < 1.5) GameBase::SetRotation(%this, %newrot);
	}
%cl = GameBase::getcontrolClient(%this);

if(%cl > 0) bottomprint(GameBase::getcontrolClient(%this), "<jc>Velocity: <f2>" @ %speed*3.6 @ "km/h     <f0>Weapon:" @ %weap @ "\n<f2>Switch weapon key switches vehicles weapon.", 0.2,PLANE);		
schedule("plane::loop(" @ %this @ ");", 0.2);
}

function Vehicle::CorruptControl(%this)
{
%cl = gamebase::getcontrolclient(%this);
if(%cl != -1) %pl = Client::getOwnedObject(%cl);
%trans = GameBase::getMuzzleTransform(%this);
%vel = item::getvelocity(%this);
%speed = sqrt(getword(%vel,0)*getword(%vel,0)+getword(%vel,1)*getword(%vel,1)+getword(%vel,2)*getword(%vel,2));
if(%speed < 6 && !GameBase::getLOSInfo(%this, 10, "-1.57079 0 0")) GameBase::SetDamageLevel(%this, GameBase::getDataname(%this).maxDamage);

%t0 = getWord(%trans, 0);
%t1 = getWord(%trans, 1);
%t2 = getWord(%trans, 2);
%t3 = getWord(%trans, 3);
%t4 = getWord(%trans, 4);
%t5 = getWord(%trans, 5);
%t6 = getWord(%trans, 6);
%t7 = getWord(%trans, 7);
%t8 = getWord(%trans, 8);
%t9 = getWord(%trans, 9);
%t10 = getWord(%trans, 10);
%t11 = getWord(%trans, 11);

if(%this.controlcorrupt == 1)
	{
	%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11-2;
	%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
	%muzzlepos = vector::add(%muzzlepos, vector::multiply(vector::neg(%aimvector), "-3 -3 -3"));
	%transnew = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %muzzlepos;
	projectile::spawnprojectile("PlaneSmoke", %transnew, %pl, %vel);
	%rot = GameBase::getrotation(%this);
	%rotX = getword(%rot, 0);
	%rotY = getword(%rot, 1);
	%rotZ = getword(%rot, 2);
	if(%pl == "" || !(%cl > 0)) return;
	if(GameBase::getLosINFO(%this, "-1.57079 0 0")) if($los::object == 8) return;
	%rotX -= 0.004;
	%rotY += floor(getrandom()*0.001)- 0.0005;
	GameBase::SetRotation(%this, %rotX @ " " @ %rotY @ " " @ %rotZ);
	}

else if(%this.controlcorrupt == 2)
	{
	%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11-2;
	%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
	%muzzlepos = vector::add(%muzzlepos, vector::multiply(vector::neg(%aimvector), "-2 -2 -2"));
	%muzzlepos1 = vector::add(%muzzlepos, %t0*3 @ " " @ %t1*3 @ " " @ %t2*3);
	%muzzlepos2 = Vector::add(%muzzlepos, -%t0*3 @ " " @ -%t1*3 @ " " @ -%t2*3);
	%trans1 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %muzzlepos1;
	%trans2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %muzzlepos2;
	projectile::spawnprojectile("PlaneSmoke", %trans1, %pl, %vel);
	projectile::spawnprojectile("PlaneSmoke", %trans2, %pl, %vel);
	%rot = GameBase::getrotation(%this);
	%rotX = getword(%rot, 0);
	%rotY = getword(%rot, 1);
	%rotZ = getword(%rot, 2);
	if(%pl == "" || !(%cl > 0)) return;
	if(GameBase::getLosINFO(%this, "-1.57079 0 0")) if($los::object == 8) return;
	%rotX -= 0.015;
	%rotY += floor(getrandom()*0.005)- 0.0025;
	GameBase::SetRotation(%this, %rotX @ " " @ %rotY @ " " @ %rotZ);
	}
else if(%this.controlcorrupt == 3)
	{
	%muzzlepos = %t9 @ " " @ %t10 @ " " @ %t11-3;
	%aimvector = %t3 @ " " @ %t4 @ " " @ %t5;
	%muzzlepos = vector::add(%muzzlepos, vector::multiply(vector::neg(%aimvector), "-2 -2 -2"));
	%muzzlepos1 = vector::add(%muzzlepos, %t0*3 @ " " @ %t1*3 @ " " @ %t2*3);
	%muzzlepos2 = Vector::add(%muzzlepos, -%t0*3 @ " " @ -%t1*3 @ " " @ -%t2*3);
	%trans1 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %muzzlepos1;
	%trans2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %muzzlepos2;
	projectile::spawnprojectile("PlaneSmoke", %trans1, %pl, %vel);
	projectile::spawnprojectile("PlaneSmoke", %trans2, %pl, %vel);
	projectile::spawnprojectile("PlaneFire", %trans1, %pl, %vel);
	projectile::spawnprojectile("PlaneFire", %trans2, %pl, %vel);
	projectile::spawnprojectile("PlaneSmoke", %trans, %pl, %vel);
	projectile::spawnprojectile("PlaneFire", %trans, %pl, %vel);
	%rot = GameBase::getrotation(%this);
	%rotX = getword(%rot, 0);
	%rotY = getword(%rot, 1);
	%rotZ = getword(%rot, 2);
	if(%pl == "" || !(%cl > 0)) return;
	if(vector::getdistance("0 0 0", item::getvelocity(%this)) < 10) return;
	%rotX -= 0.017;
	%rotY += floor(getrandom()*0.006)- 0.003;
	schedule("GameBase::SetRotation(" @ %this @ ", " @ %rotX @ " @ \" \" @" @  %rotY @ " @ \" \" @" @  %rotZ @ ");", 0.2);
	%thebigsmoke = "0 1 0 " @ vector::neg(%aimvector) @ " 0 1 0 " @ vector::add(getboxcenter(%this), vector::multiply(vector::neg(%aimvector), "2 2 2"));
	if(%speed > 30 && getrandom() < 0.7) 
		projectile::spawnprojectile("HowitzerFire", %thebigsmoke, %pl, %vel);
		
	}
}
	

RocketData PlaneSmoke
{
        bulletShapeName = "breath.dts";
	explosionTag = Dust;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 0;
	damageValue = 0.0001;
	damageType = $AlliedFighter;		
	explosionRadius = 0.1;
	kickBackStrength = 0.1;
	muzzleVelocity = 0.1;
	terminalVelocity = 0.1;
	acceleration = 0.0;
	totalTime = 0.05;
	liveTime = 0.05;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData PlaneFire
{
        bulletShapeName = "breath.dts";
	explosionTag = Fire;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 0;
	damageValue = 0.0001;
	damageType = $AlliedFighter;		
	explosionRadius = 0.1;
	kickBackStrength = 0.1;
	muzzleVelocity = 0.1;
	terminalVelocity = 0.1;
	acceleration = 0.0;
	totalTime = 0.02;
	liveTime = 0.02;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//---------------------------------------------
ItemImageData planesetupImage
{
	shapeFile = "anten_lava";
	mountPoint = 0;
	mountoffset = { -0.5, -4.5, -1.1 };
	mountrotation = { 0, 1.57079, 1.57079 };
	weaponType = 0; // 
	
	accuFire = true;

	
};

ItemData PlaneSetup
{
	description = "PPSH41";
	className = "Weapon";
	shapeFile = "anten_lava";
   validateShape = true;
	
   
	shadowDetailMask = 4;
	imageType = PlanesetupImage;
	price = 200;
	showWeaponBar = false;
};

ItemImageData planesetup2Image
{
	shapeFile = "anten_lava";
	mountPoint = 0;
	mountoffset = { -0.5, 3, -1.3 };
	mountrotation = { 1.57079, 0, -1.57079 };
	weaponType = 0; // 
	
	accuFire = true;

	
};

ItemData PlaneSetup2
{
	description = "PPSH41";
	className = "Weapon";
	shapeFile = "anten_lava";
   validateShape = true;
	
   
	shadowDetailMask = 4;
	imageType = Planesetup2Image;
	price = 200;
	showWeaponBar = false;
};

ItemImageData planesetup3Image
{
	shapeFile = "anten_lava";
	mountPoint = 0;
	mountoffset = { -0.5, 3, -1.3 };
	mountrotation = { -1.57079, 0, -1.57079 };
	weaponType = 0; // 
	
	accuFire = true;

	
};

ItemData PlaneSetup3
{
	description = "PPSH41";
	className = "Weapon";
	shapeFile = "anten_lava";
   validateShape = true;
	
   
	shadowDetailMask = 4;
	imageType = Planesetup3Image;
	price = 200;
	showWeaponBar = false;
};


//--------------------------------------
ItemImageData Bombersetup3Image
{
	shapeFile = "flyer";
	mountPoint = 0;
	mountoffset = { 4.8, 2.5, -1.8 };
	mountrotation = { 0, 0, -1.57079 };
	weaponType = 0; // 
	
	accuFire = true;

	
};

ItemData BomberSetup3
{
	description = "PPSH41";
	className = "Weapon";
	shapeFile = "flyer";
   validateShape = true;
	
   
	shadowDetailMask = 4;
	imageType = Bombersetup3Image;
	price = 200;
	showWeaponBar = false;
};

ItemImageData Bombersetup2Image
{
	shapeFile = "flyer";
	mountPoint = 0;
	mountoffset = { -5.5, 2.5, -1.8 };
	mountrotation = { 0, 0, 1.57079 };
	weaponType = 0; // 
	
	accuFire = true;

	
};

ItemData BomberSetup2
{
	description = "PPSH41";
	className = "Weapon";
	shapeFile = "flyer";
   validateShape = true;
	
   
	shadowDetailMask = 4;
	imageType = Bombersetup2Image;
	price = 200;
	showWeaponBar = false;
};

function Vehicle::CrashFix(%this)
{
%speed = 1.5*vector::getdistance(Item::getvelocity(%this), "0 0 0");
%los = gamebase::getLOSInfo(%this, %speed/5+1);
if(%los)
	{
	%type = getobjecttype($los::object);
	if(%type != "Player" && %type != "vehicle")
	eval(gamebase::getdataname(%this) @ "::onDamage(" @ %this @ "," @  $ImpactDamageType @ ", 5);");
	}
%los = gamebase::getLOSInfo(%this, sqrt(pow(%speed/5+1,2) + 2.25), "0 0 " @ tans(2.25/sqrt(pow(%speed/5+1,2) + 2.25), r));
if(%los)
	{
	%type = getobjecttype($los::object);
	if(%type != "Player" && %type != "vehicle")
	eval(gamebase::getdataname(%this) @ "::onDamage(" @ %this @ "," @  $ImpactDamageType @ ", 5);");
	}
%los = gamebase::getLOSInfo(%this, sqrt(pow(%speed/5+1,2) + 2.25), "0 0 " @ -tans(2.25/sqrt(pow(%speed/5+1,2) + 2.25), r));
if(%los)
	{
	%type = getobjecttype($los::object);
	if(%type != "Player" && %type != "vehicle")
	eval(gamebase::getdataname(%this) @ "::onDamage(" @ %this @ "," @  $ImpactDamageType @ ", 5);");
	}
 
}
