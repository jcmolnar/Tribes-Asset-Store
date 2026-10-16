//----------------------------------------------------------------------------

$ItemFavoritesKey = "Paintball26";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

// vvv Added for money vvv
if ($Money::Enabled)
	$ItemPopTime = $Money::PopTime;
else
	$ItemPopTime = $PB::itemPopTime;
// ^^^ Added for money ^^^

$ToolSlot	= 0;
$WeaponSlot	= 0;
$BackpackSlot	= 1;
$FlagSlot	= 2;
$DefaultSlot	= 3;
$ExtraSlot1	= 4;
$ExtraSlot2	= 5;
$ExtraSlot3	= 6;
$ExtraSlot4	= 7;

$AutoUse[Shocker]	= True;
$AutoUse[Angel]		= True;
$AutoUse[Delta]		= True;
$AutoUse[Inferno]	= True;
$AutoUse[Psycho]	= True;
$AutoUse[Intimidator]	= True;
$AutoUse[Mongoose]	= True;
$AutoUse[MiniGun]	= True;
$AutoUse[TipmannS]	= True;
$AutoUse[Spyder]	= True;
$AutoUse[AutoCocker]	= True;
$AutoUse[Dragun]	= True;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Female, LightArmor] = lfemale;

$ArmorName[larmor] = LightArmor;
$ArmorName[lfemale] = LightArmor;

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

// Weapon to ammo table
$WeaponAmmo[Angel]	= AngelAmmo;
$WeaponAmmo[Dragun]	= DragunAmmo;
$WeaponAmmo[AutoCocker]	= AutoCockerAmmo;
$WeaponAmmo[Spyder]	= SpyderAmmo;
$WeaponAmmo[TipmannS]	= TipmannSAmmo;
$WeaponAmmo[Mongoose]	= MongooseAmmo;
$WeaponAmmo[Intimidator]= IntimidatorAmmo;
$WeaponAmmo[Psycho]	= PsychoAmmo;
$WeaponAmmo[Inferno]	= InfernoAmmo;
$WeaponAmmo[Delta]	= DeltaAmmo;
$WeaponAmmo[Shocker]	= ShockerAmmo;
$WeaponAmmo[MiniGUn]	= MiniGunAmmo;

// Amount to remove when selling or dropping ammo
$SellAmmo[Beacon]		= 0;
$SellAmmo[MineAmmo]		= 0;
$SellAmmo[Grenade]		= 1;
$SellAmmo[AngelAmmo]		= 100;
$SellAmmo[DragunAmmo]		= 100;
$SellAmmo[ShockerAmmo]		= 100;
$SellAmmo[AutoCockerAmmo]	= 100;
$SellAmmo[SpyderAmmo]		= 100;
$SellAmmo[TipmannSAmmo]		= 100;
$SellAmmo[MiniGunAmmo]		= 100;
$SellAmmo[MongooseAmmo]		= 100;
$SellAmmo[IntimidatorAmmo]	= 100;
$SellAmmo[PsychoAmmo]		= 100;
$SellAmmo[InfernoAmmo]		= 100;
$SellAmmo[DeltaAmmo]		= 100;

$Clip[Angel]		= "AngelClip";
$Clip[AutoCocker]	= "AutoCockerClip";
$Clip[Spyder]		= "SpyderClip";
$Clip[Dragun]		= "DragunClip";
$Clip[TipmannS]		= "TipmannSClip";
$Clip[Mongoose]		= "MongooseClip";
$Clip[Intimidator]	= "IntimidatorClip";
$Clip[Psycho]		= "PsychoClip";
$Clip[Inferno]		= "InfernoClip";
$Clip[Delta]		= "DeltaClip";
$Clip[Shocker]		= "ShockerClip";
$Clip[MiniGUn]		= "MiniGunClip";

