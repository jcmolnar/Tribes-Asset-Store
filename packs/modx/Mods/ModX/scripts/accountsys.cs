// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//
// Account System
// Uses the player's name for the 'Account Name'
// password set by player on first connection

$SaveSlotLimit = 400;
$SrvSaveSlotLimit = 50;

$AccountFileShort = "ModX_Accounts.cs";
$AccountFile = "config\\" @ $AccountFileShort;
$AccountFile2Short = "ModX_Passwords.cs";
$AccountFile2 = "config\\" @ $AccountFile2Short;

$AcctWeldFileShort = "ModX_WeldOptions.cs";
$AcctWeldFile = "config\\" @ $AcctWeldFileShort;
$AcctHelpFileShort = "ModX_HelpOptions.cs";
$AcctHelpFile = "config\\" @ $AcctHelpFileShort;
$AcctBindFileShort = "ModX_BindOptions.cs";
$AcctBindFile = "config\\" @ $AcctBindFileShort;
$AcctPropFileShort = "ModX_AcctProperties.cs";
$AcctPropFile = "config\\" @ $AcctPropFileShort;

$ObjSaveFileShort = "ModX_SavedObj";
$ObjSaveFile = "config\\" @ $ObjSaveFileShort;
$ObjSaveFileNShort = "ModX_SavedObj_N.cs";
$ObjSaveFileN = "config\\" @ $ObjSaveFileNShort;

$LogTimeFileShort = "ModX_AcctTimeLog.cs";
$LogTimeFile = "config\\" @ $LogTimeFileShort;

exec($AccountFileShort);
exec($AccountFile2Short);

exec($AcctWeldFileShort);
exec($AcctBindFileShort);
exec($AcctHelpFileShort);
exec($AcctPropFileShort);

exec($LogTimeFileShort);

exec($ObjSaveFileShort @ "_DI");
exec($ObjSaveFileShort @ "_PX");
exec($ObjSaveFileShort @ "_PY");
exec($ObjSaveFileShort @ "_PZ");
exec($ObjSaveFileShort @ "_RX");
exec($ObjSaveFileShort @ "_RY");
exec($ObjSaveFileShort @ "_RZ");
exec($ObjSaveFileShort @ "_WD");
exec($ObjSaveFileShort @ "_TL");
exec($ObjSaveFileShort @ "_EW");
exec($ObjSaveFileShort @ "_ES");
exec($ObjSaveFileNShort);

echo("MODX: Beginning Account Preloading");
$ModXGetNumberOfShortCut = 0;
//Decrease lag by shorting some things...
for(%a = 0; (%name = $ModXAcctName::[%a]) != ""; %a++)
{
    $ModXNameShortCut::[%name] = %a;
    $ModXGetNumberOfShortCut++;
    $ModXExistsShortCut::[%name] = true;
}
echo("MODX: Account Preloading Completed");

function Account::isBanned(%acctNo)
{
    %status = getWord($ModXAcctProp::[%acctNo], 0);      //Account Name
    if(%status == -1)
        %status = 0;
    return NumToBool(%status);
}

function Account::isAdmin(%acctNo)
{
    %status = getWord($ModXAcctProp::[%acctNo], 1);      //Account Name
    if(%status == -1)
        %status = 0;
    %status = NumToBool(%status);
}

function Account::toggleBanned(%acctNo)
{
    %status = getWord($ModXAcctProp::[%acctNo], 0);      //Account Name
    if(%status == -1)
        %status = 0;
    %status = NumToBool(%status);
    
    %status2 = getWord($ModXAcctProp::[%acctNo], 1);      //Account Name
    if(%status2 == -1)
        %status2 = 0;
    %status2 = NumToBool(%status2);
    
    if(%status == true)
        %status = false;
    else
        %status = true;
    
    $ModXAcctProp::[%acctNo] = BoolToNum(%status) @ " " @ BoolToNum(%status2);
    
    export("$ModXAcctProp::*", $AcctPropFile, false);
}

function Account::toggleAdmin(%acctNo)
{
    %status = getWord($ModXAcctProp::[%acctNo], 0);      //Account Name
    if(%status == -1)
        %status = 0;
    %status = NumToBool(%status);

    %status2 = getWord($ModXAcctProp::[%acctNo], 1);      //Account Name
    if(%status2 == -1)
        %status2 = 0;
    %status2 = NumToBool(%status2);

    if(%status2 == true)
        %status2 = false;
    else
        %status2 = true;

    $ModXAcctProp::[%acctNo] = BoolToNum(%status) @ " " @ BoolToNum(%status2);

    export("$ModXAcctProp::*", $AcctPropFile, false);
}

function Account::getAcctNo(%name)
{
      if($ModXNameShortCut::[String::MakeCaps(%name)] == "")
          return $ModXGetNumberOfShortCut + 1;
      return $ModXNameShortCut::[String::MakeCaps(%name)];
      
      //%num = 0;
      //for(%a = 0; (%acctName = $ModXAcctName::[%a]) != ""; %a++)
      //{
      //      if(String::MakeCaps(%acctName) == String::MakeCaps(%name))
      //      {
      //          return %a;
      //      }
      //      %num++;
      //}
      //return %num;

}

function Account::Add(%clientId, %password)
{
    %name = Client::getName(%clientId);
    if (Account::Exists(%name))
        return;

    if (%name == "" || %password == "")
        return;

    %total = Account::GetNumberOf();

    $ModXAcctName::[%total] = String::MakeCaps(%name);      //Account Name
    %export = "$ModXAcctName::*";
    export(%export, $AccountFile, false);

    $ModXAcctPass::[%total] = %password;  //Password
    %export = "$ModXAcctPass::*";
    export(%export, $AccountFile2, false);

    %clientId.AcctNo = %total;

    Account::NameSlot(%clientId, 1, "Slot One");
    Account::ResetObjectIndex(%clientId, 1);
    
    $ModXNameShortCut::[%name] = %total;
    $ModXGetNumberOfShortCut++;
    $ModXExistsShortCut::[String::MakeCaps(%name)] = true;

    %name = escapeString(%name);

    Echo("MODX: New Account [" @ %name @ "]");
}

function Account::GetNumberOf()
{
      return $ModXGetNumberOfShortCut;
      //%num = 0;
      //for(%a = 0; $ModXAcctName::[%a] != ""; %a++)
      //{
      //      %num++;
      //}
      //return %num;
}

