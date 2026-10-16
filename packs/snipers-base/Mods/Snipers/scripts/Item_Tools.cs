//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon 
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onUse(%player,%item) 
{
	%ammo = %item.imageType.ammoType;
	if (%ammo == "") 
	Player::mountItem(%player,%item,$WeaponSlot);
	else 
	{
		if (Player::getItemCount(%player,%ammo) > 0) 
		Player::mountItem(%player,%item,$WeaponSlot);
		else 
		Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo"));
	}
}

ItemData Tool 
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item) 
{
	Player::mountItem(%player,%item,$ToolSlot);
}

ItemData Ammo 
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item) 
{
	if($matchStarted) 
	{
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) 
		{
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count;
			else %delta = %count - 1;
			}
			if(%delta > 0) 
			{
			%obj = newObject("","Item",%item,%delta,false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}
