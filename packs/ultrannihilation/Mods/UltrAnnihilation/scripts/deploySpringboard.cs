$InvList[SpringPack] = 1;
$MobileInvList[SpringPack] = 1;
$RemoteInvList[SpringPack] = 1;

$CanAlwaysTeamDestroy[Springboard] = 1;

 //-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deploySpringboard::Initialize()
{	$TeamItemCount[0 @ "Springboard"] = 0;
	$TeamItemCount[1 @ "Springboard"] = 0;
	$TeamItemCount[2 @ "Springboard"] = 0;
	$TeamItemCount[3 @ "Springboard"] = 0;
	$TeamItemCount[4 @ "Springboard"] = 0;
	$TeamItemCount[5 @ "Springboard"] = 0;
	$TeamItemCount[6 @ "Springboard"] = 0;
	$TeamItemCount[7 @ "Springboard"] = 0;
}

 //-=-=-=-=-=-=-=- Pack =-=-=-=-=-=-=-

ItemImageData SpringPackImage
{	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData SpringPack
{	description = "Springboard";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihDOb];
	imageType = SpringPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpringPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function SpringPack::onDeploy(%player,%item,%pos)
{	if (SpringPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);
	}
}

function SpringPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "Springboard"] >= $TeamItemMax[Springboard]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,999))   //jdm 3
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player);
	%objSpringboard = newObject("Springboard", "StaticShape", Springboard, true);
	addToSet("MissionCleanup", %objSpringboard);
	GameBase::setTeam(%objSpringboard, GameBase::getTeam(%player));
	GameBase::setPosition(%objSpringboard, $los::position);
	GameBase::setRotation(%objSpringboard, %rot);
	Gamebase::setMapName(%objSpringboard, "Springboard");
	Client::sendMessage(%client,0,"Springboard Deployed");
	GameBase::startFadeIn(%objSpringboard);
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "Springboard"]++;
	echo("MSG: ",%client," deployed a Springboard");
	return true;
}

 //-=-=-=-=-=-=-=- Object =-=-=-=-=-=-=-

StaticShapeData Springboard
{	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 2.00;
	isTranslucent = true;
   	description = "Deployable Spring";
	visibleToSensor = true;
};

function Springboard::onDestroyed(%this)
{	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "Springboard"]--;
}

function Springboard::onCollision(%this,%obj)
{	%c = Player::getClient(%obj);
	%vecVelocity = Item::getVelocity(%obj);
	%rnd = floor(getRandom() * 55);

	 // Check misfires
	if (%rnd == 1)
	{	GameBase::playSound(%this, debrisLargeExplosion, 0);
		Client::SendMessage(%c, 0, "TO THE MOON!");		
		%HMult = 50;
		%ZMax = 80;

		%rnd = floor(getRandom() * 3); 
		if (%rnd == 0) 
		{ MessageAll(0,strcat(Client::getName(%c), " takes a trip into outer space")); } 
		else if (%rnd == 1) 
		{ MessageAll(0,strcat(Client::getName(%c), " visits the moon")); } 
		else if (%rnd == 2) 
		{ MessageAll(0,strcat(Client::getName(%c), " falls off the edge of the earth")); }
	}
	else if (%rnd > 45)  // 46-54
	{	GameBase::playSound(%this, debrisLargeExplosion, 0);
		Client::SendMessage(%c, 0, "K-E-R-S-P-R-O-I-N-G-g-g-g-!-!");
		%HMult = 2;
		%ZMax = 60;
	}
	else
	{	GameBase::playSound(%this, SoundFireMortar, 0);
		Client::SendMessage(%c, 0, "SPROING!");
		%HMult = 2;
		%ZMax = 45;
	}
	%vecNewVelocity = GetWord(%vecVelocity, 0) * %HMult @ " " @ 
	                  GetWord(%vecVelocity, 1) * %HMult @ " " @
	                  %ZMax;
	Item::setVelocity(%obj, %vecNewVelocity);
}

