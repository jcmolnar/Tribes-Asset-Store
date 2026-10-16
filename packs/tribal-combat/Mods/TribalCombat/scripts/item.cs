exec(combatDeployable);
exec(combatPacks);
exec(combatWeapons);

$ItemFavoritesKey = "TRIBALCOMBAT031";

$HelpTextTime = 5;

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
$SpecialSlot=4;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, CombatArmor] = carmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, AssaultArmor] = harmor;
$ArmorType[Male, DefenderArmor] = darmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, CombatArmor] = fcarmor;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, AssaultArmor] = harmor;
$ArmorType[Female, DefenderArmor] = darmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[carmor] = CombatArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = AssaultArmor;
$ArmorName[darmor] = DefenderArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[fcarmor] = CombatArmor;
$ArmorName[mfemale] = MediumArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[FusionPack] = 100;
$SellAmmo[GaussAmmo] = 5;
$SellAmmo[BulletAmmo] = 50;
$SellAmmo[PistolAmmo] = 10;
$SellAmmo[SniperAmmo] = 10;
$SellAmmo[HvyBulletAmmo] = 40;
$SellAmmo[PlasmaAmmo] = 20;
$SellAmmo[DiscAmmo] = 10;
$SellAmmo[GrenadeAmmo] = 10;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[RLAmmo] = 2;
$SellAmmo[MLAmmo] = 2;
$SellAmmo[Beacon] = 2;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[ACAmmo] = 20;
$SellAmmo[KineticAmmo] = 25;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 8;
$TeamItemMax[DeployableInvPack] = 8;
$TeamItemMax[TurretPack] = 6;
$TeamItemMax[CameraPack] = 12;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 12;
$TeamItemMax[DGNPack] = 4;
$TeamItemMax[MotionSensorPack] = 12;
$TeamItemMax[DronePack] = 2;
$TeamItemMax[GuidedBombPack] = 2;
$TeamItemMax[SurveyDronePack] = 2;
$TeamItemMax[AttackDronePack] = 2;

$TeamItemMax[ScoutVehicle] = 2;
$TeamItemMax[SpeederVehicle] = 2;
$TeamItemMax[HTVehicle] = 1;
$TeamItemMax[BomberVehicle] = 1;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;

$TeamItemMax[Beacon] = 12;
$TeamItemMax[mineammo] = 96;
$TeamItemMax[ForceScreen] = 8;
$TeamItemMax[Barricade] = 10;
$TeamItemMax[TeleportField] = 2;
$TeamItemMax[TeleportPad] = 1;
$TeamItemMax[ChaingunTurret] = 4;
$TeamItemMax[LaserTurretPack] = 4;
$TeamItemMax[RemoteAutoCannon] = 2;
$TeamItemMax[RemoteAACannon] = 2;
$TeamItemMax[RemotePlasmaTurret] = 2;
$TeamItemMax[MissileTurret] = 1;
$TeamItemMax[MRL] = 1;
$TeamItemMax[RemoteELF] = 4;
$TeamItemMax[SniperNest] = 2;
$TeamItemMax[StealthMine] = 8;
$TeamItemMax[AntiArmorMine] = 6;

$TeamItemMax[VehicleBaseControl] = 1;
$TeamItemMax[VehicleBasePad] = 1;

$TeamItemMax[ComPack] = 6;

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

//******************
function checkItem(%item)
{
 if(%item != "Blaster" &&
    %item != "EDGun" &&
    %item != "FusionRifle" &&
    %item != "GaussRifle" &&
	%item != "SilencedPistol" &&
	%item != "SniperRifle" &&
	%item != "Chaingun" &&
	%item != "HvyChaingun" &&
	%item != "AutoCannon" &&
	%item != "Disclauncher" &&
	%item != "GrenadeLauncher" &&
	%item != "Mortar" &&
	%item != "AMortar" &&
	%item != "RocketLauncher" &&
	%item != "MissileLauncher" &&
	%item != "PlasmaGun" &&
	%item != "PlasmaRepeater" &&
	%item != "EnergyCannon" &&
	%item != "LaserRifle" &&
	%item != "CutterBeam" &&
	%item != "EnergyRifle" &&
	%item != "TransferGun" &&
	%item != "FieldRepairGun" &&
	%item != "DemoCharge" &&
	%item != "TargetingLaser" &&
	%item != "MineAmmo" &&
	%item != "Grenade" &&
	%item != "Beacon" &&
	%item != "FusionPack" &&
	%item != "GaussAmmo" &&
	%item != "PistolAmmo" &&
	%item != "SniperAmmo" &&
	%item != "BulletAmmo" &&
	%item != "HvyBulletAmmo" &&
	%item != "ACAmmo" &&
	%item != "PlasmaAmmo" &&
	%item != "DiscAmmo" &&
	%item != "GrenadeAmmo" &&
	%item != "MortarAmmo" &&
	%item != "RLAmmo" &&
	%item != "MLAmmo" &&
	%item != "EnergyPack" &&
	%item != "RepairPack" &&
	%item != "ShieldPack" &&
	%item != "SensorJammerPack" &&
	%item != "StealthPack" &&
	%item != "ComPack" &&
	%item != "TelePack" &&
	%item != "VehicleRepairPack" &&
	%item != "DronePack" &&
	%item != "GuidedBombPack" &&
	%item != "SurveyDronePack" &&
	%item != "AttackDronePack" &&
	%item != "RelocatePack" &&
	%item != "CoolantPack" &&
	%item != "MotionSensorPack" &&
	%item != "PulseSensorPack" &&
	%item != "DGNPack" &&
	%item != "DeployableSensorJammerPack" &&
	%item != "CameraPack" &&
	%item != "AmmoPack" &&
	%item != "RepairKit" &&
	%item != "DeployableInvPack" &&
	%item != "DeployableAmmoPack" &&
	%item != "ForceScreen" &&
	%item != "Barricade" &&
	%item != "TeleportField" &&
	%item != "TeleportPad" &&
	%item != "TurretPack" &&
	%item != "LaserTurretPack" &&
	%item != "ChaingunTurret" &&
	%item != "RemoteAutoCannon" &&
	%item != "RemoteAACannon" &&
	%item != "RemotePlasmaTurret" &&
	%item != "MissileTurret" &&
	%item != "MRL" &&
	%item != "SniperNest" &&
	%item != "RemoteELF" &&
	%item != "StealthMine" &&
	%item != "AntiArmorMine" &&
	%item != "VehicleBaseControl" &&
	%item != "VehicleBasePad" &&
	%item != "FloatingPad")
	return false;
	else return true;
}

