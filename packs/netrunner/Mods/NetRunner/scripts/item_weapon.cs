$PickupSound[Weapon] = "SoundPickupWeapon";

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") Item::onDrop(%player,%item);
}

function Weapon::onUse(%player,%item)
{
	if(%player.Station=="")
	{
		%ammo = %item.imageType.ammoType;
		if (%ammo == "")
		{
// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else
		{
			if (Player::getItemCount(%player,%ammo) > 0) Player::mountItem(%player,%item,$WeaponSlot);
			else
			{
				Client::sendMessage(Player::getClient(%player),0,strcat(%item.description," has no ammo"));
			}
		}
	}
}

$FirstWeapon = "";
$LastWeapon = "";

$WeaponCount = 0;

function addWeapon(%weap)
{
	if ($FirstWeapon == "") $FirstWeapon = %weap;
	if ($LastWeapon == "") $LastWeapon = %weap;
	$PrevWeapon[%weap] = $LastWeapon;
	$NextWeapon[%weap] = $FirstWeapon;
	$PrevWeapon[$FirstWeapon] = %weap;
	$NextWeapon[$LastWeapon] = %weap;
	$LastWeapon = %weap;
	$WeaponList[$WeaponCount] = %weap;
	$WeaponCount++;
}

function remoteNextWeapon(%client)
{
	%player=Client::getownedobject(%client);
	if((%player==-1) || Player::IsDead(%player)) return;
	%pl = Client::getControlObject(%client);
	if (getObjectType(%pl) != "Player") return;
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "") selectValidWeapon(%client);
	else
	{
		for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
// Make sure it mounted (laser may not), or at least next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break;
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	%player=Client::getownedobject(%client);
	if((%player==-1) || Player::IsDead(%player)) return;
	%pl = Client::getControlObject(%client);
	if (getObjectType(%pl) != "Player") return;


	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $PrevWeapon[%item] == "") selectValidWeapon(%client);
	else
	{
		for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
// Make sure it mounted (laser may not), or at least next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break;
			}
		}
	}
}

function selectValidWeapon(%client)
{
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
	{
		if (isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if (Player::getItemCount(%client,%weapon))
	{
		%ammo = %weapon.imageType.ammoType;
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0) return true;
	}
	return false;
}

echo('>> Loading Weapons');
exec(weap_chaingun);
exec(weap_disclauncher);
exec(weap_grenadelauncher);
exec(weap_laserrifle);
exec(weap_energyrifle);
exec(weap_mortar);
exec(weap_arkfire);
exec(weap_blaster);
exec(weap_plasmagun);
echo('>> Finished Loading Weapons');

