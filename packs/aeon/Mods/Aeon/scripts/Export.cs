$SpwnTDesc[lstLoc] = "Last Location";
$SpwnTDesc[lastMS] = "Last Manual Save";
$SpwnTDesc[myProp] = "My Property";
$SpwnTDesc[hereMk] = "This Location";
$SpwnTDesc[random] = "In Central";

$Aeon::startCash = 0;
$Aeon::autoExport = 60.0;
$Aeon::clExportCollapse = 1.0;
$Aeon::bankExportCollapse = 1.0;
$Aeon::propExportCollapse = 1.5;

function Aeon::mainLoop()
{
	if(getSimTime() >= ($Aeon::lastExport + $Aeon::autoExport)) {
		Aeon::ExportInfo("all");
		$Aeon::lastExport = getSimTime();
	}
	if(getSimTime() >= ($Aeon::lastRock+$Aeon::rockFall/getNumClients()) || $impactCount < getNumClients()*3) {
		Aeon::rockCall();
		$Aeon::lastRock = getSimTime();
	}
	schedule("Aeon::mainLoop();",10.0);
}

function Aeon::startMatch()
{
	$Aeon::lastRock = "";
	$Aeon::lastExport = "";
	if(isFile("temp\\AeonClassifieds.cs"))
		exec("AeonClassifieds.cs");
	AI::init();
	Central::clear();
	Central::initialize();
	Atmos::reset();
	Atmos::loop();
	Aeon::clearProperty();
	Aeon::loadProperty();
	Aeon::mainLoop();
	Firearm::buildList();
	Combine::initStrings();
}

function Aeon::gameTime(%time,%sec)
{
	%rate = $Atmos::updateTime*$DynSun::rotRate; //- 1 degree
	%rot = %time*%rate;
	%secs = (86400*(%rot/360));
	if(%sec)
		return %secs;
	%time = String::time(%secs);
	return %time;
}

function Aeon::getTime(%sec)
{
	%secs = (86400*($DynSun::rotation[1]/-360));
	if(%sec)
		return %secs;
	%time = String::time(%secs,true);
	return %time;
}

function Aeon::ExportInfo(%clientId,%manual,%inv)
{
	if(!%manual)
		%manual = false;
	if($Aeon::ClientInfo[%clientId,exportCnt] == "")
		$Aeon::ClientInfo[%clientId,exportCnt] = 0;
	$Aeon::ClientInfo[%clientId,exportCnt]++;
	$Aeon::ClientInfo[%clientId,lastExport] = getSimTime()+($Aeon::ClientInfo[%clientId,exportCnt]/100);
	schedule("Aeon::exportClientCheck("@%clientId@",\""@%manual@"\",\""@%inv@"\","@$Aeon::ClientInfo[%clientId,exportCnt]@");",$Aeon::clExportCollapse,%clientId);
}

function Aeon::exportClientCheck(%clientId,%manual,%inv,%count)
{
	%time = $Aeon::ClientInfo[%clientId,lastExport];
	if(%time <= (getSimTime()-$Aeon::clExportCollapse) && %time != "") {
		$Aeon::ClientInfo[%clientId,lastExport] = "";
		$Aeon::ClientInfo[%clientId,exportCnt] = "";
		Aeon::ExportClient(%clientId,%manual,%inv);
	}
	else if(%count <= 1) {
		schedule("Aeon::exportClientCheck("@%clientId@",\""@%manual@"\",\""@%inv@"\","@%count@");",0.1,%clientId);
	}
}

