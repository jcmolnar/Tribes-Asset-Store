// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

$ItemFavoritesKey = "INFVX6";  

//================================
// Easy Way For Invetory Headings
//================================
$InvHead[ihTur] = "a-=[Turret Systems]=-";        
$InvHead[ihWea] = "b-=[Weapon Cache]=-";
$InvHead[ihPsi] = "c-=[Psionics]=-";
$InvHead[ihArm] = "d-=[Armor Suits]=-";
$InvHead[ihBkp] = "e-=[Tactical Back Packs]=-";
$InvHead[ihFie] = "f-=[Field Equiptment]=-";
$InvHead[ihSen] = "g-=[Sensor Networks]=-";
$InvHead[ihUpg] = "h-=[Armor Upgrades]=-";
$InvHead[ihBfe] = "i-=[Base/Field Equipment]=-";
$InvHead[ihDef] = "j-=[Deffence Equiptment]=-";

$ItemPopTime = 3;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Blaster] = False;
$AutoUse[Chaingun] = False;
$AutoUse[PlasmaGun] = False;
$AutoUse[Mortar] = False;
$AutoUse[GrenadeLauncher] = False;
$AutoUse[LaserRifle] = False;
$AutoUse[EnergyRifle] = False;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = False;
$AutoUse[FireballAbility] = False;
$AutoUse[SmScreenAbility] = False;
$AutoUse[ExSmScreenAbility] = False;
$AutoUse[FireScreenAbility] = False;
$AutoUse[SpellAbility] = False;
$AutoUse[TaserRifle] = False;
$AutoUse[LiLFFB] = False;
$AutoUse[LiLPOOmkii] = False;
$AutoUse[LiLPOOmki] = False;
$AutoUse[LiLRocketLauncher] = False;
$AutoUse[LiLEMPRocketLauncher] = False;
$AutoUse[BeamOfPain] = False;

$Use[Blaster] = False;
$Use[LiLPOOmki] = False;
$Use[LiLPOOmkii] = False;
$Use[PlasmaGun] = False;
$Use[Mortar] = False;
$Use[LiLFFB] = False;
$Use[LiLRocketLauncher] = False;
$Use[LiLEMPRocketLauncher] = False;
$Use[FireballAbility] = False;
$Use[SmScreenAbility] = False;
$Use[ExSmScreenAbility] = False;
$Use[FireScreenAbility] = False;
$Use[SpellAbility] = False;
$Use[GrenadeLauncher] = False;
$Use[Chaingun] = False;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;

$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;

$TeamItemMax[ArbitorBeaconPack] = 3;
$TeamItemMax[EMPBeaconPack] = 3;
$TeamItemMax[JammerBeaconPack] = 3;
$TeamItemMax[ShieldBeaconPack] = 3;
$TeamItemMax[HealBeaconPack] = 3;

$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[MercJetVehicle] = 10;
$TeamItemMax[HAPCVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 12;
$TeamItemMax[Beacon] = 500;
$TeamItemMax[mineammo] = 500;

$TeamItemMax[TaserTrtBPack] = 10;
$TeamItemMax[TaserTrtCPack] = 10;
$TeamItemMax[LaserTurretPack] = 10;
$TeamItemMax[LaserTurretBPack] = 10;
$TeamItemMax[MiniFlakTurretPack] = 10;
$TeamItemMax[MiniSAMTurretPack] = 10;
$TeamItemMax[MiniELFTurretPack] = 10;
$TeamItemMax[MiniSmokeTurretPack] = 10;
$TeamItemMax[MiniGRIPTurretPack] = 10;
$TeamItemMax[ElectricWeb] = 5;
$TeamItemMax[lgaForceFieldPack] = 12;
$TeamItemMax[lgbForceFieldPack] = 12;
$TeamItemMax[medaForceFieldPack] = 12;
$TeamItemMax[medbForceFieldPack] = 12;
$TeamItemMax[medcForceFieldPack] = 12;
$TeamItemMax[DeployableTeleport] = 4;

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

$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = "";
$WeaponAmmo[Chaingun] = "";
$WeaponAmmo[DiscLauncher] = "";
$WeaponAmmo[GrenadeLauncher] = "";
$WeaponAmmo[Mortar] = "";
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[TaserRifle] = "";
$WeaponAmmo[BeamOfPain] = "";
$WeaponAmmo[LiLFFB] = "";
$WeaponAmmo[LiLPOOmkii] = "";
$WeaponAmmo[LiLPOOmki] = "";
$WeaponAmmo[LiLRocketLauncher] = "";
$WeaponAmmo[LiLEMPRocketLauncher] = "";
$WeaponAmmo[FireballAbility] = "";
$WeaponAmmo[SmScreenAbility] = "";
$WeaponAmmo[ExSmScreenAbility] = "";
$WeaponAmmo[FireScreenAbility] = "";
$WeaponAmmo[SpellAbility] = "";

//----------------------------------------------------------------------------
// Server side methods Buy/Sell etc

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
		%station.Energy += %cost;			
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost;    
 		%client.teamEnergy += %cost;   
	}
}

