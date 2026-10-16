//----------------------------------------------------------------------------

$ItemFavoritesKey = "shifter1";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;


$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorType[Male, ScoutArmor] = sarmor;

$ArmorType[Male, BursterArmor] = barmor;

$ArmorType[Male, EngArmor] = earmor;

$ArmorType[Male, DragArmor] = darmor;

$ArmorType[Female, ScoutArmor] = sfemale;

$ArmorType[Female, BursterArmor] = bfemale;	   

$ArmorType[Female, EngArmor] = earmor;

$ArmorType[Female, DragArmor] = darmor;

$ArmorType[Male, SpArmor] = spyarmor;
$ArmorType[Female, SpArmor] = spyfemale;
$ArmorType[Male, AlArmor] = aarmor;
$ArmorType[Female, AlArmor] = afemale;
$ArmorType[Male, Juggernaught] = jarmor;
$ArmorType[Female, Juggernaught] = jarmor;

$ArmorName[sarmor] = ScoutArmor;
$ArmorName[barmor] = BursterArmor;
$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;
$ArmorName[darmor] = DragArmor;
$ArmorName[sfemale] = ScoutArmor;
$ArmorName[bfemale] = BursterArmor;
$ArmorName[spyarmor] = SpArmor;
$ArmorName[spyfemale] = SpArmor;
$ArmorName[aarmor] = AlArmor;
$ArmorName[afemale] = AlArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[jarmor] = Juggernaught;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[Boost] = 5;
$SellAmmo[Plastique] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[BoomAmmo] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 5;
$AmmoPackMax[Beacon] = 3;
$AmmoPackMax[BoomAmmo] = 15;


// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackIteas[8] = BoomAmmo;

$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
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

$Use[Blaster] = True;
$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[Fixit] = False;
$AutoUse[ChargeGun] = True;
$AutoUse[CloakGun] = False;
$AutoUse[RocketLauncher] = True;
$AutoUse[BoomStick] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[ConCun] = True;
$AutoUse[Railgun] = True;
$AutoUse[Mfgl] = True;
$AutoUse[Vulcan] = True;
$AutoUse[Silencer] = True;
$AutoUse[IonGun] = True;
$AutoUse[TranqGun] = True;
$AutoUse[HyperB] = True;
$AutoUse[Omega] = True;

$SellAmmo[RocketAmmo] = 3;
$SellAmmo[SniperAmmo] = 15;
$SellAmmo[RailAmmo] = 25;
$SellAmmo[SilencerAmmo] = 25;
$SellAmmo[VulcanAmmo] = 100;
$SellAmmo[MfglAmmo] = 1;
$SellAmmo[TranqAmmo] = 2;
$SellAmmo[AutoRocketAmmo] = 5;

$AmmoPackMax[AutoRocketAmmo] = 15;
$AmmoPackMax[RocketAmmo] = 10;
$AmmoPackMax[SniperAmmo] = 15;
$AmmoPackMax[RailAmmo] = 5;
$AmmoPackMax[VulcanAmmo] = 100;
$AmmoPackMax[MfglAmmo] = 2;
$AmmoPackMax[TranqAmmo] = 20;

$AmmoPackItems[8] = RocketAmmo;
$AmmoPackItems[9] = SniperAmmo;
$AmmoPackItems[10] = RailAmmo;
$AmmoPackItems[11] = VulcanAmmo;
$AmmoPackItems[12] = MfglAmmo;
$AmmoPackItems[13] = TranqAmmo;
$AmmoPackItems[14] = Plastique;
$AmmoPackItems[15] = Boost;

//=========================================================================== Limit on number of special Items you can buy

$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 5;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[LaunchPack] = 15;
$TeamItemMax[Mfgl] = 2;
$TeamItemMax[PlasmaTurretPack] = 4;
$TeamItemMax[RocketPack] = 3;
$TeamItemMax[DeployableComPack] = 5;
$TeamItemMax[ForceFieldPack] = 10;
$TeamItemMax[LargeForceFieldPack] = 4;
$TeamItemMax[LaserPack] = 4;
$TeamItemMax[BlastWallPack] = 5;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[PlatformPack] = 25;
$TeamItemMax[TreePack] = 25;
$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[JetVehicle] = 5;
$TeamItemMax[PlantPack] = 3;
$TeamItemMax[hologram] = 15;
$TeamItemMax[SatchelPack] = 25;
$TeamItemMax[ShockPack] = 4;
$TeamItemMax[TargetPack] = 2;
$TeamItemMax[DeployableElf] = 5;
$TeamItemMax[ProxMine] = 8;

//=========================================================================== Weapons And Ammo

$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[GravGun] = "";
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[ConCun] = ""; 
$WeaponAmmo[IonGun] = ""; 
$WeaponAmmo[Flamer] = ""; 
$WeaponAmmo[Omega] = "";
$WeaponAmmo[Silencer] = SilencerAmmo;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$WeaponAmmo[Mfgl] = MfglAmmo;
$WeaponAmmo[TranqGun] = TranqAmmo;
$WeaponAmmo[SMRPack] = AutoRocketAmmo;
$WeaponAmmo[SMRPack2] = AutoRocketAmmo;
$WeaponAmmo[BoomStick] = BoomAmmo;
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


function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
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


//==========================================================================================================Check Max Drop from Bitchin1.3
function checkMaxDrop(%client,%armor) 
{
 	%weaponflag = 0;
 	%numweapon = Player::getItemClassCount(%client,"Weapon");
 
	if (%numweapon > $MaxWeapons[%armor]) 
	{
		%weaponflag = %numweapon - $MaxWeapons[%armor];
	}

	%max = getNumItems();
	for (%i = 0; %i < %max;	%i = %i + 1) 
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "")
		{
		 	%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
			{
				 %numsell = %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
			 	%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0)
			{
			 	Player::setItemCount(%client, %item, %count - %numsell);
			}
		}
	}
}

//======================================================================================================= Armor Change Drop from Bitchin1.3


