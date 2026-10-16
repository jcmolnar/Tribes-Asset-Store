
// Easier to use for modding, just add a weapon, and modify the Max number

$WeaponNum[1] =  Blaster;
$WeaponNum[2] =  PlasmaGun;
$WeaponNum[3] =  Chaingun;
$WeaponNum[4] =  DiscLauncher;
$WeaponNum[5] =  HDiscLauncher;
$WeaponNum[6] =  GrenadeLauncher;
$WeaponNum[7] =  Mortar;
$WeaponNum[8] =  LaserRifle;
$WeaponNum[9] =  RocketLauncher;
$WeaponNum[10] = SniperRifle;
$WeaponNum[11] = Railgun;
$WeaponNum[12] = Wavegun;
$WeaponNum[13] = EnergyRifle;
$WeaponNum[14] = PlasmaCannon;
$WeaponNum[15] = Silencer;
$WeaponNum[16] = Vulcan;
$WeaponNum[17] = Flamer;
$WeaponNum[18] = IonGun;
$WeaponNum[19] = HyperB;
$WeaponNum[20] = Omega;
$WeaponNum[21] = TargetMarkLaser;
$WeaponNum[22] = Fixit;
//===----====----====Angel Crap here
$WeaponNum[23] = Flamer2;
$WeaponNum[24] = Heal;
$WeaponNum[25] = implode;
$WeaponNum[26] = Freeze;
$WeaponNum[27] = ESP;
$WeaponNum[28] = FireBall;
$WeaponNum[29] = DFA;
$WeaponNum[30] = PLA;
$WeaponNum[31] = GodTear;
$WeaponNum[32] = Quake;
$WeaponNum[33] = AB;
$WeaponNum[34] = WG;
$WeaponNum[35] = HM;

$MaxWeapon=35;

function remoteNextWeapon(%client, %portDepth)
{
	if(%portDepth < 0 || %portDepth > $MaxWeapon) return; // PORT (2026-10-12): stop after one pass over the weapon table
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f2>[You Have No Weapons]", 1);
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
		remoteNextWeapon(%client, %portDepth + 1);
}

function remotePrevWeapon(%client, %portDepth)
{
	if(%portDepth < 0 || %portDepth > $MaxWeapon) return; // PORT (2026-10-12): stop after one pass over the weapon table
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f2>[You Have No Weapons]", 1);
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
		remotePrevWeapon(%client, %portDepth + 1);
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