//>-Defines the Magazine's size
$ClipSize[Angel]	= $PB::ClipSize;
$ClipSize[AutoCocker]	= $PB::ClipSize;
$ClipSize[Spyder]	= $PB::ClipSize;
$ClipSize[Dragun]	= $PB::ClipSize;
$ClipSize[TipmannS]	= $PB::ClipSize;
$ClipSize[Mongoose]	= $PB::ClipSize;
$ClipSize[Intimidator]	= $PB::ClipSize;
$ClipSize[Psycho]	= $PB::ClipSize;
$ClipSize[Inferno]	= $PB::ClipSize;
$ClipSize[Shocker]	= $PB::ClipSize;
$ClipSize[Delta]	= $PB::SpawnClipSize;
$ClipSize[MiniGun]	= "999";

//>-Defines how long the gun takes to switch magazines 
$ClipTime[Angel]	= $PB::ReloadTime;
$ClipTime[AutoCocker]	= $PB::ReloadTime;
$ClipTime[Spyder]	= $PB::ReloadTime;
$ClipTime[Dragun]	= $PB::ReloadTime;
$ClipTime[TipmannS]	= $PB::ReloadTime;
$ClipTime[Mongoose]	= $PB::ReloadTime;
$ClipTime[Intimidator]	= $PB::ReloadTime;
$ClipTime[Psycho]	= $PB::ReloadTime;
$ClipTime[Inferno]	= $PB::ReloadTime;
$ClipTime[Shocker]	= $PB::ReloadTime;
$ClipTime[Delta]	= $PB::SpawnReloadTime;
$ClipTime[MiniGun]	= "0.00";

//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling    IF - Cost Negitive buying 
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 

	// vvv Added for money vvv
	if ($Money::Enabled)
	{
		if (%cost > 0)
			Money::Inc(%client, Money, %cost * $Money::Price[Sell]);
		else
			Money::Inc(%client, Money, %cost);
	}
	else
	{
		if ($TeamEnergy[%team] != "Infinite") { 
			$TeamEnergy[%team] += %cost;    //Total TeamEnergy
 			%client.teamEnergy += %cost;   //Personal TeamEnergy
		}
	}
	// ^^^ Added for money
}

function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if (isPlayerBusy(%client))
		return;

	// only can buy fav every 1/2 second
	%time = getIntegerTime(true) >> 4; // int half seconds
	if(%time <= %client.lastBuyFavTime)
		return;

	%client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" ) {
		%stationName = GameBase::getDataName(%station); 

		// vvv Added for money vvv
		if ($Money::Enabled)
			%energy = Money::Get(%client, Money);
		else
			%energy = $TeamEnergy[Client::GetTeam(%client)];
		// ^^^ Added for money ^^^

		if(%energy == "Infinite" || %energy > 0) {
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) {
					%count = Player::getItemCount(%client,%item);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 20; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
						if(!buyItem(%client,%item))  
							%error = 1;
						else
							%bought++;
					}
				}
		  	}
			if(%bought) {
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}


function replenishTeamEnergy(%team)
{
	if (!$Money::Enabled)
		$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}


