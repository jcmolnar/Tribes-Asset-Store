$DTFData["3_Vehicle.dtf", 0] = "CloseQuarters";
$DTFData["3_Vehicle.dtf", 1] = "CloudySide";
$DTFData["3_Vehicle.dtf", 2] = "SunnySide_Arena";
$DTFData["5_CTF.dtf", 0] = "AreciboArena";
$DTFData["5_CTF.dtf", 1] = "TempleTussle";
$DTFData["8_Destroy.dtf", 0] = "ThunderArena";
$DTFData["Annihilator.dtf", 0] = "Lubb-Shack";
$DTFData["AntHill.dtf", 0] = "A Safe Warm Place";
$DTFData["BloodRunsCold.dtf", 0] = "TheArenaRunsCold";
$DTFData["BloodRunsCold.dtf", 1] = "TheArenaRunsCold2";
$DTFData["BloodyVengeance.dtf", 0] = "ArenaOverTheHill";
$DTFData["BloodyVengeance.dtf", 1] = "BF-Chaos";
$DTFData["BloodyVengeance.dtf", 10] = "TheCastleWithin";
$DTFData["BloodyVengeance.dtf", 11] = "WalledIn";
$DTFData["BloodyVengeance.dtf", 12] = "WalledUnder";
$DTFData["BloodyVengeance.dtf", 13] = "Warena";
$DTFData["BloodyVengeance.dtf", 14] = "Whacked";
$DTFData["BloodyVengeance.dtf", 2] = "BF-Dirt Nap";
$DTFData["BloodyVengeance.dtf", 3] = "BF-Fried Dust";
$DTFData["BloodyVengeance.dtf", 4] = "BF-MazedIn";
$DTFData["BloodyVengeance.dtf", 5] = "BF-Red Edge";
$DTFData["BloodyVengeance.dtf", 6] = "Gonrena";
$DTFData["BloodyVengeance.dtf", 7] = "HighArena";
$DTFData["BloodyVengeance.dtf", 8] = "InOrOut";
$DTFData["BloodyVengeance.dtf", 9] = "Maze-Arena";
$DTFData["Broadside.dtf", 0] = "ArenA-D";
$DTFData["Broadside.dtf", 1] = "ArenaInTheSky";
$DTFData["Broadside.dtf", 2] = "ArenaInTheTower";
$DTFData["Broadside.dtf", 3] = "Aurena";
$DTFData["Broadside.dtf", 4] = "BF-Discord";
$DTFData["Broadside.dtf", 5] = "BF-Neighbor";
$DTFData["Broadside.dtf", 6] = "BF-No camp Bside";
$DTFData["Broadside.dtf", 7] = "BlastsideArena";
$DTFData["Broadside.dtf", 8] = "Full_Force_Arena";
$DTFData["Broadside.dtf", 9] = "HotelArena";
$DTFData["Citadels.dtf", 0] = "Arena_Madness";
$DTFData["Citadels.dtf", 1] = "Damn_Arena";
$DTFData["Citadels.dtf", 2] = "IveHadWorse";
$DTFData["CrissCross.dtf", 0] = "Sunny_Side2";
$DTFData["DangerousCrossing.dtf", 0] = "Arena-DangerousCrossing";
$DTFData["DangerousCrossing.dtf", 1] = "The_Block";
$DTFData["DeathKnell.dtf", 0] = "Underground_Tunnel";
$DTFData["desert_of_death.dtf", 0] = "Intensity";
$DTFData["Fallen.dtf", 0] = "DesertRats";
$DTFData["fogofwar.dtf", 0] = "FreakyStyley";
$DTFData["kingunderthehill.dtf", 0] = "ArenaUnderTheHill";
$DTFData["kingunderthehill.dtf", 1] = "TheArenaDownUnder";
$DTFData["LuckySeven.dtf", 0] = "Smog-Arena";
$DTFData["NoQuarter.dtf", 0] = "NoQuarterArena";
$DTFData["NorthernLights.dtf", 0] = "ArenaUnderTheMountain";
$DTFData["PeakPerformance.dtf", 0] = "Amirs Desert";
$DTFData["Raindance.dtf", 0] = "BF-DeadCity";
$DTFData["Raindance.dtf", 1] = "TheForgottenCave";
$DTFData["Rollercoaster.dtf", 0] = "BF-CaX";
$DTFData["Rollercoaster.dtf", 1] = "BF-Clo";
$DTFData["Rollercoaster.dtf", 2] = "Catfight";
$DTFData["Rollercoaster.dtf", 3] = "Duelist";
$DTFData["Rollercoaster.dtf", 4] = "NewYorkerArena";
$DTFData["Rollercoaster.dtf", 5] = "The ArenA";
$DTFData["Rollercoaster.dtf", 6] = "Tombstone";
$DTFData["Sandstorm.dtf", 0] = "arena_hell";
$DTFData["Sandstorm.dtf", 1] = "BF-Air_Arena";
$DTFData["scarabrae.dtf", 0] = "CenterHill";
$DTFData["scarabrae.dtf", 1] = "Morena";
$DTFData["SeekAndDestroy.dtf", 0] = "BoxedIn";
$DTFData["SeekAndDestroy.dtf", 1] = "Freezing_Death";
$DTFData["SeekAndDestroy.dtf", 2] = "SnowBound";
$DTFData["Stonehenge.dtf", 0] = "Mono-Rail Arena";
$DTFData["Stonehenge.dtf", 1] = "No-Rail Arena";
$DTFData["templeofdoom.dtf", 0] = "Arena_01";
$DTFData["templeofdoom.dtf", 1] = "Arena_02";
$DTFData["templeofdoom.dtf", 2] = "Dune_Arena";
$DTFData["templeofdoom.dtf", 3] = "KingsArena";
$DTFData["templeofdoom.dtf", 4] = "LazArena";
$DTFData["templeofdoom.dtf", 5] = "UpOrDown";
$DTFData["towers.dtf", 0] = "OpiVille";
$DTFData["Turbulence.dtf", 0] = "GrassyKnollArena";