//******************
function adjustRot(%rot,%rad)
{
 %Zrot = getWord(%rot,2);
 if(%Zrot >= 3 || %Zrot <= -3) %Zrot *= -1;
 %val = %Zrot + %rad;
 if(%val > 3) %val -= 6;
 if(%val < -3) %val += 6;
//echo("Adjust Rot: "@%rot@" "@%val);
 return("0 0 "@%val);
}

//******************
function remoteUseSpecial(%client)
{
 if($Combat::DisableSpecial) return;
 else Player::useItem(%client,Beacon); //Special);
}

//******************
function autoSellAll(%player,%item)
{
 %client = Player::getClient(%player);
 if(%client.observerMode != "") return;

 if(!checkItem(%item))
 {
  echo("AutoSellAll Invalid Item "@%item@" Client"@%client);
  return;
 }

 %amount = Player::getItemCount(%client,%item);
 if(%amount > 0)
 {
	Player::setItemCount(%player,%item,0);
	teamEnergyBuySell(%player,%item.price * %amount);
	Client::sendMessage(%client,0,"Auto Selling "@%item);
 }
}

//********************************
function isAttached(%client,%item)
{
 %armor = Player::getArmor(%client);
 if(%armor == harmor)
 {
  if(%item == AutoCannon || %item == ACAmmo)
  {
   Client::sendMessage(%client,0,"This item is integral to this armor type.~wC_BuySell.wav");
   return true;
  }
 }
 else if(%armor == darmor)
 {
  if(%item == FieldRepairGun)
  {
   Client::sendMessage(%client,0,"This item is integral to this armor type.~wC_BuySell.wav");
   return true;
  }
 }
 return false;
}

//---------------------------------------
function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling    IF - Cost Negitive buying 
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
	{
	 %station.Energy += %cost;			//Remote StationEnergy
	 if(%station.Energy < 1) %station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") 
	{ 
		$TeamEnergy[%team] += %cost;    //Total TeamEnergy
 		%client.teamEnergy += %cost;   //Personal TeamEnergy
	}
}

//*********************
function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

//*********************
function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
 if((Client::getOwnedObject(%client) == -1) || Player::isDead(%client)) return;
 if(isPlayerBusy(%client)) return;

 // only can buy fav every 1/2 second
 %time = getIntegerTime(true) >> 4; // int half seconds
 if(%time <= %client.lastBuyFavTime) return;

 %client.lastBuyFavTime = %time;

 %station = (Client::getOwnedObject(%client)).Station;
 if(%station != "") 
 {
  %stationName = GameBase::getDataName(%station); 
  if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) %energy = %station.Energy;
  else %energy = $TeamEnergy[Client::getTeam(%client)];

  if(%energy == "Infinite" || %energy > 0) 
  {
   %error = 0;
   %bought = 0;
   %max = getNumItems();
   for(%i = 0; %i < %max; %i = %i + 1) 
   { 
	%item = getItemData(%i);
	if($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) 
	{
     %count = Player::getItemCount(%client,%item);
	 if(%count) 
	 {
	  if(%item.className != Armor) teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
	  Player::setItemCount(%client, %item, 0);  
	 }
	}
   }
   for (%i = 0; %i < 20; %i++) 
   { 
    if(%favItem[%i] != "") 
	{
	 %item = getItemData(%favItem[%i]);
	 if((Client::isItemShoppingOn(%client,%item)) && 
	   ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || 
	   %item.className == Armor)) 
	 {
	  if(!buyItem(%client,%item)) %error = 1;
	  else %bought++;
	 }
	}
   }
   if(%bought) 
   {
    if(%error) Client::sendMessage(%client,0,"~wC_BuySell.wav");
	else Client::SendMessage(%client,0,"~wbuysellsound.wav");
   }
   updateBuyingList(%client);
  }
 }
}

//**********************
function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}

//**********************
function checkResources(%player,%item,%delta,%noMessage)
{
 if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return 0;
 
 %client = Player::getClient(%player);
 %team = Client::getTeam(%client);
 %extraAmmo = 0;
 if(Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
 {
  %extraAmmo = $AmmoPackMax[%item];
  if(%delta == $ItemMax[Player::getArmor(%client), %item]) %delta = %delta + %extraAmmo;
 }
 if($TestCheats == 0 && %client.spawn == "") 
 {
  %energy = $TeamEnergy[%team];
  %station = %player.Station;
  %sName = GameBase::getDataName(%station);
  if(%sName == DeployableInvStation || %sName == DeployableAmmoStation) %energy = %station.Energy;
  if(%energy != "Infinite") 
  {
   if(%item.price * %delta > %energy) %delta = %energy / %item.price; 
   if(%delta < 1 ) 
   {
    if(%noMessage == "") Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
	return 0;
   }
  }
 }
 if(%item.className == Weapon) 
 {
  %armor = Player::getArmor(%client);
  %wcount = Player::getItemClassCount(%client,"Weapon");
  if(Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) 
  {
   Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
   return 0;
  }
 }
 else if(%item == RepairPatch) 
 {
  %pDamage = GameBase::getDamageLevel(%player);
  if(GameBase::getDamageLevel(%player) > 0) return 1;
  return 0;
 }
 else if($TeamItemMax[%item] != "" && !$TestCheats) 
 {
  if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) 
  {
   Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
   return 0;
  }
 }
 if(%item.className != Armor && %item.className != Vehicle) 
 {
  %count = Player::getItemCount(%client,%item);
  %max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
  if(%delta + %count >= %max) %delta = %max - %count;
 }
 return %delta;
}

