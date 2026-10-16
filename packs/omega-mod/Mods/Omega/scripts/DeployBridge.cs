//----Armor Data.c§
$ItemMax[larmor, BridgePack] = 0;
$ItemMax[lfemale, BridgePack] = 0;
$ItemMax[marmor, BridgePack] = 1;
$ItemMax[mfemale, BridgePack] = 1;
$ItemMax[harmor, BridgePack] = 0;
//------Things that make it work :)

$InvList[BridgePack] = 1;
$RemoteInvList[BridgePack] = 1;
$TeamItemMax[BridgePack] = 60;

function deployBridgePack::Initialize()
{
	$TeamItemCount[0 @ BridgePack] = 0;
	$TeamItemCount[1 @ BridgePack] = 0;
	$TeamItemCount[2 @ BridgePack] = 0;
	$TeamItemCount[3 @ BridgePack] = 0;
	$TeamItemCount[4 @ BridgePack] = 0;
	$TeamItemCount[5 @ BridgePack] = 0;
	$TeamItemCount[6 @ BridgePack] = 0;
	$TeamItemCount[7 @ BridgePack] = 0;
}

ItemImageData BridgePackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData BridgePack
{
	description = "Bridge Kit";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = iBarrier;
	imageType = BridgePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};
function BridgePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function BridgePack::onDeploy(%player,%item,%pos)
{
	if(BridgePack::deployShape(%player,%item)&& !$build) 
		Player::decItemCount(%player,%item);
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{	%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function BridgePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,0,0,0,0);
	%num = CountObjects(%set,"flatbrdg10241",%num);
	deleteObject(%set);
	if(0 < %num) 
	{
		Client::sendMessage(%client,0,"Too close to other objects.");
		return false;
	}
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,0,0,0,0);
	%num = CountObjects(%set,"flatbrdg10241",%num);
	deleteObject(%set);
	if(0 != %num) 
	{
		Client::sendMessage(%client,0,"Too close to other objects.");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!BridgeDeployArea(%client,$los::position))
	{
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%vctr = "0 0 0";
	%rot = Vector::add(%rot,%vctr);
	%Bridge = newObject("flatbrdg10241",InteriorShape,"flatbrdg1024.dis",false);
	NukeList(%Bridge);
	addToSet("MissionCleanup", %Bridge);
	GameBase::setTeam(%Bridge,GameBase::getTeam(%player));
	GameBase::setPosition(%Bridge,$los::position);
	GameBase::setRotation(%Bridge,%rot);
	Client::sendMessage(%client,3,"Bridge Deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "BridgePack"]++;
	echo("MSG: ",%client," deployed a bridge");
	return true;
}

function BridgeDeployArea(%client,%pos)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0.5);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{ 
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return 0;
}