if($goldeneye)
{
//	GEINIT();
}

$ArenasMade = -1;
deleteVariables("$DuelArena::*");
deleteVariables("$TeamDuel::ArenaGroup*");
$DeathMatch::ArenaGroup = "";

$SpecialArena[Full_Force_Arena-D] = true;
$SpecialArena[Arena-D] = true;
$SpecialArena[Morena] = true;
$SpecialArena[Warena] = true;

$DM::Done[AreciboArena] = true;
$DM::Done[Arena_Madness] = true;
$DM::Done[ArenaInTheSky] = true;
$DM::Done[ArenaUnderTheHill] = true;
$DM::Done[UpsideDownAuth] = true;
$DM::Done[Battle_Cube] = true;
$DM::Done["A_Safe_Warm_Place"] = true;
$DM::Done["BF-DeadCity"] = true;
$DM::Done["BF-Neighbor"] = true;
$DM::Done[bm] = true;
$DM::Done[Morena] = true;
$DM::Done[NewYorkerArena] = true;
//$DM::Done[Rockslide] = true;
$DM::Done[WalledIn] = true;
$DM::Done[Batty] = true;
$DM::Done[woot] = true;
$DM::Done[Milks_Shaft] = true;
$DM::Done[Ravine] = true;
$DM::Done[Egyptian] = true;
$DM::Done[Temple] = true;
$DM::Done[Library] = true;
$DM::Done[Grid] = true;
$DM::Done[Caves] = true;
//$DM::Done[TemplePD] = true;
$DM::Done[Complex] = true;
$DM::Done[G5] = true;

