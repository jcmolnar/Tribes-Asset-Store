

function Nappy::DuelPit::onEnter(%clientId)
{
	%clientId.game = "Duel";
	%clientId.NappyDuel = "duel";
	%clientId.DuelTeam = "-1";
	%clientId.MaxPlayers = "20";
	%clientId.WallType = "Bounce";
	%clientId.PitSize = 980;
	%clientId.DuelType = "";
	%clientId.DamageScale = 0.333;
	%clientId.AmmoScale = 3;

	%clientId.Armor = "DuelerArmor";
	%clientId.Backpack = "EnergyPack";
	%clientId.Weapon = "DiscLauncher";
	%clientId.grenadeType = "Handgrenade";//Firebomb Nukebomb Handgrenade Shockgrenade Tranqgrenade Concussion Mortarbomb
	%clientId.beaconType = "boost";//boost cloak shield firebomb
	%clientId.mineType = "DuelMine";
	%clientId.repairKitType = "repairKit";
	%clientId.Ammo = 35;
	%clientId.Grenades = 25;
	%clientId.Beacons = 10;
	%clientId.RepairKits = 1;
	%clientId.Mines = 0;

	%clientId.LandingDamage = 1;

	%clientId.BulletDamage = 1;
	%clientId.ExplosionDamage = 1;
	%clientId.ShrapnelDamage = 1;
	%clientId.MissileDamage = 1;
	%clientId.MineDamage = 1;
	%clientId.SniperDamage = 1;
	%clientId.PoisonDamage = 1;
	%clientId.FireDamage = 1;
	%clientId.ShockDamage = 1;
	%clientId.LaserDamage = 1;
	%clientId.MortarDamage = 1;
	%clientId.BlasterDamage = 1;
	%clientId.ElectricityDamage = 1;

	if(%clientId.DuelType != "")
		Nappy::RefreshDuelType(%clientId);
}




function Nappy::DuelPit::onExit(%clientId)
{
	%clientId.game = "CTF";
	%clientId.NappyDuel = "";
	%clientId.DuelTeam = "";
	%clientId.MaxPlayers = "";
	%clientId.WallType = "";
	%clientId.PitSize = "";
	%clientId.DuelType = "";
	%clientId.pit = "";
	%clientId.DamageScale = "";

	%clientId.Armor = "";
	%clientId.Backpack = "";
	%clientId.Weapon = "";
	%clientId.grenadeType = "";
	%clientId.beaconType = "";
	%clientId.mineType = "";
	%clientId.repairKitType = "";
	%clientId.Ammo = "";
	%clientId.Grenades = "";
	%clientId.Beacons = "";
	%clientId.RepairKits = "";
	%clientId.Mines = "";

	%clientId.LandingDamage = "";

	%clientId.BulletDamage = "";
	%clientId.ExplosionDamage = "";
	%clientId.ShrapnelDamage = "";
	%clientId.MissileDamage = "";
	%clientId.MineDamage = "";
	%clientId.SniperDamage = "";
	%clientId.PoisonDamage = "";
	%clientId.FireDamage = "";
	%clientId.ShockDamage = "";
	%clientId.LaserDamage = "";
	%clientId.MortarDamage = "";
	%clientId.BlasterDamage = "";
	%clientId.ElectricityDamage = "";

	if(%clientId.DuelType != "")
		Nappy::RefreshDuelType(%clientId);

	Game::refreshClientScore(%clientId);
}





function Nappy::DuelPitTeam::ChangeToTeamSettings(%clientId, %cl)
{
	%clientId.MaxPlayers = %cl.MaxPlayers;
	%clientId.WallType = %cl.WallType;
	%clientId.PitSize = %cl.PitSize;
	%clientId.DuelType = %cl.DuelType;
	if(%cl.DuelType == "1on1")
		Nappy::Duel::SetTypeInfo(%clientId);

	%clientId.DamageScale = %cl.DamageScale;
	%clientId.AmmoScale = %cl.AmmoScale;

	%clientId.Armor = %cl.Armor;
	%clientId.Backpack = %cl.Backpack;
	%clientId.Weapon = %cl.Weapon;
	%clientId.grenadeType = %cl.grenadeType;
	%clientId.beaconType = %cl.beaconType;
	%clientId.mineType = %cl.mineType;
	%clientId.repairKitType = %cl.repairKitType;
	%clientId.Ammo = %cl.Ammo;
	%clientId.Grenades = %cl.Grenades;
	%clientId.Beacons = %cl.Beacons;
	%clientId.RepairKits = %cl.RepairKits;
	%clientId.Mines = %cl.Mines;

	%clientId.LandingDamage = %cl.LandingDamage;

	%clientId.BulletDamage = %cl.BulletDamage;
	%clientId.ExplosionDamage = %cl.ExplosionDamage;
	%clientId.ShrapnelDamage = %cl.ShrapnelDamage;
	%clientId.MissileDamage = %cl.MissileDamage;
	%clientId.MineDamage = %cl.MineDamage;
	%clientId.SniperDamage = %cl.SniperDamage;
	%clientId.PoisonDamage = %cl.PoisonDamage;
	%clientId.FireDamage = %cl.FireDamage;
	%clientId.ShockDamage = %cl.ShockDamage;
	%clientId.LaserDamage = %cl.LaserDamage;
	%clientId.MortarDamage = %cl.MortarDamage;
	%clientId.BlasterDamage = %cl.BlasterDamage;
	%clientId.ElectricityDamage = %cl.ElectricityDamage;
}



function Nappy::Duel::SpawnSupply(%clientId)
{
	Nappy::Spawn::BuyArmor(%clientId);
	Game::refreshClientScore(%clientId);
	schedule("Nappy::Duel::Start(" @ %clientId @ ");",3);
}


function Nappy::Spawn::BuyArmor(%clientId)
{
	buyItem(%clientId,%clientId.Armor);

}

function Nappy::Duel::Start(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	if(!Player::isDead(%player)){
		Player::setItemCount(%clientId,%clientId.Backpack,1);
		Player::mountItem(%player,%clientId.Backpack,$BackpackSlot);
		Player::setItemCount(%clientId,%clientId.Weapon,1);

		if(%clientId.Weapon == "Chaingun")
			%ammo = "BulletAmmo";
		if(%clientId.Weapon == "DiscLauncher")
			%ammo = "DiscAmmo";
		if(%clientId.Weapon == "GrenadeLauncher")
			%ammo = "GrenadeAmmo";
		if(%clientId.Weapon == "Mortar")
			%ammo = "MortarAmmo";
		if(%clientId.Weapon == "Napalm")
			%ammo = "NapalmAmmo";
		if(%clientId.Weapon == "PlasmaGun")
			%ammo = "PlasmaAmmo";
		if(%clientId.Weapon == "Railgun")
			%ammo = "RailAmmo";
		if(%clientId.Weapon == "RocketLauncher")
			%ammo = "RocketAmmo";
		if(%clientId.Weapon == "Shotgun")
			%ammo = "ShotgunAmmo";
		if(%clientId.Weapon == "Silencer")
			%ammo = "SilencerAmmo";
		if(%clientId.Weapon == "SniperRifle")
			%ammo = "SniperAmmo";
		if(%clientId.Weapon == "TranqGun")
			%ammo = "TranqAmmo";
		if(%clientId.Weapon == "Vulcan")
			%ammo = "VulcanAmmo";

		%AmmoAmount = %clientId.Ammo * %clientId.AmmoScale;
		Player::setItemCount(%clientId,%ammo,%AmmoAmount);

		%AmmoAmount = %clientId.Grenades * %clientId.AmmoScale;
		Player::setItemCount(%clientId,Grenade,%AmmoAmount);

		%AmmoAmount = %clientId.Beacons * %clientId.AmmoScale;
		Player::setItemCount(%clientId,Beacon,%AmmoAmount);

		%AmmoAmount = %clientId.RepairKits * %clientId.AmmoScale;
		Player::setItemCount(%clientId,RepairKit,%AmmoAmount);

		%AmmoAmount = %clientId.Mines * %clientId.AmmoScale;
		Player::setItemCount(%clientId,MineAmmo,%AmmoAmount);

		Player::setItemCount(%clientId,TargetingLaser,1);

		Player::mountItem(%player,%clientId.Weapon,$WeaponSlot);

schedule("reactivateSuicide(" @ %clientId @ ");", 1);
	}
}


