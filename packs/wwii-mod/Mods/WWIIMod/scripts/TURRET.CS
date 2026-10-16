//-------------------------------------------------------------------------------																					 
//=================================MG42 Gun======================================

BulletData MG42Fire
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = smallbullet;

   damageClass        = 0;
   damageValue        = 0;
   damageType         = $nothing;

   muzzleVelocity     = 600.0;
   totalTime          = 0.01;
   liveTime           = 0.01;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData MG42Bullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = mediumbullet;
   expRandCycle       = 2;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.433;
   damageType         = $MG42;

    aimDeflection      = 0.008;
   muzzleVelocity     = 1600.9;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};
	
																					 
TurretData MG42	   
{			 
	className = "Turret";
	shapeFile = "chainturret"; //gunturret
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 0.1;
	reloadDelay = 0.078;
	speed = 5.0;
	speedModifier = 1.0;
	range = 160;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrislarge;
	shieldShapeName = "shield";
	//fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExplarge;
	description = "MG42";
};

function enableturret(%id)
{
%id.canfire = true;
}

function MG42::onFire(%this)
{
if(!%this.canfire) return;
%owner = gamebase::getcontrolclient(%this);
%Trans = GameBase::getMuzzleTransform(%this); 
%Vel = Item::getVelocity(%this); 
%this.canfire = false;
schedule("enableturret(" @ %this @ ");", 0.078);
gamebase::playsound(%this, debrisMediumExplosion, 3);
gamebase::playsound(%this, shockExplosion, 1);
//WWII::HeavyGunFire("MG42", %this);
		
Projectile::spawnProjectile("MG42Bullet", %trans, %owner.pl, %Vel); 
Projectile::spawnProjectile("MG42fire", %trans, %this, %Vel); 
}

function MG42::onMount(%turret, %player)
{
bottomprint(player::getclient(%player), "<jc><f2>You are currently controlling a stationary gun.\nPress space(jump) to stop control.", 5,TURRET);

%turretpos = GameBase::getposition(%turret);
%playerpos = GameBase::getPosition(%player);

%playerX = getword(%playerpos, 0);
%playerY = getword(%playerpos, 1);
%playerZ = getword(%playerpos, 2);


%vectoturret = Vector::Sub(%turretpos, %playerpos);
%normalized = Vector::normalize(%vectoturret);
%a = getword(%normalized, 0);
%b = getword(%normalized, 1);
%c = getword(%normalized, 2);
%normalized = vector::multiply(%normalized, "-1.2 -1.2 1.2");


%newvec = Vector::sub(%vectoturret, Vector::neg(%normalized));

%newpos = vector::add(%playerpos, %newvec);
%newpos = getword(%newpos, 0) @ " " @ getword(%newpos, 1) @ " " @ %playerZ; 
Gamebase::setposition(%player, %newpos);
}

function mg42::onDamage(%this, %type, %val)
{
if(getdamagetype(%type) == bullet) return;
%dlevel = gamebase::getdamagelevel(%this);
if(%val+%dlevel > mg42.maxdamage) gamebase::setdamagelevel(%this, mg42.maxdamage);
else gamebase::setdamagelevel(%this, %dlevel+%val);
}
function mg42::onDestroyed(%this)
{
%pl = WWII::RandomPlayer();
for(%x = 0; %x < 2+floor(getrandom()*3); %x++)
	{
	%a = getrandom()-0.5;
	%b = getrandom()-0.5;
	%c = getrandom()+0.5;
	%vector = %a @ " " @ %b @ " " @ %c;
	%vector = vector::normalize(%vector);
	%trans = "0 0 0 " @ %vector @ " 0 0 0 " @ vector::add(gamebase::getposition(%this), "0 0 2");
	%g = floor(getrandom()*3)+1;
	//echo(%g,%a,%b);
	if(%g == 1) projectile::spawnprojectile("fragexp1", %trans, %pl, "0 0 -10");
	else if(%g == 2) projectile::spawnprojectile("fragexp2", %trans, %pl, "0 0 -10");
	else projectile::spawnprojectile("fragexp3", %trans, %pl, "0 0 -10");
	}
%group = getgroup(%this); %trans = gamebase::gettransform(%this);
schedule("gamebase::startfadeout(" @ %this @ ");", 10);
schedule("deleteobject(" @ %this @ ");", 15);
schedule("Turret::Respawn(mg42,\"" @ %group @ "\",\"" @ %trans @ "\"," @ gamebase::getteam(%this) @ ");", $WWII::RespawnDelay);
}
//-------------------------------------------------------------------------------																					 
//==============================Browning Gun=====================================
BulletData BrowningFire
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = smallbullet;

   damageClass        = 0;
   damageValue        = 0;
   damageType         = $nothing;

   muzzleVelocity     = 600.0;
   totalTime          = 0.01;
   liveTime           = 0.01;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData BrowningBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = Heavybullet;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.45;
   damageType         = $browning;

    aimDeflection      = 0.006;
   muzzleVelocity     = 2000.9;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};

GrenadeData BrowningBT
{	
	bulletShapeName = "force.dts";
	explosionTag = bullet;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.2;
	damageClass = 4;
	damageValue = 0.05;
	damageType = $nothing;
	explosionRadius = 0.1;
	kickBackStrength = 0.4;
	maxLevelFlightDist = 5;
	totalTime = 12;
	liveTime = 1.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 0.1;
};


TurretData Browning
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	maxDamage = 2;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 0.1;
	reloadDelay = 0.13;
	speed = 4.0;
	speedModifier = 1.5;
	range = 160;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrislarge;
	//fireSound = DebrislargeExplosion;
	explosionId = debrisexplarge;
	description = "Browning";
	damageSkinData = "objectDamageSkins";
};

