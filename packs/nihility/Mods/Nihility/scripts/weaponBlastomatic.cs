//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Steny);
$InvList[Steny] = 1;

$AutoUse[Steny] = True;
$WeaponAmmo[Steny] = "";

$ItemMax[larmor, Steny] = 0;		//Seraph
$ItemMax[lfemale, Steny] = 0;		//Seraph
$ItemMax[earmor, Steny] = 0;		//Slave
$ItemMax[efemale, Steny] = 0;		//Slave
$ItemMax[marmor, Steny] = 0;		//Pawn
$ItemMax[aarmor, Steny] = 0;		//Navigator
$ItemMax[darmor, Steny] = 1;		//Atomizer
$ItemMax[barmor, Steny] = 1;		//Paladin


//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

BulletData StenCharge
{	bulletShapeName = "paint.dts";
	explosionTag = PlasmaExp;
	mass = 0.05;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.25;
	damageType = $ElectricityDamageType;
	explosionRadius = 2.5;
	muzzleVelocity = 375.0;
	totalTime = 0.67;
	inheritedVelocityScale = 1.0;
	liveTime = 0.66;
	isVisible = True;
	rotationPeriod = 1;
};

GrenadeData StenHyperCharge
{	bulletShapeName = "paint.dts";
	explosionTag = PlasmaExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 0.05;
	elasticity = 0.60;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.31;
	damageType = $ElectricityDamageType;
	explosionRadius = 2.5;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 5000;
	totalTime = 0.61;
	liveTime = 0.6;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "paint.dts";
	//smokeName = "";
};


MineData Charge6
{
   	mass = 1.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "paint";
	shadowDetailMask = 4;
	explosionId = PlasmaExp;
	explosionRadius = 2.5;
	damageValue = 0.2;
	damageType = $ElectricityDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Charge6::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.6,%this);
}

MineData Charge5
{
   	mass = 1.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "paint";
	shadowDetailMask = 4;
	explosionId = PlasmaExp;
	explosionRadius = 2.5;
	damageValue = 0.2;
	damageType = $ElectricityDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Charge5::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData Charge4
{
   	mass = 1.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "paint";
	shadowDetailMask = 4;
	explosionId = PlasmaExp;
	explosionRadius = 2.5;
	damageValue = 0.2;
	damageType = $ElectricityDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Charge4::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.4,%this);
}

MineData Charge3
{
   	mass = 1.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "paint";
	shadowDetailMask = 4;
	explosionId = PlasmaExp;
	explosionRadius = 2.5;
	damageValue = 0.2;
	damageType = $ElectricityDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Charge3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Charge2
{
   	mass = 1.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "paint";
	shadowDetailMask = 4;
	explosionId = PlasmaExp;
	explosionRadius = 2.5;
	damageValue = 0.2;
	damageType = $ElectricityDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Charge2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

MineData Charge1
{
   	mass = 1.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "paint";
	shadowDetailMask = 4;
	explosionId = PlasmaExp;
	explosionRadius = 2.5;
	damageValue = 0.2;
	damageType = $ElectricityDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Charge1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}


function StenHyperCharge::onAdd(%this)
{
	schedule("DeployCharges(" @ %this @ " , 5);",0.1,%this);
}

function DeployCharges(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Charge1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

//		%obj = newObject("","Mine","Charge2");
//	 	addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,-5,false);
//
//		%obj = newObject("","Mine","Charge3");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,5,false);

//		%obj = newObject("","Mine","Charge4");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,-5,false);
//		
//		%obj = newObject("","Mine","Charge6");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,5,false);

		%count -= 1;
		schedule("DeployCharges(" @ %this @ ", " @ %count @ ");",0.2,%this);
	}
}


//--------------------------------------

LightningData EnergyShot
{
   bitmapName       = "lightningNew.bmp";//lightningNew  paintpulse.dts  

   damageType       = $ElectricityDamageType;
   boltLength       = 150.0;
   coneAngle        = 10.0;
   damagePerSec      = 0.023;
   energyDrainPerSec = 0.0;
   
   segmentDivisions = 2;
   numSegments      = 8;
   beamWidth        = 0.2;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 5.0;
   lightColor = { 0.25, 1.0, 0.25 };
   

   soundId = SoundELFFire;
};





//================================


ItemImageData StenyImage
{
shapeFile = "plasma";
   mountPoint = 0;
   weaponType = 0;  // Single
   //projectileType = StenCharge;
   minEnergy = 4;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
   fireTime = 0.2;
   reloadTime = 0.07;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireBlaster;
};

ItemImageData Steny2Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0.47, 0, 0 };
	mountOffset = { 0.0, 0.12 , 0.17 };
	accuFire = true;
	weaponType = 0;
  	fireTime = 0.01;
   	reloadTime = 0.07;  
	minEnergy = 0;
	maxEnergy = 0;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
};