function Account::Exists(%name)
{
      if($ModXExistsShortCut::[String::MakeCaps(%name)] == true)
          return true;
      return false;

      //%clientId = GetClientByName(%name);
      //for(%a = 0; (%acctName = $ModXAcctName::[%a]) != ""; %a++)
      //{
      //      if(String::MakeCaps(%acctName) == String::MakeCaps(%name))
      //      {
      //          return true;
      //      }
      //}
      //return false;
}

function Account::isValidPassword(%acctno, %password)
{
      %clientId = GetClientByName(%name);
      %acctPass = $ModXAcctPass::[%acctno];

      if(%acctPass == %password)
          return true;
      return false;
}

function Account::AssignAccountNumber(%clientId, %name)
{
      if($ModXNameShortCut::[String::MakeCaps(%name)] == "")
          %clientId.AcctNo = $ModXGetNumberOfShortCut + 1;
      %clientId.AcctNo = $ModXNameShortCut::[String::MakeCaps(%name)];
      //%num = 0;
      //for(%a = 0; (%acctName = $ModXAcctName::[%a]) != ""; %a++)
      //{
      //      if(String::MakeCaps(%acctName) == String::MakeCaps(%name))
      //      {
      //          %clientId.AcctNo = %a;
      //          return;
      //      }
      //      %num++;
      //}
      //%clientId.AcctNo = %num;
}

function Account::PlayerJoin(%clientId)
{
    %clientId.ModXAccount = false;
    %name = Client::getName(%clientId);
    Account::AssignAccountNumber(%clientId, %name);
    schedule("Account::CheckIfLoggedIn("@%clientId@");", 30);
    if(Account::Exists(%name) == true)
    {
        Account::Init(%clientId);
        return;
    }
    else
    {
        Account::Create(%clientId);
        return;
    }
}

function Account::Create(%clientId)
{
    %name = Client::getName(%clientId);
    %name = escapeString(%name);
    CenterPrint(%clientId, "<JC><F1>Hello <F2>" @ %name @ "<F1>, please enter a password, you have 30 seconds.\nPasswords are <F2>case-sensititve<F1>!\n\nThis Password will be used for many things, including reserving your name!\n<F2>Please put in a password you will remeber, otherwise you'll have to change names!<F0>", 30);
    %clientId.EnteringNewAcct = true;
}

function Account::ChangePassword(%clientId)
{
    %name = Client::getName(%clientId);
    %name = escapeString(%name);
    CenterPrint(%clientId, "<JC><F1>Please enter your new password.\nPasswords are <F2>case-sensititve<F1>!\n\n<F2>Please put in a password you will remeber, otherwise you'll have to change names!<F0>", 30);
    %clientId.ChangeAcctPass = true;
}

function Account::Init(%clientId)
{
    %name = Client::getName(%clientId);
    %name = escapeString(%name);
    CenterPrint(%clientId, "<JC><F1>Hello <F2>" @ %name @ "<F1>, please say your password to continue, you have 30 seconds.", 30);
    remoteEval(%clientId, RetreivePassword, %name);
    %clientId.EnteringPassword = true;
}

function Account::LogOn(%clientId)
{
    %name = Client::getName(%clientId);
    processMenuInitialPickTeam(%clientId, -1);
	if(%clientId.spawnWeapon != "")
    {
		Player::useItem(%clientId,%clientId.spawnWeapon);
        %clientId.spawnWeapon="";
    }
    if(%clientId.EnteringNewAcct != true)
    {
        if(%clientId.autologged != true)
        {
            CenterPrint(%clientId, "<JC><F1>Welcome to "@ $currentModName @" <F2>" @ %name @ "<F1> ! Have fun.", 3);
            Echo("MODX: Account Login [" @ %name @ "]");
        }
        else
            CenterPrint(%clientId, "<JC><F2>\nYou have been automatically logged in.\n<f0>- <f1>- <f2>- <f1>- <f0>- \n\n<F1>Welcome to "@ $currentModName @" <F2>" @ %name @ "<F1> ! Have fun.", 3);
    }
    else
        CenterPrint(%clientId, "<JC><F1>Your new password is <F2>" @ %clientId.pass @ "<F1>, guard it!\n\n<F1>Welcome to "@ $currentModName @" <F2>" @ %name @ "<F1>! Have fun.", 4);

    %clientId.EnteringPassword = false;
    %clientId.EnteringNewAcct = false;
    %clientId.ModXAccount = true;
    %clientId.AcctExists = true;
    %clientId.pass = "";
    %clientId.Checkable = false;
    %clientId.autologged = true; //Regardless of if they autologged or not, set this to true to avoid exploit with remoteEval.
    $WeapHelp[%clientId] = Account::IsWeponHelpOn(%clientId);
    
   if (Account::isAdmin(%clientId.acctNo))
   {
       echo("MODX: Admin Join " @ %Name @ ", " @ %IPAddress);
       %clientId.isAdmin = true;
   }
   if (Account::isBanned(%clientId.acctNo))
   {
       echo("MODX: Banned Join " @ %Name @ ", " @ %IPAddress);
       %clientId.ModXAccountBan = true;
   }
    
    $LoggedTime::[%clientId.AcctNo] = $ModX::IntegerTime[0];
    export("$LoggedTime::*", $LogTimeFile, false);
}

function Account::LogOff(%clientId)
{
    $LoggedTime::[%clientId.AcctNo] = $ModX::IntegerTime[0];
    export("$LoggedTime::*", $LogTimeFile, false);
    
    %name = Client::getName(%clientId);
    %clientId.AcctNo = "";
    %clientId.EnteringPassword = false;
    %clientId.EnteringNewAcct = false;
    %clientId.ModXAccount = false;
    %clientId.AcctExists = false;
    %clientId.pass = "";
    %clientId.Checkable = false;
    %name = escapeString(%name);
    schedule("Net::kick("@%clientId@", \"Invalid Password for account: "@ %name @", Auto-Kicked\");", 0.2);
    Echo("MODX: Account Invalid Password [" @ %name @ "]");
}

function Account::CheckIfLoggedIn(%clientId)
{
    if(%clientId.ModXAccount == true)
        return;

    if(%clientId.Checkable == false)
        return;
        
    %name = Client::getName(%clientId);
    if (%name == "" || %name == -1)
        return;
    %clientId.AcctNo = "";
    %clientId.EnteringPassword = false;
    %clientId.EnteringPassword = false;
    %clientId.EnteringNewAcct = false;
    %clientId.ModXAccount = false;
    %clientId.AcctExists = false;
    %clientId.pass = "";
    %name = escapeString(%name);
    Net::kick(%clientId, "Login Timeout for account: "@ %name @", Auto-Kicked");
    Echo("MODX: Account Login Timeout [" @ %name @ "]");
}

