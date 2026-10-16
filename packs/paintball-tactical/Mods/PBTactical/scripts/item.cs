//----------------------------------------------------------------------------

$ItemFavoritesKey = "PBTactical_XCal123";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

//================================
// Easy Way For Invetory Headings
//================================
$InvHead[ihArm] = "a•¤*Armor Suit*¤•";        
$InvHead[ihGun] = "b•¤*Paint Ball Guns*¤•";
$InvHead[ihFit] = "c•¤*Field Items*¤•";
$InvHead[ihCam] = "d•¤*Cammo Suits*¤•";
$InvHead[ihGad] = "e•¤*Player Addons*¤•";
$InvHead[ihPbs] = "f•¤*Paint Balls*¤•";

$ItemPopTime = 2;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
$ExtraSlot=4;
$ExtraSlot=5;
$ExtraSlot=6;
$ExtraSlot=7;

$AutoUse[Angel] = True;
$AutoUse[Delta] = True;
$AutoUse[Inferno] = True;
$AutoUse[Psycho] = True;
$AutoUse[Intimidator] = True;
$AutoUse[Mongoose] = True;
$AutoUse[SmartParts] = True;
$AutoUse[TipmannS] = True;
$AutoUse[Spyder] = True;
$AutoUse[AutoCocker] = True;
$AutoUse[Dragun] = True;
$AutoUse[M79] = True;
$AutoUse[Bunker] = True;
$AutoUse[AWPTShotgun] = True;
$AutoUse[WMAssault] = True;

$Use[Angel] = True;
$Use[Delta] = True;
$Use[Inferno] = True;
$Use[Psycho] = True;
$Use[Intimidator] = True;
$Use[Mongoose] = True;
$Use[SmartParts] = True;
$Use[TipmannS] = True;
$Use[Spyder] = True;
$Use[AutoCocker] = True;
$Use[Dragun] = True;
$Use[M79] = True;
$Use[Bunker] = True;
$Use[AWPTShotgun] = True;
$Use[WMAssault] = True;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Female, LightArmor] = lfemale;

$ArmorName[larmor] = LightArmor;
$ArmorName[lfemale] = LightArmor;

$Grenade[0] = 3;  //11
$Grenade[1] = OriginalGrenade;
$Grenade[2] = SmokerGrenade;
$Grenade[3] = FlareGrenade;


// Amount to remove when selling or dropping ammo

$SellAmmo[OriginalGrenade] = 4;
$SellAmmo[SmokerGrenade] = 2;
$SellAmmo[FlareGrenade] = 3;
$SellAmmo[AngelAmmo] = 250;
$SellAmmo[DragunAmmo] = 250;
$SellAmmo[AutoCockerAmmo] = 250;
$SellAmmo[SpyderAmmo] = 250;
$SellAmmo[TipmannSAmmo] = 250;
$SellAmmo[SmartPartsAmmo] = 250;
$SellAmmo[MongooseAmmo] = 250;
$SellAmmo[IntimidatorAmmo] = 250;
$SellAmmo[PsychoAmmo] = 250;
$SellAmmo[InfernoAmmo] = 250;
$SellAmmo[WMAssaultAmmo] = 250;
$SellAmmo[DeltaAmmo] = 250;
$SellAmmo[M79Ammo] = 10;
$SellAmmo[BunkerAmmo] = 6;
$SellAmmo[AWPTShotgunAmmo] = 24;
$SellAmmo[mineammo] = 1;




// Limit on number of special Items you can buy
//$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[mineammo] = 35;

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

$WeaponAmmo[Angel] = AngelAmmo;
$WeaponAmmo[Dragun] = DragunAmmo;
$WeaponAmmo[AutoCocker] = AutoCockerAmmo;
$WeaponAmmo[Spyder] = SpyderAmmo;
$WeaponAmmo[TipmannS] = TipmannSAmmo;
$WeaponAmmo[SmartParts] = SmartPartsAmmo;
$WeaponAmmo[Mongoose] = MongooseAmmo;
$WeaponAmmo[Intimidator] = IntimidatorAmmo;
$WeaponAmmo[Psycho] = PsychoAmmo;
$WeaponAmmo[Inferno] = InfernoAmmo;
$WeaponAmmo[Delta] = DeltaAmmo;
$WeaponAmmo[M79] = M79Ammo;
$WeaponAmmo[Bunker] = BunkerAmmo;
$WeaponAmmo[AWPTShotgun] = AWPTShotgunAmmo;
$WeaponAmmo[WMAssault] = WMAssaultAmmo;