function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;

	if($TestCheats == 0 && %client.spawn == "") {

		// vvv Added for money vvv
		if ($Money::Enabled)
			%energy = Money::Get(%client, Money);
		else
			%energy = $TeamEnergy[%team];
		// ^^^ Added for money ^^^

		%station = %player.Station;
		%sName = GameBase::getDataName(%station);

		if(%energy != "Infinite") {
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price; 
			if(%delta < 1 ) {
				if(%noMessage == "")
				{
					// vvv Added for money vvv
					if ($Money::Enabled)
						Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - (Item costs $"@ %energy @ ")");
					else
						Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
					// ^^^ Added for money ^^^
				}
				return 0;
			}
		}
	}
	if(%item.className == Weapon) {
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) {
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item == RepairPatch) {
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
		return 0;
	}
	else if($TeamItemMax[%item] != "" && !$TestCheats) {
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) {
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className != Armor && %item.className != Vehicle) {
		%count = Player::getItemCount(%client,%item);
	  	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor) {
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					// vvv Added for money vvv
					if (%client.spawn == "")
						teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					// ^^^ Added for money ^^^ (The if statement)
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     					Player::setItemCount(%client, $ArmorName[%armor], 0);  
     					Player::setItemCount(%client, %item, 1);  
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				// vvv Added for money vvv
				if (%client.spawn == "")
					teamEnergyBuySell(%player,%item.price * -1);
				// ^^^ Added for money ^^^ (The if statement)
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);
				return 1;
			}
			else if(%pack != -1) {
				// vvv Added for money vvv
				if (%client.spawn == "")
					teamEnergyBuySell(%player,%item.price * -1);
				// ^^^ Added for money ^^^ (The if statement)
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);
			}
		}
		else if ((%item.className == Weapon) || (%item.className == Tool)) {
			if(checkResources(%player,%item,1)) {
				Player::incItemCount(%client,%item);

				// vvv Added for money vvv
				if (%client.spawn == "")
					teamEnergyBuySell(%player,%item.price * -1);
				// ^^^ Added for money ^^^ (The if statement)
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						// vvv Added for money vvv
						if (%client.spawn == "")
							teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						// ^^^ Added for money ^^^ (The if statement)
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				%ammoItem =  $Clip[%item]; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						// vvv Added for money vvv
						if (%client.spawn == "")
							teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						// ^^^ Added for money ^^^ (The if statement)
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
			return 0;
		}
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
				return 0;
			}
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats) {
				// vvv Added for money vvv
				if (%client.spawn == "")
					teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				// ^^^ Added for money ^^^ (The if statement)
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}