%z = -1;
for(%x = 1000; %x < 7000; %x+=1000)
{
	for(%y = 1000; %y < 7000; %y+=1000)
	{
		$ArenaOffset[%z++] = %x@" "@%y@" 2000";
	}
}


$z = 0;
if($Map::Original) { $Arena[Map] = $z++; }
if($missionname == "Goldeneye & Perfect Dark")
{
	$Arena[Ravine] = $z++;
	$Arena[Complex] = $z++;
	$Arena[G5] = $z++;
	$Arena[Temple] = $z++;
	$Arena[Egyptian] = $z++;
	$Arena[Library] = $z++;
	$Arena[Grid] = $z++;
	$Arena[Caves] = $z++;
	//$Arena[TemplePD] = $z++;


}
$Arena[AreciboArena] = $z++;
$Arena[Arena_Madness] = $z++;
//$Arena[Arena-D] = $z++;
$Arena[ArenaInTheSky] = $z++;
$Arena[ArenaUnderTheHill] = $z++;
$Arena[UpsideDownAuth] = $z++;
$Arena[Batty] = $z++;
$Arena[Battle_Cube] = $z++;
//$Arena[A_Safe_Warm_Place] = $z++;
$Arena[BF-CaX] = $z++;
$Arena[BF-Clo] = $z++;
$Arena[BF-DeadCity] = $z++;
$Arena[BF-Discord] = $z++;
$Arena[BF-Neighbor] = $z++;
$Arena[bm] = $z++;
$Arena[Damn_Arena] = $z++;
$Arena[Full_Force_Arena] = $z++;
$Arena[HotelArena] = $z++;
$Arena[Morena] = $z++;
$Arena[Milks_Shaft] = $z++;
$Arena[Old_MilWaukee] = $z++;
$Arena[NewYorkerArena] = $z++;
$Arena[Rockslide] = $z++;
//$Arena[TempleTussle] = $z++;
$Arena[The_Arena] = $z++;
$Arena[Underground_Tunnel] = $z++;
$Arena[woot] = $z++;
//$Arena[Warena] = $z++;
//$Arena[Temple] = $z++;
//need neighbor derr
if($missionname == "BloodyVengeance")
{
	$Arena[BF-Chaos] = $z++;
	$Arena[BF-Fried_Dust] = $z++;
	$Arena[BF-Red_Edge] = $z++;
	$Arena[Gonrena] = $z++;
	$Arena[HighArena] = $z++;
	$Arena[InOrOut] = $z++;
	$Arena[Maze-Arena] = $z++;
	$Arena[WalledIn] = $z++;
}