function Nappy::Duel::ArmorAmmo(%player, %item, %ammo)
{
	%clientId = Player::getClient(%player);
	if(%ammo == "cloak" || %ammo == "shield" || %ammo == "repairKit" || %ammo == "repairKit2"){
		if(%ammo == "cloak"){
			Renegades_startCloak(%clientId, %player);
		}
		else if(%ammo == "shield"){
			Renegades_startShield(%clientId, %player);
		}
		else if(%ammo == "repairKit"){
			%value = 0.2 * %clientId.DamageScale;
			GameBase::repairDamage(%player,%value);
			$burnTime[%client] = 0;
			$poisonTime[%client] = 0;
		}
		else if(%ammo == "repairKit2"){
			%value = 0.2;
			GameBase::repairDamage(%player,%value);
			$burnTime[%client] = 0;
			$poisonTime[%client] = 0;
		}
	}
	else{
		if(%ammo == "DuelMine"){
			%obj = newObject("","Mine",%ammo);
			%obj.deployClient = %clientId;
		}
		else if(%ammo == "boost"){
			%obj = newObject("","Mine","Booster");
			Client::sendMessage(%clientId,0, "You use a Speed Booster."); 
		}
		else{
			%obj = newObject("","Mine",%ammo);
		}
		addToSet("MissionCleanup", %obj); 
		%client = Player::getClient(%player); 
		GameBase::throw(%obj,%player,15 * %client.throwStrength,false); 
		%player.throwTime = getSimTime() + 0.5; 
	}
	Player::decItemCount(%player,%item);
}


//""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
//======================================================================================
//______________________________________________________________________________________
//
//""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
//======================================================================================
//______________________________________________________________________________________
//

function Nappy::Duel::CheckForCommand(%clientId,%message)
{
	%Nappy::ChatRemote::Command = GetWord(%message,0);
	if(%clientId.NappyDuel != "duel")
		return 1;
	else if(%Nappy::ChatRemote::Command == "#pit"){
		%num = GetWord(%message,1);
		if(%clientId.canSuicide != 0)
			Nappy::DuelPitSelect(%clientId, %num);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#team"){
		%num = GetWord(%message,1);
		if(%clientId.canSuicide != 0)
			Nappy::setTeam(%clientId, %num);
		return 1;
	}
	else if(%Nappy::ChatRemote::Command == "#duelers"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#wall"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#size"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#duelType"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#armor"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#backpack"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#weapon"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#grenadeType"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#beaconType"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#mineType"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#repairKitType"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#ammo"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#weaponAmmo"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#grenades"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#beacons"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#mines"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#repairKits"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
//OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
	else if(%Nappy::ChatRemote::Command == "#damage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#LandingDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#BulletDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#ExplosionDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#ShrapnelDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#MissileDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#ShockDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#SniperDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#PoisonDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#FireDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#MineDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#LaserDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#MortarDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#BlasterDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}
	else if(%Nappy::ChatRemote::Command == "#ElectricityDamage"){
		if(Client::getTeam(%clientId) == -1)
			%wrongTeam = 1;
		else{
			%num = GetWord(%message,1);
			Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %Nappy::ChatRemote::Command, %num);
			return 1;
		}
	}

	if(%wrongTeam){
		Nappy::DuelPit::Messages(%clientId, "WrongTeamForOption", %Nappy::ChatRemote::Command);
		return 1;
	}
}





function Nappy::DuelPitTeam::ChangeDuelTeamSettings(%clientId, %command, %num)
{
	%message = Nappy::getName(%clientId) @ " used duel option \"" @ %command @ " " @ %num @ "\"";
	Nappy::Log("DuelOption", %message);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.NappyDuel == "duel"){
			if(%cl.DuelTeam == %clientId.DuelTeam){
				Nappy::DuelPitTeam::ChangeSettings(%cl, %command, %num);
			}
		}
	}
}




