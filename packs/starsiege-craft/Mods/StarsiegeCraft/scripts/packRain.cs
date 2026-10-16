$InvList[Rain] = 1;
$RemoteInvList[Rain] = 1;

$MaxMan = 60;
$ManCounter = 60;

MineData raining
{ 
	mass = 0.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.0; 
	friction = 99.0; 
	className = "Handgrenade"; 
	description = "Man"; 
	shapeFile = "mortar"; 
	shadowDetailMask = 4; 
	explosionId = grenadeExp; 
	explosionRadius = 30.0; 
	damageValue = 0.7; 
	damageType = $MortarDamageType; 
	kickBackStrength = 0; 
	triggerRadius = 0.5; 
	maxDamage = 0.1; 
}; 

ItemImageData RainImage
{ 
	shapeFile = "sensor_small"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.05, 0 }; 
	firstPerson = false; 
	weaponType = 2; 
	sfxFire = SoundJammerOn; 
	maxEnergy = 100; 
        reloadTime = 160;
	mountRotation = { 0, 0, 0 }; 
};

ItemData Rain
{ 
	description = "Death Rain"; 
	shapeFile = "sensor_small"; 
	className = "Backpack"; 
	heading = $InvHead[ihPsi]; 
	shadowDetailMask = 4; 
	imageType = PackOMenImage; 
	price = 2500; 
	hudIcon = "sensorjamerpack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function raining::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",4.0,%this); 
}

function RainImage::onActivate(%player,%imageSlot) 
{ 
	bottomPrintAll("It begins to rain death...", 10);
	%clientid = Player::getClient(%player);
	%loc = GameBase::getPosition(%player);
	%loc = Vector::add(%loc, "0 0 100");
        // Deactivate Pack	
	Player::trigger(%player,%imageslot,false);
	Schedule("RainImage::onRainAMan(\"" @ %loc @ "\"," @ $MaxMan @ ");", 1); 
} 

function RainImage::onDeactivate(%player,%imageSlot) 
{ 
	// Don't need to do anything here
	//messageAll(1, "Deactivate");
} 

function RainImage::onRainAMan(%location,%ManCounter)
{
	%man = newObject("","Mine","raining"); 
	addToSet("MissionCleanup", %man); 

	%newloc = (floor(getRandom()*100)-50) @ " " @ (floor(getRandom()*100)-50) @ " 0";
	%newloc = Vector::add(%location, %newloc);
	GameBase::setPosition(%man, %newloc); // Need random location based on location
	%ManCounter = %ManCounter - 1;
	if (%ManCounter > 0)
		Schedule("RainImage::onRainAMan(\"" @ %location @ "\"," @ %ManCounter @ ");", 1); 
}

function Rain::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "This power acts like a backpack(P), explosive death rains from the skies above. Very devastating.");
}