function Account::ParseSaveInfo(%clientId, %slot)
{
      %name = Client::getName(%clientId);
      %total = $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ %slot];
      $ParseSaveInfo::total = %total;
      if(%total == "" || %total == "0")
      {
           $ParseSaveInfo::total = 0;
           return;
      }
      
      for(%a = 0; %a <= %total; %a++)
      {
                %clientId.dep[%a] = $ModXAcctObjDI::[%clientId.AcctNo @ %a @ %slot];
                %clientId.pos[%a] = $ModXAcctObjPX::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjPY::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjPZ::[%clientId.AcctNo @ %a @ %slot];
                %clientId.rot[%a] = $ModXAcctObjRX::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjRY::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjRZ::[%clientId.AcctNo @ %a @ %slot];
                %clientId.weld[%a] = NumToBool($ModXAcctObjWD::[%clientId.AcctNo @ %a @ %slot]);

                %EndPos = $ModXAcctObjEW::[%clientId.AcctNo @ %a @ %slot];
                for(%j = 0; (%epos = GetWord(%EndPos, %j)) != -1; %j++)
                {
                   %clientId.endpos[%a @ %j] = String::Replace(%epos, "#", " ");
                }
                
                %specProp = $ModXAcctObjES::[%clientId.AcctNo @ %a @ %slot];
                for(%j = 0; (%spec = GetWord(%specProp, %j)) != -1; %j++)
                {
                   %clientId.specprop[%a @ %j] = %spec;
                }
      }
}

function Account::RestoreObjects(%slot, %clientId)
{
      %name = Client::getName(%clientId);
      
      if(%slot >= 2 && %clientId.isUsingModXScript == false)
      {
        Client::SendMessage(%clientId, 1, "ERROR: You need the ModX Client Add-On to use this slot. Get it at http://modx.cjb.net/");
        return;
      }
      
      if(%slot <= 1)
        Account::ParseSaveInfo(%clientId, %slot);
      else
        Client::ParseSaveInfo(%clientId, %slot);

      if($ParseSaveInfo::total <= 0)
      {
          Client::sendMessage(%clientId, 2, "The slot was restored. All your ("@$ParseSaveInfo::total@") saved objects are now deployed.");
          return;
      }
          
      if($TotalDeploys + $ParseSaveInfo::total >= $MaximumDeployCap)
      {
            Client::sendMessage(%clientId, 1, "Sorry, the maximum object capacity would be breached if this slot were restored.");
            return; //Can't Restore
      }
      
      for(%a = 0; %a < $ParseSaveInfo::total; %a++)
      {
            //if(%clientId.dep[%a] != "False")
            //{
                %obj = DeployClObj(%clientId, %clientId.dep[%a], %clientId.pos[%a], %clientId.rot[%a], %clientId.weld[%a]);
                for(%j = 0; (%epos = %clientId.endpos[%a @ %j]) != ""; %j++)
                {
                   if(%epos != "!")
                      %obj.EndPos[%j] = %epos;
                }

                if(%clientId.specprop[%a @ 0] != "!")
                    %obj.ElevLoop = NumToBool(%clientId.specprop[%a @ 0]);

                if(%clientId.specprop[%a @ 1] != "!")
                    %obj.ElevSpeed   = %clientId.specprop[%a @ 1];

                if(%clientId.specprop[%a @ 2] != "!")
                    %obj.ElevDelay   = %clientId.specprop[%a @ 2];

                %obj.ElevStatus = "ENDED";
            //}
            //if(%obj.weld == true && GameBase::getDataName(%obj).className == "ModXElevator")
            //    Elevator::onWeld(%obj, %obj.weld);
      }
      
    $LoggedTime::[%clientId.AcctNo@"0"@%slot] = $ModX::IntegerTime[0];
    export("$LoggedTime::*", $LogTimeFile, false);
      
      %name = escapeString(%name);
      Client::sendMessage(%clientId, 2, "The slot was restored. All your ("@$ParseSaveInfo::total@") saved objects are now deployed.");
}

function Account::SaveObjects(%slot, %clientId)
{
      %name = Client::getName(%clientId);

      Account::ResetObjectIndex(%clientId, %slot);

      for(%a = 0; (%obj = %clientId.ClObj[%a]) != "" && (%a < $SrvSaveSlotLimit && %a <= %clientId.TotalDeploys); %a++)
      {
            if(%obj.Owner == %clientId && isObject(%obj) == true)
            {
                %depindex = %obj.DepIndex;
                if(%depindex == "" || %depindex == "False")
                    %depindex = 0;

                %update = true;

                if(GameBase::getDataName(%obj).className == "ModXElevator")
                {
                    for(%j = 0; %j < 3; %j++)
                    {
                        %epos = %obj.EndPos[%j];
                        if(%epos == "")
                           %epos = "!";
                        %data = %data @ " " @ String::Replace(%epos, " ", "#");
                    }

                    if(%obj.ElevLoop != "")
                        %data2 = %data2 @ " " @ BoolToNum(%obj.ElevLoop);
                    else
                        %data2 = %data2 @ " " @ BoolToNum(false);

                    if(%obj.ElevSpeed != "")
                        %data2 = %data2 @ " " @ %obj.ElevSpeed;
                    else
                        %data2 = %data2 @ " " @ 1;

                    if(%obj.ElevDelay != "")
                        %data2 = %data2 @ " " @ %obj.ElevDelay;
                    else
                        %data2 = %data2 @ " " @ 3;
                }
                else
                {
                    %data  = "! ! ! !";
                    %data2 = "! ! !";
                }
                
                %objpos = %obj.PositionalCoord;//GameBase::getRotation(%obj);
                %objrot = %obj.RotationalCoord;//GameBase::getPosition(%obj);
                
                if(%update == true)
                {
                    $ModXAcctObjDI::[%clientId.AcctNo @ %a @ %slot] = %depindex;
                    $ModXAcctObjPX::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objpos, 0);
                    $ModXAcctObjPY::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objpos, 1);
                    $ModXAcctObjPZ::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objpos, 2);
                    $ModXAcctObjRX::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objrot, 0);
                    $ModXAcctObjRY::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objrot, 1);
                    $ModXAcctObjRZ::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objrot, 2);
                    $ModXAcctObjWD::[%clientId.AcctNo @ %a @ %slot] = BoolToNum(%obj.weld);
                    $ModXAcctObjEW::[%clientId.AcctNo @ %a @ %slot] = %data;
                    $ModXAcctObjES::[%clientId.AcctNo @ %a @ %slot] = %data2;
                    %num++;
                    %data = "";
                    %data2 = "";
                    %depindex = "";
                }
            }
      }
      $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ %slot] = %num;

      schedule("Account::exportSaves();", 0.1);

      %slotName = $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ %slot];
    $LoggedTime::[%clientId.AcctNo@"0"@%slot] = $ModX::IntegerTime[0];
    export("$LoggedTime::*", $LogTimeFile, false);
      Client::sendMessage(%clientId, 2, "All your objects ("@ %num @"/"@$SrvSaveSlotLimit@") have been saved in " @ %slotName);
}