function Nappy::DuelPitTeam::ChangeSettings(%clientId, %command, %num)
{
	%needToRespawnMessage = 0;
	if(%command == "#duelers"){
		Client::sendMessage(%clientId, 0, "Team now holds " @ %num @ " duelers"); 
		%clientId.MaxPlayers = %num;
	}
	else if(%command == "#wall"){
		Client::sendMessage(%clientId, 0, "Wall type is set to " @ %num); 
		%clientId.WallType = %num;
	}
	else if(%command == "#size"){
		if(%num > 980 || %num < 100)
			Client::sendMessage(%clientId, 0, "Invalid pit size"); 
		else{
			Client::sendMessage(%clientId, 0, "Pit size is now set to " @ %num); 
			%clientId.PitSize = %num;
		}
	}
	else if(%command == "#duelType"){
		Client::sendMessage(%clientId, 0, "Duel mode now set to " @ %num); 
		%clientId.DuelType = %num;
		Nappy::Duel::SetTypeInfo(%clientId);
	}
	else if(%command == "#armor"){
		Client::sendMessage(%clientId, 0, "Armor now set to " @ %num); 
		%needToRespawnMessage = 1;
		if(%num == "CyborgArmor")
			%num = "DragArmor";
		%clientId.Armor = %num;
	}
	else if(%command == "#backpack"){
		if(Nappy::DuelPitTeam::BackpackCheck(%num)){
			Client::sendMessage(%clientId, 0, "Backpack now set to " @ %num); 
			%needToRespawnMessage = 1;
			%clientId.Backpack = %num;
		}
		else
			Client::sendMessage(%clientId, 0, %num @ " is not a selectable backpack");
	}
	else if(%command == "#weapon"){
		if(Nappy::DuelPitTeam::WeaponCheck(%num)){
			Client::sendMessage(%clientId, 0, "Weapon now set to " @ %num); 
			%needToRespawnMessage = 1;
			%clientId.Weapon = %num;
		}
		else
			Client::sendMessage(%clientId, 0, %num @ " is not a selectable weapon");
	}
	else if(%command == "#grenadeType"){
		if(Nappy::DuelPitTeam::armorAmmoCheck(%num)){
			Client::sendMessage(%clientId, 0, "Grenade type now set to " @ %num); 
			%clientId.grenadeType = %num;
		}
		else
			Client::sendMessage(%clientId, 0, %num @ " is not a selectable grenade");
	}
	else if(%command == "#beaconType"){
		if(Nappy::DuelPitTeam::armorAmmoCheck(%num)){
			Client::sendMessage(%clientId, 0, "Beacon type now set to " @ %num); 
			%clientId.beaconType = %num;
		}
		else
			Client::sendMessage(%clientId, 0, %num @ " is not a selectable beacon");
	}
	else if(%command == "#mineType"){
		if(Nappy::DuelPitTeam::armorAmmoCheck(%num)){
			Client::sendMessage(%clientId, 0, "Mine type now set to " @ %num); 
			%clientId.mineType = %num;
		}
		else
			Client::sendMessage(%clientId, 0, %num @ " is not a selectable mine");
	}
	else if(%command == "#repairKitType"){
		if(Nappy::DuelPitTeam::armorAmmoCheck(%num)){
			Client::sendMessage(%clientId, 0, "Repair kit type now set to " @ %num); 
			%clientId.repairKitType = %num;
		}
		else
			Client::sendMessage(%clientId, 0, %num @ " is not a selectable repair kit");
	}
	else if(%command == "#ammo"){
			Client::sendMessage(%clientId, 0, "Ammo scale now set to " @ %num); 
		%needToRespawnMessage = 1;
		%clientId.AmmoScale = %num;
	}
	else if(%command == "#weaponAmmo"){
		Client::sendMessage(%clientId, 0, "Weapon ammo now set to " @ %num); 
		%needToRespawnMessage = 1;
		%clientId.Ammo = %num;
	}
	else if(%command == "#grenades"){
		Client::sendMessage(%clientId, 0, "Grenades now set to " @ %num); 
		%needToRespawnMessage = 1;
		%clientId.Grenades = %num;
	}
	else if(%command == "#beacons"){
		Client::sendMessage(%clientId, 0, "Beacons now set to " @ %num); 
		%needToRespawnMessage = 1;
		%clientId.Beacons = %num;
	}
	else if(%command == "#mines"){
		Client::sendMessage(%clientId, 0, "Mines now set to " @ %num); 
		%needToRespawnMessage = 1;
		%clientId.Mines = %num;
	}
	else if(%command == "#repairKits"){
		Client::sendMessage(%clientId, 0, "Repair kits now set to " @ %num); 
		%needToRespawnMessage = 1;
		%clientId.RepairKits = %num;
	}
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
	else if(%command == "#damage"){
		Client::sendMessage(%clientId, 0, "Damage scale now set to " @ %num); 
		%clientId.DamageScale = %num;
	}
	else if(%command == "#LandingDamage"){
		Client::sendMessage(%clientId, 0, "Landing damage scale now set to " @ %num); 
		%clientId.LandingDamage = %num;
	}
	else if(%command == "#BulletDamage"){
		Client::sendMessage(%clientId, 0, "Bullet damage scale now set to " @ %num); 
		%clientId.BulletDamage = %num;
	}
	else if(%command == "#ExplosionDamage"){
		Client::sendMessage(%clientId, 0, "Explosion damage scale now set to " @ %num); 
		%clientId.ExplosionDamage = %num;
	}
	else if(%command == "#ShrapnelDamage"){
		Client::sendMessage(%clientId, 0, "Shrapnel damage scale now set to " @ %num); 
		%clientId.ShrapnelDamage = %num;
	}
	else if(%command == "#MissileDamage"){
		Client::sendMessage(%clientId, 0, "Missile damage scale now set to " @ %num); 
		%clientId.MissileDamage = %num;
	}
	else if(%command == "#ShockDamage"){
		Client::sendMessage(%clientId, 0, "Shock damage scale now set to " @ %num); 
		%clientId.ShockDamage = %num;
	}
	else if(%command == "#SniperDamage"){
		Client::sendMessage(%clientId, 0, "Sniper damage scale now set to " @ %num); 
		%clientId.SniperDamage = %num;
	}
	else if(%command == "#PoisonDamage"){
		Client::sendMessage(%clientId, 0, "Poison damage scale now set to " @ %num); 
		%clientId.PoisonDamage = %num;
	}
	else if(%command == "#FireDamage"){
		Client::sendMessage(%clientId, 0, "Fire damage scale now set to " @ %num); 
		%clientId.FireDamage = %num;
	}
	else if(%command == "#MineDamage"){
		Client::sendMessage(%clientId, 0, "Mine damage scale now set to " @ %num); 
		%clientId.MineDamage = %num;
	}
	else if(%command == "#LaserDamage"){
		Client::sendMessage(%clientId, 0, "Laser damage scale now set to " @ %num); 
		%clientId.LaserDamage = %num;
	}
	else if(%command == "#MortarDamage"){
		Client::sendMessage(%clientId, 0, "Mortar damage scale now set to " @ %num); 
		%clientId.MortarDamage = %num;
	}
	else if(%command == "#BlasterDamage"){
		Client::sendMessage(%clientId, 0, "Blaster damage scale now set to " @ %num); 
		%clientId.BlasterDamage = %num;
	}
	else if(%command == "#ElectricityDamage"){
		Client::sendMessage(%clientId, 0, "Electricity damage scale now set to " @ %num); 
		%clientId.ElectricityDamage = %num;
	}

	if(%needToRespawnMessage){
		Client::sendMessage(%clientId, 1, "This change will take effect next time you respawn."); 
		//Nappy::Duel::TakeAwayItems(%clientId);
		//Nappy::Duel::SpawnSupply(%clientId);
	}
}




function Nappy::DuelPitTeam::BackpackCheck(%pack)
{
	if(%pack == "EnergyPack")
		return 1;
	else if(%pack == "RepairPack")
		return 1;
	else if(%pack == "ShieldPack")
		return 1;
	else if(%pack == "GasPack")
		return 1;
	else if(%pack == "CloakingDevice")
		return 1;
	else if(%pack == "StealthShieldPack")
		return 1;
	else if(%pack == "RegenerationPack")
		return 1;
	else if(%pack == "LightningPack")
		return 1;
	else if(%pack == "OpticPack")
		return 1;
	else if(%pack == "SMRPackImage")
		return 1;
	else if(%pack == "SuicidePack")
		return 1;
	else if(%pack == "AmmoPack")
		return 1;
	else
		return 0;
}


function Nappy::DuelPitTeam::WeaponCheck(%weapon)
{
	if(%weapon == "Blaster")
		return 1;
	else if(%weapon =="Chaingun")
		return 1;
	else if(%weapon =="TranqGun")
		return 1;
	else if(%weapon =="DiscLauncher")
		return 1;
	else if(%weapon =="GrenadeLauncher")
		return 1;
	else if(%weapon =="IonGun")
		return 1;
	else if(%weapon =="LaserRifle")
		return 1;
	else if(%weapon =="Silencer")
		return 0;
	else if(%weapon =="Mortar")
		return 1;
	else if(%weapon =="Napalm")
		return 1;
	else if(%weapon =="Omega")
		return 1;
	else if(%weapon =="PlasmaGun")
		return 1;
	else if(%weapon =="Railgun")
		return 1;
	else if(%weapon =="RocketLauncher")
		return 1;
	else if(%weapon =="WaveGun")
		return 1;
	else if(%weapon =="Shotgun")
		return 1;
	else if(%weapon =="SniperRifle")
		return 1;
	else if(%weapon =="EnergyRifle")
		return 1;
	else if(%weapon =="Vulcan")
		return 1;
	else
		return 0;
}

