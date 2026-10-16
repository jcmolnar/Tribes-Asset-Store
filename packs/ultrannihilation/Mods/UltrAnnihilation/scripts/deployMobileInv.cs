$InvList[MobileInvPack]	= 1;
$MobileInvList[MobileInvPack] = 0;
$RemoteInvList[MobileInvPack] = 0;

$CanAlwaysTeamDestroy[MobileInv] = 1;

ItemImageData MobileInvPackImage 
{	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};

ItemData MobileInvPack
{	description = "Mobile Inventory Stn";
	shapeFile = "inventory_sta";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = MobileInvPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData MobileInv
{	description = "Mobile Supply Unit";
	shapeFile = "inventory_sta";
	classname = "MobileStation";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.5;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
	shieldShapeName = "shield";
};

function deployMobileInv::Initialize()
{	$TeamItemCount[0 @ MobileInvPack] = 0; 
	$TeamItemCount[1 @ MobileInvPack] = 0; 
	$TeamItemCount[2 @ MobileInvPack] = 0; 
	$TeamItemCount[3 @ MobileInvPack] = 0; 
	$TeamItemCount[4 @ MobileInvPack] = 0; 
	$TeamItemCount[5 @ MobileInvPack] = 0; 
	$TeamItemCount[6 @ MobileInvPack] = 0; 
	$TeamItemCount[7 @ MobileInvPack] = 0; 
}

function MobileInvPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function MobileInvPack::onDeploy(%player,%item,%pos)
{	if (MobileInvPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function MobileInvPack::onDestroyed(%this)
{	if($trace) 
		echo($ver,"| MobileInvPack::onDestroyed");
	MobileInvPack::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
	$TeamItemCount[GameBase::getTeam(%this) @ "MobileInvPack"]--;
}

function MobileInvPack::onDisabled(%this)
{	if($trace) 
		echo($ver,"| MobileInvPack::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
// 	GameBase::generatePower(%this, false);
}

function MobileInvPack::deployShape(%player,%item)
{	//Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MobileInv,1,5,0,0,true,1,250);
}

function MobileInv::onEndSequence(%this,%thread)
{	if (Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"MobileInvList");
}