function Account::exportSaves()
{
      export("$ModXAcctObjTL::*", $ObjSaveFile @ "_TL.cs", false);
      export("$ModXAcctObjEW::*", $ObjSaveFile @ "_EW.cs", false);
      export("$ModXAcctObjES::*", $ObjSaveFile @ "_ES.cs", false);
      export("$ModXAcctObjWD::*", $ObjSaveFile @ "_WD.cs", false);
      export("$ModXAcctObjRZ::*", $ObjSaveFile @ "_RZ.cs", false);
      export("$ModXAcctObjRY::*", $ObjSaveFile @ "_RY.cs", false);
      export("$ModXAcctObjRX::*", $ObjSaveFile @ "_RX.cs", false);
      export("$ModXAcctObjPZ::*", $ObjSaveFile @ "_PZ.cs", false);
      export("$ModXAcctObjPY::*", $ObjSaveFile @ "_PY.cs", false);
      export("$ModXAcctObjPX::*", $ObjSaveFile @ "_PX.cs", false);
      export("$ModXAcctObjDI::*", $ObjSaveFile @ "_DI.cs", false);
}

function Account::ResetObjectAllIndexes(%clientId)
{
      Account::ResetObjectIndex(%clientId, 1);
      //Account::ResetObjectIndex(%clientId, 2);
      //Account::ResetObjectIndex(%clientId, 3);
}

function Account::ResetObjectIndex(%clientId, %slot)
{
      %name = Client::getName(%clientId);
      %null = "";
      
      %total = $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ %slot];

      for(%a = 0; %a <= %total; %a++)
      {
                $ModXAcctObjDI::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjPX::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjPY::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjPZ::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjRX::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjRY::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjRZ::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjWD::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjEW::[%clientId.AcctNo @ %a @ %slot] = %null;
                $ModXAcctObjES::[%clientId.AcctNo @ %a @ %slot] = %null;
      }
      $ModXAcctObjTL::[%clientId.AcctNo @ "0" @ %slot] = 0;
      Account::exportSaves();
}

function Account::ResetAcctObjectIndex(%acctNo, %slot)
{
      %null = "";

      %total = $ModXAcctObjTL::[%acctNo @ "0" @ %slot];

      for(%a = 0; %a <= %total; %a++)
      {
                $ModXAcctObjDI::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjPX::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjPY::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjPZ::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjRX::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjRY::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjRZ::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjWD::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjEW::[%acctNo @ %a @ %slot] = %null;
                $ModXAcctObjES::[%acctNo @ %a @ %slot] = %null;
      }
      $ModXAcctObjTL::[%acctNo @ "0" @ %slot] = 0;
      $ModXAcctObjSlotName::[%acctNo @ "0" @ %slot] = %null;
//      Account::exportSaves();
}

function Account::NameSlot(%clientId, %slot, %slotname)
{
      %name = Client::GetName(%clientId);
          $ModXAcctObjSlotName::[%clientId.AcctNo @ "0" @ %slot] = %slotname;
          %export = "$ModXAcctObjSlotName::*";//" @ %name;
          export(%export, $ObjSaveFileN, false);
      %clientId.ReNamingSlot = -1;
      centerprint(%clientId, "<JC><F1>Slot renamed to <F2>" @ %slotname);
}

function Account::InitNameSlot(%clientId, %slot)
{
      %clientId.ReNamingSlot = %slot;
      centerprint(%clientId, "<JC><F1>Please say the new name of the slot\n<F0>Ten Character Maximum.");
}

function Account::AutoWeldToggle(%clientId)
{
    if($ModXAcctWeldOpt::[%clientId.AcctNo] == "false" || $ModXAcctWeldOpt::[%clientId.AcctNo] == "")
    {
        $ModXAcctWeldOpt::[%clientId.AcctNo] = "true";
    }
    else
        $ModXAcctWeldOpt::[%clientId.AcctNo] = "false";

    %export = "$ModXAcctWeldOpt::*";
    export(%export, $AcctWeldFile, false);
}

function Account::IsAutoWeld(%clientId)
{
    if($ModXAcctWeldOpt::[%clientId.AcctNo] != "true")
        return false;
    else
        return true;
}

function Account::WeaponMode(%player,%rotate)
{
    %client = Player::getClient(%player);
    %weapon = Player::getMountedItem(%player,$WeaponSlot);

	if(%weapon == Creator)
	{
		%mode = %client.CurDeploy + %rotate;

		if(%mode > $DeployableTotal -1) %mode = 0;
		else if (%mode <0) %mode = $DeployableTotal -1;
		%client.CurDeploy = %mode;

		//Client::sendMessage(%client, 0, "~wturreton1.wav");
		bottomprint(%client, "<jc>Object Creator: <f2>" @ $DeployableDesc[%client.CurDeploy], $DefStayTime - 1);
        return;
	}
	else if(%weapon == Grabbler)
	{
		%mode = %client.CurMoveMode + %rotate;

		if (%mode < 0) %mode = 30;
		if (%mode > 30) %mode = 0;
		%client.CurMoveMode = %mode;

		//Client::sendMessage(%client, 0, "~wturreton1.wav");
		bottomprint(%client, "<jc>Object Manipulator: <f2>" @ $MovementMode::[%mode], $DefStayTime - 1);
        %client.MovementType = $MovementMode::[%mode];

		return;
	}
	else if(%weapon == Destructor)
	{
		%mode = %client.CurDelMode + %rotate;

		if (%mode < 0) %mode = 1;
		if (%mode > 1) %mode = 0;
		%client.CurDelMode = %mode;

		//Client::sendMessage(%client, 0, "~wturreton1.wav");
		bottomprint(%client, "<jc>Object Deletor: <f2>" @ $DelMode::[%mode], $DefStayTime - 1);
		return;
	}
	else if(%weapon == Welder)
	{
		%mode = %client.WeldMode + %rotate;

		if (%mode < 0) %mode = 1;
		if (%mode > 1) %mode = 0;
		%client.WeldMode = %mode;

		//Client::sendMessage(%client, 0, "~wturreton1.wav");
		bottomprint(%client, "<jc>Object Welder: <f2>" @ $WeldMode::[%mode], $DefStayTime - 1);
		return;
	}
	else
	{
        //
		return;
	}

}