function isPlayerBusy(%client)
{
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if (isPlayerBusy(%client))
		return;
   %time = getIntegerTime(true) >> 4; 
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

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor) {
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

			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
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
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {

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

ExplosionData invExp
{
	shapeName = "plasmaex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 4.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};
GrenadeData INVNADE
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = invExp;
	collideWithOwner = true;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 1;
	damageValue = -100;
	explosionRadius = 1.8;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "plasmatrail.dts";
};

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
		for(%i=0; %i < 6.28; %i += 1.256) {
			%trans = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 " @ %i, 1.3, 1.2));
			Projectile::spawnProjectile("INVNADE", "0 0 1 0 0 0 0 0 1 " @ %trans, %player, "0 0 -2");
		}
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
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
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
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
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
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	if((Client::getOwnedObject(%client)).driver != 1) {
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
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = LiLPOOmki;
$NextWeapon[LiLPOOmki] = LiLPOOmkii;
$NextWeapon[LiLPOOmkii] = DiscLauncher;
$NextWeapon[DiscLauncher] = FireballAbility;
$NextWeapon[FireBallAbility] = SmScreenAbility;
$NextWeapon[SmScreenAbility] = ExSmScreenAbility;
$NextWeapon[ExSmScreenAbility] = FireScreenAbility;
$NextWeapon[FireScreenAbility] = SpellAbility;
$NextWeapon[SpellAbility] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LiLFFB;
$NextWeapon[LiLFFB] = LiLRocketLauncher;
$NextWeapon[LiLRocketLauncher] = LiLEMPRocketLauncher;
$NextWeapon[LiLEMPRocketLauncher] = LaserRifle;
$NextWeapon[LaserRifle] = TaserRifle;
$NextWeapon[TaserRifle] = BeamOfPain;
$NextWeapon[BeamOfPain] = EnergyRifle;

$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[LiLPOOmki] = Chaingun;
$PrevWeapon[LiLPOOmkii] = LiLPOOmki;
$PrevWeapon[DiscLauncher] = LiLPOOmkii;
$PrevWeapon[FireBallAbility] = DiscLauncher;
$PrevWeapon[SmScreenAbility] = FireBallAbility;
$PrevWeapon[ExSmScreenAbility] = SmScreenAbility;
$PrevWeapon[FireScreenAbility] = ExSmScreenAbility;
$PrevWeapon[SpellAbility] = FireScreenAbility;
$PrevWeapon[GrenadeLauncher] = SpellAbility;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LiLFFB] = Mortar;
$PrevWeapon[LiLRocketLauncher] = LiLFFB;
$PrevWeapon[LiLEMPRocketLauncher] = LiLRocketLauncher;
$PrevWeapon[LaserRifle] = LiLEMPRocketLauncher;
$PrevWeapon[TaserRifle] = LaserRifle;
$PrevWeapon[BeamOfPain] = TaserRifle;
$PrevWeapon[EnergyRifle] = BeamOfPain;



function remoteNextWeapon(%client)
{
	if(!(%client.observerMode == "" || %client.observerMode == "pregame"))
		return;

	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%co1 = Client::getControlObject(%client);
	%co = GameBase::getDataName(%co1);
	if(%co != Scout && %co != MercJet && %co != LAPC && %co != HAPC)
	{
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $NextWeapon[%item]; %weapon != %item;
					%weapon = $NextWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				}
			}
		}
	}
	else
		getNextVWeap(%client);
}

function remotePrevWeapon(%client)
{
	if(!(%client.observerMode == "" || %client.observerMode == "pregame"))
		return;

	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%co1 = Client::getControlObject(%client);
	%co = GameBase::getDataName(%co1);
	if(%co != Scout && %co != MercJet && %co != LAPC && %co != HAPC)
	{
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $PrevWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $PrevWeapon[%item]; %weapon != %item;
					%weapon = $PrevWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				}
			}
		}
	}
	else
		getPrevVWeap(%client);
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

// Default Item

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack) {
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}
  		else {
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
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
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
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
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",15, %item);
}

function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if(%item.className != Armor) {
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

function Flag::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Flag::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
} 
//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType = 2;   
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = true;
	lightType = 2;   
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
	lightType = 2;   
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
	description = "Light Armor Suit";
	className = "Armor";
	price = 0;
};

ItemData MediumArmor
{
   heading = $InvHead[ihArm];
	description = "Medium Armor Suit";
	className = "Armor";
	price = 0;
};

ItemData HeavyArmor
{
   heading = $InvHead[ihArm];
	description = "Heavy Armor Suit";
	className = "Armor";
	price = 0;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Brawler Assault";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 5000;
};

ItemData MercJetVehicle
{
	description = "Mercenary Jet-Bike";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 6000;
};

ItemData LAPCVehicle
{
	description = "Star Destroyer";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 6500;
};

ItemData HAPCVehicle
{
	description = "Hover Tank";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 7500;
};