$Clip[Angel] = "AngelClip";
$Clip[AutoCocker] = "AutoCockerClip";
$Clip[Spyder] = "SpyderClip";
$Clip[Dragun] = "DragunClip";
$Clip[TipmannS] = "TipmannSClip";
$Clip[SmartParts] = "SmartPartsClip";
$Clip[Mongoose] = "MongooseClip";
$Clip[Intimidator] = "IntimidatorClip";
$Clip[Psycho] = "PsychoClip";
$Clip[Inferno] = "InfernoClip";
$Clip[WMAssault] = "WMAssaultClip";
$Clip[Delta] = "DeltaClip";

//>-Defines the Magazine's size
$ClipSize[Angel] = "250";
$ClipSize[AutoCocker] = "250";
$ClipSize[Spyder] = "250";
$ClipSize[Dragun] = "250";
$ClipSize[TipmannS] = "250";
$ClipSize[Mongoose] = "250";
$ClipSize[SmartParts] = "250";
$ClipSize[Intimidator] = "250";
$ClipSize[WMAssault] = "250";
$ClipSize[Psycho] = "250";
$ClipSize[Inferno] = "250";
$ClipSize[Delta] = "250";

//>-Defines how long the gun takes to switch magazines 
$ClipTime[Angel] = "3.03";
$ClipTime[AutoCocker] = "3.03";
$ClipTime[Spyder] = "3.03";
$ClipTime[Dragun] = "3.03";
$ClipTime[TipmannS] = "3.03";
$ClipTime[Mongoose] = "3.03";
$ClipTime[SmartParts] = "3.03";
$ClipTime[Intimidator] = "3.03";
$ClipTime[Psycho] = "3.03";
$ClipTime[Inferno] = "3.0";
$ClipTime[WMAssault] = "2.03";
$ClipTime[Delta] = "0.5";

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
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
		%station.Energy += %cost;			//Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost;    //Total TeamEnergy
 		%client.teamEnergy += %cost;   //Personal TeamEnergy
	}
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
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
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
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}


function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	if($TestCheats == 0 && %client.spawn == "") {
		%energy = $TeamEnergy[%team];
    	%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation){
			%energy = %station.Energy;
		}
		if(%energy != "Infinite") {
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price; 
			if(%delta < 1 ) {
				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
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

function ResetGrenades(%client) 
{
	Player::setItemCount(%client,Grenade,0);
	Player::setItemCount(%client,OriginalGrenade,0);
	Player::setItemCount(%client,SmokerGrenade,0);

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
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
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
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) {
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						remoteSellItem(%client,22);						
					}
				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
	%ammoItem =  $Clip[%item]; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else if(%item.className == Grenade)
		{
			
			ResetGrenades(%client); 
			if(checkResources(%player,%item,1))
			{
				for(%i = 1; %i <= $Grenade[0]; %i++)
				{
					%g = $Grenade[%i];
					if(%item == %g) {}
					else
					{
						teamEnergyBuySell(%player,%g.price * Player::getItemCount(%player, %g));
						Player::setItemCount(%player, %g, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
			//	if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
			//		%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Grenade, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}
		}
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
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
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
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
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item.className == Grenade)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, Grenade, %numsell);
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
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
	%item = getItemData(%type);
	//echo("Throw item: " @ %item @ " of type " @ %type @ " Strength: " @ %strength);
	if (%item.className == "Grenade" || %item.className == "HandAmmo" || %item.className == "Mine")
	{
		if (%strength < 0)
			%strength = 0;
		else
			if (%strength > 100)
				%strength = 100;
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%client,%item);
	}
}

function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1) {
		//echo("Drop item: ",%type);
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
	}
}

function remoteDeployItem(%client,%type)
{
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}


$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = Angel;
$NextWeapon[Angel] = Dragun;
$NextWeapon[Dragun] = AutoCocker;
$NextWeapon[AutoCocker] = Spyder;
$NextWeapon[Spyder] = TipmannS;
$NextWeapon[TipmannS] = Mongoose;
$NextWeapon[Mongoose] = Intimidator;
$NextWeapon[Intimidator] = Psycho;
$NextWeapon[Psycho] = Inferno;
$NextWeapon[Inferno] = Delta;
$NextWeapon[Delta] = M79;
$NextWeapon[M79] = Bunker;
$NextWeapon[Bunker] = AWPTShotgun;
$NextWeapon[AWPTShotgun] = SmartParts;
$NextWeapon[SmartParts] = WMAssault;
$NextWeapon[WMAssault] = EnergyRifle;

