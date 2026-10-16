$PickupSound[Backpack] = "SoundPickupBackpack";

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot);
	}
}

echo('>> Loading Packs');
exec(pack_ammopack);
exec(pack_camerapack);
exec(pack_deployableammopack);
exec(pack_deployableinvpack);
exec(pack_deployablesensorjammerpack);
exec(pack_energypack);
exec(pack_motionsensorpack);
exec(pack_pulsesensorpack);
exec(pack_repairpack);
exec(pack_sensorjammerpack);
exec(pack_shieldpack);
exec(pack_turretpack);
exec(pack_rotpack);
exec(pack_solburnpack);
exec(pack_omnipack);
exec(pack_cloakpack);
exec(pack_exponentialpack);
exec(pack_springboardpack);
exec(pack_arkfirepack);
exec(pack_datawallpack);
exec(pack_firewallpack);
echo('>> Finished Loading Packs');