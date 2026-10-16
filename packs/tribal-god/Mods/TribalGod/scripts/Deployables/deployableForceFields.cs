//                                Largest FFDoor:
//==========================================================================================
StaticShapeData lgaForceFieldShape
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x17";
	maxDamage = 250;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 1;
	lightType = 2;
	lightColor = { 1.0, 0.2, 0.2 };
	side = "single";
	isTranslucent = true;
	description = "4x17 Field Door";
};

function lgaForceFieldShape::Destruct(%this)
{ lgaForceFieldShape::doDamage(%this); }

function lgaForceFieldShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function lgaForceFieldShape::onDestroyed(%this)
{
	lgaForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "lgaForceFieldPack"]--;
}

function lgaForceFieldShape::onCollision(%this, %obj)
{
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
		%energy = GameBase::getEnergy(%obj);
		%energy = %energy - 30;
		if (%energy < 0)  %energy = 0;
		GameBase::setEnergy(%obj, %energy);
		client::sendmessage(%c, 1, "Access Denied!~wAccess_Denied.wav");
		Player::setDamageFlash(%obj,1);
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj), -100, 4);
		Player::applyImpulse(%obj, %jumpDir);
		GameBase::setDamageLevel(%obj, 0.4);
		return;
	}
	lgaForceFieldShape::openDoor(%this);
	return;
}
function lgaForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.10);
	schedule("lgaForceFieldShape::closeDoor("@ %this @");", 1);
}

function lgaForceFieldShape::closeDoor(%this)
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 -6");
	GameBase::setPosition(%this, %pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@ %this @", ForceFieldClose, 0);", 0.10);
}

function lgaForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this, %pos);
	Schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.15);
	Schedule("lgaForceFieldShape::closeDoor("@ %this @");", 1);
}

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
	description = "LgaForceFieldDoor";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHeading[ForceFields];
	imageType = lgaForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function lgaForceFieldPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function lgaForceFieldPack::onDeploy(%player,%item,%pos)
{ if(lgaForceFieldPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function lgaForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client, 0, "You Have Reached The Limit On "@ %item.description @"'s."); return false; }
	
	if (GameBase::getLOSInfo(%player, 3))
	{
		%Set = newObject("set", SimSet);
		%Mask = $StaticObjectType;
		%num = containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150, 0);
		for(%i; %i < %num; %i++)
		{
			%thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{ %inbase = true; break; }
		}
		deleteObject(%Set);
		
		if(%inbase)
		{
			%obj = getObjectType($los::object);
			%rot = GameBase::getRotation(%player);
			%camera = newObject("lgaForceFieldPack", "StaticShape", lgaForceFieldShape, true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera, GameBase::getTeam(%player));
			GameBase::setRotation(%camera, %rot);
			GameBase::setPosition(%camera, $los::position);
			Gamebase::setMapName(%camera, "Force Field Door #"@ $totalNumCameras++ @" "@ Client::getName(%client));
			Client::sendMessage(%client, 0, "Force Field Door deployed");
			playSound(SoundPickupBackpack, $los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @"lgaForceFieldPack"]++;
			Echo("MSG: "@ %client @" deployed a Force Field Door ");
			return true;
		}
		else
		{
			BottomPrint(%client, "<jc><f1> Fair play distance exceeded for "@ %item.description @"s.", 5);
			Client::sendMessage(%client,0,"Fair play distance exceeded for "@ %item.description @"s.");
		}
	}
	else
	{ Client::sendMessage(%client, 0, "Aim at your feet then try it again..."); }
	return false;
}
//==========================================================================================

//------------------------------------------------------------------------------------------

//                           2nd Largest FFDoor:
//==========================================================================================
StaticShapeData lgbForceFieldShape
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x14";
	maxDamage = 250;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 1;
	lightType= 2;
	lightColor = { 1.0, 0.2, 0.2 };
	side = "single";
	isTranslucent = true;
	description = "4x14 Field Door";
};

function lgbForceFieldShape::Destruct(%this)
{ lgbForceFieldShape::doDamage(%this); }

function lgbForceFieldShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function lgbForceFieldShape::onDestroyed(%this)
{ lgbForceFieldShape::doDamage(%this); $TeamItemCount[GameBase::getTeam(%this) @ "lgbForceFieldPack"]--; }

function lgbForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{ return; }
	lgbForceFieldShape::openDoor(%this);
	return;
}

function lgbForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	Schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.10);
	Schedule("lgbForceFieldShape::closeDoor("@ %this @");", 1);
}

function lgbForceFieldShape::closeDoor(%this)
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this, %pos);
	GameBase::startfadein(%this);
	Schedule("GameBase::playSound("@ %this @", ForceFieldClose, 0);", 0.10);
}

function lgbForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	Schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.15);
	Schedule("lgbForceFieldShape::closeDoor("@ %this @");", 1);
}


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
	description = "LgbForceFieldDoor";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHeading[ForceFields];
	imageType = lgbForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function lgbForceFieldPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function lgbForceFieldPack::onDeploy(%player, %item, %pos)
{
	if(lgbForceFieldPack::deployShape(%player, %item))
	{ Player::decItemCount(%player, %item); }
}

function lgbForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%Set = newObject("set",SimSet);
			%Mask = $StaticObjectType;
			%num = containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
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
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%camera) @ "lgbForceFieldPack"]++;
				echo("MSG: ",%client," deployed a Force Field Door ");
				return true;
			}
			else
			{ bottomprint(%client, "<jc>Fair play distance exceeded for " @ %item.description @ "s", 3); }
		}
		else
		{ Client::sendMessage(%client, 0, "Cannot deploy here."); }
	}
	else
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s."); }
	return false;
}
//==========================================================================================

//------------------------------------------------------------------------------------------

//                             1st Medium Door:
//==========================================================================================
StaticShapeData medaForceFieldShape
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x8";
	maxDamage = 250;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 1;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "4x8 Field Door";
};

function medaForceFieldShape::Destruct(%this)
{ medaForceFieldShape::doDamage(%this); }

function medaForceFieldShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function medaForceFieldShape::onDestroyed(%this)
{ medaForceFieldShape::doDamage(%this); $TeamItemCount[GameBase::getTeam(%this) @ "medaForceFieldPack"]--; }

function medaForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{ return; }
	
	medaForceFieldShape::openDoor(%this);
	return;
}

function medaForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.10);
	schedule("medaForceFieldShape::closeDoor("@ %this @");", 1);
}
function medaForceFieldShape::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos, "0 0 -6");
	GameBase::setPosition(%this, %pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@ %this @", ForceFieldClose, 0);", 0.10);
}

function medaForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 6");
	GameBase::setPosition(%this, %pos);
	schedule("GameBase::playSound("@ %this @", ForceFieldOpen, 0);", 0.15);
	schedule("medaForceFieldShape::closeDoor("@ %this @");", 1);
}


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
	description = "MedaForceFieldDoor";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHeading[ForceFields];
	imageType = medaForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function medaForceFieldPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function medaForceFieldPack::onDeploy(%player,%item,%pos)
{ if(medaForceFieldPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function medaForceFieldPack::deployShape(%player,%item)
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
				%rot = GameBase::getRotation(%player);
				
				%camera = newObject("medaForceFieldPack","StaticShape",medaForceFieldShape,true);
				addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%player));
				GameBase::setRotation(%camera,%rot);
				GameBase::setPosition(%camera,$los::position);
				Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Force Field Door deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%camera) @ "medaForceFieldPack"]++;
				echo("MSG: ",%client," deployed a Force Field Door ");
				return true;
			}
			else
			{ bottomprint(%client, "<jc>Fair play distance exceeded for " @ %item.description @ "s", 3); }
		}
		else
		{ Client::sendMessage(%client,0,"Cannot deploy here."); }
	}
	else
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); }
	return false;
}
//==========================================================================================

//------------------------------------------------------------------------------------------

//                                   2nd Medium Door:
//==========================================================================================
StaticShapeData medbForceFieldShape
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 250;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 1;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "5x5 Field Door";
};

