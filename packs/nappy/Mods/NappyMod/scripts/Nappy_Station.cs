
function Station::getTarget(%this)
{
	if(%this.clientStation){
		%pos = GameBase::getPosition(%this.playerInBuilderStation);
		if(%pos == %this.playerInBuilderStation.StationPos){
			return %this.playerInBuilderStation;
		}
		else
			Nappy::ClientStation::Reset(%this.playerInBuilderStation, %this);
	}
	if(GameBase::getLOSInfo(%this,1.5,"0 0 3.14")) {
	  	// GetLOSInfo sets the following globals:
	  	// 	los::position
	  	// 	los::normal
	  	// 	los::object
	  	%obj = getObjectType($los::object);
		//dbecho(3, "STATION: LOS got " @ %obj);
	  	if(%obj == "Player"){
			if(Player::isAiControlled($los::object) != "True"){
				return $los::object;
			}
		}
	}
	//dbecho(3, "STATION: LOS Got None");
	return -1;
}	




function Station::onEndSequence(%this,%thread)
{
	//echo("End sequence " @ %this);
 	if (%thread == 1 && GameBase::isActive(%this)) {
		GameBase::playSequence(%this,2,"use");
		return true;
	}
	%client = %this.target;
	if(%client == "") {
		%player = Station::getTarget(%this);
		%client = Player::getClient(%player);
	}
	if(%client != "") {
		if(Client::getGuiMode(%client) != 1)
			Client::setGuiMode(%client,1);
		
		%team = Client::getTeam(%client);
		if($TeamEnergy[%team] != "Infinite") {
			if(%this.clTeamEnergy != %client.TeamEnergy) {
				if(%client.teamEnergy < 0)
					Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
				else
					Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
			}
			if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0) && !$TeamEnergyCheat) {
				TeamMessages(0, %team, "Teammate " @ Nappy::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)  
				TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]); 
		}
	}
	if(%this.target != "") {
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
		VehiclePad::checkSeq(%this.vehiclePad, %this);
	%this.clTeamEnergy = "";
	return false;
}








//----------------------------------------------------------------------------
// Deployable stations

function DeployableStation::onActivate(%this)
{
	//echo("Activate " @ %this);
	%obj = Station::getTarget(%this);
	if (%obj != -1) {
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else 
		GameBase::setActive(%this,false);
}


function DeployableStation::onEndSequence(%this,%thread)
{
   if(!%thread) {
		%this.deployed = 1;
		GameBase::playSequence(%this,2,"power");
	}
}

function DeployableStation::deploy(%this)
{
	GameBase::playSequence(%this,0,"deploy");
}

function DeployableStation::onDeactivate(%this)
{
	//echo("Dectivate " @ %this);
	GameBase::stopSequence(%this,1);
}

function DeployableStation::onEnabled(%this)
{
	GameBase::playSequence(%this,2,"power");
}

function DeployableStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::stopSequence(%this,1);
	Station::checkTarget(%this);
}

function DeployableStation::onDestroyed(%this)
{
	DeployableStation::onDisabled(%this);
	%stationName = GameBase::getDataName(%this);

	if(%stationName == DeployableInvStation) 
    	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
	else if( %stationName == DeployableAmmoStation) 
	  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 
		0.1, 200, 100); 
	Station::weaponCheck(%this);
}

function DeployableStation::onCollision(%this, %object)
{
	//echo("Collision (" @ %this @ "," @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  	 	%client = Player::getClient(%object);
		if((GameBase::getTeam(%object) == GameBase::getTeam(%this) && GameBase::getTeam(%object) != -1) || (GameBase::getTeam(%this) == -1 && GameBase::getTeam(%object) != -1)) {
			if (GameBase::getDamageState(%this) == "Enabled") {
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
      		else if(Station::getTarget(%this) == %object) {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}
//=================================================================================
//=================================================================================
//=================================================================================
//=================================================================================

//----------------------------------------------------------------------------



StaticShapeData DeployableAmmoStation
{
   description = "Remote Ammo Unit";
   shapeFile = "ammounit_remote";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
   className = "DeployableStation";
   maxDamage = 0.25;
   sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
   sequenceSound[1] = { "use", SoundUseAmmoStation };
   sequenceSound[2] = { "power", SoundAmmoStationPower };

   visibleToSensor = true;
   shadowDetailMask = 4;
   castLOS = true;
   supression = false;
   supressable = false;
   mapFilter = 4;
   mapIcon = "M_station";
   debrisId = flashDebrisSmall;
   damageSkinData = "objectDamageSkins";
   explosionId = flashExpMedium;
};


function DeployableAmmoStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Ammo Station");
	%this.Energy = $RemoteAmmoEnergy;
}

function DeployableAmmoStation::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
		schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
		%this.lastPlayer = Station::getTarget(%this);
		%player = %this.lastPlayer; 
		%player.Station = %this;
		%this.target = Player::getClient(Station::getTarget(%this));
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
		if(%weapon != -1) {
			%player.lastWeapon = %weapon;
			Player::unMountItem(%player,$WeaponSlot);
		}
	}
	else 
		GameBase::setActive(%this,false);	
}

