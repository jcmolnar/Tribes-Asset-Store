// This is a MiniMod Plugin.
// This is a "functions" patch for upgrading Tribes to MiniMod v.07 compliance.

$ItemFavoritesKey = $Server::HostName; //This is variable is set to the name of your server. (Fixes Favorites)


function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	if($InvList[MinLauncher]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,MineLauncher,MinelAmmo,5); }
	if($InvList[FlareGun]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,FlareGun,FlareAmmo,5); }
	if($InvList[Grenade]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);}
	if($InvList[Beacon]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,"",Beacon,1);}
	if($InvList[RepairKit]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);}
	if($InvList[MineAmmo]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,"",MineAmmo,1);}

	if($InvList[ChainGun]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);}
	if($InvList[PlasmaGun]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);}
	if($PlasmaGun2){%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun2,PlasmaAmmo,5);}
	if($PlasmaGun3){%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun3,PlasmaAmmo,5);}
	if($InvList[GrenadeLauncher]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);}
	if($InvList[DiscLauncher]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);}
	if($InvList[Mortar]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);}
	if($InvList[RocketLauncher]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,1);}

	if($InvList[SMRPack]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,SMRPack,AutoRocketAmmo,1);}
	if($InvList[SniperRifle]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,5);}
	if($InvList[Railgun]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,2);}
	if($InvList[Silencer]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,Silencer,SilencerAmmo,5);}
	if($InvList[Vulcan]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,Vulcan,VulcanAmmo,50);}
	if($InvList[TranqGun]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,TranqGun,TranqAmmo,5);}
	if($InvList[Mfgl]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,Mfgl,MfglAmmo,1);}
	if($InvList[SMRPack2]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,SMRPack2,AutoRocketAmmo,5);}
	if($InvList[BoomStick]!= ""){%cnt = %cnt + AmmoStation::resupply(%player,BoomStick,BoomAmmo,2);}
	return %cnt;

}