function Aeon::ExportClient(%clientId,%manual,%inv)
{
	if(%clientId == "all") {
		if(Client::getFirst() < 2049)
			return;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			Aeon::ExportInfo(%cl);
		return;
	}
	else if(%clientId < 2049)
		return;
	%player = Client::getOwnedObject(%clientId);
	if(%player < 8000 || getObjectType(%player) != "Player" || Player::isDead(%player) || %player.outArea)
		return false;
	%id = Aeon::getAeonID(%clientId);
	%name = Client::getName(%clientId);
	if(!%inv)
		Aeon::getInventory(%clientId);
	Aeon::getPerms(%clientId);
	%file = Aeon::getExportFile(%clientId)@".cs";
	$Aeon::ClientInfo[%id,time] += (getSimTime() - $JoinTime[%clientId]);
	$JoinTime[%clientId] = getSimTime();
	$Aeon::ClientInfo["[\""@%id@"\",\"Name\"]"] = Client::getName(%clientId);
	$Aeon::ClientInfo["[\""@%id@"\",\"pass\"]"] = $Aeon::ClientInfo[%id,pass];
	$Aeon::ClientInfo["[\""@%id@"\",\"cNam\"]"] = $Aeon::ClientInfo[%id,cNam];
	$Aeon::ClientInfo["[\""@%id@"\",\"cash\"]"] = $Aeon::ClientInfo[%id,cash] = floor($Aeon::ClientInfo[%id,cash]);
	$Aeon::ClientInfo["[\""@%id@"\",\"krma\"]"] = $Aeon::ClientInfo[%id,krma];
	$Aeon::ClientInfo["[\""@%id@"\",\"pnts\"]"] = $Aeon::ClientInfo[%id,pnts];
	$Aeon::ClientInfo["[\""@%id@"\",\"ownP\"]"] = $Aeon::ClientInfo[%id,ownP];
	$Aeon::ClientInfo["[\""@%id@"\",\"cMod\"]"] = $Aeon::ClientInfo[%id,cMod];
	$Aeon::ClientInfo["[\""@%id@"\",\"jCnt\"]"] = $Aeon::ClientInfo[%id,jCnt];
	$Aeon::ClientInfo["[\""@%id@"\",\"kCnt\"]"] = $Aeon::ClientInfo[%id,kCnt];
	$Aeon::ClientInfo["[\""@%id@"\",\"cGiv\"]"] = $Aeon::ClientInfo[%id,cGiv];
	$Aeon::ClientInfo["[\""@%id@"\",\"kGiv\"]"] = $Aeon::ClientInfo[%id,kGiv];
	$Aeon::ClientInfo["[\""@%id@"\",\"time\"]"] = $Aeon::ClientInfo[%id,time];
	$Aeon::ClientInfo["[\""@%id@"\",\"mute\"]"] = $Aeon::ClientInfo[%id,mute];
	$Aeon::ClientInfo["[\""@%id@"\",\"lBuy\"]"] = $Aeon::ClientInfo[%id,lBuy];
	$Aeon::ClientInfo["[\""@%id@"\",\"book\"]"] = $Aeon::ClientInfo[%id,book];
	$Aeon::ClientInfo["[\""@%id@"\",\"book\",\"bookDebt\"]"]= $Aeon::ClientInfo[%id,book,bookDebt];
	$Aeon::ClientInfo["[\""@%id@"\",\"book\",\"lastBook\"]"]= $Aeon::ClientInfo[%id,book,lastBook];
	$Aeon::ClientInfo["[\""@%id@"\",\"book\",\"lastTime\"]"]= $Aeon::ClientInfo[%id,book,lastTime];
	$Aeon::ClientInfo["[\""@%id@"\",\"pref\",\"txtClr\"]"] = $Aeon::ClientInfo[%id,pref,txtClr];
	$Aeon::ClientInfo["[\""@%id@"\",\"pref\",\"scrSpd\"]"] = $Aeon::ClientInfo[%id,pref,scrSpd];
	$Aeon::ClientInfo["[\""@%id@"\",\"pref\",\"cShown\"]"] = $Aeon::ClientInfo[%id,pref,cShown];
	$Aeon::ClientInfo["[\""@%id@"\",\"pref\",\"spwnTp\"]"] = $Aeon::ClientInfo[%id,pref,spwnTp];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Grenade\"]"] = $Aeon::ClientInfo[%id,fKey,Grenade];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator1\"]"] = $Aeon::ClientInfo[%id,fKey,Activator1];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator2\"]"] = $Aeon::ClientInfo[%id,fKey,Activator2];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator3\"]"] = $Aeon::ClientInfo[%id,fKey,Activator3];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator4\"]"] = $Aeon::ClientInfo[%id,fKey,Activator4];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator5\"]"] = $Aeon::ClientInfo[%id,fKey,Activator5];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator6\"]"] = $Aeon::ClientInfo[%id,fKey,Activator6];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator7\"]"] = $Aeon::ClientInfo[%id,fKey,Activator7];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator8\"]"] = $Aeon::ClientInfo[%id,fKey,Activator8];
	$Aeon::ClientInfo["[\""@%id@"\",\"fKey\",\"Activator9\"]"] = $Aeon::ClientInfo[%id,fKey,Activator9];
	Aeon::updateSkills(%id);
	if($Aeon::ClientInfo[%id,pref,spwnTp] == "lstLoc" && Aeon::spawnCheck(%clientId) == "true") {
		$Aeon::ClientInfo[%id,sPos] = GameBase::getPosition(%player);
		$Aeon::ClientInfo[%id,sRot] = GameBase::getRotation(%player);
	}
	else if($Aeon::ClientInfo[%id,pref,spwnTp] == "lastMS" && %manual == "true" && Aeon::spawnCheck(%clientId) == "true") {
		$Aeon::ClientInfo[%id,sPos] = GameBase::getPosition(%player);
		$Aeon::ClientInfo[%id,sRot] = GameBase::getRotation(%player);
	}
	else if($Aeon::ClientInfo[%id,pref,spwnTp] == "myProp") {
		%props = $Aeon::ClientInfo[%id,ownP];
		%propRnd = floor(getRandom()*AeonStr::getWordCount(%props));
		%propNum = getWord(%props,%propRnd);
		$Aeon::ClientInfo[%id,sPos] = Property::getSpawnPos(%propNum);
		$Aeon::ClientInfo[%id,sRot] = "0 0 0";
	}
	$Aeon::ClientInfo["[\""@%id@"\",\"sPos\"]"] = $Aeon::ClientInfo[%id,sPos];
	$Aeon::ClientInfo["[\""@%id@"\",\"sRot\"]"] = $Aeon::ClientInfo[%id,sRot] = Vector::mult($Aeon::ClientInfo[%id,sRot],"0 0 1");
	$Aeon::ClientInfo["[\""@%id@"\",\"Inv\",\"num\"]"] = $Aeon::ClientInfo[%id,Inv,num];
	for(%i = 1; $Aeon::ClientInfo[%id,keys,%i] != ""; %i++)
		$Aeon::ClientInfo["[\""@%id@"\",\"keys\",\""@%i@"\"]"] = $Aeon::ClientInfo[%id,keys,%i];
	%exportTo = "temp\\"@%file;
	if(isFile(%exportTo))
		File::delete(%exportTo);
	echo("Exporting Client: "@%id);
	if(%clientId > 2048)
		Export("Aeon::ClientInfo[\""@%id@"\",*",%exportTo,false);
}

