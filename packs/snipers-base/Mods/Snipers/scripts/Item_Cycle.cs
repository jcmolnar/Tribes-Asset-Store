//-------------------------------------------------
//
//	ITEM CYCLE
//
//------------------------------------------------- 

 //-=-=-=- Ammo handling -=-=-=-

$AmmoCount = 0;

function addAmmo(%weapon, %ammo, %count)
{
	$Ammo_Weapon[$AmmoCount] = %weapon;
	$Ammo_Ammo[$AmmoCount] = %ammo;
	$Ammo_Count[$AmmoCount] = %count;  
	$AmmoCount++;
}

 //-=-=-=- Weapon handling -=-=-=-

$FirstWeapon = "";
$LastWeapon = "";

function addWeapon(%weap)
{
	if ($FirstWeapon == "")
	$FirstWeapon = %weap;
	if ($LastWeapon == "") 
	$LastWeapon = %weap;
	$PrevWeapon[%weap] = $LastWeapon;
	$NextWeapon[%weap] = $FirstWeapon;
	$PrevWeapon[$FirstWeapon] = %weap;
	$NextWeapon[$LastWeapon] = %weap;
	$LastWeapon = %weap;
}

function remoteNextWeapon(%client) 
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 
 	if (%armor == "parmor")
	return;

	if((%player==-1) || Player::IsDead(%player))
	return;

		%pl = Client::getControlObject(%client);
		if (getObjectType(%pl) != "Player") return;

			%item = Player::getMountedItem(%client,$WeaponSlot);
			if (%item == -1 || $NextWeapon[%item] == "") 
			selectValidWeapon(%client);
			 else 
			{
			for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) 
			{
			if (isSelectableWeapon(%client,%weapon)) 
			{
				Player::useItem(%client,%weapon);
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break;
			}
		}
	}
}

function remotePrevWeapon(%client) 
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 
 	if (%armor == "parmor")
	return;

	if((%player==-1) || Player::IsDead(%player))
	return;

		%pl = Client::getControlObject(%client);
		if (getObjectType(%pl) != "Player") return;

			%item = Player::getMountedItem(%client,$WeaponSlot);
			if (%item == -1 || $PrevWeapon[%item] == "") 
			selectValidWeapon(%client);
			else 
			{
			for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]) 
			{
			if (isSelectableWeapon(%client,%weapon)) 
			{
				Player::useItem(%client,%weapon);
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break;
			}
		}
	}
}

function selectValidWeapon(%client) 
{
	%item = $FirstWeapon;
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
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0) return true;
	}
	return false;
}
 //-=-=-=-
