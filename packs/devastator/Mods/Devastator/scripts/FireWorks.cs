//------------------------------------------//
//ICE'S PERTY LIGHT SHOW THAT'S JUST FOR FUN//
//------------------------------------------//

MineData FireWorkMine
{
	className = "Mine";
        shapeFile = "plasmaex";
        shadowDetailMask = 4;
        explosionId = plasmaExp;
        explosionRadius = 0;
        damageValue = 0.0;
	damageType = $MortarDamageType;
        kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FireWorkMine::onAdd(%this)
{
	schedule("Mine::Detonate("@%this@");",0.1,%this);
}
//--------------------------------------
GrenadeData FireWork1
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 5;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;

   smokeName              = "fusionex.dts";
};
//--------------------------------------
GrenadeData FireWork2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 5;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;

   smokeName              = "Plasmabolt.dts";
};

//--------------------------------------
GrenadeData FireWork3
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 5;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;

   smokeName              = "Plasmaex.dts";
};

//--------------------------------------
RocketData FireWorkRocket
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmaexp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 25.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};

function FireWorkRocket::onAdd(%this)
{
	FireWork::Rocket(%this);
	schedule("FireWork::MidPoint("@%this@");",5,$Shooter[%this]);
}

function FireWork::MidPoint(%this)
{
	echo("MidPoint");
	FireWork::Boom(%this,$LastRot[%this],$LastPos[%this],getSimTime(),$Shooter[%this]);
}

function FireWorkRocket::onRemove(%this)
{
	FireWork::Boom(%this,$LastRot[%this],$LastPos[%this],getSimTime(),$Shooter[%this]);
}
//--------------------------------------
GrenadeData FireWorkGrenade
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 10;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;

   smokeName              = "PlasmaEx.dts";
};

//--------------------------------------

function FireWork::Rocket(%this)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%pos2= Vector::add(%pos,Vector::getFromRot(%rot,10));
	%vel = Item::getVelocity(%this);
	%AimRot = Vector::getRotAim(%pos,%pos2);
	%vec = Vector::getFromRot(%AimRot,1);
	%newVel = Vector::add(%vel,%vec);
	Item::setVelocity(%this,%newVel);
	%trans = %AimRot@" "@%vec@" "@%AimRot@" "@%pos2;
	Projectile::spawnProjectile(FireWorkGrenade,%trans,$Shooter[%this],%vel);
	schedule("FireWork::Rocket("@%this@");",0.2,%this);
	$LastPos[%this] = GameBase::getPosition(%this);
	$LastRot[%this] = GameBase::getRotation(%this);
}
//--------------------------------------

function FireWork::Boom(%this,%rot,%pos,%start,%player)
{
	%vel = "0 0 0";
	%rot[1]  = %rot;						//- rotation aim forward
	%rot[2]  = Vector::Add(%rot,"0 0 3.141592654");			//- rotation aim back
	%rot[3]  = Vector::Add(%rot,"0 0 -1.570796327");		//- rotation aim left
	%rot[4]  = Vector::Add(%rot,"0 0 1.570796327");			//- rotation aim right
	%rot[5]  = Vector::Add(%rot,"1.570796327 0 0");			//- rotation aim up
	%rot[6]  = Vector::Add(%rot,"-1.570796327 0 0");		//- rotation aim down
	%rot[7]  = Vector::Add(%rot,"-0.7853981635 0 0");		//- rotation aim down/forward
	%rot[8]  = Vector::Add(%rot,"0.7853981635 0 0");		//- rotation aim up/forward
	%rot[9]  = Vector::Add(%rot,"-3.9269908175 0 0");		//- rotation aim down/back
	%rot[10] = Vector::Add(%rot,"3.9269908175 0 0");		//- rotation aim up/back
	%rot[11] = Vector::Add(%rot,"0 0 -0.7853981635");		//- rotation aim left/forward
	%rot[12] = Vector::Add(%rot,"0 0 0.7853981635");		//- rotation aim right/forward
	%rot[13] = Vector::Add(%rot,"0 0 -3.9269908175");		//- rotation aim left/back
	%rot[14] = Vector::Add(%rot,"0 0 3.9269908175");		//- rotation aim right/back
	%rot[15] = Vector::Add(%rot,"1.570796327 0.7853981635 0");	//- rotation aim up/right
	%rot[16] = Vector::Add(%rot,"-1.570796327 0.7853981635 0");	//- rotation aim down/right
	%rot[17] = Vector::Add(%rot,"1.570796327 -0.7853981635 0");	//- rotation aim up/left
	%rot[18] = Vector::Add(%rot,"-1.570796327 -0.7853981635 0");	//- rotation aim down/left
	for(%i = 1; %i <= 18; %i++) {
		%vec[%i] = Vector::getFromRot(%rot[%i],2);
		%pos[%i] = Vector::Add(%pos,%vec[%i]);
		%trans = %rot[1]@" "@%vec[%i]@" "@%rot[1]@" "@%pos[%i];
		Projectile::spawnProjectile(FireWorkGrenade,%trans,%player,%vel);
	}
	if(getSimTime() < %start+1) //- lets it go twice
		schedule("FireWork::Boom("@%this@",\""@%rot@"\",\""@%pos@"\",\""@%start@"\",\""@%player@"\");",1.0,%player);
	else {
		FireWork::Sparklers(%pos,%rot,getSimTime(),%player);
	}
}