//=================================================================================
//=================================================================================
//=================================================================================
//=================================================================================

//----------------------------------------------------------------------------

StaticShapeData DeployableInvStation
{
   description = "Remote Inv Unit";
   shapeFile = "invent_remote";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
   className = "DeployableStation";
   maxDamage = 0.25;
   sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
   sequenceSound[1] = { "use", SoundUseAmmoStation };
   sequenceSound[2] = { "power", SoundInventoryStationPower };			
   visibleToSensor = true;
   shadowDetailMask = 4;
   castLOS = true;
   supression = false;
   supressable = false;
   mapFilter = 4;
   mapIcon = "M_station";
   debrisId = flashDebrisMedium;
   damageSkinData = "objectDamageSkins";
   explosionId = flashExpSmall;
   //triggerRadius = 1.5;
};


function DeployableInvStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Inv Station");
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
 		InventoryStation::onResupply(%this,"RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
		GameBase::setActive(%this,false);
}


//=================================================================================
//=================================================================================
//=================================================================================
//=================================================================================


StaticShapeData DeployableComStation 
{ 
   description = "Remote Command Station"; 
   shapeFile = "cmdpnl"; 
   className = "DeployableStation"; 
   visibleToSensor = true; 
   sequenceSound[0] = { "activate", SoundActivateCommandStation }; 
   sequenceSound[1] = { "power", SoundCommandStationPower }; 
   sequenceSound[2] = { "use", SoundUseCommandStation }; 
   maxDamage = 1.0; 
   debrisId = flashDebrisMedium; 
   mapFilter = 4; 
   mapIcon = "M_station"; 
   damageSkinData = "objectDamageSkins"; 
   shadowDetailMask = 16; 
   triggerRadius = 1.5; 
   castLOS = true; 
   supression = false; 
   supressable = false; 
   explosionId = flashExpLarge; 
}; 


function DeployableComStation::onAdd(%this)
{
	GameBase::playSequence(%this,0,"power"); 
	GameBase::playSequence(%this,1); 
}

function DeployableComStation::onActivate(%this) 
{ 
	%obj = Station::getTarget(%this); 
	if (%obj != -1) { 
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
		CommandStation::onResupply(%this);
		%this.lastPlayer = Station::getTarget(%this);  
	} 
	else 
	GameBase::setActive(%this,false); 
} 

function DeployableComStation::onDeactivate(%this) 
{ 
	GameBase::stopSequence(%this,2); 
	GameBase::setSequenceDirection(%this,1,0);
} 

function DeployableComStation::onEnabled(%this) 
{ 
	GameBase::playSequence(%this,0,"power"); 
	GameBase::playSequence(%this,1); 
} 
	 
function DeployableComStation::onDisabled(%this) 
{
	Station::weaponCheck(%this); 
	GameBase::stopSequence(%this,0); 
	GameBase::setSequenceDirection(%this,1,0); 
	GameBase::pauseSequence(%this,1); 
	GameBase::stopSequence(%this,2); 
	Station::checkTarget(%this);
} 


//=================================================================================
//=================================================================================
//=================================================================================
//=================================================================================


StaticShapeData BaseStation 
{ 
   description = "Station Supply Unit"; 
   shapeFile = "inventory_sta"; 
   className = "DeployableStation"; 
   visibleToSensor = true; 
   sequenceSound[0] = { "activate", SoundActivateInventoryStation }; 
   sequenceSound[1] = { "power", SoundInventoryStationPower }; 
   sequenceSound[2] = { "use", SoundUseInventoryStation }; 
   maxDamage = 2.0; 
   debrisId = flashDebrisLarge; 
   mapFilter = 4; 
   mapIcon = "M_station"; 
   damageSkinData = "objectDamageSkins"; 
   shadowDetailMask = 16; 
   triggerRadius = 1.5; 
   explosionId = flashExpLarge; 
}; 

