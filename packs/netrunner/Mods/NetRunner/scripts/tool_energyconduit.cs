$InvList[EnergyConduit] = 1;
$RemoteInvList[EnergyConduit] = 1;

ItemImageData EnergyConduitImage
{
	shapeFile = "grenammo";
	mountPoint = 4;
	mass = 0.0;
};

ItemData EnergyConduit
{
	description = "Energy Conduit";
	className = "Tool";
	shapeFile = "grenammo";
	heading = $InvHead[iTool];
	shadowDetailMask = 4;
	imageType = EnergyConduitImage;
	price = 0;
	showWeaponBar = false;
	mass = 0.0;
};

function EnergyConduit::onUse(%player, %item)
{
	%client = GameBase::getOwnerClient(%player);
	if(%client.power < 1) return;
	%client.recha += 2;
	%client.power--;
	GameBase::setRechargeRate(%player, (8 + %client.recha));
}
