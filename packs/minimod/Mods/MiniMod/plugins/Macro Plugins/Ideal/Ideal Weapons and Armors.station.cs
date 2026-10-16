// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!

$InvList[RealTargetingLaser] = 1;
$RemoteInvList[RealTargetingLaser] = 1;

$InvList[TractorBeam] = 1;
$RemoteInvList[TractorBeam] = 1;


$InvList[FlagMine] = 1;
$RemoteInvList[FlagMine] = 1;

$InvList[ReplicatingMine] = 1;
$RemoteInvList[ReplicatingMine] = 1;

$InvList[OriginalMine] = 1;
$RemoteInvList[OriginalMine] = 1;

$InvList[ChangelingNet] = 1;
$RemoteInvList[ChangelingNet] = 1;

$InvList[FlagMovePack] = 1;
$RemoteInvList[FlagMovePack] = 1;

$InvList[Marlin] = 1;
$RemoteInvList[Marlin] = 1;

$InvList[MarlinAmmo] = 1;
$RemoteInvList[MarlinAmmo] = 1;

$InvList[laserchaingun] = 1;
$RemoteInvList[LaserChaingun] = 1;

$InvList[slowgun] = 1;
$RemoteInvList[slowgun] = 1;

$InvList[slowgunammo] = 1;
$RemoteInvList[slowgunammo] = 1;

$InvList[concuss] = 1;
$RemoteInvList[concuss] = 1;

$InvList[concussammo] = 1;
$RemoteInvList[concussammo] = 1;

$InvList[special] = 1;

$InvList[SpecialistPack] = 1;
$RemoteInvList[SpecialistPack] = 1;

$InvList[cloaker] = 1;
$RemoteInvList[cloaker] = 1;

$InvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 1;

$InvList[C4Ammo] = 1;
$RemoteInvList[C4Ammo] = 1;

$InvList[HandgrenadeAmmo] = 1;
$RemoteInvList[HandgrenadeAmmo] = 1;

$InvList[SuicideAmmo] = 1;
$RemoteInvList[SuicideAmmo] = 1;

$InvList[FlashgrenadeAmmo] = 1;
$RemoteInvList[FlashgrenadeAmmo] = 1;

$InvList[StungrenadeAmmo] = 1;
$RemoteInvList[StungrenadeAmmo] = 1;

$InvList[JetfirePack] = 1;
$RemoteInvList[JetfirePack] = 0;

$DataBlockName[JetfireVehicle] = Jetfire;
$VehicleToItem[Jetfire] = JetfireVehicle;

function AmmoStation::resupply(%player,%weapon,%item,%delta)
{
	%delta = checkResources(%player,%item,%delta,1);		
	if(%delta > 0)
		{						
		if(%item == RepairPatch)
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			GameBase::repairDamage(%player,0.06);
		 	return %delta;
		}
		else if (%item == RepairKit)
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
		else if(%item.className == "Grenade") //mod:
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			Player::incItemCount(%player,Grenade,%delta);
		 	return %delta;
		}
		else if(%item.className == "Mine") //mod:
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			Player::incItemCount(%player,MineAmmo,%delta);
		 	return %delta;
		}
		else if (Player::getItemCount(%player,%weapon))
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
	}
	return 0;
}


