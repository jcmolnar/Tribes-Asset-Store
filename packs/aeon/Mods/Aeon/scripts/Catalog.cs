$CatalogInv[CnTool] = 1;
$CatalogInv[DeployPack] = 0;
$CatalogInv[ScoutVehicle] = 1;
$CatalogInv[RazorVehicle] = 0;

$CatalogName[CnTool] = "Construction Tool";
$CatalogName[DeployPack] = "Deployable Packages";
$CatalogName[ScoutVehicle] = "Scout";
$CatalogName[RazorVehicle] = "Hover Bike";

$CatalogPrice[CnTool] = 100;
$CatalogPrice[DeployPack] = "Menu";
$CatalogPrice[ScoutVehicle] = "3000";
$CatalogPrice[RazorVehicle] = "5000";

function processMenuCatOpts(%clientId,%opt)
{
	%id = Aeon::getAeonID(%clientId);
	%name = Client::getName(%clientId);
	%cash = $Aeon::ClientInfo[%id,cash];
	%opt1 = getWord(%opt,0);
	if(%opt1 == "PO") {
		%opt2 = getWord(%opt,1);
		%max = getNumItems();
		%catNum = 0;
		%start = 0;
		%lastBuy = $Aeon::ClientInfo[%id,lBuy];
		if(%opt2 == "next")
			%start = getWord(%opt,2);
		Client::buildMenu(%clientId, "Cash: $"@String::cashComma(%cash),"catOpts",true);
		if(%start == 0) {
			Client::addMenuItem(%clientId,%catNum++@$CatalogName[DeployPack]@" "@$CatalogPrice[DeployPack],"Buy DeployPack");
			if(%lastBuy != "") {
				%lastDsc = $CatalogName[%lastBuy];
				%lastPrc = $CatalogPrice[%lastBuy];
				if(getWord(%lastBuy,0) == "DeployPack") {
					%lastTyp = getWord(%lastBuy,1);
					%lastDsc = $DeployItem[%lastTyp,desc];
					%lastPrc = $DeployItem[%lastTyp,prce];
					%lastBuy = "deployType "@%lastTyp;
				}
				Client::addMenuItem(%clientId,%catNum++@"Last: "@%lastDsc@" $"@String::cashComma(%lastPrc),"Buy "@%lastAdd@%lastBuy);
			}
		}
		for(%i = %start; %i < %max; %i++) {
			%item = getItemData(%i);
			%price = "$"@String::cashComma($CatalogPrice[%item]);
			if($CatalogInv[%item] > 0) {
				if(%catNum > 4) {
					Client::addMenuItem(%clientId,%catNum++@"Next Page...","PO next "@%i);
					break;
				}
				Client::addMenuItem(%clientId,%catNum++@$CatalogName[%item]@" "@%price,"Buy "@%item);
			}
			if(%i == %max)
				Client::addMenuItem(%clientId,%catNum++@"Done...","catDone");
		}
		return;
	}
	else if(%opt1 == "RE") {
		%bos = getWord(%opt,1);
		if(%bos == "buy") {
			%cash = $Aeon::ClientInfo[%id,cash];
			if(%cash >= $Property::minCstReq) {
				%catNum = 0;
				%price = Property::getValue($tempDims[%clientId],$tempPrpr[%clientId],$tempLctn[%clientId],com);
				Client::buildMenu(%clientId,"Real Estate: "@%price,"catOpts",true);
				Client::addMenuItem(%clientId,%catNum++@"Set Location","RE buyOpts pos");
				Client::addMenuItem(%clientId,%catNum++@"Set Dimensions","RE buyOpts dim");
				Client::addMenuItem(%clientId,%catNum++@"Proprietary Rights","RE buyOpts prR");
				Client::addMenuItem(%clientId,%catNum++@"Buy","RE buyOpts buy");
				Client::addMenuItem(%clientId,%catNum++@"Cancel...","catDone");
				return;
			}
			else
				bottomPrint2(%clientId,"<jc><f3>You don't even have $"@$Property::minCstReq@".",3,"C_BuySell.wav");
		}
		else if(%bos == "buyOpts") {
			%prt = getWord(%opt,2);
			if(%prt == "pos") {
				%type = getWord(%opt,3);
				%wp = wayPointToWorld($Aeon::ClientInfo[%id,WayP]);
				%wp = getWord(%wp,0)@" "@getWord(%wp,1)@" "@Property::terrainHeight(%wp);
				if(%type != -1 && %type != "") {
					%dims = $tempDims[%clientId];
					if(%dims != "" && %dims != -1) {
						if(%type == "centCL")
							%pos = GameBase::getPosition(%clientId);
						else if(%type == "centCW")
							%pos = %wp;
						if((%loc = Property::checkLocation(%clientId,%pos,%dims,%wp)) != false) {
							if(getWord(%loc,0) == "exp") {
								processMenuCatOpts(%clientId,"RE edit "@getWord(%loc,1));
								return;
							}
							$tempLctn[%clientId] = %loc;
							processMenuCatOpts(%clientId,"RE buy");
							return;
						}
					}
					else
						bottomPrint2(%clientId,"<jc><f3>You must set the dimensions first.",1,"C_BuySell.wav");
				}
				%catNum = 0;
				Client::buildMenu(%clientId,"Location:","catOpts",true);
				Client::addMenuItem(%clientId,%catNum++@"Center at current location","RE buyOpts pos centCL");
				Client::addMenuItem(%clientId,%catNum++@"Center at current waypoint","RE buyOpts pos centCW");
				Client::addMenuItem(%clientId,%catNum++@"Back...","RE buy");
				return;
			}
			else if(%prt == "dim") {
				if(getWord(%opt,3) != 1 && $tempDims[%clientId] == "") {
					$tempX[%clientId] = $Property::limits[Width,min];
					$tempY[%clientId] = $Property::limits[Length,min];
					$tempZ[%clientId] = $Property::limits[Height,min];
				}
				$tempDims[%clientId] = $tempX[%clientId]@" x "@$tempY[%clientId]@" x "@$tempZ[%clientId];
				Client::buildMenu(%clientId, "Dimensions: "@$tempDims[%clientId],"catOpts",true);
				Client::addMenuItem(%clientId,%catNum++@"Set Width","RE buyOpts setDim x");
				Client::addMenuItem(%clientId,%catNum++@"Set Length","RE buyOpts setDim y");
				Client::addMenuItem(%clientId,%catNum++@"Set Height","RE buyOpts setDim z");
				if(getWord(%opt,5) != -1)
					Client::addMenuItem(%clientId,%catNum++@"Back...","RE edit "@getWord(%opt,6));
				else
					Client::addMenuItem(%clientId,%catNum++@"Back...","RE buy dims");
				return;
			}
			else if(%prt == "setDim") {
				%xyz = getWord(%opt,3);
				%amt = getWord(%opt,4);
				%edit = getWord(%opt,5);
				if(%edit != -1) {
					%prop = getWord(%opt,6);
					%edit = " edit "@%prop;
				}
				else
					%edit = "";
				%check = getWord(%opt,7);
				if(%xyz == "x") {
					%num = 0;
					%whch = "Width";
				}
				else if(%xyz == "y") {
					%num = 2;
					%whch = "Length";
				}
				else if(%xyz == "z") {
					%num = 4;
					%whch = "Height";
				}
				if(%amt == -1) {
					if($tempDims[%clientId] == "")
						$tempProp[%clientId] = $Property::limits[%whch,min];
					else
						$tempProp[%clientId] = getWord($tempDims[%clientId],%num);
				}
				else {
					if(%amt == "neg1")
						%amt = -1;
					else if(%amt == "neg10")
						%amt = -10;
					$tempProp[%clientId]+=%amt;
					if(%xyz == "x")
						$tempX[%clientId] = $tempProp[%clientId];
					else if(%xyz == "y")
						$tempY[%clientId] = $tempProp[%clientId];
					else if(%xyz == "z")
						$tempZ[%clientId] = $tempProp[%clientId];
					$tempDims[%clientId] = $tempX[%clientId]@" x "@$tempY[%clientId]@" x "@$tempZ[%clientId];
				}
				if(%edit != "") {
					if(%amt > 0 && %check == -1) {
						echo("expand broke?");
					}
					if(%check != true && %check != false && %check != -1) {
						%newLoc = Property::floatOrigin($tempLctn[%clientId],%check,%amt);
						if($tempLctn[%clientId,ExpLastDir] == "") {
							$tempLctn[%clientId,ExpLast] = $tempLctn[%clientId];
							$tempLctn[%clientId,ExpLastDir] = %check;
						}
						$tempLctn[%clientId] = %newLoc;
					}
					else if($tempLctn[%clientId,ExpLastDir] != "") {
						%dist = Vector::getDistance($tempLctn[%clientId,ExpLast],$tempLctn[%clientId]);
						%check = $tempLctn[%clientId,ExpLastDir];
						if(%dist < 0.2) {
							$tempLctn[%clientId] = $tempLctn[%clientId,ExpLast];
							$tempLctn[%clientId,ExpLast] = "";
							%dist2 = Vector::getDistance($prevLctn[%clientId],$tempLctn[%clientId]);
							if(%dist2 < 0.2) {
								$tempLctn[%clientId] = $prevLctn[%clientId];
								$tempLctn[%clientId,ExpLastDir] = "";
							}
							else {
								%newLoc = Property::floatOrigin($tempLctn[%clientId],%check,%amt);
								$tempLctn[%clientId] = %newLoc;
							}
						}
						else {
							%newLoc = Property::floatOrigin($tempLctn[%clientId],%check,%amt);
							$tempLctn[%clientId] = %newLoc;
						}
					}
					
					%dimDiff = Property::subDims($tempDims[%clientId],$prevDims[%clientId]);
					//Property::setOpts(%prop,$tempDims[%clientId],$tempLctn[%clientId],$prevPrpr[%clientId]);
					//Property::updateDims(%prop,$tempDims[%clientId],$tempPropOrgn[%clientId]);
					//Property::setOpts(%prop,$prevDims[%clientId],$prevLctn[%clientId],$prevPrpr[%clientId]);
					//schedule("Property::updateDims("@%prop@");",2.0);

					%check[10] = Property::canExpand(%prop,Property::addDims(%dimDiff,Property::dir2Dims(%whch,10)),%whch);
					%check[1] = Property::canExpand(%prop,Property::addDims(%dimDiff,Property::dir2Dims(%whch,1)),%whch);
				}
				Client::buildMenu(%clientId, "Dimension "@%whch@": "@$tempProp[%clientId],"catOpts",true);
				if(Property::dimsMax($tempProp[%clientId],%whch,-50) && %edit == "")
					Client::addMenuItem(%clientId,%catNum++@"+50","RE buyOpts setDim "@%xyz@" 50");
				if(Property::dimsMax($tempProp[%clientId],%whch,-10) && (%edit == "" || %check1 != false))
					Client::addMenuItem(%clientId,%catNum++@"+10","RE buyOpts setDim "@%xyz@" 10"@%edit@" "@%check[10]);
				if(Property::dimsMax($tempProp[%clientId],%whch,-1) && (%edit == "" || %check2 != false))
					Client::addMenuItem(%clientId,%catNum++@"+1","RE buyOpts setDim "@%xyz@" 1"@%edit@" "@%check[1]);
				if(Property::dimsMax($tempProp[%clientId],%whch,1) && (%edit == "" || Property::dimsPositive(%dimDiff,%whch,1)))
					Client::addMenuItem(%clientId,%catNum++@"-1","RE buyOpts setDim "@%xyz@" neg1"@%edit);
				if(Property::dimsMax($tempProp[%clientId],%whch,10) && (%edit == "" || Property::dimsPositive(%dimDiff,%whch,10)))
					Client::addMenuItem(%clientId,%catNum++@"-10","RE buyOpts setDim "@%xyz@" neg10"@%edit);
				if(%edit != "")
					Client::addMenuItem(%clientId,%catNum++@"Back...","RE edit "@%prop);
				else
					Client::addMenuItem(%clientId,%catNum++@"Back...","RE buyOpts dim");
				return;				
			}
			else if(%prt == "prR") {
				%type = getWord(%opt,3);
				if(%type != -1 && %type != "") {
					$tempPrpr[%clientId] = %type;
					processMenuCatOpts(%clientId,"RE buy");
					return;
				}
				%catNum = 0;
				Client::buildMenu(%clientId,"Proprietary Rights:","catOpts",true);
				Client::addMenuItem(%clientId,%catNum++@"Public Domain - $"@$Property::extras["PD"],"RE buyOpts prR PD");
				Client::addMenuItem(%clientId,%catNum++@"Basic Rights - $"@$Property::extras["BR"],"RE buyOpts prR BR");
				Client::addMenuItem(%clientId,%catNum++@"Private Property - $"@$Property::extras["PP"],"RE buyOpts prR PP");
				Client::addMenuItem(%clientId,%catNum++@"Back...","RE buy");
				return;
			}
			else if(%prt == "buy") {
				if($tempDims[%clientId] != "" && $tempLctn[%clientId] != "" && $tempPrpr[%clientId] != "") {
					%value = Property::getValue($tempDims[%clientId],$tempPrpr[%clientId],$tempLctn[%clientId],true);
					if(%cash >= %value) {
						%info = $tempLctn[%clientId]@" | "@$tempDims[%clientId]@" | "@$tempPrpr[%clientId];
						Property::buy(%clientId,%info);
						return;
					}
					else
						bottomPrint2(%clientId,"<jc><f3>You don't have enough money.",1,"C_BuySell.wav");
				}
				else {
					bottomPrint2(%clientId,"<jc><f3>Settings incomplete, you must set all data.",1,"C_BuySell.wav");
					processMenuCatOpts(%clientId,"RE buy");
					return;
				}
			}
		}
		else if(%bos == "sell") {
			
		}
		else if(%bos == "edit") {
			%prop = getWord(%opt,2);
			if(!(Property::getOwner(%prop) == %id)) return; // PORT (2026-10-12): the menu offers this for the caller's own land only
			if(getWord(%opt,3) == "init") {
				$tempX[%clientId] = $Aeon::property[%prop,Width];
				$tempY[%clientId] = $Aeon::property[%prop,Lngth];
				$tempZ[%clientId] = $Aeon::property[%prop,HghtZ];
				$tempLctn[%clientId,ExpLastDir] = "";
				$tempLctn[%clientId] = $Aeon::property[%prop,locat];
				$prevDims[%clientId] = $tempX[%clientId]@" x "@$tempY[%clientId]@" x "@$tempZ[%clientId];
				$prevLctn[%clientId] = $Aeon::property[%prop,locat];
				$prevPrpr[%clientId] = $Aeon::property[%prop,prprt];
			}
			else if(getWord(%opt,3) == "buy") {
				%areaDif = Property::subArea($tempDims[%clientId],$prevDims[%clientId],true);
				%price = Property::getValue(%areaDif,"PD",$tempLctn[%clientId],true);
				if(%cash >= %price) {
					%decide = getWord(%opt,4);
					if(%decide == "yes") {
						Property::setOpts(%prop,$tempDims[%clientId],$tempLctn[%clientId],$prevPrpr[%clientId]);
						Property::updateDims(%prop,$tempDims[%clientId],$tempPropOrgn[%clientId]);
						$Aeon::ClientInfo[%id,cash] -= %price;
						%group = nameToID("MissionCleanup\\Property\\Property #"@%prop);
						Aeon::ExportInfo(%clientId);
						Aeon::ExportProperty(%group);
						bottomPrint2(%clientId,"<jc><f3>You expanded your land to <f1>"@$tempDims[%clientId]@"<f3>!",3,"BuySellSound.wav");
						return;
					}
					%catNum = 0;
					%price = Property::getValue(%areaDif,"PD",$tempLctn[%clientId],com);
					Client::buildMenu(%clientId, "Really Expand?: $"@%price,"catOpts",true);
					Client::addMenuItem(%clientId,%catNum++@"Yes","RE edit "@%prop@" buy yes");
					Client::addMenuItem(%clientId,%catNum++@"No","RE edit "@%prop);
					return;
				}
				else {
					bottomPrint2(%clientId,"<jc><f3>You don't have $"@%price@".",3,"C_BuySell.wav");
				}
			}
			%catNum = 0;
			$tempDims[%clientId] = $tempX[%clientId]@" x "@$tempY[%clientId]@" x "@$tempZ[%clientId];
			%areaDif = Property::subArea($tempDims[%clientId],$prevDims[%clientId],true);
			%price = Property::getValue(%areaDif,"PD",$tempLctn[%clientId],com);
			Client::buildMenu(%clientId, "Dims: "@$tempDims[%clientId]@" : $"@%price,"catOpts",true);
			Client::addMenuItem(%clientId,%catNum++@"Set Width","RE buyOpts setDim x -1 edit "@%prop);
			Client::addMenuItem(%clientId,%catNum++@"Set Length","RE buyOpts setDim y -1 edit "@%prop);
			Client::addMenuItem(%clientId,%catNum++@"Set Height","RE buyOpts setDim z -1 edit "@%prop);
			Client::addMenuItem(%clientId,%catNum++@"Buy","RE edit "@%prop@" buy");
			Client::addMenuItem(%clientId,%catNum++@"Cancel...","catDone");
			return;
		}
		$tempX[%clientId] = $Property::limits[Width,min];
		$tempY[%clientId] = $Property::limits[Length,min];
		$tempZ[%clientId] = $Property::limits[Height,min];
		$tempDims[%clientId] = $tempX[%clientId]@" x "@$tempY[%clientId]@" x "@$tempZ[%clientId];
		$tempLctn[%clientId] = "";
		$tempPrpr[%clientId] = "PD";
		%catNum = 0;
		Client::buildMenu(%clientId,"Real Estate:","catOpts",true);
		Client::addMenuItem(%clientId,%catNum++@"Purchase Land","RE buy");
		if($Aeon::ClientInfo[%id,ownP] != "")
			Client::addMenuItem(%clientId,%catNum++@"Sell Land","RE sell");
		if((%prop = Aeon::inProperty(GameBase::getPosition(%clientId)))) {
			if(Property::getOwner(%prop) == %id) {
				Client::addMenuItem(%clientId,%catNum++@"Expand/Change Land","RE edit "@%prop@" init");
			}
			else if(%prop > 0 && (%owner = Aeon::isHere(Property::getOwner(%prop)))) {
				//echo(%owner);
				Client::addMenuItem(%clientId,%catNum++@"Request "@Client::getName(%owner)@"'s permission","");
			}
		}
		Client::addMenuItem(%clientId,%catNum++@"Done...","catDone");
		return;
	}
	else if(%opt1 == "RC") {
		Client::buildMenu(%clientId, "Classifieds:","catOpts",true);
		%catNum = 0;
		%start = 1;
		if(getWord(%opt,1) == "next")
			%start = getWord(%opt,2);
		for(%i = %start; $Aeon::classified[%i,title] != ""; %i++) {
			%ad = $Aeon::classified[%i,cntxt];
			%title = $Aeon::classified[%i,title];
			if(%catNum > 5) {
				Client::addMenuItem(%clientId,%catNum++@"Next Page...","RC next "@%i);
				break;
			}
			if(%ad != "")
				Client::addMenuItem(%clientId,%catNum++@%title,"Read "@%i);
		}
		Client::addMenuItem(%clientId,%catNum++@"Back...","catDone");
		return;
	}
	else if(%opt1 == "Read") {
		//%ad = String::getSubStr(%opt,5,AeonStr::Len(%opt)-4);
		//Aeon::readAd(%clientId,%ad);
		Aeon::readAd(%clientId,getWord(%opt,1));
		return;
	}
	else if(%opt1 == "PC") {
		%input = getWord(%opt,1);
		if($Aeon::ClientInfo[%id,aNum] >= $Aeon::maxPost) {
			bottomPrint2(%clientId,"<jc><f3>You have reached the maximum post.",1,"C_BuySell.wav");
			return;
		}
		if(%input == -1 || %input == "again")
			%clientId.tempTitle = "";
		else if(%input == "cancel") {
			%clientId.tempTitle = "";
			processMenuOptions(%clientId,"catalog");
			return;
		}
		else if(%input == "done" || %input == "untitled") {
			if(Classifieds::checkTitle(%clientId.tempTitle) != true) {
				%clientId.tempTitle = "";
				processMenuCatOpts(%clientId,"PC again");
				return;
			}
			if(AeonStr::Len(%clientId.tempTitle) < 1 || %input == "untitled") {
				%clientId.tempTitle = "";
				%count = Classifieds::getPostCount(%id)+1;
				%title = %name@"'s Ad #"@%count;
				%num = Classifieds::addToStack(%title);
				bottomPrint(%clientId,"<jc><f2>Please type your post in the global chat now.",2);
				%clientId.nextMsg = "writePost "@%num;
				return;
			}
			Classifieds::addToStack(%clientId.tempTitle);
			%num = Classifieds::getNum(%clientId.tempTitle);
			%clientId.tempTitle = "";
			bottomPrint(%clientId,"<jc><f2>Please type your post in the global chat now.",2);
			%clientId.nextMsg = "writePost "@%num;
			return;
		}
		else {
			%length = AeonStr::Len(%clientId.tempTitle);
			if(%input == "del") {
				if(%length > 0)
					%clientId.tempTitle = String::getSubStr(%clientId.tempTitle,0,%length-1);
			}
			else if(%length < 20) {
				if(%input == "space") {
					if(String::getSubStr(%clientId.tempTitle,%length-2,1) == " " && String::getSubStr(%clientId.tempTitle,%length-1,1) == "i")
						%clientId.tempTitle = String::getSubStr(%clientId.tempTitle,0,%length-1)@"I";
					%input = " ";
				}
				if(%length == 0)
					%input = AeonStr::char(String::ascii(%input)-32);
				
				%clientId.tempTitle = %clientId.tempTitle@%input;
			}
			else
				bottomPrint2(%clientId,"<jc><f3>Your post's title can not be longer than 20 charectors",1,"C_BuySell.wav");
		}
		if(%input == "again")
			bottomPrint2(%clientId,"<jc><f3>Your post's title is already taken, try another.",2,"C_BuySell.wav");
		else
			bottomPrint(%clientId,"<jc><f2>Please type in your post's title, numbers and letters only.",2);
		Client::buildMenu(%clientId,"Enter Title: "@%clientId.tempTitle,"catOpts",true);
		Client::addMenuItem(%clientId,"/" @">    Leave Untitled    <","PC untitled");
		Client::addMenuItem(%clientId,"\\"@">        Cancel        <","PC cancel");
		Client::addMenuItem(%clientId,"." @">         Done         <","PC done");
		Client::addMenuItem(%clientId," " @"   ----------Space----------","PC space");
		Client::addMenuItem(%clientId,"-" @"    << BackSpace <<","PC del");
		for(%i = 48; %i <= 57; %i++) {
			%char = AeonStr::char(%i);
			Client::addMenuItem(%clientId,%char@%char,"PC "@%char);
		}
		for(%i = 97; %i <= 122; %i++) {
			%char = AeonStr::char(%i);
			Client::addMenuItem(%clientId,%char@%char,"PC "@%char);
		}
		return;
	}
	else if(%opt1 == "DC") {
		%sel = getWord(%opt,1);
		if(%sel == "del") {
			%num = getWord(%opt,2);
			if(!($Aeon::classified[%num,authr] == %id)) return; // PORT (2026-10-12): the list shows the caller's own posts only
			Classifieds::removeFromStack($Aeon::classified[%num,title]);
			bottomPrint(%clientId,"<jc><f2>Your post has been deleted.",2);
			return;
		}
		Client::buildMenu(%clientId,"Select the post to delete:","catOpts",true);
		exec("AeonClassifieds.cs");
		%count = 0;
		for(%i = 1; $Aeon::classified[%i,title] != ""; %i++) {
			%title = $Aeon::classified[%i,title];
			%cntxt = $Aeon::classified[%i,cntxt];
			if($Aeon::classified[%i,authr] == %id) {
				Client::addMenuItem(%clientId,%count++@%title,"DC del "@%i);
			}
		}
		return;
	}
	else if(%opt1 == "Buy") {
		%item = getWord(%opt,1);
		%title = $CatalogName[%item];
		%price = $CatalogPrice[%item];
		if(%item == "DeployPack") {
			%opt2 = getWord(%opt,2);
			%curItem = 0;
			Client::buildMenu(%clientId,"Purchase Deployable Packs:","catOpts",true);
			%catNum = 0;
			%start = 1;
			if(%opt2 == "next")
				%start = getWord(%opt,3);
			for(%i = %start; (%type = $DeployType[%i]) != ""; %i++) {
				if(%catNum > 4) {
					Client::addMenuItem(%clientId,%catNum++@"Next Page...","Buy DeployPack next "@%i);
					break;
				}
				Client::addMenuItem(%clientId,%catNum++@$DeployItem[%type,desc]@" $"@String::cashComma($DeployItem[%type,prce]),"Buy deployType "@%type);
			}
			return;
		}
		else if(%item == "deployType") {
			%type = getWord(%opt,2);
			%title = $DeployItem[%type,desc];
			%price = $DeployItem[%type,prce];
			%item = "DeployPack "@%type;
		}
		if(%price > %cash) {
			bottomPrint2(%clientId,"<jc><f3>You cannot afford this.",1,"Error_Message.wav");
			processMenuCatOpts(%clientId,"PO");
			return;
		}
		else {
			Client::buildMenu(%clientId,"Buy "@%title@" @ $"@String::cashComma(%price)@"?","BuyAffirm",true);
			Client::addMenuItem(%clientId,"1Buy "@%title,"yes "@%item);
			Client::addMenuItem(%clientId,"2Don't Buy "@%title,"no "@%item);
			return;
		}
	}
	else if(%opt1 == "Done") {
		%clientId.tempTitle = "";
		processMenuOptions(%clientId,"catalog");
		//Catalog::receipt(%clientId);
		return;
	}
	%clientId.tempTitle = "";
	processMenuOptions(%clientId,"catalog");
}

