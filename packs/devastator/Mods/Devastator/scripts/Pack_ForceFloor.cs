$InvList[ForceFloorPack] = 1;
$RemoteInvList[ForceFloorPack] = 0;
$TeamItemMax[ForceFloorPack] = 5;
$Dec[ForceFloorPack] = 1;

$ItemMax[larmor, ForceFloorPack] = 0;
$ItemMax[marmor, ForceFloorPack] = 1;
$ItemMax[harmor, ForceFloorPack] = 0;
$ItemMax[qarmor, ForceFloorPack] = 0;
$ItemMax[tarmor, ForceFloorPack] = 0;
$ItemMax[sarmor, ForceFloorPack] = 0;
$ItemMax[srarmor, ForceFloorPack] = 0;
$ItemMax[parmor, ForceFloorPack] = 0;
$ItemMax[psarmor, ForceFloorPack] = 0;
$ItemMax[IceMor, ForceFloorPack] = 1;
$ItemMax[lfemale, ForceFloorPack] = 0;
$ItemMax[mfemale, ForceFloorPack] = 1;
$ItemMax[qarmor, ForceFloorPack] = 0;
$ItemMax[sarmor, ForceFloorPack] = 0;
$ItemMax[srarmor, ForceFloorPack] = 0;
$ItemMax[parmor, ForceFloorPack] = 0;
//----------------------------------------------------------------------------

ItemImageData ForceFloorPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData ForceFloorPack 
{ 
	description = "Plasma Deck"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = fDeployables; 
	imageType = ForceFloorPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function ForceFloorPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function ForceFloorPack::onDeploy(%player,%item,%pos) 
{ 
	if(ForceFloorPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item,$Dec[ForceFloorPack]);
}

function ForceFloorPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(Player::getlastcontactcount(%player) < 10) {
		Client::sendMessage(%client,0,"Plasma Decks should be deployed in the air");
		return false;
	}
	if(LOSCheck(%player,1,"-1.570796 0 0") != FALSE) {
		Client::sendMessage(%client,0,"Item in the way");
		return false;
	}
	%rot = GameBase::getRotation(%player); 
	%pos = GameBase::getPosition(%player);
	%objForceField = newObject("","StaticShape",DeployableForceFloor,true); 
	addToSet("MissionCleanup",%objForceField); 
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objForceField,%pos); 
	GameBase::setRotation(%objForceField,%rot); 
	Gamebase::setMapName(%objForceField,"Plasma Deck"); 
	Client::sendMessage(%client,0,"Plasma Deck Deployed"); 
	GameBase::startFadeIn(%objForceField); 
	playSound(SoundPickupBackpack,%pos); 
	playSound(ForceFieldOpen,%pos); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ForceFloorPack"]++; 
        reportDeploy(%objForceField, %client);
	return true; 
} 

function ForceFloorPack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>Durable, transparent, and free-floating, use the Plasma Deck for Defensive Strategy.");
}

//------------------------------------

StaticShapeData DeployableForceFloor
{ 
	shapeFile = "plasmawall"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 10.50; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Plasma Deck"; 
}; 

function DeployableForceFloor::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFloorPack"]--; 
}