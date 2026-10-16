//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemImageData FreezePackImage
{
	shapeFile = "flagstand";
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData FreezePack
{
	description = "Freezing Pad";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = $InvHeading[oddnend];
	imageType = FreezePackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FreezePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function FreezePack::onDeploy(%player,%item,%pos)
{ if(FreezePack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function FreezePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ CenterPrint(%client,"<jc><f1>Ahh, you ain't got no more " @ %item.description @ "s fella, THERE ALL GONE", 7); return false; }
	
	if(!GameBase::getLOSInfo(%player,3))
	{ Client::sendMessage(%client,0,"Out Of Range, Deploy Closer"); return false; }
	
	%obj = getObjectType($los::object);
	%playerPos = GameBase::getPosition(%player);
	
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	%rot =  "1.57079 0 "@ %zRot;
	%padd = "0 0 0";
	%pos = Vector::add($los::position,%padd);
	
	%camera = newObject("", "StaticShape", "FreezePad",true);
	addToSet("MissionCleanup", %camera);
	GameBase::startFadeOut(%camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera,"0 0 0");
	GameBase::setPosition(%camera,%pos);
	Gamebase::setMapName(%camera,"Freeze Pad " @ $totalNumCameras++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Freeze Pad Deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "FreezePack"]++;
	echo("MSG: ",%client," deployed a Freeze Pad");
	return true;
}
//===========================================================================================


StaticShapeData TG::KillPadShape
{ description = "Kill Pad"; shapeFile = "flagstand"; visibleToSensor = false; };

function TG::KillPadShape::onCollision(%this, %object)
{
	%obj = getObjectType(%object);
	%ths = getObjectType(%this);
	
	if (%obj != "Player")
	{ return; }
	
	%sclient = Player::getClient(%object);
	%sname   = Client::getName(%sclient);
	
	if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) 
	{ Client::sendMessage(%sclient, 0, "Your Lucky Your On The Right Team Dumbass, That's A Kill Pad!"); }
	
	else if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
	{
		Schedule("Player::kill("@ %object @");", 13, %object);
		Schedule("CenterPrint("@ %sclient @", \"<jc><f1>You Just Got Mamed Courtesy Of A Kill Pad\", 7);", 13);
	}
}

function TG::KillPadShape::doDamage(%this)
{ calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); }

function TG::KillPadShape::onDestroyed(%this)
{ TG::KillPadShape::doDamage(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TG::KillPad"]--; }


ItemImageData TG::KillPadImage
{
	shapeFile = "flagstand";
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData TG::KillPad
{
	description = "Kill Pad";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = $InvHeading[oddnend];
	imageType = TG::KillPadImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TG::KillPad::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function TG::KillPad::onDeploy(%player,%item,%pos)
{
	if(TG::KillPad::deployShape(%player,%item))
	{ Player::decItemCount(%player,%item); }
}

function TG::KillPad::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if(GameBase::getLOSInfo(%player, 3)) 
		{
			%obj = getObjectType($los::object);
			%playerPos = GameBase::getPosition(%player);
			%flag = $teamFlag[GameBase::getTeam(%player)];
			%flagpos = gamebase::getPosition(%flag);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot, 2);
			%rot =  "1.57079 0 "@ %zRot;
			%padd = "0 0 0";
			%pos = Vector::add($los::position,%padd);
			
			%camera = newObject("","StaticShape","TG::KillPadShape",true);
			addToSet("MissionCleanup", %camera);
			GameBase::startFadeOut(%camera);
			GameBase::setTeam(%camera, GameBase::getTeam(%player));
			GameBase::setRotation(%camera,"0 0 0");
			GameBase::setPosition(%camera,%pos);
			Gamebase::setMapName(%camera,"Kill Pad " @ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Kill Pad Deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "TG::KillPad"]++;
			return true;
		}
		else
		{ Client::sendMessage(%client,0,"Out Of Range, Deploy Closer"); }
	}
	else
	{ CenterPrint(%client, "<jc><f1>Ahh, you ain't got no more "@ %item.description @"s fella, THERE ALL GONE", 7); }
	return false;
}