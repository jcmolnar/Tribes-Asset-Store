function SpawnBuyList(%clientId){
	%player = Client::getOwnedObject(%clientId);
	if(%clientId.spawnType == "larmor"){
		$spawnBuyList[%clientId, 0]   = LightArmor;
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = Tunneler;
		$spawnBuyList[%clientId, 6] = RepairKit;
		$spawnBuyList[%clientId, 7] = Blaster;
		$spawnBuyList[%clientId, 8] = MineLauncher;
		$spawnBuyList[%clientId, 9] = TRocketLauncher;
		$spawnBuyList[%clientId, 10] = DiscLauncher;
		$spawnBuyList[%clientId, 11] = TankShredder;
		$spawnBuyList[%clientId, 12] = PlasmaCannon;
		$spawnBuyList[%clientId, 13] = LiLffb;
		$spawnBuyList[%clientId, 14] = Mortar;
		$spawnBuyList[%clientId, 15] = LiLPOOmkii;
		$spawnBuyList[%clientId, 16] = LiLPOOmki;
		$spawnBuyList[%clientId, 17] = DoublePlasma;
		%clientId.spawnWeapon = DoublePlasma;
		XBottomPrint(%clientId, "<jc><f1>Standard Light Armor Setup");
		return;
	}
	else if(%clientId.spawnType == "marmor"){
		$spawnBuyList[%clientId, 0]   = MediumArmor;
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = RepairKit;
		$spawnBuyList[%clientId, 6] = MineLauncher;
		$spawnBuyList[%clientId, 7] = Blaster;
		$spawnBuyList[%clientId, 8] = TRocketLauncher;
		$spawnBuyList[%clientId, 9] = DiscLauncher;
		$spawnBuyList[%clientId, 10] = PlasmaCannon;
		$spawnBuyList[%clientId, 11] = LiLffb;
		$spawnBuyList[%clientId, 12] = Mortar;
		$spawnBuyList[%clientId, 13] = LiLPOOmkii;
		$spawnBuyList[%clientId, 14] = LiLPOOmki;
		$spawnBuyList[%clientId, 15] = DoublePlasma;
		$spawnBuyList[%clientId, 16] = TankShredder;
		%clientId.spawnWeapon = TankShredder;
		XBottomPrint(%clientId, "<jc><f1>Standard Medium Armor Setup");
		return;
	}
	else if(%clientId.spawnType == "harmor"){
		$spawnBuyList[%clientId, 0] = HeavyArmor;
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = RepairKit;
		$spawnBuyList[%clientId, 6] = DetPackLauncher;
		$spawnBuyList[%clientId, 7] = TRocketLauncher;
		$spawnBuyList[%clientId, 8] = DiscLauncher;
		$spawnBuyList[%clientId, 9] = TankShredder;
		$spawnBuyList[%clientId, 10] = PlasmaCannon;
		$spawnBuyList[%clientId, 11] = Mortar;
		$spawnBuyList[%clientId, 12] = LiLPOOmkii;
		$spawnBuyList[%clientId, 13] = LiLPOOmki;
		$spawnBuyList[%clientId, 14] = DoublePlasma;
		$spawnBuyList[%clientId, 15] = TankRPGLauncher;
		%clientId.spawnWeapon = TankRPGLauncher;
		XBottomPrint(%clientId, "<jc><f1>Standard Heavy Armor Setup");
		return;
	}
	else if(%clientId.spawnType == "earmor"){
		$spawnBuyList[%clientId, 0] = EnginArmor;
		$spawnBuyList[%clientId, 1] = EnergyPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = RepairKit;
		$spawnBuyList[%clientId, 6] = MineLauncher;
		$spawnBuyList[%clientId, 7] = MineSweeper;
		$spawnBuyList[%clientId, 8] = Mortar;
		$spawnBuyList[%clientId, 9] = LiLffb;
		$spawnBuyList[%clientId, 10] = DetPackLauncher;
		$spawnBuyList[%clientId, 11] = PlasmaCannon;
		%clientId.spawnWeapon = PlasmaCannon;
		XBottomPrint(%clientId, "<jc><f1>Standard Engineer Armor Setup");
	}
	else if(%clientId.spawnType == "Favs"){
		for(%x = 0; $FavsBuyList[%clientId, %x] != ""; %x++){
			$spawnBuyList[%clientId, %x] = $FavsBuyList[%clientId, %x];
		}
		XBottomPrint(%clientId, "<jc><f1>Your Favs Setup");
		return;
	}else{// No Preference
		$TribalGod::RandomArmor[0] = "LightArmor";
		$TribalGod::RandomArmor[1] = "MediumArmor";
		$TribalGod::RandomArmor[2] = "EnginArmor";
		$TribalGod::RandomArmor[3] = "HeavyArmor";
		%rnd = floor(getRandom() * 4);
		if($TribalGod::RandomArmor[%rnd] == "LightArmor"){
			$spawnBuyList[%clientId, 0]   = LightArmor;
			$spawnBuyList[%clientId, 1] = RepairPack;
			$spawnBuyList[%clientId, 2] = MineAmmo;
			$spawnBuyList[%clientId, 3] = Beacon;
			$spawnBuyList[%clientId, 4] = Grenade;
			$spawnBuyList[%clientId, 5] = Tunneler;
			$spawnBuyList[%clientId, 6] = RepairKit;
			$spawnBuyList[%clientId, 7] = Blaster;
			$spawnBuyList[%clientId, 8] = MineLauncher;
			$spawnBuyList[%clientId, 9] = TRocketLauncher;
			$spawnBuyList[%clientId, 10] = DiscLauncher;
			$spawnBuyList[%clientId, 11] = TankShredder;
			$spawnBuyList[%clientId, 12] = PlasmaCannon;
			$spawnBuyList[%clientId, 13] = LiLffb;
			$spawnBuyList[%clientId, 14] = Mortar;
			$spawnBuyList[%clientId, 15] = LiLPOOmkii;
			$spawnBuyList[%clientId, 16] = LiLPOOmki;
			$spawnBuyList[%clientId, 17] = DoublePlasma;
			%clientId.spawnWeapon = DoublePlasma;
		}else if($TribalGod::RandomArmor[%rnd] == "MediumArmor"){
			$spawnBuyList[%clientId, 0]   = MediumArmor;
			$spawnBuyList[%clientId, 1] = RepairPack;
			$spawnBuyList[%clientId, 2] = MineAmmo;
			$spawnBuyList[%clientId, 3] = Beacon;
			$spawnBuyList[%clientId, 4] = Grenade;
			$spawnBuyList[%clientId, 5] = RepairKit;
			$spawnBuyList[%clientId, 6] = MineLauncher;
			$spawnBuyList[%clientId, 7] = Blaster;
			$spawnBuyList[%clientId, 8] = TRocketLauncher;
			$spawnBuyList[%clientId, 9] = DiscLauncher;
			$spawnBuyList[%clientId, 10] = PlasmaCannon;
			$spawnBuyList[%clientId, 11] = LiLffb;
			$spawnBuyList[%clientId, 12] = Mortar;
			$spawnBuyList[%clientId, 13] = LiLPOOmkii;
			$spawnBuyList[%clientId, 14] = LiLPOOmki;
			$spawnBuyList[%clientId, 15] = DoublePlasma;
			$spawnBuyList[%clientId, 16] = TankShredder;
			%clientId.spawnWeapon = TankShredder;
		}else if($TribalGod::RandomArmor[%rnd] == "EnginArmor"){
			$spawnBuyList[%clientId, 0] = EnginArmor;
			$spawnBuyList[%clientId, 1] = EnergyPack;
			$spawnBuyList[%clientId, 2] = MineAmmo;
			$spawnBuyList[%clientId, 3] = Beacon;
			$spawnBuyList[%clientId, 4] = Grenade;
			$spawnBuyList[%clientId, 5] = RepairKit;
			$spawnBuyList[%clientId, 6] = MineLauncher;
			$spawnBuyList[%clientId, 7] = MineSweeper;
			$spawnBuyList[%clientId, 8] = Mortar;
			$spawnBuyList[%clientId, 9] = LiLffb;
			$spawnBuyList[%clientId, 10] = DetPackLauncher;
			$spawnBuyList[%clientId, 11] = PlasmaCannon;
			%clientId.spawnWeapon = PlasmaCannon;
		}else if($TribalGod::RandomArmor[%rnd] == "HeavyArmor"){
			$spawnBuyList[%clientId, 0] = HeavyArmor;
			$spawnBuyList[%clientId, 1] = RepairPack;
			$spawnBuyList[%clientId, 2] = MineAmmo;
			$spawnBuyList[%clientId, 3] = Beacon;
			$spawnBuyList[%clientId, 4] = Grenade;
			$spawnBuyList[%clientId, 5] = RepairKit;
			$spawnBuyList[%clientId, 6] = DetPackLauncher;
			$spawnBuyList[%clientId, 7] = TRocketLauncher;
			$spawnBuyList[%clientId, 8] = DiscLauncher;
			$spawnBuyList[%clientId, 9] = TankShredder;
			$spawnBuyList[%clientId, 10] = PlasmaCannon;
			$spawnBuyList[%clientId, 11] = Mortar;
			$spawnBuyList[%clientId, 12] = LiLPOOmkii;
			$spawnBuyList[%clientId, 13] = LiLPOOmki;
			$spawnBuyList[%clientId, 14] = DoublePlasma;
			$spawnBuyList[%clientId, 15] = TankRPGLauncher;
			%clientId.spawnWeapon = TankRPGLauncher;
		}
		XBottomPrint(%clientId, "<jc><f1>Random Armor Setup");
		return;
	}
}
// This'll record all items you are carrying...
function TG::SetFavsSpawn(%clientId){
	if(%clientId.dead != "1" && %clientId.observerMode == "" && client::getownedobject(%clientId) != "-1"){
		for(%x = 0; %x < 25; %x++) $FavsBuyList[%clientId, %x] = "";
		%ii = 0;
		%max = getNumItems();
		//$NumItems = getNumItems();
		if(Player::getMountedItem(%clientId, 0) !=-1) %clientId.spawnWeapon = Player::getMountedItem(%clientId, 0);
		if(Player::getMountedItem(%clientId, 1) !=-1) $FavsBuyList[%clientId, %ii] = Player::getMountedItem(%clientId, 1);
		else $FavsBuyList[%clientId, %ii] = RepairPack;
	}
	for(%i = 0; %i < %max; %i++){
		%checkItem = getItemData(%i);
		%datab = GameBase::getDataName(%i);
		if(%itemcount = Player::getItemCount(%clientId, %checkItem)){
			if(%itemcount){
				if(%checkItem.classname != Ammo){
					%ii++;
					$FavsBuyList[%clientId, %ii] = %checkItem;
				}
			} 
		}
	}
	%clientId.spawnType = "Favs";
	if(Player::getMountedItem(%player, $WeaponSlot) != -1) %clientId.spawnWeapon = Player::getMountedItem(%player, $WeaponSlot);
}