function Browning::onFire(%this)
{
if(!%this.canfire) return;
%owner = gamebase::getcontrolclient(%this);
%Trans = GameBase::getMuzzleTransform(%this); 
%Vel = Item::getVelocity(%this); 
%this.canfire = false;
schedule("enableturret(" @ %this @ ");", 0.13);
gamebase::playsound(%this, debrisLargeExplosion, 3);
gamebase::playsound(%this, debrissmallExplosion, 1);
		
//WWII::HeavyGunFire("Browning", %this);
		%pos1=getWord(%trans,0);
		%pos2=getWord(%trans,1);
		%pos3=getWord(%trans,2);
		%pos4=%pos1;
		%pos5=%pos2;
		%pos6=%pos3;
		%pos7=getWord(%trans,6);
		%pos8=getWord(%trans,7);
		%pos9=getWord(%trans,8);
		%pos10=getWord(%trans,9);
		%pos11=getWord(%trans,10);
		%pos12=getWord(%trans,11);
		
		%trans2=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
		
Projectile::spawnProjectile("Browningbullet", %trans, %owner.pl, %Vel); 
Projectile::spawnProjectile("Browningfire", %trans, %this, %Vel); 
Projectile::spawnProjectile("BrowningBT", %trans2, %this, %Vel); 
}
																					 
function Browning::onDamage(%this, %type, %val)
{
if(getdamagetype(%type) == bullet) return;
%dlevel = gamebase::getdamagelevel(%this);
if(%val+%dlevel > browning.maxdamage) gamebase::setdamagelevel(%this, browning.maxdamage);
else gamebase::setdamagelevel(%this, %dlevel+%val);
}

function Browning::onDestroyed(%this)
{
%pl = WWII::RandomPlayer();
for(%x = 0; %x < 2+floor(getrandom()*3); %x++)
	{
	%a = getrandom()-0.5;
	%b = getrandom()-0.5;
	%c = getrandom()+0.5;
	%vector = %a @ " " @ %b @ " " @ %c;
	%vector = vector::normalize(%vector);
	%trans = "0 0 0 " @ %vector @ " 0 0 0 " @ vector::add(gamebase::getposition(%this), "0 0 2");
	%g = floor(getrandom()*3)+1;
	//echo(%g,%a,%b);
	if(%g == 1) projectile::spawnprojectile("fragexp1", %trans, %pl, "0 0 -10");
	else if(%g == 2) projectile::spawnprojectile("fragexp2", %trans, %pl, "0 0 -10");
	else projectile::spawnprojectile("fragexp3", %trans, %pl, "0 0 -10");
	}
%group = getgroup(%this); %trans = gamebase::gettransform(%this);
schedule("deleteobject(" @ %this @ ");", 2);
schedule("Turret::Respawn(browning,\"" @ %group @ "\",\"" @ %trans @ "\"," @ gamebase::getteam(%this) @ ");", $WWII::RespawnDelay);
}

function Browning::onAdd(%this)
{
	%this.canfire = true;
	schedule("Browning::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Browning");
	}
	Browning::onEnabled(%this); 
}

function Browning::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function Browning::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}



function Browning::onPower(%this,%power,%generator) {}
function Browning::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


function Browning::onMount(%turret, %player)
{
bottomprint(player::getclient(%player), "<jc><f2>You are currently controlling a stationary gun.\nPress space(jump) to stop control.", 5,TURRET);
%turretpos = GameBase::getposition(%turret);
%playerpos = GameBase::getPosition(%player);

%playerX = getword(%playerpos, 0);
%playerY = getword(%playerpos, 1);
%playerZ = getword(%playerpos, 2);


%vectoturret = Vector::Sub(%turretpos, %playerpos);
%normalized = Vector::normalize(%vectoturret);
%a = getword(%normalized, 0);
%b = getword(%normalized, 1);
%c = getword(%normalized, 2);
%normalized = vector::multiply(%normalized, "-0.6 -0.6 0.6");


%newvec = Vector::sub(%vectoturret, Vector::neg(%normalized));

%newpos = vector::add(%playerpos, %newvec);
%newpos = getword(%newpos, 0) @ " " @ getword(%newpos, 1) @ " " @ %playerZ; 
Gamebase::setposition(%player, %newpos);
}


//-------------------------------------------------------------------------------																					 
//=====================Howitzer - US Coastal defence gun=========================

