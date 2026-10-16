// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$ClientScriptVersion = "0.5";

function remoteLogOnPlayer(%clientId, %pass)
{
    if(%pass == "" || %clientId.AcctNo == "") return; // PORT: no account yet, or nothing sent: let the player type it
    if(%clientId.autologged == true)
        return;
        
    %name = Client::getName(%clientId);
    %clientId.autologged = true;
    echo("MODX: AutoLogin["@%name@"]");
    if(Account::isValidPassword(%clientId.AcctNo, %pass))
        Account::LogOn(%clientId);
    else
        Account::LogOff(%clientId);
    return;
}

function remoteWriteSaveVars(%clientId, %data, %slot)
{
    %slot = floor(%slot); // PORT: a slot number, not client text (it is part of every saved-object variable name)
    if(%clientId.ModXAccount != true) return; // PORT: logged-in accounts only
    if(%clientId.isUsingModXScript == false)
    {
        Client::SendMessage(%clientId, 1, "ERROR: You need the ModX Client Add-On to use this slot. Get it at http://modx.cjb.net/");
        return;
    }

    if($ModXSaveObjCount::[%clientId.AcctNo @ "0" @ %slot] >= $SaveSlotLimit)
    {
        Client::SendMessage(%clientId, 1, "Your Save contains more than the allowed maximum per slot on this server ("@$SaveSlotLimit@")! Ignoring Any More Objects!");
        return;
    }
    if(%data != -1)
    {
        %Px = getWord(%data, 0);
        %Py = getWord(%data, 1);
        %Pz = getWord(%data, 2);
        %Rx = getWord(%data, 3);
        %Ry = getWord(%data, 4);
        %Rz = getWord(%data, 5);
        %Di = getWord(%data, 6);
        %Wd = getWord(%data, 7);
        %Ew = String::Replace(getWord(%data, 8), "^", " ");
        %Es = String::Replace(getWord(%data, 9), "^", " ");

        if($DeployableDesc[%Di] == "")
        {
            Client::SendMessage(%clientId, 1, "CORRUPT SAVE FILE! Your Save contains an Invalid Object! Ignoring Invalid Object and continuing with the rest of the file.");
            return;
        }
        %a = $ModXSaveObjCount::[%clientId.AcctNo @ "0" @ %slot];
        if(%a == "")
            %a = 0;

        $ModXAcctObjPXCL::[%clientId.AcctNo @ %a @ %slot] = %Px;
        $ModXAcctObjPYCL::[%clientId.AcctNo @ %a @ %slot] = %Py;
        $ModXAcctObjPZCL::[%clientId.AcctNo @ %a @ %slot] = %Pz;
        $ModXAcctObjRXCL::[%clientId.AcctNo @ %a @ %slot] = %Rx;
        $ModXAcctObjRYCL::[%clientId.AcctNo @ %a @ %slot] = %Ry;
        $ModXAcctObjRZCL::[%clientId.AcctNo @ %a @ %slot] = %Rz;
        $ModXAcctObjDICL::[%clientId.AcctNo @ %a @ %slot] = %Di;
        $ModXAcctObjWDCL::[%clientId.AcctNo @ %a @ %slot] = %Wd;
        $ModXAcctObjEWCL::[%clientId.AcctNo @ %a @ %slot] = %Ew;
        $ModXAcctObjESCL::[%clientId.AcctNo @ %a @ %slot] = %Es;
        $ModXAcctObjTLCL::[%clientId.AcctNo @ "0" @ %slot] = %a + 1;
        $ModXSaveObjCount::[%clientId.AcctNo @ "0" @ %slot] = $ModXAcctObjTLCL::[%clientId.AcctNo @ "0" @ %slot];
    }
    else
    {
        Account::RestoreObjects(%slot, %clientId);
        $ModXSaveObjCount::[%clientId.AcctNo @ "0" @ %slot] = 0;
    }
}

function Client::ClearSlot(%clientId, %slot)
{
    //remoteEval(%clientId, WriteSave, -2, %slot);
}

function Client::ParseSaveInfo(%clientId, %slot)
{
      %name = Client::getName(%clientId);
      %total = $ModXAcctObjTLCL::[%clientId.AcctNo @ "0" @ %slot];
      $ParseSaveInfo::total = %total;
      if(%total == "" || %total == "0")
      {
           $ParseSaveInfo::total = 0;
           return;
      }

      for(%a = 0; %a <= %total; %a++)
      {
                %clientId.dep[%a] = $ModXAcctObjDICL::[%clientId.AcctNo @ %a @ %slot];
                %clientId.pos[%a] = $ModXAcctObjPXCL::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjPYCL::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjPZCL::[%clientId.AcctNo @ %a @ %slot];
                %clientId.rot[%a] = $ModXAcctObjRXCL::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjRYCL::[%clientId.AcctNo @ %a @ %slot] @ " " @ $ModXAcctObjRZCL::[%clientId.AcctNo @ %a @ %slot];
                %clientId.weld[%a] = NumToBool($ModXAcctObjWDCL::[%clientId.AcctNo @ %a @ %slot]);

                %EndPos = $ModXAcctObjEWCL::[%clientId.AcctNo @ %a @ %slot];
                for(%j = 0; (%epos = GetWord(%EndPos, %j)) != -1; %j++)
                {
                   %clientId.endpos[%a @ %j] = String::Replace(%epos, "#", " ");
                }

                %specProp = $ModXAcctObjESCL::[%clientId.AcctNo @ %a @ %slot];
                for(%j = 0; (%spec = GetWord(%specProp, %j)) != -1; %j++)
                {
                   %clientId.specprop[%a @ %j] = %spec;
                }
      }
}

function Client::SaveObjects(%slot, %clientId)
{
      %name = Client::getName(%clientId);
      if(%clientId.isUsingModXScript == false)
      {
          Client::SendMessage(%clientId, 1, "ERROR: You need the ModX Client Add-On to use this slot. Get it at http://modx.cjb.net/");
          return;
      }
      for(%a = 0; (%obj = %clientId.ClObj[%a]) != "" && (%a < $SaveSlotLimit && %a <= %clientId.TotalDeploys); %a++)
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
      if(%num == "")
        %num = 0;
      remoteEval(%clientId, WriteSave, -1, %slot);
      Client::sendMessage(%clientId, 2, "All your objects ("@ %num @"/"@$SaveSlotLimit@") have been saved in Slot " @ %slot);
}

function remoteIAmUsingModX(%manager, %version)
{
    if(%manager.isUsingModXScript == true)
        return;
        
    if(%version == "")
        %version = "0.2"; //Compatibility with pre-0.3, was no 'version' checking...
                
    if(%version < $ClientScriptVersion)
    {
        %manager.isUsingModXScript = false;
        echo("MODX: OldScriptUser[" @ %manager @ "]");
        Client::sendMessage(%manager, 1, "Old ModX Script Detected");
        Client::sendMessage(%manager, 1, "You need to update to the server's version: " @ $ClientScriptVersion);
        return;
    }
    if(%version > $ClientScriptVersion)
    {
        %manager.isUsingModXScript = false;
        echo("MODX: NewScriptUser[" @ %manager @ "]");
        Client::sendMessage(%manager, 1, "New ModX Script Detected");
        Client::sendMessage(%manager, 1, "The server is probably out of date, talk to sever operator.");
        return;
    }
    %manager.isUsingModXScript = true;
    echo("MODX: ScriptUser[" @ %manager @ "]");
    Client::sendMessage(%manager, 3, "           > > > ModX Script Detected < < <           ");
}