function ModX::moveBoost(%obj) //PlayerId
{
    %rot = GameBase::getRotation(%obj);

    %boostVec = Vector::getFromRot(%rot, 60, 0);
    Item::setVelocity(%obj, Vector::add(%boostVec, Item::getVelocity(%obj)));

    //Player::applyImpulse(%obj,%boostVec);
}

function ModX::moveStop(%player)
{
    Item::setVelocity(%player, "0 0 0");
}

function Account::readBind(%player, %item)
{
    %num = Account::ItemToNumber(%item);
    %bind = Account::getBoundFunc(%player, %num);
    if($LaserTagMode)
        return false;
        
 	if(%bind == "A")
	{
        Account::WeaponMode(%player,1);
        return true;
    }
 	if(%bind == "B")
	{
        Account::WeaponMode(%player,-1);
        return true;
    }
 	if(%bind == "C")
	{
        UndoLast(Player::getClient(%player));
        return true;
    }
 	if(%bind == "D")
	{
        Creator::onUse(%player,Creator);
        return true;
    }
    if(%bind == "E")
	{
        Grabbler::onUse(%player,Grabbler);
        return true;
    }
    if(%bind == "F")
	{
        Destructor::onUse(%player,Destructor);
        return true;
    }
 	if(%bind == "G")
	{
        Welder::onUse(%player,Welder);
        return true;
	}
	if(%bind == "H")
	{
        Warper::onUse(%player,Warper);
        return true;
	}
	if(%bind == "I")
	{
        TargetingLaser::onUse(%player,TargetingLaser);
        return true;
	}
	if(%bind == "J")
	{
        StrykerChain::onUse(%player,TargetingLaser);
        return true;
	}
    if(%bind == "K")
	{
		ModX::moveBoost(%player);
        return true;
	}
	if(%bind == "L")
	{
		ModX::moveStop(%player);
        return true;
	}
	if(%bind == "M")
	{
        //Do Nothing...
        return true;
	}
    return false;
}

$DefaultBindAction[0] = "A";
$DefaultBindAction[1] = "B";
$DefaultBindAction[2] = "C";
$DefaultBindAction[3] = "D";
$DefaultBindAction[4] = "E";
$DefaultBindAction[5] = "F";
$DefaultBindAction[6] = "G";
$DefaultBindAction[7] = "H";
$DefaultBindAction[8] = "I";
$DefaultBindAction[9] = "K";
$DefaultBindAction[10] = "L";
$DefaultBindAction[11] = "M";
$DefaultBindAction[12] = "M";

function Account::getBoundFunc(%player, %num)
{
    %clientId = Player::getClient(%player);
    %return = GetWord($ModXAcctBinds::[%clientId.AcctNo], %num);
    if(%return == -1)
        %return = $DefaultBindAction[%num];
    return %return;
}

function Account::ItemToNumber(%item)
{
    %num = -1;
    if(%item == Blaster)
        %num = 0;
 	if(%item == PlasmaGun)
        %num = 1;
 	if(%item == Chaingun)
        %num = 2;
 	if(%item == DiscLauncher)
        %num = 3;
    if(%item == GrenadeLauncher)
        %num = 4;
    if(%item == LaserRifle)
        %num = 5;
 	if(%item == EnergyRifle)
        %num = 6;
	if(%item == Mortar)
        %num = 7;
	if(%item == TargetingLaser)
        %num = 8;
	if(%item == Grenade)
        %num = 9;
	if(%item == MineAmmo)
        %num = 10;
	if(%item == Beacon)
        %num = 11;
	if(%item == RepairKit)
        %num = 12;
    return %num;
}

function Account::ItemToBind(%item)
{
    %letter = -1;
    if(%item == Creator)
        %letter = "D";
 	if(%item == Grabbler)
        %letter = "E";
 	if(%item == Destructor)
        %letter = "F";
 	if(%item == Welder)
        %letter = "G";
    if(%item == Warper)
        %letter = "H";
    if(%item == TargetingLaser)
        %letter = "I";
 	if(%item == StrykerChain)
        %letter = "J";
    if(%item == Grenade)
        %letter = "K";
 	if(%item == MineAmmo)
        %letter = "L";
    return %letter;
}

function Account::LetterIsBound(%clientId, %letter)
{
    %string = $ModXAcctBinds::[%clientId.AcctNo];
    if(%string == "")
        %string = "A B C D E F G H I K L M M";

    if(String::Contains(%string, %letter))
        return true;
    else
        return false;
}

function Account::LetterToFuncDesc(%letter)
{
 	if(%letter == "A")
	{
        return "Weapon Mode Next";
    }
 	if(%letter == "B")
	{
        return "Weapon Mode Previous";
    }
 	if(%letter == "C")
	{
        return "Undo Last Deploy";
    }
 	if(%letter == "D")
	{
        return "Use Object Creator";
    }
    if(%letter == "E")
	{
        return "Use Object Manipulator";
    }
    if(%letter == "F")
	{
        return "Use Object Deletor";
    }
 	if(%letter == "G")
	{
        return "Use Object Welder";
	}
	if(%letter == "H")
	{
        return "Use Warper";
	}
	if(%letter == "I")
	{
        return "Use Targeting Laser";
	}
	if(%letter == "J")
	{
        return "Use Pull-Beam";
	}
	if(%letter == "K")
	{
        return "Boost";
	}
	if(%letter == "L")
	{
        return "Air Brake";
	}
	if(%letter == "M")
	{
        return "Do Nothing";
	}
    return "";
}

function Account::ModifyBind(%clientId, %num, %new)
{
    %stringTemp = "";
    for(%i = 0; %i < 13; %i++)
    {
        %bind = GetWord($ModXAcctBinds::[%clientId.AcctNo], %i);

        if(%bind == -1)
            %bind = $DefaultBindAction[%i];
        if(%i == %num)
            %bind = %new;
        %stringTemp = %stringTemp @ " " @ %bind;

    }

    $ModXAcctBinds::[%clientId.AcctNo] = String::Left(%stringTemp, 1); //Trim Extra Space
    %export = "$ModXAcctBinds::*";
    export(%export, $AcctBindFile, false);
}