RocketData HowitzerBomb
{
	bulletShapeName = "bullet.dts";
	explosionTag = BigBombExp;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 1;
	damageValue = 2.4;
	damageType = $howitzer;		
	explosionRadius = 12;
	kickBackStrength = 100.0;
	muzzleVelocity = 300.0;
	terminalVelocity = 300.0;
	acceleration = 100.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

RocketData HowitzerFire
{
        bulletShapeName = "bullet.dts";
	explosionTag = MineExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 0;
	damageValue = 0.1;
	damageType = $explosion;		
	explosionRadius = 1;
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

StaticShapeData GunPart1
{
   description = "gun part 1";
	shapeFile = "flagstand";
	visibleToSensor = false;
	maxdamage = 9999999;
};

StaticShapeData GunPart99
{
   description = "never mind";
	shapeFile = "anten_small";
	visibleToSensor = false;
	maxdamage = 9999999;
};

TurretData Howitzer   
{			 
	className = "Turret";
	shapeFile = "mortar_turret";
	maxDamage = 4;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 6;
	//projectiletype = yBazookashell;
	reloadDelay = 9;
	speed = 0.13;
	speedModifier = 0.13;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 15;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	shieldShapeName = "shield";
	fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = bigbombexp;
	description = "105mm Howitzer Mk II";
};

function Howitzer::onFire(%this)
{
if(!%this.canfire) return;
%owner = gamebase::getcontrolclient(%this);
%Trans = GameBase::getMuzzleTransform(%this); 
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);
%Vel = Item::getVelocity(%this); 
%this.canfire = false;
schedule("enableturret(" @ %this @ ");", 5.078);
gamebase::playsound(%this, shockexplosion, 3);
//WWII::HeavyGunFisre("MG42", %this);

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

%trans2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ vector::sub(%vec_forward,vector::multiply(vector::getrandom(), "0.01 0.01 0.01"))  @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(GameBase::getPosition($HowitzerPart[%this, 3]), vector::multiply(%vec_forward, "0.7 0.7 0.7"));		
Projectile::spawnProjectile("HowitzerBomb", %trans2, client::getownedobject(%owner), %Vel); 
Projectile::spawnProjectile("HowitzerFire", %trans2, %this, %Vel); 
}

function Howitzer::onAdd(%this) { %this.canfire = true; schedule("Howitzer::Setup(" @ %this @ ");", 3); }

function Howitzer::setup(%this)
{
%this.canfire = true;
%gunpos = gamebase::getposition(%this);
%group = "MissionCleanup"; //getGroup(%this);
%trans = gamebase::getmuzzletransform(%this);
%Vec_right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%Vec_left = vector::neg(%vec_right);
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);
%gunrot = vector::add(Vector::getRotation(%Vec_forward), "1.57079 0 0"); 
//------------------------------------------------------------------------
%gunpart1 = NewObject("Gunpart1", "StaticShape", GunPart1, True);
addToSet(%group, %gunpart1);
if($HowitzerPart[%this, 1] > 0) deleteObject($HowitzerPart[%this, 1]);
$HowitzerPart[%this, 1] = %gunpart1;

%gunpart2 = NewObject("Gunpart2", "StaticShape", GunPart1, True);
addToSet(%group, %gunpart2);
if($HowitzerPart[%this, 2] > 0) deleteObject($HowitzerPart[%this, 2]);
$HowitzerPart[%this, 2] = %gunpart2;

%gunpart99 = NewObject("Gunpart99", "StaticShape", GunPart99, True);
addToSet(%group, %gunpart99);
if($HowitzerPart[%this, 3] > 0) deleteObject($HowitzerPart[%this, 3]);
$HowitzerPart[%this, 3] = %gunpart99;

%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 0.133"), vector::multiply(%Vec_forward, "-0.25 -0.25 -0.25")), vector::multiply(%vec_Left, "1.2 1.2 1.2"));
gamebase::setposition(%gunpart1, %curpos);
gamebase::setrotation(%gunpart1, vector::add(%gunrot, "0 1.57079 1.84997"));

%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 0.133"), vector::multiply(%Vec_forward, "-0.285 -0.285 -0.285")), vector::multiply(%vec_Right, "1.2 1.2 1.2"));
gamebase::setposition(%gunpart2, %curpos);
gamebase::setrotation(%gunpart2, vector::add(%gunrot, "0 1.57079 1.13998"));

%curpos = vector::add(vector::add(%vec_muzzle, "0 0 0.895"), vector::multiply(%vec_forward, "7.1 7.1 7.1"));
gamebase::setposition(%gunpart99, %curpos);
gamebase::setrotation(%gunpart99, vector::add(%gunrot, "0 1.57079 -1.57079"));

schedule("gamebase::setactive(" @ %this @ ", 0);", 1);
}

function Howitzer::onMount(%this, %player)
{
//if(isObject($HowitzerPart[%this, 12])) deleteObject($HowitzerPart[%this, 12]);
//if(isObject($HowitzerPart[%this, 22])) deleteObject($HowitzerPart[%this, 22]);
Howitzer::SystemMove(%this);
bottomprint(player::getclient(%player), "<jc><f2>You are currently controlling a <f1>heavy stationary weapon.<f2>\nPress space(jump) to observe or press it twice to stop control.", 10,TURRET);
Player::getclient(%player).turret = %this;

}

function Howitzer::SystemMove(%this)
{
if(GameBase::getControlClient(%this) == -1) return; //check if turret might move

%trans = GameBase::getMuzzleTransform(%this);
%Vec_right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%Vec_left = vector::neg(%vec_right);
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5); //brake the muzzle 
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11); //trans apart.

%gunpos = GameBase::getPosition(%this); //Get the turrets transform
%gunrot = vector::add(Vector::getRotation(%Vec_forward), "1.57079 0 0"); 

//Move gun part I
%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 0.234"), vector::multiply(%Vec_forward, "-0.25 -0.25 0")), vector::multiply(%vec_Left, "1.2 1.2 0"));
%curpos = getWord(%curpos, 0) @ " " @ getWord(%curpos, 1) @ " " @ getword(%gunpos, 2) + 1;
gamebase::setposition($HowitzerPart[%this, 1], %curpos);
gamebase::setrotation($HowitzerPart[%this, 1], vector::add(%gunrot, -getWord(%gunrot, 0) @ " 1.57079 1.84997"));

//Move gun part II                                             //1.234
%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 0.234"), vector::multiply(%Vec_forward, "-0.285 -0.285 0")), vector::multiply(%vec_Right, "1.2 1.2 0"));
%curpos = getWord(%curpos, 0) @ " " @ getWord(%curpos, 1) @ " " @ getword(%gunpos, 2) + 1;
gamebase::setposition($HowitzerPart[%this, 2], %curpos);
gamebase::setrotation($HowitzerPart[%this, 2], vector::add(%gunrot, -getWord(%gunrot, 0) @ " 1.57079 1.13998"));

