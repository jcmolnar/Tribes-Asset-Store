//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[AccelPPack] = 1;

$TeamItemMax[AccelPPack] = 5;

$ItemMax[larmor, AccelPPack] = 0;	//Seraph
$ItemMax[lfemale, AccelPPack] = 0;	//Seraph
$ItemMax[earmor, AccelPPack] = 1;	//Slave
$ItemMax[efemale, AccelPPack] = 1;	//Slave
$ItemMax[marmor, AccelPPack] = 0;	//Pawn
$ItemMax[aarmor, AccelPPack] = 0;	//Navigator
$ItemMax[darmor, AccelPPack] = 0;	//Atomizer
$ItemMax[barmor, AccelPPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ AccelPPack] = 0;
//	$TeamItemCount[1 @ AccelPPack] = 0;
//	$TeamItemCount[2 @ AccelPPack] = 0;
//	$TeamItemCount[3 @ AccelPPack] = 0;
//	$TeamItemCount[4 @ AccelPPack] = 0;
//	$TeamItemCount[5 @ AccelPPack] = 0;
//	$TeamItemCount[6 @ AccelPPack] = 0;
//	$TeamItemCount[7 @ AccelPPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


ItemImageData AccelPPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AccelPPack
{
	description = "Accelerator Pad";
	shapeFile = "elevator_6x6_octagon";
	className = "Backpack";
	heading = "jTransportation";
	imageType = AccelPPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AccelPPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function AccelPPack::onDeploy(%player,%item,%pos)
{
	if (AccelPPack::deployShape(%player,"AccelPad",AccelPadPack,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"]++;
	}
}

function CreateAccelPadSimSet()
{
	%teleset = nameToID("MissionCleanup/AccelPadPack");
	if(%teleset == -1)
	{
		newObject("AccelPadPack",SimSet);
		addToSet("MissionCleanup","AccelPadPack");
	}
}

function AccelPPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"] < $TeamItemMax[AccelPPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				%sensor = newObject("AccelPadPack","StaticShape",%shape,true);
				CreateAccelPadSimSet();
				addToSet("MissionCleanup/AccelPadPack", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,GameBase::getTeam(%player));
				%pos = Vector::add($los::position,"0 0 -0.25");
				GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
				GameBase::setPosition(%sensor,%pos);
				%Rot=GameBase::getRotation(%player);
				%Rot=Vector::add(%Rot,"0 0 3.14159");
				GameBase::setRotation(%sensor,%rot);
				GameBase::setPosition(%sensor,%pos);
				Gamebase::setMapName(%sensor,"Accel Pad");
				Client::sendMessage(%client,0,%item.description @ " deployed");
				echo("MSG: ",%client," deployed an Accelerator Pad ");
				%sensor.disabled = false;
				%sensor.activated=false;
				GameBase::startFadeIn(%sensor);
				playSound(SoundPickupBackpack,$los::position);
				GameBase::startfadein(%sensor);
				return true;
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}