function Nappy::DuelPitTeam::armorAmmoCheck(%ammo)
{
	if(%ammo == "Firebomb")
		return 1;
	else if(%ammo == "Handgrenade")
		return 1;
	else if(%ammo == "Shockgrenade")
		return 1;
	else if(%ammo == "Tranqgrenade")
		return 1;
	else if(%ammo == "Concussion")
		return 1;
	else if(%ammo == "Mortarbomb")
		return 1;
	else if(%ammo == "boost")
		return 1;
	else if(%ammo == "cloak")
		return 1;
	else if(%ammo == "shield")
		return 1;
	else if(%ammo == "DuelMine")
		return 1;
	else if(%ammo == "repairKit")
		return 1;
	else if(%ammo == "repairKit2")
		return 1;
	else
		return 0;
}




function Nappy::DuelPitSelect(%clientId, %num)
{
	%num = floor(%num); // PORT: chat text; "3);quit();//" passed the 1..8 test and was spliced into schedule() below
	%message = Nappy::getName(%clientId) @ " changed  to duel pit " @ %num;
	Nappy::Log("DuelOption", %message);

	if(%clientId.NappyDuel == "duel"){
		%team = %clientId.DuelTeam;
	
		if(%num > 8 || %num < 1){
			Client::sendMessage(%clientId,1,"You can only select 1 to 8.");
			return;
		}
		if(Nappy::DuelPitTeam::DoesPitTeamHaveRoom(%clientId, %num, %team)){
			%clientId.canSuicide = 0;
			%clientId.pit = %num;
			%player = Client::getOwnedObject(%clientId);
			if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)){ 
				Nappy::Duel::TakeAwayItems(%clientId);
				playNextAnim(%clientId); 
				Player::kill(%clientId); 
				deleteObject(%player);
			} 
			%currentTeam = Client::getTeam(%clientId);
			if(%currentTeam > -1){
				Nappy::DuelPitTeam::SetUpOnJoin(%clientId, %currentTeam);
			}
			%spawnTime = 2;
			schedule("Game::playerSpawn(" @ %clientId @ ");", %spawnTime);
			%pitNum = %clientId.pit;
			%type = "pitnum";
			schedule("Nappy::DuelPit::Messages(" @ %clientId @ ", " @ %type @ ", " @ %pitNum @ ");", %spawnTime + 0); 
			schedule("Nappy::DuelPit::Messages(" @ %clientId @ ", " @ %type @ ", " @ %pitNum @ ");", %spawnTime + 0.5); 
			schedule("Nappy::DuelPit::Messages(" @ %clientId @ ", " @ %type @ ", " @ %pitNum @ ");", %spawnTime + 1); 
			schedule("Nappy::DuelPit::Messages(" @ %clientId @ ", " @ %type @ ", " @ %pitNum @ ");", %spawnTime + 1.5); 
			schedule("Nappy::DuelPit::Messages(" @ %clientId @ ", " @ %type @ ", " @ %pitNum @ ");", %spawnTime + 2); 
			schedule("Nappy::DuelPit::Messages(" @ %clientId @ ", " @ %type @ ", " @ %pitNum @ ");", %spawnTime + 2.5); 
		}
		else
			Client::sendMessage(%clientId,1,"Team is full.");
	}
}




function Nappy::setTeam(%clientId, %team)
{
	%team = floor(%team); // PORT: chat text (#team)
	%message = Nappy::getName(%clientId) @ " changed  to duel team " @ %team;
	Nappy::Log("DuelOption", %message);

	%pit = %clientId.pit;
	if(Nappy::DuelPitTeam::DoesPitTeamHaveRoom(%clientId, %pit, %team)){
		%clientId.canSuicide = 0;
		Nappy::DuelPitTeam::SetUpOnJoin(%clientId, %team);
		%player = Client::getOwnedObject(%clientId); 
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)){ 
			Nappy::Duel::TakeAwayItems(%clientId);
			playNextAnim(%clientId); 
			Player::kill(%clientId);
			deleteObject(%player);
		} 
		GameBase::setTeam(%clientId, %team); 
		if(Client::getGuiMode(%clientId) != 1) 
			Client::setGuiMode(%clientId,1); 
		%spawnTime = 2;
		schedule("Game::playerSpawn(" @ %clientId @ ");", %spawnTime);
		%clientId.DuelTeam = Client::getTeam(%clientId); 
		if(%clientId.DuelTeam == -1)
			Nappy::DuelPit::onEnter(%clientId);
	}
	else
		Client::sendMessage(%clientId,1,"Team is full.");
}




function Nappy::DuelPitTeam::DoesPitTeamHaveRoom(%clientId, %pit, %team)
{
	%players = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.NappyDuel == "duel" && %cl != %clientId){
			if(%cl.DuelTeam == %team && %cl.pit == %pit){
				%max = %cl.MaxPlayers;
				%players++;
			}
		}
	}
	if(%players < %max || %players == 0)
		return 1;
	else
		return 0;
}




function Nappy::DuelPitTeam::SetUpOnJoin(%clientId, %team)
{
	%pit = %clientId.pit;
	%clientOnTeam = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.NappyDuel == "duel" && %cl != %clientId){
			if(%cl.DuelTeam == %team && %cl.pit == %pit){
				%clientOnTeam = %cl;
				break;
			}
		}
	}
	if(%clientOnTeam){
		Nappy::DuelPitTeam::ChangeToTeamSettings(%clientId, %clientOnTeam);
	}
	else{
		Nappy::DuelPit::onEnter(%clientId);
	}
}




function Nappy::DuelTeam::DamageScales(%clientId, %type)
{
	if(%type == $BulletDamageType)//Chaingun/-/Shotgun/-/Vulcan
		%scale = %clientId.BulletDamage;
	else if(%type == $ExplosionDamageType)//Disc Launcher/-/Rocket Launcher
		%scale = %clientId.ExplosionDamage;
	else if(%type == $ShrapnelDamageType)//Armor Grenade/-/Grenade Launcher/-/
		%scale = %clientId.ShrapnelDamage;
	else if(%type == $MissileDamageType)//Shockwave Cannon
		%scale = %clientId.MissileDamage;
	else if(%type == $MineDamageType)//Mines
		%scale = %clientId.MineDamage;
	else if(%type == $SniperDamageType)//Sniper Rifle/-/Railgun
		%scale = %clientId.SniperDamage;
	else if(%type == $PoisonDamageType)//Dart Rifle
		%scale = %clientId.PoisonDamage;
	else if(%type == $FireDamageType)//Plasma Gun/-/Napalm Launcher/-/Flamethrower
		%scale = %clientId.FireDamage;
	else if(%type == $ShockDamageType)//Shock grenade
		%scale = %clientId.ShockDamage;
	else if(%type == $LaserDamageType)//Magnum/-/Laser Rifle
		%scale = %clientId.LaserDamage;
	else if(%type == $MortarDamageType)//Mortar/-/Mortarbomb grenade
		%scale = %clientId.MortarDamage;
	else if(%type == $BlasterDamageType)//Blaster
		%scale = %clientId.BlasterDamage;
	else if(%type == $ElectricityDamageType)//Omega/-/Ion Rifle/-/Thunderbolt
		%scale = %clientId.ElectricityDamage;

	%damage = %clientId.DamageScale * %scale;
	return %damage;
}






