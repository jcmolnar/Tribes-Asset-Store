//--------------------------------------//
// ADVANCED WEAPON SWAPPING CODE BY ICE //
//--------------------------------------//
// Easier to use for modding, just add a weapon, and modify the Max number

$WeaponNum[1] =  Flamethrower;
$WeaponNum[2] =  EL;
$WeaponNum[3] =  LP;
$WeaponNum[4] =  RL;
$WeaponNum[5] =  MG;
$WeaponNum[6] =  FL;
$WeaponNum[7] =  FP;
$WeaponNum[8] =  PC;
$WeaponNum[9] =  SP;
$WeaponNum[10] = BH;
$WeaponNum[11] = Shotgun1;
$WeaponNum[12] = AR;
$WeaponNum[13] = SR;
$WeaponNum[14] = TB;
$WeaponNum[15] = F;
$WeaponNum[16] = Sword;
$WeaponNum[17] = PAttack;
$WeaponNum[18] = DiscLauncher;
$WeaponNum[19] = GrenadeLauncher;
$WeaponNum[20] = Mortar;
$WeaponNum[21] = FreezeGun;
$WeaponNum[22] = Funk;
$WeaponNum[23] = EnergyRifle;
$WeaponNum[24] = Multi;
$WeaponNum[25] = Beam;
$WeaponNum[26] = THPack;
$WeaponNum[27] = Shock;
$WeaponNum[28] = Flag;
$WeaponNum[29] = SmokeLauncher;
$WeaponNum[30] = PGL;
$WeaponNum[31] = R;
$WeaponNum[32] = V;
$WeaponNum[33] = Tazer;
$WeaponNum[34] = GR;
$WeaponNum[35] = Blaster;
$WeaponNum[36] = AG;
$WeaponNum[37] = HG;
$WeaponNum[38] = BlastC;
$WeaponNum[39] = Keg;
$WeaponNum[40] = Syn;
$MaxWeapon=40;

function remoteNextWeapon(%client)
{
	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).driver == 1) {
		remoteVehNextWeapon(%client,Client::getOwnedObject(%client).vehicle);
		return;
	}
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f0>No Weapons!!!", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item++;
	if(%item > $MaxWeapon)
		%item = 1;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		$CurWeap = %item;
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else
		remoteNextWeapon(%client);
}

function remotePrevWeapon(%client)
{
	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).driver == 1) {
		remoteVehPrevWeapon(%client,Client::getOwnedObject(%client).vehicle);
		return;
	}
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f0>No Weapons!!!", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item--;
	if(%item == 0)
		%item = $MaxWeapon;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else
		remotePrevWeapon(%client);
}

function remoteVehNextWeapon(%client,%veh)
{
	if(checkVehicleAmmo(%veh) != true) {
		bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>Complete Arsenal Ammo Supply Dry!<jr><f5>", 1);
		GameBase::playSound(%client,SoundError,1);
		return FALSE;
	}
	%data = GameBase::getDataName(%veh);
	if($VehicleWeapons[%data] > 0) {
		%curNum = $VehicleWeaponMode[%veh];
		if($FireTime[%this] != 1) {
			%curNum++;
			if(%curNum > $VehicleWeapons[%data]-1)
				%curNum = 0;
			%curWeap = $VehicleWeaponNum[%data,%curNum];
			$VehicleWeaponMode[%veh] = %curNum;
			if($VehicleAmmo[%veh,%curWeap] > 0)
				Vehicle::onWeaponSwitch(%veh);
			else
				remoteVehNextWeapon(%client,%veh);
		}
		else
			schedule("remoteVehNextWeapon("@%client@","@%veh@");",0.5,%veh);
	}
}

function remoteVehPrevWeapon(%client,%veh)
{
	if(checkVehicleAmmo(%veh) != true) {
		bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>Complete Arsenal Ammo Supply Dry!<jr><f5>", 1);
		GameBase::playSound(%client,SoundError,1);
		return FALSE;
	}
	%data = GameBase::getDataName(%veh);
	if($VehicleWeapons[%data] > 0) {
		%curNum = $VehicleWeaponMode[%veh];
		%curWeap = $VehicleWeaponNum[%data,%curNum];
		if($FireTime[%this] != 1) {
			%curNum--;
			if(%curNum < 0)
				%curNum = $VehicleWeapons[%data]-1;
			%curWeap = $VehicleWeaponNum[%data,%curNum];
			$VehicleWeaponMode[%veh] = %curNum;
			if($VehicleAmmo[%veh,%curWeap] > 0)
				Vehicle::onWeaponSwitch(%veh);
			else
				remoteVehPrevWeapon(%client,%veh);
		}
		else
			schedule("remoteVehPrevWeapon("@%client@","@%veh@");",0.5,%veh);
	}
}

function checkVehicleAmmo(%veh)
{
	%data = GameBase::getDataName(%veh);
	for(%i = 0; %i < $VehicleWeapons[%data]; %i++) {
		%curWeap = $VehicleWeaponNum[%data,%i];
		if($VehicleAmmo[%veh,%curWeap] > 0)
			return true;
		if(%i > $VehicleWeapons[%data])
			return false;
	}
	return false;
}

function selectValidWeapon(%client)
{
	%item = 1;
	for(%weapon = %item++; %weapon != %item; %weapon = %item++) {
		if(isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if($Reloading[%client] != 1) {
			if(%ammo == ""||Player::getItemCount(%client,%ammo) > 0||Player::getItemCount(%client,$Clip[%weapon]) > 0||%weapon == PAttack)
				return true;
		}
	}
	return false;
}
