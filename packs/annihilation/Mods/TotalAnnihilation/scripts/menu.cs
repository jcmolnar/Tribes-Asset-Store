function Client::cancelMenu(%clientId)
{
	if(!%clientId.menuLock)
	{
		%clientId.selClient = "";
		%clientId.menuMode = "";
		%clientId.menuLock = "";
		remoteEval(%clientId, "CancelMenu");
		Client::setMenuScoreVis(%clientId, false);
	}
}

// MODERN TRIBES (2026-09-22): a BACK item on every submenu. Player report: going into a
// submenu of the tab menu had no way back -- you had to close it and start over.
// Generic, so none of the ~60 submenu builders needed editing: every menu is recorded as it
// is built (title, mode, lock, selClient, items). A menu built while the player is PICKING
// from another one (remoteMenuSelect) is a submenu, so the menu it came from is pushed.
// A menu built any other way (tab key, clicking a player) is a new root and clears history.
// Rebuilding a menu already on the stack (same title + mode) pops back to it, so "return to
// the main menu after an action" and paging ("Next Page") never grow the history.
// Menus that already carry their own Back item (admin/ban list viewers) are left alone.
// Back is hotkey "b": every stock TA item is keyed by a digit. Code "mnuback".
function MenuHist::save(%cl, %lvl)
{
	$MnuHist::T[%cl, %lvl] = $MnuHist::curT[%cl];
	$MnuHist::M[%cl, %lvl] = $MnuHist::curM[%cl];
	$MnuHist::C[%cl, %lvl] = $MnuHist::curC[%cl];
	$MnuHist::S[%cl, %lvl] = $MnuHist::curS[%cl];
	%n = $MnuHist::curN[%cl];
	$MnuHist::N[%cl, %lvl] = %n;
	for(%i = 0; %i < %n; %i++)
	{
		$MnuHist::O[%cl, %lvl, %i] = $MnuHist::curO[%cl, %i];
		$MnuHist::K[%cl, %lvl, %i] = $MnuHist::curK[%cl, %i];
	}
}

function Client::buildMenu(%clientId, %menuTitle, %menuCode, %cancellable)
{
	%cl = %clientId;
	if(!$MnuHist::replay[%cl])
	{
		if(!$MnuHist::inSel[%cl])
			$MnuHist::depth[%cl] = 0;			// a new root menu
		else if(!($MnuHist::curT[%cl] == %menuTitle && $MnuHist::curM[%cl] == %menuCode))
		{
			for(%k = 0; %k < $MnuHist::depth[%cl]; %k++)
				if($MnuHist::T[%cl, %k] == %menuTitle && $MnuHist::M[%cl, %k] == %menuCode)
					break;
			if(%k < $MnuHist::depth[%cl])
				$MnuHist::depth[%cl] = %k;		// back on a menu we came through: pop to it
			else if($MnuHist::curN[%cl] > 0 && $MnuHist::depth[%cl] < 12)
			{
				MenuHist::save(%cl, $MnuHist::depth[%cl]);
				$MnuHist::depth[%cl]++;
			}
		}
	}
	$MnuHist::curT[%cl] = %menuTitle;
	$MnuHist::curM[%cl] = %menuCode;
	$MnuHist::curC[%cl] = %cancellable;
	$MnuHist::curS[%cl] = %clientId.selClient;
	$MnuHist::curN[%cl] = 0;
	$MnuHist::curHasBack[%cl] = false;
	$MnuHist::built[%cl] = true;

	Client::setMenuScoreVis(%clientId, true);
	%clientId.menuLock = !%cancellable;
	%clientId.menuMode = %menuCode;
	remoteEval(%clientId, "NewMenu", %menuTitle);
}