//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

function Nappy::Duel::PickSpawnPoint(%clientId, %opt)
{
	if(%clientId.pit == ""){
		%clientId.pit = 1;
	}
	if(%opt == "pos"){
		%center = Nappy::Pit::Center();
		%offset = Nappy::Pit::Offset(%clientId);
		%spawnPos = Vector::add(%center,%offset);
		return %spawnPos;
	}
	if(%opt == "rot")
		return "0 0 0";
}


function Nappy::Pit::Center()
{
	if($missionName == "Blastside" || $missionName == "Broadside" || $missionName == "Scarabrae")
		return "-25 32 206";
	else if($missionName == "DangerousCrossing")
		return "-62 33 145";
	else if($missionName == "Desert_Of_Death")
		return "0 0 34";
	else if($missionName == "IceRidge")
		return "-17 69 173";
	else if($missionName == "Raindance")
		return "0 0 53";
	else if($missionName == "Rollercoaster")
		return "0 0 53";
	else if($missionName == "Snowblind")
		return "17 4 110";
	else if($missionName == "Stonehenge")
		return "0 0 124";
	else 
		return "0 0 300";
}


function Nappy::Pit::Offset(%clientId)
{
	%pit = %clientId.pit;
	if(%pit == 1)//EAST
		return "2050 0 0";
	if(%pit == 2)//SOUTH EAST
		return "2050 -2050 0";
	if(%pit == 3)//SOUTH
		return "0 -2050 0";
	if(%pit == 4)//SOUTH WEST
		return "-2050 -2050 0";
	if(%pit == 5)//WEST
		return "-2050 0 0";
	if(%pit == 6)//NORTH WEST
		return "-2050 2050 0";
	if(%pit == 7)//NORTH
		return "0 2050 0";
	if(%pit == 8)//NORTH EAST
		return "2050 2050 0";
}


function Nappy::Pit::Boundary(%clientId)
{
	if(%clientId.game == "CTF")
		return;
	%player = Client::getOwnedObject(%clientId);


	%center = Nappy::Pit::Center();
	%offset = Nappy::Pit::Offset(%clientId);
	%pitPos = Vector::add(%center,%offset);//%offset;
	%pos = GameBase::getPosition(%player);

	if(%clientId.WallType == "Bounce")
		%wallType = "push";
	else if(%clientId.WallType == "Teleport")
		%wallType = "teleport";
	else
		%wallType = "push";

	if(%wallType == "push"){
		%size = %clientId.PitSize;
		%checkTime = 0.5;
	}
	else if(%wallType == "teleport"){
		%size = 1025;
		%checkTime = 0.3;
	}

	%centerX = GetWord(%pitPos,0);
	   %centerX[LOW] = %centerX - %size;
	   %centerX[HIGH] = %centerX + %size;
	%centerY = GetWord(%pitPos,1);
	   %centerY[LOW] = %centerY - %size;
	   %centerY[HIGH] = %centerY + %size;
	%centerZ = GetWord(%pitPos,2);
	   %centerZ[LOW] = %centerZ - %size;
	   %centerZ[HIGH] = %centerZ + %size;

	%bounceBox = 0;
	if(%bounceBox){
		   %centerX[LOW] = %centerX - 200;
		   %centerX[HIGH] = %centerX + 200;
		   %centerY[LOW] = %centerY - 200;
		   %centerY[HIGH] = %centerY + 200;
		   %centerZ[LOW] = %centerZ - 200;
		   %centerZ[HIGH] = %centerZ + 210;
	}

	%posX = GetWord(%pos,0);
	%posY = GetWord(%pos,1);
	%posZ = GetWord(%pos,2);

	if(%posX <= %centerX[LOW])
		Nappy::Pit::Wall(%clientId, "west", %wallType);
	else if(%posX >= %centerX[HIGH])
		Nappy::Pit::Wall(%clientId, "east", %wallType);
 
	if(%posY <= %centerY[LOW])
		Nappy::Pit::Wall(%clientId, "south", %wallType);
	else if(%posY >= %centerY[HIGH])
		Nappy::Pit::Wall(%clientId, "north", %wallType);

	if(%posz <= %centerZ[LOW])
		Nappy::Pit::Wall(%clientId, "bottom", %wallType);
	else if(%posz >= %centerZ[HIGH])
		Nappy::Pit::Wall(%clientId, "top", %wallType);

	if(%clientId.observerMode != "dead" && %clientId.observerMode == "")
		schedule("Nappy::Pit::Boundary(" @ %clientId @ ");", %checkTime);
}


function Nappy::Pit::Wall(%clientId, %side, %wallType)
{
	if(%clientId.game != "Duel")
		return;
	%player = Client::getOwnedObject(%clientId);

	%vel = Item::getVelocity(%player);
	%Xvel = GetWord(%vel,0);
	%Yvel = GetWord(%vel,1);
	%Zvel = GetWord(%vel,2);

	%force = 30;
	%negForce = -30;

	if(%side == "west"){
		if(%wallType == "push"){
			if(%Xvel < %force)
				Item::setVelocity(%player, %force @ " " @ %Yvel @ " " @ %Zvel);
		}
		else if(%wallType == "teleport"){
			%pos = Nappy::PitWall::TeleportPosition(%player, %side);
			GameBase::setPosition(%player,%pos);
		}
		%vec = "-2 0 0";
	}	
	else if(%side == "east"){
		if(%wallType == "push"){
			if(%Xvel > %negForce)
				Item::setVelocity(%player, %negForce @ " " @ %Yvel @ " " @ %Zvel);
		}
		else if(%wallType == "teleport"){
			%pos = Nappy::PitWall::TeleportPosition(%player, %side);
			GameBase::setPosition(%player,%pos);
		}
		%vec = "2 0 0";
	}	
	else if(%side == "south"){
		if(%wallType == "push"){
			if(%Yvel < %force)
				Item::setVelocity(%player, %Xvel @ " " @ %force @ " " @ %Zvel);
		}
		else if(%wallType == "teleport"){
			%pos = Nappy::PitWall::TeleportPosition(%player, %side);
			GameBase::setPosition(%player,%pos);
		}
		%vec = "0 -2 0";
	}	
	else if(%side == "north"){
		if(%wallType == "push"){
			if(%Yvel > %negForce)
				Item::setVelocity(%player, %Xvel @ " " @ %negForce @ " " @ %Zvel);
		}
		else if(%wallType == "teleport"){
			%pos = Nappy::PitWall::TeleportPosition(%player, %side);
			GameBase::setPosition(%player,%pos);
		}
		%vec = "0 2 0";
	}	
	else if(%side == "bottom"){
		if(%wallType == "push"){
			if(%Zvel < %force)
				Item::setVelocity(%player, %Xvel @ " " @ %Yvel @ " " @ %force);
		}
		else if(%wallType == "teleport"){
			%pos = Nappy::PitWall::TeleportPosition(%player, %side);
			GameBase::setPosition(%player,%pos);
		}
		%vec = "0 0 -2";
	}	
	else if(%side == "top"){
		if(%wallType == "push"){
			if(%Zvel > %negForce)
				Item::setVelocity(%player, %Xvel @ " " @ %Yvel @ " " @ %negForce);
		}
		else if(%wallType == "teleport"){
			%pos = Nappy::PitWall::TeleportPosition(%player, %side);
			GameBase::setPosition(%player,%pos);
		}
		%vec = "0 0 2";
	}
	GameBase::activateShield(%player,%vec, 0);	
}




