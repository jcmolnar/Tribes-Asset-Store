ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description    = "Inventory Station";
	shapeFile      = "invent_remote";
	className      = "Backpack";
    heading        = $InvHeading[Deployables];
	shadowDetailMask = 4;
	imageType      = DeployableInvPackImage;
	mass           = 2.0;
	elasticity     = 0.2;
	price          = 30000;
	hudIcon        = "deployable";
	showWeaponBar  = true;
	hiliteOnActive = true;
};

function DeployableInvPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function DeployableInvPack::onDeploy(%player,%item,%pos)
{ if(DeployableInvPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s"); return false; }
	
	if(!GameBase::getLOSInfo(%player, 5))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false;}
	 
	%Set = newObject("set", SimSet);
	%Mask = $StaticObjectType;
	%num = containerBoxFillSet(%Set, %Mask, $los::position, 999, 999, 999, 0);
	for(%i; %i < %num; %i++)
	{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
			%inbase = true;
			break;
		}
	}
	deleteObject(%Set);
	
	if(!%inbase)
	{ bottomprint(%client, "<jc><f1>Fair play distance exceeded for " @ %item.description @ "s", 3); return false; }
	
	%obj = getObjectType($los::object);
	
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape" && %obj != "Turret")
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }
	
	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false;}
	
	%inv = newObject("ammounit_remote", "StaticShape", "DeployableInvStation",true);
	addToSet("MissionCleanup", %inv);
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv, GameBase::getTeam(%player));
	GameBase::setPosition(%inv, $los::position);
	GameBase::setRotation(%inv, %rot);
	Gamebase::setMapName(%inv, %item.description);
	Client::sendMessage(%client, 0, "Inventory Station deployed.");
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%inv) @"DeployableInvPack"]++;
	echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed an Inventory Station.");
	return true;
}