function Aeon::updateSkills(%id)
{
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"spentStr\"]"] = $Aeon::ClientInfo[%id,skll,spentStr];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"mStr\"]"] = $Aeon::ClientInfo[%id,skll,mStr];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"mStm\"]"] = $Aeon::ClientInfo[%id,skll,mStm];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"mAgl\"]"] = $Aeon::ClientInfo[%id,skll,mAgl];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"mPer\"]"] = $Aeon::ClientInfo[%id,skll,mPer];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"mInt\"]"] = $Aeon::ClientInfo[%id,skll,mInt];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"htWr\"]"] = $Aeon::ClientInfo[%id,skll,htWr];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"stel\"]"] = $Aeon::ClientInfo[%id,skll,stel];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"loot\"]"] = $Aeon::ClientInfo[%id,skll,loot];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"aggr\"]"] = $Aeon::ClientInfo[%id,skll,aggr];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"geol\"]"] = $Aeon::ClientInfo[%id,skll,geol];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"metl\"]"] = $Aeon::ClientInfo[%id,skll,metl];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"herb\"]"] = $Aeon::ClientInfo[%id,skll,herb];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"meng\"]"] = $Aeon::ClientInfo[%id,skll,meng];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"eeng\"]"] = $Aeon::ClientInfo[%id,skll,eeng];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"arch\"]"] = $Aeon::ClientInfo[%id,skll,arch];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"avia\"]"] = $Aeon::ClientInfo[%id,skll,avia];
	$Aeon::ClientInfo["[\""@%id@"\",\"skll\",\"Life\"]"] = $Aeon::ClientInfo[%id,skll,Life];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"htWr\"]"] = $Aeon::ClientInfo[%id,know,htWr];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"stel\"]"] = $Aeon::ClientInfo[%id,know,stel];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"loot\"]"] = $Aeon::ClientInfo[%id,know,loot];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"aggr\"]"] = $Aeon::ClientInfo[%id,know,aggr];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"geol\"]"] = $Aeon::ClientInfo[%id,know,geol];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"metl\"]"] = $Aeon::ClientInfo[%id,know,metl];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"herb\"]"] = $Aeon::ClientInfo[%id,know,herb];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"meng\"]"] = $Aeon::ClientInfo[%id,know,meng];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"eeng\"]"] = $Aeon::ClientInfo[%id,know,eeng];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"arch\"]"] = $Aeon::ClientInfo[%id,know,arch];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"avia\"]"] = $Aeon::ClientInfo[%id,know,avia];
	$Aeon::ClientInfo["[\""@%id@"\",\"know\",\"Life\"]"] = $Aeon::ClientInfo[%id,know,Life];
}

function Aeon::getPerms(%clientId)
{
	%id = Aeon::getAeonID(%clientId);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%id2 = Aeon::getAeonID(%cl);
		%prms = $Aeon::ClientInfo[%id,prms,%id2];
		if(%prms  > 0)
			$Aeon::ClientInfo["[\""@%id@"\",\"prms\",\""@%id2@"\"]"] = %prms;
	}
}

