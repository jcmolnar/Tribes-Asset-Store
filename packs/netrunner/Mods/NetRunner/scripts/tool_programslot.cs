$InvList[ProgramSlot] = 1;
$RemoteInvList[ProgramSlot] = 1;

ItemImageData ProgramSlotImage
{
	shapeFile = "grenammo";
	mountPoint = 4;
	mass = 0.0;
};

ItemData ProgramSlot
{
	description = "Program Slot";
	className = "Tool";
	shapeFile = "grenammo";
	heading = $InvHead[iTool];
	shadowDetailMask = 4;
	imageType = ProgramSlotImage;
	price = 0;
	showWeaponBar = false;
	mass = 0.0;
};

function ProgramSlot::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	if(%client.power < 1) return;
	%client.maxwp++;
	%client.power--;
}