//--------------------------------------
function FireWork::Sparklers(%pos,%rot,%start,%player)
{
	%rot[1]  = %rot;						//- rotation aim forward
	%rot[2]  = Vector::Add(%rot,"0 0 3.141592654");			//- rotation aim back
	%rot[3]  = Vector::Add(%rot,"0 0 -1.570796327");		//- rotation aim left
	%rot[4]  = Vector::Add(%rot,"0 0 1.570796327");			//- rotation aim right
	%rot[5]  = Vector::Add(%rot,"1.570796327 0 0");			//- rotation aim up
	%rot[6]  = Vector::Add(%rot,"-1.570796327 0 0");		//- rotation aim down
	%rot[7]  = Vector::Add(%rot,"-0.7853981635 0 0");		//- rotation aim down/forward
	%rot[8]  = Vector::Add(%rot,"0.7853981635 0 0");		//- rotation aim up/forward
	%rot[9]  = Vector::Add(%rot,"-3.9269908175 0 0");		//- rotation aim down/back
	%rot[10] = Vector::Add(%rot,"3.9269908175 0 0");		//- rotation aim up/back
	%rot[11] = Vector::Add(%rot,"0 0 -0.7853981635");		//- rotation aim left/forward
	%rot[12] = Vector::Add(%rot,"0 0 0.7853981635");		//- rotation aim right/forward
	%rot[13] = Vector::Add(%rot,"0 0 -3.9269908175");		//- rotation aim left/back
	%rot[14] = Vector::Add(%rot,"0 0 3.9269908175");		//- rotation aim right/back
	%rot[15] = Vector::Add(%rot,"1.570796327 0.7853981635 0");	//- rotation aim up/right
	%rot[16] = Vector::Add(%rot,"-1.570796327 0.7853981635 0");	//- rotation aim down/right
	%rot[17] = Vector::Add(%rot,"1.570796327 -0.7853981635 0");	//- rotation aim up/left
	%rot[18] = Vector::Add(%rot,"-1.570796327 -0.7853981635 0");	//- rotation aim down/left
	for(%i = 1; %i <= 18; %i++) {
		%vec[%i] = Vector::getFromRot(%rot[%i],1);
		%veP[%i] = Vector::getFromRot(%rot[%i],4);
		%pos[%i] = Vector::Add(%pos,%veP[%i]);
		%trans = %rot[1]@" "@%vec[%i]@" "@%rot[1]@" "@%pos[%i];
		%type = radnomItems(6,Confetti,Confetti2,Confetti3,FireWork1,FireWork2,FireWork3);
		Projectile::spawnProjectile(%type,%trans,%player,"0 0 0");
	}
	if(getSimTime() < %start+3)
		schedule("FireWork::Sparklers(\""@%pos@"\",\""@%rot@"\",\""@%start@"\",\""@%player@"\");",0.2,%player);
}

//--------------------------------------

ItemImageData FWImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData FW
{
	description = "Fire Works";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "dTools";
	shadowDetailMask = 4;
	imageType = FWImage;
	price = 0;
	showWeaponBar = true;
};

function FWImage::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%proj = Weapon::onFire(%player);
	$Shooter[%proj] = %player;
	%clientName = client::GetName(%client);
	messageAll(2,%clientName@": Happy New Year!!!~wShell_Click.wav");
}
$WeapProjectile[FW] = FireWorkRocket;

//-Use this to console in a FireWork gun
function FireWork(%this)
{
	player::incitemcount(%this,FW);
	player::mountitem(%this,FW,0);
}