//*****************************
function buyItem(%client,%item)
{
 if((Client::getOwnedObject(%client) == -1) || Player::isDead(%client)) return 0;

 %player = Client::getOwnedObject(%client);
 %armor = Player::getArmor(%client);
 if(($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
   ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) 
 {
  if(%item.className == Armor) 
  {
   //Reset Broadcast Power
   if(%armor == "darmor" && $Combat::BroadcastPower[%client])
   {
    $Combat::BroadcastPower[%client].broadcastPower = false;
    if(!GameBase::isPowered($Combat::BroadcastPower[%client]))
    {
     GameBase::stopSequence($Combat::BroadcastPower[%client],0);
     GameBase::pauseSequence($Combat::BroadcastPower[%client],1);
     GameBase::pauseSequence($Combat::BroadcastPower[%client],2);
     Station::checkTarget($Combat::BroadcastPower[%client]);
    }
    $Combat::BroadcastPower[%client] = false;
    GameBase::setRechargeRate(%player,8);
    bottomprint(%client,"<jc>Broadcast power stopped",3);
   }

   // Assign armor by requested type & gender
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
	 if(Player::getMountedItem(%client,$BackpackSlot) == ammopack) fillAmmoPack(%client);
	 if(%item == DefenderArmor && !$Combat::BaseItems)
	 {
	  Player::setItemCount(%client,"FieldRepairGun",1);
	  teamEnergyBuySell(%player,FieldRepairGun.price);
	  Client::sendMessage(%client,0,"Bought Defender Armor - Auto Buying Field Repair Gun");
	 }
	 if(%item == AssaultArmor && !$Combat::BaseItems)
	 {
	  Player::setItemCount(%client,"AutoCannon",1);
	  teamEnergyBuySell(%player,AutoCannon.price);
	  Player::setItemCount(%client,"ACAmmo",$ItemMax[harmor,ACAmmo]);
	  teamEnergyBuySell(%player,ACAmmo.price * $ItemMax[harmor,ACAmmo]);
	  Client::sendMessage(%client,0,"Bought Assault Armor - Auto Buying Auto Cannon");
	 }
	 return 1;
	}
   	teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
   }
  }
  else if (%item.className == Backpack) 
  {
   if($TeamItemMax[%item] != "") 
   {						
    if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0;
   }
   %pack = Player::getMountedItem(%client,$BackpackSlot);
   if(%pack != -1) 
   {
    if(%pack == ammopack) checkMax(%client,%armor);
    else if(%pack == EnergyPack) 
   	{
	 if(Player::getItemCount(%client,"LaserRifle") > 0) autoSellAll(%player,"LaserRifle");
	 if(Player::getItemCount(%client,"CutterBeam") > 0) autoSellAll(%player,"CutterBeam");
	 if(Player::getItemCount(%client,"EnergyCannon") > 0) autoSellAll(%player,"EnergyCannon");
	}
	else if(%pack == RepairPack)
	{
	 if(Player::getItemCount(%client,"TransferGun") > 0) autoSellAll(%player,"TransferGun");
	}
	else if(%pack == ShieldPack)
	{
	 if(Player::getItemCount(%client,"EDGun") > 0) autoSellAll(%player,"EDGun");
	}
	else if(%pack == CoolantPack)
	{
	 if(Player::getItemCount(%client,"PlasmaRepeater") > 0) autoSellAll(%player,"PlasmaRepeater");
	}	
	teamEnergyBuySell(%player,%pack.price);
	if(!Player::isDead(%player)) Player::decItemCount(%client,%pack);
   }			   
   if(checkResources(%player,%item,1) || $testCheats) 
   {
    teamEnergyBuySell(%player,%item.price * -1);
	Player::incItemCount(%client,%item);
	Player::useItem(%client,%item);									 
	if(%item == ammopack) fillAmmoPack(%client);
	return 1;
   }
   else if(%pack != -1) 
   {
    teamEnergyBuySell(%player,%pack.price * -1);
	Player::incItemCount(%client,%pack);
	Player::useItem(%client,%pack);									 
	if(%pack == ammopack) fillAmmoPack(%client);
   }				 
  }
  else if(%item.className == Weapon) 
  {
   if(checkResources(%player,%item,1)) 
   {
    if(%item == EDGun && Player::getItemCount(%client,"ShieldPack") == 0) 
	{
	 buyItem(%client,"ShieldPack");
	 Client::sendMessage(%client,0,"Bought EDGun - Auto buying Shield Pack");
	}
	if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) 
	{
	 buyItem(%client,"EnergyPack");
	 Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
	}
	if(%item == CutterBeam && Player::getItemCount(%client,"EnergyPack") == 0) 
  	{ 
	 buyItem(%client,"EnergyPack");
	 Client::sendMessage(%client,0,"Bought Pulse Laser  - Auto buying Energy Pack");
	}
	if(%item == EnergyCannon && Player::getItemCount(%client,"EnergyPack") == 0) 
	{
     buyItem(%client,"EnergyPack");
	 Client::sendMessage(%client,0,"Bought Energy Cannon  - Auto buying Energy Pack");
	}
	if(%item == TransferGun && Player::getItemCount(%client,"RepairPack") == 0) 
	{
	 buyItem(%client,"RepairPack");
	 Client::sendMessage(%client,0,"Bought Transfer Gun - Auto buying Repair Pack");
	}
	if(%item == PlasmaRepeater && Player::getItemCount(%client,"CoolantPack") == 0) 
	{
	 buyItem(%client,"CoolantPack");
	 Client::sendMessage(%client,0,"Bought Plasma Repeater - Auto buying Coolant Pack");
	}
	Player::incItemCount(%client,%item);
	teamEnergyBuySell(%player,(%item.price * -1));
	%ammoItem =  %item.imageType.ammoType; 
	if(%ammoItem != "") 
	{
	 %delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
	 if(%delta || $testCheats) 
	 {
	  teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
	  Player::incItemCount(%client,%ammoitem,%delta);
	 }
	}
	return 1;
   }
  }
  else if(%item.className == Vehicle) 
  {
   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) 
   {
	%shouldBuy = VehicleStation::checkBuying(%client,%item);
	if(%shouldBuy == 1) 
	{
	 teamEnergyBuySell(%player,(%item.price * -1));
	 return 1;
	}			
 	else if(%shouldBuy == 2) return 1;
   }
  }
  else 
  {
   if($TeamItemMax[%item] != "") 
   {
    if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0;
   }
   %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
   if(%delta || $testCheats) 
   {
	teamEnergyBuySell(%player,(%item.price * -1 * %delta));
	Player::incItemCount(%client,%item,%delta);
	return 1;
   }
  }
 }
 return 0;
}

//*****************
function armorChange(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "") 
	{
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);	
	  	%newPosX = (getWord(%vec,0) * 1) + %posX;		 
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
		%armor = Player::getArmor(%client);
		if(%armor == larmor || %armor == lfemale) %armorText = "Light Armor sacrifices protection for speed.\nSPECIAL: Jump Booster\nGRENADE: Hand Grenade\n";
		if(%armor == carmor || %armor == cfarmor) %armorText = "Combat Armor balances speed, manuverability, and protection.\nSPECIAL: Emergency Medical Kit\nGRENADE: Hand Grenade\n";
		if(%armor == marmor || %armor == mfemale) %armorText = "Medium Armor sacrifices some speed for the ability to carry deployables.\nSPECIAL: Emergency Energy Supply\nGRENADE: Demo Grenade\n";
		if(%armor == harmor) %armorText = "Assault Armor has good overall protection, but is relatively slow.\nSPECIAL: Assault Shield (toggle)\nGRENADE: Blast Grenade\n";
		if(%armor == darmor) %armorText = "Defender Armor is agonizingly slow, very heavy, and is hard to destroy.\nIt also may NOT be transported in a vehicle.\nSPECIAL: Broadcast Power\nGRENADE: Blast Grenade\n";

		if(%armorText != "") topprint(%client,"<jc>"@%armorText,$HelpTextTime);
	}
}