function Aeon::getInventory(%clientId,%inv)
{
	%scrollSpeed = 2;
	if(%clientId > 2048) {
		%id = Aeon::getAeonID(%clientId);
		//echo("Exporting Client Inventory: "@%id);
		%player = Client::getOwnedObject(%clientId);
		if(%player < 8000 || Player::isDead(%player))
			return;
		Activators::setCount(%clientId);
		%num = 0;
		%max = getNumItems();
		%ownd = 0;
		for(%i = 0; %i < %max; %i++) {
			%data = getItemData(%i);
			%count = Player::getItemCount(%player,%data);
			if($Aeon::grabTempCount[%player,%data]) {
				%delta = $Aeon::grabTempCount[%player,%data];
				%print = "<jc><f3>Got <f0>"@%delta@" "@Item::getDescription(%data,%delta)@"<f3>.";
				if(%temp == "")
					%temp = 0;
				else
					%temp++;
				if(%clientId.dispNew)
					schedule("bottomPrint("@%clientId@",\""@%print@"\");",%temp/%scrollSpeed,%clientId);
				$Aeon::grabTempCount[%player,%data] = "";
			}
			if(InvOwned::getCount(%clientId,%data) > 0) {
				%count = InvOwned::getCount(%clientId,%data);
				Aeon::ownedInv(%clientId,%data);
			}
			else if($Aeon::invStyle[%data] == "ownd")
				%count = 0;
			if(%count > 0 && %data != DeployPack) {
				%info = %data@" "@%count;
				$Aeon::ClientInfo["[\""@%id@"\",\"Inv\",\""@%num++@"\"]"] = $Aeon::ClientInfo[%id,Inv,%num] = %info;
				%clientId.invNum[%data] = %num;
			}
		}
		$Aeon::ClientInfo["[\""@%id@"\",\"Inv\",\""@%num++@"\"]"] = $Aeon::ClientInfo[%id,Inv,%num] = "";
		if(%inv == true && (getSimTime() > %clientId.lastInvExport+2.0)) {
			Aeon::ExportInfo(%clientId,"",true);
		}
	}
	%clientId.lastInvExport = getSimTime();
}

function Aeon::ownedInv(%clientId,%item,%update)
{
	%id = Aeon::getAeonID(%clientId);
	if(%update) {
		%title = %item@" "@%update;
		$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"pos\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"pos"];
		$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"rot\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"rot"];
		$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"nam\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"nam"];
		$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"dmg\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"dmg"];
		return;
	}
	for(%i = 1; (%ownd = $Aeon::ClientInfo[%id,ownd,%item@" "@%i]) != ""; %i++) {
		%pos = GameBase::getPosition(%ownd);
		%dmg = GameBase::getDamageLevel(%ownd);
		if(%pos == "0 0 0" || %ownd == -1 || %ownd == "") {
			%title = %item@" "@%i;
			$Aeon::ClientInfo[%id,"Ownd",%title,"pos"] = "";
			$Aeon::ClientInfo[%id,"Ownd",%title,"rot"] = "";
			$Aeon::ClientInfo[%id,"Ownd",%title,"nam"] = "";
			$Aeon::ClientInfo[%id,"Ownd",%title,"dmg"] = "";
		}
		else {
			%rot = GameBase::getRotation(%ownd);
			%nam = GameBase::getMapName(%ownd);
			%title = %item@" "@%i;
			$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"pos\"]"] = %pos;
			$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"rot\"]"] = %rot;
			$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"nam\"]"] = %nam;
			$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"dmg\"]"] = %dmg;
		}
	}
}

function Aeon::ExportClassifieds()
{
	%exportTo = "temp\\AeonClassifieds.cs";
	if(isFile(%exportTo))
		File::delete(%exportTo);
	Export("Aeon::classified[*",%exportTo,false);
}

function Aeon::clientInfo(%id)
{
	if($idFileLoaded[%id] == "") {
		%file = "AeonClient["@%id@"].cs";
		if(isFile("temp\\"@%file)) {
			exec(%file);
			$idFileLoaded[%id] = true;
			Property::updateOwner(%id);
			return true;
		}
	}
	return false;
}