function armorChange(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "") {
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);	
	  	%newPosX = (getWord(%vec,0) * 1) + %posX;		 
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
	}
}

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	if(buyItem(%client,%item)) {
		if ($PB::Debug)
			echo(sprintf("%1 is buying %2 (%3)", %client, %type, %item));
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
		// vvv Added for money vvv
		if ($Money::Enabled)
			if ((%item.className == Weapon) || (%item.className == Tool) || (%item.className == Backpack))
			{
				Money::Set(%client, %item.className, %item);
				if ($PB::Debug)
					echo(sprintf("%1 bought a %2 (%3) and was added to spawn buy list", %client, %item, %item.className));
			}
		// ^^^ Added for money ^^^
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) {
		if(Player::getItemCount(%client,%item) && %item.className != Armor) {
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) {
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			if ($PB::Debug)
				echo(sprintf("%1 is sellin %2 (%3)", %client, %type, %item));
			// vvv Added for money vvv
			if ($Money::Enabled)
				if ((%item.className == Weapon) || (%item.className == Tool) || (%item.className == Backpack))
				{
					Money::Set(%client, %item.className, "");
					if ($PB::Debug)
						echo(sprintf("%1 sold a %2 (%3) and was added to spawn buy list", %client, %item, %item.className));
				}
			// ^^^ Added for money ^^^
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteUseItem(%client,%type)
{
	//echo("Use item: " @ %type @ " " @ %item);
	%client.throwStrength = 1;

	%item = getItemData(%type);
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo) {
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1) {
		if ($PB::Debug)
			echo("Drop item: ",%type);
		%client.throwStrength = 1;

		%item = getItemData(%type);
		if (%item == Backpack) {
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
	    else if (%item == Weapon) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) {
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else 
			Player::dropItem(%client,%item);

		if ($PB::Debug)
			echo(sprintf("%1 dropped item %2 (%3)", %client, %type, %item));

		// vvv Added for money vvv
		if ($Money::Enabled)
			Money::Set(%client, %item.className, "");
		// ^^^ Added for money ^^^
	}
}

function remoteDeployItem(%client,%type)
{
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//
$NextWeapon[Shocker] = Angel;
$NextWeapon[Angel] = Dragun;
$NextWeapon[Dragun] = AutoCocker;
$NextWeapon[AutoCocker] = Spyder;
$NextWeapon[Spyder] = TipmannS;
$NextWeapon[TipmannS] = Mongoose;
$NextWeapon[Mongoose] = Intimidator;
$NextWeapon[Intimidator] = Psycho;
$NextWeapon[Psycho] = Inferno;
$NextWeapon[Inferno] = Delta;
$NextWeapon[Delta] = Shocker;

$PrevWeapon[Angel] = Shocker;
$PrevWeapon[Dragun] = Angel;
$PrevWeapon[AutoCocker] = Dragun;
$PrevWeapon[Spyder] = AutoCocker;
$PrevWeapon[TipmannS] = Spyder;
$PrevWeapon[Mongoose] = TipmannS;
$PrevWeapon[Intimidator] = Mongoose;
$PrevWeapon[Psycho] = Intimidator;
$PrevWeapon[Inferno] = Psycho;
$PrevWeapon[Delta] = Inferno;
$PrevWeapon[Shocker] = Delta;

// I am going to try a new way of handling the weapons. Basically, I'm going to see
// if I can make a dynamic weapons list using getnumItems and so on (like how the
// inventory is populated) then use that to loop through valid weapons.  I mean you
// can only have two weapons, so there is no real need for an order. All you need
// really is some thing the scripts below can use.

function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) {
			if (isSelectableWeapon(%client,%weapon)) {
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $PrevWeapon[%item] == "")
		selectValidWeapon(%client);
	else {
		for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]) {
			if (isSelectableWeapon(%client,%weapon)) {
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}

function selectValidWeapon(%client)
{
	if ($PB::Debug)
		echo("Locating valid weapon...");
	%item = Shocker;
	for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) {
		if ($PB::Debug)
			echo("Trying " @ %weapon @ "...");
		if (isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			if ($PB::Debug)
				echo("Weapon found! exiting...");
			break;
		}
		if ($PB::Debug)
			echo("Bad weapon, finding next...");
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if (Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
}


//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack) {
			// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}
  		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;

			// Make sure it doesn't exceed carrying capacity
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
			if (%delta > 0) {
				Player::incItemCount(%player,%item,%delta);
				if (%count == 0 && $AutoUse[%item]) 
					Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
			}
		}
   }
	return 0;
}


//----------------------------------------------------------------------------
// Default Item object methods

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if (%sound != "")  
		playSound(%sound,GameBase::getPosition(%this));
	else {
		// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
	if (Item::isRotating(%this)) {
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else { 
		deleteObject(%this);
	}
}	

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%player = Player::GetClient(%object);
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			Item::respawn(%this);

			// vvv Added for money vvv
			%cl = GameBase::getOwnerClient(%this);
			if ($Money::Enabled)
				if ((%item.className == Weapon) || (%item.className == Tool) || (%item.className == Backpack))
				{
					Money::Set(%cl, %item.className, %item);
					if ($PB::Debug)
						echo(sprintf("%1 picked up a %2 (%3) and was added to spawn buy list", %cl, %item, %item.className));
				}
			// ^^^ Added for money ^^^
		}
	}
}