function Nappy::PitWall::TeleportPosition(%player, %side)
{
	%pos = GameBase::getPosition(%player);
	%Xpos = GetWord(%pos,0);
	%Ypos = GetWord(%pos,1);
	%Zpos = GetWord(%pos,2);

	if(%side == west)
		%Xpos = %Xpos + 2050;
	else if(%side == east)
		%Xpos = %Xpos - 2050;
	if(%side == south)
		%Ypos = %Ypos + 2050;
	else if(%side == north)
		%Ypos = %Ypos - 2050;
	if(%side == bottom)
		%Zpos = %Zpos + 2050;
	else if(%side == top)
		%Zpos = %Zpos - 2050;
	%pos = %Xpos @ " " @ %Ypos @ " " @ %Zpos;
	return %pos;
}

//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv




function Nappy::Duel::TakeAwayItems(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	Player::setItemCount(%clientId,%clientId.Backpack,0);
	Player::setItemCount(%clientId,%clientId.Weapon,0);

	if(%clientId.Weapon == "Chaingun")
		%ammo = "BulletAmmo";
	if(%clientId.Weapon == "DiscLauncher")
		%ammo = "DiscAmmo";
	if(%clientId.Weapon == "GrenadeLauncher")
		%ammo = "GrenadeAmmo";
	if(%clientId.Weapon == "Mortar")
		%ammo = "MortarAmmo";
	if(%clientId.Weapon == "Napalm")
		%ammo = "NapalmAmmo";
	if(%clientId.Weapon == "PlasmaGun")
		%ammo = "PlasmaAmmo";
	if(%clientId.Weapon == "Railgun")
		%ammo = "RailAmmo";
	if(%clientId.Weapon == "RocketLauncher")
		%ammo = "RocketAmmo";
	if(%clientId.Weapon == "Shotgun")
		%ammo = "ShotgunAmmo";
	if(%clientId.Weapon == "Silencer")
		%ammo = "SilencerAmmo";
	if(%clientId.Weapon == "SniperRifle")
		%ammo = "SniperAmmo";
	if(%clientId.Weapon == "TranqGun")
		%ammo = "TranqAmmo";
	if(%clientId.Weapon == "Vulcan")
		%ammo = "VulcanAmmo";

	Player::setItemCount(%clientId,%ammo,0);

	Player::setItemCount(%clientId,Grenade,0);

	Player::setItemCount(%clientId,Beacon,0);

	Player::setItemCount(%clientId,RepairKit,0);

	Player::setItemCount(%clientId,MineAmmo,0);

	Player::setItemCount(%clientId,TargetingLaser,0);
}






function Nappy::Duel::Death(%deadClient, %killerClient, %damageType)
{
	if(%deadClient != %killerClient){
		%killerClient.DuelKills++;
		%deadClient.DuelDeaths++;
		%killerClient.score++;
		Game::refreshClientScore(%killerClient);
		Game::refreshClientScore(%deadClient);

		if(%killerClient.DuelType == "1on1"){
			Nappy::Duel::DisplayInfo(%deadClient, %killerClient, %damageType);
			
			%player = Client::getOwnedObject(%killerClient); 
			deleteObject(%player);
			Game::playerSpawn(%killerClient);
			Game::playerSpawn(%deadClient);
		}
		else{
			%winner = Nappy::getName(%killerClient);
			%loser = Nappy::getName(%deadClient);
			Client::sendMessage(%killerClient,0,"You killed " @ %loser @ ".");
			Client::sendMessage(%deadClient,0,%winner @ " killed you.");
		}
	}
	else if(%deadClient == %killerClient){
		//%deadClient.DuelDeaths++;
		%deadClient.Suicides++;
		%deadClient.score--;

		if(%killerClient.DuelType == "1on1"){
			Nappy::Duel::DisplayInfo(%deadClient, %killerClient, suicide);
			%player = Client::getOwnedObject(%deadClient); 
			playNextAnim(%deadClient); 
			Player::kill(%deadClient); 
			deleteObject(%player);
		}
		else{
			Client::sendMessage(%deadClient,0,"It's harder to kill your opponent.");
			Nappy::Chat::PitTeamMessageAllExcept(%deadClient, suicide);
		}

		Game::refreshClientScore(%deadClient);

		if(%deadClient != %deadClient.Opponent && %deadClient.Opponent != ""){
			remoteKill(%deadClient.Opponent);
			%player = Client::getOwnedObject(%deadClient.Opponent); 
			deleteObject(%player);
			Game::playerSpawn(%deadClient.Opponent);
		}
		Game::playerSpawn(%deadClient);
	}
}


function Nappy::Duel::SpawnReset(%clientId)
{
	if(%clientId.DuelType == "1on1")
		Nappy::DuelType::1on1Refresh(%clientId);
}


function Nappy::Duel::SetTypeInfo(%clientId)
{
	%clientId.Suicides = 0;
	%clientId.DuelKills = 0;
	%clientId.DuelDeaths = 0;
}


function Nappy::DuelType::1on1Refresh(%clientId)
{
	%clientId.Opponent = "";
	%clientId.Dueling = "";
	%clientId.HitOpponent = "0";
	%clientId.GotHit = "0";
	
}


//________________________________________________________________________________________
function Nappy::Duel::DisplayInfo(%loser, %winner, %damageTypeOfDestruction)
{
	%kills = %winner.DuelKills;
	%deaths = %winner.DuelDeaths;

	%winnerName = Nappy::getName(%winner);
	%loserName = Nappy::getName(%loser);

	%winnerArmor = Player::getArmor(%winner);
	%loserArmor = Player::getArmor(%loser);

	%winnerDamage = GameBase::getDamageLevel(%winnerArmor);
	%loserDamage = GameBase::getDamageLevel(%loserArmor);

	%gender = Client::getGender(%loser); 
	if(%gender == "Male")
		%genderTag = "him";
	else
		%genderTag = "her";

	if(%damageTypeOfDestruction != "suicide"){
		Client::sendMessage(%winner,0,"You killed " @ %loserName @ " in " @ %loser.GotHit @ " hits.");
		Client::sendMessage(%winner,0,"You were hit " @ %winner.GotHit @ " times.");// for a total of " @ %winnerDamage @ " damage.");

		Client::sendMessage(%winner,0,"You won " @ %winner.DuelKills @ " times and lost " @ %winner.DuelDeaths @ " Times.");
		Client::sendMessage(%winner,0,"You have " @ %winner.Suicides @ " suicides and " @ %loserName @ " has " @ %loser.Suicides @ " suicides.");

		Client::sendMessage(%loser,0,%winnerName @" killed you  in " @ %loser.GotHit @ " hits.");
		Client::sendMessage(%loser,0,"You hit " @ %winnerName @ " " @ %winner.GotHit @ " times.");// for a total of " @ %winnerDamage @ " damage.");

		Client::sendMessage(%loser,0,"You won " @ %loser.DuelKills @ " times and lost " @ %loser.DuelDeaths @ " Times.");
		Client::sendMessage(%loser,0,"You have " @ %loser.Suicides @ " suicides and " @ %winnerName @ " has " @ %winner.Suicides @ " suicides.");
	}
	else if(%damageTypeOfDestruction == "suicide"){
		if(%loser.Opponent != ""){
			Client::sendMessage(%loser.Opponent,0,%loserName @ " has killed " @ %genderTag @ "self.");
		}
		Client::sendMessage(%loser,0,"You have killed yourself " @ %loser.Suicides @ " times.");
	}

}