function armorChange(%client) 
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "")
	{
		%sPos = GameBase::getPosition(%player.Station);
		%pPos = GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);
		%newPosX = (getWord(%vec,0) * 1) + %posX;
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
	}
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

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		
//================================================================================================= Assign armor by requested type & gender 
		if (%item.className == Armor) {

			%buyarmor = $ArmorType[Client::getGender(%client), %item];

			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);

				if(checkResources(%player,%item,1))
				{
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					
					Player::setArmor(%client,%buyarmor);					
					checkMax(%client,%buyarmor);
					armorChange(%client);
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  

						if (%buyarmor == "jarmor") //================================================== Check Juggernaught   
						{
							echo("Purchased Juggernaught");
							checkMaxDrop(%client,%armor);
							
							//========================================================= Set Weapons
							Player::setItemCount(%client, RocketLauncher, 1);
							Player::setItemCount(%client, SMRPack2,1);
							Player::setItemCount(%client, Mortar,1);
							Player::setItemCount(%client, Mfgl,1);
							Player::setItemCount(%client, GrenadeLauncher,1);
							Player::setItemCount(%client, Vulcan,1);
							

							//========================================================= Set Ammo
							Player::setItemCount(%client, RocketAmmo,25);
							Player::setItemCount(%client, AutoRocketAmmo,20);
							Player::setItemCount(%client, MortarAmmo,20);
							Player::setItemCount(%client, MfglAmmo,3);
							Player::setItemCount(%client, GrenadeAmmo,30);
							Player::setItemCount(%client, VulcanAmmo,900);
							

							//========================================================= Mount Items
							Player::mountItem(%client, RocketLauncher, $WeaponSlot);
							Player::mountItem(%client, SMRPack2, $BackPackSlot);
						}
					
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
					
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
//======================================================================================================= Finish Armor Buy
		else if (%item.className == Backpack) {
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


//========================================================================================================== AutoBuy Energy Pack for Laser
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}

//========================================================================================================== AutoBuy Containment Pack
				if(%item == Mfgl && Player::getItemCount(%client,"FgcPack") == 0) {
					buyItem(%client,"FgcPack");
					Client::sendMessage(%client,0,"Bought Tactical Nuke - Auto buying Containment Pack");
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
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
			%shouldBuy = VehicleStation::checkBuying(%client,%item);
			if(%shouldBuy == 1) {
				teamEnergyBuySell(%player,(%item.price * -1));
				return 1;
			}			
 			else if(%shouldBuy == 2)
				return 1;
		}
		else {
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
	if(%client.respawn == "" && %player.Station != "")
	{
		%sPos = GameBase::getPosition(%player.Station);
		%pPos = GameBase::getPosition(%client);
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
			else if(%item == EnergyPack) { 
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,22);						
				}
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
	//echo("Throw item: " @ %type @ " " @ %strength);
	%item = getItemData(%type);
	if (%item == Grenade || %item == MineAmmo)
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
	if((Client::getOwnedObject(%client)).driver != 1) 
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

//
$NextWeapon[BoomStick] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = RocketLauncher;
$NextWeapon[RocketLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = ConCun;
$NextWeapon[ConCun] = EnergyRifle;
$NextWeapon[EnergyRifle] = Railgun;
$NextWeapon[Railgun] = Mfgl;
$NextWeapon[Mfgl] = Silencer;
$NextWeapon[Silencer] = Vulcan;
$NextWeapon[Vulcan] = IonGun;
$NextWeapon[IonGun] = Flamer;
$NextWeapon[Flamer] = TranqGun;
$NextWeapon[TranqGun] = HyperB;
$NextWeapon[HyperB] = Omega;
$NextWeapon[Omega] = FixIt;
$NextWeapon[FixIt] = Hackit;
$NextWeapon[Hackit] = DisIt;
$NextWeapon[DisIt] = GravGun;
$NextWeapon[GravGun] = BoomStick;

$PrevWeapon[Blaster] = BoomStick;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[RocketLauncher] = LaserRifle;
$PrevWeapon[SniperRifle] = RocketLauncher;
$PrevWeapon[ConCun] = SniperRifle;
$PrevWeapon[EnergyRifle] = ConCun;
$PrevWeapon[Railgun] = EnergyRifle;
$PrevWeapon[Mfgl] = Railgun;
$PrevWeapon[Silencer] = Mfgl;
$PrevWeapon[Vulcan] = Silencer;
$PrevWeapon[Flamer] = Vulcan;
$PrevWeapon[IonGun] = Flamer;
$PrevWeapon[TranqGun] = IonGun;
$PrevWeapon[HyperB] = TranqGun;
$PrevWeapon[Omega] = HyperB;
$PrevWeapon[DisIt] = Omega;
$PrevWeapon[HackIt] = DisIt;
$PrevWeapon[FixIt] = HackIt;
$PrevWeapon[GravGun] = FixIt;
$PrevWeapon[BoomStick] = GravGun;

function remoteNextWeapon(%client)
{
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
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
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
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
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

	echo ("ITEM = " @ %item);
	if($matchStarted)
	{
		if(%item.className != Armor)
		{
			%obj = newObject("","Item",%item,1,false);			
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);			
 	 	 	addToSet("MissionCleanup", %obj);

			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else
			{
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}


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
	mapIcon = "M_camera";

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

ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Scout";
	className = "Armor";
	price = 175;
};

ItemData SpArmor
{
   heading = "aArmor";
	description = "Chemeleon";
	className = "Armor";
	price = 175;
};

ItemData LightArmor
{
   heading = "aArmor";
	description = "Assassin";
	className = "Armor";
	price = 175;
};


ItemData MediumArmor
{
   heading = "aArmor";
	description = "Mercenary";
	className = "Armor";
	price = 250;
};

ItemData BursterArmor
{
   heading = "aArmor";
	description = "Goliath";
	className = "Armor";
	price = 250;
};

ItemData EngArmor
{
   heading = "aArmor";
	description = "Engineer";
	className = "Armor";
	price = 250;
};

ItemData AlArmor
{
   heading = "aArmor";
	description = "Arbitor";
	className = "Armor";
	price = 250;
};

ItemData DragArmor
{
   heading = "aArmor";
	description = "DreadNaught";
	className = "Armor";
	price = 400;
};

ItemData Juggernaught
{
   heading = "aArmor";
	description = "Juggernaught";
	className = "Armor";
	price = 2500;
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
};

ItemData WraithVehicle
{
	description = "Wraith";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};

ItemData JetVehicle
{
	description = "Interceptor";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};



ItemData LAPCVehicle
{
	description = "BomberLPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "StealthHPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};


//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onUse(%player,%item)
{
	%ammo = %item.imageType.ammoType;
	if (%ammo == "") {
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else {
		if (Player::getItemCount(%player,%ammo) > 0) 
			Player::mountItem(%player,%item,$WeaponSlot);
		else {
			Client::sendMessage(Player::getClient(%player),0,
			strcat(%item.description," has no ammo"));
		}
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
	if($matchStarted)
	{
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta)
		{
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0)
		{
			%obj = newObject("","Item",%item,%delta,false);
      			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

		      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	

//======================================================================== Base Blaster

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.250;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

//======================================================================== Chain Gun

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.2;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function Chaingun::verifyTarget(%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}


//======================================================================== Plasma Gun

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = "PlasmaAmmo";
	projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};


function PlasmaGunImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);


			if (%playerId.Plasma == 0)
			{
				Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
			}
			else if (%playerId.Plasma == 1)
			{
				Projectile::spawnProjectile("PlasmaBoltRapid",%trans,%player,%vel);
				Projectile::spawnProjectile("PlasmaBoltRapid2",%trans,%player,%vel);
			}
			else if (%playerId.Plasma == 2)
			{
				Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
				Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,(%vel + 25));
				Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,(%vel - 25));
			}
		}	//=== End standard plasma fire.
}


ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};


//======================================================================== Grenade Launcher


ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};


//======================================================================== Mortar 


ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function MortarImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.Mortar == 0)
			{
				Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
			}
			else if (%playerId.Mortar == 1)
			{
				Projectile::spawnProjectile("EMPMortar",%trans,%player,%vel);
			}
			else if (%playerId.Mortar == 2)
			{
				Projectile::spawnProjectile("BomberShell",%trans,%player,%vel);
			}
		}	//=== End standard mortar fire.
}

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
};

//======================================================================== Disc Launcher


ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//======================================================================== Laser Rifle


ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle."); 
}

//======================================================================== ELF GUN

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
	

   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 500;
};

//======================================================================== Repair Gun

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
	price = 125;
	showInventory = true;

};

function RepairGun::onMount(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if (%armor != "earmor" && %armor != "efemale")	
		Player::trigger(%player,$BackpackSlot,true);

}

function RepairGun::onUnmount(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);

	if (%armor != "earmor" && %armor != "efemale")	
		Player::trigger(%player,$BackpackSlot,false);

}


//======================================================================== HyperBlaster


ItemImageData HyperBImage
{
   shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = HyperBolt;
	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB
{
   heading = "bWeapons";
	description = "Hyper Blaster";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HyperBImage;
	price = 285;
	showWeaponBar = true;
};

//======================================================================== Rocket Launcher

ItemData RocketAmmo 
{
	description = "RocketAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = RocketAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 1.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
	} //=== End standard missile fire.


ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};

function Tracker(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has a Missile Lock!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 


//======================================================================== Projectile - Sniper Rifle

ItemData SniperAmmo
{
	description = "Sniper Bullet";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SniperAmmo;
	//projectileType = SniperBullet;
	projectileType = SniperRound;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFireChainGun;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData SniperRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
  heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 375;
	showWeaponBar = true;
};
//======================================================================== Boom Stick
ItemData BoomAmmo
{
	description = "Boom Shell";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData BoomStickImage
{
	shapeFile = "shotgun";
    mountPoint = 0;

	ammoType = BoomAmmo;
	projectileType = "Undefined";
	weaponType = 0; // Single Shot
	reloadTime = 0.5;
	fireTime = 1.1;
	minEnergy = 5;
	maxEnergy = 6;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireMortar;
	sfxReload   = SoundMortarReload;
   
};

ItemData BoomStick
{
    description = "Boom Stick";
	shapeFile = "shotgun";
	hudIcon = "blaster";
    className = "Weapon";
    heading = "bWeapons";
    shadowDetailMask = 4;
    imageType = BoomStickImage;
	showWeaponBar = true;
    price = 500;
};


function BoomStickImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[BoomStick]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[BoomStick],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);			
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}


//======================================================================== Poison Dart Gun

