$InvList[iNuclearWaste] = 1;
$RemoteInvList[iNuclearWaste] = 1;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iNuclearWaste] = 0;
$ItemMax[reconfemalearmor, iNuclearWaste] = 0;
$ItemMax[espionagearmor, iNuclearWaste] = 0;
$ItemMax[espionagefemalearmor, iNuclearWaste] = 0;
$ItemMax[engineerarmor, iNuclearWaste] = 0;
$ItemMax[engineerfemalearmor, iNuclearWaste] = 0;
$ItemMax[infantryarmor, iNuclearWaste] = 0;
$ItemMax[infantryfemalearmor, iNuclearWaste] = 0;
$ItemMax[falloutarmor, iNuclearWaste] = 1;
$ItemMax[falloutfemalearmor, iNuclearWaste] = 1;
$ItemMax[demolitionsarmor, iNuclearWaste] = 0;
$ItemMax[assaultarmor, iNuclearWaste] = 0;
$ItemMax[artilleryarmor, iNuclearWaste] = 0;
$ItemMax[commanderarmor, iNuclearWaste] = 0;

$TeamItemMax[iNuclearWaste] = 2;

ItemImageData NuclearWasteImage
{
	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	lightType = 2;   // Pulsing
	lightRadius = 20;
	lightTime = 1.0;
	lightColor = { 0, 1, 0};
	mass = 1.0;
};

ItemData iNuclearWaste 
{
	description = "Nuclear Waste";
	shapeFile = "liqcyl";
	className = "Backpack";
	heading = "dDeployables";
	imageType = NuclearWasteImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;

	lightType = 2;   // Pulsing
	lightRadius = 20;
	lightTime = 1.0;
	lightColor = { 0, 1, 0};

};

function iNuclearWaste::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iNuclearWaste::onDeploy(%player, %item, %pos) {
	if (iNuclearWaste::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iNuclearWaste::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurfaceStack($los::object, "NuclearWaste")) {

						// Make sure it's on a flat surface
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						// if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						// 	%rot = GameBase::getRotation(%player); 
						//}
						//else {
						//	if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						//		%rot = "3.14159 0 0";
						//	}
						//	else {
						//		%rot = Vector::getRotation($los::normal);
						//	}
						//}
							// Make sure player is out of the way
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("NuclearWaste", "StaticShape", NuclearWaste, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Nuclear Waste - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Nuclear Waste deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iNuclearWaste"]++;

								// Set this canister's owner
								$NuclearWasteOwner[%turret] = Player::getClient(%player);

								// Set up the glowing object
								%newobj = newObject("", "Item", NuclearWasteGlow, 1, false);
								addToSet("MissionCleanup", %newobj);
								GameBase::setTeam(%newobj,GameBase::getTeam(%player));
								GameBase::setPosition(%newobj, $los::position);
								$RadiationGlow[%turret] = %newobj;


								echo("MSG: ",%client," deployed Nuclear Waste");
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemData NuclearWasteGlow
{
	description = "Nuclear Waste Glow";
	shapeFile = "breath";
	// imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 16;

	lightType = 2;   // Pulsing
	lightRadius = 40;
	lightTime = 1.5;
	lightColor = { 0, 1, 0 };
};


StaticShapeData NuclearWaste
{
	shapeFile = "liqcyl";
	debrisId = flashDebrisSmall;
	maxDamage = 3.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "NuclearWaste";
	lightType = 2;   // Pulsing
	lightRadius = 40;
	lightTime = 1.5;
	lightColor = { 0, 1, 0};
};


function NuclearWaste::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Nuclear Waste");

	%damage = 0.1;
	%range = 40;
	schedule("PermanentRadiationUpdate(" @ %this @ ", " @%damage@ ", " @%range@ ");", 0.5, %this);
}

function NuclearWaste::onDestroyed(%this) 
{
	deleteObject($RadiationGlow[%this]);
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iNuclearWaste"]--;
}

