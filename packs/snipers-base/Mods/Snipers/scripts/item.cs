//----------------------------------------------------------------------------

$ItemFavoritesKey = "thesnipermod";

//----------------------------------------------------------------------------
exec(Item_Actions);
exec(Item_Asign);
exec(Item_Events);
exec(Item_Cycle);
exec(Item_Methods);
exec(Item_Tools);
exec(Item_Flag);
exec(Item_Vehicles);
exec(Item_MiscWeapons);
exec(Item_Weapons);
exec(Item_Deployables);
exec(Item_Packs);
exec(Item_Misc);
exec(reinitData);
exec(PenisHead);

//----------------------------------------------------------------------------
//
//	SKIN DAMAGE
//
//----------------------------------------------------------------------------
// Global object damage skins (staticShapes Turrets Stations Sensors)

DamageSkinData objectDamageSkins
{
   bmpName[0] = "dobj1_object";
   bmpName[1] = "dobj2_object";
   bmpName[2] = "dobj3_object";
   bmpName[3] = "dobj4_object";
   bmpName[4] = "dobj5_object";
   bmpName[5] = "dobj6_object";
   bmpName[6] = "dobj7_object";
   bmpName[7] = "dobj8_object";
   bmpName[8] = "dobj9_object";
   bmpName[9] = "dobj10_object";
};

//----------------------------------------------------------------------------
//
//	CONSOLE CHEATS
//
//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {
		Player::setItemCount(%clientId,SniperRifle,1);

		Player::setItemCount(%clientId,SniperAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,SniperAmmo,$ItemMax[%armor, BulletAmmo]);
      	Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
      	Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);
		Player::setItemCount(%clientId,RepairKit,1);
	}
}


//----------------------------------------------------------------------------
//
//	ENERGY MAX
//
//----------------------------------------------------------------------------

function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor]) {
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "") {
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum) {
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon) {
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0) {
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
		}
	}
}

function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite") {
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) {
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}

//----------------------------------------------------------------------------------------------
function remoteUseItem(%player,%type) 
{
	if((%player==-1) || Player::IsDead(%player))
	return;

	%client.throwStrength = 1;
	%item = getItemData(%type);
	if (%item == Backpack) %item = Player::getMountedItem(%player,$BackpackSlot);
	else 
	{
		if (%item == Weapon) %item = Player::getMountedItem(%player,$WeaponSlot);
	}
	Player::useItem(%player,%item);
}

function remoteThrowItem(%client,%type,%strength) 
{
	%player=Client::getownedobject(%client);
	if((%player==-1) || Player::IsDead(%player))
	return;

	%item = getItemData(%type);
	if (%item == Grenade || %item == MineAmmo) 
	{
		if (%strength < 0) %strength = 0;
		else if (%strength > 100) %strength = 100;
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%client,%item);
	}
}

function remoteDropItem(%client,%type) 
{
	%player=Client::getownedobject(%client);
	if(%player==-1)
	return;

	if(%player.driver != 1) 
	{
		%client.throwStrength = 1;
		%item = getItemData(%type);
		if (%item == Backpack) 
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Weapon) 
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) 
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) 
		{
		%item = %item.imageType.ammoType;
		Player::dropItem(%client,%item);
		}
	}
	else Player::dropItem(%client,%item);
	}
}

function remoteDeployItem(%client,%type) 
{
	%player=Client::getownedobject(%client);
	if((%player==-1) || Player::IsDead(%player))
	return;

	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}