ItemImageData DeployPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.41, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData DeployPack
{
	description = "Package";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = "fDeployables";
	imageType = DeployPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

//------------------------------------------------------------------------
StaticShapeData Window_3x4
{
	description = "Window (3x4)";
	shapeFile = "forcefield_3x4";
	className = "Window";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
};

//------------------------------------------------------------------------
StaticShapeData Window_5x5
{
	description = "Window (5x5)";
	shapeFile = "forcefield_5x5";
	className = "Window";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
};

//------------------------------------------------------------------------
StaticShapeData Window_4x17
{
	description = "Window (4x17)";
	shapeFile = "forcefield_4x17";
	className = "Window";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
};

//------------------------------------------------------------------------
StaticShapeData AcmeHole
{
	description = "Acme Hole";
	shapeFile = "flagstand";
	className = "Moo.";
	debrisId = PlayerDebris;
	maxDamage = 100000.0;
};

function AcmeHole::onCollision(%This, %Object)
{
	%Object.Acme = %This;
	AcmeHole::Loop(%Object);
}

function AcmeHole::Loop(%This)
{
	%AcmeHole = %This.Acme;
	%APos = GameBase::getPosition(%AcmeHole);
	%ARot = GameBase::getRotation(%AcmeHole);
	%PPos = GameBase::getPosition(%This);
	Client::sendMessage(Player::getClient(%This),3,"Watch Your Step...~wsniper2.wav");
	%PosNew = GetOffsetRot("0 0 -2.5", %ARot, %APos);
	GameBase::setPosition(%This, %PosNew);
}

//------------------------------------------------------------------------
StaticShapeData Tree
{
	description = "Tree";
	shapeFile = "tree2";
	className = "fuck a goat";
	debrisId = PlayerDebris;
	maxDamage = 100000.0;
	isTranslucent = true;
};

//------------------------------------------------------------------------
StaticShapeData Sattrrt
{
	description = "Sattalite?????";
	shapeFile = "Sat_Big";
	className = "fuck a goat!!";
	debrisId = PlayerDebris;
	maxDamage = 100000.0;
};

//------------------------------------------------------------------------
StaticShapeData Solarpzzntl
{
	description = "solar panel foolllll";
	shapeFile = "solar_med";
	className = "fuck a goat!?!";
	debrisId = PlayerDebris;
	maxDamage = 100000.0;
};