$PrevWeapon[EnergyRifle] = Blaster;
$PrevWeapon[Blaster] = PlasmaGun;
$PrevWeapon[PlasmaGun] = Chaingun;
$PrevWeapon[Chaingun] = DiscLauncher;
$PrevWeapon[DiscLauncher] = GrenadeLauncher;
$PrevWeapon[GrenadeLauncher] = Mortar;
$PrevWeapon[Mortar] = LaserRifle;
$PrevWeapon[LaserRifle] = Angel;
$PrevWeapon[Angel] = Dragun;
$PrevWeapon[Dragun] = AutoCocker;
$PrevWeapon[AutoCocker] = Spyder;
$PrevWeapon[Spyder] = TipmannS;
$PrevWeapon[TipmannS] = Mongoose;
$PrevWeapon[Mongoose] = Intimidator;
$PrevWeapon[Intimidator] = Psycho;
$PrevWeapon[Psycho] = Inferno;
$PrevWeapon[Inferno] = Delta;
$PrevWeapon[Delta] = M79;
$PrevWeapon[M79] = Bunker;
$PrevWeapon[Bunker] = AWPTShotgun;
$PrevWeapon[AWPTShotgun] = SmartParts;
$PrevWeapon[SmartParts] = WMAssault;
$PrevWeapon[WMAssault] = EnergyRifle;

function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else {
		for (%weapon = $NextWeapon[%item]; %weapon != %item;
				%weapon = $NextWeapon[%weapon]) {
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
		for (%weapon = $PrevWeapon[%item]; %weapon != %item;
				%weapon = $PrevWeapon[%weapon]) {
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
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;
			%weapon = $NextWeapon[%weapon]) {
		if (isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			break;
		}
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
		else if(%item.className == Grenade)
		{
			if(Player::getItemCount(%player, Grenade) == Player::getItemCount(%player, %item))
			{
				%count = Player::getItemCount(%player, %item);
				%total = $ItemMax[%armor, %item];
				%extra = %total - %count;
				if(%delta > %extra)
					%delta = %extra;
				if(%delta > 0)
				{
					Player::incItemCount(%player, %item, %delta);
					Player::incItemCount(%player, Grenade, %delta);
					Client::sendMessage(%client, 0, "You received " @ %delta @ " " @ %item.description);
					return %delta;
				}
			}
		}
  		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
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
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
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
	if($matchStarted)
	{
		if(%item.className != Armor)
		{
			//echo("Item dropped: ",%player," ",%item);
			%client = Player::getClient(%player);
			if(%item.className == Grenade)
			{
				%amount = $SellAmmo[%item];
				if (%amount > Player::getItemCount(%player, %item))
					%amount = Player::getItemCount(%player, %item);
				Player::decItemCount(%client, Grenade, %amount);
				Player::decItemCount(%client, %item, %amount);
			}
			else if(%item.className == Mine)
			{
				%amount = $SellAmmo[%item];
				if (%amount > Player::getItemCount(%player, %item))
					%amount = Player::getItemCount(%player, %item);
				Player::decItemCount(%client, mineammo, %amount);
				Player::decItemCount(%client, %item, %amount);
			}
			else if(%item.className == Beacon)
			{
				%amount = $SellAmmo[%item];
				if (%amount > Player::getItemCount(%player, %item))
					%amount = Player::getItemCount(%player, %item);
				Player::decItemCount(%client, Beacon, %amount);
				Player::decItemCount(%client, %item, %amount);
			}
			else
			{
				Player::decItemCount(%player,%item,1);
				%amount = 1;
			}
			%obj = newObject("","Item",%item,%amount,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else
			{
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
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
		Reload(%player,%weapon,$ClipTime[%weapon]);
	else {
		if(%clip != "")
			bottomprint(%client, "<jc><f0> No Paintballs Left!", 2);
	}
}

function Reload(%player,%weapon,%RDPer)
{
	%client = Player::getClient(%player);
	$Reloading[%client] = 1;
	Player::unMountItem(%player, %weapon);
	if($ClipSound == 1) {
		schedule("GameBase::playSound("@%player@",SoundPickupHealth,"@0@");",%RDPer*2/3,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupHealth,"@0@");",%RDPer*1/3,%player);
	}
	else if($ClipSound == 2) {
		schedule("GameBase::playSound("@%player@",SoundPDAButtonSoft,"@0@");",%RDPer/3,%player);
		schedule("GameBase::playSound("@%player@",SoundButton3,"@0@");",%RDPer/3+0.1,%player);
		schedule("GameBase::playSound("@%player@",SoundButton4,"@0@");",%RDPer/3+0.2,%player);
		schedule("GameBase::playSound("@%player@",SoundButton5,"@0@");",%RDPer/3+0.3,%player);
		schedule("GameBase::playSound("@%player@",SoundWeaponSelect,"@0@");",%RDPer/3+0.4,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupAmmo,"@0@");",%RDPer*2/3-0.1,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupBackpack,"@0@");",%RDPer*2/3,%player);
		schedule("GameBase::playSound("@%player@",SoundWeaponSelect,"@0@");",%RDPer*2/3+0.1,%player);
	}
	else if($ClipSound == 3) {
		schedule("GameBase::playSound("@%player@",SoundWeaponSelect,"@0@");",%RDPer/3,%player);
		schedule("GameBase::playSound("@%player@",SoundButton5,"@0@");",%RDPer/3+0.1,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupAmmo,"@0@");",%RDPer/2,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupWeapon,"@0@");",%RDPer/2+0.5,%player);
	}	
	bottomprint(%client, "<jc><f0>Inserting A New Cannister Of Paintballs", %RDPer);
	schedule("Player::setAnimation("@%player@"," @21@");", %RDPer-1.13);
	schedule("Player::setItemCount("@%player@"," @%weapon.imageType.ammoType@"," @$ClipSize[%weapon]@");",%RDPer/2);
	schedule("Player::MountItem("@%player@ "," @%weapon@ "," @$WeaponSlot@ ");", %RDPer);
	Player::decItemCount(%player, $Clip[%weapon]);
	schedule("$Reloading["@%client@"] = 0;",%RDPer++);
}

//----------------------------------------------------------------------------
//-Clips
//----------------------------------------------------------------------------

ItemData PsychoClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

ItemData DeltaClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

ItemData InfernoClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

ItemData AngelClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

ItemData IntimidatorClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

ItemData MongooseClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

ItemData AutoCockerClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 10;
};

ItemData SpyderClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
       heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 10;
};

ItemData DragunClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 10;
};

ItemData TipmannSClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 10;
};

