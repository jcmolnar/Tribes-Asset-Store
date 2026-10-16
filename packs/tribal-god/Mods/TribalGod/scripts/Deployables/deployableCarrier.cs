//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemImageData DecoyCarrierImage
{
	shapeFile = "marmor";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.5;
};

ItemData DecoyCarrier
{
	description = "Decoy Carrier";
	shapeFile = "marmor";
	className = "Backpack";
	heading = $InvHeading[Deployables];
	imageType = DecoyCarrierImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 6000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = false;
};

function DecoyCarrier::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function DecoyCarrier::onDeploy(%player,%item,%pos)
{ if(DecoyCarrier::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function DecoyCarrier::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%clientName = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DecoyCarrier"] >= $TeamItemMax[DecoyCarrier])
	{ Client::sendMessage(%client,0,"Can Not Deploy, You've passed your limit "); return false; }
	
	
	%obj = getObjectType($los::object);
	%set = newObject("DecoyCarrier",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
	%num = CountObjects(%set,"DecoyCarrier",%num);
	deleteObject(%set);

	%objDevice =   newObject("DecoyCarrier","Staticshape",Hologram1,true);
	%objDevice.objSide2 = newObject("DecoyCarrier2","Staticshape",Flag101,true);
	%objDevice.objSide3 = newObject("DecoyCarrier3","Staticshape",DecoyWeapon,true);
	
	%objDevice.objSide1.objParent = %objDevice;
	%objDevice.objSide2.objParent = %objDevice;
	%objDevice.objSide3.objParent = %objDevice;
	
	addToSet(MissionCleanup, %objDevice);
	addToSet(MissionCleanup, %objDevice.objSide2);
	addToSet(MissionCleanup, %objDevice.objSide3);
	
	
	%rot = gamebase::getrotation(%player);
    %playerpos = GameBase::getPosition(%player);

	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "0 2.5 0",%rot));
	GameBase::setRotation(%objDevice,%rot);
	GameBase::setPosition(%objDevice,%pos);
	GameBase::setTeam(%objDevice,GameBase::getTeam(%player));
	Gamebase::setMapName(%objDevice,%clientName @" ");

    %pos = Vector::add(%playerpos, EmplacementPack::rotVector( "0 2.12599 1.5",%rot));
	GameBase::setRotation(%objDevice.objSide2,%rot);
	GameBase::setPosition(%objDevice.objSide2,%pos);
	GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));
	
	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "0.51 3.099 1.5",%rot));
	GameBase::setRotation(%objDevice.objSide3,%rot);
	GameBase::setPosition(%objDevice.objSide3,%pos);
	GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));

	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%sensor) @ "DecoyCarrier"]++;
	echo("MSG: ",%client," deployed a Decoy");
	Client::sendMessage(%client,0, "Decoy Carrier deployed");
	return true;
}