function Mission::reinitData()
{
for(%i = 0; %i < 8; %i++)
{
	$TeamItemCount[%i @ threebyfourForceFieldPack] = 0;
	$TeamItemCount[%i @ fourbyfourteenForceFieldPack] = 0;
	$TeamItemCount[%i @ fourbyseventeenForceFieldPack] = 0;
	$TeamItemCount[%i @ fourbyeightForceFieldPack] = 0;
	$TeamItemCount[%i @ fivebyfiveForceFieldPack] = 0;
      $TeamItemCount[%i @ AccelPPack] = 0;
      $TeamItemCount[%i @ AirAmmoPad] = 0;
      $TeamItemCount[%i @ airbase] = 0;
      $TeamItemCount[%i @ BlastWall] = 0;
      $TeamItemCount[%i @ doorthreebyfourForceFieldPack] = 0;
      $TeamItemCount[%i @ doorfourbyfourteenForceFieldPack] = 0;
      $TeamItemCount[%i @ doorfourbyseventeenForceFieldPack] = 0;
      $TeamItemCount[%i @ doorfourbyeightForceFieldPack] = 0;
      $TeamItemCount[%i @ doorfivebyfiveForceFieldPack] = 0;
      $TeamItemCount[%i @ HoloPack] = 0;
      $TeamItemCount[%i @ JailCapPack] = 0;
      $TeamItemCount[%i @ jailpack] = 0;
      $TeamItemCount[%i @ LargeAirPlatPack] = 0;
      $TeamItemCount[%i @ newdoorone] = 0;
      $TeamItemCount[%i @ newdoortwo] = 0;
      $TeamItemCount[%i @ newdoorthree] = 0;
      $TeamItemCount[%i @ newdoorfour] = 0;
      $TeamItemCount[%i @ Springboard] = 0;
      $TeamItemCount[%i @ SuicidePack] = 0;
	$TeamItemCount[%i @ ConPack] = 0;
	$TeamItemCount[%i @ DissectionPack] = 0;
	$TeamItemCount[%i @ DoBPack] = 0;
	$TeamItemCount[%i @ HGravTurretPack] = 0;
	$TeamItemCount[%i @ AGravPack] = 0;
	$TeamItemCount[%i @ ChaingunTurretPack] = 0;
	$TeamItemCount[%i @ FlakPack] = 0;
	$TeamItemCount[%i @ ConPack] = 0;
	$TeamItemCount[%i @ SeekerPack] = 0;
	$TeamItemCount[%i @ WatchdogPack] = 0;
	$TeamItemCount[%i @ ArbitorBoxPack] = 0;
	$TeamItemCount[%i @ FlameTurretPack] = 0;
	$TeamItemCount[%i @ NuclearTurretPack] = 0;
	$TeamItemCount[%i @ ObeliskPack] = 0;
	$TeamItemCount[%i @ ObeliskPowerPack] = 0;
	$TeamItemCount[%i @ TreePack] = 0;

	$TeamItemCount[%i @ DeployableAmmoPack] = 0;
	$TeamItemCount[%i @ DeployableInvPack] = 0;
	$TeamItemCount[%i @ TurretPack] = 0;
	$TeamItemCount[%i @ CameraPack] = 0;
	$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[%i @ PulseSensorPack] = 0;
	$TeamItemCount[%i @ MotionSensorPack] = 0;
	$TeamItemCount[%i @ ScoutVehicle] = 0;
	$TeamItemCount[%i @ LAPCVehicle] = 0;
	$TeamItemCount[%i @ HAPCVehicle] = 0;
	$TeamItemCount[%i @ Beacon] = 0;
	$TeamItemCount[%i @ mineammo] = 0;
	$TeamItemCount[%i @ RocketPack] = 0;
	$TeamItemCount[%i @ ForceFieldPack] = 0;
	$TeamItemCount[%i @ LaserPack] = 0;
	$TeamItemCount[%i @ DeployableComPack] = 0;
	$TeamItemCount[%i @ PlasmaTurretPack] = 0;
	$TeamItemCount[%i @ DeployableTeleport] = 0;
	$TeamItemCount[%i @ WraithVehicle] = 0;
	$TeamItemCount[%i @ JetVehicle] = 0;
	$TeamItemCount[%i @ BlastWallPack] = 0;
	$TeamItemCount[%i @ ShockPack] = 0;
	$TeamItemCount[%i @ PlatformPack] = 0;
	$TeamItemCount[%i @ TreePack] = 0;
	$TeamItemCount[%i @ LargeForceFieldPack] = 0;
	$TeamItemCount[%i @ TargetPack] = 0;
	$TeamItemCount[%i @ PlantPack] = 0;
	$TeamItemCount[%i @ hologram] = 0;
	$TeamItemCount[%i @ SatchelPack] = 0;
      $TeamItemCount[%i @ LaunchPack] = 0;
	$TeamItemCount[%i @ proxLaserT] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;
}
	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

function removePack(%client) // Handy function for dropping extra packs.
{
  %pack = Player::getMountedItem(%client, $BackpackSlot);
  %item = getItemData(%pack);
  if(%pack != "" || -1)
	{
	Player::decItemCount(%client, %pack);
	teamEnergyBuySell(%player, %item.price);
	}
}

function buyItem(%client,%item)
{
	%pack = Player::getMountedItem(%client,$BackpackSlot);
	%numsell = Player::getItemCount(%client, %item);
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	$tempBuyItem = %item;
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor)
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			%checkArmor = %buyarmor;
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
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack){ 
						fillAmmoPack(%client);
					}