function Account::ResetBinds(%clientId)
{
    $ModXAcctBinds::[%clientId.AcctNo] = "A B C D E F G H I K L M M";
    %export = "$ModXAcctBinds::*";
    export(%export, $AcctBindFile, false);
}

function Account::isSpawnWeapon(%clientId, %search) //Checks to see if the item is currently bound to a key
{
    for(%i = 0; $spawnBuyList[%i] != ""; %i++)
    {
        if(%bind == -1)
            %bind = $DefaultBindAction[%i];

        if((%search @ "s") == ($spawnBuyList[%i] @ "s"))
        {
            if(Account::LetterIsBound(%clientId, Account::ItemToBind($spawnBuyList[%i])) == true)
                return true;
        }

    }
    return false;
}

function Account::ToggleWeaponHelp(%clientId)
{
    %toggle = $ModXAcctWeapHelp::[%clientId.AcctNo];
    if(%toggle == "false")
        %toggle = "true";
    else
        %toggle = "false";

    $ModXAcctWeapHelp::[%clientId.AcctNo] = %toggle;
    %export = "$ModXAcctWeapHelp::*";
    export(%export, $AcctHelpFile, false);
    $WeapHelp[%clientId] = %toggle;
}

function Account::IsWeponHelpOn(%clientId)
{
    %help = $ModXAcctWeapHelp::[%clientId.AcctNo];
    if(%help == "")
        %help = $WeapHelp[%clientId];
    if(%help == "false")
        return false;
    else
        return true;
}

function sendHelpMessages(%type, %msg)
{

    for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
    {
        if($WeapHelp[%clientId] == "true")
            Client::SendMessage(%clientId, %type, %msg);
    }

}

function Account::ToggleLaserTag(%clientId, %team)
{
    if($LaserTagMode)
        Account::DisableLaserTag(%clientId);
    else
        Account::EnableLaserTag(%clientId, %team);
}

exec("weaponLaserTagRifle.cs");
exec("weaponRapidLaserTagRifle.cs");

function Account::EnableLaserTag(%clientId, %team)
{
    %team = NumToBool(%team);
    if(%team == "")
        %team = false;
    %initCl = %clientId;
    if($LaserTagMode)
        return;

    $LaserTagMode = true;
    $LaserTagTeamMode = %team;                      //Has Issues with trying to read it's value outside this function
    $LaserTagXtra = BoolToNum($LaserTagTeamMode);
    
    lfemale.minJetEnergy = 25;
    lfemale.jetEnergyDrain = 4.5;
    //lfemale.jetForce = 256;
    lfemale.maxDamage = 1.0;
    $DamageScale[lfemale, $LaserTagDamageType] = 1.0;
    $DamageScale[lfemale, $LandingDamageType] = 1.0;
    $DamageScale[lfemale, $ImpactDamageType] = 1.0;
    $DamageScale[lfemale, $CrushDamageType] = 1.0;
    $MaxWeapons[lfemale] = 2;
    
    larmor.minJetEnergy = 25;
    larmor.jetEnergyDrain = 4.5;
    //larmor.jetForce = 256;
    larmor.maxDamage = 1.0;
    $DamageScale[larmor, $LaserTagDamageType] = 1.0;
    $DamageScale[larmor, $LandingDamageType] = 1.0;
    $DamageScale[larmor, $ImpactDamageType] = 1.0;
    $DamageScale[larmor, $CrushDamageType] = 1.0;
    $MaxWeapons[larmor] = 2;

    $ItemMax[larmor,Welder]	= 0;
    $ItemMax[lfemale,Welder] = 0;
    $ItemMax[larmor, Warper] = 0;
    $ItemMax[lfemale, Warper] = 0;
    $ItemMax[larmor, TargetingLaser] = 0;
    $ItemMax[lfemale, TargetingLaser] = 0;
    $ItemMax[larmor,StrykerChain] = 0;
    $ItemMax[lfemale,StrykerChain] = 0;
    $ItemMax[larmor, Grabbler] = 0;
    $ItemMax[lfemale, Grabbler] = 0;
    $ItemMax[larmor,Destructor]	= 0;
    $ItemMax[lfemale,Destructor] = 0;
    $ItemMax[larmor, Creator] = 0;
    $ItemMax[lfemale, Creator] = 0;
    
    $ItemMax[larmor, LaserTagRifle] = 1;
    $ItemMax[lfemale, LaserTagRifle] = 1;
    $ItemMax[larmor, RapidLaserTagRifle] = 1;
    $ItemMax[lfemale, RapidLaserTagRifle] = 1;
    
   setClientScoreHeading("Player Name\t\x78Team\t\xC8Score");

   $numTeams = getNumTeams();
   for(%i = 0; %i < $numTeams; %i++)
      $teamScoreLT[%i] = 0;

   if($LaserTagTeamMode && !($numTeams == 1))
   {
      setTeamScoreHeading("Team Name\t\xC8Score");
      setClientScoreHeading("Player Name\t\x78Team\t\xC8Score");
   }
   else
   {
      $SensorNetworkEnabled = false;
      setTeamScoreHeading("Builder Team Name\t\xC8--");
      setClientScoreHeading("Player Name\t\x55Kills\t\x75Deaths\t\xA5Efficiency\t\xE3Ping\t\xFFPL");
   }
   $dieSeqCount = 0;
   
    for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
    {
        if(!Player::isDead(%clientId))
        {
            if (Player::getArmor(%clientId) == slarmor || Player::getArmor(%clientId) == marmor)
                Player::setArmor(%clientId, larmor);
            if (Player::getArmor(%clientId) == slfemale || Player::getArmor(%clientId) == mfemale)
                Player::setArmor(%clientId, lfemale);
            if (Player::getArmor(%clientId) == harmor)
            {
                remoteKill(%clientId);
                return;
            }
            Player::setItemCount(%clientId, $spawnBuyList[1], 0);
            Player::setItemCount(%clientId, $spawnBuyList[2], 0);
            Player::setItemCount(%clientId, $spawnBuyList[3], 0);
            Player::setItemCount(%clientId, $spawnBuyList[4], 0);
            Player::setItemCount(%clientId, $spawnBuyList[5], 0);
            Player::setItemCount(%clientId, $spawnBuyList[6], 0);
            Player::setItemCount(%clientId, $spawnBuyList[7], 0);
            Player::setItemCount(%clientId, LaserTagRifle, 1);
            Player::setItemCount(%clientId, RapidLaserTagRifle, 1);
            Player::useItem(%clientId,LaserTagRifle);
        }
        %clientId.ltscore = 0;
        Game::refreshClientScore(%clientId);
    }
    Centerprintall("<JC>Laser Tag Mode Enabled\nTEAM: " @ %team);
}

