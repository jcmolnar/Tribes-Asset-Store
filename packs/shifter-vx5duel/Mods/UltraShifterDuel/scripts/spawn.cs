// This handles spawn load-outs...
//===============================================================================================================

//===============================================================================================================
//== Player spawns with NO saved profile and NO Favs set.

if (!$Shifter::SaveOn)
{
	if ($Debug) echo ("Loading Standard Equip Set");
	$spawnBuyList[0] = MediumArmor;
	$spawnBuyList[1] = Mortar;
	$spawnBuyList[2] = RocketLauncher;
	$spawnBuyList[3] = Disclauncher;
	$spawnBuyList[4] = RepairKit; 
	$spawnBuyList[5] = GrenadeLauncher; 
	$spawnBuyList[6] = Grenade; 
	$spawnBuyList[7] = Grenade; 
	$spawnBuyList[8] = Grenade;
	$spawnBuyList[9] = Beacon;
	$spawnBuyList[10] = Beacon;
	$spawnBuyList[11] = Beacon;
	$spawnBuyList[12] = Beacon;
	$spawnBuyList[13] = TargetingLaser;
	$spawnBuyList[14] = RepairPack;
	$spawnBuyList[15] = "PlasmaGun";
	$fa_armor = "Mercenary";
	$fa_pack = "RepairPack";
}


//===============================================================================================================
//== Standard Spawn Options

function standardSpawnlist(%client)
{

	if ($Debug) echo ("----------------------->Spawning Standard");
	$spawnBuyList[0, %client] = EngArmor;
	$spawnBuyList[1, %client] = PlasmaGun;
	$spawnBuyList[2, %client] = RailGun;
	$spawnBuyList[3, %client] = Disclauncher;
	$spawnBuyList[4, %client] = RocketLauncher ; 
	$spawnBuyList[5, %client] = GrenadeLauncher; 
	$spawnBuyList[6, %client] = FixIt; 
	$spawnBuyList[7, %client] = RepairKit;
	$spawnBuyList[8, %client] = Grenade;
	$spawnBuyList[9, %client] = Grenade;
	$spawnBuyList[10, %client] = Grenade;
	$spawnBuyList[11, %client] = Beacon;
	$spawnBuyList[12, %client] = Beacon;
	$spawnBuyList[13, %client] = Beacon;
	$spawnBuyList[14, %client] = DeployableInvPack;
	$spawnBuyList[15, %client] = "";
	$fa_armor = "Engineer";
	$fa_pack = "Invo. Station";
}

//===============================================================================================================
//== Player Spawned with saved options.

function savedSpawnList(%clientId)
{

	if ($Debug) echo ("----------------------->Spawning Saved");
	
	if ($debug) echo("Loading armor " @ %clientId.SavedList[0] @ " for " @ %clientId);
	   	
	for(%i = 0; %clientId.SavedList[%i] != ""; %i++)
	{
		%item = GetWord(%clientId.SavedList[%i], 0);
		%ammt = GetWord(%clientId.SavedList[%i], 1);
		
		$spawnBuyList[%i, %clientId] = %item;
	}
		
	if (%clientId.favsettings)
		%clientId.spawntype = %clientId.spawntypetwo;

	%clientId.spawn = false;

	schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>You have spawned with your previously saved favorites.\", 10);", 3);
}	

//===============================================================================================================
//== Player Spawned with Favs set.