ItemData TranqAmmo
{
	description = "Poison Dart";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TranqGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = TranqAmmo;
	projectileType = TranqDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFireChainGun;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData TranqGun
{
	description = "Dart Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
  heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TranqGunImage;
	price = 475;
	showWeaponBar = true;
};

//======================================================================== Magnum - Silencer

ItemData SilencerAmmo
{
	description = "Magnum Bullets";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SilencerImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SilencerAmmo;
	projectileType = SilencerBullet;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData Silencer
{
	description = "Magnum";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "targetlaser";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SilencerImage;
	price = 375;
	showWeaponBar = true;
};


 
//======================================================================== ConCusion Gun - Shockwave Cannon


ItemImageData ConCunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; 
    minEnergy = 40;
	maxEnergy = 45;
      

	projectileType = Shock;
	accuFire = true;
	
	fireTime = 0.9;
	
    
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData ConCun
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
 	hudIcon = "disk";
      heading = "bWeapons";
 	shadowDetailMask = 4;
	imageType = ConCunImage;
	price = 250;
	showWeaponBar = true;
};


//======================================================================== Rail Gun

ItemData RailAmmo
{
	description = "Railgun Bolt";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RailgunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RailAmmo;
	projectileType = RailRound;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;

	
};

ItemData Railgun
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

//======================================================================== Vulcan - AutoCanaon

ItemData VulcanAmmo
{
	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VulcanImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.1;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0;

	ammoType = VulcanAmmo;
	projectileType = VulcanBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan
{
	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

//======================================================================== Nuke Launcher and Pack

ItemData MfglAmmo
{
	description = "Nuclear Warhead";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 500;
};

ItemImageData MfglImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MfglAmmo;
	projectileType = FgcShell;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 4.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mfgl
{
	description = "Tactical Nuke";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MfglImage;
	price = 3500;
	showWeaponBar = true;
};

function Mfgl::onUse(%player,%item)
{
	%armor = Player::getArmor(%player);
		if((Player::getMountedItem(%player,$BackpackSlot) == FgcPack) || (%armor == "jarmor"))
		{
			Weapon::onUse(%player,%item);
		}
		else
			Client::sendMessage(Player::getClient(%player),0,"Must have the Containment Pack to use the Tactical Nuke."); 
	
}


//======================================================================== Flamer

ItemImageData FlamerImage
{
  shapeFile  = "GrenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	minEnergy = 6;
	maxEnergy = 6;

	projectileType = FlamerBolt;
	accuFire = true;

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Flamer
{
    heading = "bWeapons";
	description = "Flame Thrower";
	className = "Weapon";
    shapeFile  = "GrenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 385;
	showWeaponBar = true;
};

//======================================================================== Ion Canon

ItemImageData IonGunImage
{
   shapeFile  = "GrenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 0.2;
	minEnergy = 40;
	maxEnergy = 30;

	projectileType = IonBolt;
	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};


ItemData IonGun
{
    heading = "bWeapons";
	description = "Ion Rifle";
	className = "Weapon";
    shapeFile  = "GrenadeL";
	hudIcon = "targetlaser";
	shadowDetailMask = 4;
	imageType = IonGunImage;
	price = 250;
	showWeaponBar = true;
};




//======================================================================== Volter

ItemImageData OmegaImage
{
  shapeFile  = "shotgun";

	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = Flameburst;
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };
	 sfxFire = SoundFlyerActive;
	 sfxActivate = SoundPickUpWeapon;
};

ItemData Omega
{
	heading = "bWeapons";
	description = "Volter";
	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = OmegaImage;
	price = 385;
	showWeaponBar = true;
};

//======================================================================== Targetting Laser

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	//projectileType = RepairBolt;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//======================================================================== Engineer Repair Gun


ItemImageData FixitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "RepairBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = FixitImage;
	price         = 350;
	showWeaponBar = true;
};


//======================================================================== Grav Gun

ItemImageData GravGunImage
{
   shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = gravCharge;
   minEnergy = 3;
   maxEnergy = 20;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.15, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData GravGun
{
   description = "Grav Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = GravGunImage;
	showWeaponBar = true;
   price = 900;
};

//======================================================================== 
//                                                              Back Packs
//======================================================================== 

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




//======================================================================== More Like A Front Pack

 ItemImageData PenisImage
 {
 	shapeFile = "cactus1";
 	mountPoint = 2;
 	mountOffset = { 0, 0.1, -0.2 };
 	mountRotation = { -1.572, 0, 0 };
 	mass = 1.0;
 	firstPerson = true;
 };
 
 ItemData Penis
 {
 	description = "Penis";
 	shapeFile = "cactus1";
 	className = "Backpack";
 	imageType = PenisImage;
 	shadowDetailMask = 4;
 	mass = 1.0;
 	elasticity = 0.2;
 	price = 0;
 	showWeaponBar = false;
 	hiliteOnActive = false;
	
	//===== Testing Pee For Penis
	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = Pee;
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };
	 sfxFire = SoundFlyerActive;
	 sfxActivate = SoundPickUpWeapon;	
	
 };
 
 
 function Penis::onDrop(%player,%item)
 {
 	Client::sendMessage(%client,0,"The curse of the penis can not be removed so easily.");
 }
 
//======================================================================== Deployable Invo

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{

				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 	 		         	addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//======================================================================== Deployable Ammo Station

ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
	         	   		addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Ammo Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
						echo("MSG: ",%client," deployed an Ammo Station");
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//======================================================================== Deployable Command Center

ItemImageData DeployableComPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 4.5;
	firstPerson = false;
};

ItemData DeployableComPack
{
	description = "Command Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableComPackImage;
	mass = 4.0;
	elasticity = 0.2;
	price = $RemoteComEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableComPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableComPack::onDeploy(%player,%item,%pos)
{
	if (DeployableComPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableComPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{

				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("comunit_remote","StaticShape","DeployableComStation",true);
 	 		         	addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Command Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++;
						return true;
					}
				}
				else
				{
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//======================================================================== Energy Pack

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

//======================================================================== Repair Pack

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
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun)
		{
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//======================================================================== Shield Pack

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.022;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}


//======================================================================== Sensor Jammer

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//======================================================================== Cloacking Device

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloaking Device";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{

%armor = Player::getArmor(%player);
 if ((%armor != "aarmor") && (%armor != "afemale"))
 {
 	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
 }
 else
 {
	%obj = newObject("","Mine","CloakBlast");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 3.5";
	%pos = Vector::add(GameBase::getPosition(%player), %padd);
	GameBase::setPosition(%obj, %pos);	
 }
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{

%armor = Player::getArmor(%player);

 if ((%armor != "aarmor") && (%armor != "afemale"))
 {
 	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	%rate = Player::getSensorSupression(%player) - 5;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
 }
 else
  Player::trigger(%player,%imageslot,false);

}

//======================================================================== Stealth Shield

ItemImageData StealthShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 6;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData StealthShieldPack
{
	description = "StealthShield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StealthShieldPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
	%player.shieldStrength = 0.012;
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);

}

function StealthShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
}

//======================================================================== Regeneration Pack

ItemImageData RegenerationPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 8;
	maxEnergy = 14;   // Energy/sec for sustained weapons
	sfxFire = SoundRepairItem;
	
	projectileType = RepairBolt;
	
	//firstPerson = false;
};

ItemData RegenerationPack
{
	description = "Regeneration Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RegenerationPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RegenerationPackImage::onActivate(%player,%imageSlot) 
{
		%clientId = Player::getClient(%player);
}

function RegenerationPackImage::onDeactivate(%player,%imageSlot) 
{
	Player::trigger(%player,$BackpackSlot,false);
}

function TransferHealth(%clientId, %player) 
{
	Client::sendMessage(%clientId,1,"Regeneration On");
	Player::unmountItem(%player,$WeaponSlot);
	if($regTime[%clientId] == 0) 
	{
		GameBase::setEnergy(%player,0);
		GameBase::setRechargeRate(%player,0);
		$regTime[%clientId] = 10;
		checkPlayerDrain(%clientId, %player);
	}
	else $regTime[%clientId] = 10;
}

function checkPlayerDrain(%clientId, %player)
{
	if($regTime[%clientId] > 0)
	{
		$regTime[%clientId] -= 2;
	
	if(GameBase::getDamageLevel(%player))
	{
		GameBase::repairDamage(%player,0.04);
		GameBase::playSound(%player,ForceFieldOpen,0);
	}

	schedule("checkPlayerDrain(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else
	{
	Client::sendMessage(%clientId,1,"Regeneration Off");
	GameBase::setRechargeRate(%player,8);
	}
}

//======================================================================== Teleport Pack

ItemImageData LightningPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LightningPack
{
	description = "Teleport Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
    heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LightningPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LightningPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Teleport On...");
	echo("Calculating Incomming Point");	
	%spawnMarker = GameBase::getPosition(%player);	
	echo ("Blink Out Point " @ %spawnMarker @ "");



	%rnd = floor(getRandom() * 10);

		if (%rnd < 5)	
			%xPos = getWord(%spawnMarker, 0) + (15 + floor(getRandom() * 25));
		else
			%xPos = getWord(%spawnMarker, 0) - (15 + floor(getRandom() * 25));


	%rnd = floor(getRandom() * 10);

		if (%rnd < 5)	
			%yPos = getword(%spawnMarker, 1) + (15 + floor(getRandom() * 20));
		else
			%yPos = getword(%spawnMarker, 1) - (15 + floor(getRandom() * 20));
	
	%zPos = getWord(%spawnMarker, 2) + 15;	
	%rPos = GameBase::getRotation(%player);	
	%zcoor = getWord(%spawnMarker, 2);
	%o = %xPos @ "  " @ %yPos @ "  " @ %zPos;

	echo ("Blink In Point  " @ %o @ "");

	%clientId = (client::getownedobject(%player));



		%belowground = (gamebase::getLOSInfo(%player,5000, "0 3.14 0"));
		%object = $los::object;

		%objname1 = getobjecttype(%object);
		%objname = (GameBase::getDataName(%object)).description;

		echo (" LOS     " @ %belowground);
		echo (" Object  " @ $los::object);
		echo (" ObjectN " @ %objname);
		echo (" ObjectT " @ %objname1);
		
		
	if(GameBase::testPosition(%player, %o))
	{		
		GameBase::SetPosition(%player, %o);
		%belowground = (gamebase::getLOSInfo(%player,5000, "0 3.14 0"));
		echo ("Below Ground " @ %belowground);
		echo ("Player Id " @ %player);
		
		if (%belowground == "false")
		{
			%rnd = floor(getRandom() * 10);

			if (%rnd < 5)	
				%xPos = getWord(%spawnMarker, 0) + (15 + floor(getRandom() * 25));
			else
				%xPos = getWord(%spawnMarker, 0) - (15 + floor(getRandom() * 25));

			%rnd = floor(getRandom() * 10);

			if (%rnd < 5)	
				%yPos = getword(%spawnMarker, 1) + (15 + floor(getRandom() * 20));
			else
				%yPos = getword(%spawnMarker, 1) - (15 + floor(getRandom() * 20));
	
			%zPos = getWord(%spawnMarker, 2) + 25;	
			%rPos = GameBase::getRotation(%player);	
			%o = %xPos @ "  " @ %yPos @ "  " @ %zPos;

			GameBase::SetPosition(%player, %o);
		}


	}
	else 
	{
		Client::sendMessage(Player::getClient(%player),0,"Object Will In The Way...");
	}
}

function LightningPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Relocated...");
	Player::trigger(%player,$BackpackSlot,false);
}


//======================================================================== Flight Pack


ItemImageData FlightPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -2;
 	maxEnergy = -6;
	firstPerson = false;
};

ItemData FlightPack
{
	description = "Flight Pack";
	shapeFile = "jetPack";
	className = "Backpack";
    heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FlightPackImage;
	price = 350;
	hudIcon = "FlightPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlightPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FlightPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FlightPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}


//======================================================================== Auto Rocket Launcher

ItemData AutoRocketAmmo
{
	description = "Auto Rockets";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 30;
};

ItemImageData SMRPackImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.3 };
	mountRotation = { 0, 180, 0 };

	weaponType = 0;
	ammoType = AutoRocketAmmo;

	projectileType = StingerMissile;
	accuFire = true;
	
	reloadTime = 3.5;
	fireTime = 0.0;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;

};

ItemData SMRPack
{
	description = "Rocket Launcher Pack";
	shapeFile = "mortargun";
	className = "Backpack";
    heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SMRPackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SMRPackImage::onActivate(%player,%imageSlot)
{
Player::trigger(%player,$BackpackSlot,false);
}

function SMRPackImage::onDeactivate(%player,%imageSlot)
{
Player::trigger(%player,$BackpackSlot,false);
}

//======================================================================== Auto Rocket Launcher For Juggernaught

ItemImageData SMRPack2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;
	
	mountOffset = { -0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };	
	
	//mountOffset = { 0.0, 0.0, -0.3 };
	//mountRotation = { 0, 180, 0 };

	weaponType = 2;
	ammoType = AutoRocketAmmo;

	projectileType = "Undefined";
	accuFire = true;
	
	reloadTime = 3.5;
	fireTime = 0.0;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;

};

ItemData SMRPack2
{
	description = "Rocket Launcher Pack";
	shapeFile = "mortargun";
	className = "Backpack";
    heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SMRPack2Image;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SMRPack2Image::onDeactivate(%player,%slot)
{
Player::trigger(%player,%slot,false);
}

function SMRPack2Image::onActivate(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SMRPack]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[SMRPack],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
		 if(GameBase::getLOSInfo(%player,950)) 
		 {
			 %object = getObjectType($los::object);
			 %targetId = GameBase::getOwnerClient($los::object);

			 if(%object == "Player" || %object == "Flier") 
			 {			 
				%armor = Player::getArmor(%targetId);
				if (%armor != "spyarmor" || %armor != "spyfemale")
				{
					%name = Client::getName(%targetId);
					Tracker(%client,%targetId);
					Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
					Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
				}
				else
				{
					Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				}
			 }
			 else
			 {
				 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			 }
	 	}
		else
		{
			Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
		}
	}
else
	Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Auto Rocket Launcher");
}