$z = 0;
$Arena[-1] = "None";
if($Map::Original) { $Arena[$z++] = "Map"; }
if($missionname == "Goldeneye & Perfect Dark")
{
	$Arena[$z++] = "Ravine";
	$Arena[$z++] = "Complex";
	$Arena[$z++] = "G5";
	$Arena[$z++] = "Temple";
	$Arena[$z++] = "Egyptian";
	$Arena[$z++] = "Library";
	$Arena[$z++] = "Grid";
	$Arena[$z++] = "Caves";
	//$Arena[$z++] = "TemplePD";
}
$Arena[$z++] = "AreciboArena";
$Arena[$z++] = "Arena_Madness";
//$Arena[$z++] = "Arena-D";
$Arena[$z++] = "ArenaInTheSky";
$Arena[$z++] = "ArenaUnderTheHill";
$Arena[$z++] = "UpsideDownAuth";
$Arena[$z++] = "Battle_Cube";
$Arena[$z++] = "Batty";
//$Arena[$z++] = "A_Safe_Warm_Place";
$Arena[$z++] = "BF-CaX";
$Arena[$z++] = "BF-Clo";
$Arena[$z++] = "BF-DeadCity";
$Arena[$z++] = "BF-Discord";
$Arena[$z++] = "BF-Neighbor";
$Arena[$z++] = "bm";
$Arena[$z++] = "Damn_Arena";
$Arena[$z++] = "Full_Force_Arena";
$Arena[$z++] = "HotelArena";
$Arena[$z++] = "Morena";
$Arena[$z++] = "Milks_Shaft";
$Arena[$z++] = "Old_MilWaukee";
$Arena[$z++] = "NewYorkerArena";
$Arena[$z++] = "Rockslide";
//$Arena[$z++] = "TempleTussle";
$Arena[$z++] = "The_Arena";
$Arena[$z++] = "Underground_Tunnel";
$Arena[$z++] = "woot";
//$Arena[$z++] = "Warena";
//$Arena[$z++] = "Temple";
if($missionname == "BloodyVengeance")
{
	$Arena[$z++] = "BF-Chaos";
	$Arena[$z++] = "BF-Fried_Dust";
	$Arena[$z++] = "BF-Red_Edge";
	$Arena[$z++] = "Gonrena";
	$Arena[$z++] = "HighArena";
	$Arena[$z++] = "InOrOut";
	$Arena[$z++] = "Maze-Arena";
	$Arena[$z++] = "WalledIn";


	$ArenaOffset[0] = "0 0 1000";
	$ArenaOffset[1] = "0 2048 1000";
	$ArenaOffset[2] = "2048 0 1000";
	$ArenaOffset[3] = "-2048 -2048 1000";
	$ArenaOffset[4] = "0 -2048 1000";
	$ArenaOffset[5] = "-2048 0 1000";
	$ArenaOffset[6] = "2048 -2048 1000";
	$ArenaOffset[7] = "-2048 2048 1000";
	$ArenaOffset[8] = "2048 2048 1000";
}

$BVMapSet["BF-Chaos"] = true;
$BVMapSet["BF-Fried_Dust"] = true;
$BVMapSet["BF-Red_Edge"] = true;
$BVMapSet[Gonrena] = true;
$BVMapSet[HighArena] = true;
$BVMapSet[InOrOut] = true;
$BVMapSet["Maze-Arena"] = true;
$BVMapSet[WalledIn] = true;
$Arenas = $z+1;
deleteVariables("$ArenaIsMade*");
for(%x = 0; %x < $z+1; %x++)
{
	for(%y = 0; %y < $z+1; %y++)
	{
		$ArenaInUse[$Arena[%x],%y] = false;
	}
}
$RemoteInvList[TurretPack] = 0;
$InvList[MineAmmo] = 0;
$RemoteInvList[MineAmmo] = 1;
$AmmoPackMax[MineAmmo] = 0;
$AmmoPackItems[6] = Beacon;
$InvList[DeployableInvPack] = 0;
$InvList[DeployableAmmoPack] = 0;
$InvList[Mortar] = 0;
$InvList[MortarAmmo] = 0;
$InvList[HeavyArmor] = 0;
$RemoteInvList[Mortar] = 0;
$RemoteInvList[MortarAmmo] = 0;
$TeamItemCount[0,HeavyArmor] = 0;
$TeamItemCount[1,HeavyArmor] = 0;
$TeamItemCount[0,LaserRifle] = 0;
$TeamItemCount[1,LaserRifle] = 0;
$TeamItemMax[HeavyArmor] = 0;
$TeamItemMax[LaserRifle] = 2;

$loaded["TDArena.cs"] = true;





