//--------------------------------------

$InvList[LargeForceFieldPack] = 1;
$RemoteInvList[LargeForceFieldPack] = 1;

//--------------------------------------
$TeamItemMax[LargeForceFieldPack] = 1000;
//__________________________
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
    heading = "uDeployables";
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
		$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;
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
					if (Vector::dot($los::normal,"0 0 1") > 0.0) //0.7
					{
							%rot = GameBase::getRotation(%player);
							%fField = newObject("ForceField","StaticShape",LargeForceField,true);

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

StaticShapeData LargeForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Large Force Field";
};

function LargeForceField::onCollision(%this,%obj)
{
	echo ("Open Damnit!");
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ((%armor == "spyarmor" || %armor == "spyfemale")) )
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		LargeForceField::Open(%this);
		return;
	}
	echo ("Wrong Team");
	return;
}

function LargeForceField::Open(%this)
{
	echo ("Opening");
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",4);
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 5");
		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",0.05);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 -5");
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
	}
}

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;	
}



//=========