function Aeon::loadClient(%clientId)
{
	if(%clientId < 2049)
		return;
	%id = Aeon::getAeonID(%clientId);
	%name = Client::getname(%clientId);
	%file = Aeon::getExportFile(%clientId)@".cs";
	if(isFile("temp\\"@%file))
		exec(%file);
	else {
		%file = Aeon::getExportFile(%clientId,true)@".cs";
		if(isFile("temp\\"@%file)) {
			exec(%file);
			%id = Aeon::getAeonIDold(%clientId);
		}
	}
	if($Aeon::ClientInfo[%id,"time"] > 0 && $Aeon::ClientInfo[%id,"jCnt"] > 0) {
		$Aeon::ClientInfo[%id,jCnt]++;
	}
	else {
		$Aeon::ClientInfo[%id,name] = Client::getName(%clientId);
		$Aeon::ClientInfo[%id,pass] = "";
		$Aeon::ClientInfo[%id,cNam] = Client::getName(%clientId);
		$Aeon::ClientInfo[%id,cash] = $Aeon::startCash;
		$Aeon::ClientInfo[%id,krma] = 0;
		$Aeon::ClientInfo[%id,pnts] = 0;
		$Aeon::ClientInfo[%id,jCnt] = 1;
		$Aeon::ClientInfo[%id,kCnt] = 0;
		$Aeon::ClientInfo[%id,cGiv] = 0;
		$Aeon::ClientInfo[%id,kGiv] = 0;
		$Aeon::ClientInfo[%id,time] = 0;
		$Aeon::ClientInfo[%id,pref,txtClr] = 3;
		$Aeon::ClientInfo[%id,pref,scrSpd] = 9;
		$Aeon::ClientInfo[%id,pref,spwnTp] = "random";
		$Aeon::ClientInfo[%id,pref,cShown] = 1;
		$Aeon::ClientInfo[%id,skll,spentStr] = "";
		$Aeon::ClientInfo[%id,skll,mStr] = 0;
		$Aeon::ClientInfo[%id,skll,htWr] = 0;
		$Aeon::ClientInfo[%id,skll,stel] = 0;
		$Aeon::ClientInfo[%id,skll,loot] = 0;
		$Aeon::ClientInfo[%id,skll,aggr] = 0;
		$Aeon::ClientInfo[%id,skll,geol] = 0;
		$Aeon::ClientInfo[%id,skll,metl] = 0;
		$Aeon::ClientInfo[%id,Inv,1] = "CnTool 1";
		$Aeon::ClientInfo[%id,Inv,2] = "RepairKit 1";
		Aeon::ExportInfo(%clientId);
	}
	%clientId.allowObs = "";
	$idFileLoaded[%id] = true;
	Property::updateOwner(%id);
}

function Aeon::ExportBank(%clientId)
{
	%id = Aeon::getAeonId(%clientId);
	if($Aeon::Bank[%id,exportCnt] == "")
		$Aeon::Bank[%id,exportCnt] = 0;
	$Aeon::Bank[%id,exportCnt]++;
	$Aeon::Bank[%id,lastExport] = getSimTime()+($Aeon::Bank[%id,exportCnt]/100);
	schedule("Aeon::exportBankCheck(\""@%id@"\","@$Aeon::Bank[%id,exportCnt]@");",$Aeon::bankExportCollapse,%clientId);
}

function Aeon::exportBankCheck(%id,%count)
{
	%time = $Aeon::Bank[%id,lastExport];
	if(%time <= (getSimTime()-$Aeon::bankExportCollapse) && %time != "") {
		$Aeon::Bank[%id,lastExport] = "";
		$Aeon::Bank[%id,exportCnt] = "";
		Aeon::ExportBank2(%id);
	}
	else if(%count <= 1)
		schedule("Aeon::exportBankCheck(\""@%id@"\","@%count@");",0.1);
}

function Aeon::ExportBank2(%id)
{
	%exportTo = "temp\\AeonBank["@%id@"].cs";
	Bank::update(%id);
	echo("Exporting Bank: "@%id);
	if(isFile(%exportTo))
		File::delete(%exportTo);
	Export("Aeon::Bank[\""@%id@"\"*",%exportTo,false);
}

function Aeon::ExportProperty(%prop,%num)
{
	if(!%num || %num < 1)
		%num = %prop.propID;
	if($Aeon::Property[%prop,exportCnt] == "")
		$Aeon::Property[%prop,exportCnt] = 0;
	$Aeon::Property[%prop,exportCnt]++;
	$Aeon::Property[%prop,lastExport] = getSimTime()+($Aeon::Property[%prop,exportCnt]/100);
	schedule("Aeon::exportPropCheck("@%prop@","@%num@","@$Aeon::Property[%prop,exportCnt]@");",$Aeon::propExportCollapse,%prop);
}

function Aeon::ExportPropCheck(%prop,%num,%count)
{
	%time = $Aeon::Property[%prop,lastExport];
	if(%time <= (getSimTime()-$Aeon::propExportCollapse) && %time != "") {
		$Aeon::Property[%prop,lastExport] = "";
		$Aeon::Property[%prop,exportCnt] = "";
		Aeon::ExportProperty2(%prop,%num);
	}
	else if(%count <= 1)
		schedule("Aeon::exportPropCheck("@%prop@","@%num@","@%count@");",0.1,%prop);
}