//Move gun part III (the turret)
%curpos = vector::add(vector::add(%vec_muzzle, "0 0 0.3"), vector::multiply(%vec_forward, "7.1 7.1 7.1"));
gamebase::setposition($HowitzerPart[%this, 3], %curpos);
gamebase::setrotation($HowitzerPart[%this, 3], vector::add(%gunrot, -getWord(%gunrot, 0) @ " " @ 1.57079+getWord(%gunrot, 0)  @ " -1.57079"));

schedule("Howitzer::SystemMove(" @ %this @ ");", 0.3); //Loop the system move...
}

function Howitzer::Jump(%this)
{
%cl = GameBase::getControlClient(%this);
%cl.jump = 1;

%trans = GameBase::getMuzzleTransform(%this);
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11); 
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5); 

%campos = vector::add(%vec_muzzle, vector::multiply(%vec_forward, "8 8 8"));
%camrot = vector::add(vector::getrotation(%vec_forward), "1.57079 0 0");

client::setcontrolObject(%cl, client::getobserverCamera(%cl));
Observer::setFlyMode(%cl, %campos, %camrot, false, false);

schedule("if(" @ %cl @ ".jump == 1) { client::setcontrolobject(" @ %cl @ "," @ %this @ "); Howitzer::SystemMove(" @ %this @ "); " @ %cl @ ".jump = 0; }", 2);
}
function Howitzer::onDamage(%this, %type, %val)
{
if(getdamagetype(%type) == bullet) return;
%dlevel = gamebase::getdamagelevel(%this);
if(%dlevel >= 4) return;
if(%val+%dlevel > howitzer.maxdamage) gamebase::setdamagelevel(%this, howitzer.maxdamage);
else gamebase::setdamagelevel(%this, %dlevel+%val);
}

function Howitzer::onDestroyed(%this)
{
GameBase::applyRadiusDamage($Explosion, vector::add(getBoxCenter(%this), "0 0 3"), 6, 2,10,%this);
%def1 = $HowitzerPart[%this, 1];
%def2 = $HowitzerPart[%this, 2];
%pos1 = gamebase::getposition(%def1);
%pos2 = gamebase::getposition(%def2);
%turret = $howitzerpart[%this, 3];
%pl = WWII::RandomPlayer();
for(%x = 0; %x < 6+floor(getrandom()*4); %x++)
	{
	%a = getrandom()-0.5;
	%b = getrandom()-0.5;
	%c = getrandom()+0.5;
	%vector = %a @ " " @ %b @ " " @ %c;
	%vector = vector::normalize(%vector);
	%trans = "0 0 0 " @ %vector @ " 0 0 0 " @ vector::add(gamebase::getposition(%this), "0 0 2");
	%g = floor(getrandom()*6) +2;
	//echo(%g,%a,%b);
	if(%g > 6) %g = 6; %block = "fragexp" @ %g; 
	//echo(%block);
	projectile::spawnprojectile(%block, %trans, %pl, "0 0 -10");
	}
%matrix = gamebase::getmuzzletransform(%this);
%a = getword(%matrix, 3); %b = getword(%matrix, 4); %c = getword(%matrix, 5);
%a += getrandom()-0.5; %b += getrandom()-0.5; %c += getrandom()/2;
schedule("deleteobject(" @ %def1 @ ");",0.2);
%newtrans = "0 0 0 " @ vector::normalize(%a @ " " @ %b @ " " @ %c) @ " 0 0 0 " @ %pos1;
projectile::spawnprojectile("defpart", %newtrans, %pl, "0 0 0");
%a = getword(%matrix, 3); %b = getword(%matrix, 4); %c = getword(%matrix, 5);
%a += getrandom()-0.5; %b += getrandom()-0.5; %c += getrandom()/2;
schedule("deleteobject(" @ %def2 @ ");",0.2);
%newtrans = "0 0 0 " @ vector::normalize(%a @ " " @ %b @ " " @ %c) @ " 0 0 0 " @ %pos2;
projectile::spawnprojectile("defpart", %newtrans, %pl, "0 0 0");
deletevariables("Howitzerpart" @ %this @ "*");
schedule("deleteobject(" @ %this @ ");", 1);
schedule("deleteobject(" @ %turret @ ");", 1);
schedule("turret::respawn(Howitzer," @ getgroup(%this) @ ", \"" @ gamebase::gettransform(%this) @ "\"," @ gamebase::getteam(%this) @ ");", $WWII::RespawnDelay);
if(gamebase::getcontrolclient(%this) > 1000) client::setcontrolobject(gamebase::getcontrolclient(%this), client::getownedobject(gamebase::getcontrolclient(%this)));
}
//-------------------------------------------------------------------------------																					 
//=====================Pak - German Coastal defence gun=========================