//.HitSelf

//________________________________________________________________________________________





//<jr> = put message to the right
//<jl> = put message to the left
//<jc> = put message in the center

//<f0> = orange
//<f1> = yellow
//<f2> = white

//bottomprint(%clientId, "", 0);
//centerprint(%clientId, %msg, %timeout)


function Nappy::Duel::CheckForHelpCommand(%clientId,%message)
{
	%Nappy::ChatRemote::Command = GetWord(%message,0);
	if(%Nappy::ChatRemote::Command == "!help"){
		Nappy::DuelPit::HelpMessages(%clientId, %message);
	}
}



function Nappy::DuelPit::HelpMessages(%clientId, %message)
{
	%messageColor = 0;
	%Nappy::Help::Command = GetWord(%message,1);
	if(%message == "reminder"){
		centerprint(%clientId, "<f2>REMEBER:<f1>\n        CAPS COUNT!!\n        AND THE OPTIONS WILL NOT WORK IF YOU ARE ON TEAM -1",10);
	}
	else if(%Nappy::Help::Command == "pit"){
		Client::sendMessage(%clientId,1,"PIT OPTIONS:");
		Client::sendMessage(%clientId,3,"type #duelers \"1 to whatever\" to change the amount of duelers for the team");
		Client::sendMessage(%clientId,3,"type #wall \"Bounce or Teleport\" to change the wall type");
		Client::sendMessage(%clientId,3,"type #size \"100 to 980\" to change the pit size");
		Client::sendMessage(%clientId,3,"type #duelType 1on1 to change the duel mode to one on one");

		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #duelers 2\n        #wall <f2>T<f1>eleport\n        #size 500\n        #duel<f2>T<f1>ype 1on1",10);
	}
	else if(%Nappy::Help::Command == "armor"){
		Client::sendMessage(%clientId,1,"ARMOR OPTIONS:");
		Client::sendMessage(%clientId,0,"type !help listArmors for a list of the armors");
		Client::sendMessage(%clientId,0,"type !help listArmorAmmo for a list of the armor ammo");
		Client::sendMessage(%clientId,0,"type !help listBackpacks for a list of the backpacks");
		Client::sendMessage(%clientId,0,"type !help listWeapons for a list of the weapons");
		Client::sendMessage(%clientId,3,"type #ammo \"0 to whatever\" to adjust all ammo(this gets multiplied to all ammo)");
		Client::sendMessage(%clientId,3,"type #weaponAmmo \"0 to whatever\" to set amount of weapon ammo");
		Client::sendMessage(%clientId,3,"type #grenades \"0 to whatever\" to set amount of armor grenades");
		Client::sendMessage(%clientId,3,"type #beacons \"0 to whatever\"to set amount of beacons");
		Client::sendMessage(%clientId,3,"type #mines \"0 to whatever\"to set amount of mines");
		Client::sendMessage(%clientId,3,"type #repairKits \"0 to whatever\"to set amount of repairKits");

		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #ammo 1\n        #weapon<f2>A<f1>mmo 35\n        #repair<f2>K<f1>its",10);
	}
	else if(%Nappy::Help::Command == "listArmors"){
		Client::sendMessage(%clientId,1,"ARMOR LIST:");
		Client::sendMessage(%clientId,3,"type #armor DuelerArmor for Dueler armor");
		Client::sendMessage(%clientId,3,"type #armor ScoutArmor for Scout armor");
		Client::sendMessage(%clientId,3,"type #armor SpyArmor for Spy armor");
		Client::sendMessage(%clientId,3,"type #armor SniperArmor for Sniper armor");
		Client::sendMessage(%clientId,3,"type #armor MercenaryArmor for Mercenary armor");
		Client::sendMessage(%clientId,3,"type #armor EngineerArmor for Engineer armor");
		Client::sendMessage(%clientId,3,"type #armor FlagMoverArmor for FlagMover armor");
		Client::sendMessage(%clientId,3,"type #armor BursterArmor for Burster armor");
		Client::sendMessage(%clientId,3,"type #armor CyborgArmor for Cyborg armor");

		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #armor <f2>D<f1>ueler<f2>A<f1>rmor\n        #armor <f2>S<f1>cout<f2>A<f1>rmor\n        #armor <f2>E<f1>ngineer<f2>A<f1>rmor",10);
	}
	else if(%Nappy::Help::Command == "listArmorAmmo"){
		Client::sendMessage(%clientId,1,"ARMOR AMMO TYPES:");
		Client::sendMessage(%clientId,3,"type #grenadeType <ammo>");
		Client::sendMessage(%clientId,3,"type #beaconType <ammo>");
		Client::sendMessage(%clientId,3,"type #mineType <ammo>");
		Client::sendMessage(%clientId,3,"type #repairKitType <ammo>");
		Client::sendMessage(%clientId,1,"ARMOR AMMO LIST:");
		Client::sendMessage(%clientId,2,"Firebomb for scout grenade");
		Client::sendMessage(%clientId,2,"Handgrenade for mercenary grenade");
		Client::sendMessage(%clientId,2,"Shockgrenade for engineer grenade");
		Client::sendMessage(%clientId,2,"Tranqgrenade for flagmover grenade");
		Client::sendMessage(%clientId,2,"Concussion for burster grenade");
		Client::sendMessage(%clientId,2,"Mortarbomb for cyborg grenade");
		Client::sendMessage(%clientId,2,"boost for mercenary beacon");
		Client::sendMessage(%clientId,2,"cloak for flagmover beacon");
		Client::sendMessage(%clientId,2,"shield for cyborg beacon");
		Client::sendMessage(%clientId,2,"DuelMine for mine");
		Client::sendMessage(%clientId,2,"repairKit for repair kit");
		Client::sendMessage(%clientId,2,"repairKit2 for non damage scaled repair kit");

		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #grenade<f2>T<f1>ype shield\n        #beacon<f2>T<f1>ype repair<f2>K<f1>it\n        #mine<f2>T<f1>ype <f2>S<f1>hockgrenade\n        #repair<f2>K<f1>it<f2>T<f1>ype boost\n",10);
	}
	else if(%Nappy::Help::Command == "listBackpacks"){
		Client::sendMessage(%clientId,1,"BACKPACK LIST:");
		Client::sendMessage(%clientId,3,"type #backpack EnergyPack for an Energy Pack");
		Client::sendMessage(%clientId,3,"type #backpack RepairPack for a Repair Pack");
		Client::sendMessage(%clientId,3,"type #backpack ShieldPack for a Shield Pack");
		Client::sendMessage(%clientId,3,"type #backpack CloakingDevice for a Cloaking Device");
		Client::sendMessage(%clientId,3,"type #backpack StealthShieldPack for a StealthShield Pack");
		Client::sendMessage(%clientId,3,"type #backpack RegenerationPack for a Regeneration Pack");
		Client::sendMessage(%clientId,3,"type #backpack LightningPack for a Lightning Pack");
		Client::sendMessage(%clientId,3,"type #backpack OpticPack for a Cybernetic Laser");
		Client::sendMessage(%clientId,3,"type #backpack SMRPackImage for an Auto-Rocket Cannon");
		Client::sendMessage(%clientId,3,"type #backpack SuicidePack for a Suicide DetPack");
		Client::sendMessage(%clientId,3,"type #backpack AmmoPack for an Ammo Pack");

		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #backpack <f2>E<f1>nergy<f2>P<f1>ack\n        #backpack <f2>R<f1>epair<f2>P<f1>ack\n        #backpack <f2>A<f1>mmo<f2>P<f1>ack",10);
	}
	else if(%Nappy::Help::Command == "listWeapons"){
		Client::sendMessage(%clientId,1,"WEAPON LIST:");
		Client::sendMessage(%clientId,3,"type #weapon Chaingun for Chaingun");
		Client::sendMessage(%clientId,3,"type #weapon DiscLauncher for Disc Launcher");
		Client::sendMessage(%clientId,3,"type #weapon GrenadeLauncher for Grenade Launcher");
		Client::sendMessage(%clientId,3,"type #weapon Mortar for Mortar");
		Client::sendMessage(%clientId,3,"type #weapon Napalm for Napalm Launcher");
		Client::sendMessage(%clientId,3,"type #weapon PlasmaGun for Plasma Gun");
		Client::sendMessage(%clientId,3,"type #weapon Railgun for Railgun");
		Client::sendMessage(%clientId,3,"type #weapon RocketLauncher for Rocket Launcher");
		Client::sendMessage(%clientId,3,"type #weapon Shotgun for Shotgun");
		Client::sendMessage(%clientId,3,"type #weapon Silencer for Magnum");
		Client::sendMessage(%clientId,3,"type #weapon SniperRifle for Sniper Rifle");
		Client::sendMessage(%clientId,3,"type #weapon TranqGun for Dart Rifle");
		Client::sendMessage(%clientId,3,"type #weapon Vulcan for Vulcan");
		Client::sendMessage(%clientId,3,"type #weapon WaveGun for Shockwave Cannon");
		Client::sendMessage(%clientId,3,"type #weapon LaserRifle for Laser Rifle");
		Client::sendMessage(%clientId,3,"type #weapon Blaster for Blaster");
		Client::sendMessage(%clientId,3,"type #weapon Omega for Omega");
		Client::sendMessage(%clientId,3,"type #weapon IonGun for Ion Rifle");
		Client::sendMessage(%clientId,3,"type #weapon EnergyRifle for Thunderbolt");

		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #weapon <f2>C<f1>haingun\n        #weapon <f2>D<f1>isc<f2>L<f1>auncher\n        #weapon <f2>R<f1>ocket<f2>L<f1>auncher",10);
	}
	else if(%Nappy::Help::Command == "damage"){
		Client::sendMessage(%clientId,1,"DAMAGE TYPE LIST:");
		Client::sendMessage(%clientId,3,"type #damage \"0 to whatever\" to adjust amount of all damage types");
		Client::sendMessage(%clientId,3,"type #LandingDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #BulletDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #ExplosionDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #ShrapnelDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #MissileDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #ShockDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #SniperDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #PoisonDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #FireDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #MineDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #LaserDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #MortarDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #BlasterDamage \"0 to whatever\"");
		Client::sendMessage(%clientId,3,"type #ElectricityDamage \"0 to whatever\"");
			
		bottomprint(%clientId, "<f2>EXAMPLES:<f1>\n        #damage 0.1\n        #<f2>L<f1>anding<f2>D<f1>amage 0\n        #<f2>E<f1>xplosion<f2>D<f1>amage 1.5",10);
	}
	else{
		Client::sendMessage(%clientId,1,"DUEL PIT TEAM HELP:");
		Client::sendMessage(%clientId,0,"type !help pit for pit options");
		Client::sendMessage(%clientId,0,"type !help armor for armor options");
		Client::sendMessage(%clientId,0,"type !help damage for damage options");
		Client::sendMessage(%clientId,3,"type #pit \"1 to 8\" to change your pit");
		Client::sendMessage(%clientId,3,"type #team \"-1 to 1\" to change your team");

		bottomprint(%clientId, "<f2>WHAT TO DO...<f1>\n        #pit 5\n        #team 0\n\n<f2>WHAT NOT TO DO...<f1>\n        #pit \"1 to 8\"\n        #Team 0", 15);
		schedule("Nappy::DuelPit::HelpMessages(" @ %clientId @ ", reminder);",15);

	}
}



