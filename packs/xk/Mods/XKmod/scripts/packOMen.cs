
$MaxMan = 60;
$ManCounter = 60;

MineData rainingMan
{ 
	mass = 2.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.0; 
	friction = 99.0; 
	className = "Handgrenade"; 
	description = "Man"; 
	shapeFile = "zap"; 
	shadowDetailMask = 4; 
	explosionId = turretExp; 
	explosionRadius = 5.0; 
	damageValue = 0.3; 
	damageType = $MortarDamageType; 
	kickBackStrength = 0; 
	triggerRadius = 0.5; 
	maxDamage = 0.1; 
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
	description = "Pack O' Lightning"; 
	shapeFile = "ammopack"; 
	className = "Backpack"; 
	heading = $InvHead[ihBac]; 
	shadowDetailMask = 4; 
	imageType = PackOMenImage; 
	price = 200; 
	hudIcon = "sensorjamerpack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function rainingMan::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",4.0,%this); 
}

function PackOMenImage::onActivate(%player,%imageSlot) 
{ 
	bottomPrintAll("It's Lightning! Take Cover!", 10);
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
