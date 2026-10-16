// GammY[MK2] "version 0.07" by Gammak7 (scripts packed 2003-10-23), a fork of {ATF}HaCk's
// Foundation-layout mod -- Modern Tribes (1.50) entry script.
//
// The archive holds only a folder "GammY[MK2]" of loose scripts, no readme and no launch line:
// the mod was started with  Tribes.exe -mod GammY[MK2].  Brackets are not legal in a mod word
// here (letters, digits and underscore only), so the folder and the mod word are "GammYMK2".
// Nothing else was exec'd: the game's own console.cs loads server.cs from this mod's scripts
// folder, and createServer execs ripserver.cs (the Foundation mod's loader), which execs one
// script per armour / weapon / pack / deployable / vehicle.
//
// This file only adds what the mod's scripts use but do not define.
echo(">> GammY[MK2] 0.07 by Gammak7");

// PORT FIX (same as the ATF port): the mod's item.cs dropped the stock CountObjects, but 16
// deploy functions still call it (how many turrets / sensors / walls already stand inside the
// placement box). An undefined call returns "False" (= 0), so the "too many in the area" and
// "too close to another" limits never applied and every deploy printed
// "CountObjects: Unknown command". This is the stock function.
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

// PORT FIX (same as the ATF port): the mod's game.cs is older than its item.cs and never sets
// the stock 2 second wait that item.cs adds to %player.waitThrowTime (set when a player uses a
// station) before an item can be thrown.
if($WaitThrowTime == "")
   $WaitThrowTime = 2;
