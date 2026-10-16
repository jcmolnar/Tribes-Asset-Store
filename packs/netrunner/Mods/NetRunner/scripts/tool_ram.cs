$InvList[Ram] = 1;
$RemoteInvList[Ram] = 1;

ItemImageData RamImage
{
	shapeFile = "grenammo";
	mountPoint = 4;
	mass = 0.0;
};

ItemData Ram
{
	description = "Ram Upgrade";
	className = "Tool";
	shapeFile = "grenammo";
	heading = $InvHead[iTool];
	shadowDetailMask = 4;
	imageType = RamImage;
	price = 0;
	showWeaponBar = false;
	mass = 0.0;
};

function Ram::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	if(%client.power < 1) return;
	%client.ammom += 0.100001;
	%client.power--;
}
