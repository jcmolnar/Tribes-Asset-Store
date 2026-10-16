//----------------Sherman - British Light Tank------------
FlierData ShermanTank
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc";
  // shieldShapeName = "shield_large";
   mass = 2000;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.4;
   maxPitch = 1;
   maxSpeed = 9.72;
   minSpeed = -9.72;
	lift = 0;
	maxAlt = 15;
	maxVertical = 0.0001;
	maxDamage = 5.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.1;

	groundDamageScale = 0.0001;

	repairRate = 0;
	ramDamage = 0.1;
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
	idleSound = SoundTankIdle;
	moveSound = SoundFlyerActive;
	minDamageSpeed = 1;
	visibleDriver = true;
	driverPose = 23;
	description = "Sherman";
};

function ShermanTank::onAdd(%this)
{

schedule("if(" @ %this @ ".respawned == 1) Vehicle::onAdd(" @ %this @ ",1);", 0.2);
gamebase::setteam(%this, 0);
%trans = gamebase::getmuzzletransform(%this);
%this.aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans,5);
tank::update(%this);
//%this.spawnpos = GameBase::getPosition(%this);
//%this.spawnrot = GameBase::getRotation(%this);
//%this.weaponmode = 0; //0 Gun 1 Bomb
AI::spawn("TankService" @ %this, soldier, "0 0 -700", "0 0 0", "Allied Sherman Tank", "male2" );
%id = ai::getid("TankService" @ %this);
client::setinitialteam(%id, gamebase::getteam(%this));
gamebase::setteam(%id, gamebase::getteam(%this));
player::setmountobject(%id, %this, 1);
player::Setitemcount(%id, ShermanTankSetup2, 1);
player::mountitem(%id, ShermanTankSetup2, 0);
player::Setitemcount(%id, ShermanTankSetup, 1);
player::mountitem(%id, ShermanTankSetup, 1);
%this.tankguy = client::getownedobject(%id);
client::getownedobject(%id).vehicle = %this;

} 



ItemImageData ShermanTankSetupImage
{
	shapeFile = "anten_small";
	mountPoint = 0;
	mountOffset = { -0.7, 10, 0 };
	mountRotation = { 1.57079, 0, 0 };
	
};

ItemData ShermanTankSetup
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "anten_small";
	imageType = ShermanTankSetupImage;
	showWeaponBar = false;
};

ItemImageData ShermanTankSetup2Image
{
	shapeFile = "flagstand";
	mountPoint = 0;
	mountOffset = { -1.7, 4, 0.2 };
	mountRotation = { 1.17079, 0, 3.14159 };
	
};
ItemData ShermanTankSetup2
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "flagstand";
	imageType = ShermanTankSetup2Image;
	showWeaponBar = false;
};
ItemImageData ShermanTankSetup3Image
{
	shapeFile = "flagstand";
	mountPoint = 0;
	mountOffset = { 0.3, 4, 0.2 };
	mountRotation = { 1.17079, 0, 3.14159 };
	
};
ItemData ShermanTankSetup3
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "flagstand";
	imageType = ShermanTankSetup3Image;
	showWeaponBar = false;
};
ItemImageData ShermanTankSetup4Image
{
	shapeFile = "dsply_h1";
	mountPoint = 0;
	mountOffset = { -2.4, 2, -1.1 };
	mountRotation = { 0, -0.1, 1.57079 };
	
};
ItemData ShermanTankSetup4
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "dsply_h1";
	imageType = ShermanTankSetup4Image;
	showWeaponBar = false;
};
ItemImageData ShermanTankSetup5Image
{
	shapeFile = "dsply_h1";
	mountPoint = 0;
	mountOffset = { 1, 2, -1.1 };
	mountRotation = { 0, -0.1, 1.57079 };
	
};
ItemData ShermanTankSetup5
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "dsply_h1";
	imageType = ShermanTankSetup5Image;
	showWeaponBar = false;
};
ItemImageData ShermanTankSetup6Image
{
	shapeFile = "dsply_h1";
	mountPoint = 0;
	mountOffset = { -0.7, 0, -1.3 };
	mountRotation = { 0, 0, 0 };
	
};
ItemData ShermanTankSetup6
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "dsply_h1";
	imageType = ShermanTankSetup6Image;
	showWeaponBar = false;
};
ItemImageData ShermanTankSetup7Image
{
	shapeFile = "generator";
	mountPoint = 0;
	mountOffset = { -2.05, 2.1, 0.3 };
	mountRotation = { 3.44159, 1.57079, 0 };
	
};
ItemData ShermanTankSetup7
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "generator";
	imageType = ShermanTankSetup7Image;
	showWeaponBar = false;
};
function ShermanTankSetup2::onMount(%player)
{
player::mountitem(%player, ShermanTankSetup3, 2);
player::mountitem(%player, ShermanTankSetup4, 3);
player::mountitem(%player, ShermanTankSetup5, 4);
player::mountitem(%player, ShermanTankSetup6, 5);
player::mountitem(%player, ShermanTankSetup7, 6);
}