//======================================================================== 
ItemImageData NewPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	weaponType = 0;  // Sustained
	//projectileType = lightningCharge2;
	projectileType = Nuke;

	
	minEnergy = 100;
	maxEnergy = 140;   // Energy/sec for sustained weapons
	reloadTime = 2.5; //new	

	sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;


	//firstPerson = false;
	

};

ItemData NewPack
{
	description = "Auto-Cannon";
	shapeFile = "mortargun";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = NewPackImage;
	price = 350;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NewPackImage::onActivate(%player,%imageSlot)
{

	//Client::sendMessage(Player::getClient(%player),0,"Lightning Field On");
	//%player.shieldStrength = 0.012;
}

function NewPackImage::onDeactivate(%player,%imageSlot)
{
	//Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off");
	Player::trigger(%player,$BackpackSlot,false);
	//%player.shieldStrength = 0;
}

//======================================================================== 

ItemImageData NewerPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	weaponType = 0;  // Sustained
	//projectileType = lightningCharge2;
	projectileType = Nuke;

	
	minEnergy = 100;
	maxEnergy = 140;   // Energy/sec for sustained weapons
	reloadTime = 5.0; //new	

	sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;


	//firstPerson = false;
	

};

ItemData NewerPack
{
	description = "Auto-Cannon";
	shapeFile = "mortargun";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = NewerPackImage;
	price = 350;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NewerPackImage::onActivate(%player,%imageSlot)
{
	//Client::sendMessage(Player::getClient(%player),0,"Lightning Field On");
	//%player.shieldStrength = 0.012;
}

function NewerPackImage::onDeactivate(%player,%imageSlot)
{
	//Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off");
	Player::trigger(%player,$BackpackSlot,false);
	//%player.shieldStrength = 0;
}


//======================================================================== Command LapTop

ItemImageData LaptopImage
{
	shapeFile = "AmmoPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData Laptop
{
	description = "Command Laptop";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 650;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Laptop::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Laptop::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Laptop::onUnmount(%player,%item)
{
//	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
//		Player::unmountItem(%player,$WeaponSlot);
}

//======================================================================== Suicide Pack

ItemImageData SuicidePackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;

};

ItemData SuicidePack
{
	description = "Suicide DetPack";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function SuicidePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function SuicidePack::onUnmount(%player,%item)
{
	deleteObject(%item);
	
}

function SuicidePack::onDeploy(%player,%item,%pos)
{
	if (SuicidePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function SuicidePack::deployShape(%player,%item)
{
	Player::unmountItem(%player,$BackpackSlot);	
		
			%obj = newObject("","Mine","Suicidebomb2");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
			Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds");
}


//======================================================================== Containment

ItemImageData FgcPackImage
{
	shapeFile = "generator_p";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 3.0;
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData FgcPack
{
	description = "Containment Pack";
	shapeFile = "generator_p";
	className = "Backpack";
    heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FgcPackImage;
	price = 1150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FgcPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FgcPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FgcPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Mfgl)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

//======================================================================== Motion Sensor

ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "dDeployables";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	     			addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//======================================================================== Ammo Pack

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 13 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.RocketAmmo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.SniperAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.RailAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.SilencerAmmo = %numPack;
			}
		
			else if(%i == 10) {
	 	    	%item.VulcanAmmo = %numPack;
			
			}
			else if(%i == 11) {
	 	    	%item.Beacon = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.TranqAmmo = %numPack;
			}

			//	else if(%i == 13) {
	 	    //	%item.Boost = %numPack;
			//}
		//		else if(%i == 14) {
	 	//    	%item.Plastique = %numPack;
		//	}
		

			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 13 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		
		else if(%i == 6) {
 	    	%numAdd = %item.RocketAmmo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.SniperAmmo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.RailAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.SilencerAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.VulcanAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.Beacon;
		}
		else if(%i == 12) {
 	    	%numAdd = %item.TranqAmmo;
		}
		else if(%i == 13) {
 	    	%numAdd = %item.Boost;
		}
		else if(%i == 14) {
 	    	%numAdd = %item.Plastique;
		}

		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 13 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

//======================================================================== Pulse Sensor

ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}


//======================================================================== Sensor Jammer

ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = "dDeployables";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}

//======================================================================== Camera Pack

ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//==========================================================================================================================================
// Remote Turets
//==========================================================================================================================================

//=================================================================================================== Ion Turret
																			
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Ion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++)
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TurretPack::deployShape(%player,%item)
{

	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);				//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   		//== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                    					addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Ion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Ion Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");

	if (%flagdist < 35)
	{
	 	%client.score = %client.score + $Score::FlagDef;
	 	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
	        Game::refreshClientScore(%client);
	}
	
								if ($Shifter::TurretKill)
								{
						        		Client::setOwnedObject(%client, %turret);
						        		Client::setOwnedObject(%client, %player);
								}
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

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

//=================================================================================================== Laser Turret

ItemImageData LaserPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function LaserPack::onDeploy(%player,%item,%pos)
{
	if (LaserPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function LaserPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   //== Player To Flag Distance


	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
				%obj = getObjectType($los::object);
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableLaser",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{

					if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
					{
						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot($los::normal,"0 0 1") > 0.6)
						{
							%rot = "0 0 " @ %zRot;
						}
						else
						{
							if (Vector::dot($los::normal,"0 0 -1") > 0.6)
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else
							{
								%rot = Vector::getRotation($los::normal);
							}
						}
						if(checkDeployArea(%client,$los::position))
						{
							%camera = newObject("Camera","Turret",DeployableLaser,true);
			   	      		addToSet("MissionCleanup", %camera);
							GameBase::setTeam(%camera,GameBase::getTeam(%player));
							GameBase::setRotation(%camera,%rot);
							GameBase::setPosition(%camera,$los::position);
							Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Laser Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
							echo("MSG: ",%client," deployed a Remote Turret");

	if (%flagdist < 55)
	{
	 	%client.score = %client.score + $Score::FlagDef;
	  	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
	    Game::refreshClientScore(%client);
	}

							if ($Shifter::TurretKill)
							{
					        	Client::setOwnedObject(%client, %turret);
					        	Client::setOwnedObject(%client, %player);
							}
							return true;
						}
			
					}
					else
					{
						Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
					}			
				}
				else 
					Client::sendMessage(%client,0,"Interference from other laser turrets in the area");
			}
			else
			{
				Client::sendMessage(%client,0,"Deploy position out of range");		
		    }
		}
		else																						  
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");	
	return false;
}