ItemData SmartPartsClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 10;
};

ItemData WMAssaultClip
{
        description = "Paintballs";
        className = "Clip";
        shapeFile = "ammo2";
        heading = $InvHead[ihPbs];
        shadowdetailmask = 4;
        price = 30;
};

//---------------
// Old Base datablocks stripped

ItemData Blaster
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData Chaingun
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData Plasmagun
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData DiscLauncher
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData GrenadeLauncher
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData Mortar
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData LaserRifle
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
};

ItemData EnergyRifle
{
	showInventory = false;
	description = "Old";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "weapon";
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
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
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
   validateShape = true;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
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
   heading = $InvHead[ihArm];
	description = "Player Suit";
	className = "Armor";
	price = 175;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------




//----------------------------------------------------------------------------
// Tools, Weapons , ammo And IX crap
//----------------------------------------------------------------------------
function ixDotProd(%vec, %scalar) 
{ %return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar); return %return; } 

function ixSin(%theta) 
{ return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800)); }  

function ixCos(%theta) 
{ return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800)); } 

function ixApplyKickback(%player, %strength, %lift) 
{ if((!%lift) && (%lift != 0)) %lift = 0; %rot = GameBase::getRotation(%player); %rad = getWord(%rot, 2); %x = (-1) * (ixSin(%rad)); %y = ixCos(%rad); %dir = %x @ " " @ %y @ " 0"; %force = ixDotProd(Vector::neg(%dir),%strength); %x = getWord(%force, 0); %y = getWord(%force, 1); %dir = %x @ " " @ %y @ " " @ %lift; Player::applyImpulse(%player,%force); } 

function GiveKickback(%player, %strength, %lift)
{	
	if((!%lift) && (%lift != 0)) %lift = 0;
	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (Sin(%rad));
	%y = Cos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force=NewVector(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%force = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}





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
//=========================

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

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
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = $InvHead[ihFit];
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------




//----------------------------------------------------------------------------

ItemData Grenade
{
	showInventory = false;
	description = "Grenade";
	shapeFile = "grenade";
//	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
};

ItemData OriginalGrenade
{
	description = "Paint Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData SmokerGrenade
{
	description = "Smoke Bomb";
	shapeFile = "grenade";
	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData FlareGrenade
{
	description = "Flash Bang";
	shapeFile = "grenade";
	heading = $InvHead[ihFit];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

function Grenade::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			if(Player::getItemCount(%player, OriginalGrenade) > 0)
			{
				%item = OriginalGrenade;
				%name = "Handgrenade";
				%chuckmod = 0.5;
			}
			else if(Player::getItemCount(%player, FlareGrenade) > 0)
			{
				%item = FlareGrenade;
				%name = "Flashgrenade";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, SmokerGrenade) > 0)
			{
				%item = SmokerGrenade;
				%name = "Smoker";
				%chuckmod = 0.2;
			}
			else
				return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%armor = Player::getArmor(%player);
			%obj = newObject("","Mine",%name);
 	 	 	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,9 * %clientId.throwStrength * %chuckmod,false);
			GameBase::throw(%obj,%player,10,false);

			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


ItemData mineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvHead[ihFit];
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function mineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			gamebase::setTeam(%obj, gamebase::getTeam(%client));
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = $InvHead[ihFit];
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
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
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = $InvHead[ihFit];
	shadowDetailMask = 4;
  	price = 2;
   validateShape = true;
   validateMaterials = true;
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
	if ($TestCheats) {
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
		Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

      Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
      Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
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

function Mission::reinitData()
{
	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;


	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;


	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;


	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;


	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;


	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;


	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;


	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;


	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}