function ShermanTank::isDamage(%this, %type, %val)
{
if(getdamagetype(%type) != "exp") %val = %val / 30;
else %val /= 1.6;
%dlevel = gamebase::getdamagelevel(%this);
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel+%val);

}

GrenadeData ShermanTankShell
{	bulletShapeName = "breath.dts";
	explosionTag = bombexp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.2;
	damageClass = 4;
	damageValue = 1.8;
	damageType = $ShermanTank;
	explosionRadius = 14;
	kickBackStrength = 50;
	maxLevelFlightDist = 1300;
	totalTime = 12;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 0.1;
};

function ShermanTank::onFire(%this)
{
if(%this.cantfire == 1) return;
%trans = gamebase::getmuzzletransform(%this);
%vel = item::getvelocity(%this);
%owner = gamebase::getcontrolclient(%this);

%vecforward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);


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
%newmuzzlepos2 = vector::add(%muzzlepos, vector::multiply(%vecforward, "12.5 12.5 12.5"));
%newmuzzlepos = vector::add(%muzzlepos, vector::multiply(%vecforward, "8 8 8"));
%transnew = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %this.aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %newmuzzlepos;
%transnew2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %this.aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %newmuzzlepos2;

Projectile::spawnProjectile("ShermanTankShell", %transnew, client::getownedobject(gamebase::getcontrolclient(%this)), %Vel); 
Projectile::spawnProjectile("HowitzerFire", %transnew2, client::getownedobject(gamebase::getcontrolclient(%this)), %Vel); 
%this.cantfire = 1;
schedule(%this @ ".cantfire = 0;",4,%this);
}

function shermanTank::isDestroyed(%this)
{
ai::delete("TankService" @ %this);
}






//----------------Panzer - German Light Tank------------
FlierData PanzerTank
{
	explosionId = BombExp;
	debrisId = VehicleDebris;
	className = "Vehicle";
   shapeFile = "hover_apc";
  // shieldShapeName = "shield_large";
   mass = 2000;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.4;
   maxPitch = 1;
   maxSpeed = 10.72;
   minSpeed = -10.72;
	lift = 0;
	maxAlt = 15;
	maxVertical = 0.0001;
	maxDamage = 4.9;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.2;

	groundDamageScale = 0.0001;

	repairRate = 0;
	ramDamage = 0.1;
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
	idleSound = SoundTankIdle;
	moveSound = SoundFlyerActive;
	minDamageSpeed = 1;
	visibleDriver = true;
	driverPose = 23;
	description = "PanzerIV";
};

function PanzerTank::onAdd(%this)
{

schedule("if(" @ %this @ ".respawned == 1) Vehicle::onAdd(" @ %this @ ",1);", 0.2);
gamebase::setteam(%this, 1);
%trans = gamebase::getmuzzletransform(%this);
%this.aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans,5);
tank::update(%this);

AI::spawn("TankService" @ %this, soldier, "0 0 -700", "0 0 0", "Axis PanzerIV Tank", "male2" );
%id = ai::getid("TankService" @ %this);
client::setinitialteam(%id, gamebase::getteam(%this));
gamebase::setteam(%id, gamebase::getteam(%this));
player::setmountobject(%id, %this, 1);
player::Setitemcount(%id, PanzerTankSetup2, 1);
player::mountitem(%id, PanzerTankSetup2, 0);
player::Setitemcount(%id, PanzerTankSetup, 1);
player::mountitem(%id, PanzerTankSetup, 1);
%this.tankguy = client::getownedobject(%id);
client::getownedobject(%id).vehicle = %this;

} 



ItemImageData PanzerTankSetupImage
{
	shapeFile = "anten_small";
	mountPoint = 0;
	mountOffset = { -0.7, 10, 0 };
	mountRotation = { 1.57079, 0, 0 };
	
};

