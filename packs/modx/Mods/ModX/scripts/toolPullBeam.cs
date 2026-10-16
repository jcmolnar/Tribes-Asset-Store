// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------
// Pull Beam
//--------------------------------------------------------------------------------------------------------

$ItemMax[larmor,StrykerChain]	= 1;
$ItemMax[lfemale,StrykerChain]	= 1;

LightningData tractorChargeOld
{
   bitmapName = "lightningNew.bmp";

   boltLength = 15.0;
   coneAngle = 35.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 0;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 0.25, 0.25, 0.85 };
};

LightningData tractorCharge
{
	bitmapName = "lightningNew.bmp";//"discglow2.bmp";//"paintglow.bmp"; //"lightningNew.bmp";//"antgrv04.bmp"; //"chainflash1.bmp"; //"lightningNewSub.bmp"; //"grn_blink4.bmp";	//lightningNew.bmp";
	//damageType = $ElectricityDamageType;
	boltLength = 150.0;
	coneAngle = 35.0;
	damagePerSec = 0.0;
	energyDrainPerSec = 0.0;
	segmentDivisions = 0;
	numSegments = 1;
	beamWidth = 0.085;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	//lightRange = 3.0;
	//lightColor = { 0.25, 0.25, 0.85 };
    lightRange = 3.0;
    //lightColor  = { 0.25, 1, 0.25 };
    lightColor = { 0.25, 0.25, 0.85 };
	//soundId = SoundLaserIdle;
};

function tractorCharge::pull(%client, %target)
{
	%myPos = GameBase::getPosition(%client);
	%yourPos = GameBase::getPosition(%target);
	%myRot = GameBase::getRotation(%client);

	%dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2);
	//make dir face opposite direction, thus pulls toward

	%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
	%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0";
	%dist = Vector::getDistance(%myFlatPos, %yourFlatPos);
	//so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference

	%force = 15; //not too hard and fast

	%height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values

	%diffVector = Vector::getFromRot(%dir, -%force, (-%height / %force));

	if(%client.tractorMode == 1)
		%diffVector = Item::getVelocity(%target);

	Item::setVelocity(%client, %diffVector); //the actual movement function
}

function tractorCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	tractorCharge::pull(%shooterID,%target);
}


ItemImageData Pull
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = tractorCharge;
   minEnergy = 0;
   maxEnergy = 0;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;

   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundSensorPower;
};

ItemData StrykerChain
{
   description = "Pull Beam";
	shapeFile = "shotgun";
	//hudIcon = "energyRifle";
   className = "Tool";
   heading = "bTools";
   shadowDetailMask = 4;
   imageType = Pull;
	showWeaponBar = false;
   price = 1500;
};

AddWeapon(StrykerChain);
AddToInv(StrykerChain);

