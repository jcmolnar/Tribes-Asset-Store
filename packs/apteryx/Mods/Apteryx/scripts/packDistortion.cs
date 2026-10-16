$InvList[PhaseShifterPack] = 1;
$MobileInvList[PhaseShifterPack] = 1;
$RemoteInvList[PhaseShifterPack] = 1;
AddItem(PhaseShifterPack);

ItemImageData PhaseShifterPackImage
{	
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 10;
	maxEnergy = 10;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 3.14, 0, 0 };
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.3, 0.1, 0.6 };
	firstPerson = false;
};

ItemData PhaseShifterPack
{	
	description = "Distortion Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = PhaseShifterPackImage;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$CrowAiNumberOut = 0;

function PhaseShifterPackImage::onActivate(%player,%imageSlot)
{
	gamebase::setenergy(%player, gamebase::getenergy(%player) - 30);
//cloak
	%client = player::getclient(%player);
	client::sendmessage(%client, 0, "Distortion field activated");
	startcloak(%client);

//create two ai guys - first create two mission groups in the CrowsAI folder
//each such group has two points - spawning then a point in the distance for the guy to travel towards
//I will need the player's position, then two random vectored go to points
	%rot = gamebase::getrotation(%player);
	%xrot = 0;
	%yrot = 0;
	%zrot = getword(%rot, 2);
	%myzrot = getrandom() * 1.5708 + %zrot;
	%myrot = %xrot @ " " @ %yrot @ " " @ %myzrot;
	%pos = gamebase::getposition(%player);
	%pos1spawn = Vector::getfromrot(%myrot, 3);
	%pos1goto = Vector::getfromrot(%myrot, 500);
	%myzrot = getrandom() * -1.5708 + %zrot;
	%myrot = %xrot @ " " @ %yrot @ " " @ %zrot;
	%pos2spawn = Vector::getfromrot(%myrot, 3);
	%pos2goto = Vector::getfromrot(%myrot, 500);

//now create the groups
	$CrowAiGuysOut++;
	%AiName1 = "CrowAi";
	%AiName1 = %AiName1 @ $CrowAiGuysOut;
	instant SimGroup %AiName1
	{
		instant Marker "Spawn"
		{
			datablock = "PathMarker";
			name = "";
			position = Vector::add(%pos, %pos1spawn);
			rotation = "0 0 0";
		};
		instant Marker "Goto"
		{
			datablock = "PathMarker";
			name = "";
			position = Vector::add(%pos, %pos1goto);
			rotation = "0 0 0";
		};
	};
//guy number 2
	$CrowAiGuysOut++;
	%AiName2 = "CrowAi";
	%AiName2 = %AiName2 @ $CrowAiGuysOut;
	instant SimGroup %AiName2
	{
		instant Marker "Spawn"
		{
			datablock = "PathMarker";
			name = "";
			position = Vector::add(%pos, %pos2spawn);
			rotation = "0 0 0";
		};
		instant Marker "Goto"
		{
			datablock = "PathMarker";
			name = "";
			position = Vector::add(%pos, %pos2goto);
			rotation = "0 0 0";
		};
	};
//Now actually create the guys, and set thier teams, and start the cloaks
	%group = nametoid(%AiName1);
	%armor = player::getarmor(%player);
	%PlayerName = Client::getname(%client);
	%team = gamebase::getteam(%player);

	createai(%AiName1, %group, %armor, %PlayerName);
	%AiId = ai::getid(%AiName1);
	startcloak(%AiId);
	%AiPlayerId = client::getownedobject(%AiId);
	gamebase::setteam(%AiId, %team);
	%AiPlayerId.ShieldStrength = 0.02;
	schedule("ai::delete("@%AiName1@");", 21);
//oddly, there is an error when both ai's delete at the same time.  So, I have one delete .5 sec earlier than the other
	
	%group = nametoid(%AiName2);
	createai(%AiName2, %group, %armor, %PlayerName);
	%AiId = ai::getid(%AiName2);
	startcloak(%AiId);
	%AiPlayerId = client::getownedobject(%AiId);
	gamebase::setteam(%AiId, %team);
	%AiPlayerId.ShieldStrength = 0.02;
	schedule("ai::delete("@%AiName2@");", 20.5);

	PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
	player::decitemcount(%player, PhaseShifterPack);
	schedule("player::incitemcount("@%player@", PhaseShifterPack); Player::useitem("@%player@", PhaseShifterPack);", 20);
//oh, yeah, and deal the user some damage.
	gamebase::setdamagelevel(%player, gamebase::getdamagelevel(%player) + 0.2);
}

function PhaseShifterPackImage::onDeactivate(%player,%imageSlot)
{	
	Player::trigger(%player,$BackpackSlot,false);
}

function PhaseShifterPack::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>Distortion Pack:<f2> Usable once every 20 seconds, and hurts you a bit. Creates two images of yourself and cloaks both them and you. Note that the images tend to walk slower than you.");
}