ItemData PanzerTankSetup
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "anten_small";
	imageType = PanzerTankSetupImage;
	showWeaponBar = false;
};

ItemImageData PanzerTankSetup2Image
{
	shapeFile = "hellfiregun";
	mountPoint = 0;
	mountOffset = { -0.6, 3, 0 };
	mountRotation = { 0,3.14159,3.14159 };
	
};
ItemData PanzerTankSetup2
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "force";
	imageType = PanzerTankSetup2Image;
	showWeaponBar = false;
};

ItemImageData PanzerTankSetup4Image
{
	shapeFile = "teleport_square";
	mountPoint = 0;
	mountOffset = { -1.7, 2, -1.1 };
	mountRotation = { 0, 0, 1.57079 };
	
};
ItemData PanzerTankSetup4
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "teleport_square";
	imageType = PanzerTankSetup4Image;
	showWeaponBar = false;
};
ItemImageData PanzerTankSetup5Image
{
	shapeFile = "teleport_square";
	mountPoint = 0;
	mountOffset = { 0.5, 2, -1.1 };
	mountRotation = { 0, 0, 1.57079 };
	
};
ItemData PanzerTankSetup5
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "teleport_square";
	imageType = PanzerTankSetup5Image;
	showWeaponBar = false;
};
ItemImageData PanzerTankSetup6Image
{
	shapeFile = "teleport_square";
	mountPoint = 0;
	mountOffset = { -0.6, 1, -1.1 };
	mountRotation = { 0, 0, 0 };
	
};
ItemData PanzerTankSetup6
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "teleport_square";
	imageType = PanzerTankSetup6Image;
	showWeaponBar = false;
};
ItemImageData PanzerTankSetup7Image
{
	shapeFile = "solar_med";
	mountPoint = 0;
	mountOffset = { -0.6, 5.5, -1.4 };
	mountRotation = { 0, 0, 3.14159 };
	
};
ItemData PanzerTankSetup7
{
	description = "hmm..........";
	className = "tool";
	shapeFile = "solar_med";
	imageType = PanzerTankSetup7Image;
	showWeaponBar = false;
};
function PanzerTankSetup2::onMount(%player)
{

player::mountitem(%player, PanzerTankSetup4, 3);
player::mountitem(%player, PanzerTankSetup5, 4);
player::mountitem(%player, PanzerTankSetup6, 5);
player::mountitem(%player, PanzerTankSetup7, 6);
}

function PanzerTank::isDamage(%this, %type, %val)
{
if(getdamagetype(%type) != "exp") %val = %val / 30;
else %val /= 1.6;
%dlevel = gamebase::getdamagelevel(%this);
%dlevel = %dlevel + %val;
gamebase::setdamagelevel(%this, %dlevel+%val);

}

GrenadeData PanzerTankShell
{	bulletShapeName = "breath.dts";
	explosionTag = bombexp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.2;
	damageClass = 4;
	damageValue = 1.4;
	damageType = $PanzerTank;
	explosionRadius = 12;
	kickBackStrength = 50;
	maxLevelFlightDist = 2000;
	totalTime = 12;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 0.1;
};

function PanzerTank::onFire(%this)
{
if(%this.cantfire == 1) return;
%trans = gamebase::getmuzzletransform(%this);
%vel = item::getvelocity(%this);
%owner = gamebase::getcontrolclient(%this);

%vecforward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%muzzlepos = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);


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
%newmuzzlepos2 = vector::add(%muzzlepos, vector::multiply(%vecforward, "12.5 12.5 12.5"));
%newmuzzlepos = vector::add(%muzzlepos, vector::multiply(%vecforward, "8 8 8"));
%transnew = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %this.aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %newmuzzlepos;
%transnew2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %this.aimvector @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ %newmuzzlepos2;

Projectile::spawnProjectile("PanzerTankShell", %transnew, client::getownedobject(gamebase::getcontrolclient(%this)), %Vel); 
Projectile::spawnProjectile("PakFire", %transnew2, client::getownedobject(gamebase::getcontrolclient(%this)), %Vel); 
%this.cantfire = 1;
schedule(%this @ ".cantfire = 0;",3.1,%this);
}

function PanzerTank::isDestroyed(%this)
{
ai::delete("TankService" @ %this);
}