function BaseStation::onAdd(%this)
{
	GameBase::playSequence(%this,0,"power"); 
	GameBase::playSequence(%this,1); 
}

function BaseStation::onActivate(%this) 
{ 
	%obj = Station::getTarget(%this); 
	if (%obj != -1) { 
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
		InventoryStation::onResupply(%this,"InvList");
		%this.lastPlayer = Station::getTarget(%this);  
	} 
	else 
		GameBase::setActive(%this,false); 
} 

function BaseStation::onDeactivate(%this) 
{ 
	GameBase::stopSequence(%this,2); 
	GameBase::setSequenceDirection(%this,1,0);
} 

function BaseStation::onEnabled(%this) 
{ 
	GameBase::playSequence(%this,0,"power"); 
	GameBase::playSequence(%this,1); 
} 
	 
function BaseStation::onDisabled(%this) 
{
	Station::weaponCheck(%this); 
	GameBase::stopSequence(%this,0); 
	GameBase::setSequenceDirection(%this,1,0); 
	GameBase::pauseSequence(%this,1); 
	GameBase::stopSequence(%this,2); 
	Station::checkTarget(%this);
} 











//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
function Nappy::Station::Ejection(%player, %this)
{
%ejectionTime = $Nappy::Station::EjectTime;
%stationEjectionMessageColor = 1;
	if(%player.Station){
		%client = Player::getClient(%player);
		if(!%player.timeChecking){
			%player.time = %ejectionTime;
			%player.timechecking = 1;
			Client::sendMessage(%client,%stationEjectionMessageColor,"You have " @ %ejectionTime @ " seconds to use this station.");
		}
		else{
			%player.time--;
			if(%player.time == 10){
				Client::sendMessage(%client,%stationEjectionMessageColor,"You have 10 seconds left.");
			}
			else if(%player.time == 5){
				Client::sendMessage(%client,%stationEjectionMessageColor,"You have 5 seconds left.");
			}
			else if(!%player.time){
				Client::sendMessage(%client,%stationEjectionMessageColor,"Your station time has expired.");
				%armor = Player::getArmor(%player);
				if(%armor == "sarmor" || %armor == "sfemale" || %armor == "sparmor" || %armor == "spfemale" || %armor == "sniparmor" || %armor == "snipfemale") {
					%velocity = -80;
					%zVec = 70;
				}
				else if(%armor == "mercarmor" || %armor == "mercfemale" || %armor == "flagarmor" || %armor == "flagfemale" || %armor == "barmor" || %armor == "bfemale" || %armor == "engarmor" || %armor == "engfemale") {
					%velocity = -150;
					%zVec = 100;
				}
				else if(%armor == "darmor") {
					%velocity = -200;
					%zVec = 110;
				}
				%jumpDir = Vector::getFromRot(GameBase::getRotation(%this),%velocity,%zVec);
				Player::applyImpulse(%player,%jumpDir);
				%player.timechecking = 2;
			}
		}
		if(%player.timechecking == 1){
			schedule("Nappy::Station::Ejection(" @ %player @ ", " @ %this @ ");",1);
		}
		else if(%player.timechecking == 2){
			%player.time = 0;
		}
	}
	else{
		%player.time = 0;
		%player.timechecking = 0;
	}
}




function InventoryStation::onResupply(%this,%InvShopList)
{

	%player = Station::getTarget(%this);
	%client = Player::getClient(%player);

	if(!%player.timeChecking){
		if(GameBase::getDataName(%this) == "InventoryStation" || GameBase::getDataName(%this) == "BaseStation")
			Nappy::Station::Ejection(%player, %this);
	}

	if(%InvShopList != ""){
		$ClientList[%client] = %InvShopList;
	}
	%InvShopList = $ClientList[%client];

	//dbecho(3, "STATION::Resupply");
	if(GameBase::isActive(%this)){
		if(%player != -1 && %this.lastPlayer == %player) {
			if(%this.target != %client || $StationArmor[%client] != Player::getArmor(%client)) {
				$StationArmor[%client] = Player::getArmor(%client);
				Client::clearItemShopping(%this.target);
				%player.Station = %this;
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				if(!%client.noEnterInventory)
   					Client::setGuiMode(%client,$GuiModeInventory);
				if(!%client.stationOn)
					Client::sendMessage(%client,0,"Station Access On");
				%client.stationOn = 1;
				%this.beingUsed = 1;
				%client.usingThis = %this;
				%player.ResupplyFlag = 1;
				%weapon = Player::getMountedItem(%player,$WeaponSlot);
				if(%weapon != -1) {
					%player.lastWeapon = %weapon;
					Player::unMountItem(%player,$WeaponSlot);
				}
			}
			%player.waitThrowTime = getSimTime();
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
			if(%player.ResupplyFlag) 
				%player.ResupplyFlag = resupply(%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if(%this.target != ""){  
		%player = Client::getOwnedObject(%this.target);
		%client = Player::getClient(%player);
		%client.stationOn = 0;
		%this.beingUsed = 0;
		%client.usingThis = "";
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);

		%player.timechecking = 0;

		if(GameBase::getDataName(%player.Station) == DeployableInvStation) {
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1)
				Client::setGuiMode(%this.target,1);
			%player.Station = "";
  			%this.target = "";
		}
		if(Player::getMountedItem(%player,$WeaponSlot) == -1){
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);		 	
				%player.lastWeapon = "";
	  		}
		}
	}
	%this.enterTime="";
}


