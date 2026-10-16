$InvList[RepairKit] = 1;
$MobileInvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;

$AutoUse[RepairKit] = false;

addAmmo("", RepairKit, 1);

ItemData RepairKit 
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 35;
};

function RepairKit::onUse(%player,%item) 
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
	%c = Player::getClient(%player);
	 // Alliance armor support
	%armor = Player::getArmor(%player);
	eval(%armor @ "::onRepairKit(" @ %player @ ");");
}
