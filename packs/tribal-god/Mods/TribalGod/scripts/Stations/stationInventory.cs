// I used some of the great plasmatic's code here
// to help me with my connecter turret.
StaticShapeData InventoryStation {
	description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

function InventoryStation::onEndSequence(%this,%thread){
	if(Station::onEndSequence(%this, %thread)){
		InventoryStation::onResupply(%this, "InvList");
	}
}

function InventoryStation::onResupply(%this, %InvShopList){
	dbecho(3, "STATION::Resupply");
	if(GameBase::isActive(%this)){
		%player = Station::getTarget(%this);
		if(%player != -1 && %this.lastPlayer == %player){
			%client = Player::getClient(%player);
			if(%this.target != %client){
				%player.Station = %this;
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				if($TG::ShoppingList){
					%client.invo = %this; //armor based list
					%client.ListType = %InvShopList;
				}
				if(!%client.noEnterInventory){
					Client::setGuiMode(%client, $GuiModeInventory);
				}
				Client::sendMessage(%client, 0, "Station Access On");
				Client::setInventoryText(%client, "<jc><f1>Check Through This Inv Very Carefully.");
				%player.ResupplyFlag = 1;
				%weapon = Player::getMountedItem(%player, $WeaponSlot);
				if(%weapon != -1){
					%player.lastWeapon = %weapon;
					Player::unMountItem(%player,$WeaponSlot);
				}
			}
			%player.waitThrowTime = getSimTime();
			schedule("InventoryStation::onResupply("@ %this @");", 0.5, %this);
			if(%player.ResupplyFlag){
				%player.ResupplyFlag = resupply(%this);
			}
			return;
		}
		GameBase::setActive(%this,false);
	}
	if(%this.target != ""){	   
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
		if(GameBase::getDataName(%player.Station) == DeployableInvStation){
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1){
				Client::setGuiMode(%this.target, 1);
			}
			%player.Station = "";
			%this.target = "";
		}
		if(Player::getMountedItem(%player,$WeaponSlot) == -1){
			if(%player.lastWeapon != ""){
				Player::useItem(%player,%player.lastWeapon);		 	
				%player.lastWeapon = "";
			}
		}
	}
	%this.enterTime="";
}

//===========================================================================================


StaticShapeData DeployableInvStation
{
	description = "Remote Inv Unit";
	shapeFile = "invent_remote";
	validateShape = false;
	validateMaterials = false;
	className = "DeployableStation";
	maxDamage = 2.0;
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
};


function DeployableInvStation::onAdd(%this)
{
	Schedule("DeployableStation::deploy("@ %this @");", 1, %this);
	if(GameBase::getMapName(%this) == "") 
	{ GameBase::setMapName (%this, "R-Inv Station"); }
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1)
	{
		GameBase::playSequence(%this, 1, "use");
 		InventoryStation::onResupply(%this, "RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
	{ GameBase::setActive(%this, false); }
}