function medbForceFieldShape::Destruct(%this)
{ medbForceFieldShape::doDamage(%this); }

function medbForceFieldShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function medbForceFieldShape::onDestroyed(%this)
{ medbForceFieldShape::doDamage(%this); $TeamItemCount[GameBase::getTeam(%this) @ "medbForceFieldPack"]--; }

function medbForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{ return; }
	medbForceFieldShape::openDoor(%this);
	return;
}

function medbForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
	schedule("medbForceFieldShape::closeDoor("@%this@");",1);
}

function medbForceFieldShape::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);
}

function medbForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("medbForceFieldShape::closeDoor("@%this@");",1);
}


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
	description = "MediumFFDoor2";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHeading[ForceFields];
	imageType = medbForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function medbForceFieldPack::onUse(%player, %item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::deployItem(%player, %item); }
}

function medbForceFieldPack::onDeploy(%player, %item, %pos)
{
	if(medbForceFieldPack::deployShape(%player, %item))
	{ Player::decItemCount(%player, %item); }
}

function medbForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if(GameBase::getLOSInfo(%player,3))
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
				%rot = GameBase::getRotation(%player);
				%camera = newObject("medbForceFieldPack","StaticShape",medbForceFieldShape,true);
				addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%player));
				GameBase::setRotation(%camera,%rot);
				GameBase::setPosition(%camera,$los::position);
				Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Force Field Door deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%camera) @ "medbForceFieldPack"]++;
				echo("MSG: ",%client," deployed a Force Field Door ");
				return true;
			}
			else
			bottomprint(%client, "<jc>Fair play distance exceeded for "@ %item.description @"s", 3);
		}
		else
		{ Client::sendMessage(%client,0,"Cannot deploy here."); }
	}
	else
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); }
	return false;
}
//==========================================================================================

//------------------------------------------------------------------------------------------

//                                 3rd MediumFFDoor:
//==========================================================================================
StaticShapeData medcForceFieldShape
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_3x4";
	maxDamage = 250;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 1;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "3x4 Field Door";
};

function medcForceFieldShape::Destruct(%this)
{ medcForceFieldShape::doDamage(%this); }

function medcForceFieldShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function medcForceFieldShape::onDestroyed(%this)
{ medcForceFieldShape::doDamage(%this); $TeamItemCount[GameBase::getTeam(%this) @ "medcForceFieldPack"]--; }

function medcForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{ return; }
	medcForceFieldShape::openDoor(%this);
	return;
}
function medcForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.10);
	schedule("medcForceFieldShape::closeDoor("@%this@");",1);
}

function medcForceFieldShape::closeDoor(%this)
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.10);
}

function medcForceFieldShape::openDoor(%this)
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("medcForceFieldShape::closeDoor("@%this@");",1);
}

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
	description  = "MediumFFDoor3";
	shapeFile    = "AmmoPack";
	className    = "Backpack";
	heading      = $InvHeading[ForceFields];
	imageType    = medcForceFieldPackImage;
	shadowDetailMask = 4;
	mass         = 2.5;
	elasticity   = 0.2;
	price        = 500;
	hudIcon      = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function medcForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else{ Player::deployItem(%player,%item); }
}

function medcForceFieldPack::onDeploy(%player,%item,%pos)
{ if(medcForceFieldPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function medcForceFieldPack::deployShape(%player,%item)
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
				%rot = GameBase::getRotation(%player);
				
				%camera = newObject("medcForceFieldPack","StaticShape",medcForceFieldShape,true);
				addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%player));
				GameBase::setRotation(%camera,%rot);
				GameBase::setPosition(%camera,$los::position);
				Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Force Field Door deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%camera) @ "medcForceFieldPack"]++;
				echo("MSG: ",%client," deployed a Force Field Door ");
				return true;
			}
			else
			{ bottomprint(%client, "<jc>Fair play distance exceeded for " @ %item.description @ "s", 3); }
		}
		else
		{ Client::sendMessage(%client,0,"Cannot deploy here."); }
	}
	else
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); }
	return false;
}