function favoriteSpawnList(%client)
{
	if ($Debug) echo ("----------------------->Spawning Favorites");
	%clientId = %client;
	
	if (%client.favsettings)
	{
		if ($SpawnFav)
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

//===============================================================================================================
//== Player Spawns in random armor setting.

function randomSpawnList(%client)
{

	if ($Debug) echo ("----------------------->Spawning Randonm");

		%rnd = floor(getRandom() * 50);	
		if ($debug) echo("Setting Up Gear For Random Spawn" @ %rnd @ " - ");
		if (%rnd <= 15) //=========================== Most of the time 
		{
			if ($debug) echo("Spawn - SG1 Random");
			$spawnBuyList[0, %client] = EngArmor;
			$spawnBuyList[1, %client] = PlasmaGun;
			$spawnBuyList[2, %client] = RailGun;
			$spawnBuyList[3, %client] = Disclauncher;
			$spawnBuyList[4, %client] = RocketLauncher ; 
			$spawnBuyList[5, %client] = GrenadeLauncher; 
			$spawnBuyList[6, %client] = FixIt; 
			$spawnBuyList[7, %client] = RepairKit;
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = Grenade;
			$spawnBuyList[10, %client] = Grenade;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = Beacon;
			$spawnBuyList[14, %client] = DeployableInvPack;
			$spawnBuyList[15, %client] = "";
			$fa_armor = "Engineer";
			$fa_pack = "Invo. Station";
		}
	
		if ((%rnd >= 16) && (%rnd <= 23))
		{
			if ($debug) echo("Spawn - Mercenary");
			$spawnBuyList[0] = MediumArmor;
			$spawnBuyList[1] = Mortar;
			$spawnBuyList[2] = RocketLauncher;
			$spawnBuyList[3] = Disclauncher;
			$spawnBuyList[4] = RepairKit; 
			$spawnBuyList[5] = GrenadeLauncher; 
			$spawnBuyList[6] = Grenade; 
			$spawnBuyList[7] = Grenade; 
			$spawnBuyList[8] = Grenade;
			$spawnBuyList[9] = Beacon;
			$spawnBuyList[10] = Beacon;
			$spawnBuyList[11] = Beacon;
			$spawnBuyList[12] = Beacon;
			$spawnBuyList[13] = TargetingLaser;
			$spawnBuyList[14] = RepairPack;
			$spawnBuyList[15] = "PlasmaGun";
			$fa_armor = "Mercenary";
			$fa_pack = "RepairPack";
		}
	
		if ((%rnd >= 24) && (%rnd <= 36))
		{
			$spawnBuyList[0, %client] = EngArmor;
			$spawnBuyList[1, %client] = PlasmaGun;
			$spawnBuyList[2, %client] = RailGun;
			$spawnBuyList[3, %client] = Disclauncher;
			$spawnBuyList[4, %client] = RocketLauncher ; 
			$spawnBuyList[5, %client] = GrenadeLauncher; 
			$spawnBuyList[6, %client] = FixIt; 
			$spawnBuyList[7, %client] = RepairKit;
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = Grenade;
			$spawnBuyList[10, %client] = Grenade;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = Beacon;
			$spawnBuyList[14, %client] = DeployableInvPack;
			$spawnBuyList[15, %client] = "";
			$fa_armor = "Engineer";
			$fa_pack = "Invo. Station";
		}
	
		if ((%rnd >= 36) && (%rnd <= 39))
		{
			if ($debug) echo("Spawn - Assassin");
			$spawnBuyList[0, %client] = LightArmor;
			$spawnBuyList[1, %client] = PlasmaGun;
			$spawnBuyList[2, %client] = RailGun;
			$spawnBuyList[3, %client] = SniperRifle;
			$spawnBuyList[4, %client] = RepairKit;
			$spawnBuyList[5, %client] = Grenade;
			$spawnBuyList[6, %client] = Grenade;
			$spawnBuyList[7, %client] = Grenade;
			$spawnBuyList[8, %client] = Beacon;
			$spawnBuyList[9, %client] = Beacon;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = EnergyPack;
			$spawnBuyList[12, %client] = "";
			$fa_armor = "Assassin";
			$fa_pack = "Energy Pack";
		}
	
		if ((%rnd >= 46) && (%rnd <= 48))
		{
			if ($debug) echo("Spawn - Scout");
			$spawnBuyList[0, %client] = ScoutArmor;
			$spawnBuyList[1, %client] = PlasmaGun;
			$spawnBuyList[2, %client] = Disclauncher;
			$spawnBuyList[3, %client] = RepairKit;
			$spawnBuyList[4, %client] = Grenade;
			$spawnBuyList[5, %client] = Grenade;
			$spawnBuyList[6, %client] = Grenade;
			$spawnBuyList[7, %client] = Beacon;
			$spawnBuyList[8, %client] = Beacon;
			$spawnBuyList[9, %client] = Beacon;
			$spawnBuyList[10, %client] = FlightPack;
			$spawnBuyList[11, %client] = "";
			$fa_armor = "Scout";
			$fa_pack = "Flight Pack";
		}
	
		if ((%rnd == 49) || (%rnd == 50))
		{
			if ($debug) echo("Spawn - Dreadnaught");
			$spawnBuyList[0, %client] = DragArmor;
			$spawnBuyList[1, %client] = PlasmaGun;
			$spawnBuyList[2, %client] = Mortar;
			$spawnBuyList[3, %client] = Disclauncher;
			$spawnBuyList[4, %client] = RocketLauncher ; 
			$spawnBuyList[5, %client] = Vulcan; 
			$spawnBuyList[6, %client] = RepairKit;
			$spawnBuyList[7, %client] = Grenade;
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = Grenade;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = StealthShieldPack;
			$spawnBuyList[14, %client] = "";
			$fa_armor = "Dreadnaught";
			$fa_pack = "Stealth Shield Pack";
		}
	
	if(!$Shifter::SpawnRandom && !%client.favsettings && !%client.isGod)

	{
		standardSpawnlist(%client);
	}
}