RocketData PakBomb
{
	bulletShapeName = "bullet.dts";
	explosionTag = BombExp;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 1;
	damageValue = 2.5;
	damageType = $pak;		
	explosionRadius = 10;
	kickBackStrength = 100.0;
	muzzleVelocity = 500.0;
	terminalVelocity = 400.0;
	acceleration = 100.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

RocketData PakFire
{
        bulletShapeName = "tumult_medium.dts";
	explosionTag = debrisExpLarge;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 0;
	damageValue = 0.8;
	damageType = $Pak;		
	explosionRadius = 1;
	kickBackStrength = 10;
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


StaticShapeData PakPart99
{
   description = "never mind";
	shapeFile = "anten_rod";
	visibleToSensor = false;
	maxdamage = 9999999;
};

TurretData Pak   
{			 
	className = "Turret";
	shapeFile = "mortar_turret";
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 6;
	//projectiletype = yBazookashell;
	reloadDelay = 9;
	speed = 0.15;
	speedModifier = 0.15;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 15;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "7.5cm Pak 40";
};

function Pak::onFire(%this)
{
if(!%this.canfire) return;
%owner = gamebase::getcontrolclient(%this);
%Trans = GameBase::getMuzzleTransform(%this); 
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);
%Vel = Item::getVelocity(%this); 
%this.canfire = false;
schedule("enableturret(" @ %this @ ");", 3.078);
gamebase::playsound(%this, shockexplosion, 3);
//WWII::HeavyGunFisre("MG42", %this);

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

%trans2 = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ vector::sub(%vec_forward,vector::multiply(vector::getrandom(), "0.01 0.01 0.01")) @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ vector::add(GameBase::getPosition($PakPart[%this, 3]), vector::multiply(%vec_forward, "7.7 7.7 7.7"));		
Projectile::spawnProjectile("PakBomb", %trans2, client::getownedobject(%owner), %Vel); 
Projectile::spawnProjectile("PakFire", %trans2, %this, %Vel); 
}

function Pak::onAdd(%this) { %this.canfire = true; schedule("Pak::Setup(" @ %this @ ");", 3); }

function Pak::setup(%this)
{
%this.canfire = true;
%gunpos = gamebase::getposition(%this);
%group = "MissionCleanup"; //getGroup(%this);
%trans = gamebase::getmuzzletransform(%this);
%Vec_right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%Vec_left = vector::neg(%vec_right);
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11);
%gunrot = vector::add(Vector::getRotation(%Vec_forward), "1.57079 0 0"); 
//------------------------------------------------------------------------
%gunpart1 = NewObject("Gunpart1", "StaticShape", GunPart1, True);
addToSet(%group, %gunpart1);
if($PakPart[%this, 1] > 0) deleteObject($PakPart[%this, 1]);
$PakPart[%this, 1] = %gunpart1;

%gunpart2 = NewObject("Gunpart2", "StaticShape", GunPart1, True);
addToSet(%group, %gunpart2);
if($PakPart[%this, 2] > 0) deleteObject($PakPart[%this, 2]);
$PakPart[%this, 2] = %gunpart2;

%gunpart99 = NewObject("Pakpart99", "StaticShape", PakPart99, True);
addToSet(%group, %gunpart99);
if($PakPart[%this, 3] > 0) deleteObject($PakPart[%this, 3]);
$PakPart[%this, 3] = %gunpart99;

%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 0.133"), vector::multiply(%Vec_forward, "-0.25 -0.25 -0.25")), vector::multiply(%vec_Left, "1.2 1.2 1.2"));
gamebase::setposition(%gunpart1, %curpos);
gamebase::setrotation(%gunpart1, vector::add(%gunrot, "0 1.57079 1.84997"));

%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 0.133"), vector::multiply(%Vec_forward, "-0.285 -0.285 -0.285")), vector::multiply(%vec_Right, "1.2 1.2 1.2"));
gamebase::setposition(%gunpart2, %curpos);
gamebase::setrotation(%gunpart2, vector::add(%gunrot, "0 1.57079 1.13998"));

%curpos = vector::add(vector::add(%vec_muzzle, "0 0 -0.21"), vector::multiply(%vec_forward, "-0.3 -0.3 -0.3"));
gamebase::setposition(%gunpart99, %curpos);
gamebase::setrotation(%gunpart99, vector::add(%gunrot, "0 -1.57079 -1.57079"));

schedule("gamebase::setactive(" @ %this @ ", 0);", 1);
}

function Pak::onMount(%this, %player)
{
//if(isObject($PakPart[%this, 12])) deleteObject($PakPart[%this, 12]);
//if(isObject($PakPart[%this, 22])) deleteObject($PakPart[%this, 22]);
Pak::SystemMove(%this);
bottomprint(player::getclient(%player), "<jc><f2>You are currently controlling a <f1>heavy stationary weapon.<f2>\nPress space(jump) to observe or press it twice to stop control.", 10,TURRET);
Player::getclient(%player).turret = %this;
%turretpos = gamebase::getposition(%this);
%playerpos = gamebase::getposition(%player);
%x = vector::sub(%playerpos, %turretpos);
//gamebase::setposition(%player, vector::normalize(%x));
}

function Pak::SystemMove(%this)
{
if(GameBase::getControlClient(%this) == -1) return; //check if turret might move

%trans = GameBase::getMuzzleTransform(%this);
%Vec_right = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%Vec_left = vector::neg(%vec_right);
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5); //brake the muzzle 
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11); //trans apat.

%gunpos = GameBase::getPosition(%this); //Get the turrets transform
%gunrot = vector::add(Vector::getRotation(%Vec_forward), "1.57079 0 0"); 

//Move gun part I
%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 1.234"), vector::multiply(%Vec_forward, "-0.25 -0.25 0")), vector::multiply(%vec_Left, "1.2 1.2 0"));
%curpos = getWord(%curpos, 0) @ " " @ getWord(%curpos, 1) @ " " @ getword(%gunpos, 2) + 0.9;
gamebase::setposition($PakPart[%this, 1], %curpos);
gamebase::setrotation($PakPart[%this, 1], vector::add(%gunrot, -getWord(%gunrot, 0) @ " 1.57079 1.84997"));