function Account::DisableLaserTag(%clientId)
{
    %initCl = %clientId;
    if(!$LaserTagMode)
        return;

    $LaserTagMode = false;
    $LaserTagXtra = -1;
    
    lfemale.minJetEnergy = 0;
    lfemale.jetForce = 336;
    lfemale.maxDamage = 1.0;
    lfemale.jetEnergyDrain = -0.1;
    $DamageScale[lfemale, $LaserTagDamageType] = -0.0;
    $DamageScale[lfemale, $LandingDamageType] = -0.0;
    $DamageScale[lfemale, $ImpactDamageType] = -0.0;
    $DamageScale[lfemale, $CrushDamageType] = -0.0;
    $MaxWeapons[lfemale] = 7;

    larmor.minJetEnergy = 0;
    larmor.jetForce = 336;
    larmor.maxDamage = 1.0;
    larmor.jetEnergyDrain = -0.1;
    $DamageScale[larmor, $LaserTagDamageType] = -0.0;
    $DamageScale[larmor, $LandingDamageType] = -0.0;
    $DamageScale[larmor, $ImpactDamageType] = -0.0;
    $DamageScale[larmor, $CrushDamageType] = -0.0;
    $MaxWeapons[larmor] = 7;

    $ItemMax[larmor,Welder]	= 1;
    $ItemMax[lfemale,Welder] = 1;
    $ItemMax[larmor, Warper] = 1;
    $ItemMax[lfemale, Warper] = 1;
    $ItemMax[larmor, TargetingLaser] = 1;
    $ItemMax[lfemale, TargetingLaser] = 1;
    $ItemMax[larmor,StrykerChain] = 1;
    $ItemMax[lfemale,StrykerChain] = 1;
    $ItemMax[larmor, Grabbler] = 1;
    $ItemMax[lfemale, Grabbler] = 1;
    $ItemMax[larmor,Destructor]	= 1;
    $ItemMax[lfemale,Destructor] = 1;
    $ItemMax[larmor, Creator] = 1;
    $ItemMax[lfemale, Creator] = 1;

    $ItemMax[larmor, LaserTagRifle] = 0;
    $ItemMax[lfemale, LaserTagRifle] = 0;
    $ItemMax[larmor, RapidLaserTagRifle] = 0;
    $ItemMax[lfemale, RapidLaserTagRifle] = 0;
    
    for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
    {
        if(!Player::isDead(%clientId))
        {
            Player::setItemCount(%clientId, LaserTagRifle, 0);
            Player::setItemCount(%clientId, RapidLaserTagRifle, 0);
            for(%i = 1; (%item = $spawnBuyList[%i]) != ""; %i++)
            {
                if(Account::isSpawnWeapon(%clientId, %item))
                {
                    Player::setItemCount(%clientId,%item,1);
                }
        	}
        }
        %clientId.ltscore = 0;
        %clientId.scoreKills = 0;
        %clientId.scoreDeaths = 0;
        Game::refreshClientScore(%clientId);
    }
    
   setClientScoreHeading("Player Name\t\x78Team\t\xC8Score");

    $numTeams = getNumTeams();
    for(%i = 0; %i < $numTeams; %i++)
       $teamScoreLT[%i] = 0;

    $SensorNetworkEnabled = true;
    setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Deploys\t\xDFPing");//\t\xD6PL");
    setTeamScoreHeading("Team Name\t\xD0Deploys");
    $dieSeqCount = 0;
    
    Centerprintall("<JC>Laser Tag Mode Disabled");
}

//Builder Groups, 11-7-04
function BuildGroup::RequestJoin(%clientId, %group)
{
    if(BuildGroup::IsInGroup(%clientId, %group))
        return;

    if(%clientId.buildgroup != "")
        return;

    if($BuildGroupLeader[%group] == "")
        BuildGroup::Create(%clientId, %group);
    else
    {
        if($BuildGroupLeader[%group].DecidingOnAccept == true)
        {
            Client::sendMessage(%clientId, 0, "Your request to join group " @ %group @ " has been delayed. Try Again Later!");
            return;
        }

        Client::sendMessage($BuildGroupLeader[%group], 0, Client::getName(%clientId) @ " is requesting to join your group: " @ %group @ ". Say '!ok' to accept, or '!no' to decline.");
        $BuildGroupLeader[%group].DecidingOnAccept = true;
        $BuildGroupLeader[%group].DecidingOnAcceptCL = %clientId;
        Client::sendMessage(%clientId, 0, "Your request to join group " @ %group @ " has been sent.");
    }
}

function BuildGroup::Join(%clientId, %group)
{
    if(BuildGroup::IsInGroup(%clientId, %group))
        return;

    if(%clientId.buildgroup != "")
        return;
        
    $BuildGroup[%group, %clientId] = true;
    $BuildGroup[%group, -1]++;
    
    %clientId.buildgroup = %group;
    
    Client::sendMessage(%clientId, 0, "Your request to join group " @ %group @ " has been accepted.");
}

function BuildGroup::Leave(%clientId)
{
    if(%clientId.buildgroup == "")
        return;

    if($BuildGroupLeader[%clientId.buildgroup] == %clientId)
    {
        BuildGroup::Disband(%clientId, %clientId.buildgroup);
        return;
    }

    $BuildGroup[%group, %clientId] = "";
    $BuildGroup[%group, -1]--;
    
    %clientId.buildgroup = "";
    
    Client::sendMessage(%clientId, 0, "You have left your group.");
}

function BuildGroup::Reject(%clientId, %group)
{
    if(%clientId.buildgroup == "")
        return;

    Client::sendMessage(%clientId, 0, "Your request to join group " @ %group @ " has been denined.");
}

function BuildGroup::Create(%clientId, %group)
{
    if($BuildGroup[%group] == true)
        return;

    if(BuildGroup::IsInGroup(%clientId, %group))
        return;

    if(%clientId.buildgroup != "")
        return;

    $BuildGroup[%group] = true;
    $BuildGroup[%group, -1] = 0;
    Client::sendMessage(%clientId, 0, "Group " @ %group @ " is now created.");
    
    $BuildGroup[%group, %clientId] = true;
    $BuildGroup[%group, -1]++;
    $BuildGroupLeader[%group] = %clientId;
    
    %clientId.buildgroup = %group;
}

