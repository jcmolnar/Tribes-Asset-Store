$InvList[PortableSolarPack] = 1;
$MobileInvList[DeployableInvPack] = 1;
$RemoteInvList[PortableSolarPack] = 1;

function deployPortableSolar::Initialize()
{	$TeamItemCount[0 @ PortableSolarPack] = 0; 
	$TeamItemCount[1 @ PortableSolarPack] = 0; 
	$TeamItemCount[2 @ PortableSolarPack] = 0; 
	$TeamItemCount[3 @ PortableSolarPack] = 0; 
	$TeamItemCount[4 @ PortableSolarPack] = 0; 
	$TeamItemCount[5 @ PortableSolarPack] = 0; 
	$TeamItemCount[6 @ PortableSolarPack] = 0; 
	$TeamItemCount[7 @ PortableSolarPack] = 0; 
}

ItemImageData PortableSolarPackImage 
{	shapeFile = "magCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PortableSolarPack
{	description = "Portable Solar Panel";
	shapeFile = "solar_med";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = PortableSolarPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData PortableSolar 
{	description = "Portable Solar Panel";
	shapeFile = "solar_med";
	classname = "pGen";
	debrisId = flashDebrisSmall;
	maxDamage = 2;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

function PortableSolarPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function PortableSolarPack::onDeploy(%player,%item,%pos)
{	if (PortableSolarPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function PortableSolarPack::deployShape(%player,%item)
{	//  Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,PortableSolar,3,4,0,0,false,2,150);
}

function PortableSolar::onDestroyed(%this)
{	if($trace) 
		echo($ver,"|PortableSolar::onDestroyed");
	PortableSolar::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function PortableSolar::onEnabled(%this)
{	if($trace) echo($ver,"|PortableSolar::onEnabled");
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
}

function PortableSolar::onDisabled(%this)
{	if($trace) echo($ver,"|PortableSolar::onDisabled");
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}