function processMenuBuyAffirm(%clientId,%opt)
{
	if(getWord(%opt,0) == "yes")
		Catalog::placeOrder(%clientId,getWord(%opt,1)@" "@getWord(%opt,2));
	processMenuOptions(%clientId,"catalog");
}

function Catalog::placeOrder(%clientId,%word)
{
	%id = Aeon::getAeonID(%clientId);
	%item = getWord(%word,0);
	%portPrice = $CatalogPrice[%item]; // PORT (2026-10-12): the confirmation reply names the item; price it again before making it
	if(%item == "DeployPack") %portPrice = $DeployItem[getWord(%word,1),prce];
	if(%portPrice <= 0 || %portPrice > $Aeon::ClientInfo[%id,cash]) return;
	if(%item.className == "Vehicle") {
		%obj = newObject("",flier,$DataBlockName[%item],true);
		%clientId.hasKey[%obj] = true;
	}
	else
		%obj = newObject("",item,%item,1,false);
	%price = $CatalogPrice[%item];
	if(getWord(%word,0) == "DeployPack") {
		%type = getWord(%word,1);
		$DeployTypeThis[%obj] = %type;
		%price = $DeployItem[%type,prce];
	}
	Gamebase::setMapName(%obj,%item.description);
	%obj.owner = %clientId;
	%obj.ownId = Aeon::getAeonID(%clientId);
	addToSet("MissionCleanup",%obj);
	GameBase::setPosition(%obj,Vector::add(GameBase::getPosition(%clientId), (getRandom()-0.5)*15@" "@(getRandom()-0.5)*15@" 50"));
	$Aeon::ClientInfo[%id,cash] -= %price;
	if($Aeon::invStyle[%item] == "ownd") {
		%num = InvOwned::getNext(%clientId,%item);
		%ttl = %item@" "@%num;
		$Aeon::ClientInfo[%id,ownd,%ttl] = %obj;
		%obj.owndNum = %num;
		GameBase::setMapName(%obj,Client::getName(%clientId)@"'s "@GameBase::getMapName(%obj));
	}
	$Aeon::ClientInfo[%id,lBuy] = %word;
	Aeon::ExportInfo(%clientId);
}

$CashName["B"] = " Billion";
$CashName["M"] = " Million";
$CashName["K"] = " Thousand";

function Aeon::cashStr(%num,%desc)
{
	if(%num <= 0)
		return "$0.00";
	%length = AeonStr::Len(%num);
	%div = 1;
	%stamp = "";
	%rDeep = 2;
	%dispRem = false;
	if(%length >= 10+%a) {
		%div = 1000000000;
		%stamp = "B";
		%rDeep = 1;
		%dispRem = true;
	}
	else if(%length >= 7+%a) {
		%div = 1000000;
		%stamp = "M";
		%dispRem = true;
	}
	else if(%length >= 4+%a) {
		%div = 1000;
		%stamp = "K";
		%rDeep = 1;
	}
	%str = floor(%num/%div);

	%rem = Calc::Mod(%num,%div,true);
	%rem = String::getSubStr(%rem,0,%rDeep);
	if(%desc == true)
		%stamp = $CashName[%stamp];
	if(%dispRem == true) {
		if(%rem > 0)
			%rest = "."@%rem@%stamp;
		else
			%rest = ""@%stamp;
	}
	else
		%rest = ""@%stamp;
	return "$"@%str@%rest;
}