function Aeon::ExportProperty2(%prop,%num)
{
	%propManager = nameToID("MissionCleanup\\Property");
	%propCount = Group::objectCount(%propManager);
	if(%prop <= 0) {
		for(%i = 0; %i < %propCount; %i++) {
			%obj = Group::getObject(%propManager,%i);
			Aeon::ExportProperty2(%obj,%i+1);
		}
	}
	else {
		if(!%num || %num < 1)
			%num = %prop.propID;
		%ownedCount = Group::objectCount(%prop);
		%owner = $Aeon::property[%prop.propID,owner];

		$Aeon::property["[\""@%num@"\",\"owner\"]"] = %owner;
		$Aeon::property["[\""@%num@"\",\"locat\"]"] = $Aeon::property[%prop.propID,locat];
		$Aeon::property["[\""@%num@"\",\"Width\"]"] = $Aeon::property[%prop.propID,Width];
		$Aeon::property["[\""@%num@"\",\"Lngth\"]"] = $Aeon::property[%prop.propID,Lngth];
		$Aeon::property["[\""@%num@"\",\"HghtZ\"]"] = $Aeon::property[%prop.propID,HghtZ];
		$Aeon::property["[\""@%num@"\",\"prprt\"]"] = $Aeon::property[%prop.propID,prprt];
		%count = -1;
		for(%i = 0; %i < %ownedCount; %i++) {
			%obj = Group::getObject(%prop,%i);
			%data = GameBase::getDataName(%obj);
			%nam = GameBase::getMapName(%obj);
			if(String::findSubStr(Object::getName(%obj),"PropBox") != 0) {
				%count++;
				if(String::findSubStr(%data,"FencePost") == 0 && Aeon::isHere(%owner)) {
					%cNam = $Aeon::ClientInfo[%owner,Name];
					if(String::findSubStr(%nam,"NW") > 0)
						%nam = %cNam@"'s NW Post";
					else if(String::findSubStr(%nam,"NE") > 0)
						%nam = %cNam@"'s NE Post";
					else if(String::findSubStr(%nam,"SW") > 0)
						%nam = %cNam@"'s SW Post";
					else if(String::findSubStr(%nam,"SE") > 0)
						%nam = %cNam@"'s SE Post";
					GameBase::setMapName(%obj,%nam);
				}
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"itm\"]"] = %obj.ownsItem;
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"typ\"]"] = getObjectType(%obj);
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"lok\"]"] = %obj.locked;
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"nam\"]"] = %nam;
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"pos\"]"] = GameBase::getPosition(%obj);
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"rot\"]"] = GameBase::getRotation(%obj);
				$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"dmg\"]"] = GameBase::getDamageLevel(%obj);
				//if(%obj.bindLight) {
				//	%light = Lights::getExportString(%obj.bindLight);
				//	$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"lgt\"]"] = %light;
				//}
			}
		}
		%count++;
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"itm\"]"] = $Aeon::property[%num,piece,%count,itm] = "";
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"typ\"]"] = $Aeon::property[%num,piece,%count,typ] = "";
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"lok\"]"] = $Aeon::property[%num,piece,%count,lok] = "";
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"nam\"]"] = $Aeon::property[%num,piece,%count,nam] = "";
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"pos\"]"] = $Aeon::property[%num,piece,%count,pos] = "";
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"rot\"]"] = $Aeon::property[%num,piece,%count,rot] = "";
		$Aeon::property["[\""@%num@"\",\"piece\",\""@%count@"\",\"dmg\"]"] = $Aeon::property[%num,piece,%count,dmg] = "";

		$AeonProperty[%num,pPrev] = %count;
		%file = "AeonProperty["@%num@"].cs";
		%exportTo = "temp\\"@%file;
		//echo("Exporting Prop: "@%num);
		if(isFile(%exportTo))
			File::delete(%exportTo);
		Export("Aeon::property[\""@%num@"\",*",%exportTo,false);
	}
}

function Aeon::clearProperty()
{
	%propManager = nameToID("MissionCleanup\\Property");
	if(%propManager != -1) {
		for(%i = 0; %i < Group::objectCount(%propManager); %i++)
			deleteObject(Group::getObject(%propManager,%i));
		deleteObject(%propManager);
	}
	return true;
}

function Aeon::loadProperty()
{
	%fileBase = "AeonProperty[*";
	%propList = %prop = Aeon::alphaCacheFile(%fileBase,13);
	for(%i = 0; getWord(%propList,%i) != -1; %i++) {
		%num = getWord(%propList,%i);
		%prop = "AeonProperty["@%num@"].cs";
		$Aeon::property[%prop,pcCnt] = 0;
		$Aeon::property[%prop,lastP] = 0;
		exec(%prop);
		$Property::lastExport[%num] = 0;
		if(getWord($Aeon::property[%num,owner],0) != -1)
			Property::reAdd(%num);
	}
	$Property::last = Property::getNext();
}

function Aeon::alphaCacheFile(%fileBase,%tic)
{
	%file = File::findFirst(%fileBase);
	%str = "";
	while(%file != "") {
		%num = String::getSubStr(%file,%tic,String::indexOf(%file,"]")-%tic);
		%str = String::alphaInsert(%str,%num@" ");
		%file = File::findNext(%fileBase);
	}
	return AeonStr::trim(%str);
}

function Aeon::getAeonIDold(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	%id = String::getSubStr(%ip,0,String::indexOf(%ip,":",3));
	return %id;
}

