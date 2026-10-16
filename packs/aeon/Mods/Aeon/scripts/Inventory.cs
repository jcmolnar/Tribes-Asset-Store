//- Because of the auto-Scientific-Notation in Tribes, we set a Wallet Cap to avoid , the rest you will have to bank
$Aeon::WalletMax = "999999";

$Aeon::invStyle[LATMk1] = "held";
$Aeon::invStyle[CnTool] = "held";
$Aeon::invStyle[RepairKit] = "held";
$Aeon::invStyle[RepairGun] = "held";
$Aeon::invStyle[DeployPack] = "held";
$Aeon::invStyle[Vege1Item] = "held";
$Aeon::invStyle[Ore1Item] = "held";
$Aeon::invStyle[Book] = "held";
$Aeon::invStyle[Flag] = "ownd";
$Aeon::invStyle[ScoutVehicle] = "ownd";
$Aeon::invStyle[RazorVehicle] = "ownd";

$Aeon::invOwnFunc[Flag] = true;
$Aeon::invOwnFunc[ScoutVehicle] = true;
$Aeon::invOwnFunc[RazorVehicle] = true;

$Aeon::invNodrop[Unarmed] = true;

function InvOwned::getNext(%clientId,%item)
{
	%id = Aeon::getAeonID(%clientId);
	for(%i = 1; $Aeon::ClientInfo[%id,ownd,%item@" "@%i] != ""; %i++){}
	return %i;
}

function InvOwned::getCount(%clientId,%item)
{
	%id = Aeon::getAeonID(%clientId);
	%count = 0;
	for(%i = 1; %i < 10; %i++) {
		if($Aeon::ClientInfo[%id,ownd,%item@" "@%i] != "")
			%count++;
	}
	return %count;
}

function InvOwned::hasRoom(%obj,%pos)
{
	%rad = GameBase::getRadius(%obj);
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType|$SimInteriorObjectType|$SimPlayerObjectType,%pos,%rad,%rad,%rad);
	if(!%num || (%num == 1 && Group::getObject(%set,0) == %obj)) {
		deleteObject(%set);
		return true;
	}
	deleteObject(%set);
	return false;
}

function InvOwned::checkOwner(%this)
{
	%owner = %this.owner;
	%ownId = %this.ownId;
	%owNum = %this.owndNum;
	if((GameBase::getTeam(%owner) != 0 && %owner.observerMode != "observe") || Aeon::getAeonID(%owner) != %ownId) {
		deleteObject(%this);
		return;
	}
	%item = GameBase::getDataName(%this);
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"pos"] = GameBase::getPosition(%this);
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"rot"] = GameBase::getRotation(%this);
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"dmg"] = GameBase::getDamageLevel(%this);
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"nam"] = GameBase::getMapName(%this);
	Aeon::ownedInv(%owner,%item,%owNum);
	%next = 10;
	if(Item::getVelocity(%owner) == "0 0 0")
		%next = 5;
	schedule("InvOwned::checkOwner("@%this@");",%next,%this);
}

function InvOwned::Make(%clientId,%info)
{
	if(%clientId < 2049)
		return;
	%id = Aeon::getAeonID(%clientId);
	%item = getWord(%info,0);
	%count = getWord(%info,1);
	for(%i = 1; %i <= %count; %i++) {
		if($Aeon::ClientInfo[%id,"Ownd",%item@" "@%i,"pos"] != "")
			Eval("InvOwnedMake::"@%item@"("@%clientId@",\""@%i@"\");");
	}
}

function InvOwnedMake::Item(%clientId,%type,%num)
{
	if(%clientId < 2049)
		return;
	%id = Aeon::getAeonID(%clientId);
	%title = %type@" "@%num;
	%pos = $Aeon::ClientInfo[%id,"Ownd",%title,"pos"];
	%rot = $Aeon::ClientInfo[%id,"Ownd",%title,"rot"];
	%nam = $Aeon::ClientInfo[%id,"Ownd",%title,"nam"];
	%dmg = $Aeon::ClientInfo[%id,"Ownd",%title,"dmg"];
	%obj = newObject("",Item,%type,1,false);
	addToSet("MissionCleanup",%obj);
	%pos = Vector::add(%pos,"0 0 1");
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%nam);
	Gamebase::setDamageLevel(%obj,%dmg);
	%obj.owner = %clientId;
	%obj.ownId = Aeon::getAeonID(%clientId);
	%obj.owndNum = %num;
	$Aeon::ClientInfo[%id,ownd,%title] = %obj;
	InvOwned::checkOwner(%obj);
}

function InvOwnedMake::Vehicle(%clientId,%type,%num)
{
	if(%clientId < 2049)
		return;
	%id = Aeon::getAeonID(%clientId);
	%title = %type@" "@%num;
	%pos = $Aeon::ClientInfo[%id,"Ownd",%title,"pos"];
	%rot = $Aeon::ClientInfo[%id,"Ownd",%title,"rot"];
	%nam = $Aeon::ClientInfo[%id,"Ownd",%title,"nam"];
	%dmg = $Aeon::ClientInfo[%id,"Ownd",%title,"dmg"];
	%obj = newObject("",flier,$DataBlockName[%type],true);
	addToSet("MissionCleanup",%obj);
	//if(InvOwned::hasRoom(%obj,%pos) == false)
	//	%pos = getWord(%pos,0)@" "@getWord(%pos,1)@" "@Property::terrainHeight(%pos) + 2;
	%pos = Vector::add(%pos,"0 0 1");
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%nam);
	Gamebase::setDamageLevel(%obj,%dmg);
	%obj.owner = %clientId;
	%obj.ownId = Aeon::getAeonID(%clientId);
	%obj.owndNum = %num;
	%clientId.hasKey[%obj] = true;
	$Aeon::ClientInfo[%id,ownd,%title] = %obj;
}

function InvOwnedMake::ScoutVehicle(%clientId,%num)
{
	InvOwnedMake::Vehicle(%clientId,"ScoutVehicle",%num);
}

function InvOwnedMake::RazorVehicle(%clientId,%num)
{
	InvOwnedMake::Vehicle(%clientId,"RazorVehicle",%num);
}

function InvOwnedMake::flag(%clientId,%num)
{
	InvOwnedMake::Item(%clientId,"Flag",%num);
}