//+++++++++++++++++++++++++++++++++++++
// Weapon Code
//+++++++++++++++++++++++++++++++++++++
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
	if(%player.Station==""){
		%ammo = %item.imageType.ammoType;
		if (%ammo == "") {
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


function HybridVector::rotVector(%vec,%rot)
{
	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";
	%basedis = Vector::getDistance( "0 0 0", %basevec);
	%normvec = Vector::normalize( %basevec );
	%baserot = Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );
	%newrot = Vector::add( %baserot, %rot );
	%newvec = Vector::getFromRot( %newrot, %basedis, %vec_z );

	return %newvec;
}
//----------------------------------------------------------------------------
ItemImageData LaserScopeImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
   	mountOffset = { 0, 0.08, 0.05 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData LaserScope
{
	description = "Laser Scope";
	className = "Scope";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = LaserScopeImage;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData LaserScope2Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
   	mountOffset = { 0, 0.08, 0.1 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 22.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData LaserScope2
{
	description = "Laser Scope2";
	className = "Scope";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = LaserScope2Image;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function LaserRifle::onMount(%player,%item)
{
	GameBase::setRechargeRate(%player,1750);
	Player::mountItem(%player,LaserScope,5);
	Player::mountItem(%player,LaserScope2,6);
}

function LaserRifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,5);  
	Player::unmountItem(%player,6); 
}
//----------------------------------------------------------------------------

ItemImageData TaserScopeImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0, 0.08, 0.05 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData TaserScope
{
	description = "Taser Scope";
	className = "Scope";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = TaserScopeImage;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData TaserScope2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0, 0.08, 0.1 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 22.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData TaserScope2
{
	description = "Taser Scope2";
	className = "Scope";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = TaserScope2Image;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData TaserRifleImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // 2,Sustained
        projectileType = TaserRfLaser;
        accuFire = true;
        minEnergy = 1;
        maxEnergy = 15;//brightness of beamhere
        reloadTime = 0.08;

        sfxFire     = SoundTaserFire;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundEnergyPackOn;
};

ItemData TaserRifle
{
        description   = "Taser Rifle";
        className     = "Weapon";
        shapeFile     = "sniper";
        hudIcon       = "sniper";
   heading = $InvHead[ihWea];
        shadowDetailMask = 4;
        imageType     = TaserRifleImage;
        price         = 0;
        showWeaponBar = true;
};

function TaserRifle::onMount(%player,%item)
{
	GameBase::setRechargeRate(%player,2750);
	Player::mountItem(%player,TaserScope,5);
	Player::mountItem(%player,TaserScope2,6);
}

function TaserRifle::onUnmount(%player,%imageSlot)
{
 	Player::unmountItem(%player,5);  
	Player::unmountItem(%player,6); 
}
//--------------------------------------
ItemImageData FireballAbilityImage
{
	shapeFile = "plasmatrail";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = Fireball;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundJetHeavy;
        sfxActivate = SoundPickUpWeapon;
};

ItemData FireballAbility
{
	description = "Solar Flare";
	className = "Weapon";
	shapeFile = "plasmatrail";
	hudIcon = "fear";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = FireballAbilityImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function FireballAbilityImage::onFire(%player, %slot) 
{		
		 	 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %armor = Player::getArmor(%player);
			 %los = GameBase::getLOSInfo(%player,3000);
			 %pos = $los::position;
			 %trans = GameBase::getMuzzleTransform(%player);
		       	 %vel = Item::getVelocity(%player);
					%fired = (Projectile::spawnProjectile("solarBurst1",%trans,%player,%vel));	%fired.deployer = %client;
					%fired = (Projectile::spawnProjectile("solarBurst2",%trans,%player,%vel));	%fired.deployer = %client;
}
//--------------------------------------
ItemImageData SmScreenAbilityImage
{
	shapeFile = "breath";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SmScreen;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundJetHeavy;
                     sfxActivate = SoundPickUpWeapon;
};

ItemData SmScreenAbility
{
	description = "Noxious Gas";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "fear";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = SmScreenAbilityImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

//--------------------------------------
ItemImageData ExSmScreenAbilityImage
{
	shapeFile = "enbolt";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = ExSmScreen;
        accuFire = true;
        reloadTime = 2.75;
        fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundJetHeavy;
                     sfxActivate = SoundPickUpWeapon;
};

ItemData ExSmScreenAbility
{
	description = "Split Waster";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "fear";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = ExSmScreenAbilityImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function ExSmScreenAbilityImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);

 		%newObj = Projectile::spawnProjectile("NapShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("NapSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("NapFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
		}
	deleteobject(%newObj);
	}
}

//--------------------------------------
ItemImageData FireScreenAbilityImage
{
	shapeFile = "plasmabolt";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = firebomb;
	accuFire = true;
  	reloadtime = 2.1;
  	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	sfxFire = SoundJetHeavy;
        sfxActivate = SoundPickUpWeapon;
};

ItemData FireScreenAbility
{
	description = "Hell Fire";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "fear";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = FireScreenAbilityImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

//----------------------------------------------------------------------------

ItemImageData SpellAbilityImage
{
	shapeFile = "breath";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = SpellAbilityproj1-5;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundJetHeavy;
                     sfxActivate = SoundPickUpWeapon;
};

ItemData SpellAbility
{
	description = "Confusion Spell";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "fear";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = SpellAbilityImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function SpellAbilityImage::onFire(%player, %slot) 
{ 
	   %trans = GameBase::getMuzzleTransform(%player); 
	   %vel = Item::getVelocity(%player);
	   	Projectile::spawnProjectile("SpellAbilityproj1",%trans,%player,%vel);
	   	Projectile::spawnProjectile("SpellAbilityproj2",%trans,%player,%vel); 
}
//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = $InvHead[ihWea];
	description = "Energy Pistol";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 0;
	showWeaponBar = true;
};

function BlasterImage::onFire(%player, %slot)
{
		 %clientId = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		
		 Projectile::spawnProjectile("GrBlasterBolt",%trans,%player,%vel);

		 %vel = HybridVector::rotVector( "5 0 -5", GameBase::getRotation(%player));
		 Projectile::spawnProjectile("GrBlasterBolt",%trans,%player,%vel);

		 %vel = HybridVector::rotVector( "-5 0 -5", GameBase::getRotation(%player));
		 Projectile::spawnProjectile("GrBlasterBolt",%trans,%player,%vel);

		 %vel = HybridVector::rotVector( "0 2 5", GameBase::getRotation(%player));
		 Projectile::spawnProjectile("GrBlasterBolt",%trans,%player,%vel);
}
//----------------------------------------------------------------------------
ItemImageData Chaingun2Image
{
	shapeFile = "Sniper";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Chaingun2
{
	description = "Chaingun2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Chaingun2Image;
	showWeaponBar = false;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Chaingun
{
	description = "Verminator";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function Chaingun::onMount(%player,%item)
{
	Player::mountItem(%player,Chaingun2,5);
}

function ChaingunImage::onFire(%player, %slot) 
{ 
	   %trans = GameBase::getMuzzleTransform(%player); 
	   %vel = Item::getVelocity(%player);
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
 	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
}

function Chaingun::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,5);  
}
//----------------------------------------------------------------------------

ItemImageData SniperScopeImage
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SniperScope
{
	description = "SniperScope";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = SniperScopeImage;
	showWeaponBar = false;
};

ItemImageData LiLPOOmkiImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = LiLPOOmkiBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LiLPOOmki
{
	description = "Sniper MKI";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLPOOmkiImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function LiLPOOmki::onMount(%player,%item)
{
	Player::mountItem(%player,SniperScope,7);
}

function LiLPOOmki::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//----------------------------------------------------------------------------
ItemImageData Burst3Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { -0.02, -0.04, -0.02 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.57, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Burst3
{
	description = "Burst3";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = Burst3Image;
	showWeaponBar = false;
};

ItemImageData LiLPOOmkiiImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.1, -0.08 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right

	weaponType = 0; // Single Shot
	projectileType = LiLPOOmkiiBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundLiLPOOmkii;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LiLPOOmkii
{
	description = "Sniper MKII";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLPOOmkiiImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function LiLPOOmkii::onMount(%player,%item)
{
	Player::mountItem(%player,Burst3,7);
}

function LiLPOOmkii::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//----------------------------------------------------------------------------
ItemImageData Plasmagun2Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Plasmagun2
{
	description = "Plasmagun2";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Plasmagun2Image;
	showWeaponBar = false;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function PlasmaGun::onMount(%player,%item)
{
	Player::mountItem(%player,plasmagun2,7);
}

function PlasmaGun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

//----------------------------------------------------------------------------

ItemImageData Cluster1Image
{
	shapeFile = "grenAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 3.1, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Cluster1
{
	description = "Cluster1";
	className = "Weapon";
	shapeFile = "grenAmmo";
	shadowDetailMask = 4;
	imageType = Cluster1Image;
	showWeaponBar = false;
};

ItemImageData Cluster2Image
{
	shapeFile = "grenAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 3.1, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Cluster2
{
	description = "Cluster2";
	className = "Weapon";
	shapeFile = "grenAmmo";
	shadowDetailMask = 4;
	imageType = Cluster2Image;
	showWeaponBar = false;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };

	weaponType = 0; 
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.2;
	minEnergy = 1;
	maxEnergy = 0.1;
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GrenadeLauncher
{
	description = "Cluster Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function GrenadeLauncher::onMount(%player,%item)
{
	Player::mountItem(%player,Cluster1,5);
	Player::mountItem(%player,Cluster2,6);
}

function GrenadeLauncher::onUnmount(%player,%imageSlot)
{ 
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6); 
}

function GrenadeLauncherImage::onFire(%this) 
{
   %client = GameBase::getOwnerClient(%this);
   %trans = GameBase::getMuzzleTransform(%this);
   %vel = Item::getVelocity(%this);
   for(%i=0; %i < 5; %i++) 
		{
		%xrnd = floor(getRandom() *10)/100 -0.05;
		%yrnd = floor(getRandom() *10)/100 -0.05;
		%zrnd = floor(getRandom() *10)/100 -0.05;
		%trans1= getWord(%trans,0);
		%trans2= getWord(%trans,1);
		%trans3= getWord(%trans,2);
		%trans4= getWord(%trans,3) + %xrnd;
		%trans5= getWord(%trans,4) + %yrnd;
		%trans6= getWord(%trans,5) + %zrnd;
		%trans7= getWord(%trans,6);
		%trans8= getWord(%trans,7);
		%trans9= getWord(%trans,8);
		%trans10=getWord(%trans,9);
		%trans11=getWord(%trans,10);
		%trans12=getWord(%trans,11);
		
		%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;

		Projectile::spawnProjectile("ClusterShell", %NewTrans, %this, %vel);

	}
}

//----------------------------------------------------------------------------
ItemImageData MortarCoreImage
{
	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.22 };
	mountRotation = { 0,  1.57, 1.57}; 
};

ItemData MortarCore
{
	description = "Mortar Core";
	className = "Weapon";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	imageType = MortarCoreImage;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
        mountOffset = { 0, 0, -0.2};
	weaponType = 0; // Single Shot
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Mortar
{
	description = "Fusion Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function Mortar::onMount(%player,%item)
{
	Player::mountItem(%player, MortarCore, 7);
}

function Mortar::onUnmount(%player,%item)
{
	Player::unmountItem(%player, 7);
}
//----------------------------------------------------------------------------

ItemImageData LiLFFBImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 };
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.25;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundFireGrenade; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReady = SoundMortarIdle;
};

ItemData LiLFFB
{
	description = "ForceField Buster";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLFFBImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function LiLFFBImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("FFBShell1",%trans,%player,%vel);
	Projectile::spawnProjectile("FFBShell2",%trans,%player,%vel);
}

//--------------------------------------------------------------

ItemImageData LiLRocketLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 }; 		// ?, around gun barrel, ?
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

       sfxActivate = SoundMortarTurretTurn; 
       sfxReload = SoundMortarTurretOn;
       sfxReady = SoundMineActivate; 
};

ItemData LiLRocketLauncher
{
	description = "RPG Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLRocketLauncherImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function LiLRocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("LiLRocketRPG",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("LiLRocket",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("LiLRocketSubmission",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("LiLRocketalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("LiLRocketalt",%trans,%player,%vel);  
} 


//--------------------------------------------------------------

ItemImageData LiLEMPRocketLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
mountOffset = { 0.0, 0.0, -0.2 };
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundEMPfire;
                     sfxActivate = SoundPickUpWeapon;
};

ItemData LiLEMPRocketLauncher
{
	description = "EMP Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLEMPRocketLauncherImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function LiLEMPRocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("LiLEMPRocketONE",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("LiLEMPRocketTWO",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("LiLEMPRocketalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("LiLEMPRocketalt",%trans,%player,%vel);  
} 

//--------------------------------------------------------------
ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.02;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

//--------------------------------------------------------------
ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 1;
	reloadTime = 0.1;

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
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 0;
	showWeaponBar = false;
};

//------------------------------------------------------------------------------

ItemImageData BeamOfPainImage
{
	shapeFile = "shotgun";
   mountPoint = 0;
       mountoffset = { 0, 0, -0.2 };
       mountrotation = { 0, 3, 0 };
   weaponType = 2;  // Sustained
	projectileType = BeamOfPainProj;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.03;
                     
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFFire;
};

ItemData BeamOfPain
{
   description = "Beam Of Pain";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = BeamOfPainImage;
	showWeaponBar = true;
   price = 0;
   validateShape = true;
};

//--------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;
mountRotation = { 0, 0.785, 0 };
   weaponType = 2;  // Sustained
	projectileType = cloakingCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.08;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 3;
   lightTime = 1;
   lightColor = { 0.15, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "Cloak Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 0;
   validateShape = true;
};

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
	price = 0;
   validateShape = true;
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

// ========================================================
// W E I G H T  &  M A S S  M A N I P U L A T I O N
// ========================================================

ItemData Weight
{				
	description = "";
	className = "Tool";
	showInventory = false;
};

function Weight::onDrop(%player, %item){}
function Weight::onUse(%player, %item){}

ItemImageData DeadWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = 90000.0;
};

ItemData DeadWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = DeadWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = 90000.0;
	showInventory = false;
};

ItemImageData LessWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -2.0;
};

ItemData LessWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = -2.0;
	showInventory = false;
};

ItemImageData LessWeight2Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -4.0;
};

ItemData LessWeight2
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeight2Image;
	price = 0;
	showWeaponBar = false;
	mass = -4.0;
	showInventory = false;
};
//----------------------------------------------------------------------------
// Turrets/Deps
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
   heading = $InvHead[ihBfe];
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		%Set = newObject("set",SimSet);
	        %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
		%inbase= true;
		break;
		}
	}
		deleteObject(%Set);
		if(%inbase)
                {
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
		if(checkDeployArea(%client,$los::position)) {
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
		bottomprint(%client,"<jc>Deffence Bonus: 2 points");
		%client.score = (%client.score +2);
		Game::refreshClientScore(%playerId);
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
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
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


//----------------------------------------------------------------------------

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
   heading = $InvHead[ihBfe];
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		%Set = newObject("set",SimSet);
		%Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
		%inbase= true;
		break;
		}
	}
		deleteObject(%Set);
		if(%inbase)
                {
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
		if(checkDeployArea(%client,$los::position)) {
		%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
	        addToSet("MissionCleanup", %inv);
		%rot = GameBase::getRotation(%player); 
		GameBase::setTeam(%inv,GameBase::getTeam(%player));
		GameBase::setPosition(%inv,$los::position);
		GameBase::setRotation(%inv,%rot);
		Gamebase::setMapName(%inv,%name);
		Client::sendMessage(%client,0,"Ammo Station deployed");
		bottomprint(%client,"<jc>Deffence Bonus: 2 points");
		%client.score = (%client.score +2);
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
					bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
	}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}
