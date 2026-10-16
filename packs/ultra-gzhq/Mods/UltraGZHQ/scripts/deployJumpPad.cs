$InvList[JumpPadPack] = 1;
$MobileInvList[JumpPadPack] = 1;
$RemoteInvList[JumpPadPack] = 1;
AddItem(JumpPadPack);

$CanAlwaysTeamDestroy[JumpPad] = 1;

function deployJumpPad::Initialize()
{	
	$TeamItemCount[0 @ JumpPadPack] = 0;
	$TeamItemCount[1 @ JumpPadPack] = 0;
	$TeamItemCount[2 @ JumpPadPack] = 0;
	$TeamItemCount[3 @ JumpPadPack] = 0;
	$TeamItemCount[4 @ JumpPadPack] = 0;
	$TeamItemCount[5 @ JumpPadPack] = 0;
	$TeamItemCount[6 @ JumpPadPack] = 0;
	$TeamItemCount[7 @ JumpPadPack] = 0;
}

ItemImageData JumpPadPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData JumpPadPack
{
	description = "Jump Pad";
	shapeFile = "elevator_6x6_octagon";
	className = "Backpack";
	heading = $InvHead[ihDob];
	imageType = JumpPadPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JumpPadPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function JumpPadPack::onDeploy(%player,%item,%pos)
{
	if (JumpPadPack::deployShape(%player,%item)&& !$build)
		Player::decItemCount(%player,%item);
}


function JumpPadPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	
	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 -1") > 0.6)
	{
		Client::sendMessage(%client,0,"Canot deploy on ceiling.");
		return false;
	}

// check if object is in motion, for dropships and jail cell 
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	%obj = newObject("JumpPad","StaticShape",JumpPad,true);
	NukeList(%obj);
	%obj.cloakable = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,%team);
	%pos = Vector::add($los::position,"0 0 -0.5");
	%rot=GameBase::getRotation(%player);
//	GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
//	%pos = Vector::add(%pos,Vector::getFromRot(%rot,2,0));
	GameBase::setPosition(%obj,%pos);

	%pos=Vector::add(%rot,"0 0 3.14159");
	GameBase::setRotation(%obj,GameBase::getRotation(%player));

	Gamebase::setMapName(%sensor,"JumpPad");
	Client::sendMessage(%client,0,%item.description @ " deployed");
	echo("MSG: ",%client," deployed a JumpPad");

	$TeamItemCount[GameBase::getTeam(%obj) @ "JumpPadPack"]++;
	GameBase::startFadeIn(%obj);
	playSound(SoundPickupBackpack,$los::position);

	return true;
}

StaticShapeData JumpPad 
{
	shapeFile = "elevator_6x6_octagon";
	maxDamage = 250;
	maxEnergy = 200;
	debrisId = defaultDebrisMedium;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "JumpPad";
};

function JumpPadPack::Destruct(%this)
{
	JumpPadPack::doDamage(%this);
}

function JumpPadPack::doDamage(%this) 
{
}

function JumpPad::onDestroyed(%this)
{
	JumpPadPack::doDamage(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "JumpPadPack"]--;
}

function JumpPad::onCollision(%this,%obj)
{	
	if($debug) 
		event::collision(%this,%obj);

	if(getObjectType(%obj) != "Player")
		return;
	if(Player::isDead(%obj))
		return;
	if(%this.cloaked > 0 && getObjectType(%obj) == "Player")
	{
		//pop this visible for a second 
		%this.cloaked = "";
		GameBase::startFadein(%this);
	}	
	%clientId = Player::getClient(%obj);
//	%pteam = GameBase::getTeam(%obj);
//	%oteam = GameBase::getTeam(%this);
	%diffZ = getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);
	%tpos = GameBase::getPosition(%this);
	%opos = GameBase::getPosition(%obj);
	%tstartX = getWord(%tpos,0);
	%tstartY = getWord(%tpos,1);
	%tstartZ = getWord(%tpos,2);
	%ostartX = getWord(%opos,0);
	%ostartY = getWord(%opos,1);
	%ostartZ = getWord(%opos,2);
	%diffX = %ostartX-%tstartX;
	%diffY = %ostartY-%tstartY;
	%diffZ = %ostartZ-%tstartZ;
//	if(%pteam == %oteam)
//	{
		if(%obj.deployStandby!=1)
		{
			if(%diffZ > 0.950)
			{
				%obj.deployStandby = 1;
				//%msg="<f1>JumpPad : <f0>Aim the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
				//remoteEval(%clientId, "BP", %msg, 0);
				bottomprint(%clientId, "<f1>JumpPad : <f0>Aim the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.");
				JumpPadPack::CheckPlayer(%this,%obj);
			}
		}
		else if(%diffZ < 0.950)
		{
			remoteEval(%clientId, "CP", "", 0);
			%obj.deployStandby = 0;
		}
//	}
	return;
}

//from shifter, modified to use %trans
function JumpPadPack::CheckPlayer(%this,%obj)
{
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);

	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ-0.92;
	%deploy=0;
	%recall=1;

	if(%diffZ>0.5) %deploy=1;
	if(%diffZ<0) %deploy=-1;
	
	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%client);
	
	if(%deploy>0)
	{
		//begin deploy
		%armor=GameBase::getDataName(%obj);
		%mass=%armor.mass;
		%rot=GameBase::getRotation(%obj);

		%rnd=floor(getrandom()*30);
		if(%rnd > 20) 
		{
			GameBase::playSound(%this, debrisLargeExplosion, 0);
			Client::SendMessage(%client, 0, "K-E-R-S-P-R-O-I-N-G-g-g-g-!-!");
			%rnd = %rnd + 10;
		}
		else
		{
			GameBase::playSound(%this, SoundFireMortar, 0);
			Client::SendMessage(%client, 0, "SPROING!");
		}	
		%len = 40 + %rnd;
		%trans = GameBase::getMuzzleTransform(%obj);
		%tr= getWord(%trans,5);
		if(%tr < 0) %tr = -%tr;
		%tr = %tr+ 0.15;
		%up = %tr;
		%out = 1-%tr;
		%vec = Vector::getFromRot(%rot,%len*%mass*%out,%len*%mass*%up);
		Player::applyImpulse(%obj,%vec);
		schedule(%obj @ ".deployStandby=0;",0.1);
		%recall = 0;
		// end deploy
	}
	else if(%deploy < 0)
	{
		%recall = 0;
		%obj.deployStandby = 0;
	}
	if(%recall)
		schedule("JumpPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
	else
		remoteEval(%client, "CP", "", 0);
}
