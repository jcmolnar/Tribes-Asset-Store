
$MaxMan = 160;
$ManCounter = 20;

ExplosionData grenade78Exp
{
   shapeName = "fiery.dts";
   soundId   = bigExplosion1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

MineData rainingMan
{ 
	mass = 2.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.0; 
	friction = 99.0; 
	className = "Handgrenade"; 
	description = "Man"; 
	shapeFile = "plasmabolt"; 
	shadowDetailMask = 4; 
	explosionId = grenade78Exp; 
	explosionRadius = 20.0; 
	damageValue = 100; 
	damageType = $MortarDamageType; 
	kickBackStrength = 0; 
	triggerRadius = 0.5; 
	maxDamage = 200; 
}; 

ItemImageData PackOMenImage
{ 
	shapeFile = "ammopack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.05, 0 }; 
	firstPerson = false; 
	weaponType = 2; 
//	sfxFire = SoundJammerOn; 
//	maxEnergy = 10; 
//	mountRotation = { 0, 0, 0 }; 
};

ItemData PackOMen
{ 
	description = "Raining HellFire"; 
	shapeFile = "ammopack"; 
	className = "Backpack"; 
	heading = "cBackpacks"; 
	shadowDetailMask = 4; 
	imageType = PackOMenImage; 
	price = 200; 
	hudIcon = "sensorjamerpack"; 
	showWeaponBar = false; 
	hiliteOnActive = true; 
}; 

function rainingMan::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",4.0,%this); 
}

function PackOMenImage::onActivate(%player,%imageSlot) 
{ 
	bottomPrintAll("<jc><f3>***An Admin Has Summoned HellFire To Rain From The Heavens***", 10);
	%clientid = Player::getClient(%player);
	%loc = GameBase::getPosition(%player);
	%loc = Vector::add(%loc, "0 0 100");
        // Deactivate Pack	
	Player::trigger(%player,%imageslot,false);
	Schedule("PackOMenImage::onRainAMan(\"" @ %loc @ "\"," @ $MaxMan @ ");", 1); 
} 

function PackOMenImage::onDeactivate(%player,%imageSlot) 
{ 
	// Don't need to do anything here
	//messageAll(1, "Deactivate");
} 

function PackOMenImage::onRainAMan(%location,%ManCounter)
{
	%man = newObject("","Mine","rainingMan"); 
	addToSet("MissionCleanup", %man); 

	%newloc = (floor(getRandom()*100)-50) @ " " @ (floor(getRandom()*100)-50) @ " 0";
	%newloc = Vector::add(%location, %newloc);
	GameBase::setPosition(%man, %newloc); // Need random location based on location
	%ManCounter = %ManCounter - 1;
	if (%ManCounter > 0)
		Schedule("PackOMenImage::onRainAMan(\"" @ %location @ "\"," @ %ManCounter @ ");", 1); 
}