//Move gun part II
%curpos = vector::add(vector::add(vector::add(%vec_muzzle, "0 0 1.234"), vector::multiply(%Vec_forward, "-0.285 -0.285 0")), vector::multiply(%vec_Right, "1.2 1.2 0"));
%curpos = getWord(%curpos, 0) @ " " @ getWord(%curpos, 1) @ " " @ getword(%gunpos, 2) + 0.9;
gamebase::setposition($PakPart[%this, 2], %curpos);
gamebase::setrotation($PakPart[%this, 2], vector::add(%gunrot, -getWord(%gunrot, 0) @ " 1.57079 1.13998"));

//Move gun part III (the turret)
%curpos = vector::add(vector::add(%vec_muzzle, "0 0 -0.23"), vector::multiply(%vec_forward, "-0.3 -0.3 -0.3"));
gamebase::setposition($PakPart[%this, 3], %curpos);
gamebase::setrotation($PakPart[%this, 3], vector::add(%gunrot, -getWord(%gunrot, 0) @ " " @ -1.57079+getWord(%gunrot, 0)  @ " -1.57079"));

schedule("Pak::SystemMove(" @ %this @ ");", 0.3); //Loop the system move...
}

function Pak::Jump(%this)
{
%cl = GameBase::getControlClient(%this);
%cl.jump = 1;

%trans = GameBase::getMuzzleTransform(%this);
%vec_muzzle = getword(%trans, 9) @ " " @ getword(%trans, 10) @ " " @ getword(%trans, 11); 
%vec_forward = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5); 

%campos = vector::add(%vec_muzzle, vector::multiply(%vec_forward, "8 8 8"));
%camrot = vector::add(vector::getrotation(%vec_forward), "1.57079 0 0");

client::setcontrolObject(%cl, client::getobserverCamera(%cl));
Observer::setFlyMode(%cl, %campos, %camrot, false, false);

schedule("if(" @ %cl @ ".jump == 1) { client::setcontrolobject(" @ %cl @ "," @ %this @ "); Pak::SystemMove(" @ %this @ "); " @ %cl @ ".jump = 0; }", 2);
}
function Pak::onDamage(%this, %type, %val)
{
if(getdamagetype(%type) == bullet) return;
%dlevel = gamebase::getdamagelevel(%this);
if(%dlevel >= 4) return;
if(%val+%dlevel > pak.maxdamage) gamebase::setdamagelevel(%this, pak.maxdamage);
else gamebase::setdamagelevel(%this, %dlevel+%val);
}

function Pak::onDestroyed(%this)
{
GameBase::applyRadiusDamage($Explosion, vector::add(getBoxCenter(%this), "0 0 3"), 6, 2,10,%this);

%def1 = $PakPart[%this, 1];
%def2 = $PakPart[%this, 2];
%pos1 = gamebase::getposition(%def1);
%pos2 = gamebase::getposition(%def2);
%turret = $Pakpart[%this, 3];
%pl = WWII::RandomPlayer();
for(%x = 0; %x < 5+floor(getrandom()*4); %x++)
	{
	%a = getrandom()-0.5;
	%b = getrandom()-0.5;
	%c = getrandom()+0.5;
	%vector = %a @ " " @ %b @ " " @ %c;
	%vector = vector::normalize(%vector);
	%trans = "0 0 0 " @ %vector @ " 0 0 0 " @ vector::add(gamebase::getposition(%this), "0 0 2");
	%g = floor(getrandom()*6) +2;
	//echo(%g,%a,%b);
	if(%g > 6) %g = 6; %block = "fragexp" @ %g; 
	projectile::spawnprojectile(%block, %trans, %pl, "0 0 -10");
	}
%matrix = gamebase::getmuzzletransform(%this);
%a = getword(%matrix, 3); %b = getword(%matrix, 4); %c = getword(%matrix, 5);
%a += getrandom()-0.5; %b += getrandom()-0.5; %c += getrandom()/2;
schedule("deleteobject(" @ %def1 @ ");",0.2);
%newtrans = "0 0 0 " @ vector::normalize(%a @ " " @ %b @ " " @ %c) @ " 0 0 0 " @ %pos1;
projectile::spawnprojectile("defpart", %newtrans, %pl, "0 0 0");
%a = getword(%matrix, 3); %b = getword(%matrix, 4); %c = getword(%matrix, 5);
%a += getrandom()-0.5; %b += getrandom()-0.5; %c += getrandom()/2;
schedule("deleteobject(" @ %def2 @ ");",0.2);
%newtrans = "0 0 0 " @ vector::normalize(%a @ " " @ %b @ " " @ %c) @ " 0 0 0 " @ %pos2;
projectile::spawnprojectile("defpart", %newtrans, %pl, "0 0 0");
deletevariables("Pakpart" @ %this @ "*");
schedule("deleteobject(" @ %this @ ");", 1);
schedule("deleteobject(" @ %turret @ ");", 1);
schedule("turret::respawn(Pak," @ getgroup(%this) @ ", \"" @ gamebase::gettransform(%this) @ "\"," @ gamebase::getteam(%this) @ ");", $WWII::RespawnDelay);
if(gamebase::getcontrolclient(%this) > 1000) client::setcontrolobject(gamebase::getcontrolclient(%this), client::getownedobject(gamebase::getcontrolclient(%this)));

}
//---------------------------------------------------
//-------------------------------------------------------------------------------																					 
//=====================40mm Bofors - Allied AA defence gun=======================

BulletData BoforsAIBolt
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = heavybullet;
   expRandCycle       = 1;
   mass               = 0.15;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.76;
   damageType         = $Bofors;

    aimDeflection      = 0.002;
   muzzleVelocity     = 150.9;
   totalTime          = 2;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

