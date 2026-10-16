for(%i = 0; %i < 7; %i++) $TeamItemCount[%i @ IBlock] = 0;

ItemImageData IBlockImage {	
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData IBlock {	
	description = "Big Fuckin Floor";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHeading[Walls];
	imageType = IBlockImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function IBlock::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function IBlock::onDeploy(%player,%item,%pos)
{ if(IBlock::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }

function CreateIBlockSimSet(%team)
{ %teleset = nameToID("MissionCleanup/IBlock"@ %team); if(%teleset == -1){	newObject("IBlock"@ %team, SimSet); addToSet("MissionCleanup", "IBlock"@ %team); } }

function IBlock::deployshape(%player, %item){
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	%playerPos = GameBase::getPosition(%player);
	%prot =GameBase::getRotation(%player);		
	
	%Set = newObject("set",SimSet);
	%Mask = $StaticObjectType;
	%num = containerBoxFillSet(%Set, %Mask, %playerPos, 200, 200, 200, 0);
	
	if(!TG::CheckFairPlay(%player, "IBlock", %set, %num))
	{ return false; }
	
	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client, 1, "Can Not Deploy, yer maxed out.~wAccess_Denied.Wav"); return false; }
	
	// check flag pos and player pos.
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);
	if(Vector::getDistance(%flagpos, %playerPos) <= 50)
	{ Client::sendMessage(%client, 1, "Your To Close To Your Flag.~wAccess_Denied.Wav"); return false; }
	
	// ok here we go
	CreateIBlockSimSet(%team);
	
	%object = newObject("IBlock", "InteriorShape", "iblock.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/IBlock"@ %team, %object);
	%pos = rotateVector("0 0 -1.5", %prot);
	%pos = Vector::add(%playerPos, %pos);	
	%rot = "0 0 -3.132";
	%rot = Vector::add(%prot, %rot);
	
	GameBase::setRotation(%object, %rot);
	GameBase::setPosition(%object, %pos);
	GameBase::setTeam(%object, %team);
	GameBase::startFadeIn(%object);
	
	$TeamItemCount[%team @ %item]++;
	echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed a Massive Floor");
	Client::sendMessage(%client,0,%item.description @" deployed.");
	return true;
}