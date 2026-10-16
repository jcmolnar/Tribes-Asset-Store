$MENU::MaxOptions = 8;

function Client::ClearMenuData(%clientId) {
   if(!%clientId.MenuCount) %clientId.MenuCount = 0;
   for(%i = 0; %i < %clientId.MenuCount; %i++) {
      if(%clientId.MenuOption[%i] != "") %clientId.MenuOption[%i] = "";
      if(%clientId.MenuCode[%i] != "") %clientId.MenuCode[%i] = "";
   }
   %clientId.MenuSpecial = "";
   %clientId.MenuCount = 0;
   %clientId.MenuTitle = "";
   %clientId.MenuCode = "";
   %clientId.MenuCancellable = "";
   %clientId.AutoCurItem = "";
}

//To create a "fixed" menu, you must call on this before calling Client::buildMenu (only call this once)
function Client::prepLimitedMenu(%clientId)
{
   Client::ClearMenuData(%clientId);
   %clientId.MenuSpecial = true;
}

//If creating a "fixed" menu, you MUST call on this after you are done calling on Client::addMenuItem (only call this once)
function Client::displayMenuOpts(%clientId) {
   if(%clientId.MenuSpecial == true) {
      Client::displayMenuFrom(%clientId,0);
   }
}

function Client::displayMenuFrom(%clientId,%Start) {
   if(%clientId.MenuSpecial == true) {
      %MenuCount = %clientId.MenuCount - %Start;
      %MaxOptions = $MENU::MaxOptions;

      if(%Start != 0) {
        if(%Start == (%MaxOptions - 1))
          %BackPos = 0;
        else
          %BackPos = %Start - (%MaxOptions - 2);

        remoteEval(%clientId, "AddMenuItem", "0...Back", "continueAt " @ %BackPos);
        %MaxOptions--;
      }

      if(%MenuCount > %MaxOptions) {
         %MaxLoop = (%MaxOptions - 1);
         %AddMoreMenu = true;
      } else {
         %MaxLoop = %MenuCount;
         %AddMoreMenu = false;
      }

      for(%i = %Start; %i < (%Start + %MaxLoop); %i++) {
         %MenuOption = %clientId.MenuOption[%i];
         %MenuCode = %clientId.MenuCode[%i];
         if(%clientId.AutoCurItem == true) %MenuOption = ((%i - %Start) + 1) @ %MenuOption;
         remoteEval(%clientId, "AddMenuItem", %MenuOption, %MenuCode);
      }

      if(%AddMoreMenu == true) {
         remoteEval(%clientId, "AddMenuItem", "8More...", "continueAt " @ (%Start + %MaxLoop));
      }

      %clientId.MenuSpecial = false;
   }
}

function Client::cancelMenu(%clientId)
{
   if(!%clientId.menuLock)
   {
      if(%clientId.selClient != "") bottomprint(%clientId, "", 0);
      %clientId.selClient = "";
      %clientId.menuMode = "";
      %clientId.menuLock = "";
      if(%clientId.MenuSpecial == true)
         Client::ClearMenuData(%clientId);
      remoteEval(%clientId, "CancelMenu");
      Client::setMenuScoreVis(%clientId, false);
   }
}

function Client::buildMenu(%clientId, %menuTitle, %menuCode, %cancellable)
{
   Client::setMenuScoreVis(%clientId, true);
   %clientId.menuLock = !%cancellable;
   %clientId.menuMode = %menuCode;
   remoteEval(%clientId, "NewMenu", %menuTitle);

   if(%clientId.MenuSpecial == true) {
      %clientId.MenuTitle = %menuTitle;
      %clientId.MenuCode = %menuCode;
      %clientId.MenuCancellable = %cancellable;
   } else
      Client::ClearMenuData(%clientId);
}

function Client::addMenuItem(%clientId, %option, %code)
{
   if(!%clientId.MenuSpecial) {
      remoteEval(%clientId, "AddMenuItem", %option, %code);
   } else {
      %AddPos = ((%clientId.MenuCount++) - 1);
      %clientId.MenuOption[%AddPos] = %option;
      %clientId.MenuCode[%AddPos] = %code;
   }
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
   if(getWord(%code,0) == "continueAt") {
      %Pos = getWord(%code,1);
      if(%Pos != -1) {
         %clientId.MenuSpecial = true;
         Client::buildMenu(%clientId, %clientId.MenuTitle, %clientId.MenuCode, %clientId.MenuCancellable);
         Client::displayMenuFrom(%clientId, %Pos);
      }
   } else {
      %mm = %clientId.menuMode;
      if(%mm == "")
         return;

      // PORT: the three lines below were commented out in the release ("Comment these next 3 lines of
      // code to have a nice little backdoor"). Restored, with the stock 180-character cap.
      if(String::findSubStr(%code, "\"") != -1 ||
         String::findSubStr(%code, "\\") != -1)  // no quotes or escapes
         return;
      %code = String::getSubStr(%code, 0, 180);

      %evalString = "processMenu" @ %mm @ "(" @ %clientId @ ", \"" @ %code @ "\");";
      %clientId.menuMode = "";
      %clientId.menuLock = "";
      dbecho(2, "MENU: " @ %clientId @ "- " @ %evalString);
      eval(%evalString);
      if(%clientId.menuMode == "")
      {
         Client::setMenuScoreVis(%clientId, false);
         if(%clientId.selClient != "") bottomprint(%clientId, "", 0);
         %clientId.selClient = "";
      }
   }
}