function Aeon::getClient(%id,%alt)
{
	//%name = String::getSubStr(%id,0,String::indexOf(%id,"@"));
	%name = Aeon::getName(%id);
	%clientId = getClientByName(%name);
	if(%clientId > 2048)
		return %clientId;
	if(%alt) {
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			%nam = Client::getName(%cl);
			if(%nam == %name) // || %nam == Aeon::hashString(%name,true))
				return %cl;
		}
		return false;
	}
	return false;
}

function Aeon::getAeonID(%clientId)
{
	%name = Client::getName(%clientId);
	%pass = $Client::info[%clientId,5];
	%inf1 = escapeString(String::convertSpaces(%name));
	%inf2 = escapeString(String::convertSpaces(%pass));
	%info = Aeon::hashString(%inf1)@"@"@Aeon::hashString(%inf2);
	return %info;
}

function Aeon::getName(%id)
{
	Aeon::clientInfo(%id);
	%name = $Aeon::ClientInfo[%id,name];
	return escapeString(%name);
}

function Aeon::hashString(%info,%undo)
{
	if(!%undo) {
		%info = AeonStr::replace(%info,"\?","A1");
		%info = AeonStr::replace(%info,"\\","A2");
		%info = AeonStr::replace(%info,"\/","A3");
		%info = AeonStr::replace(%info,"\!","A4");
		%info = AeonStr::replace(%info,"\@","A5");
		%info = AeonStr::replace(%info,"\#","A6");
		%info = AeonStr::replace(%info,"\$","A7");
		%info = AeonStr::replace(%info,"\%","A8");
		%info = AeonStr::replace(%info,"\^","A9");
		%info = AeonStr::replace(%info,"\&","A0");
		%info = AeonStr::replace(%info,"\*","B1");
		%info = AeonStr::replace(%info,"\(","B2");
		%info = AeonStr::replace(%info,"\)","B3");
		%info = AeonStr::replace(%info,"\+","B4");
		%info = AeonStr::replace(%info,"\=","B5");
		%info = AeonStr::replace(%info,"\:","B6");
		%info = AeonStr::replace(%info,"\;","B7");
		%info = AeonStr::replace(%info,"\<","B8");
		%info = AeonStr::replace(%info,"\>","B9");
		%info = AeonStr::replace(%info,"\,","B0");
		%info = AeonStr::replace(%info,"\|","C1");
		%info = AeonStr::replace(%info,"\`","C2");
		%info = AeonStr::replace(%info,"\~","C3");
		%info = AeonStr::replace(%info,"[", "C4");
		%info = AeonStr::replace(%info,"]", "C5");
		%info = AeonStr::replace(%info,"'", "C6");
		%info = AeonStr::replace(%info,"\"","C7"); // PORT: a quote survived into the id (file name, export pattern, quoted schedule strings)
		return %info;
	}
	else {
		%info = AeonStr::replace(%info,"A1","\?");
		%info = AeonStr::replace(%info,"A2","\\");
		%info = AeonStr::replace(%info,"A3","\/");
		%info = AeonStr::replace(%info,"A4","\!");
		%info = AeonStr::replace(%info,"A5","\@");
		%info = AeonStr::replace(%info,"A6","\#");
		%info = AeonStr::replace(%info,"A7","\$");
		%info = AeonStr::replace(%info,"A8","\%");
		%info = AeonStr::replace(%info,"A9","\^");
		%info = AeonStr::replace(%info,"A0","\&");
		%info = AeonStr::replace(%info,"B1","\*");
		%info = AeonStr::replace(%info,"B2","\(");
		%info = AeonStr::replace(%info,"B3","\)");
		%info = AeonStr::replace(%info,"B4","\+");
		%info = AeonStr::replace(%info,"B5","\=");
		%info = AeonStr::replace(%info,"B6","\:");
		%info = AeonStr::replace(%info,"B7","\;");
		%info = AeonStr::replace(%info,"B8","\<");
		%info = AeonStr::replace(%info,"B9","\>");
		%info = AeonStr::replace(%info,"B0","\,");
		%info = AeonStr::replace(%info,"C1","\|");
		%info = AeonStr::replace(%info,"C2","\`");
		%info = AeonStr::replace(%info,"C3","\~");
		%info = AeonStr::replace(%info,"C4","[");
		%info = AeonStr::replace(%info,"C5","]");
		%info = AeonStr::replace(%info,"C6","'");
		%info = AeonStr::replace(%info,"C7","\""); // PORT: undo of the line added above
		return %info;	
	}
}

