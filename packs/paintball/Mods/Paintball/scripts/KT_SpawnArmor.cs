// ----------------------------------------------------------------------------
// Paintball Mod
//
// Mod gutted by KingTomato
// Original coding by |K0RN|, with help from [RR]MisterPibb
// ----------------------------------------------------------------------------

// This file will basically take care of the spawn items for each player.
// Each play, after joining, will be asked which weapon and pack they would
// like on spawn. Then, the script will set it up, and use those settings each
// player spawn. The settings, however, are only good on a per connection basis.
// This means that when a player leaves the server, the favorites will go with
// them.

// List of weapon names...
function processMenuSpawnArmor(%clientId, %options, %closable)
{
	%curItem = 0;

	if (%closable == "")
		%closable = false;

	// Setup a list of weapons and packs
	%items = getNumItems();
	for (%a = 0; %a < %items; %a++)
	{
		%item = getItemData(%a);
		if ($InvList[%item])
		{
			if (%item.className == "Weapon")
				%weapons = %weapons @ %a @ " ";
			else if (%item.className == "Backpack")
				%backpacks = %backpacks @ %a @ " ";
		}
	}

	%opt = getWord(%options, 0);

	// Build the menu of weapons
	if (%opt == "Weapon")
	{
		%start = getWord(%options, 1);
		if (%start == -1)
			%start = 0;
			
		Client::buildMenu(%clientId, "Spawn Items (Weapon)", "SpawnArmor", %closable);

		for (%a = %start; %a < (%start + 7); %a++)
		{
			%weap = getWord(%weapons, %a);
			if (%weap != -1)
			{
				%weapon = getItemData(%weap);
				Client::AddMenuItem(%clientId, %curItem++ @ %weapon.description, "PickWeapon " @ %weap);
			}
			else if (%start != 0)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Back To Beginning", "Weapon 0");
				break;
			}
		}
		if (getWord(%weapons, %a) != -1)
			Client::AddMenuItem(%clientId, %curItem++ @ "More Weapons...", "Weapon " @ %a);
	}

	// Pick weapons
	else if (%opt == "PickWeapon")
	{
		%sel = getWord(%options, 1);
		%item = getItemData(%sel);

		if (%item.className != "Weapon")
		{
			processMenuSpawnArmor(%clientId, "Weapon");
		}
		else
		{
			%clientId.SpawnBuy[Weapon] = %sel;
			processMenuSpawnArmor(%clientId, "Backpack");
		}
	}

	// Pick backpack
	else if (%opt == "Backpack")
	{
		%start = getWord(%options, 1);
		if (%start == -1)
			%start = 0;
			
		Client::buildMenu(%clientId, "Spawn Items (Pack)", "SpawnArmor", %closable);
		for (%a = %start; %a < (%start + 7); %a++)
		{
			%pack = getWord(%backpacks, %a);
			if (%pack != -1)
			{
				%backpack = getItemData(%pack);
				Client::AddMenuItem(%clientId, %curItem++ @ %backpack.description, "PickPack " @ %pack);
			}
			else if (%start != 0)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Back", "Backpack 0");
				break;
			}
		}
		if (getWord(%backpacks, %a) != -1)
			Client::AddMenuItem(%clientId, %curItem++ @ "More Backpacks...", "Backpack " @ %a);
	}

	// Pick Backpack
	else if (%opt == "PickPack")
	{
		%sel = getWord(%options, 1);
		%item = getItemData(%sel);

		if (%item.className != "Backpack")
		{
			processMenuSpawnArmor(%clientId, "Backpack");
		}
		else
		{
			%clientId.SpawnBuy[Pack] = %sel;

			%weapon = getItemData(%clientId.SpawnBuy[Weapon]);
			%backpack = getItemData(%clientId.SpawnBuy[Pack]);

			%msg = "<jc><f2>Shopping List Configured\n\n";
			%msg = %msg @ "<f1>Backpack: <f0>" @ %backpack.description @ "\n<f1>Weapon: <f0>" @ %weapon.description;
			bottomPrint(%clientId, %msg, 10);

			if (%clientId.needsToSpawn != "")
				Player::Kill(%clientId);
		}
	}
}

Event::Attach(Game_initialMissionDrop, SpawnArmor::Display);

function SpawnArmor::Display(%clientId)
{
	if (!$Money::Enabled)
		processMenuSpawnArmor(%clientId, "Weapon");
}