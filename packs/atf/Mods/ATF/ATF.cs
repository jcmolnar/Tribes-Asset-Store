// {ATF} Mod "v1.0.beta.I.guess" (Attack Team Force, by {ATF}HaCk, scripts dated 2001-2004)
// -- Modern Tribes (1.50) entry script.
//
// The original was started with:   Tribes.exe -mod {ATF} [-dedicated]
// (the two shortcuts in the archive; the mod folder was named "{ATF}"). Here the folder and the
// mod word are "ATF": a mod word may hold letters, digits and underscore only. Nothing else was
// exec'd: the game's own console.cs loads server.cs from this mod's scripts folder, and
// createServer execs ripserver.cs (the Foundation mod's loader), which execs one script per
// armour / weapon / pack / deployable / vehicle.
//
// This file only adds what the mod's scripts use but do not define.
echo(">> {ATF} Mod by {ATF}HaCk");

// PORT FIX: the mod's item.cs dropped the stock CountObjects, but 16 deploy functions still call
// it (how many turrets / sensors / walls already stand inside the placement box). An undefined
// call returns "False" (= 0), so the "too many in the area" and "too close to another" limits never
// applied and every deploy printed "CountObjects: Unknown command". This is the stock function.
function CountObjects(%set,%name,%num)
{
   %count = 0;
   for(%i=0;%i<%num;%i++) {
      %obj=Group::getObject(%set,%i);
      if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
         %count++;
   }
   return %count;
}

// PORT FIX: the mod's game.cs is older than its objectives.cs / item.cs and never sets these two
// stock values. Without the first, a flag taken on a Find-and-Retrieve map had no time allowance
// before it went back; the second is the stock 2 second wait that item.cs:532 adds to
// %player.waitThrowTime (set when a player uses a station) before an item can be thrown.
if($flagToStandTime == "")
   $flagToStandTime = 180;
if($WaitThrowTime == "")
   $WaitThrowTime = 2;