//--------------------------------------

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
   heading = $InvHead[ihBkp];
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 0;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
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
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


//----------------------------------------------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 18;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = $InvHead[ihBkp];
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 0;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.008;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}


//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 18;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "StealthShield Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = $InvHead[ihBkp];
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 0;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
	%player.shieldStrength = 0.008;
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
	%player.shieldStrength = 0;
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 18;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloaking Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHead[ihBkp];
	shadowDetailMask = 4;
	imageType = CloakingDeviceImage;
	price = 0;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
 	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
 	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	%rate = Player::getSensorSupression(%player) - 3;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------------------------

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
	description = "Motion Sen. Network";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
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

function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					Gamebase::setMapName(%mSensor,"Motion Sensor Network");
					Client::sendMessage(%client,0,"Motion Sensor Network deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor Network");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
					bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
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

//----------------------------------------------------------------------------

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
	description = "Pulse Sen. Network";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
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


//----------------------------------------------------------------------------

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
	description = "Sen. Jammer Network";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 0;
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


//----------------------------------------------------------------------------


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
	description = "Spy Camera Network";
	shapeFile = "camera";
	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
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
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					Gamebase::setMapName(%camera,"Spy Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Spy Camera deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Spy Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
						
					bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
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

//--------------																			
ItemImageData LaserTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Laser Turret System";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LaserTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
		%Set = newObject("set",SimSet);
                %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		        %thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{
			       %inbase= true;
			       break;
			}
                }
		deleteObject(%Set);
		if(%inbase)
                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
                        {
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"LaserTurret",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num) {
		    	%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"LaserTurret",%num);
			deleteObject(%set);
			if(0 == %num) 
                {
			if (Vector::dot($los::normal,"0 0 1") > 0.7) {
			if(checkDeployArea(%client,$los::position)) {
			%rot = GameBase::getRotation(%player); 
			%turret = newObject("remoteTurret","Turret",LaserTurret,true);
	                addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Gamebase::setMapName(%turret,"Laser Turret System#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Laser Turret System deployed");
			bottomprint(%client,"<jc>Deffence Bonus: 2 points");
			%client.score = (%client.score +2);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
			echo("MSG: ",%client," deployed a Laser Turret System");
			Client::setOwnedObject(%client, %turret); 
			Client::setOwnedObject(%client, %player);
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
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	        }
	        else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}






//----------------------------------------------------------------------------
																			
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
	description = "Sentry Turret System";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
		%Set = newObject("set",SimSet);
                %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		        %thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{
			       %inbase= true;
			       break;
			}
                }
		deleteObject(%Set);
		if(%inbase)
                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
                        {
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"LaserTurret",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num) {
		    	%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"LaserTurret",%num);
			deleteObject(%set);
			if(0 == %num) 
                {
			if (Vector::dot($los::normal,"0 0 1") > 0.7) {
			if(checkDeployArea(%client,$los::position)) {
			%rot = GameBase::getRotation(%player); 
			%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Gamebase::setMapName(%turret,"Sentry Turret System#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Sentry Turret System deployed");
			bottomprint(%client,"<jc>Deffence Bonus: 2 points");
			%client.score = (%client.score +2);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
			echo("MSG: ",%client," deployed a Sentry Turret System");
			Client::setOwnedObject(%client, %turret); 
			Client::setOwnedObject(%client, %player);
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
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	        }
	        else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


//------------------------------------------------------------------------------------

ItemImageData 	TaserTrtBPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TaserTrtBPack
{
        description = "Taser Turret System";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihTur];
        imageType = TaserTrtBPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function TaserTrtBPack::onUse(%player,%item)
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

function TaserTrtBPack::onDeploy(%player,%item,%pos)
{
        if (TaserTrtBPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function TaserTrtBPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
		%Set = newObject("set",SimSet);
                %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		        %thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{
			       %inbase= true;
			       break;
			}
                }
		deleteObject(%Set);
		if(%inbase)
                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
                        {
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"DeployableTaserTrtB",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num) {
		    	%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"DeployableTaserTrtB",%num);
			deleteObject(%set);
			if(0 == %num) 
                {
			if (Vector::dot($los::normal,"0 0 1") > 0.7) {
			if(checkDeployArea(%client,$los::position)) {
			%rot = GameBase::getRotation(%player); 
			%turret = newObject("Camera","Turret",DeployableTaserTrtB,true);
	                addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Gamebase::setMapName(%turret,"Taser Turret System#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Taser Turret System deployed");
			bottomprint(%client,"<jc>Deffence Bonus: 2 points");
			%client.score = (%client.score +2);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "TaserTrtBPack"]++;
			echo("MSG: ",%client," deployed a Taser Turret System");
			Client::setOwnedObject(%client, %turret); 
			Client::setOwnedObject(%client, %player);
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
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	        }
	        else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//-------------------------------------------------

ItemImageData 	TaserTrtCPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TaserTrtCPack
{
        description = "Scan Tracking Network";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihSen];
        imageType = TaserTrtCPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function TaserTrtCPack::onUse(%player,%item)
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

function TaserTrtCPack::onDeploy(%player,%item,%pos)
{
        if (TaserTrtCPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function TaserTrtCPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
		%Set = newObject("set",SimSet);
                %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		        %thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{
			       %inbase= true;
			       break;
			}
                }
		deleteObject(%Set);
		if(%inbase)
                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
                        {
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"DeployableTaserTrtC",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num) {
		    	%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"DeployableTaserTrtC",%num);
			deleteObject(%set);
			if(0 == %num) 
                {
			if (Vector::dot($los::normal,"0 0 1") > 0.7) {
			if(checkDeployArea(%client,$los::position)) {
			%rot = GameBase::getRotation(%player); 
			%turret = newObject("Camera","Turret",DeployableTaserTrtC,true);
	                addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Gamebase::setMapName(%turret,"Scan Tracking Network#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Scan Tracking Network deployed");
			bottomprint(%client,"<jc>Deffence Bonus: 2 points");
			%client.score = (%client.score +2);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "TaserTrtCPack"]++;
			echo("MSG: ",%client," deployed a Scan Tracking Network");
			Client::setOwnedObject(%client, %turret); 
			Client::setOwnedObject(%client, %player);
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
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	        }
	        else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//----------------------------------------------------------------------------
																			
ItemImageData LaserTurretBPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretBPack
{
	description = "Plasma Turret System";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = LaserTurretBPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretBPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretBPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretBPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function LaserTurretBPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%turret = newObject("remoteTurret","Turret",LaserTurretB,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Plasma Turret System#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Plasma Turret System deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "LaserTurretBPack"]++;
					echo("MSG: ",%client," deployed a Plasma Turret System");
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
					}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
		 
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

//---------------------------------------------

ItemImageData MiniFlakTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniFlakTurretPack
{
	description = "Flak Turret System";
	shapeFile = "mortar_turret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniFlakTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniFlakTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniFlakTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniFlakTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function MiniFlakTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%turret = newObject("remoteTurret","Turret",MiniFlakTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"FlakTurret System#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Flak Turret System deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniFlakTurretPack"]++;
					echo("MSG: ",%client," deployed a Flak Turret System");
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
		 
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


//----------------------------------------------------------------------------

ItemImageData MiniSAMTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniSAMTurretPack
{
	description = "S.A.M Turret System";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniSAMTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniSAMTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniSAMTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniSAMTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function MiniSAMTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%turret = newObject("remoteTurret","Turret",MiniSAMTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"S.A.M Turret System#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"S.A.M Turret System deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniSAMTurretPack"]++;
					echo("MSG: ",%client," deployed a S.A.M Turret System");
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
		 
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

//-------------------------------------

ItemImageData MiniGripTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniGripTurretPack
{
	description = "GRIP Turret System";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniGripTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniGripTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniGripTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniGripTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function MiniGripTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%turret = newObject("remoteTurret","Turret",MiniGripTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"GRIP Turret System#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"GRIP Turret System deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniGripTurretPack"]++;
					echo("MSG: ",%client," deployed a GRIP Turret System");
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
			}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
		 
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

//----------------------------------------------------------------------------

ItemImageData 	MiniELFTurretPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData MiniELFTurretPack
{
        description = "ELF Turret System";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihTur];
        imageType = MiniELFTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MiniELFTurretPack::onUse(%player,%item)
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

function MiniELFTurretPack::onDeploy(%player,%item,%pos)
{
        if (MiniELFTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function MiniELFTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%elfturret = newObject("camera","Turret",MiniELFTurret,true);
	   	      addToSet("MissionCleanup", %elfturret);
					GameBase::setTeam(%elfturret,GameBase::getTeam(%player));
					GameBase::setRotation(%elfturret,%rot);
					GameBase::setPosition(%elfturret,$los::position);
					Gamebase::setMapName(%elfturret,"ELF Turret System#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"ELF Turret System deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%elfturret) @ "MiniELFTurretPack"]++;
					echo("MSG: ",%client," deployed a ELF Turret System");
					Client::setOwnedObject(%client, %elfturret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//----------------------------------------------------------------------------


ItemImageData 	MiniSmokeTurretPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData MiniSmokeTurretPack
{
        description = "B.o.P Turret System";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihTur];
        imageType = MiniSmokeTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MiniSmokeTurretPack::onUse(%player,%item)
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

function MiniSmokeTurretPack::onDeploy(%player,%item,%pos)
{
        if (MiniSmokeTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function MiniSmokeTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%elfturret = newObject("camera","Turret",MiniSmokeTurret,true);
	   	      addToSet("MissionCleanup", %elfturret);
					GameBase::setTeam(%elfturret,GameBase::getTeam(%player));
					GameBase::setRotation(%elfturret,%rot);
					GameBase::setPosition(%elfturret,$los::position);
					Gamebase::setMapName(%elfturret,"B.o.P Turret System#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"B.o.P Turret System deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%elfturret) @ "MiniSmokeTurretPack"]++;
					echo("MSG: ",%client," deployed a B.o.P Turret System");
					Client::setOwnedObject(%client, %elfturret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//-------------|Electric Web By: Arma|----- 
ItemImageData ElectricWebImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };//1.57
	firstPerson = false;
};

ItemData ElectricWeb
{
	description = "Electric Web";
	shapeFile = "display_three";
	className = "Backpack";
      heading = $InvHead[ihTur];
	imageType = ElectricWebImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectricWeb::onUse(%player,%item)
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

function ElectricWeb::onDeploy(%player,%item,%pos)
{
	if (ElectricWeb::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ElectricWeb::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                %playerPos = GameBase::getPosition(%player);
                %deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2");
                %rot = Vector::add(GameBase::getRotation(%player), "0 1.57 1.57");
                %inv = newObject("Electric Web","Turret","PlasmaDoorTurr",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,%deploypos);
                Gamebase::setMapName(%inv,"Electric Web" @  Client::getName(%client));
                Client::setOwnedObject(%client, %inv); 
                Client::setOwnedObject(%client, %player);
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "ElectricWeb"]++;
                Client::sendMessage(%client,0,"Electric Web is spun.~wlightning_idle.wav");
		bottomprint(%client,"<jc>Deffence Bonus: 2 points");
		%client.score = (%client.score +2);
      
        }

}
//----------------------------------------------------------------------------

ItemImageData lgaForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData lgaForceFieldPack
{
        description = "Lrg A: Force Field";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihDef];
        imageType = lgaForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function lgaForceFieldPack::onUse(%player,%item)
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

function lgaForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (lgaForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function lgaForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("lgaForceFieldPack","StaticShape",lgaForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "lgaForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------

ItemImageData lgbForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData lgbForceFieldPack
{
        description = "Lrg B: Force Field";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihDef];
        imageType = lgbForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function lgbForceFieldPack::onUse(%player,%item)
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

function lgbForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (lgbForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function lgbForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("lgbForceFieldPack","StaticShape",lgbForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "lgbForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medaForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medaForceFieldPack
{
        description = "Med A: Force Field";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihDef];
        imageType = medaForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medaForceFieldPack::onUse(%player,%item)
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

function medaForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medaForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medaForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medaForceFieldPack","StaticShape",medaForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medaForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        
                        else
									                                         
									                                         
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                        
                }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medbForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medbForceFieldPack
{
        description = "Med B: Force Field";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihDef];
        imageType = medbForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medbForceFieldPack::onUse(%player,%item)
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

function medbForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medbForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medbForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medbForceFieldPack","StaticShape",medbForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medbForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medcForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medcForceFieldPack
{
        description = "Med C: Force Field";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihDef];
        imageType = medcForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medcForceFieldPack::onUse(%player,%item)
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

function medcForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medcForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medcForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {
                

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medcForceFieldPack","StaticShape",medcForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medcForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        
                        else
									                                         
									                                        
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

//----------------------------------------------------------------------------
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
	description = "Teleport Station";
	shapeFile = "flagstand";
	className = "Backpack";
    heading = $InvHead[ihBfe];
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 0;
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
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) {
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
								%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {

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
		 bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
		}

		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

// =========================
// Devices
// =========================

ItemImageData ArbitorBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData ArbitorBeaconPack
{
	description = "Cloak Device";
	shapeFile = "plasammo";
	className = "Backpack";
   	heading = $InvHead[ihBfe];
	imageType = ArbitorBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ArbitorBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Cloak Device Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ArbitorBeaconPack::onDeploy(%player,%item,%pos)
{
	if (ArbitorBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ArbitorBeaconPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%Device = newObject("remoteTurret","Turret",ArbitorBeacon,true);
	   	      addToSet("MissionCleanup", %Device);
					GameBase::setTeam(%Device,GameBase::getTeam(%player));
					GameBase::setRotation(%Device,%rot);
					GameBase::setPosition(%Device,$los::position);
					Gamebase::setMapName(%Device,"Cloak Device#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Cloak Device deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%Device) @ "ArbitorBeaconPack"]++;
					echo("MSG: ",%client," deployed a Cloak Device");
					Client::setOwnedObject(%client, %Device); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//==================================
ItemImageData EMPBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData EMPBeaconPack
{
	description = "Flux Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = $InvHead[ihBfe];
	imageType = EMPBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function EMPBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Flux Device Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function EMPBeaconPack::onDeploy(%player,%item,%pos)
{
	if (EMPBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function EMPBeaconPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%Device = newObject("remoteTurret","Turret",EMPBeacon,true);
	   	      addToSet("MissionCleanup", %Device);
					GameBase::setTeam(%Device,GameBase::getTeam(%player));
					GameBase::setRotation(%Device,%rot);
					GameBase::setPosition(%Device,$los::position);
					Gamebase::setMapName(%Device,"Flux Device#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Flux Device deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%Device) @ "EMPBeaconPack"]++;
					echo("MSG: ",%client," deployed a Flux Device");
					Client::setOwnedObject(%client, %Device); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//========================jamm'in Beacon
ItemImageData JammerBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData JammerBeaconPack
{
	description = "Jammer Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = $InvHead[ihBfe];
	imageType = JammerBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JammerBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Jammer Device Has A 250m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function JammerBeaconPack::onDeploy(%player,%item,%pos)
{
	if (JammerBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function JammerBeaconPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%sensor = newObject("","Sensor",jammerbeacon,true);
	   	      addToSet("MissionCleanup", %sensor);
					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					GameBase::setRotation(%sensor,%rot);
					GameBase::setPosition(%sensor,$los::position);
					Gamebase::setMapName(%sensor,"Jammer Device#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Jammer Device deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%sensor) @ "JammerBeaconPack"]++;
					echo("MSG: ",%client," deployed a Jammer Device");
					Client::setOwnedObject(%client, %sensor); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//==================================
ItemImageData ShieldBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData ShieldBeaconPack
{
	description = "Shield Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = $InvHead[ihBfe];
	imageType = ShieldBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ShieldBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Shield Device Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ShieldBeaconPack::onDeploy(%player,%item,%pos)
{
	if (ShieldBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShieldBeaconPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%Device = newObject("remoteTurret","Turret",ShieldBeacon,true);
	   	      addToSet("MissionCleanup", %Device);
					GameBase::setTeam(%Device,GameBase::getTeam(%player));
					GameBase::setRotation(%Device,%rot);
					GameBase::setPosition(%Device,$los::position);
					Gamebase::setMapName(%Device,"Shield Device#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Shield Device deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%Device) @ "ShieldBeaconPack"]++;
					echo("MSG: ",%client," deployed a Shield Device");
					Client::setOwnedObject(%client, %Device); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//========================Healing Device

ItemImageData HealBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
   	mountOffset = { 0, 0.0, 0.0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData HealBeaconPack
{
	description = "Healing Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = $InvHead[ihBfe];
	imageType = HealBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HealBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HealBeaconPack::onDeploy(%player,%item,%pos)
{
	if (HealBeaconPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HealBeaconPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%Device = newObject("","staticshape",HealBeacon,true);
	   	      addToSet("MissionCleanup", %Device);
					GameBase::setTeam(%Device,GameBase::getTeam(%player));
					GameBase::setRotation(%Device,%rot);
					GameBase::setPosition(%Device,$los::position);
					Gamebase::setMapName(%Device,"Heal Device#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Heal Device deployed");
					bottomprint(%client,"<jc>Deffence Bonus: 2 points");
					%client.score = (%client.score +2);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%Device) @ "HealBeaconPack"]++;
					echo("MSG: ",%client," deployed a Heal Device");
					Client::setOwnedObject(%client, %Device); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//----------------------------------------------------------------------------
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
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
						bottomprint(%client,"<jc>Deffence Bonus: 2 points");
						%client.score = (%client.score +2);
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
   heading = $InvHead[ihUpg];
   shadowDetailMask = 4;
   price = 0;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	GameBase::repairDamage(%player,0.99);
}

//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvHead[ihUpg];
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function MineAmmo::onUse(%player,%item)
{
        if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                        %obj = newObject("","Mine","antipersonelMine");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.5;
                  GameBase::setTeam (%obj,GameBase::getTeam (%client));
                }
        }
}

//---------------------------------------------------------------------------
ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = $InvHead[ihUpg];
   shadowDetailMask = 4;
   price = 0;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
  if($matchStarted) 
     {
	  %client = Player::getClient(%player);	
          %velocity = Item::getVelocity(%player);
    	  %velX = getWord(%velocity, 0);
    	  %velY = getWord(%velocity, 1);
	  %velZ = getWord(%velocity, 2);
	  %velXa = %velX / 6;
	  %velYa = %velY / 6;
	  %velZa = %velZ / 6;
	  Item::setVelocity(%player, %velXa @ " " @ %velYa @ " " @ %velZa);
	}
}

//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = $InvHead[ihUpg];
   shadowDetailMask = 4;
   price = 0;
        className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
  if($matchStarted) 
{
                if(%player.throwTime < getSimTime() ) {
                        %obj = newObject("","Mine","boost");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,0,false);
                        %player.throwTime = getSimTime() + 0.15;
                }
        }
}

//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = $InvHead[ihUpg];
	shadowDetailMask = 4;
  	price = 0;
   validateShape = true;
   validateMaterials = true;
};


function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.5);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	GameBase::repairDamage(%player,0.1);
}

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

      		Player::setItemCount(%clientId,Grenade, 1);
      		Player::setItemCount(%clientId,MineAmmo, 1);
		Player::setItemCount(%clientId,Beacon,  1);

		Player::setItemCount(%clientId,RepairKit,1);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);

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
// VX6
function recountitem(%itemname)
{
	if ($debug) echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 8 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}

function Mission::reinitData()
{
        // Ammo-Inv-Transport Systems
	recountitem("DeployableAmmoPack");
	recountitem("DeployableInvPack");
	recountitem("DeployableTeleport");
        // Turret Systems
	recountitem("TurretPack");
	recountitem("LaserTurretPack");
	recountitem("LaserTurretBPack");
	recountitem("TaserTrtBPack");
	recountitem("TaserTrtCPack");
	recountitem("MiniFlakTurretPack");
	recountitem("MiniSAMTurretPack");
	recountitem("MiniELFTurretPack");
	recountitem("MiniSmokeTurretPack");
	recountitem("MiniGRIPTurretPack");
	recountitem("ElectricWeb");
        // Defence Equiptment
        recountitem("lgaForceFieldPack");
	recountitem("lgbForceFieldPack");
	recountitem("medaForceFieldPack");
	recountitem("medbForceFieldPack");
	recountitem("medcForceFieldPack");
        // Sensor Networks
	recountitem("CameraPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("PulseSensorPack");
	recountitem("MotionSensorPack");
        // Devices
	recountitem("ArbitorBeaconPack");
	recountitem("EMPBeaconPack");
	recountitem("JammerBeaconPack");
	recountitem("ShieldBeaconPack");
	recountitem("HealBeaconPack");
        // Vehicles
	recountitem("ScoutVehicle");
	recountitem("MercJetVehicle");
	recountitem("LAPCVehicle");
	recountitem("HAPCVehicle");
        // Misc
	recountitem("Beacon");
	recountitem("mineammo");

	$totalNumCameras = 0;
	$totalNumTurrets = 0;


	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

//----------------------------------------------------------------------------------------------------------------------------------------------
// Music That Fueled This Project: Fear Factor, American Head Charge, Nirvana, MisFiTs, DanZig, As I Lay Dying, Chimera & MUDVAYNE!  (Armageddon)
//----------------------------------------------------------------------------------------------------------------------------------------------