//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
function setupShoppingList(%client,%station,%ListType)
{
	%player = Client::getOwnedObject(%client);
	if(Client::getTeam(%client) == -1){
		Client::sendMessage(%client,1,"You don't need anything from the station");
		return;
	}
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	if(%ListType == "InvList" || ($Nappy::FullInventoryListDeploaybleStation && %ListType == "RemoteInvList")) {
		for(%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item] && $ItemMax[%armor, %item] != 0) 
				Client::setItemShopping(%client, %item);
			else if(%item.className == Armor && !%station.dontSell[%item])  
				Client::setItemShopping(%client, %item);
		}
	}
	else if(%ListType == "RemoteInvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item] && $ItemMax[%armor, %item] != 0) 
				Client::setItemShopping(%client, %item);
			else 
			if($Nappy::BuyArmorDeployableStation){
				if(%item.className == Armor && !%station.dontSell[%item])  
					Client::setItemShopping(%client, %item);
			}
		}
	}
	else if(%ListType == "NewInvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($NewInvList[%item] != "" && $NewInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
			else 
			if($Nappy::BuyArmorDeployableStation){
				if(%item.className == Armor && !%station.dontSell[%item])  
					Client::setItemShopping(%client, %item);
			}
		}
	}
	else {
		for (%i = 0; %i < %max; %i = %i + 1) {						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------




function updateBuyingList(%client)
{
	if(%client.usingBuilderStation && $BuilderMode){
		Client::clearItemBuying(%client);
		%energy = 999999999;
		Client::setInventoryText(%client, "<f1><jc>.:.:.:BUILDER.:.STATION:.:.:.");
	}
	else{
		Client::clearItemBuying(%client);
		%station = (Client::getOwnedObject(%client)).Station;
		%stationName = GameBase::getDataName(%station); 
		if((!$Nappy::BigStationEnergyDeployableStation && %stationName == DeployableInvStation) || %stationName == DeployableAmmoStation) {
			%energy = %station.Energy;
	   		Client::setInventoryText(%client, "<f1><jc>STATION ENERGY: " @ %energy );
		}
		else {
			%energy = $TeamEnergy[Client::getTeam(%client)];
			Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ %energy);
		}
	}
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++) {
		%item = getItemData(%i);
      	if(!%item.showInventory)
           		continue;
		if($ItemMax[%armor, %item] != "" && Client::isItemShoppingOn(%client,%i)) {
			%extraAmmo = 0;
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
				%extraAmmo = $AmmoPackMax[%item];
			if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item))	{
				if(%energy >= %item.price ) {
					if(%item.className == Weapon) {
						if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor])					
							Client::setItemBuying(%client, %item);
					}
					else { 
						if($TeamItemMax[%item] != "") {						
							if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
								Client::setItemBuying(%client, %item);
						}
						else
							Client::setItemBuying(%client, %item);
					}
				}
			}
		}
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i)) 
			Client::setItemBuying(%client, %item);
		else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i))
			Client::setItemBuying(%client, %item);
	}
}







