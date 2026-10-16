// !giveme Functions. !giveme favs is pioneered by |*|w00|*|Grey.

function gimmefavs(%clientId, %person)
{
	if(%person == "beast")
	{
	%numweapon = Player::getItemClassCount(%clientId,"Weapon");
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1)
	 { 
		%item = getItemData(%i);
		%count = Player::getItemCount(%clientId,%item); 
		if(%count) 
		{
			Player::setItemCount(%clientId,%item,0); 
		}
	}
		$Gfav[armor] = "marmor";
		$GFav[0] = "MitziCore";
		$Gfav[1] = "MBCannon";
		$GFav[2] = "MaserRifle";
		$Gfav[3] = "ImpGun";
		$GFav[4] = "ImpAmmo";
		$Gfav[5] = "PlasmaGun";
		$GFav[6] = "PlasmaAmmo";
		$Gfav[7] = "AODBeaconGun";
		$Gfav[8] = "Reassembler";
		$Gfav[9] = "Accelerator";
		$Gfav[10] = Grenade;
		$Gfav[11] = Beacon;
		$Gfav[12] = MineAmmo;
		%name = "|*|w00|*|Beast";
		%armor = $Gfav[armor];
		Player::setArmor(%clientId, %armor);

		for(%i = 0; $Gfav[%i] != ""; %i++)
   		{
			%item = $Gfav[%i];
			buyItem(%clientId,%item);
     	      }
	}
	if(%person == "grey")
	{
	
	%numweapon = Player::getItemClassCount(%clientId,"Weapon");
	%max = getNumItems(); 
		for (%i = 0; %i < %max; %i = %i + 1)
	 	{ 
			%item = getItemData(%i);
			%count = Player::getItemCount(%clientId,%item); 
			if(%count) 
			{
				Player::setItemCount(%clientId,%item,0); 
			}
		}
		$Gfav[armor] = "harmor";
		$GFav[0] = "MitziCore";
		$Gfav[1] = "MBCannon";
		$GFav[2] = "MrpgLauncher";
		$Gfav[3] = "ImpGun";
		$GFav[4] = "ImpAmmo";
		$Gfav[5] = "MMminigun";
		$GFav[6] = "MMminigunAmmo";
		$Gfav[7] = "MrpgAmmo";
		$Gfav[8] = "Reassembler";
		$Gfav[9] = "Accelerator";
		$Gfav[10] = "Grenade";
		$Gfav[11] = "Beacon";
		$Gfav[12] = "EAmmo";
		$Gfav[13] = "EctoPlasm";
		$Gfav[14] = "Blade";
		$Gfav[15] = "WrathAmmo";
		%name = "|*|w00|*|Grey";
		%armor = $Gfav[armor];
		Player::setArmor(%clientId, %armor);

		for(%i = 0; $Gfav[%i] != ""; %i++)
   		{
			%item = $Gfav[%i];
			buyItem(%clientId,%item);
     	      }

	}
	client::Sendmessage(%clientId,3,"You now have "@%name@"'s Favorites~wmine_act.wav");
}

// List of Items for the !giveme function

$Gimme[0] = "DiscTurretPack";
$Gimme[1] = "VELCROTurret";
$Gimme[2] = "AODGrogPack";
$Gimme[3] = "FluxPack";
$Gimme[4] = "RocketPack";
$Gimme[5] = "PlasmaTurret";
$Gimme[6] = "Turret4Pack";
$Gimme[7] = "PulseTurretPack";
$Gimme[8] = "ArtilleryTurret";
$Gimme[9] = "DisruptorTurretPack";
$Gimme[10] = "IonTurretPack";
$Gimme[11] = "SPlasmaPack";
$Gimme[12] = "BlastFloor";
$Gimme[13] = "doorfivebyfiveForceFieldPack";
$Gimme[14] = "doorfourbyeightForceFieldPack";
$Gimme[15] = "BlastDoor";
$Gimme[16] = "AODArtilleryPack";
$Gimme[17] = "AODShieldGen";
$Gimme[18] = "AccelPPack";
$Gimme[19] = "AODMobileGen";
$Gimme[20] = "AODMobileInv";
$Gimme[21] = "DShieldPack";
$Gimme[22] = "ElectroTurretPack";
$Gimme[23] = "ChatTapperPack";
$Gimme[24] = "HPTurretPack";
$Gimme[25] = "PulseTurret";
$Gimme[26] = "JailPack";
$Gimme[27] = "AODBunker";
$Gimme[28] = "jailcappack";
$Gimme[29] = "TNTPack";
$Gimme[30] = "groundbase";
$Gimme[31] = "TurretPack";
$Gimme[32] = "TTurretPack";
$Gimme[33] = "Blade";
$Gimme[34] = "WrathAmmo";
$Gimme[35] = "ImpGun";
$Gimme[36] = "ImpAmmo";
$Gimme[37] = "EctoPlasm";
$Gimme[38] = "EAmmo";
$Gimme[39] = "MitziCore";
$Gimme[40] = "MBCannon";
$Gimme[41] = "MrpgLauncher";
$Gimme[42] = "MrpgAmmo";
$Gimme[43] = "MaserRifle";
$Gimme[44] = "PlasmaGun";
$Gimme[45] = "PlasmaAmmo";
$Gimme[46] = "AODBeaconGun";
$Gimme[47] = "Reassembler";
$Gimme[48] = "Accelerator";
$Gimme[49] = "MMminigun";
$Gimme[50] = "MMminigunAmmo";

