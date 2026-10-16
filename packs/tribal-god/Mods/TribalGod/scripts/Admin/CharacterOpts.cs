// In This File Are All The Processmenu Functions For Character Preferences.
//====================================================================================
function processMenucharacter2(%clientId, %opt){
	if(%opt == "weaponopts"){
		Client::buildMenu(%clientId, "Weapon Options", "weaponopts", true);
		Client::addMenuItem(%clientId, "1MineLauncher Options", "MineLopts");
		Client::addMenuItem(%clientId, "2Mortar Options"      , "Mortaropts");
		Client::addMenuItem(%clientId, "3Blaster Options"     , "Blasteropts");
		Client::addMenuItem(%clientId, "4Disc Options"        , "Discopts");
		return;
	}
	else if(%opt == "packopts"){
		Client::buildMenu(%clientId, "Pack Options", "packopts", true);
		Client::addMenuItem(%clientId, "1Repair Pack Options", "RepairPackopts");
		return;
	}
	else if(%opt == "spawnopts"){
		Client::buildMenu(%clientId, "Spawn Options", "spawnopts", true);
		Client::addMenuItem(%clientId, "1Light  Armor Setup" , "setuplarmor");
		Client::addMenuItem(%clientId, "2Medium Armor Setup" , "setupmarmor");
		Client::addMenuItem(%clientId, "3Engineer Setup" , "setupearmor");
		Client::addMenuItem(%clientId, "4Heavy  Armor Setup" , "setupharmor");
		Client::addMenuItem(%clientId, "5Save Current Setup", "setupfavs");
		return;
	}
	else if(%opt == "hlpset"){
		Client::buildMenu(%clientId, "Help Settings", "helpsetting", true);
		if(%client.Tutorial != 1) Client::addMenuItem(%clientId, %curItem++ @"Standard Help" , "tut1");
		if(%client.Tutorial != 2) Client::addMenuItem(%clientId, %curItem++ @"Full Tutorial" , "tut2");
		if(%client.Tutorial != -1) Client::addMenuItem(%clientId, %curItem++ @"Disable All Help" , "tutoff");
	}
}
function processMenuhelpsetting(%clientId, %opt){
	if(%opt == "tut1") %clientId.Tutorial = 1;
	else if(%opt == "tut2") %clientId.Tutorial = 2;
	else if(%opt == "tutoff") %clientId.Tutorial = 0;
}

function processMenuspawnopts(%clientId, %opt){
	%player = Client::getOwnedObject(%clientId);
	if(%opt == "setuplarmor"){
		%clientId.spawnType = "larmor";
		BottomPrint(%clientId, "<jc><f1>Light Armor Setup Engaged", 5);
		return;
	}else if(%opt == "setupmarmor"){
		%clientId.spawnType = "marmor";
		BottomPrint(%clientId, "<jc><f1>Medium Armor Setup Engaged", 5);
		return;
	}else if(%opt == "setupearmor"){
		%clientId.spawnType = "earmor";
		BottomPrint(%clientId, "<jc><f1>Engineer Armor Setup Engaged", 5);
		return;
	}else if(%opt == "setupharmor"){
		%clientId.spawnType = "harmor";
		BottomPrint(%clientId, "<jc><f1>Heavy Armor Setup Engaged", 5);
		return;
	}else if(%opt == "setupfavs"){
		%clientId.spawnType = "Favs";
		TG::SetFavsSpawn(%clientId);
		BottomPrint(%clientId, "<jc><f1>Current Setup Saved.", 5);
		return;
	}
}

function processMenupackopts(%clientId, %opt){
	if(%opt == "RepairPackopts"){
		Client::buildMenu(%clientId, "Repair Pack Options", "packopts2", true);
		Client::addMenuItem(%clientId, "1Default Repair Gun"  , "RepairGun_Default");
		Client::addMenuItem(%clientId, "2Advanced Repair Gun" , "RepairGun_Advanced");
		return;
	}
}

function processMenupackopts2(%clientId, %opt){
	if(%opt == "RepairGun_Default"){
		%clientId.RepairPref = "StandardRepairGun";
		Client::sendMessage(%clientId, 0, "~wshell_click.wav");
		CenterPrint(%clientId, "<jc><f1>Standard <f0>Repair Pack Engaged", 4);
		return;
	}
	else if(%opt == "RepairGun_Advanced"){
		%clientId.RepairPref = "AdvancedRepairGun";
		CenterPrint(%clientId, "<jc><f2>Advanced <f0>Repair Pack Engaged", 4);
		Client::sendMessage(%clientId, 0, "~wshell_click.wav");
		return;
	}
}