function Station::itemsToResupply(%player) 
{ 
	if(%player.check == "usingStation"){
		%cnt = 0;
 		%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1); 
		%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1); 
		%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,5); 
 		%cnt = %cnt + AmmoStation::resupply(%player,"",Beacon,5);
		%cnt = %cnt + AmmoStation::resupply(%player,"",MineAmmo,5);
		%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,50); 
		%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,10); 
		%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,SMRPack,MissileAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Silencer,SilencerAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Vulcan,VulcanAmmo,50); 
		%cnt = %cnt + AmmoStation::resupply(%player,TranqGun,TranqAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Shotgun,ShotgunAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Napalm,NapalmAmmo,5); 
		%cnt = %cnt + AmmoStation::resupply(%player,Flamer,FlamerAmmo,50); 
		return %cnt; 
	} 
}




function resupply(%this)
{
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1) {
			//========Nappy cheater check
			%player.check = "usingStation";
			// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
			%client = Player::getClient(%player);
			if (%cnt != 0) {
				updateBuyingList(%client);
				return 1;
			}
			Client::sendMessage(%client,0,"Resupply Complete");
			%player.check = "";
			return 0;
		}
	}
	return 0;
}






function AmmoStation::onResupply(%this)
{
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			//========Nappy cheater check
			%player.check = "usingStation";
			// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
			if (%cnt != 0) {
				%player.waitThrowTime = getSimTime();
				schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
				return;
			}
			%player.Station = "";
			%client = Player::getClient(%player);
			%this.target = "";
			Client::sendMessage(%client,0,"Resupply Complete");
			%player.check = "";
			Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%client)]);

			if(Player::getMountedItem(%player,$WeaponSlot) == -1){
				if(%player.lastWeapon != "") {
					Player::useItem(%player,%player.lastWeapon);		 	
					%player.lastWeapon = "";
	  			}
			}			
		}
		else if(%this.target != "") {
			%player = Client::getOwnedObject(%this.target);
			%player.Station = "";
			if(Player::getMountedItem(%player,$WeaponSlot) == -1){
				if(%player.lastWeapon != "") {
					Player::useItem(%player,%player.lastWeapon);		 	
					%player.lastWeapon = "";
	  			}
			}		
			%this.target = "";
		}
		else {
			%this.lastPlayer.Station = "";
			if(Player::getMountedItem(%this.lastPlayer,$WeaponSlot) == -1){
				if(%this.lastPlayer.lastWeapon != "") {
					Player::useItem(%this.lastPlayer,%this.lastPlayer.lastWeapon);		 	
					%this.lastPlayer.lastWeapon = "";
	  			}
			}
			%this.target = "";
		}
		GameBase::setActive(%this,false);
		%this.enterTime="";
	}
}






function AmmoStation::resupply(%player,%weapon,%item,%delta)
{
	%delta = checkResources(%player,%item,%delta,1);		
	if(%delta > 0) {						
		if(%item == RepairPatch) {
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			GameBase::repairDamage(%player,0.1);
		 	return %delta;
		}
		else if (%item == MineAmmo || %item == Grenade || %item == RepairKit || %item == Beacon) {
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
		else if (Player::getItemCount(%player,%weapon)) {
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
	}
	return 0;
}



function VehicleStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled") {
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("set",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,7,1);
		%station = %player.Station;
		if(%objInWay == 1) {
			%object = Group::getObject(%set, 0);	
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle) {
				if(GameBase::getControlClient(%object) == -1) {
					if(%station.fadeOut == "") {
						if(%item != $VehicleToItem[%sname]) {
							%object.fading = 1;
							%station.fadeOut=1;
							teamEnergyBuySell(%player,$VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteObject(" @ %object @ ");",2.5,%object);
							schedule(%object @ ".fading = \"\";",2.5,%object);
							schedule(%station @ ".fadeOut = \"\";",2.5,%station);
							%objInWay--;
						}
						else
							return 2;
					}
					else {
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else { 
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			} 
		}
		if(!%objInWay) {
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
			%NappyDeployedObj = newObject("NDOset",SimSet);
			%NappyObjInWay = containerBoxFillSet(%NappyDeployedObj,$StaticObjectType,%markerPos,6,5,7,1);
			if(%NappyObjInWay > 1){
				Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
				return 0;
			}
			deleteObject(%NappyDeployedObj);
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
			if (checkResources(%player,%item,1)) {
	    		%vehicle = newObject("",flier,$DataBlockName[%item],true);
				Gamebase::setMapName(%vehicle,%item.description);
				%vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
			  	%vehicle.fading = 1;
				GameBase::setTeam(%vehicle,Client::getTeam(%client));
				if(%object.fading) { 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %markerPos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else {
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%markerPos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
				 	schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
					%obj.busy = getSimTime() + 3;
				}
				deleteObject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");

	return 0;
}