// Error traps. (The fast and dirty way.)
// Also Auto::Loadout are handled here.
				if($Transformer == True)
				{
					if(%checkArmor != tarmor){
							Player::setItemCount(%client, JetfirePack, 0);}
						if($APCTransformation == True){
							Player::setItemCount(%client, TransAPCPack, 0);}
						if($HAPCTransformation == True){
							Player::setItemCount(%client, TransHAPCPack, 0);}
				}
				if($Changeling == True)
				{
					if(%checkArmor != secrarmor){
						Player::setItemCount(%client, ChangelingNet, 0);
						if($FusionBlaster == True)
							Player::setItemCount(%client, FusionGun, 0);}
				}
				if($SCV == True)
				{
					if(%checkArmor != SCVArmor){
						Player::setItemCount(%client, SCVPack, 0);
						Player::setItemCount(%client, SCVGun, 0);}
				}
				if($Specialist == True)
				{
					if(%checkArmor != specarmor)
					{
						Player::setItemCount(%client, SpecialistPack, 0);
					  if($Cloaker)
						Player::setItemCount(%client, Cloaker, 0);
					  if($SlowGun){
						Player::setItemCount(%client, SlowGun, 0);
						Player::setItemCount(%client, SlowGunAmmo, 0);}
					  if($Concuss){
						Player::setItemCount(%client, Concuss, 0);
						Player::setItemCount(%client, ConcussAmmo, 0);}
					}
				}
				if($Engineer == True)
				{
					if(%checkArmor != earmor || efemale)
						Player::setItemCount(%client, Fixit, 0);
				}
				if($Juggernaught == True)
				{
					if (%checkArmor != jarmor)
					{
					  if($RocketLauncher){
						Player::setItemCount(%client, RocketLauncher, 0);
						Player::setItemCount(%client, RocketAmmo,0);
						Player::setItemCount(%client, SMRPack2,0);
						Player::setItemCount(%client, AutoRocketAmmo,0);}
					  if($Mortar){
						Player::setItemCount(%client, Mortar,0);
						Player::setItemCount(%client, MortarAmmo,0);}
					if($TacticalNuke){
						Player::setItemCount(%client, Mfgl,0);
						Player::setItemCount(%client, MfglAmmo,0);}
					  if($GrenadeLauncher){
						Player::setItemCount(%client, GrenadeLauncher,0);
						Player::setItemCount(%client, GrenadeAmmo,0);}
					  if($Vulcan){
						Player::setItemCount(%client, Vulcan,0);
						Player::setItemCount(%client, VulcanAmmo,0);}
					}
				}
				if($DreadNaught == True)
				{
					if (%checkArmor != darmor)
					{
						if($RocketLauncher){
							Player::setItemCount(%client, RocketLauncher, 0);
							Player::setItemCount(%client, SMRPack,0);
							Player::setItemCount(%client, RocketAmmo,0);
							Player::setItemCount(%client, AutoRocketAmmo,0);}
						if($Mortar){
							Player::setItemCount(%client, Mortar,0);
							Player::setItemCount(%client, MortarAmmo,0);}
						if($GrenadeLauncher){
							Player::setItemCount(%client, GrenadeLauncher,0);
							Player::setItemCount(%client, GrenadeAmmo,0);}
						if($Vulcan)
							Player::setItemCount(%client, Vulcan,0);
					}
				}
				if($Engineer == True)
				{
					if(%buyarmor == earmor || efemale)
					{
						if($AutoBuy::Loadouts::Engineer == True)
						{
						checkMaxDrop(%client,%armor);
							Player::setItemCount(%client, Fixit, 1);
						}
					}
				}
				if($Changeling == True)
				{
					if(%buyarmor == secrarmor)
					{
						if($AutoBuy::Loadouts::Changeling == True)
						{
//						checkMaxDrop(%client,%armor);
						Player::unmountItem(%client, $BackpacSlot);
							Player::setItemCount(%client, ChangelingNet, 1);
							Player::mountItem(%client, ChangelingNet, $BackpackSlot);
						  if($FusionBlaster)
							Player::setItemCount(%client, FusionGun, 1);
						  if($Beacon)
							Player::setItemCount(%client, Beacon, 5);
						}
					}
				}
				if($Specialist == True)
				{
					if(%buyarmor == specarmor)
					{
						if($AutoBuy::Loadouts::Specialist == True)
						{
						checkMaxDrop(%client,%armor);
							Player::setItemCount(%client, Beacon, 5);
							Player::setItemCount(%client, SlowGun, 1);
							Player::setItemCount(%client, SlowGunAmmo, 25);
							Player::setItemCount(%client, EnergyRifle, 1);
							Player::setItemCount(%client, SpecialistPack, 1);
							Player::mountItem(%client, SpecialistPack, $BackpackSlot);
							Player::setItemCount(%client, Cloaker, 1);
							Player::setItemCount(%client, Concuss, 1);
							Player::setItemCount(%client, ConcussAmmo, 25);
							Player::setItemCount(%client, Beacon, 5);
						}
					}
				}
				if($SCV == True)
				{
					if(%buyarmor == SCVArmor)
					{
						if($AutoBuy::Loadouts::SCV == True)
						{
						checkMaxDrop(%client,%armor);
							Player::setItemCount(%client, SCVPack, 1);
							Player::mountItem(%client, SCVPack, $BackpackSlot);
							Player::setItemCount(%client, SCVGun, 1);
							Player::mountItem(%client, SCVGun, $WeaponSlot);
						  if($FusionBlaster)
							Player::setItemCount(%client, FusionGun, 0);
						}
					}
				}
				if($Transformer == True)
				{
					if(%buyarmor == tarmor)
					{
						if($AutoBuy::Loadouts::Transformer == True)
						{
							removePack(%client);
							buyItem(%client, JetfirePack);
							Player::mountItem(%client, JetfirePack, $BackpackSlot);
//						checkMaxDrop(%client,%armor);
						  if($FusionBlaster){
							Player::setItemCount(%client, FusionGun, 1);
							Player::mountItem(%client, FusionGun, $WeaponSlot);}
						  if($Blaster)
							Player::setItemCount(%client, Blaster, 1);
						  if(ELFGun)
							Player::setItemCount(%client, EnergyRifle, 1);
						  if($RepairKit)
							Player::setItemCount(%client, RepairKit, 2);
						  if($Beacon)
							Player::setItemCount(%client, Beacon, 5);

						}
					}
				}
				if($Heavy == True)
				{
					if(%buyarmor == harmor)
					{
						if($AutoBuy::Loadouts::Heavy == True)
						{
						checkMaxDrop(%client,%armor);
						  if($FusionBlaster){
							Player::setItemCount(%client, FusionGun, 1);
							Player::mountItem(%client, FusionGun, $WeaponSlot);}
						  if($Blaster)
							Player::setItemCount(%client, Blaster, 1);
						  if($Mortar){
							Player::setItemCount(%client, Mortar, 1);
							Player::setItemCount(%client, MortarAmmo, 20);}
						  if($PlasmaGun){
							Player::setItemCount(%client, PlasmaGun, 1);
							Player::setItemCount(%client, PlasmaAmmo, 60);}
						  if($RepairKit)
							Player::setItemCount(%client, RepairKit, 1);
						  if($Beacon)
							Player::setItemCount(%client, Beacon, 5);
						}
					}
				}
				if($Juggernaught == True)
				{
					if (%buyarmor == jarmor) //================================================== Check Juggernaught   
					{

						echo("Purchased Juggernaught");
						checkMaxDrop(%client,%armor);
						
						//========================================================= Set Weapons
						if($RocketLauncher)
						{
							Player::setItemCount(%client, RocketLauncher, 1);
							Player::setItemCount(%client, SMRPack,1);
							Player::setItemCount(%client, SMRPack2,1);
							Player::setItemCount(%client, RocketAmmo,25);
							Player::setItemCount(%client, AutoRocketAmmo,20);
							Player::mountItem(%client, RocketLauncher, $WeaponSlot);
							Player::mountItem(%client, SMRPack, $FlagSlot);
							Player::mountItem(%client, SMRPack2, $BackPackSlot);
						}
						if($Mortar){
							Player::setItemCount(%client, Mortar,1);
							Player::setItemCount(%client, MortarAmmo,20);}
						if($TacticalNuke){
							Player::setItemCount(%client, Mfgl,1);
							Player::setItemCount(%client, MfglAmmo,3);}
						if($GrenadeLauncher){
							Player::setItemCount(%client, GrenadeLauncher,1);
							Player::setItemCount(%client, GrenadeAmmo,30);}
						if($Vulcan){
							Player::setItemCount(%client, Vulcan,1);
							Player::setItemCount(%client, VulcanAmmo,900);}
					}
				}
				if($DreadNaught == True)
				{
				 if (%buyarmor == darmor)
				 {
				  if($AutoBuy::Loadouts::DreadNaught == True)
				  {
						checkMaxDrop(%client,%armor);
					if($RocketLauncher)
					{
							Player::setItemCount(%client, RocketLauncher, 1);
							Player::setItemCount(%client, SMRPack,1);
							Player::setItemCount(%client, RocketAmmo,10);
							Player::setItemCount(%client, AutoRocketAmmo,15);
							Player::mountItem(%client, SMRPack, $BackPackSlot);
					}
					if($Mortar)
					{
							Player::setItemCount(%client, Mortar,1);
							Player::mountItem(%client, Mortar, $WeaponSlot);
							Player::setItemCount(%client, MortarAmmo,20);
					}
					if($GrenadeLauncher)
					{
							Player::setItemCount(%client, GrenadeLauncher,1);
							Player::setItemCount(%client, GrenadeAmmo,15);
					}
					if($Vulcan)
					{
							Player::setItemCount(%client, Vulcan,1);
							Player::setItemCount(%client, VulcanAmmo,400);
					}
				     }
				    }
				   }	
				   return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack)
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack)
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						Player::decItemCount(%client,"LaserRifle");
						%gun=LaserRifle;
						teamEnergyBuySell(%player, %gun.price);
					}
					if(Player::getItemCount(%client,"LaserChaingun") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
						Player::decItemCount(%client,"LaserChaingun");
						%gun=LaserChaingun;
						teamEnergyBuySell(%player, %gun.price);
					}

				}	
				else if(%pack == EnergizerPack) {
					if(Player::getItemCount(%client,"RepairRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energizer Pack - Auto Selling Repair Rifle");
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
		else if(%item.className == Weapon)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					if(Player::getArmor(%client) != tarmor)
						Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				if(%item == LaserChaingun && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Chaingun - Auto buying Energy Pack");
				}
				if(%item == RepairRifle && Player::getItemCount(%client,"EnergizerPack") == 0) {
					buyItem(%client,"EnergizerPack");
					Client::sendMessage(%client,0,"Bought Repair Rifle - Auto buying Energizer Pack");
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
	 	else if(%item.className == Vehicle)
		{
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
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Grenade, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}

		}
		else if(%item.className == Mine)
		{
			if(checkResources(%player,%item,1))
			{
				for(%i = 1; %i <= $Mine[0]; %i++)
				{
					%m = $Mine[%i];
					if(%item == %m) {}
					else
					{
						teamEnergyBuySell(%player,%m.price * Player::getItemCount(%player, %m));
						Player::setItemCount(%player, %m, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,MineAmmo, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}
		}
		else if(%item.className == Tool)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == RealTargetingLaser)
				{
					teamEnergyBuySell(%player, TractorBeam.price * Player::getItemCount(%player, TractorBeam));
					Player::setItemCount(%player, TractorBeam, 0);
				}
				else if(%item == TractorBeam)
				{
					teamEnergyBuySell(%player, RealTargetingLaser.price * Player::getItemCount(%player, TargetingLaser));
					Player::setItemCount(%player, RealTargetingLaser, 0);
				}
				Player::incItemCount(%client, %item);
				teamEnergyBuySell(%player, (%item.price * -1));
				Player::setItemCount(%client, TargetingLaser, 1);
				return 1;
			}
		}
		else
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
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


// (below) Here is a handy function that I picked up from the z-tek mod and then beefed it up a bit.
// I use this alot when I'm diagnosing problems (provided you grant me access in MiniMod.Prefs.cs)
// and don't want me spending more time killing bots/players just to give you a helping hand in fixing/
// looking for bugs. Also I use it from time to time when I hop on a MiniMod servers that the admin has
// allowed me to gain "SAD" access. It helps when I stop by and ask for the people opinion on what they want
// and don't to see in MiniMod. (Why?) I had some stupid people trying to kill me over and over for points when
// I'm just there to chat and diagnose probs on the server. P.S. The gun is a shortrange "anti-pinhead"
// weapon for discouraging attacks from such people.

// NOTE: DON'T USE THIS FOR CHEATING OR I'LL HAVE TO MAKE UGLY STUFF HAPPEN TO ABUSERS.

function godmode(%client)
{
  if($GodMode != stop)
  {
    %player=client::getownedobject(%client);
    if(%player!=-1)
    { 
	GameBase::setRechargeRate(%player,999999);
	GameBase::setAutoRepairRate(%player,999999);
	%player.shieldStrength=10.0;
	%player.maxDamage=90;
	Player::setItemCount(%client,PlasmaGun3,1);
	if(Player::getMountedItem(%client,$WeaponSlot) != PlasmaGun3)
	{
	  	Player::mountItem(%client,PlasmaGun3,$WeaponSlot);
	}
	Player::setItemCount(%client,PlasmaAmmo,100);
	schedule("godmode("@%client@");",3);
    }
  }
  if($GodMode == stop)
  {
	echo("God Mode stopped for "@%client@"");
	return;
  }
}

