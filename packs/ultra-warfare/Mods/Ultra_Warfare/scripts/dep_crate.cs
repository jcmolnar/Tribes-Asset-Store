//=============================================================
//stackable crate
//=============================================================
$ItemMax[larmor, StackableCratePack] = 0;
$ItemMax[lfemale, StackableCratePack] = 0;
$ItemMax[marmor, StackableCratePack] = 0;
$ItemMax[mfemale, StackableCratePack] = 0;
$ItemMax[harmor, StackableCratePack] = 1;
//================================================================
$InvList[StackableCratePack] = 1;
$RemoteInvList[StackableCratePack] = 1;
$TeamItemMax[StackableCratePack] = 10;
//==============================================================
ItemImageData StackableCratePackImage 
{ 
	shapeFile = "magcargo"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.5, 0 }; 
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData StackableCratePack 
{ 
	description = "Stackable Crate"; 
	shapeFile = "magcargo"; 
	className = "Backpack"; 
	heading = "wDeployables"; 
	imageType = StackableCratePackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 0; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function StackableCratePack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function StackableCratePack::onDeploy(%player,%item,%pos) 
{ 
	if (StackableCratePack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function StackableCratePack::deployShape(%player,%item) 
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%shape = newObject("","StaticShape",StackableCrate,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Stackable Crate deployed");
	playSound(SoundPickupBackpack,$los::position);
	GameBase::startFadeIn(%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "StackableCratePack"]++;
	echo("MSG: ",%client," deployed a Stackable Crate");
	return true;
}


StaticShapeData StackableCrate 
{
	shapeFile = "magcargo";
	debrisId = flashDebrisSmall;
	maxDamage = 25.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Stackable Crate";
};


function StackableCrate::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "StackableCratePack"]--; 
	if($Eradication::showDestructionMessages)
	  	MessageAll(0, "A "@ $Server::teamName[GameBase::getTeam(%this)] @" stackable crate was destroyed.");
} 
