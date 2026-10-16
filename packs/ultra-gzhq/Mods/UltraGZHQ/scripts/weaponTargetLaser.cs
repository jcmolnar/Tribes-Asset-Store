$InvList[TargetingLaser] = 1;
$MobileInvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;

AddItem(TargetingLaser);	// adding this way so doesnt cycle 
$AutoUse[TargetingLaser] = False;


ItemImageData TargetingLaserImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 2;	//15
	reloadTime = 1.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser 
{
	description = "Targeting Laser";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "targetlaser";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = TargetingLaserImage;
	price = 50;
	showWeaponBar = false;
};

function TargetingLaser::onMount(%player,%item)
{	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Target Laser: <f2>Mounted");
}

function TargetingLaser::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	%playerteam = GameBase::getTeam(%player);
	%playerpos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%pos = %flag.originalposition;
	%playerposX = getWord(%playerpos,0);
	%playerposY = getWord(%playerpos,1);
	%playerposZ = getWord(%playerpos,2)*1;
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);
	%posZ = getWord(%pos,2)*1;
	%distance = (%playerposZ - %posZ)*1;
	if(%playerposZ > %posZ)
		{
		bottomprint(%clientId, "<jc><f0>You are <f1>" @ %distance @ " <f0>meters <f1>ABOVE <f0>your flag.", 3);
		}
	else
		{
		bottomprint(%clientId, "<jc><f1>You are <f0>" @ %distance * -1 @ " <f1>meters <f0>BELOW <f1>your flag.", 3);
		}
}
