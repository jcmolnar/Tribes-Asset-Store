$InvList[PerInv] = 1;
$RemoteInvList[PerInv] = 0;
$TeamItemMax[PerInv] = 5;

$ItemMax[larmor, PerInv] = 0;
$ItemMax[marmor, PerInv] = 1;
$ItemMax[harmor, PerInv] = 0;
$ItemMax[qarmor, PerInv] = 0;
$ItemMax[tarmor, PerInv] = 0;
$ItemMax[sarmor, PerInv] = 0;
$ItemMax[srarmor, PerInv] = 0;
$ItemMax[parmor, PerInv] = 0;
$ItemMax[psarmor, PerInv] = 0;
$ItemMax[IceMor, PerInv] = 1;
$ItemMax[lfemale, PerInv] = 0;
$ItemMax[mfemale, PerInv] = 1;
$ItemMax[qarmor, PerInv] = 0;
$ItemMax[sarmor, PerInv] = 0;
$ItemMax[srarmor, PerInv] = 0;
$ItemMax[parmor, PerInv] = 0;
//----------------------------------------------------------------------------

ItemImageData PerInvImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData PerInv
{
	description = "Personal Inv";
	shapeFile = "enerpad";
	className = "Backpack";
	heading = "fDeployables";
	imageType = PerInvImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PerInv::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function PerInv::onDeploy(%player,%item,%pos)
{
	if(PerInv::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function PerInv::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%Name = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape") {
				if(checkDeployArea(%client,$los::position)) {
					if(%client.hasPerInv == "") {
						%InvName = %Name@"'s Personal Inventory Station";
						%LOS = $los::object;
						%inv = newObject("enerpad","StaticShape","PInvStation",true);
 	 		         		addToSet("MissionCleanup", %inv);
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						%NewPos = Vector::add($los::position,"0 0 -0.35");
						%rot = GameBase::getRotation(%player);
						GameBase::setPosition(%inv,%NewPos);
						GameBase::setRotation(%inv,Vector::Add(%rot,"0 0 -1.570796327"));
						Gamebase::setMapName(%inv,%InvName);
						Client::sendMessage(%client,0,"Personal Inventory station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "PerInv"]++;
						%client.hasPerInv = %inv;
						%inv.deployer = %client;
						echo("MSG: ",%client," deployed a Personal Inventory Station");
						return true;
					}
					else
						Client::sendMessage(%client,0,"You already have a personal Inventory Station!");
				}
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on Buildings or Terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function PerInv::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>Perfect for all of those hard working Engineers on defence!");
}

StaticShapeData PInvStation
{
	description = "Personal Inv Unit";
	shapeFile = "enerpad";
	className = "DeployableStation";
	maxDamage = 1.0;
	sequenceSound[0] = { "idle", SoundBeaconActive };
	sequenceSound[1] = { "busy", SoundUseCommandStation };
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

function PInvStation::onAdd(%this)
{
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Personal Inv Station");
	%this.Energy = $TeamEnergy[Client::getTeam(%this.deployer)];
	GameBase::playSequence(%this,1,"busy");
	schedule("GameBase::stopSequence("@%this@","@1@");",1.5);
	schedule("GameBase::playSequence("@%this@","@0@","@"idle"@");",1.5);
	schedule(%this.deployed = 1,1.8);
}

function PInvStation::onEnabled(%this)
{
	GameBase::playSequence(%this,0,"idle");
}

function PInvStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	Station::checkTarget(%this);
}

function PInvStation::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"busy");
		echo("Activate " @ %this);
 		InventoryStation::onResupply(%this,"InvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
		GameBase::setActive(%this,false);
}

function PInvStation::onCollision(%this,%object)
{
	%client = Player::getClient(%object);
	%obj = getObjectType(%object);
	if(%obj == "Player" && isPlayerBusy(%object) == 0) {
		if(%this.deployer == %client) {
			if(GameBase::getDamageState(%this) == "Enabled") {
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
				if(AreGod(%client) == true)
					Client::setItemShopping(%client,Ultra);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
		else if(Station::getTarget(%this) == %object) {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- this is a personal station ~waccess_denied.wav");
			}
		}
	}
}

function PInvStation::onDestroyed(%this)
{
	%this.deployer.hasPerInv = "";
	Station::onDestroyed(%this);
	Station::weaponCheck(%this);
}