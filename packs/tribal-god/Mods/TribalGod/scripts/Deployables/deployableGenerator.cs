StaticShapeData DeployableGenerator
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 1.6;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	maxEnergy = 80;
	shieldShapeName = "shield";
};

function DeployableGenerator::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableSolarPanel"]--;
	Generator::onDestroyed(%this);
}

ItemImageData DeployableSolarPanelImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
  	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};
ItemData DeployableSolarPanel
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = $InvHeading[Deployables2];
	shadowDetailMask = 4	;
	imageType = DeployableSolarPanelImage;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function DeployableSolarPanel::onUse(%player, %item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player, %item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function DeployableSolarPanel::onDeploy(%player, %item, %pos)
{ if(DeployableSolarPanel::deployShape(%player, %item)) { Player::decItemCount(%player, %item); } }	

function DeployableSolarPanel::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if(%client.outArea)
	{ Client::sendMessage(%client,0,"Can only deploy within the mission boundaries."); return; }
	
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] > $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
	
	if(!GameBase::getLOSInfo(%player, 3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "OutpostWall") 
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }
	
	if(Vector::dot($los::normal,"0 0 1") < 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); }
	
	if(!checkDeployArea(%client,$los::position)) 
	{ return false; }
	
	%teamnum = GameBase::getTeam(%player);
	%SPanel = newObject("Portable Generator", "StaticShape", DeployableGenerator, true);
	addToSet("MissionGroup/Teams/Team" @ %teamnum, %SPanel);
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%SPanel,GameBase::getTeam(%player));
	GameBase::setPosition(%SPanel,$los::position);
	GameBase::setRotation(%SPanel,%rot);
	Gamebase::setMapName(%SPanel,"Portable Generator");
	GameBase::generatePower(%SPanel, True);
	Client::sendMessage(%client,0,"Portable Generator deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%SPanel) @ "DeployableSolarPanel"]++;
	echo("MSG: ",%client," deployed a Portable Generator");
	return true;
}