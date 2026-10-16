//====================================================================================
// Shifter2k5Compat.cs -- 1.50 port shim for Shifter 2K5 v1.0. Exec'd once from
// Shifter2k5.cs. Nothing here changes Shifter gameplay: every function below is one
// the mod's own scripts call and that had no definition left in the shipped set.
//====================================================================================

//------------------------------------------------------------------------------------
// Client::buildText -- defined in the release's menu.cs (a copy of stock menu.cs plus
// this one function, identical to Client::buildMenu). That menu.cs is not shipped: the
// 1.50 base menu.cs is the same code with length checks on the client side. 19 call
// sites in admin.cs / AdminServerConfig.cs / AdminGameConfig.cs open admin menus with it.
//------------------------------------------------------------------------------------
function Client::buildText(%clientId, %menuTitle, %menuCode, %cancellable)
{
   Client::setMenuScoreVis(%clientId, true);
   %clientId.menuLock = !%cancellable;
   %clientId.menuMode = %menuCode;
   remoteEval(%clientId, "NewMenu", %menuTitle);
}

//------------------------------------------------------------------------------------
// GameBase::getHeatFactor -- base's stub, dropped by Shifter's game.cs while turret.cs
// and baseProjData.cs still dispatch GameBase::virtual(%target, "getHeatFactor").
// Same fix as the Shifter and Shifter_v1G packs: "" and 0.0 both fail the >= 0.5 test.
//------------------------------------------------------------------------------------
function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

//------------------------------------------------------------------------------------
// checkMaxDrop -- called from penisCurse (player.cs) and defined by no Shifter build.
// The no-op it has always been; keeps "Unknown command" out of the log.
//------------------------------------------------------------------------------------
function checkMaxDrop(%client, %armor)
{
}

//------------------------------------------------------------------------------------
// Admin::setTeamDamageEnable -- Shifter K had it; Shifter 2K4 moved team damage into
// the Damage Options menu and deleted the function, but the vote handler
// (Admin::voteSucceded, actions "etd" / "dtd") still calls it. A passed team-damage
// vote did nothing. Body = Shifter K 10-30-2003 admin.cs:240.
//------------------------------------------------------------------------------------
function Admin::setTeamDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Server::TeamDamageScale = 1;
         if(%admin == -1)
            messageAll(0, "Team damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
      }
   }
}

//------------------------------------------------------------------------------------
// processMenuDSAAffirm -- the confirm handler of "Remove SuperAdmin" (admin.cs builds
// the menu with code "dsaaffirm"). Shifter 2K4 had it; 2K5 deleted it and left the
// menu, so the option printed "Unknown command". Restored from 2K4 0.85 WITHOUT its
// hard-coded exemption for one player name (the 2K4 author).
//------------------------------------------------------------------------------------
function processMenuDSAAffirm(%clientId, %opt)
{
   %cl = getWord(%opt, 1);
   if(getWord(%opt, 0) == "yes" && %clientId.isSuperAdmin)
   {
      %cl.isAdmin = false;
      %cl.isSuperAdmin = false;
      messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s Super admin ability.");
      echo("" @ Client::getName(%cl) @ " Super Admin Revoked By " @ Client::getName(%clientId));
      return;
   }
   Game::menuRequest(%clientId);
}