ItemImageData Steny3Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
  	mountRotation = { 0.47, 0, 0 };
	mountOffset = { 0.0, 0.05 , 0.17 };
	accuFire = true;
	weaponType = 0;
  	fireTime = 0.01;
   	reloadTime = 0.07;  
	minEnergy = 0;
	maxEnergy = 0;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
};

ItemImageData Steny4Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0.47, 0, 0 };
	mountOffset = { 0.0, -0.02 , 0.17 };
	accuFire = true;
	weaponType = 0;
  	fireTime = 0.01;
   	reloadTime = 0.07;  
	minEnergy = 0;
	maxEnergy = 0;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
};

ItemData Steny
{
   description = "Blastomatic 3000";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = StenyImage;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemData Steny2
{
   description = "void";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Steny2Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemData Steny3
{
   description = "void";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Steny3Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemData Steny4
{
   description = "void";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Steny4Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};



$StenySlotA=4;
$StenySlotB=7;
$StenySlotC=6;

function Steny::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Blastomatic 3000");

	Player::mountItem(%player,steny2,$StenySlotA); 
	Player::mountItem(%player,steny3,$StenySlotB);
	Player::mountItem(%player,steny4,$StenySlotC);

}

function Steny::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$StenySlotA); 
	Player::unmountItem(%player,$StenySlotB); 
	Player::unmountItem(%player,$StenySlotC); 
}
//THIS IS SHIFTER! THIS FUNCTION.... RIGHT HERE
function EmplacementPack::rotVector(%vec,%rot)
{
	// this function rotates a vector about the z axis

	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);

	// new vector with z axis removed
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";
	
	// change vector to distance and rotation
	%basedis = Vector::getDistance( "0 0 0", %basevec);
	%normvec = Vector::normalize( %basevec );
	%baserot = Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );

	// modify rotation and change back to vector (put z axis offset back)
	%newrot = Vector::add( %baserot, %rot );
	%newvec = Vector::getFromRot( %newrot, %basedis, %vec_z );

	return %newvec;
}

function StenyImage::onFire(%player, %slot) 
{

	%playerId = Player::getClient(%player);
	%fired.deployer = %player;
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);

	if (!%playerId.Steny || %playerId.Steny == 0)
	{
		%fired = Projectile::spawnProjectile("StenCharge",%trans,%player,%vel);
		//%newObj = Projectile::spawnProjectile("StenCharge", %trans, %player, %vel);		
		%energy = GameBase::getEnergy(%player);
		%energy -= 3;
		GameBase::setEnergy(%player,%energy);
	}
	else if (%playerId.Steny == 1)
	{
		%fired = Projectile::spawnProjectile("StenHyperCharge",%trans,%player,%vel);
		//%newObj = Projectile::spawnProjectile("StenHyperCharge", %trans, %player, %vel);
		%energy = GameBase::getEnergy(%player);
		%energy -= 5;
		GameBase::setEnergy(%player,%energy);
	}


}


//%vel = EmplacementPack::rotVector( "15 0 -15", GameBase::getRotation(%player));
//Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
// 
//%vel = EmplacementPack::rotVector( "-15 0 -15", GameBase::getRotation(%player));
//Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
// 
//%vel = EmplacementPack::rotVector( "0 2 15", GameBase::getRotation(%player));
//Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);


function Steny::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.Steny || %client.Steny == 0)
	{
	        bottomprint(%client, "<jc><f2>Blastomatic 3000<f1> Standard Blast", 2);
	}
	if (%client.Steny == 1)
	{
	        bottomprint(%client, "<jc><f2>Blastomatic 3000<f1> Hyper Bolt", 2);
	}
}