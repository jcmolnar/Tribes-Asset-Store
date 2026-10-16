//==========================================
// This handles spawn load-outs...
//==========================================

//==========================================
//== Player spawns with NO saved profile and NO Favs set.

if (!$Wasteland::SaveOn)
{
	if ($Debug) echo ("Loading Standard Equip Set");
	$spawnBuyList[0] = MediumArmor;
	$spawnBuyList[1] = RepairPack;
	$spawnBuyList[2] = Chaingun;
	$spawnBuyList[3] = Disclauncher;
	$spawnBuyList[4] = GrenadeLauncher;
	$spawnBuyList[5] = HyperB;
	$spawnBuyList[6, %client] = "";
	$fa_armor = "Patriot";
	$fa_pack = "RepairPack";
}


//==========================================
//== Standard Spawn Options

function standardSpawnlist(%client)
{

	if ($Debug) echo ("----------------------->Spawning Standard");
	$spawnBuyList[0, %client] = MediumArmor;
	$spawnBuyList[1, %client] = HyperB;
	$spawnBuyList[2, %client] = Chaingun;
	$spawnBuyList[3, %client] = Disclauncher;
	$spawnBuyList[4, %client] = GrenadeLauncher;
	$spawnBuyList[5, %client] = RepairPack;
	$spawnBuyList[6, %client] = "";
	$fa_armor = "Patriot";
	$fa_pack = "RepairPack";

}

//==========================================
//== Player Spawned with saved options.

function savedSpawnList(%clientId)
{
	for(%i = 0; %clientId.SavedList[%i] != ""; %i++)
	{
		%item = GetWord(%clientId.SavedList[%i], 0);

		$spawnBuyList[%i, %clientId] = %item;
	}

	if (%clientId.favsettings)
		%clientId.spawntype = %clientId.spawntypetwo;

	%clientId.spawn = false;

	schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>You have spawned with your previously saved favorites.\", 4);", 4);
}

//==========================================
//== Player Spawned with Favs set.

function favoriteSpawnList(%client)
{
	if ($Debug) echo ("----------------------->Spawning Favorites");
	%clientId = %client;

	if (%client.favsettings)
	{
		if ($SpawnFavs)
		{
			%error = 0;
			%max = getNumItems();

			if ($debug) echo ("Checking Items");

			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%item = getItemData(%i);
				%count = Player::getItemCount(%client,%item);

				if(%count)
				{
					if(%item.className != Armor)
						teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
					Player::setItemCount(%client, %item, 0);
				}
			}

			if ($debug) echo ("Buying New");

			for (%i = 0; %i <= 19; %i++)
			{
				if(%client.fav[%i] != "")
				{
					%item = getItemData(%client.fav[%i]);
					if ($debug) echo ("Bought " @ %i @ " - " @ %item @ "");
					if (%i == 0)
					{
						$fa_armor = %item.description;
					}
					$spawnBuyList[%i, %clientId] = %item;
				}
		  	}
		}
	}
}

//==========================================
//== Player Spawns in random armor setting.

function randomSpawnList(%client)
{

	if ($Debug) echo ("----------------------->Spawning Random");

	%rnd = floor(getRandom() * 50);
	if ($debug) echo("Setting Up Gear For Random Spawn" @ %rnd @ " - ");
	if (%rnd <= 20) //=========================== Most of the time
	{
		if ($debug) echo("Spawn - Standard");
		$spawnBuyList[0, %client] = MediumArmor;
		$spawnBuyList[1, %client] = RepairPack;
		$spawnBuyList[2, %client] = Chaingun;
		$spawnBuyList[3, %client] = Disclauncher;
		$spawnBuyList[4, %client] = GrenadeLauncher;
		$spawnBuyList[5, %client] = HyperB;
		$spawnBuyList[6, %client] = "";
		$fa_armor = "Patriot";
		$fa_pack = "RepairPack";
	}
	if ((%rnd >= 21) && (%rnd <= 35))
	{
		if ($debug) echo("Spawn - Dreadnaught");
		$spawnBuyList[0, %client] = HeavyArmor;
		$spawnBuyList[1, %client] = EnergyPack;
		$spawnBuyList[2, %client] = Vulcan;
		$spawnBuyList[3, %client] = Disclauncher;
		$spawnBuyList[4, %client] = GrenadeLauncher;
		$spawnBuyList[5, %client] = Mortar;
		$spawnBuyList[6, %client] = "";
		$fa_pack = "EnergyPack";
		$fa_armor = "Dreadnaught";
	}
	if ((%rnd >= 36) && (%rnd <= 40))
	{
		$spawnBuyList[0, %client] = BursterArmor;
		$spawnBuyList[1, %client] = EnergyPack;
		$spawnBuyList[2, %client] = RocketLauncher;
		$spawnBuyList[3, %client] = Flamer;
		$spawnBuyList[4, %client] = Mortar;
		$spawnBuyList[5, %client] = GrenadeLauncher;
		$spawnBuyList[6, %client] = "";
		$fa_pack = "EnergyPack";
		$fa_armor = "Goliath";
	}

	if ((%rnd >= 41) && (%rnd <= 45))
	{
		if ($debug) echo("Spawn - Arbitor");
		$spawnBuyList[0, %client] = AlArmor;
		$spawnBuyList[1, %client] = EnergyPack;
		$spawnBuyList[2, %client] = Volter;
		$spawnBuyList[3, %client] = Chaingun;
		$spawnBuyList[4, %client] = RepairKit;
		$spawnBuyList[5, %client] = ConCun;
		$spawnBuyList[6, %client] = HyperB;
		$spawnBuyList[7, %client] = "";
		$fa_pack = "EnergyPack";
		$fa_armor = "Arbitor";
	}

	if ((%rnd >= 46) && (%rnd <= 48))
	{
		if ($debug) echo("Spawn - Engineer 1");
		$spawnBuyList[0, %client] = EngArmor;
		$spawnBuyList[1, %client] = RepairPack;
		$spawnBuyList[2, %client] = FixIt;
		$spawnBuyList[3, %client] = DiscLauncher;
		$spawnBuyList[4, %client] = RailGun;
		$spawnBuyList[5, %client] = RocketLauncher;
		$spawnBuyList[6, %client] = Hackit;
		$spawnBuyList[7, %client] = "";
		$fa_pack = "RepairPack";
		$fa_armor = "Engineer1";
	}
	if ((%rnd == 49) || (%rnd == 50))
	{
		if ($debug) echo("Spawn - Engineer 2");
		$spawnBuyList[0, %client] = EngArmor;
		$spawnBuyList[1, %client] = DeployableInvPack;
		$spawnBuyList[2, %client] = DiscLauncher;
		$spawnBuyList[3, %client] = RocketLauncher;
		$spawnBuyList[4, %client] = RailGun;
		$spawnBuyList[5, %client] = Hackit;
		$spawnBuyList[6, %client] = "";
		$fa_pack = "Inventory Station";
		$fa_armor = "Engineer2";
	}

	if(!$Wasteland::SpawnRandom && !%client.favsettings)
	{
		if ($debug) echo("Spawn - Standard - No Random");
		$spawnBuyList[0, %client] = MediumArmor;
		$spawnBuyList[1, %client] = RepairPack;
		$spawnBuyList[2, %client] = Chaingun;
		$spawnBuyList[3, %client] = Disclauncher;
		$spawnBuyList[4, %client] = HyperB;
		$spawnBuyList[5, %client] = GrenadeLauncher;
		$spawnBuyList[6, %client] = "";
		$fa_pack = "RepairPack";
		$fa_armor = "Patriot";
	}
}