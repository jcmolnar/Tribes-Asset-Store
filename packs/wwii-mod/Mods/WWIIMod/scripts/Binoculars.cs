StaticShapeData ATB
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "breath";
	maxDamage = 999999999;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = false;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};


ItemImageData BinocularsI
{
   shapeFile  = "mortar";
	mountPoint = 0;
	mountOffset = { -0.14, 0, 0 };
	minenergy = 0; 
	maxenergy = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 0.1;
	accufire = true;
};

ItemData binoculars
{
   heading = "dAdvanced";
	description = "Binoculars";
	className = "Weapon";
   shapeFile  = "mortar";
	hudIcon = "sniper";
	shadowDetailMask = 4;
	imageType = BinocularsI;
	price = 200;
	showWeaponBar = true;
};

ItemImageData binoculars2Image 
{
	shapeFile = "mortar";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	mountOffset = { 0.1, 0, 0 };
	accuFire = true;
};

ItemData binoculars2
{
	description = "Railgun";
	shapeFile = "mortar";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = binoculars2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function binoculars::onMount(%pl, %item)
{
player::mountitem(%pl, binoculars2, 4);
%cl = player::getclient(%pl);
bottomprint(%cl, "<jc>Binoculars are given for calling air strikes and setting artillery targets.\n<f2>Press 'M' to target artillery or press 'B' to call an air strike.", 10, AIRSTRIKE);
}

function binoculars::onUnMount(%pl, %item)
{
player::unmountitem(%pl, 4);
}

function Artillery::setTarget(%player)
{
%cl = player::getclient(%player);
if(%cl.cansettarget == false) return;
if(gamebase::getlosinfo(%player, 400))
	{
	%beacon = newObject("Artillery Beacon","StaticShape",ATB,true); 
	GameBase::setTeam(%beacon,gamebase::getteam(%player)); 
	gamebase::setposition(%beacon, $los::position);
	GameBase::setRotation(%beacon,"0 0 0"); 
	addToSet("MissionCleanup", %beacon);
	GameBase::setIstarget(%beacon, true);
	}
else bottomprint(%cl, "<jc>Target out of range!", 2,AIRSTRIKE);
%cl.cansettarget = false;
schedule(%cl @ ".cansettarget = true;", 5);
if(%cl.targetbeacon > 0 && gamebase::getdataname(%cl.targetbeacon) == "ATB") deleteobject(%cl.targetbeacon);
%cl.targetbeacon = %beacon;
%cl.lasttargettime = getSimTime();
schedule("Artillery::checkTarget(" @ %cl @ ");", 100);

}

function Artillery::checkTarget(%cl)
{
if(GetsimTime() - %cl.lasttargettime > 98) { if(gamebase::getdataname(%cl.targetbeacon) == "ATB") deleteobject(%cl.targetbeacon); %cl.targetbeacon = ""; }
}