//*******************
function remoteBuyItem(%client,%type)
{
 if(isPlayerBusy(%client)) return;

 %item = getItemData(%type);
 if(buyItem(%client,%item)) 
 {
  Client::sendMessage(%client,0,"~wbuysellsound.wav");
  updateBuyingList(%client);

  if(%item.className == "Weapon")
  {
	if(%item == Blaster) %helpText = "The Blaster has a pretty good rate of fire, and does a small amount of splash damage.\nIt is not very effective against shielded targets.\n";
	if(%item == EDGun) %helpText = "The EDGun drains all the energy from a target, and does almost no physical damage.\n It has a very short projectile range,\nbut is the weapon of choice used to take down deployed Force Fields.\nIt requires the Shield Pack to fire, as it creates an inverse shield effect.";
	if(%item == FusionRifle) %helpText = "The Fusion Rifle is an ammo driven energy weapon, which is best used at a moderate range.\nA continued stream of fire can penetrate shielded targets.\n";
	if(%item == GaussRifle) %helpText = "The Gauss Rifle is the most potent sniper weapon available.\nIt can destroy just about any target, but has a slow reload rate.\n";
	if(%item == SilencedPistol) %helpText = "The Silenced Pistol is a close range assassin weapon,\ndesigned to penetrate thick armors.\n";
	if(%item == SniperRifle) %helpText = "The Sniper Rifle is a weapon of choice for long ranged kills.\n";
	if(%item == Chaingun) %helpText = "The Chaingun is a great assault weapon of choice.\nIt has a high rate of fire, and tight groupings of shots even at moderate ranges.\n";
	if(%item == HvyChaingun) %helpText = "The Heavy Chaingun is a very powerful weapon.\nIts spin up time is a bit slower,\nbut it can do twice the amount of damage,\nin half the amount of time and ammo then a Chaingun.\n";
	if(%item == DiscLauncher) %helpText = "The Disc Launcher is very effective in duels against other players,\nand has a nice splash damage radius effect.\nIt isn't as powerful against shielded targets.\n";
	if(%item == AutoCannon) %helpText = "The AutoCannon has a slow cycle rate, but fires potent explosive shells.\n";
	if(%item == PlasmaGun) %helpText = "The Plasma Gun is a very powerful weapon, and deadly in skilled hands.\nJust a few well placed shots can destroy any unshieled target,\nbut even shields are not invulnerable against this weapon.\n";
	if(%item == PlasmaRepeater) %helpText = "The Plasma Repeater is a rapid fire version of the Plasma Gun.\nIt requires significant cooling to function, which lessens the damage done per shot with this weapon.\nThis weapon require the Coolant Pack.\n";
	if(%item == EnergyCannon) %helpText = "The Energy Cannon is a slow firing energy weapon,\nthat causes some very good damage against all but the most heavily shielded targets.\nIt requires an Energy Pack to fire.\n";
	if(%item == Mortar) %helpText = "The Mortar fires the standard Mortar Shell.\nThis weapon has targetting features which allow it use the Targeting Laser and Beacon waypoint settings.\n";
	if(%item == AMortar) %helpText = "The Assault Mortar is extremely powerful, and has a moderate range of fire.\nThe mortar shell has tremendous explosive force,\nand can kill less protected targets in one shot.\nThis weapon will NOT work with Beacons and Target Lasers.\n";
	if(%item == RocketLauncher) %helpText = "The Rocket Launcher has an extened range of fire, and the rocket itself a sizable blast area.\nThe only set back is the limited amount of ammunition that this weapon can carry.\n";
	if(%item == MissileLauncher) %helpText = "The Missile Launcher is a two shot missile pack, used to destroy moving targets.\nThe AutoTarget mode fires a self seeking missile,\n while the guidance mode fires a player guided missile.\nDo NOT fire the guided missile while you yourself are moving!\n";
	if(%item == GrenadeLauncher) %helpText = "The Grenade Launcher is a tricky weapon to master,\nand can be used to clear rooms of enemy defenses.\nIn skilled hands it can also be used in overhead strafing passes.\n";
	if(%item == LaserRifle) %helpText = "The Laser Rifle requires an energy pack, and has a very long recharge time between shots.\nWhile it doesn't do much damage to heavily shielded targets,\nit can cause extremely serious damage to any armor type.\nThis is a VERY powerful weapon.\n";
	if(%item == CutterBeam) %helpText = "The Pulse Laser requires an Energy Pack to be used, but is deadly against ground troops.\nIt is not effective against shielded targets.\nThis weapon uses an armor energy source for power,\nonce this supply is depleted this weapon does almost no damage.\n";
	if(%item == EnergyRifle) %helpText = "The ELF gun can drain the energy of any target,\nand does a fair amount of damage as well.\nIt is auto aiming,\nand can be very effective against players as well as emplacements.\n";
	if(%item == TransferGun) %helpText = "The Energy Transfer Gun uses the enemy energy to activate a healing process.\nThis heals damage taken by draining the enemy of power.\nThis is the slowest healing method provided.\nThis weapon requires a Repair Pack to function.\n";
	if(%item == DemoCharge) %helpText = "The Demolitions Charge is one package of explosives\nthat can be delievered to any target at close range.\nOnce used it frees up a weapon slot.\nIf you MUST blow something up, this will do the job.\n";
	if(%item == KineticRifle) %helpText = "The Particle Cannon fires a burst of charged particles, which do kinetic damage to targets.\nThis weapon has a very long range, and can cause significant amounts of damage with concentrated fire.\nIt also pierces armor shields, with no reduction in damage strength.\n";
  }

  else if(%item.className == "Tool")
  {
    if(%item == FieldRepairGun) %helpText = "The Field Repair Gun doesn't use a weapon nor backpack slot.\nThereby freeing up space for more items.\nIt is redundant to get this item and the Repair Pack\n";
  }

  else if(%item.className == "Backpack")
  {
	if(%item == Barricade) %helpText = "The Barricade is great for setting up a blockade of an area.\n";
	if(%item == ForceScreen) %helpText = "The Force Screen can be used to protect critical areas of one's base.\nIt acts as a doorway, so you may seal off entire sections of the base from intrusion.\nIf you do not want a moveable barrier, use the Barricade.";
	if(%item == FloatingPad) %helpText = "The Floating Pad can be placed anywhere,\nbut it is advised to use this device outside only.\nWhile it can take an amazing amount of punishment, once destroyed it goes critical mass,\nand causes tremendous amounts of damage to nearby objects.\n";
	if(%item == TeleportPad) %helpText = "The Teleport Pad sets up a location by which users of the Teleport Pack may travel to.\n";
	if(%item == TeleportField) %helpText = "The Teleport Field sets up a gateway by which one can\ntravel between two locationsn and must be used in pairs.\nThey will NOT transport flags, and do NOT differentiate between teams.\nOne one side is destroy, the other field collapses as well.\n";
	if(%item == TelePack) %helpText = "The Teleportation Pack can be used after a Teleport Pad had been deployed.\nActivation of this device will send the user to the location of the Teleport Pad.\nFlags will NOT travel through teleportation.\n";
	if(%item == RelocatePack) %helpText = "The Relocator Pack is a line of sight teleportation device.\nThe range is not unlimited, and like with all teleporters, flags will NOT travel to the destination point.\nOnce used, your energy systems must recover.\n";
	if(%item == DronePack) %helpText = "The Drone will let you scout areas without danger.\nAlthough slow moving, it is extremely manuverable, and in skilled hands can go anywhere.\nThe jump command self-destructs the Drone, which is the only way to dismount it.\n";
	if(%item == SurveyDronePack) %helpText = "The Survey Drone is much more useful outdoors then the Drone.\nWhile it doesn't have the manuverability of the Drone to venture within structures,\n it more then makes up for it in speed.\n";
	if(%item == GuidedBombPack) %helpText = "The Guided Bomb is an awesome tool of warfare.\nThis weapon can knock out all but the most hardened structures.\nThe jump command self-destructs, and ramming a target detonates the device.\n";
	if(%item == EnergyPack) %helpText = "The Energy Pack steps up the output of your armors energy source,\n and allows a faster recharge per second rate.\n";
	if(%item == RepairPack) %helpText = "\n";
	if(%item == Shieldpack) %helpText = "The Shield Pack converts your armors energy in to a portable force shield.\nDamage caused while using this pack depletes the energy supply, so use it wisely.\nThis improved version will not put a drain on your energy source while running.\n";
	if(%item == SensorJammerPack) %helpText = "The Sensor Jammer Pack suppresses the enemy sensor network,\nand conceals your presense on the battlefield.\nThis pack does not put a drain on your energy supply,\nbut it must be turned off to recover energy when depleted.\n";
	if(%item == AmmoPack) %helpText = "The Ammo Pack supplies a generous amountof ammunition to any weapon carried.\nIt will NOT hold ammo for any weapon not currently in your inventory.\n";
	if(%item == ComPack) %helpText = "The Communications Link provides the means to access the command network from anywhere on the battlefield.\nThis allows the control of turrets from any location.\n";
	if(%item == CoolantPack) %helpText = "The Coolant Pack is needed for the operation of the PlasmaRepeater.\nThere is no other use for this device, and it carries a severe energy penality for its use.\nIt is advised to drop this pack when no longer needed.\n";
	if(%item == VehicleRepairPack) %helpText = "The Vehicle Repair Pack allows the automatic repair of a vehicle while piloting.\nThe rate is slower then using a Repair Pack, but it allows repair over time spent flying.\nYou must be inside the vehicle for this device to function.\n";
	if(%item == SniperNest) %helpText = "Use the Remote Sniper via the commander screen to\nassassinate enemies and destroy their defensive structures.\nYou may use the CommLink Pack or a Command Staation to access this device.\n";
  }

  else if(%item.className == "Vehicle")
  {
	if(%item == ScoutVehicle) %helpText = "The Scout is the fastest of the fliers,\nand has built in mini fusion guns.\n";
	if(%item == SpeederVehicle) %helpText = "The Fighter is extremely manuverable,\nand has twin chainguns for attack runs.\n";
	if(%item == LAPCVehicle) %helpText = "The LPC can carry two passengers.\n";
	if(%item == BomberVehicle) %helpText = "The Bomber is slow and can take a fair amount\nof punishment before being destroyed.\nIt drops a Bomb, which has a very large blast radius.\nTry to gain some altitude before the Bomb detonates.\n";
	if(%item == HAPCVehicle) %helpText = "The HPC can carry four passengers.\n";
  }

  else if(%item.className == "HandAmmo")
  {
   %armor = Player::getArmor(%client);
   if(%item == Beacon)
    {
	 if(%armor == "larmor" || %armor == "lfemale") %helpText = "The Special slot is different for each armor.\nLight Armor gets a jump thruster, which will propel the user a great distance.\n";
	 if(%armor == "carmor" || %armor == "fcarmor") %helpText = "The Special slot is different for each armor.\nCombat Armor has Emergency Medical Kits.\nThey must be manually triggered to heal damage.\n";
	 if(%armor == "marmor" || %armor == "mfemale") %helpText = "The Special slot is different for each armor.\nMedium Armor has emergency Energy Reserves.\nThese can only be activated when below 30% energy.\n";
	 if(%armor == "harmor") %helpText = "The Special slot is different for each armor.\nAssault Armor has an assault shield, which replaces the siheld pack.\nThis shield acts just like the shield pack, but is more durable\nToggle it on and off.\nIt must be manually shut down in order to recharge energy!\n";
	}
  }

  if(%helpText != "") topprint(%client,"<jc>"@%helpText,$HelpTextTime);
 }
 else Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

//**********************
function remoteSellItem(%client,%type)
{
 if((Client::getOwnedObject(%client) == -1) || Player::isDead(%client)) return 0;
 if(isPlayerBusy(%client)) return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) 
	{
		if(Player::getItemCount(%client,%item) && %item.className != Armor) 
		{
         if(isAttached(%client,%item)) return 0;

			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) 
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) %numsell = %count; 
				else %numsell = $SellAmmo[%item];
			}
			else if(%item == ammopack) checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") 
			{
				if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}

			else if(%item == EnergyPack) 
			{ 
				if(Player::getItemCount(%client,"LaserRifle") > 0) autoSellAll(%player,"LaserRifle");
				if(Player::getItemCount(%client,"CutterBeam") > 0) autoSellAll(%player,"CutterBeam");
				if(Player::getItemCount(%client,"EnergyCannon") > 0) autoSellAll(%player,"EnergyCannon");
			}
	 		else if(%item == RepairPack)
			{
				if(Player::getItemCount(%client,"TransferGun") > 0) autoSellAll(%player,"TransferGun");
			}
			else if(%item == ShieldPack)
			{
				if(Player::getItemCount(%client,"EDGun") > 0) autoSellAll(%player,"EDGun");
			}
			else if(%item == CoolantPack)
			{
				if(Player::getItemCount(%client,"PlasmaRepeater") > 0) autoSellAll(%player,"PlasmaRepeater");
			}
			else if(%item.classname == Weapon)
			{
			 if(%item == FusionRifle) autoSellAll(%player,"FusionPack");
			 if(%item == GaussRifle) autoSellAll(%player,"GaussAmmo");
			 if(%item == PlasmaGun)
			 {
			  if(Player::getItemCount(%client,"PlasmaRepeater") == 0) autoSellAll(%player,"PlasmaAmmo");
			 }
			 if(%item == PlasmaRepeater)
			 {
			  if(Player::getItemCount(%client,"PlasmaGun") == 0) autoSellAll(%player,"PlasmaAmmo");
			  if(Player::getItemCount(%client,"CoolantPack") > 0) autoSellAll(%player,"CoolantPack");
			 }
			 if(%item == SilencedPistol) autoSellAll(%player,"PistolAmmo");
			 if(%item == SniperRifle) autoSellAll(%player,"SniperAmmo");
			 if(%item == Chaingun) autoSellAll(%player,"BulletAmmo");
			 if(%item == HvyChaingun) autoSellAll(%player,"HvyBulletAmmo");
			 if(%item == DiscLauncher) autoSellAll(%player,"DiscAmmo");
			 if(%item == GrenadeLauncher) autoSellAll(%player,"GrenadeAmmo");
			 if(%item == Mortar) autoSellAll(%player,"MortarAmmo");
			 if(%item == RocketLauncher) autoSellAll(%player,"RLAmmo");
			 if(%item == MissileLauncher) autoSellAll(%player,"MLAmmo");
			 if(%item == AutoCannon) autoSellAll(%player,"ACAmmo");
			 if(%item == KineticRifle) autoSellAll(%player,"KineticAmmo");
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

//*******************
function remoteUseItem(%client,%type)
{
 %client.throwStrength = 1;
 %item = getItemData(%type);
 if(%item == Backpack) %item = Player::getMountedItem(%client,$BackpackSlot);
 else 
 {
  if(%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot);
 }
 Player::useItem(%client,%item);
}

//*******************
function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime() && GameBase::getControlClient(%player) != -1) 
	{
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") 
		{
		//if(GameBase::getControlClient(%player) != -1) {
//echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo) 
			{
				if(%strength < 0) %strength = 0;
				else if(%strength > 100) %strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	%player = Client::getOwnedObject(%client);
	if($Combat::NoLitterBug && %player.station != "")
	{
	 Client::sendMessage(%client,0,"This server is running anti-litter bug.");
	 return;
	}

	if((Client::getOwnedObject(%client)).driver != 1) 
	{
		%client.throwStrength = 1;
		%item = getItemData(%type);

		if(%item == Backpack) 
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
	    else if(%item == Weapon) 
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
            if(isAttached(%client,%item)) return;
			Player::dropItem(%client,%item);
		}
		else if(%item == Ammo) 
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
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//-------------------------------------------
function Item::giveItem(%player,%item,%delta)
{
 if(GameBase::getOwnerClient(%player) == -1) return 0;
 %client = Player::getClient(%player);
 %armor = Player::getArmor(%player);
 if($ItemMax[%armor, %item]) 
 {		  
  if(%item.className == Backpack) 
  {
   // Only one backpack per armor, and it's always mounted
   if(Player::getMountedItem(%player,$BackpackSlot) == -1) 
   {
    Player::incItemCount(%player,%item);
	Player::useItem(%player,%item);
	Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
	return 1;
   }
  }
  else 
  {
   // Check num weapons carried by player can't have more then max
   if(%item.className == Weapon) 
   {
	if(Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) return 0;
   }  
   %extraAmmo = 0 ;
   if(Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") %extraAmmo = $AmmoPackMax[%item];
   // Make sure it doesn't exceed carrying capacity
   %count = Player::getItemCount(%player,%item);
   if(%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) %delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
   if(%delta > 0) 
   {
    Player::incItemCount(%player,%item,%delta);
//	if(%count == 0 && $AutoUse[%item]) Player::useItem(%player,%item);
	Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
	return %delta;
   }
  }
 }
 return 0;
}


//----------------------------
// Default Item object methods

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if(%sound != "") playSound(%sound,GameBase::getPosition(%this));
	// Generic item sound
	else playSound(SoundPickupItem,GameBase::getPosition(%this));
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
	if (Item::isRotating(%this)) 
	{
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else deleteObject(%this);
}	

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
 if(getObjectType(%object) == "Player") 
 {
  if((GameBase::getOwnerClient(%object) == -1) || Player::isDead(%object)) return;

  %item = Item::getItemData(%this);
  %count = Player::getItemCount(%object,%item);
  if(Item::giveItem(%object,%item,Item::getCount(%this))) 
  {
   Item::playPickupSound(%this);
   Item::respawn(%this);
  }
 }
}

//--------------------------
// Default Inventory methods

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{
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
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if(Player::isDead(%player)) GameBase::throw(%obj,%player,10,true);
			else 
			{
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			//if(!Player::isDead(%player)) 
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}

//---------------------------------
function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}

function Flag::onMount(%player,%slot)
{
	%client = Player::getClient(%player);
	%type = Player::getMountedItem(%player,$BackpackSlot);
	if(%type == StealthPack)
	 {
		Player::trigger(%player,$BackpackSlot,false);
		centerprint(%client,"<jc>Carrying a flag interferes with the operation of the stealth pack.");
	 }
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
   heading = "aArmor";
	description = "Light Armor";
	className = "Armor";
	price = 175;
};

ItemData CombatArmor
{
	heading = "aArmor";
	description = "Combat Armor";
	className = "Armor";
	price = 200;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Medium Armor";
	className = "Armor";
	price = 250;
};

ItemData AssaultArmor
{
   heading = "aArmor";
	description = "Assault Armor";
	className = "Armor";
	price = 400;
};

ItemData DefenderArmor
{
	heading = "aArmor";
	description = "Defender Armor";
	className = "Armor";
	price = 600;
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

ItemData SpeederVehicle
{
	description = "Fighter";
	className = "Vehicle";
    heading = "aVehicle";
	price = 750;
};

ItemData HTVehicle
{
	description = "Assault Craft";
	className = "Vehicle";
    heading = "aVehicle";
	price = 900;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
    heading = "aVehicle";
	price = 675;
};

ItemData BomberVehicle
{
    description = "Bomber";
	className = "Vehicle";
    heading = "aVehicle";
	price = 1000;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
    heading = "aVehicle";
	price = 875;
};

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
			%objname = GameBase::getDataName(%obj);
			if(%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
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
				else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//--------------------------
$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "vTools";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	%client = Player::getClient(%player);
    if(GameBase::getDamageLevel(%player) != 0)
	{
	 if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
	 bottomprint(%client,"<jc>Repair Kit used.");
	 GameBase::repairDamage(%player,0.5);
	}
}

//---------------
ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "wMiscellany";
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
 if($matchStarted) 
 {
  %vehicle = GameBase::getDataName(%player.vehicle);
  if(%vehicle == Drone || %vehicle == GuidedBomb || 
     %vehicle == SurveyDrone || %vehicle == AttackDrone || %vehicle == GuidedMissile) return;

  if(%player.throwTime < getSimTime()) 
  {
   if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
   %obj = newObject("","Mine","antipersonelMine");
   addToSet("MissionCleanup", %obj);
   %client = Player::getClient(%player);
   GameBase::setTeam (%obj,GameBase::getTeam (%client));
   GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
   %player.throwTime = getSimTime() + 0.5;
  }
 }
}

//--------------
ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "wMiscellany";
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	 {
	    %vehicle = GameBase::getDataName(%player.vehicle);
	    if(%vehicle == Drone || %vehicle == GuidedBomb || 
		   %vehicle == SurveyDrone || %vehicle == AttackDrone || %vehicle == GuidedMissile) return;

		if(%player.throwTime < getSimTime() )
		 {
			if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
			
			%armor = Player::getArmor(%player);
			if(%armor == "harmor" || %armor == "darmor") %obj = newObject("","Mine","BlastGrenade");
			else if(%armor == "marmor" || %armor == "mfemale") %obj = newObject("","Mine","DemoGrenade");
			else %obj = newObject("","Mine","Handgrenade");

 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//**************
//$InvList[Special] = 1;
//$RemoteInvList[Special] = 1;

$ItemMax[larmor, Special] = 2;
$ItemMax[carmor, Special] = 4;
$ItemMax[marmor, Special] = 3;
$ItemMax[harmor, Special] = 1;
$ItemMax[darmor, Special] = 0;
$ItemMax[lfemale, Special] = 2;
$ItemMax[fcarmor, Special] = 4;
$ItemMax[mfemale, Special] = 3;

ItemData Special
{
   description = "Special";
   shapeFile = "sensor_small";
   heading = "vTools";
   shadowDetailMask = 4;
   price = 0;
   className = "Tool";
};

function Special::onUse(%player,%item)
{
 if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return;

 %armor = Player::getArmor(%player);
 %client = Player::getClient(%player);
 if(%client.observerMode != "") return;

 //Check valid item
 if(!checkItem(%item))
 {
  echo("Special::onUse invalid item "@%item@" Client "@%client);
  return;
 }

//centerprint(%client,"<jc>"@GameBase::getPosition(%player)@"\n"@GameBase::getRotation(%player),10);

 if(Player::getItemCount(%client,%item) < 1)
 {
  bottomprint(%client,"<jc>This item has been depleted.");
  return;
 }

 if(%armor == "larmor" && $Combat::JumpThruster == "off")
 {
  if(Beacon::deployShape(%player,%item)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
  return;
 }

 if($matchStarted && %player.Station == "")
 {
	if(%armor == "larmor" || %armor == "lfemale")
	 {
	    if($Combat::timeOut[%client] <= 0)
		{
		 $Combat::timeOut[%client] = 10;
		 %rot = GameBase::getRotation(%player);
		 if($Combat::ForwardThrust < 0 || $Combat::ForwardThrust > 500) $Combat::ForwardThrust = 500;
		 if($Combat::UpThrust < 0 || $Combat::UpThrust > 600) $Combat::UpThrust = 600;
		 %vect = Vector::getFromRot(%rot,$Combat::ForwardThrust,$Combat::UpThrust);
		 if(Player::getItemCount(%client,%item) > 0) bottomprint(%client,"<jc>Jump thruster activated. aprox. 20 seconds until recharged.");
		 else bottomprint(%client,"<jc>Jump thruster is now depleted.");
		 GameBase::PlaySound(%player,shockExplosion,0);
		 Player::applyImpulse(%player,%vect);
		 if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
		 if(Player::getItemCount(%client,%item) > 0)	bottomprint(%client,"<jc>Jump thruster activated. aprox. 20 seconds until recharged.");
		 else bottomprint(%client,"<jc>Jump thruster is now depleted.");
		 setTimeOut(%player,%item);
		}
		else bottomprint(%client,"<jc>Jump thruster is recharging.");
	 }
    else if(%armor == "carmor" || %armor == "fcarmor")
	{
	  if(GameBase::getDamageLevel(%player) != 0)
	  {
	   bottomprint(%client,"<jc>Emergency medical kit engaged");
	   GameBase::repairDamage(%player,0.35);
	   if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
	  }
	  else bottomprint(%client,"<jc>You are not in need of medical aid.");
	}
	else if(%armor == "marmor" || %armor == "mfemale")
    {
	  if(GameBase::getEnergy(%player) < %armor.maxEnergy * 0.4)
	  {
	   bottomprint(%client,"<jc>Emergency energy supply engaged");
	   GameBase::setEnergy(%player,%armor.maxEnergy);
	   if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
	  }
	  else bottomprint(%client,"<jc>Energy levels are not low enough to need a backup supply.");
	}
	else if(%armor == "harmor")
	{
	  if($assaultShield[%client])
	   {
		 $assaultShield[%client] = false;
	     %player.shieldStrength = 0;
	     bottomprint(%client,"<jc>Assault Shield Deactivated",2);
		 GameBase::setRechargeRate(%player,8);
         GameBase::playSound(%player,ForceFieldOpen,0);
	   }
	   else
	   {
		 $assaultShield[%client] = true;
	     %player.shieldStrength = 0.015;
	     bottomprint(%client,"<jc>Assault Shield Activated",2);
		 GameBase::setRechargeRate(%player,0);
	     GameBase::playSound(%player,ForceFieldOpen,0);
   	     schedule("checkAShield("@%player@","@%item@");",2,%player);
	   }
	}
	else if(%armor == "darmor")
	 {	
	  %team = Client::getTeam(%client);
	  if($Combat::BroadcastPower[%client])
	  {
       $Combat::BroadcastPower[%client].broadcastPower = false;
	   if(!GameBase::isPowered($Combat::BroadcastPower[%client]))
	   {
	    GameBase::stopSequence($Combat::BroadcastPower[%client],0);
	    GameBase::pauseSequence($Combat::BroadcastPower[%client],1);
	    GameBase::pauseSequence($Combat::BroadcastPower[%client],2);
	    Station::checkTarget($Combat::BroadcastPower[%client]);
	   }
	   $Combat::BroadcastPower[%client] = false;
	   GameBase::setRechargeRate(%player,8);
	   bottomprint(%client,"<jc>Broadcast power stopped",3);
	  }
      else 
	  {
	   if(GameBase::getLOSInfo(%player,5)) 
	   {
	    %objName = GameBase::getDataName($los::object);
	    if(%objName == InventoryStation || %objName == AmmoStation)
	    {
	     %station = $los::object;
         if(GameBase::isPowered(%station) || %station.broadcastPower) bottomprint(%client,"<jc>Station is powered");
		 else
		 {
		  $Combat::BroadcastPower[%client] = %station;
		  %station.broadcastPower = true;
		  GameBase::playSequence(%station,0,"power");
		  GameBase::playSequence(%station,1);
		  GameBase::setEnergy(%player,0);
	      GameBase::setRechargeRate(%player,0);
	      bottomprint(%client,"<jc>Broadcast power started",3);
		  schedule("checkBroadcastPower("@%client@","@%item@");",3,%client);
		 }
	    }
	   }
	  }
	 }
 }
}

function setTimeOut(%player,%item)
{
	%client = Player::getClient(%player);
    if(%client.observerMode != "") return;

	$Combat::timeOut[%client]--;
	if($Combat::timeOut[%client] > 0 && !Player::isDead(%player)) schedule("setTimeOut("@%player@","@%item@");",2,%client);
	else
	{
//	 if(%item == "Special")
	 if(%item == "Beacon")
	  {
	   %armor = Player::getArmor(%player);
	   if(%armor == "larmor" || %armor == "lfemale")
	   {
	    if(Player::getItemCount(%client,%item) > 0) bottomprint(%client,"<jc>Jump thruster is now charged.");	   
	   }
	  }
	}
}

function checkAShield(%player,%item)
{
 %client = GameBase::getOwnerClient(%player);
 %energy = GameBase::getEnergy(%player);
 if($assaultShield[%client])
 {
  if(%energy < 8) Player::useItem(%client,%item);
  else schedule("checkAShield("@%player@","@%item@");",2,%player);
 }
}

function checkBroadcastPower(%client,%item)
{
 if($Combat::BroadcastPower[%client])
 {
  %station = $Combat::BroadcastPower[%client];
  if(GameBase::isPowered(%station)) Player::useItem(%client,%item);
  else schedule("checkBroadcastPower("@%client@","@%item@");",3,%client);
 }
}

//-------------
ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "wMiscellany";
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
 if($Combat::DisableSpecial)
 {
  if(Beacon::deployShape(%player,%item)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
 }
 else Special::onUse(%player,%item);
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

//------------------
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
    heading = "vTools";
	shadowDetailMask = 4;
  	price = 2;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") 
	{
		if(GameBase::getDamageLevel(%object)) 
		{
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}

//-------------------------------
function remoteGiveAll(%clientId)
{
	if($TestCheats) 
	{
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
	else if($ServerCheats) 
	{
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

//-------------------------------
function checkMax(%client,%armor)
{
 if(Client::getOwnedObject(%client) == -1) return;

 %weaponflag = 0;
 %numweapon = Player::getItemClassCount(%client,"Weapon");
 if(%numweapon > $MaxWeapons[%armor]) %weaponflag = %numweapon - $MaxWeapons[%armor];
 %max = getNumItems();
 for(%i = 0; %i < %max; %i = %i + 1) 
 {
  %item = getItemData(%i);
  %maxnum = $ItemMax[%armor, %item];
  if(%maxnum != "")
  {
   %numsell = 0;
   %count = Player::getItemCount(%client,%item);
   if(%count > %maxnum) %numsell =  %count - %maxnum;
   if(%count > 0 && %weaponflag && %item.className == Weapon) 
   {
    %numsell = 1;
	%weaponflag = %weaponflag - 1;
   }
   if(%numsell > 0) 
   {
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
	if($TeamEnergy[%team] != "Infinite") 
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) 
		{
			if(%client.teamEnergy >= 0) %diff = $InitialPlayerEnergy;
			else %diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

function Mission::reinitData()
{
 %i = 0;
 while(%i < 8)
 {
	$TeamItemCount[%i @ DeployableAmmoPack] = 0;
	$TeamItemCount[%i @ DeployableInvPack] = 0;
	$TeamItemCount[%i @ TurretPack] = 0;
	$TeamItemCount[%i @ ChaingunTurret] = 0;
	$TeamItemCount[%i @ LaserTurretPack] = 0;
	$TeamItemCount[%i @ CameraPack] = 0;
	$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[%i @ PulseSensorPack] = 0;
	$TeamItemCount[%i @ DGNPack] = 0;
	$TeamItemCount[%i @ MotionSensorPack] = 0;
	$TeamItemCount[%i @ ScoutVehicle] = 0;
	$TeamItemCount[%i @ LAPCVehicle] = 0;
	$TeamItemCount[%i @ HAPCVehicle] = 0;
	$TeamItemCount[%i @ SpeederVehicle] = 0;
	$TeamItemCount[%i @ BomberVehicle] = 0;
	$TeamItemCount[%i @ HTVehicle] = 0;
	$TeamItemCount[%i @ Beacon] = 0;
	$TeamItemCount[%i @ mineammo] = 0;
    $TeamItemCount[%i @ ForceScreen] = 0;
	$TeamItemCount[%i @ Barricade] = 0;
	$TeamItemCount[%i @ FloatingPad] = 0;
	$TeamItemCount[%i @ TeleportField] = 0;
	$TeamItemCount[%i @ TeleportPad] = 0;
	$TeamItemCount[%i @ RemoteAutoCannon] = 0;
	$TeamItemCount[%i @ RemoteAACannon] = 0;
	$TeamItemCount[%i @ RemotePlasmaTurret] = 0;
	$TeamItemCount[%i @ RemoteELF] = 0;
	$TeamItemCount[%i @ MissileTurret] = 0;
	$TeamItemCount[%i @ StealthMine] = 0;
	$TeamItemCount[%i @ AntiArmorMine] = 0;
	$TeamItemCount[%i @ MRL] = 0;
	$TeamItemCount[%i @ SniperNest] = 0;
	$TeamItemCount[%i @ DronePack] = 0;
	$TeamItemCount[%i @ SurveyDronePack] = 0;
	$TeamItemCount[%i @ GuidedBombPack] = 0;
	$TeamItemCount[%i @ AttackDronePack] = 0;
	$TeamItemCount[%i @ VehicleBasePad] = 0;
	$TeamItemCount[%i @ VehicleBaseControl] = 0;
	%i++;
 }
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++) $TeamEnergy[%i] = $DefaultTeamEnergy; 
}