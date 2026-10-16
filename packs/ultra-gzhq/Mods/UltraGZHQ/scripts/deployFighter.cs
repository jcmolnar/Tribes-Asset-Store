$InvList[FighterPack] = 1;
$MobileInvList[FighterPack] = 1;
$RemoteInvList[FighterPack] = 1;
AddItem(FighterPack);

function deployFighter::Initialize()
{
	$TeamItemCount[0 @ FighterPack] = 0; 
	$TeamItemCount[1 @ FighterPack] = 0; 
	$TeamItemCount[2 @ FighterPack] = 0;
	$TeamItemCount[3 @ FighterPack] = 0;
	$TeamItemCount[4 @ FighterPack] = 0;
	$TeamItemCount[5 @ FighterPack] = 0;
	$TeamItemCount[6 @ FighterPack] = 0;
	$TeamItemCount[7 @ FighterPack] = 0;
}

ItemImageData FighterPackImage 
{
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack 
{
	description = "Screaming Eagle Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = FighterPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FighterPack::onUse(%player,%item) 
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
}

function FighterPack::onDeploy(%player,%item,%pos) 
{
	if(FighterPack::deployShape(%player,%item))
	{
		if(!$build)Player::decItemCount(%player,%item);	
	}
}

function FighterPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "InterceptorVehicle"] >= $TeamItemMax[InterceptorVehicle] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object); 
	if(%obj != "SimTerrain" && %obj != "InteriorShape") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!Vehicle::DeployArea(%player,"Interceptor",$los::position)) 
		return false;		
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if(!%player.vehicle)
	{		
		%rot = GameBase::getRotation(%player); 
		%objVehicle = newObject("",flier,Interceptor,true); 
		NukeList(%objvehicle);
		addToSet("MissionCleanup", %objVehicle); 
		GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
		GameBase::setPosition(%objVehicle,$los::position); 
		GameBase::setRotation(%objVehicle,%rot); 
		Client::sendMessage(%client,0,"Piloting Interceptor..."); 
		GameBase::startFadeIn(%objVehicle); 
		Vehicle::TerrainCheck(%objVehicle);
		playSound(SoundPickupBackpack,$los::position); 
		$TeamItemCount[GameBase::getTeam(%player) @ "InterceptorVehicle"]++; 
		echo("MSG: ",%client," deployed a Fighter Vehicle Pack"); 
		
		
		return true;
	}	

	
}

function deployFighter(%player,%item)
{
	%pPos	= GameBase::getPosition(%player);
	%tPos	= GameBase::getPosition(%player.terCheck);
	deleteobject(%player.terCheck);
	%AboveTerrain = (getWord(%pPos,2)+10 - getWord(%tPos,2)) >0;
	
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if(!player.vehicle && %AboveTerrain)
	{	
		
		
		%rot = GameBase::getRotation(%player); 
		%objVehicle = newObject("",flier,Interceptor,true); 
		NukeList(%objvehicle);
		addToSet("MissionCleanup", %objVehicle); 
		GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
		GameBase::setPosition(%objVehicle,$los::position); 
		GameBase::setRotation(%objVehicle,%rot); 
		Client::sendMessage(%client,0,"Piloting Screaming Eagle..."); 
		GameBase::startFadeIn(%objVehicle); 
		playSound(SoundPickupBackpack,$los::position); 
		$TeamItemCount[GameBase::getTeam(%player) @ "InterceptorVehicle"]++; 
		echo("MSG: ",%client," deployed a Fighter Vehicle Pack");
		if(!$build)Player::decItemCount(%player,%item);
	}	
	else
	{
		%rot = GameBase::getRotation(%player);
		if(!$build)Player::decItemCount(%player,%item);
		//Client::sendMessage(%client,0,"Cannot deploy below terrain.~wError_Message.wav");
		%obj = newObject("","Mine","Fighterbomb");
		Armor::ThrowGrenade(%player, %obj);
		GameBase::startFadeIn(%obj); 
		
		playSound(SoundPickupBackpack,$los::position); 
		
		%obj.time = 25;
		flierBombSound(%obj);
		GameBase::setRotation(%obj,%rot);
	}	
}

function flierBombSound(%obj)
{
	%BombPos = vector::add(GameBase::getPosition(%obj),"0 0 1");
	playSound(SoundFlyerBomb,%BombPos);
	%obj.time--;
	%rnd = (floor(getRandom() * 60) -30)/30;
	if(%obj.time>0)
		schedule("flierBombSound("@%obj@");",0.70 + %rnd);
	
}