$InvList[SuicidePack] = 1;
$MobileInvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;
AddItem(SuicidePack);

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
	description = "Suicide DetPack";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = $InvHead[ihBac];
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
	%obj = newObject("","Mine","Suicidebomb2");
	%obj.timer = %clientId.suicideTimer;
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,3 * %clientId.throwStrength,false);
	if(%obj.timer > 0)
		Client::sendMessage(%clientId,1,"Det Pack will destruct in " @ %obj.timer @ " seconds");
	else
		Client::sendMessage(%clientId,1,"Your Det Pack was set to INSTANT");
	schedule("Mine::Detonate(" @ %obj @ ");",%obj.timer,%obj);
}
