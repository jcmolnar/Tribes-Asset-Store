$InvList[MobileGenPack] = 1;
$MobileInvList[MobileGenPack] = 1;
$RemoteInvList[MobileGenPack] = 1;

ItemImageData MobileGenImage 
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};

ItemData MobileGenPack
{	description = "Portable Generator";
	shapeFile = "generator_p";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = MobileGenImage;
	shadowDetailMask = 4;
	mass = 4.5;
	elasticity = 0.2;
	price = 2500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData MobileGen
{	description = "Portable Generator";
	shapeFile = "generator_p";
	classname = "pGen";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 1.8;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};

function deployMobileGen::Initialize()
{	$TeamItemCount[0 @ MobileGenPack] = 0; 
	$TeamItemCount[1 @ MobileGenPack] = 0; 
	$TeamItemCount[2 @ MobileGenPack] = 0; 
	$TeamItemCount[3 @ MobileGenPack] = 0; 
	$TeamItemCount[4 @ MobileGenPack] = 0; 
	$TeamItemCount[5 @ MobileGenPack] = 0; 
	$TeamItemCount[6 @ MobileGenPack] = 0; 
	$TeamItemCount[7 @ MobileGenPack] = 0; 
}

function MobileGenPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function MobileGenPack::onDeploy(%player,%item,%pos)
{	if (MobileGenPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function MobileGenPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MobileGen,1,5,0,0,true,2,200);
}

function MobileGen::onAdd(%this)
{
}

function MobileGen::onDestroyed(%this)
{	
	if($trace) echo($ver,"| MobileGen::onDestroyed");
	MobileGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function MobileGen::onEnabled(%this)
{	
	if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
}

function MobileGen::onDisabled(%this)
{	
	if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
 	//DisconnectGenerator(%this);
}

