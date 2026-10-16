$InvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = $InvHead[iMisc];
	shadowDetailMask = 4;
	price = 35;
};

function RepairKit::onUse(%player,%item)
{
	if($time[$ExplosionDamageType, %player] > 0) $time[$ExplosionDamageType, %player] = 0;
	if($time[$MissileDamageType, %player] > 0) $time[$MissileDamageType, %player] = 0;
	if($time[$MineDamageType, %player] > 0) $time[$MineDamageType, %player] = 0;
	%player.tracing = "";
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}