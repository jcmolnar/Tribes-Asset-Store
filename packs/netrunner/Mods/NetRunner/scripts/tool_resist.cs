$InvList[Resist] = 1;
$RemoteInvList[Resist] = 1;

ItemImageData ResistImage
{
	shapeFile = "grenammo";
	mountPoint = 4;
	mass = 0.0;
};

ItemData Resist
{
	description = "Armor";
	className = "Tool";
	shapeFile = "grenammo";
	heading = $InvHead[iTool];
	shadowDetailMask = 4;
	imageType = ResistImage;
	price = 0;
	showWeaponBar = false;
	mass = 0.0;
};

function Resist::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	if(%client.power < 1) return;
	%client.resis += 0.100001;
	%client.power--;
}
