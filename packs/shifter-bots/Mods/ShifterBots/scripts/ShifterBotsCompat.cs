//====================================================================================
// ShifterBotsCompat.cs -- 1.50 port helper for Shifter v1 (10-09-99) with Bots.
// Exec'd once from ShifterBots.cs. Nothing here changes Shifter gameplay.
//====================================================================================

//------------------------------------------------------------------------------------
// ShifterBots::validBotType -- called from processMenuBotAllDone (admin.cs).
//
// The "Bot Controls" menu (in every player's Tab menu while bots are on) ends in a
// menu code that becomes the new bot's NAME: <type>_<gender> or <type>_<gender>_Roam.
// SpoonBot then writes that name unquoted into schedule() strings (AI::setWeapons,
// AI::setupAI, AI::RoamingBotsStartup, AI::SetVar ...). Menu codes come from the
// client, so a crafted code was server-side script. Only the 20 names the three
// menus (type, gender, roaming) can build are accepted. == on two non-numeric strings
// is an exact, case-sensitive compare in this engine.
//------------------------------------------------------------------------------------
function ShifterBots::validBotType(%opt)
{
   %types = "Guard Demo Painter Sniper Medic";
   for(%i = 0; %i < 5; %i++)
   {
      %t = getWord(%types, %i);
      if(%opt == %t @ "_Male" || %opt == %t @ "_Female" || %opt == %t @ "_Male_Roam" || %opt == %t @ "_Female_Roam")
         return true;
   }
   return false;
}
