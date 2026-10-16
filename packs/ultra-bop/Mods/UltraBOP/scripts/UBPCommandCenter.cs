//  Ultra Balance of Power
//   Command Center Code
//  Free if you just ask us.
//----------------------------	 
//----------------------------

//----------------------------
//Pack Stuff
//----------------------------

ItemImageData CommandCenterPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData CommandCenterPack
{
	description = "Command Center";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = "jDeployables";
	shadowDetailMask = 4;
	imageType = CommandCenterPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function CommandCenterPack::onUse(%player,%item)
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

function CommandCenterPack::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}	

function CommandCenterPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "StaticShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					 
			instant TeamGroup GameBase::getTeam(%player) {
	
			instant SimGroup "CommandCenter" {
				instant InteriorShape "CC" {
					filename="tank17.1.dis";
					iscontainer="1";
					position=Vector::add(Gamebase::getPosition(%player), "0 0 6");
					rotation=GameBase::getRotation(%player);
					lightparams="1";
					locked="0";
					};
				//###########################################
				//Nothing Deploys right.  Will work on later.
				//###########################################
				
				//instant Sensor "Sensor1" {
			      //	dataBlock = "MediumPulseSensor";
				//	name = "Pulse Sensor #1";
				//	position = Vector::add(GameBase::getPosition(%player), "0 0 60");
				//	rotation = GameBase::getRotation(%player);
				//	destroyable = "True";
				//	deleteOnDestroy = "False";
				//	shieldStrength = "0.0299999";
				//};
				//instant StaticShape "InventoryStation1" {
				//	dataBlock = "InventoryStation";
				//	name = "Inventory Station #1";
				//	position = Vector::add(GameBase::getPosition(%player), "7 3.356 27.75");
				//	rotation = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
				//	destroyable = "True";
				//	deleteOnDestroy = "False";
				//};
				//instant StaticShape "CommandStation1" {
				//	dataBlock = "CommandStation";
				//	name = "Command Station #1";
				//	position = Vector::add(GameBase::getPosition(%player), "1 -5.631 46");
				//	rotation = Vector::add(GameBase::getRotation(%player), "0 0 0.02916");
				//	destroyable = "True";
				//	deleteOnDestroy = "False";
				//};
				//instant StaticShape "CommandStation1" {
				//	dataBlock = "CommandStation";
				//	name = "Command Station #2";
				//	position = Vector::add(GameBase::getPosition(%player), "-0.949 -6.092 46");
				//	rotation = Vector::add(GameBase::getRotation(%player), "0 0 3.11522");
				//	destroyable = "True";
				//	deleteOnDestroy = "False";
				//};




				};
		//END OF TEAM STUFF
			};	
				
				
				$TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack"]++;
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