function Client::addMenuItem(%clientId, %option, %code)
{
	%cl = %clientId;
	%n = $MnuHist::curN[%cl];
	if(%n < 64)
	{
		$MnuHist::curO[%cl, %n] = %option;
		$MnuHist::curK[%cl, %n] = %code;
		$MnuHist::curN[%cl] = %n + 1;
	}
	if(String::getSubStr(%option, 1, 4) == "Back")
		$MnuHist::curHasBack[%cl] = true;
	remoteEval(%clientId, "AddMenuItem", %option, %code);
}

// Called once the submenu builder has finished adding its items, so Back lands at the bottom.
function MenuHist::addBack(%cl)
{
	if($MnuHist::depth[%cl] > 0 && !$MnuHist::curHasBack[%cl])
		remoteEval(%cl, "AddMenuItem", "bBack", "mnuback");
}

// Re-send the parent menu exactly as it was built (items, mode, lock, selected player).
function MenuHist::goBack(%cl)
{
	%lvl = $MnuHist::depth[%cl] - 1;
	if(%lvl < 0)
		return;
	$MnuHist::depth[%cl] = %lvl;
	%cl.selClient = $MnuHist::S[%cl, %lvl];
	$MnuHist::replay[%cl] = true;
	Client::buildMenu(%cl, $MnuHist::T[%cl, %lvl], $MnuHist::M[%cl, %lvl], $MnuHist::C[%cl, %lvl]);
	%n = $MnuHist::N[%cl, %lvl];
	for(%i = 0; %i < %n; %i++)
		Client::addMenuItem(%cl, $MnuHist::O[%cl, %lvl, %i], $MnuHist::K[%cl, %lvl, %i]);
	$MnuHist::replay[%cl] = false;
	MenuHist::addBack(%cl);
}

function remoteCancelMenu(%server)
{
	if(%server != 2048)
		return;
	if(isObject(CurServerMenu))
		deleteObject(CurServerMenu);
}

function remoteNewMenu(%server, %title)
{
	if(%server != 2048)
		return;

	if(isObject(CurServerMenu))
		deleteObject(CurServerMenu);

	newObject(CurServerMenu, ChatMenu, %title);
	setCMMode(PlayChatMenu, 0);
	setCMMode(CurServerMenu, 1);
}

function remoteAddMenuItem(%server, %title, %code)
{
	if(%server != 2048)
		return;
	addCMCommand(CurServerMenu, %title, clientMenuSelect, %code);
}

function clientMenuSelect(%code)
{
	deleteObject(CurServerMenu);
	remoteEval(2048, menuSelect, %code);
}

function remoteMenuSelect(%clientId, %code)
{
	if( CheckEval("remoteMenuSelect", %clientId, %code) )
		return;
		
	if ( $debug )
		Anni::Echo("remoteMenuSelect("@%clientId@", "@Ann::Clean::string(%code));	

	%mm = %clientId.menuMode;
	if(%mm == "")
		return;
	if( String::findSubStr(%code, "\"") != -1 
         || String::findSubStr(%code, "\\") != -1 
         || String::findSubStr(%code, ";") != -1 
         || String::findSubStr(%code, "$") != -1 
         || String::findSubStr(%code, "(") != -1 
         || String::findSubStr(%code, ")") != -1 ) 
		return;

	if(%code == "mnuback")
	{
		%clientId.menuMode = "";
		%clientId.menuLock = "";
		MenuHist::goBack(%clientId);
		if(%clientId.menuMode == "")
			Client::setMenuScoreVis(%clientId, false);
		return;
	}

	%evalString = "processMenu" @ %mm @ "(" @ %clientId @ ", \"" @ %code @ "\");";
	%clientId.menuMode = "";
	%clientId.menuLock = "";
	$MnuHist::inSel[%clientId] = true;
	$MnuHist::built[%clientId] = false;
	eval(%evalString);
	$MnuHist::inSel[%clientId] = false;
	if($MnuHist::built[%clientId] && %clientId.menuMode != "")
		MenuHist::addBack(%clientId);
	if(%clientId.menuMode == "")
	{
		Client::setMenuScoreVis(%clientId, false);
		%clientId.selClient = "";
	}
}
