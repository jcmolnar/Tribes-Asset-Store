$InvList[SightPack] = 1;
$MobileInvList[SightPack] = 1;
$RemoteInvList[SightPack] = 1;
AddItem(SightPack);

ItemImageData SightPackImage
{	
	shapeFile = "sensor_small";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 25;
	maxEnergy = 50;
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.8, 0.8, 0.1 };
	firstPerson = false;

	sfxFire = SoundFireLaser;
};

ItemData SightPack
{	
	description = "Reversion Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = SightPackImage;
	price = 250;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SightPackImage::onActivate(%player,%imageSlot)
{	
	gamebase::setenergy(%player, gamebase::getenergy(%player) - 40);
	schedule("gamebase::setposition(" @ %player @ ", \"" @ gamebase::getposition(%player) @ "\");",1);
	Player::trigger(%player,$BackpackSlot,false);
}

function SightPackImage::onDeactivate(%player,%imageSlot)
{	
	Player::trigger(%player,$BackpackSlot,false);
}

function SightPack::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>Reversion Pack:<f2> In one second, it will teleport you to where you were when you first activated it.  Useful for dodging. ");
}