RocketData BoforsAABolt
{
	bulletShapeName = "bullet.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 1;
	damageValue = 1;
	damageType = $bofors;		
	explosionRadius = 12;
	kickBackStrength = 100.0;
	muzzleVelocity = 300.0;
	terminalVelocity = 300.0;
	acceleration = 100.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

RocketData FlakFire
{
        bulletShapeName = "breath.dts";
	explosionTag = smokeExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 0;
	damageValue = 0.4;
	damageType = $Bofors;		
	explosionRadius = 0.2;
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


TurretData Bofors   
{			 
	className = "Turret";
	shapeFile = "hellfiregun";
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 6;
	//projectiletype = yBazookashell;
	reloadDelay = 1;
	speed = 0.45;
	speedModifier = 0.35;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 15;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "40-mm Bofors";
};


//---------------------------------------------------
//-------------------------------------------------------------------------------																					 
//=====================2cm FLAK 38 - Axis AA defence gun=======================



BulletData FlakAIBolt
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = heavybullet;
   expRandCycle       = 2;
   mass               = 0.15;
   bulletHoleIndex    = 0;

   damageClass        = 0;      
   damageValue        = 0.76;
   damageType         = $Flak;

    aimDeflection      = 0.005;
   muzzleVelocity     = 150.9;
   totalTime          = 2;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};

RocketData FlakAABolt
{
	bulletShapeName = "bullet.dts";
	explosionTag = heavybullet;
	collisionRadius = 0.0;
	mass = 9.0;
	damageClass = 1;
	damageValue = 1;
	damageType = $Flak;		
	explosionRadius = 12;
	kickBackStrength = 100.0;
	muzzleVelocity = 300.0;
	terminalVelocity = 300.0;
	acceleration = 100.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

TurretData Flak  
{			 
	className = "Turret";
	shapeFile = "hellfiregun";
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 6;
	//projectiletype = yBazookashell;
	reloadDelay = 1;
	speed = 0.65;
	speedModifier = 0.45;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 15;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "2cm Flak 38";
};

function Flak::onFire(%this)
{
if(!%this.canfire) return;
%owner = gamebase::getcontrolclient(%this);
%Trans = GameBase::getMuzzleTransform(%this); 
%Vel = Item::getVelocity(%this); 
%this.canfire = false;
schedule("enableturret(" @ %this @ ");", 0.39);
gamebase::playsound(%this, mineExplosion, 3);

if(getword(%trans, 5) > 0.15) { %id = Projectile::spawnProjectile("FlakAABolt", %trans, client::getownedobject(%owner), %Vel); %id.owner = %owner; schedule("Flakloop(" @ %id @ ");",0.3); } 
else Projectile::spawnProjectile("FlakAIBolt", %trans, client::getownedobject(%owner), %Vel); 
Projectile::spawnProjectile("FlakFire", %trans, %this, %Vel); 
}
function Bofors::onFire(%this)
{
if(!%this.canfire) return;
%owner = gamebase::getcontrolclient(%this);
%Trans = GameBase::getMuzzleTransform(%this); 
%Vel = Item::getVelocity(%this); 
%this.canfire = false;
schedule("enableturret(" @ %this @ ");", 0.39);
gamebase::playsound(%this, mineExplosion, 3);

if(getword(%trans, 5) > 0.15) { %id = Projectile::spawnProjectile("BoforsAABolt", %trans, client::getownedobject(%owner), %Vel); %id.owner = %owner; schedule("boforsloop(" @ %id @ ");",0.3); } 
else Projectile::spawnProjectile("BoforsAIBolt", %trans, client::getownedobject(%owner), %Vel); 
Projectile::spawnProjectile("FlakFire", %trans, %this, %Vel); 
}

function flakloop(%id)
{
%Set = newObject("set",SimSet);
%Pos = gamebase::getposition(%id);
%num = containerBoxFillSet(%Set, $vehicleObjectType | $Simplayerobjecttype, %Pos, 40, 40, 40,0); 
%los = GetLOSInfo(vector::add(%pos, "0 0 -0.2"), vector::sub(%pos, "0 0 80"),-1);
if(%num > 0 && !%los) 
{

%obj = newObject("","Mine","FlakExp");
GameBase::throw(%obj,client::getownedobject(%id.owner),3 ,false);
deleteobject(%id);
gamebase::setposition(%obj, %pos);
//gamebase::setactive(%obj, true);
schedule("gamebase::setdamagelevel(" @ %obj @ ", flakexp.maxdamage);", 0.04, %obj);
return;
}
deleteobject(%set);
schedule("flakloop(" @ %id @ ");",0.2,%id);
}
function boforsloop(%id)
{
%Set = newObject("set",SimSet);
%Pos = gamebase::getposition(%id);
%num = containerBoxFillSet(%Set, $vehicleObjectType | $Simplayerobjecttype, %Pos, 40, 40, 40,0); 

%los = GetLOSInfo(vector::add(%pos, "0 0 -0.2"), vector::sub(%pos, "0 0 80"),-1);
if(%los) echo($los::object);
if(%num > 0 && !%los) 
{

%obj = newObject("","Mine","BoforsExp");
GameBase::throw(%obj,client::getownedobject(%id.owner),3 ,false);
deleteobject(%id);
gamebase::setposition(%obj, %pos);
//gamebase::setactive(%obj, true);
schedule("gamebase::setdamagelevel(" @ %obj @ ", Boforsexp.maxdamage);", 0.04, %obj);
return;
}
deleteobject(%set);
schedule("boforsloop(" @ %id @ ");",0.2,%id);
}
MineData BoforsExp
{
	className = "Mine";
   description = "Mine";
   shapeFile = "breath";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 35.0;
	damageValue = 0.7;
	damageType = $Boforsx;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
MineData FlakExp
{
	className = "Mine";
   description = "Mine";
   shapeFile = "breath";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 35.0;
	damageValue = 0.7;
	damageType = $Flakx;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
//-----------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------

function Turret::onAdd(%this)
{
	%this.canfire = true;
	schedule(%this @ ".firstrotation = Gamebase::getrotation(%this);", 0.5);

	Turret::onEnabled(%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Turret");
	}
	//eval(gamebase::getdataname(%this) @ "::onAdd(" @ %this @ ");");
}

function Turret::onActivate(%this)
{
	//GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	//GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);

}

function Turret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
		
		GameBase::setRechargeRate(%this,5);
		GameBase::setActive(%this,true);
}

function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	Turret::onDeactivate(%this);
	//Turret::objectiveDestroyed(%this);
	
	eval(gamebase::getdataname(%this) @ "::onDestroyed(" @ %this @ ");");
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
%data = gamebase::getdataname(%this);
eval(%data @ "::onDamage(" @ %this @ "," @ %type @ "," @ %value @ ");");   
}

function Turret::onControl(%this, %object)
{
}



//=====================================================================

function Turret::onCollision (%this, %object)
{

	if (getObjectType (%object) == "Player")
		{
			if(GameBase::getLOSInfo(%this, 3, "0 0 3.14159"))
				{
				if($los::object != %object) return;
			%client = player::getclient(%object);
			if(%client.canmountguns) Turret::onManualControl(%this, %object);
				}	
		}
}

function Turret::onManualControl(%this, %player) 
{	
	%client = Player::getClient(%player);

	%player.ManualCommandTag = True;
	%player.CommandTag = 1;
	%client.pl = %player;
	 Client::takeControl(%client, %this);
	
}

function Client::takeControl(%clientId, %objectId)
{
  
   if(%objectId == -1)
   {
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getControlClient(%objectId) != -1)
   {
      return;
   }
	%name = GameBase::getDataName(%objectId);
	
	%rot = getword(Gamebase::getRotation(%objectId), 2);
	
   gamebase::setrotation(%clientId, "0 0 " @ %rot);

   if(gamebase::getdamagelevel(%objectid) < %name.maxdamage) {
   	Client::setControlObject(%clientId, %objectId);
   	Client::setGuiMode(%clientId, $GuiModePlay);
	GameBase::Virtual(%objectId, "onmount", %clientId);
	Player::UnMountItem(%pl, $weaponslot);
	}
}

function Turret::onDismount(%this, %object) 
{
	%client = %object;
	%client.turret = 0;
	Turret::checkOperator(%this);
	//gamebase::setrotation(%this, %this.firstrotation);
	%trans = GameBase::getMuzzleTransform(%client);
	%aim = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%playerpos = gamebase::getposition(%client);
	gamebase::setposition(%client, vector::add(%playerpos, vector::neg(%aim)));
}

function Turret::Jump(%this, %mom) 
{	
	if(GameBase::getDataName(%this) == Pak) { Pak::Jump(%this); return; }
	if(GameBase::getDataName(%this) == Howitzer) { Howitzer::Jump(%this); return; }
	%cl = GameBase::getControlClient(%this);
	%cl.canmountguns = false;
	schedule("gunstuff(" @ %cl @ ");", 1.5);
	Turret::onDismount(%this, %cl);
}

function gunstuff(%id)
{
%id.canmountguns = true;
%id.jump = 0;
}

function Turret::checkOperator(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) 
	{
		%pl = Client::getOwnedObject(%cl);
		if(%player.ManualCommandTag)
		{	%player.ManualCommandTag = False;
			%player.CommandTag = "";
		}
		Player::setMountObject(%pl, -1,0);
		Client::setControlObject(%cl, %pl);
	}
	
}



function turret::respawn(%data, %group, %trans, %team)
{
%pos = getword(%trans, 0) @ " " @ getword(%trans, 1) @ " " @ getword(%trans, 2);
%rot = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
%obj = newObject(%data, "Turret", %data, false);
addtoset(%group, %obj);
gamebase::setposition(%obj, %pos);
gamebase::setrotation(%obj, %rot);
gamebase::setteam(%obj, %team);
gamebase::startfadein(%obj);
}

//---------------------------------------------------------------------

function vector::Multiply(%vec1, %vec2)
{
%vec1a = getword(%vec1, 0);
%vec1b = getword(%vec1, 1);
%vec1c = getword(%vec1, 2);

%vec2a = getword(%vec2, 0);
%vec2b = getword(%vec2, 1);
%vec2c = getword(%vec2, 2);

return %vec1a * %vec2a @ " " @ %vec1b * %vec2b @ " " @ %vec1c * %vec2c;
}
//-----------------------------------------
TurretData DummyTurret   
{			 
	className = "Turret";
	shapeFile = "breath"; //gunturret
	maxDamage = 999;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 6;
	reloadDelay = 0.1;
	speed = 5.0;
	speedModifier = 1.0;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	
	
	debrisId = defaultDebrislarge;
	shieldShapeName = "shield";
	fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExplarge;
	description = "Dumbass";
};


//--------------------------------------------------

RocketData TurretFireCheat
{
        bulletShapeName = "breath.dts";
	explosionTag = noExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 0;
	damageValue = 0.001;
	damageType = $nothing;		
	explosionRadius = 0.002;
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

function TurretFireCheat::onAdd(%this)
{
%pos = gamebase::getposition(%this);
%Set = newObject("set",SimSet);
%num = containerBoxFillSet(%Set, $StaticObjectType, %Pos, 1, 1, 1, 0); 
%turretid = group::getobject(%set, 0);
%datablock = Gamebase::getDataname(%turretid);
eval(%datablock @ "::onFire(" @ %turretid @ ");");
}