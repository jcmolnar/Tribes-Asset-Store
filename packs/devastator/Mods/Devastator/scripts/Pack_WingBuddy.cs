$InvList[WingBuddyPack] = 1;
$RemoteInvList[WingBuddyPack] = 1;
$TeamItemMax[WingBuddyPack] = 12;
$Dec[WingBuddyPack] = 1;

$ItemMax[larmor, WingBuddyPack] = 0;
$ItemMax[marmor, WingBuddyPack] = 1;
$ItemMax[harmor, WingBuddyPack] = 0;
$ItemMax[qarmor, WingBuddyPack] = 0;
$ItemMax[tarmor, WingBuddyPack] = 0;
$ItemMax[sarmor, WingBuddyPack] = 0;
$ItemMax[srarmor, WingBuddyPack] = 0;
$ItemMax[parmor, WingBuddyPack] = 0;
$ItemMax[psarmor, WingBuddyPack] = 0;
$ItemMax[IceMor, WingBuddyPack] = 1;
$ItemMax[lfemale, WingBuddyPack] = 0;
$ItemMax[mfemale, WingBuddyPack] = 1;
$ItemMax[qarmor, WingBuddyPack] = 0;
$ItemMax[sarmor, WingBuddyPack] = 0;
$ItemMax[srarmor, WingBuddyPack] = 0;
$ItemMax[parmor, WingBuddyPack] = 0;
//----------------------------------------------------------------------------

ItemImageData WingBuddyPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData WingBuddyPack
{
	description = "Turret-Buddy";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "fDeployables";
	imageType = WingBuddyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function WingBuddyPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function WingBuddyPack::onDeploy(%player,%item,%pos)
{
	if(WingBuddyPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item,$Dec[WingBuddyPack]);
}	

function WingBuddyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%Name = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%Data = GameBase::getDataName($los::object);
			echo(%obj@", type: "@%Data);
			if(%obj == "Turret" && (%data.shapeFile == "remoteturret" || %data.shapeFile == "camera")) {
				if($los::object.TopBunk == "") {
					%LOS = $los::object;
					%num = $TeamItemCount[GameBase::getTeam(%player)@"WingBuddyPack"];
					%turret = newObject("Turret-Buddy","Turret",AddTurret,true);
					addToSet("MissionCleanup", %turret);
					%pos = getBoxCenter(%LOS);
					%x = getWord(%pos,0);
					%y = getWord(%pos,1);
					if(%data.shapeFile == "remoteturret")
						%z = getWord(%pos,2) + 0.65;
					else if(%data.shapeFile == "camera")
						%z = getWord(%pos,2) + 0.45;
					%pos = ""@%x@" "@%y@" "@%z@"";
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setPosition(%turret,%pos);
					GameBase::setRotation(%turret,GameBase::getRotation(%LOS));
					%LOS.TopBunk = %turret;
					Client::sendMessage(%client,0,"Turret-Buddy deployed");
					playSound(SoundPickupBackpack,%pos);
					$TeamItemCount[GameBase::getTeam(%player) @ "WingBuddyPack"]++;	
					return TRUE;
					echo("MSG: ",%client," deployed a Turret-Buddy");
				}
				else
					Client::sendMessage(%client,0,"There is already one stacked there");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on Small Deployable Defence Systems");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function WingBuddyPack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>Deploy your Turret-Buddy on a Small Deployable Defence System for superior stacking defence!");
}

TurretData AddTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = MiniFusionBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Turret-Buddy";
	damageSkinData = "objectDamageSkins";
};

function AddTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
		GameBase::setMapName (%this, "Turret-Buddy");
}

function AddTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AddTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "WingBuddyPack"]--;
}

// Override base class just in case.
function AddTurret::onPower(%this,%power,%generator) {}
function AddTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
