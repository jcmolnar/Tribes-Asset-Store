// Private dedicated-host regression: ordinary arena functions, no player commands.
// Load after Duelmap4; schedule ArenaFix::Run() after mission startup settles.
function ArenaFix::Check(%ok, %name)
{
   $arenaFix::checks++;
   if(!%ok) { $arenaFix::failures++; echo("[ARENAFIX-FAIL] ",%name); }
}
function ArenaFix::Count(%group)
{
   %count=Group::objectCount(%group);
   %total=%count;
   for(%i=0;%i<%count;%i++) {
      %o=Group::getObject(%group,%i);
      if(getObjectType(%o)=="SimGroup") %total+=ArenaFix::Count(%o);
   }
   return %total;
}
function ArenaFix::Run()
{
   $Server::timeLimit=0;
   $arenaFix::checks=0; $arenaFix::failures=0;
   $arenaFix::baseline=ArenaFix::Count(MissionCleanup);
   %group=$DeathMatch::ArenaGroup;
   ArenaFix::Check(isObject(%group),"DM owns an arena group");
   echo("[ARENAFIX] initial total=",$arenaFix::baseline," top=",Group::objectCount(MissionCleanup)," children=",Group::objectCount(%group));
   for(%n=0;%n<40;%n++) {
      %old=$DeathMatch::ArenaGroup;
      %child=Group::getObject(%old,0);
      DeathMatch::Stop();
      ArenaFix::Check(!isObject(%old) && !isObject(%child),"DM removes old group and child "@%n);
      if(%n%2==0) $DeathMatch::Arena="AreciboArena";
      else $DeathMatch::Arena="Arena_Madness";
      DeathMatch::Start();
      ArenaFix::Check(isObject($DeathMatch::ArenaGroup) && $DeathMatch::Offset=="1000 1000 2000","DM reuses first offset "@%n);
   }
   ArenaFix::Check(ArenaFix::Count(MissionCleanup)==$arenaFix::baseline,"40 DM transitions stay bounded");
   echo("[ARENAFIX] after40=",ArenaFix::Count(MissionCleanup)," allocations=",$ArenasMade);

   ArenaFix::Check(TeamDuel::MakeArena("Battle_Cube",1,2),"first team match builds");
   %first=$TeamDuel::ArenaGroup[1]; %offset=%first.offsetIndex;
   ArenaFix::Check(TeamDuel::MakeArena("Battle_Cube",3,4),"second team match builds");
   %second=$TeamDuel::ArenaGroup[3]; %secondChild=Group::getObject(%second,0);
   ArenaFix::Check(%first!="" && %first==$TeamDuel::ArenaGroup[2] && %first!=%second,"teams share only their own instance");
   ArenaFix::Check($TeamDuel::ArenaNum[1]!=$TeamDuel::ArenaNum[3],"concurrent matches own distinct slots");
   %count=ArenaFix::Count(MissionCleanup);
   ArenaFix::Check(TeamDuel::MakeArena("Battle_Cube",1,2) && ArenaFix::Count(MissionCleanup)==%count,"repeat setup reuses same match");
   TeamDuel::ClearArena(2);
   ArenaFix::Check(!isObject(%first) && isObject(%secondChild) && Group::objectCount(%second)==90,"ending either team preserves other match");
   ArenaFix::Check(TeamDuel::MakeArena("Battle_Cube",1,2),"released team slot rebuilds");
   ArenaFix::Check($TeamDuel::ArenaGroup[1].offsetIndex==%offset,"team world offset reused");
   TeamDuel::ClearArena(4); TeamDuel::ClearArena(1);
   ArenaFix::Check(ArenaFix::Count(MissionCleanup)==$arenaFix::baseline,"team instances fully released");

   for(%n=0;%n<9;%n++) ArenaFix::Check(TeamDuel::MakeArena("Battle_Cube",100+%n*2,101+%n*2),"team slot "@%n);
   %count=ArenaFix::Count(MissionCleanup);
   ArenaFix::Check(!TeamDuel::MakeArena("Battle_Cube",200,201) && ArenaFix::Count(MissionCleanup)==%count,"full arena rejects without allocating");
   for(%n=0;%n<9;%n++) TeamDuel::ClearArena(100+%n*2);
   ArenaFix::Check(ArenaFix::Count(MissionCleanup)==$arenaFix::baseline,"all nine matches release");

   for(%n=0;%n<35;%n++) {
      $arenaFix::reserved[%n]=DuelArena::Allocate("ArenaFix"@%n,"");
      ArenaFix::Check(isObject($arenaFix::reserved[%n]),"offset reservation "@%n);
   }
   ArenaFix::Check(!isObject(DuelArena::Allocate("ArenaFixOverflow","")),"world offset pool refuses overflow");
   for(%n=0;%n<35;%n++) DuelArena::Release($arenaFix::reserved[%n]);

   if(!isObject($BuildGroup)) { $BuildGroup=newObject("BuildGroup",SimGroup); addToSet(MissionCleanup,$BuildGroup); }
   %projectBaseline=ArenaFix::Count(MissionCleanup);
   %dm=$DeathMatch::ArenaGroup; %spawn=$DeathMatch::Spawn[0];
   ArenaFix::Check(DeathMatch::MakeArena("Arena_Madness","ArenaFixFixture"),"project import succeeds");
   ArenaFix::Check($DeathMatch::ArenaGroup==%dm && $DeathMatch::Spawn[0]==%spawn,"project import preserves DM ownership and spawns");
   %projectObjects=0;
   for(%n=0;%n<Group::objectCount($BuildGroup);%n++) {
      %o=Group::getObject($BuildGroup,%n);
      if(%o.project=="ArenaFixFixture") { %projectObjects++; %projectSample=%o; }
   }
   ArenaFix::Check(%projectObjects==98,"project objects remain directly in BuildGroup");
   DeathMatch::Stop(); DeathMatch::Start();
   ArenaFix::Check(isObject(%projectSample),"DM teardown preserves project objects");
   for(%n=Group::objectCount($BuildGroup)-1;%n>=0;%n--) {
      %o=Group::getObject($BuildGroup,%n);
      if(%o.project=="ArenaFixFixture") deleteObject(%o);
   }
   DeathMatch::Stop(); DeathMatch::Start();
   ArenaFix::Check(ArenaFix::Count(MissionCleanup)==%projectBaseline,"empty project reservation reclaimed");

   NexusInit(); %count=ArenaFix::Count(MissionCleanup); %nexus=$FlagHunter::Nexus[2];
   for(%n=0;%n<40;%n++) { deleteNexus(); NexusInit(); }
   ArenaFix::Check(ArenaFix::Count(MissionCleanup)==%count && $FlagHunter::Nexus[2]==%nexus,"Nexus reuse stays bounded");
   %group=DuelArena::Allocate("ArenaFixTimer","");
   $arenaFix::lateCallback=0;
   schedule("$arenaFix::lateCallback++;",1,%group);
   DuelArena::Release(%group);
   schedule("ArenaFix::Finish();",2);
}
function ArenaFix::Finish()
{
   ArenaFix::Check($arenaFix::lateCallback==0,"deleted arena cancels owned schedules");
   echo("[ARENAFIX-DONE] checks=",$arenaFix::checks," failures=",$arenaFix::failures," total=",ArenaFix::Count(MissionCleanup));
}
