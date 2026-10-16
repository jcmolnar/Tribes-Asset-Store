$InvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;

$ItemMax[narmor, SuicidePack] = 0;
$ItemMax[aarmor, SuicidePack] = 0;
$ItemMax[darmor, SuicidePack] = 1;
$ItemMax[nfemale, SuicidePack] = 0;
$ItemMax[afemale, SuicidePack] = 0;
$ItemMax[warmor, SuicidePack] = 1;
$ItemMax[barmor, SuicidePack] = 1;
$ItemMax[sarmor, SuicidePack] = 1;
$ItemMax[avarmor, SuicidePack] = 1;
$ItemMax[wfemale, SuicidePack] = 1;
$ItemMax[bfemale, SuicidePack] = 1;

ItemImageData SuicidePackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SuicidePack
{
	description = "Suicide Pack";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = "eBackpacks";
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SuicidePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function SuicidePack::onUnmount(%player,%item)
{
}

function SuicidePack::onDeploy(%player,%item,%pos)
{
	if(SuicidePack::deployShape(%player,%item)&& !$build)
		Player::decItemCount(%player,%item);
}

function SuicidePack::deployShape(%player,%item)
{
	%clientId = Player::getClient(%player);
	Player::unmountItem(%player,$BackpackSlot);
	%obj = newObject("","Mine","Suicidebomb");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,3 * %clientId.throwStrength,false);
	Client::sendMessage(%clientId,1,"For My Country!");
	schedule("Mine::Detonate(" @ %obj @ ");",0.1,%obj);
}