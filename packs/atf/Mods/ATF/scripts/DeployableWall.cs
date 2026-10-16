//--------------------------------------

$InvList[TripwirePack] = 1;
$RemoteInvList[TripWirePack] = 1;

//--------------------------------------
$TeamItemMax[TripWirePack] = 25;
//__________________________

StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 30.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Metal Wall";

};
function BlastWall::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--;
	
}
StaticShapeData BlastWall2
{
	shapeFile = "newdoor5";
	maxDamage = 30.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Metal Wall";

};
function BlastWall2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--;
	
}


ItemImageData TripwirePackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TripwirePack
{
	description = "Metal Wall";
	shapeFile = "newdoor5";
	className = "Backpack";
    heading = "uDeployables";
	imageType = TripwirePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TripwirePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TripwirePack::onDeploy(%player,%item,%pos)
{
	if (TripwirePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TripWirePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"BlastWall",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.0) //0.7
					{
							%rot = GameBase::getRotation(%player);
							 %fField = newObject("","StaticShape",BlastWall,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Metal Wall");
							Client::sendMessage(%client,0,"Wall Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "TripWirePack"]++;
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
// This is a shifter script...i did not wanna add it...but so many people told me to that i decided to get it.....I modded it a bit...and woulda made one my self...but that woulda taken time...and since it wasn't something i wanted anyway.......i will add this to my readme next version
//--------------------------------------

$InvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 1;

//--------------------------------------
$TeamItemMax[TeleportPack] = 25;
$TeamItemMax[TeleportPack] = 25;

//__________________________



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
	description = "Warp Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    	heading = "sWarp Technology";
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if (teleportPack::deployShape(%player,"Warp Pad",DeployableTeleport,%item))
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
	
	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				//if(checkDeployArea(%client,$los::position))
				//{
					%pos = $los::position;
					%padd = "0 0 0.3";
                			%poss = Vector::add(%pos, %padd);
					
					if(GameBase::testPosition(%player, %poss)) { } else { Client::sendMessage(%client,0,"Can not deploy inside other objects."); return; }

					%sensor = newObject("Warp Pad","StaticShape",%shape,true);

					CreateteleportSimSet();
					addToSet("MissionCleanup/Teleports", %sensor);
					addToSet("MissionCleanup", %sensor);

					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					%pos = Vector::add($los::position,"0 0 1");
					GameBase::setPosition(%sensor,%pos);
					Gamebase::setMapName(%sensor,%name);
					Client::sendMessage(%client,0,%item.description @ " deployed");
					%sensor.disabled = false;
					playSound(SoundPickupBackpack,$los::position);

					%beam = newObject("","StaticShape",IWarpI,true);
					addToSet("MissionCleanup", %beam);
					GameBase::setTeam(%beam,GameBase::getTeam(%player));
					GameBase::setPosition(%beam,%pos);

					%sensor.beam1 = %beam;
					return true;
				//}
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}