//----------------------------------------------------------------------------
// Default Inventory methods

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{
	//echo("Item used: ",%player," ",%item);
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if(%item.className != Armor) {
			if ($PB::Debug)
				echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else {
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);

			// vvv Added for money vvv
			%cl = GameBase::getOwnerClient(%this);
			if ($Money::Enabled)
				if ((%item.className == Weapon) || (%item.className == Tool) || (%item.className == Backpack))
				{
					Money::Set(%cl, %item.className, "");
					if ($PB::Debug)
						echo(sprintf("%1 dropped a %2 (%3) and was removed from spawn buy list", %cl, %item, %item.className));
				}
			// ^^^ Added for money ^^^

			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}

//----------------------------------------------------------------------------

ItemData Clip
{
	description = "Clip";
	showInventory = false;
};

function Clip::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		if(%count > 0) {
			%obj = newObject("","Item",%item,1,false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Clip::onUse(%player, %item)
{
	%client = Player::getclient(%player);
	%weapon = Player::getMountedItem(%player, $WeaponSlot);
	if($Clip[%weapon] != "")
		%clip = $Clip[%weapon];
	if(Player::getItemCount(%player,%clip) > 0)
		Clip::Reload(%player,%weapon,$ClipTime[%weapon]);
	else {
		if(%clip != "")
			bottomprint(%client, "<jc><f0> No Paintballs Left!", 2);
	}
}

function Clip::Reload(%player,%weapon,%RDPer)
{
	%client = Player::getClient(%player);
	$Reloading[%client] = 1;
	Player::unMountItem(%player, %weapon);
	bottomprint(%client, "<jc><f0>Inserting A New Cannister Of Paintballs", %RDPer);
	schedule("Player::setItemCount("@%player@"," @%weapon.imageType.ammoType@"," @$ClipSize[%weapon]@");",%RDPer/2);
	schedule("Clip::RemountWeapon("@%player@ "," @%weapon@ ");", %RDPer);
	Player::decItemCount(%player, $Clip[%weapon]);
	schedule("$Reloading["@%client@"] = 0;",%RDPer++);
}

// Fixed the mount bug
function Clip::RemountWeapon(%player, %weapon)
{
	if (Player::GetMountedItem(%player) == -1)
		Player::mountItem(%player, %weapon, $WeaponSlot);
}

//----------------------------------------------------------------------------
//-Clips
//----------------------------------------------------------------------------

ItemData PsychoClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData DeltaClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData ShockerClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData InfernoClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData AngelClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData IntimidatorClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData MongooseClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData AutoCockerClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData SpyderClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData DragunClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};

ItemData TipmannSClip
{
        description = "Extra Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 0;
	showInventory = false;
};


//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------

function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}


//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 }; // left-right back-front up-down
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 0;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = $PB::Validate;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1.0, 1.0, 1.0 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData LightArmor
{
   heading = "aArmor";
	description = "Light Armor";
	className = "Armor";
	price = 0;
	showInventory = false;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
	showInventory = false;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 675;
	showInventory = false;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
	showInventory = false;
};


//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	%client = Player::getclient(%player);
	if(%player.Station == "") {
		%ammo = %item.imageType.ammoType;
		Player::mountItem(%player,%item,$WeaponSlot);
		if(Player::getItemCount(%player,%ammo) < 0 && Player::getItemCount(%player,$Clip[%item]) < 0)
			bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
		if(Player::getItemCount(%player,%ammo) < 0 && Player::getItemCount(%player,$Clip[%item]) > 0)
			Player::useItem(%player,$Clip[%item]);
	}
}


//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onDrop(%player, %item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}



//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
   validateShape = $PB::Validate;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = $PB::Validate;
   validateMaterials = $PB::Validate;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("","Sensor",%shape,true);
 	        	   	addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = $PB::Validate;
   validateMaterials = $PB::Validate;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
   validateShape = $PB::Validate;
   validateMaterials = $PB::Validate;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = $PB::Validate;
   validateMaterials = $PB::Validate;
};

function Beacon::onUse(%player,%item)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   		Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
   validateShape = $PB::Validate;
   validateMaterials = $PB::Validate;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}


//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	messageAll(5, Client::GetName(%clientId) @ " tried using giveAll(); Laught at them!");
}

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
	// vvv Added for money vvv
	if (($TeamEnergy[%team] != "Infinite") && ($Money::Enabled)) {
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) {
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

function Mission::reinitData()
{
	for (%a = 0; %a < 8; %a++)
	{
		$TeamItemCount[%a @ ScoutVehicle] = 0;
		$TeamItemCount[%a @ LAPCVehicle] = 0;
		$TeamItemCount[%a @ HAPCVehicle] = 0;
	}

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