function BuildGroup::Disband(%initclientId, %disgroup)
{
    for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
    {
        %group = %clientId.buildgroup;
        if(%group == "")
            continue;

        if(%group != %disgroup)
            continue;
            
        $BuildGroup[%disgroup, %clientId] = "";
        $BuildGroup[%disgroup, -1]--;
        
        %clientId.buildgroup = "";
        
        if(%clientId != %initclientId)
            Client::sendMessage(%clientId, 0, "Your group has been disbanded.");
    }
    $BuildGroupLeader[%disgroup] = "";
    $BuildGroup[%group] = "";
    
    Client::sendMessage(%initclientId, 0, "Group " @ %disgroup @ " has now been disbanded.");
}

function BuildGroup::ShowMembers(%InitClientId)
{
    if(%InitClientId.buildgroup == "")
        return;

    %str = "<F1>Members of " @ %InitClientId.buildgroup @ ": <F2>\n";
    for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
    {
        %group = %clientId.buildgroup;
        if(%group == "")
            continue;

        if(BuildGroup::IsInGroup(%clientId, %InitClientId.buildgroup))
            %str = %str @ "\n" @ Client::getName(%clientId);
    }
    centerprint(%InitClientId, %str);
}

function BuildGroup::IsInGroup(%clientId, %group)
{
    if($BuildGroup[%group, %clientId] == true)
        return true;
    return false;
}

function BuildGroup::SaveObjects(%slot, %clientId)
{
      if(%clientId.buildgroup == "")
          return;

      %name = Client::getName(%clientId);
      if(%clientId.isUsingModXScript == false)
      {
          Client::SendMessage(%clientId, 1, "ERROR: You need the ModX Client Add-On to use this slot. Get it at http://modx.cjb.net/");
          return;
      }
      %num = 0;
      for(%clientIdTgt = Client::getFirst(); %clientIdTgt != -1; %clientIdTgt = Client::getNext(%clientIdTgt))
      {
          if(!BuildGroup::IsInGroup(%clientId, %clientIdTgt.buildgroup))
              continue;

          if(%num > $SaveSlotLimit + 100)
              break;
              
          for(%a = 0; (%obj = %clientIdTgt.ClObj[%a]) != "" && (%a < $SaveSlotLimit + 100 && %a <= %clientIdTgt.TotalDeploys); %a++)
          {
                if(%num + %a > $SaveSlotLimit + 100)
                    break;
                if(%obj.Owner == %clientIdTgt && isObject(%obj) == true)
                {
                    %depindex = %obj.DepIndex;
                    if(%depindex == "" || %depindex == "False")
                        %depindex = 0;

                    %update = true;

                    if(GameBase::getDataName(%obj).className == "ModXElevator")
                    {
                        for(%j = 0; %j < 3; %j++)
                        {
                            %epos = %obj.EndPos[%j];
                            if(%epos == "")
                               %epos = "!";
                            %data = %data @ " " @ String::Replace(%epos, " ", "#");
                        }

                        if(%obj.ElevLoop != "")
                            %data2 = %data2 @ " " @ BoolToNum(%obj.ElevLoop);
                        else
                            %data2 = %data2 @ " " @ BoolToNum(false);

                        if(%obj.ElevSpeed != "")
                            %data2 = %data2 @ " " @ %obj.ElevSpeed;
                        else
                            %data2 = %data2 @ " " @ 1;

                        if(%obj.ElevDelay != "")
                            %data2 = %data2 @ " " @ %obj.ElevDelay;
                        else
                            %data2 = %data2 @ " " @ 3;
                    }
                    else
                    {
                        %data  = "! ! ! !";
                        %data2 = "! ! !";
                    }

                    %objpos = %obj.PositionalCoord;//GameBase::getRotation(%obj);
                    %objrot = %obj.RotationalCoord;//GameBase::getPosition(%obj);

                    if(%update == true)
                    {
                        $ModXAcctObjPXCL::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objpos, 0);
                        $ModXAcctObjPYCL::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objpos, 1);
                        $ModXAcctObjPZCL::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objpos, 2);
                        $ModXAcctObjRXCL::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objrot, 0);
                        $ModXAcctObjRYCL::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objrot, 1);
                        $ModXAcctObjRZCL::[%clientId.AcctNo @ %a @ %slot] = GetWord(%objrot, 2);
                        $ModXAcctObjDICL::[%clientId.AcctNo @ %a @ %slot] = %depindex;
                        $ModXAcctObjWDCL::[%clientId.AcctNo @ %a @ %slot] = BoolToNum(%obj.weld);
                        $ModXAcctObjEWCL::[%clientId.AcctNo @ %a @ %slot] = %data;
                        $ModXAcctObjESCL::[%clientId.AcctNo @ %a @ %slot] = %data2;
                        %num++;
                        %data = "";
                        %data2 = "";
                        %depindex = "";

                        %Px = $ModXAcctObjPXCL::[%clientId.AcctNo @ %a @ %slot];
                        %Py = $ModXAcctObjPYCL::[%clientId.AcctNo @ %a @ %slot];
                        %Pz = $ModXAcctObjPZCL::[%clientId.AcctNo @ %a @ %slot];
                        %Rx = $ModXAcctObjRXCL::[%clientId.AcctNo @ %a @ %slot];
                        %Ry = $ModXAcctObjRYCL::[%clientId.AcctNo @ %a @ %slot];
                        %Rz = $ModXAcctObjRZCL::[%clientId.AcctNo @ %a @ %slot];
                        %Di = $ModXAcctObjDICL::[%clientId.AcctNo @ %a @ %slot];
                        %Wd = $ModXAcctObjWDCL::[%clientId.AcctNo @ %a @ %slot];
                        %Ew = String::Replace($ModXAcctObjEWCL::[%clientId.AcctNo @ %a @ %slot], " ", "^");
                        %Es = String::Replace($ModXAcctObjESCL::[%clientId.AcctNo @ %a @ %slot], " ", "^");

                        %dataToSend = %Px @ " " @ %Py @ " " @ %Pz @ " " @ %Rx @ " " @ %Ry @ " " @ %Rz @ " " @ %Di @ " " @ %Wd @ " " @ %Ew @ " " @ %Es;

                        remoteEval(%clientId, WriteSave, %dataToSend, %slot);
                    }
                }
          }
          //%num += %a;
      }
      //%num = 0;
      remoteEval(%clientId, WriteSave, -1, %slot);
      Client::sendMessage(%clientId, 2, "All your group's objects ("@ %num @"/"@$SaveSlotLimit + 100@") have been saved in your Group Slot");
}
