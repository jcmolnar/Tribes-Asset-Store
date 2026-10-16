//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player, %item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::trigger(%player, $BackpackSlot); }
}

//========== Setup ItemMax ==========//
ItemMax(SensorJammerPack, 1, 1, 1, 1, 0, 1);
ItemMax(CloakingDevice, 1, 1, 1, 1, 0, 1);
ItemMax(BorgDevice    , 0, 0, 1, 1, 1, 0);
ItemMax(EnergyPack    , 0, 0, 0, 0, 0, 1);
ItemMax(HackPack      , 0, 0, 1, 1, 0, 1);
ItemMax(HiderPack     , 1, 1, 1, 1, 0, 1);
ItemMax(RepairPack    , 1, 1, 1, 1, 1, 0);
ItemMax(RepairGun     , 0, 0, 0, 0, 0, 1);
ItemMax(ShieldPack    , 1, 1, 1, 1, 1, 1);
ItemMax(SuicidePack   , 1, 1, 1, 1, 1, 1);
ItemMax(AmmoPack      , 0, 0, 1, 1, 1, 1);
//===================================//


//========== Setup InvList ==========//
AddToInv(SensorJammerPack, 1, 1);
AddToInv(CloakingDevice, 1, 1);
AddToInv(SuicidePack, 1, 1);
AddToInv(BorgDevice, 1, 1);
AddToInv(EnergyPack, 1, 1);
AddToInv(RepairPack, 1, 1);
AddToInv(RepairGun, 1, 0);
AddToInv(ShieldPack, 1, 1);
AddToInv(AdminPack, 0, 0);
AddToInv(HackPack, 1, 0);
AddToInv(AmmoPack, 1, 1);
AddToInv(HiderPack, 1, 0);
//===================================//