// Arena objects live only as long as their match. A project reservation is a
// non-owning set: project objects stay directly in BuildGroup for its menus.
function DuelArena::Allocate(%arena, %project)
{
   for(%i = 0; %i < 36; %i++)
   {
      %old = $DuelArena::OffsetOwner[%i];
      if(isObject(%old) && %old.projectArena && Group::objectCount(%old) == 0)
         DuelArena::Release(%old);
   }
   for(%slot = 1; %slot < 10; %slot++)
      if(!$ArenaInUse[%arena, %slot]) break;
   for(%index = 0; %index < 36; %index++)
      if(!isObject($DuelArena::OffsetOwner[%index])) break;
   if(%slot == 10 || %index == 36)
   {
      echo("[Duel] No free arena slot or world offset for ", %arena);
      // Object zero is the simulation manager, not an allocation failure.
      return -1;
   }
   if(%project != "") %group = newObject("", SimSet);
   else %group = newObject("", SimGroup);
   if(!isObject(%group)) return -1;
   addToSet(MissionCleanup, %group);
   %group.duelArena = true;
   %group.projectArena = (%project != "");
   %group.arenaName = %arena;
   %group.arenaSlot = %slot;
   %group.offsetIndex = %index;
   $DuelArena::OffsetOwner[%index] = %group;
   $ArenaInUse[%arena, %slot] = true;
   $ArenaIsMade[%arena, %slot] = true;
   $ArenasMade++;
   return %group;
}

function DuelArena::Release(%group)
{
   if(!isObject(%group) || !%group.duelArena) return;
   $ArenaInUse[%group.arenaName, %group.arenaSlot] = false;
   $ArenaIsMade[%group.arenaName, %group.arenaSlot] = false;
   if($DuelArena::OffsetOwner[%group.offsetIndex] == %group)
      $DuelArena::OffsetOwner[%group.offsetIndex] = "";
   if($DeathMatch::ArenaGroup == %group)
   {
      $DeathMatch::ArenaGroup = "";
      $DeathMatch::ArenaNum = "";
   }
   if(%group.team1 != "" && $TeamDuel::ArenaGroup[%group.team1] == %group)
   {
      $TeamDuel::ArenaGroup[%group.team1] = "";
      $TeamDuel::ArenaNum[%group.team1] = "";
   }
   if(%group.team2 != "" && $TeamDuel::ArenaGroup[%group.team2] == %group)
   {
      $TeamDuel::ArenaGroup[%group.team2] = "";
      $TeamDuel::ArenaNum[%group.team2] = "";
   }
   // SimGroup deletes its children; SimSet only releases project references.
   deleteObject(%group);
}

function TeamDuel::ClearArena(%team)
{
   DuelArena::Release($TeamDuel::ArenaGroup[%team]);
}