function processMenuweaponopts(%clientId, %opt){
	if(%opt == "MineLopts"){
		Client::buildMenu(%clientId, "MineLauncher Options:", "MineLopts", true);
		Client::addMenuItem(%clientId, "1MineL - LightGren"  , "MineLauncher_Light");
		Client::addMenuItem(%clientId, "2MineL - BurstMine"  , "MineLauncher_Burst");
		Client::addMenuItem(%clientId, "3MineL - TranqGren"  , "MineLauncher_Tranq");
		Client::addMenuItem(%clientId, "4MineL - RadiusMine" , "MineLauncher_RMine");
		Client::addMenuItem(%clientId, "5MineL - Default"    , "MineLauncher_Default");
		return;
	}
	else if(%opt == "Mortaropts"){
		Client::buildMenu(%clientId, "Mortar Options:", "Mortaropts", true);
		Client::addMenuItem(%clientId, "1Mortar - Nuke"   , "Mortar_Nuke");
		Client::addMenuItem(%clientId, "2Mortar - Multi"  , "Mortar_Multi");
		Client::addMenuItem(%clientId, "3Mortar - Flame"  , "Mortar_Flame");
		Client::addMenuItem(%clientId, "4Mortar - Default", "Mortar_Default");
		return;
	}
	else if(%opt == "Blasteropts"){
		Client::buildMenu(%clientId, "Blaster Options:", "Blasteropts", true);
		Client::addMenuItem(%clientId, "1Blaster - Spredder", "Blaster_Spredder");
		Client::addMenuItem(%clientId, "2Blaster - Default" , "Blaster_Default");
	}
	else if(%opt == "Discopts"){
		Client::buildMenu(%clientId, "Disc Options:", "Discopts", true);
		Client::addMenuItem(%clientId, "1Disc - Spredder" , "Disc_Spredder");
		Client::addMenuItem(%clientId, "2Disc - Invisible", "Disc_Invisible");
		Client::addMenuItem(%clientId, "3Disc - Default"  , "Disc_Default");
	}
}

function processMenuDiscopts(%clientId, %opt){
	if(%opt == "Disc_Spredder") $WeaponMode[%clientId, DiscLauncher] = "Spreader_Projectile";
	else if(%opt == "Disc_Invisible") $WeaponMode[%clientId, DiscLauncher] = "Invisible_Projectile";
	else if(%opt == "Disc_Default") $WeaponMode[%clientId, DiscLauncher] = "";
}

function processMenuBlasteropts(%clientId, %opt){
	if(%opt == "Blaster_Spredder"){
		$WeaponMode[%clientId, Blaster] = "Spredder_Projectile"; 
		BottomPrint(%clientId, "<jc><f0>Blaster: <f1>Spredder Projectile Engaged.", 5);
		return;
	}else{ $WeaponMode[%clientId, Blaster] = ""; return; }
}

function processMenuMortaropts(%clientId, %opt){
	if(%opt == "Mortar_Nuke"){
		Client::sendMessage(%clientId, 0, "~wturreton1.wav");
        $WeaponMode[%clientId, Mortar] = "Nuke";
        bottomprint(%clientId, "<jc><f0>Mortar: <f2>Nuclear Projectile Engaged", 5);
		return;
	}
	else if(%opt == "Mortar_Multi"){
        Client::sendMessage(%clientId, 0, "~wturreton1.wav");
        $WeaponMode[%clientId, Mortar] = "Multi";
        bottomprint(%clientId, "<jc><f0>Mortar: <f2>Hells Fury Projectile Engaged", 7);
		return;
	}
	else if(%opt == "Mortar_Flame"){
        Client::sendMessage(%clientId, 0, "~wpda_on.wav");
        $WeaponMode[%clientId, Mortar] = "Flame";
        bottomprint(%clientId, "<jc><f0>Mortar: <f2>Flame Strike Projectile Engaged", 7);
		return;
	}
	else if(%opt == "Mortar_Default"){
        Client::sendMessage(%clientId, 0, "~wturreton1.wav");
        $WeaponMode[%clientId, Mortar] = "Default";
        bottomprint(%clientId, "<jc><f0>Mortar: <f2>Default Projectile Engaged", 7);
		return;
	}
}

function processMenuMineLopts(%clientId, %opt){
	if(%opt == "MineLauncher_Light"){
		Client::sendMessage(%clientId, 0, "~wturreton2.wav");
        $WeaponMode[%clientId, MineLauncher] = "Light_Grenade";
        bottomprint(%clientId, "<jc><f0>Mine Launcher: <f2>Light Grenade Projectile Engaged", 7);
		return;
	}
	else if(%opt == "MineLauncher_Burst"){
        Client::sendMessage(%clientId, 0, "~wturreton1.wav");
        $WeaponMode[%clientId, MineLauncher] = "BurstMine_Grenade";
        bottomprint(%clientId, "<jc><f0>Mine Launcher: <f2>Mine Burst Projectile Engaged", 7);
		return;
	}
	else if(%opt == "MineLauncher_Tranq"){
        Client::sendMessage(%clientId, 0, "~wWeapon5.wav");
        $WeaponMode[%clientId, MineLauncher] = "Tranq_Grenade";
        BottomPrint(%clientId, "<jc><f0>Mine Launcher: <f2>Tranq Grenade Projectile Engaged", 7);
		return;
	}
	else if(%opt == "MineLauncher_RMine"){
        Client::sendMessage(%clientId, 0, "~wturreton1.wav");
        $WeaponMode[%clientId, MineLauncher] = "Radius_Mine";
        bottomprint(%clientId, "<jc><f0>Mine Launcher: <f2>Radius Mine Projectile Engaged", 7);
		return;
	}
	else if(%opt == "MineLauncher_Default"){
        Client::sendMessage(%clientId, 0, "~wturreton1.wav");
        $WeaponMode[%clientId, MineLauncher] = "";
        bottomprint(%clientId, "<jc><f0>Mine Launcher: <f2>Default Projectile Engaged", 7);
		return;
	}
}