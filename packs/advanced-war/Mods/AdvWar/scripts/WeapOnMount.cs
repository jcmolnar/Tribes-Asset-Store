
// Easier to use for modding, just add a weapon, and modify the Max number

$WeaponNum[1] =  Blaster;
$WeaponNum[2] =  PlasmaGun;
$WeaponNum[3] =  Chaingun;
$WeaponNum[4] =  Disclauncher;
$WeaponNum[5] =  Grenadelauncher;
$WeaponNum[6] =  Mortar;
$WeaponNum[7] =  LaserRifle;
$WeaponNum[8] =  EnergyRifle;
$WeaponNum[9] =  AODBeaconGun;
$WeaponNum[10] =  RocketLauncher;

$MaxWeapon= 10;

function remoteNextWeapon(%client)
{
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f0>[You Have No Weapons]", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item++;
	if(%item == $MaxWeapon+1)
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
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f0>[You Have No Weapons]", 1);
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

function selectValidWeapon(%client)
{
	%item = 1;
	for(%weapon = %item++; %weapon != %item; %weapon = %item++) {
		echo(%weapon);
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