function Game::playerSpawned(%pl,%clientId,%armor,%respawn)
{						  
	%id = Aeon::getAeonID(%clientId);
	%clientId.spawn = 1;
	Client::setSkin(%clientId,$Client::info[%clientId,0]);
	Activators::setCount(%clientId);
	%name = Client::getName(%clientId);
	$DeployPack[%clientId] = "";
	%clientId.teleMenu = "";
	for(%i = 1; $Aeon::ClientInfo[%id,Inv,%i] != ""; %i++) {
		%savIn = $Aeon::ClientInfo[%id,Inv,%i];
		%item  = getWord(%savIn,0);
		%count = getWord(%savIn,1);
		%style = $Aeon::invStyle[%item];
		if(%count > 0 && %style == "held")
			Player::setItemCount(%pl,%item,%count);
		else if(%style == "ownd") {
			if(%respawn != true) {
				if($Aeon::invOwnFunc[%item] == true)
					InvOwned::Make(%clientId,%savIn);
			}
		}
	}
	//%group = nameToID("MissionCleanup\\ClientTest");
	//if(%group == -1) {
	//	%group = newObject("ClientTest",SimGroup,"Group");
	//	addToSet("MissionCleanup",%group);
	//}
	//addToSet("MissionCleanup\\ClientTest",%clientId);
	Skill::setAttr(%clientId);
	Player::mountItem(%pl,"Unarmed",$WeaponSlot);
} 

function Aeon::onKilled(%clientId)
{
	%clientId.isFlashing = "";
	%clientId.hasGrab = "";
	%clientId.isDancing = "";
}

function Aeon::isHere(%id)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(Aeon::getAeonID(%cl) == %id)
			return %cl;
	}
	return false;
}

function Aeon::getExportFile(%cl,%old)
{
	if(%cl) {
		if(%old == true)
			%id = AeonStr::replace(Aeon::getAeonIDold(%cl),":","_");
		else
			%id = Aeon::getAeonID(%cl);
		%file = "AeonClient["@%id@"]";
	}
	else
		%file = false;
	return %file;
}

function Aeon::joinMessage(%clientId)
{
	%id = Aeon::getAeonID(%clientId);
	%jCnt = $Aeon::ClientInfo[%id,jCnt];
	if(%jCnt < 5) {
		if(%jCnt <= 1)
			$Aeon::ClientInfo[%id,mute] = true;
		%str = escapeString("<f1><jc>Welcome to the Aeon Monopolization RPG Mod! \n<f0>Press <f2>'O'<f0> and read before asking any questions! \nThis message will only show when you connect <f2>"@5 - %jCnt@"<f0> more times.");
		for(%i = 0; %i < 10; %i++)
			schedule("centerPrint("@%clientId@",\""@%str@"\",1);",%i,%clientId);
	}
	else
		bottomprint(%clientId,"<f0><jc>Welcome back <f2>"@$Aeon::ClientInfo[%id,name]@"<f0>!",5);
	%clientId.lastActTime = getSimTime();
	$Aeon::ClientInfo[%clientId,lastExport] = "";
	$Aeon::ClientInfo[%clientId,exportCnt] = "";
}

function SayFunc::getPW(%clientId,%msg,%new)
{
	%id = Aeon::getAeonID(%clientId);
	if(%new == "new") {
		if(String::empty(AeonStr::trim(%msg)) != true) {
			%clientId.pw1 = %msg;
			bottomPrint2(%clientId,"<jc><f2>Please enter your desired password again.",10,"mine_act.wav");
			schedule(%clientId@".nextMsg = \"getPW check\";",0.1,%clientId);
		}
		else {
			bottomPrint2(%clientId,"<jc><f2>You must enter a valid password.",5,"C_BuySell.wav");
			schedule(%clientId@".nextMsg = \"getPW new\";",0.1,%clientId);
		}
	}
	else if(%new == "check") {
		if(String::compare(%msg,%clientId.pw1) == 0) {
			$Aeon::ClientInfo[%id,pass] = %msg;
			bottomPrint2(%clientId,"<jc><f2>Your new profile password is <f3>"@%msg@"<f2>, don't forget it.",10,"mine_act.wav");
			%clientId.inputPW = true;
		}
		else {
			bottomPrint2(%clientId,"<jc><f2>Your password does not match your previous entry.",5,"C_BuySell.wav");
			schedule(%clientId@".nextMsg = \"getPW new\";",0.1,%clientId);
		}
	}
	else {
		if(String::compare(%msg,$Aeon::ClientInfo[%id,pass]) == 0 || String::compare(%msg,$Aeon::ClientInfo[%id,pass]@"~w") == 0) {
			%clientId.inputPW = true;
			bottomPrint2(%clientId,"<jc><f2>Access Granted, Fire to Spawn.",3,"mine_act.wav");
		}
		else {
			bottomPrint2(%clientId,"<jc><f2>Invalid password.",5,"C_BuySell.wav");
			schedule(%clientId@".nextMsg = \"getPW\";",0.1,%clientId);
		}
	}
}

function Aeon::getUserPW(%clientId)
{
	if(%clientId.inputPW == true)
		return true;
	return false;
}

function Aeon::joinKickCheck(%clientId)
{
	if(%clientId.observerMode == "justJoined" || Aeon::getUserPW(%clientId) != true) {
		if(!%clientId.isSuperAdmin)
			Net::kick(%clientId,"Your 30 seconds to input your password ran out.");
	}
}