//=================================================================================================== Deployable ELF Turret

ItemImageData DeployableElfImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DeployableElf
{
	description = "Deployable Elf Turret";
	shapeFile = "camera";
	className = "Backpack";
    heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 700;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableElf::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableElf::onDeploy(%player,%item,%pos)
{
	if (DeployableElf::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DeployableElf::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   //== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableElfTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {

			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",DeployableElfTurret,true);
			   	    addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Deployable ELF Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"ELF Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DeployableElf"]++;
					echo("MSG: ",%client," deployed a Remote Turret");

	if (%flagdist < 20)
	{
	 	%client.score = %client.score + $Score::FlagDef;
	  	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
	    Game::refreshClientScore(%client);
	}

					if ($Shifter::TurretKill)
					{
			        	Client::setOwnedObject(%client, %turret);
			        	Client::setOwnedObject(%client, %player);
					}
					return true;
				}
			
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
			   else 
					Client::sendMessage(%client,0,"Interference from other Elf turrets in the area");
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//========================================================================================================== Emp Turret

ItemImageData ShockPackImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ShockPack
{
	description = "EMP Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ShockPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShockPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ShockPack::onDeploy(%player,%item,%pos)
{
	if (ShockPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ShockPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   //== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
					%num = CountObjects(%set,"DeployableShock",%num);
					deleteObject(%set);
					if($MaxNumTurretsInBox > %num) 
					{
						%camera = newObject("Camera","Turret",DeployableShock,true);
	   	    			addToSet("MissionCleanup", %camera);
						GameBase::setTeam(%camera,GameBase::getTeam(%player));
						GameBase::setRotation(%camera,%rot);
						GameBase::setPosition(%camera,$los::position);
						Gamebase::setMapName(%camera,"EMP Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
						Client::sendMessage(%client,0,"EMP Shock Turret deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++;
						echo("MSG: ",%client," deployed a Remote Turret");

	if (%flagdist < 10)
	{
	 	%client.score = %client.score + $Score::FlagDef;
	  	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
	    Game::refreshClientScore(%client);
	}

						if ($Shifter::TurretKill)
						{
						   	Client::setOwnedObject(%client, %turret);
						   	Client::setOwnedObject(%client, %player);
						}
						return true;
				
					}
				    else 
						Client::sendMessage(%client,0,"Interference from other EMP turrets in the area");
				}
			}

			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//===================================================================================================  Mortar Turret

ItemImageData TargetPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData TargetPack
{
	description = "Mortar Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TargetPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TargetPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TargetPack::onDeploy(%player,%item,%pos)
{
	if (TargetPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TargetPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   //== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableMortar",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableMortar,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Mortar Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");

								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;

}

//=============================================================================================== Deployable Plasma Turret

ItemImageData PlasmaTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmaTurretPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "dDeployables";
	imageType = PlasmaTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function PlasmaTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   //== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployablePlasma",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployablePlasma",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployablePlasma,true);
	                     		addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Plasma Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Plasma Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");

	if (%flagdist < 35)
	{
	 	%client.score = %client.score + $Score::FlagDef;
	  	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
	    Game::refreshClientScore(%client);
	}

								if ($Shifter::TurretKill)
								{
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);
								}
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

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

//=================================================================================================== Rocket Turret
						
ItemImageData RocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RocketPack
{
	description = "Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "dDeployables";
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function RocketPack::onDeploy(%player,%item,%pos)
{
	if (RocketPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function RocketPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);   //== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableRocket,true);
	                    		addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Rocket#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");

	if (%flagdist < 100)
	{
	 	%client.score = %client.score + $Score::FlagDef;
	  	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
	    Game::refreshClientScore(%client);
	}

								if ($Shifter::TurretKill)
								{
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);
								}
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//======================================================================================================================
// Other Deployables
//======================================================================================================================

//================================================================================================ Deployable Force Field
						
ItemImageData ForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldPack
{
	description = "Small Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
    heading = "dDeployables";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableForceField",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							%rot = GameBase::getRotation(%player);
							%fField = newObject("","StaticShape",DeployableForceField,true);
							
							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Small Force Field");
							Client::sendMessage(%client,0,"Force Field Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;							
							%fField.isactive = false;
							return true;
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


//=================================================================================================== Large Force Field


ItemImageData LargeForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldPack
{
	description = "Large Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
    heading = "dDeployables";
	imageType = LargeForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LargeForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}



function LargeForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableForceField",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
							%rot = GameBase::getRotation(%player);
							%fField = newObject("","StaticShape",LargeForceField,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Large Force Field");
							Client::sendMessage(%client,0,"Force Field Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;
							%fField.isactive = false;
							return true;
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//=================================================================================================== Blastwall

ItemImageData BlastWallPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastWallPack
{
	description = "Blast Wall";
	shapeFile = "newdoor5";
	className = "Backpack";
    heading = "dDeployables";
	imageType = BlastWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BlastWallPack::onDeploy(%player,%item,%pos)
{
	if (BlastWallPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function BlastWallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		//	if (%obj == "SimTerrain") {
		    	%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"BlastWall",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
   						    %fField = newObject("","StaticShape",BlastWall,true);
							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Blast Wall");
							Client::sendMessage(%client,0,"Blast Wall Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "BlastWallPack"]++;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		//	}
		//	else 
		//		Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


//=================================================================================================== HoloGram

ItemImageData HoloPackImage
{
	shapeFile = "larmor";
	mountPoint = 2;
    mountOffset = { 5, -5, 0 };
	mass = 1.0;
	firstPerson = true;
};

ItemData HoloPack
{
	description = "Hologram";
	shapeFile = "larmor";
	className = "Backpack";
	heading = "dDeployables";
	imageType = HoloPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 900;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HoloPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HoloPack::onDeploy(%player,%item,%pos)
{
	if (HoloPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HoloPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			//if (%obj == "SimTerrain") {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"Hologram",%num);
				deleteObject(%set);
				//if(0 == %num) {
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
							%rnd = floor(getRandom() * 10);
							if(%rnd > 6)
							   %fField = newObject("","StaticShape",Hologram1,true);
							else
								if((%rnd > 2) && (%rnd < 7))				
								   %fField = newObject("","StaticShape",Hologram2,true);
								else
								   %fField = newObject("","StaticShape",Hologram3,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							//Gamebase::setMapName(%fField,"Hologram");
							//Gamebase::setMapName(%fField,Client::getName(%client) @ "'s Hologram" );

							Client::sendMessage(%client,0,"Hologram Deployed");
							GameBase::startFadeIn(%fField);
							//playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);					
							$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");

		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}



//=================================================================================================== Launch Pad

 ItemImageData LaunchPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {
 0, -0.03, 0 }
;

 mass = 2.5;
 firstPerson = false;
 }
;

 ItemData LaunchPack {
 	description = "Launch Pad";
 	shapeFile = "AmmoPack";
 	className = "Backpack";
 	heading = "dDeployables";
 	imageType = LaunchPackImage;
 	shadowDetailMask = 4;
 	mass = 1.0;
 	elasticity = 0.2;
 	price = 500;
 	hudIcon = "deployable";
 	showWeaponBar = true;
 	hiliteOnActive = true;
 }
;

 function LaunchPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function LaunchPack::onDeploy(%player,%item,%pos) {
 	if 
	 (LaunchPack::deployShape(%player,%item)) {
	 Player::decItemCount(%player,%item);
	 }
	 }
	 function LaunchPack::deployShape(%player,%item) {
	 %client = Player::getClient(%player);
		 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
			 if (GameBase::getLOSInfo(%player,3)) {
				 %obj = getObjectType($los::object);
				 if (%obj == "SimTerrain" || %obj == "InteriorShape") {
					 %set = newObject("set",SimSet);
					 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
					 %num = CountObjects(%set,"DeployableCactus",%num);
					 deleteObject(%set);
						 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							 if(checkDeployArea(%client,$los::position)) {
								 %rot = GameBase::getRotation(%player);
								 %phase = newObject("","StaticShape",DeployableLaunch,true);
								 addToSet("MissionCleanup", %phase);
								 GameBase::setTeam(%phase,GameBase::getTeam(%player));
								 GameBase::setPosition(%phase,$los::position);
								 GameBase::setRotation(%phase,%rot);
								 Gamebase::setMapName(%phase,"Launchboard");
								 Client::sendMessage(%client,0,"Launchboard Deployed");
								 GameBase::startFadeIn(%phase);
								 playSound(SoundPickupBackpack,$los::position);
								 playSound(ForceFieldOpen,$los::position);
								 $TeamItemCount[GameBase::getTeam(%player) @ "LaunchPack"]++;
								 return true;
							 }
						 }
						 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					 }
					 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
				 }
				 else Client::sendMessage(%client,0,"Deploy position out of range");
			 }
			 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			 return false;
 }


//=================================================================================================== Mechanical Tree

ItemImageData TreePackImage
{
	//shapeFile = "AmmoPack";
	shapeFile = "tree1";
	mountPoint = 2;
   mountOffset = { 0, 0.15, -1 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Mechanical Tree";
	//shapeFile = "AmmoPack";
	shapeFile = "tree1";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TreePack::onDeploy(%player,%item,%pos)
{
	if (TreePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableTree",%num);
				deleteObject(%set);
				//if(0 == %num) {
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
							%rnd = floor(getRandom() * 10);
							if(%rnd > 5)
								// do tree one
							   %fField = newObject("","StaticShape",DeployableTree,true);
							else
								//tree 2
       						   %fField = newObject("","StaticShape",DeployableTree2,true);
							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Mechanical Tree");
							Client::sendMessage(%client,0,"Mechanical Tree Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//=================================================================================================== Healing Plant

ItemImageData PlantPackImage
{
	//shapeFile = "AmmoPack";
	shapeFile = "cactus2";
	mountPoint = 2;
   mountOffset = { 0, -0.5, -0.3 };

//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlantPack
{
	description = "Healing Plant";
	//shapeFile = "AmmoPack";
	shapeFile = "cactus2";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PlantPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlantPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlantPack::onDeploy(%player,%item,%pos)
{
	if (PlantPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlantPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")  {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableCactus",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
							%rnd = floor(getRandom() * 10);
							if(%rnd > 5)
							   %fField = newObject("","StaticShape",DeployableCactus1,true);
							else  
							 %fField = newObject("","StaticShape",DeployableCactus2,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Healing Plant");
							Client::sendMessage(%client,0,"Healing Plant Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "PlantPack"]++;
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//=================================================================================================== Platform

ItemImageData PlatformPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlatformPack
{
	description = "Deployable Platform";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlatformPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlatformPack::onDeploy(%player,%item,%pos)
{
	if (PlatformPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlatformPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployablePlatform",%num);
				deleteObject(%set);
							%rot = GameBase::getRotation(%player);
							%fField = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Deployable Platform");
							Client::sendMessage(%client,0,"Platform Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
							return true;
	}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//==================================================================================================== Teleport Pad

ItemImageData TeleportPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    	heading = "dDeployables";
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
	}
}

function CreateteleportSimSet()
{
    %teleset = nameToID("MissionCleanup/Teleports");
	if(%teleset == -1)
	{
		newObject("Teleports",SimSet);
		addToSet("MissionCleanup","Teleports");
	}
}

function TeleportPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
	
	if (GameBase::getLOSInfo(%player,3)) {

			%obj = getObjectType($los::object);

			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				if (Vector::dot($los::normal,"0 0 1") > 0.7) {

					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("Teleport Pad","StaticShape",%shape,true);
						CreateteleportSimSet();

                        addToSet("MissionCleanup/Teleports", %sensor);

				addToSet("MissionCleanup", %sensor);

						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						%pos = Vector::add($los::position,"0 0 1");
						echo("LOS pos " @ $los::position @ " " @ %pos);
						GameBase::setPosition(%sensor,%pos);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sensor.disabled = false;
						playSound(SoundPickupBackpack,$los::position);

						%beam = newObject("","StaticShape",ElectricalBeamBig,true);

                        		addToSet("MissionCleanup", %beam);

						GameBase::setTeam(%beam,GameBase::getTeam(%player));
						GameBase::setPosition(%beam,%pos);
						%sensor.beam1 = %beam;

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

//==================================================================================================== Interceptor Pack

ItemImageData MechPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
    mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MechPack
{
	description = "Interceptor Pack";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "dDeployables";
	imageType = MechPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MechPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MechPack::onDeploy(%player,%item,%pos)
{
	if (MechPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MechPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"] < $TeamItemMax[JetVehicle]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		    		%set = newObject("set",SimSet);

				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
						%fField = newObject("",flier,Jet,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Client::sendMessage(%client,0,"Piloting Interceptor");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++;
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


//==================================================================================================== Stealth HPC Pack

ItemImageData DetPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
    mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DetPack
{
	description = "Stealth HPC Pack";
	shapeFile = "ammounit_remote";
	className = "Backpack";
    heading = "dDeployables";
	imageType = DetPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DetPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DetPack::onDeploy(%player,%item,%pos)
{
	if (DetPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DetPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		    		%set = newObject("set",SimSet);

				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
						%fField = newObject("",flier,HAPC,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"HPC Pack");
							Client::sendMessage(%client,0,"Deployed StealthHPC");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							//playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++;
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}



//=====================================================================================================================
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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

//======================================================================== Repair Kit

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//======================================================================== Mines

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

//==== Check Armour To Mine Type

			%armor = Player::getArmor(%player);
			%playerClient = Player::getClient(%player);

		     		if (%armor == "larmor" || %armor == "lfemale")
					{
						%obj = newObject("","Mine","Hologram");					//=== Flag Mine
						Player::decItemCount(%player,%item);				
					}
					//============================================================================================
					if(%armor == "earmor" || %armor == "efemale")				//=== Engineer Mines
					{
						%playerId = %playerClient;

						if (%playerId.EngMine == "0")
						{
							%obj = newObject("","Mine","ProxMine");
							Player::decItemCount(%player,%item);
							$TeamItemCount[GameBase::getTeam(%player) @ "ProxMine"]++;
						}
						else if (%playerId.EngMine == "1")
						{
							%obj = newObject("","Mine","SubspaceMine");
							Player::decItemCount(%player,%item);
						}
						else if (%playerId.EngMine == "2")
						{
							LaserMine(%playerClient, %player, %item);				//==== Point Def. Laser Mine
							return;
						}
						else if (%playerId.EngMine == "3")
						{
							%obj = newObject("","Mine","antipersonelMine");
							Player::decItemCount(%player,%item);
						}
						
					}//===========================================================================================
					
					if (%armor == "sarmor" || %armor == "sfemale")
					{
						%obj = newObject("","Mine","antipersonelMine"); 
						Player::decItemCount(%player,%item);					
					}
					
					if (%armor == "spyarmor" || %armor == "spyfemale")
					{
						%obj = newObject("","Mine","SubspaceMine");				//=== Cloaking Mine
						Player::decItemCount(%player,%item);					
					}
					
					if (%armor == "marmor" || %armor == "mfemale")
                    {
						%obj = newObject("","Mine","antipersonelMine"); 
						Player::decItemCount(%player,%item);					
					}
					
					if (%armor == "aarmor" || %armor == "afemale")
                    {
						%obj = newObject("","Mine","ShockMine");				//=== ShockWaveMine
						Player::decItemCount(%player,%item);					
					}
			        
					if (%armor == "harmor")
                    {
						%obj = newObject("","Mine","antipersonelMine"); 
						Player::decItemCount(%player,%item);					
					}
					
					if (%armor == "barmor" || %armor == "bfemale")
			        {
						%obj = newObject("","Mine","antipersonelMine"); 
						Player::decItemCount(%player,%item);					
					}
					
					if (%armor == "darmor")
					{
						LaserMine(%clientId, %player, %item);				//==== Point Def. Laser Mine
					}
					
//==== Finish Mine Deploy

		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;

			GameBase::setTeam (%obj,GameBase::getTeam (%client));

		}
	}
}

//==================================================================================================== Laser Mine
	
function LaserMine(	%clientId, %player, %bec)
{
	%item = "LaserMine";
	%client = Player::getClient(%player);
		
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
				if (Vector::dot($los::normal,"0 0 1") > 0.2)
				{
					%rot = "0 0 " @ %zRot;
				}
					else 
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
							%rot = "3.14159 0 " @ %zRot;
					}
				
					else 
					{
							%rot = Vector::getRotation($los::normal);
					}
		}
			if(checkDeployArea(%client,$los::position)) {
				
					%camera = newObject("Camera","Turret",DeployableLaserM,true);
	   	    	    addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					
					//Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					//Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen.");
					
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "LaserMine"]++;
					echo("MSG: ",%client," deployed a Laser Mine.");

					Player::decItemCount(%player,%bec);				
					return true;
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	
		return false;
	}

//==================================================================================================== Grenades

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			// class selection grenades		
			%armor = Player::getArmor(%player);

		     	if (%armor == "larmor" || %armor == "lfemale")
                    %obj = newObject("","Mine","HoloMine");				//==== 

				if(%armor == "earmor" || %armor == "efemale")
					%obj = newObject("","Mine","EMPgrenade"); 	//==== 

			    if (%armor == "sarmor" || %armor == "sfemale")
	                %obj = newObject("","Mine","Firebomb"); 			//==== 

				if (%armor == "spyarmor" || %armor == "spyfemale")
				{ 
					%obj = newObject("","Mine","Nukebomb");
					%playerId = (Player::getClient(%player));
					Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in " @ %playerId.plastic @ " seconds"); 
					%timer = %playerId.plastic;
					schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", %timer);
				}

				if (%armor == "marmor" || %armor == "mfemale")
                    %obj = newObject("","Mine","Handgrenade");				//====  

				if (%armor == "aarmor" || %armor == "afemale")
                    %obj = newObject("","Mine","Tranqgrenade");				//==== 

		        if (%armor == "harmor")
	                %obj = newObject("","Mine","Nukebomb"); 			//==== 

				if (%armor == "barmor" || %armor == "bfemale")
				  	%obj = newObject("","Mine","Concussion");	//==== 

				if (%armor == "darmor")
	                %obj = newObject("","Mine","Mortarbomb"); 			//==== 

			//================================================================ End class select
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));//
		}
	}
}
function Grenade::Plastic_Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
//==================================================================================================== Beacons

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);
		     		
				if (%armor == "larmor" || %armor == "lfemale") 
                {
					SniperJammer(%clientId, %player, %item);							//=== Sniper Jammer
				}
				
				if(%armor == "earmor" || %armor == "efemale")
					EngCamera(%clientId, %player, %item);								//=== Eng. Camera
			    
				if (%armor == "sarmor" || %armor == "sfemale")
	      		{              
			  		ScoutStim(%clientId, %player, %item);								//=== Scout Sensor
				}

				if (%armor == "spyarmor" || %armor == "spyfemale")
				{
					DeploySatchel(%clientId, %player, %item);
				}

				if (%armor == "marmor" || %armor == "mfemale")
                          {
					if($matchStarted) {
						if(%player.throwTime < getSimTime() )
						{	
							%obj = newObject("","Mine","Booster");
						 	addToSet("MissionCleanup", %obj);
							%client = Player::getClient(%player);
							GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
							%player.throwTime = getSimTime() + 0.5;
							Client::sendMessage(Player::getClient(%player),0,
							"You use a Speed Booster."); 
							Player::decItemCount(%player, %item);
						}
					}
				}

				if (%armor == "aarmor" || %armor == "afemale")
                {    
					Renegades_startCloak(%clientId, %player);
					Player::decItemCount(%player,%item);
				}

				if (%armor == "barmor" || %armor == "bfemale")
				{
					if($matchStarted)
					{
						if(%player.throwTime < getSimTime() )
						{
							%obj = newObject("","Mine","Concussion2");
						 	addToSet("MissionCleanup", %obj);
							%client = Player::getClient(%player);
							GameBase::throw(%obj,%player,35 * %client.throwStrength,false);
							%player.throwTime = getSimTime() + 0.5;
							Player::decItemCount(%player,%item);
						}
				}}	
				
				if (%armor == "darmor" || %armor == "harmor")
				{
					Renegades_startShield(%clientId, %player); 
					Player::decItemCount(%player,%item);
				}
}


//========================================================================================================= Scout Stim

function ScoutStim(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);
	
	if ($stimTime[%clientId] > 0)
	{
		Client::sendMessage(%clientId,0,"You can NOT Stim Again!");
	}
	else
	{
		if (%armor == "sarmor")
		{
			Player::setArmor(%player,stimarmor);
		}
		else if (%armor == "sfemale")
		{
			Player::setArmor(%player,stimfemale);
		}


		Player::decItemCount(%player, %item);
		Client::sendMessage(%clientId,0,"You used a Stim Pack!");

		//%this = "RepairPatch";
		//Item::playPickupSound(%this);
		
		$stimTime[%clientId] = 10;
		CheckStim(%clientId, %player);		
	}
}

function CheckStim(%clientId, %player)
{
	if($StimTime[%clientId] > 0)
	{
		$StimTime[%clientId] -= 2; 
		%drrate = GameBase::getDamageLevel(%player) * 0.05; //==== Damage Rate When Stimmed
		
		if  (!Player::isDead(%player)) 
		{  
			Player::setDamageFlash(%player,0.35);  
			GameBase::setDamageLevel(%player, %drrate);		
			
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
				%clientId.scoreDeaths++;
      			%clientId.score--;
				Game::refreshClientScore(%clientId);
				$StimTime[%clientId] = 0;
			}

		}
		else
		{
			$StimTime[%clientId] = 0;		
		}
		schedule("CheckStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
    }
	else
	{
		Client::sendMessage(%clientId,0,"Stim Effect Wears Off.");
		%armor = Player::getArmor(%player);
		
		if (%armor == "stimarmor")
			Player::setArmor(%player,sarmor);
		else if (%armor == "stimfemale")
			Player::setArmor(%player,sfemale);
	}					
}

//===================================================================================================== Start Shielding

function Renegades_startShield(%clientId, %player)
{
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

	if (%armor == "jarmor")
		%player.shieldStrength = 0.016;
	else
		%player.shieldStrength = 0.006;

	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 20;
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($shieldTime[%clientId] > 0)
	{
		$shieldTime[%clientId] -= 2;  

		if  ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale" || %armor == "jarmor"))
		{
			if  (Player::isDead(%player))
			{
			}
		}
		else
		{
		
		$shieldTime[%clientId] = 0;
		}
		

		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
    }
	else
	{
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);	
	}			

		
}

//========================================================================================================== Start Cloaking

function Renegades_startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"Cloaking On");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);

	if($cloakTime[%clientId] == 0)
	{
		
		$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else
		$cloakTime[%clientId] = 20;
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($cloakTime[%clientId] > 0)
	{
		$cloakTime[%clientId] -= 2;  
		
		if  ((!Player::isDead(%player)) &&  (%armor == "aarmor" || %armor == "afemale"))
		{
		
		}
		else
		{
			$cloakTime[%clientId] = 0;
		}
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
    }
	else
	{
		Client::sendMessage(%clientId,0,"Cloaking Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
	
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}			

		
}

//==================================================================================================== Satchel Deploy
	
function DeploySatchel(	%clientId, %player, %bec)
{
	%item = "SatchelPack";
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,3)) 
		{

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);

				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{
					%rot = "0 0 " @ %zRot;
				}
				
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
		}
		if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",DeployableSatchel,true);
	   	   		    addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
			
					Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen.");

					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++;
					echo("MSG: ",%client," deployed a Satchel Charge.");
					Player::decItemCount(%player,%bec);
					return true;
					
				}
		}
		else 
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges");
	
	return false;
}


//==================================================================================================== Engineer Camera

function EngCamera(%clientId, %player, %bec)
{
	%item = "CameraPack";
%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Camera");
					Player::decItemCount(%player,%bec);
						return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

return false;
}

//==================================================================================================== Sniper Jammer

function SniperJammer(%clientId, %player, %bec)
{
	%item = "DeployableSensorJammerPack";
%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"SensorJammer");
					Client::sendMessage(%client,0,"SensorJammer deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++;
					echo("MSG: ",%client," deployed a Sensor Jammer");
					Player::decItemCount(%player,%bec);
				return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//==================================================================================================== Scout Sensor

function ScoutSensor(%clientId, %player, %bec)
{
	%item = "PulseSensorPack";
%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("radar_small","Sensor",DeployablePulseSensor,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Pulse Sensor");
					Client::sendMessage(%client,0,"Pulse Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++;
					echo("MSG: ",%client," deployed a Pulse Sensor");
					Player::decItemCount(%player,%bec);
				return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//==================================================================================================== Booster

ItemData Boost
{
   description = "Bot";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Boost::onUse(%player,%item)
{
			%client = Player::getClient(%player);
			Training::setupAI(%client);
}

//==================================================================================================== Plastique Deploy

ItemData Plastique
{
   description = "Plastique";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Plastique::onUse(%player,%item)
{
	if($matchStarted) 
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Nukebomb");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,4 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in " @ %player.Plastic @ " seconds"); 
		}
	}

}

//============================================================================ Repair Patch
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
    heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
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


//======================================================================== Engineer Repair Gun - Hacking Option

ItemImageData HackitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "HackBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hackit
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = HackitImage;
	price         = 1000;
	showWeaponBar = true;
};

//======================================================================== Engineer Repair Gun - Hacking Option

ItemImageData DisItImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "DisaBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DisIt
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = DisItImage;
	price         = 1000;
	showWeaponBar = true;
};



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
	$TeamItemCount[0 @ DeployableInvPack] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;
	
	$TeamItemCount[0 @ RocketPack] = 0;
	$TeamItemCount[1 @ RocketPack] = 0;
	$TeamItemCount[2 @ RocketPack] = 0;
	$TeamItemCount[3 @ RocketPack] = 0;
	$TeamItemCount[4 @ RocketPack] = 0;
	$TeamItemCount[5 @ RocketPack] = 0;
	$TeamItemCount[6 @ RocketPack] = 0;
	$TeamItemCount[7 @ RocketPack] = 0;

	$TeamItemCount[0 @ ForceFieldPack] = 0;
	$TeamItemCount[1 @ ForceFieldPack] = 0;
	$TeamItemCount[2 @ ForceFieldPack] = 0;
	$TeamItemCount[3 @ ForceFieldPack] = 0;
	$TeamItemCount[4 @ ForceFieldPack] = 0;
	$TeamItemCount[5 @ ForceFieldPack] = 0;
	$TeamItemCount[6 @ ForceFieldPack] = 0;
	$TeamItemCount[7 @ ForceFieldPack] = 0;


	$TeamItemCount[0 @ LaserPack] = 0;
	$TeamItemCount[1 @ LaserPack] = 0;
	$TeamItemCount[2 @ LaserPack] = 0;
	$TeamItemCount[3 @ LaserPack] = 0;
	$TeamItemCount[4 @ LaserPack] = 0;
	$TeamItemCount[5 @ LaserPack] = 0;
	$TeamItemCount[6 @ LaserPack] = 0;
	$TeamItemCount[7 @ LaserPack] = 0;

	$TeamItemCount[0 @ DeployableComPack] = 0;
	$TeamItemCount[1 @ DeployableComPack] = 0;
	$TeamItemCount[2 @ DeployableComPack] = 0;
	$TeamItemCount[3 @ DeployableComPack] = 0;
	$TeamItemCount[4 @ DeployableComPack] = 0;
	$TeamItemCount[5 @ DeployableComPack] = 0;
	$TeamItemCount[6 @ DeployableComPack] = 0;
	$TeamItemCount[7 @ DeployableComPack] = 0;
      
	$TeamItemCount[0 @ PlasmaTurretPack] = 0;
	$TeamItemCount[1 @ PlasmaTurretPack] = 0;
	$TeamItemCount[2 @ PlasmaTurretPack] = 0;
	$TeamItemCount[3 @ PlasmaTurretPack] = 0;
	$TeamItemCount[4 @ PlasmaTurretPack] = 0;
	$TeamItemCount[5 @ PlasmaTurretPack] = 0;
	$TeamItemCount[6 @ PlasmaTurretPack] = 0;
	$TeamItemCount[7 @ PlasmaTurretPack] = 0;

	$TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[7 @ DeployableTeleport] = 0;

	$TeamItemCount[0 @ WraithVehicle] = 0;
	$TeamItemCount[1 @ WraithVehicle] = 0;
	$TeamItemCount[2 @ WraithVehicle] = 0;
	$TeamItemCount[3 @ WraithVehicle] = 0;
	$TeamItemCount[4 @ WraithVehicle] = 0;
	$TeamItemCount[5 @ WraithVehicle] = 0;
	$TeamItemCount[6 @ WraithVehicle] = 0;
	$TeamItemCount[7 @ WraithVehicle] = 0;

	$TeamItemCount[0 @ JetVehicle] = 0;
	$TeamItemCount[1 @ JetVehicle] = 0;
	$TeamItemCount[2 @ JetVehicle] = 0;
	$TeamItemCount[3 @ JetVehicle] = 0;
	$TeamItemCount[4 @ JetVehicle] = 0;
	$TeamItemCount[5 @ JetVehicle] = 0;
	$TeamItemCount[6 @ JetVehicle] = 0;
	$TeamItemCount[7 @ JetVehicle] = 0;



	$TeamItemCount[0 @ BlastWallPack] = 0;
	$TeamItemCount[1 @ BlastWallPack] = 0;
	$TeamItemCount[2 @ BlastWallPack] = 0;
	$TeamItemCount[3 @ BlastWallPack] = 0;
	$TeamItemCount[4 @ BlastWallPack] = 0;
	$TeamItemCount[5 @ BlastWallPack] = 0;
	$TeamItemCount[6 @ BlastWallPack] = 0;
	$TeamItemCount[7 @ BlastWallPack] = 0;

	$TeamItemCount[0 @ ShockPack] = 0;
	$TeamItemCount[1 @ ShockPack] = 0;
	$TeamItemCount[2 @ ShockPack] = 0;
	$TeamItemCount[3 @ ShockPack] = 0;
	$TeamItemCount[4 @ ShockPack] = 0;
	$TeamItemCount[5 @ ShockPack] = 0;
	$TeamItemCount[6 @ ShockPack] = 0;
	$TeamItemCount[7 @ ShockPack] = 0;

	$TeamItemCount[0 @ PlatformPack] = 0;
	$TeamItemCount[1 @ PlatformPack] = 0;
	$TeamItemCount[2 @ PlatformPack] = 0;
	$TeamItemCount[3 @ PlatformPack] = 0;
	$TeamItemCount[4 @ PlatformPack] = 0;
	$TeamItemCount[5 @ PlatformPack] = 0;
	$TeamItemCount[6 @ PlatformPack] = 0;
	$TeamItemCount[7 @ PlatformPack] = 0;

	$TeamItemCount[0 @ TreePack] = 0;
	$TeamItemCount[1 @ TreePack] = 0;
	$TeamItemCount[2 @ TreePack] = 0;
	$TeamItemCount[3 @ TreePack] = 0;
	$TeamItemCount[4 @ TreePack] = 0;
	$TeamItemCount[5 @ TreePack] = 0;
	$TeamItemCount[6 @ TreePack] = 0;
	$TeamItemCount[7 @ TreePack] = 0;

	$TeamItemCount[0 @ LargeForceFieldPack] = 0;
	$TeamItemCount[1 @ LargeForceFieldPack] = 0;
	$TeamItemCount[2 @ LargeForceFieldPack] = 0;
	$TeamItemCount[3 @ LargeForceFieldPack] = 0;
	$TeamItemCount[4 @ LargeForceFieldPack] = 0;
	$TeamItemCount[5 @ LargeForceFieldPack] = 0;
	$TeamItemCount[6 @ LargeForceFieldPack] = 0;
	$TeamItemCount[7 @ LargeForceFieldPack] = 0;

	$TeamItemCount[0 @ TargetPack] = 0;
	$TeamItemCount[1 @ TargetPack] = 0;
	$TeamItemCount[2 @ TargetPack] = 0;
	$TeamItemCount[3 @ TargetPack] = 0;
	$TeamItemCount[4 @ TargetPack] = 0;
	$TeamItemCount[5 @ TargetPack] = 0;
	$TeamItemCount[6 @ TargetPack] = 0;
	$TeamItemCount[7 @ TargetPack] = 0;

	$TeamItemCount[0 @ PlantPack] = 0;
	$TeamItemCount[1 @ PlantPack] = 0;
	$TeamItemCount[2 @ PlantPack] = 0;
	$TeamItemCount[3 @ PlantPack] = 0;
	$TeamItemCount[4 @ PlantPack] = 0;
	$TeamItemCount[5 @ PlantPack] = 0;
	$TeamItemCount[6 @ PlantPack] = 0;
	$TeamItemCount[7 @ PlantPack] = 0;

	$TeamItemCount[0 @ hologram] = 0;
	$TeamItemCount[1 @ hologram] = 0;
	$TeamItemCount[2 @ hologram] = 0;
	$TeamItemCount[3 @ hologram] = 0;
	$TeamItemCount[4 @ hologram] = 0;
	$TeamItemCount[5 @ hologram] = 0;
	$TeamItemCount[6 @ hologram] = 0;
	$TeamItemCount[7 @ hologram] = 0;

	$TeamItemCount[0 @ SatchelPack] = 0;
	$TeamItemCount[1 @ SatchelPack] = 0;
	$TeamItemCount[2 @ SatchelPack] = 0;
	$TeamItemCount[3 @ SatchelPack] = 0;
	$TeamItemCount[4 @ SatchelPack] = 0;
	$TeamItemCount[5 @ SatchelPack] = 0;
	$TeamItemCount[6 @ SatchelPack] = 0;
	$TeamItemCount[7 @ SatchelPack] = 0;

     $TeamItemCount[0 @ LaunchPack] = 0;
     $TeamItemCount[1 @ LaunchPack] = 0;
     $TeamItemCount[2 @ LaunchPack] = 0;
     $TeamItemCount[3 @ LaunchPack] = 0;
     $TeamItemCount[4 @ LaunchPack] = 0;
     $TeamItemCount[5 @ LaunchPack] = 0;
     $TeamItemCount[6 @ LaunchPack] = 0;
     $TeamItemCount[7 @ LaunchPack] = 0;
	 
	 $TeamItemCount[0 @ proxLaserT] = 0;
     $TeamItemCount[1 @ proxLaserT] = 0;
     $TeamItemCount[2 @ proxLaserT] = 0;
     $TeamItemCount[3 @ proxLaserT] = 0;
     $TeamItemCount[4 @ proxLaserT] = 0;
     $TeamItemCount[5 @ proxLaserT] = 0;
     $TeamItemCount[6 @ proxLaserT] = 0;
     $TeamItemCount[7 @ proxLaserT] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