function Nappy::DuelPit::Messages(%clientId, %message, %other, %other2, %other3, %other4)
{
	if(%message == "enter"){
		centerprint(%clientId,"<jc>Type \"<f1>!help<f0>\" for help with the duel pit options.", 10);
//		centerprint(%clientId,3,"There are 8 pits with 3 teams per pit");
//		centerprint(%clientId,3,"Team -1 can't be changed");

//		Client::sendMessage(%clientId,3,"Type \"!help\" for help with the duel pit team setup.");
		Client::sendMessage(%clientId,3,"There are 8 pits with 3 teams per pit");
		Client::sendMessage(%clientId,3,"Team -1 can't be changed");
	}
	else if(%message == "pitnum"){
		%pit = %other;
		%pitMessage = "<jc>.:{  DUEL PIT " @ %pit @ "  }:.";
		%time = 0.25;
		centerprint(%clientId, %pitMessage, %time);
	}
	else if(%message == "damage"){
		%shooterClient = %clientId;
		%damagedClient = %other;
		%armor = %other2;
		%spillOver = %other3;
		%newvalue = %other4;
		if(%spillOver > 0){
			%newvalue = %newvalue - %spillOver; 
		}
		%newvalue = (%newvalue * 100) / %armor.maxDamage;//(damage*100)/max
		%wholeNum = 0;
		%otherNum = 0;
		%otherNum2 = 0;
		for(%i = 0; %newvalue >= 1; %i++){
			%newvalue--;
			%wholeNum++;
		}
		for(%i = 0; %newvalue >= 0.1; %i++){
			%newvalue = %newvalue - 0.1;
			%otherNum++;
		}
		for(%i = 0; %newvalue >= 0.01; %i++){
			%newvalue = %newvalue - 0.01;
			%otherNum2++;
		}
		Client::sendMessage(%shooterClient,0,"You just harmed " @ Nappy::getName(%damagedClient) @ " " @ %wholeNum @ "." @ %otherNum @ %otherNum2 @ "%.");
		Client::sendMessage(%damagedClient,0,Nappy::getName(%shooterClient) @ " just harmed you " @ %wholeNum @ "." @ %otherNum @ %otherNum2 @ "%.");
	}
	else if(%message == "WrongTeamForOption"){
		Client::sendMessage(%clientId, 1, %other @ " can't be used for this team.~waccess_denied.wav");
		centerprint(%clientId, "<jc>To change teams type\n<jc>\"<f1>#team 0<f0>\"\n<jc>or\n<jc>\"<f1>#team 1<f0>\"", 10);
	}
}