function TeamDuel::MakeArena(%arena, %t1, %t2)
{
   %existing = $TeamDuel::ArenaGroup[%t1];
   if(isObject(%existing) && %existing == $TeamDuel::ArenaGroup[%t2])
      return (%existing.arenaName == %arena);
   if(isObject(%existing) || isObject($TeamDuel::ArenaGroup[%t2])) return false;
   %group = DuelArena::Allocate(%arena, "");
   if(!isObject(%group)) return false;
   %group.team1 = %t1;
   %group.team2 = %t2;
   $TeamDuel::ArenaGroup[%t1] = %group;
   $TeamDuel::ArenaGroup[%t2] = %group;
   $TeamDuel::ArenaNum[%t1] = %group.arenaSlot;
   $TeamDuel::ArenaNum[%t2] = %group.arenaSlot;
   $Arena::ArenaNum = %group.arenaSlot;

   // Some tables only append with $z++; start each build with an empty table.
   $z = 0;
	exec("zz"@%arena@".cs");

	echo("*** Creating: "@%arena@": Arena slot: "@%group.arenaSlot@" *** Z:"@$z);//@"Building: "@ %x);

	%offset = $ArenaOffset[%group.offsetIndex];
	if($BVMapSet[%arena]&&$missionname=="BloodyVengeance")
	{
		$TeamDuel::MissionArea[%t1] = 270;
		$TeamDuel::MissionArea[%t2] = 270;
		%offset = vector::add("0 0 -1000", %offset);
	}
	if(%arena == "Rockslide")
	{
		%offset = "2048 2048 0";
	}
	echo(%offset@" "@%arena);
	deleteVariables("$TeamDuel::Spawn["@%t1@"*");
	deleteVariables("$TeamDuel::Spawn["@%t2@"*");


	for(%x = 0; (%x < 30) ; %x++)
	{
		$TeamDuel::Spawn[%t1, %x] = vector::add($TeamDuel::Spawn[X, %x+1], %offset) ;
		$TeamDuel::SpawnRot[%t1, %x] = $TeamDuel::SpawnRot[X, %x+1] ;
		$TeamDuel::Spawn[%t2, %x] = vector::add($TeamDuel::Spawn[O, %x+1], %offset) ;
		$TeamDuel::SpawnRot[%t2, %x] = $TeamDuel::SpawnRot[O, %x+1] ;

	}
	// Every match owns a fresh instance; there is no unbounded geometry cache.
	{
		ECHO("Starting spawn process..."@%offset);
		for(%a = 0; %a < $z+1; %a++)
		{

			if($objtype[%a] == "StaticShape" || $objtype[%a] == "Turret" || $objtype[%a] == "Sensor")
			{
				if($obj[%a] == "InventoryStation" && $TeamDuel::ArenaSpawn[%clientId.Team])
				{
					$obj[%a] = "AmmoStation";
				}
				%spawn = newObject($obj[%a],$objtype[%a],$obj[%a],false);
				addToSet(%group, %spawn);
				%pos = Getword($objpos[%a], 0)+Getword(%offset, 0)@" "@Getword($objpos[%a], 1)+Getword(%offset, 1)@" "@Getword($objpos[%a], 2)+Getword(%offset, 2) ;
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, $objrot[%a]);
				GameBase::setTeam(%spawn, $objTeam[%a]);
				GameBase::setActive(%spawn,14);
				GameBase::playSequence(%spawn,0,power);
			}
			if($objtype[%a] == "InteriorShape")
			{
				%spawn = newObject($obj[%a]@".dis",$objtype[%a],$obj[%a]@".dis",true);
				addToSet(%group, %spawn);
				%pos = Getword($objpos[%a], 0)+Getword(%offset, 0)@" "@Getword($objpos[%a], 1)+Getword(%offset, 1)@" "@Getword($objpos[%a], 2)+Getword(%offset, 2) ;
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, $objrot[%a]);

			}
			if($objtype[%a] == "Item")
			{
				%amount = "1";

				if($obj[%a] == "PlasmaAmmo")
				{
					%amount = "10";
				}
				if($obj[%a] == "BulletAmmo")
				{
					%amount = "30";
				}
				if($obj[%a] == "GrenadeAmmo" || $obj[%a] == "discammo" || $obj[%a] == "Grenade")
				{
					%amount = "5";
				}
				%spawn = newObject($obj[%a],"Item",$obj[%a],%amount,true,true,false);
				addToSet(%group, %spawn);
				%pos = Getword($objpos[%a], 0)+Getword(%offset, 0)@" "@Getword($objpos[%a], 1)+Getword(%offset, 1)@" "@Getword($objpos[%a], 2)+Getword(%offset, 2) ;
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, %rot);
			}
				%totalpos = Getword(%pos, 0)+Getword(%totalpos, 0)@" "@Getword(%pos, 1)+Getword(%totalpos, 1)@" "@Getword(%pos, 2)+Getword(%totalpos, 2) ;
		}
		%spawn.weld = true;
	}
	echo("...Spawn process complete");
	//$DeathMatch::Center =  Getword(%totalpos, 0)/$z@" "@  Getword(%totalpos, 1)/$z@" "@  Getword(%totalpos, 2)/$z ;
	deleteVariables("$DM::Spawn*");
	deleteVariables("$TeamDuel::Spawn[X*");
	deleteVariables("$TeamDuel::SpawnRot[X*");
	deleteVariables("$TeamDuel::Spawn[O*");
	deleteVariables("$TeamDuel::SpawnRot[O*");
	deletevariables("$obj*");
   return true;
}
