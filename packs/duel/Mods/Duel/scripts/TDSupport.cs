function fiftyy()
{
	if(getrandom() > getrandom())
		return true;
	else
		return false;
}
function fiftyTest()
{
	%true = 0;	%false = 0;	%counter = 1000001;
	while(%counter--)
	{
		if(fiftyy())
			%true++;
		else
			%false++;
	}
	//echo(%true@" to "@%false);
	if(%true > %false)
	return true;
	else
	return false;
}
function ftfw()
{
	%true = 0;	%false = 0;	%counter = 1000001;
	while(%counter--)
	{
		if(fiftyTest())
			%true++;
		else
			%false++;
	}
	echo(%true@" to "@%false);
}

function TeamDuel::TeamsNotInMatch()
{
	%count = 0;
	%lastfound = 0;
	%iter = 0;
	for(%x = 1; %x < (%lastfound+5); %x++)//scan 5 ahead incase gaps form
	{
		%iter++;
		if($Teamduel::Name[%x] != "" && $TeamDuel::InMatch[%x] != "True")
		{
			//echo("found a team: "@$Teamduel::Name[%x]);
			%count++;
			%lastfound = %x;
		}
	}
	//echo("Total: "@%count@" iters: "@%iter);
	return %count;
}

function DiscLauncherKing::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	if(!%client.isKing && !%client.cursed)
	{
		if(!Player::getItemCount(%client, "DiscAmmo"))
		{
			Player::SetItemCount(%client,"DiscAmmo", "75");
		}
		if(%client.score["KingKills"] > 2)
		{
			AssignKing(%client, "Mount");
		}
		else
		{
			client::sendmessage(%client, $red, "You must kill the current King "@(3 - %client.score["KingKills"])@" more times to use this.");
			KingCurse(%client, %player);
		}
	}
}
function remoteNESW(%cl)
{
	%clpos = gamebase::Getposition(%cl);

	%pl = Client::getOwnedObject(%cl);
	GameBase::getLOSinfo(%pl, 3000);
	%los = $los::position;
	resetlos();
	%xxx = GexxxtNESW(%clpos, %los);
	%reg = GetNESW(%clpos, %los);
	both("f1: "@%xxx);
	both("f2: "@%reg);
}

function GexxxtNESW(%pos1, %pos2)
{
	echo("GetNESW(" @ %pos1 @ ", " @ %pos2 @ ")");
//Vector::getRotation(Vector::sub(%pos1, %pos2));
	%v1 = Vector::sub(%pos1, %pos2);
	%v2 = Vector::getRotation(%v1);
	%a = GetWord(%v2, 2);

	if(%a >= 2.7475 && %a <= 3.15 || %a >= -3.15 && %a <= -2.7475)
		%d = "North";
	else if(%a >= 1.1775 && %a <= 1.9625)
		%d = "East";
	else if(%a >= -0.3925 && %a <= 0.3925)
		%d = "South";
	else if(%a >= -1.9625 && %a <= -1.1775)
		%d = "West";

	return %d;
}




function Handgrenade::onCollision(%this, %object)
{
	//both(%thrower@" nade collision this:"@getObjectType(%this)@": ["@GameBase::getDataName(%this)@"] that: "@getObjectType(%object)@": ["@GameBase::getDataName(%object)@"]");
	if(getObjectType(%object) == "Player" && !Player::isDead(%object))
	{
		%damagedClient = Player::getClient(%object);
		if(%this.owner != %damagedClient)// && NotTouching(%object, 5))
		{
			%playtype = GetPlayType(%this.owner);
			//echo(getSimTime()@" person hitting other person");
			if(!%this.collision[%object])
			{
				//echo("first collision");
				%this.collision[%object] = 0;
			}
			%this.collision[%object]++;
			if(%this.collision[%object] == "2")
			{
				%object.stuckhard = true;
			}
			if(%this.collision[%object] == "1")
			{
				%message = client::getname(%this.owner)@" hit "@client::getname(%damagedClient)@" directly with a hand grenade!" ;
				if(%this.owner.DM)
				{
					DeathMatch::Message($Green, %message);
				}
				else if(%this.owner.team != "" && %damagedClient.team != "")
				{
					TMessage(%this.owner.team, %damagedClient.team, $Green, %message, 1);
				}
				Score::IncreaseStat(%this.owner, "HandNadeHits", 1, %PlayType);
				Score::IncreaseStat(%damagedClient, "HandNadesCaught", 1, %PlayType);
				//echo(%message);
			}
			//echo(getSimTime()@" person hitting other person "@%this.collision[%object]);
		}
	}
	else if(GameBase::getDataName(%object) == "Handgrenade")
	{
		if(%this.owner != %object.owner && !%this.checked && !%object.checked)
		{
			%this.checked = true;
			%object.checked = true;
			if(NotTouching(%this, 2) && NotTouching(%object, 2))
			{
				messageall($Green, client::getname(%this.owner)@" and "@client::getname(%object.owner)@" collided hand grenades mid-air!");
			}
		}
	}
	//echo(%this@" <- this object -> "@%object@": "@client::getname(Player::getClient(%object))@" owner: "@%this.owner@": "@client::getname(%this.owner));
}
$CustomBlueCode = "Y";
$CustomGreenCode = "michY";
$CustomYellowCode = "*******";
$CustomPinkCode = "Y";
$CustomBlackCode = "Y";
$CustomPurpleCode = "ForMisterJack";

function remoteCustomDisc(%clientId, %color, %code)
{
	if(%code == $CustomBlueCode ||%code == $CustomGreenCode || %code == $CustomYellowCode || %code == $CustomPinkCode || %code == $CustomBlackCode || %code == $CustomPurpleCode)
	{
		%clientId.customweap = "DiscLauncher"@%color;
		echo("Code entered for: "@%color@" by "@client::getname(%clientId)@". weapon enabled: "@%clientId.customweap);
		client::sendmessage(%clientId, $Green, "Code successfully entered. weapon enabled: "@%clientId.customweap);
	}
}

$MapHasHoles["Duelmap4.1"] = true;
$MapHasHoles["ProvingGrounds"] = true;
$MapHasHoles["BloodyVengeance"] = true;
$MapHasHoles["Heights"] = true;
$MapHasHoles["Tranquility"] = true;//??

function remotePlugHoles()
{
	%group = nameToID("MissionGroup\\Objects");
	%count = Group::objectCount(%group);
	for(%i = 0; %i < %count; %i++)
	{
		%obj = Group::getObject(%group,%i);
		%name = object::getname(%obj);
		echo(%name);
		if(%name == "iblock1" || %name == "iblock" || %name == "Iblock" || %name == "Iblock1")
		{
			echo("iblock found... Cloning!");
			Plug::CloneBlock(%obj, "iblock.dis");
		}
		else if(%name == "observation" || %name == "observation1")
		{
			echo("observation found... Cloning!");
			Plug::CloneObject(%obj, "observation.dis");
		}
		echo("List :"@%i+1 @"-"@%numitems@" "@%name@" Project:"@%obj.project);
	}
}

function Plug::CloneObject(%obj, %name)
{
	%offset[0] = "0 0 0";
	%offset[1] = "0 2048 0";
	%offset[2] = "2048 0 0";
	%offset[3] = "-2048 -2048 0";
	%offset[4] = "0 -2048 0";
	%offset[5] = "-2048 0 0";
	%offset[6] = "2048 -2048 0";
	%offset[7] = "-2048 2048 0";
	%offset[8] = "2048 2048 0";

	%pos = gamebase::getposition(%obj);
	%rot = gamebase::getrotation(%obj);



	for(%a = 1; %a < 9; %a++)
	{
		%plug = SpawnIt(%name);
		gamebase::setposition(%plug, MyVector::Add(%pos, %offset[%a]));
		echo(%a@": "@gamebase::getposition(%plug));
	}
}

function Player::AssignCustomWeapon(%clientId)
{
	echo("assign custom.. "@%clientId.customweap);
	if(%clientId.isking)
	{
		Player::SetItemCount(%clientId,"DiscLauncherKing",1);
		Player::SetItemCount(%clientId,"KingHalo",1);
		Player::useItem(%clientId,"KingHalo");
	}
	else
	{
		Player::SetItemCount(%clientId,"DiscAmmo", 1);
		Player::SetItemCount(%clientId,%clientId.customweap, 1);
		Player::useItem(%clientId,%clientId.customweap);
	}
}
function Player::AssignLoadout(%clientId, %mines)
{
	if(%clientId.Armor == "") %clientId.Armor = "1";

	if (Client::getGender(%clientId) == "Female" && %clientId.armor != 3)
			%armor = $DuelRealFArmor[%clientId.armor];
		else
			%armor = $DuelRealArmor[%clientId.armor];

	Player::SetArmor(%clientId, %armor);

    if (!%clientId.weapon[0])
		%clientId.weapon[0] = 3;
    if (!%clientId.weapon[1])
		%clientId.weapon[1] = 2;
    if (!%clientId.weapon[2])
		%clientId.weapon[2] = 4;
    if (!%clientId.weapon[3])
		%clientId.weapon[3] = 1;
    if (!%clientId.weapon[4])
		%clientId.weapon[4] = 8;
	if (%clientId.pack == "") %clientId.pack = 1;

	%pack = $DuelRealPack[%clientId.pack];
    Player::SetItemCount(%clientId, %pack, 1);
  	Player::UseItem(%clientId, %pack);
	for (%i = 0; %i < 2+%clientId.armor; %i++)
	{
    	%weapon = %clientId.weapon[%i];
       	%weaponAmmo = $DuelWeaponAmmo[%weapon];
       	%realweapon = $DuelRealWeapon[%weapon];
       //	both("w: "@%weapon@" a: "@%weaponammo@" realw: "@%realweapon);

		if(%realweapon == "LaserRifle" && %clientId.DM)
		{
			schedule("addlaser("@%clientId@");",10);
		}
		else
		{
			if(%realweapon == "DiscLauncher" && %clientId.isKing  || %realweapon == "DiscLauncher" && %clientId.customweap != "")
			{
				Player::AssignCustomWeapon(%clientId);
			}
			else
			{
				Player::SetItemCount(%clientId,%realweapon,1);
				//client::sendmessage(%clientID, $green, "King status not given!  "@%realweapon);
			}
		}
       	if (%weaponAmmo != "")
       	{
			if(%pack == "ammopack")
			{
				//echo($AmmoPackMax[%weaponAmmo]@" "@$ItemMax[%armor, %weaponAmmo]);
				%ammoAmount = ($AmmoPackMax[%weaponAmmo] + $ItemMax[%armor, %weaponAmmo]) ;
				Player::SetItemCount(%clientId,%weaponAmmo, %ammoAmount);
			}
			else
			{
				Player::SetItemCount(%clientId,%weaponAmmo, $ItemMax[%armor, %weaponAmmo]);
			}

       	}
       //	echo("KK "@%realweapon);
       	if(%realweapon == "DiscLauncher")
		{
			//BONUS AMMO
			//Player::SetItemCount(%clientId,%weaponAmmo, $ItemMax[%armor, %weaponAmmo]*5);
		}
    }
   // echo("KK "@%realweapon); echo("KK "@%realweapon); echo("KK "@%realweapon); echo("KK "@%realweapon); echo("KK "@%realweapon); echo("KK "@%realweapon);
	if(%pack == "ammopack")
	{
		Player::SetItemCount(%clientId, Grenade, ($AmmoPackMax[Grenade] + $ItemMax[%armor, Grenade]));
		Player::SetItemCount(%clientId, Beacon, ($AmmoPackMax[Beacon] + $ItemMax[%armor, Beacon]));
		if(%mines)
			Player::SetItemCount(%clientId, MineAmmo, ($AmmoPackMax[MineAmmo] + $ItemMax[%armor, MineAmmo]));
	}
	else {
		Player::SetItemCount(%clientId, Grenade, $ItemMax[%armor, Grenade]);
		Player::SetItemCount(%clientId, Beacon, $ItemMax[%armor, Beacon]);

		if(%mines)
		{
			Player::SetItemCount(%clientId, MineAmmo, $ItemMax[%armor, MineAmmo]);
		}
	}

	if(%clientId.isKing || %clientId.customweap != "")
	{
		Player::useItem(%clientId,%clientId.customweap);
	}
	else
	{
		//echo($DuelRealWeapon[%clientId.weapon[0]]);
		Player::UseItem(%clientId, $DuelRealWeapon[%clientId.weapon[0]]);
	}
	Player::SetItemCount(%clientId, RepairKit,1);
	Player::SetItemCount(%clientId, TargetingLaser,1);
}
function remotedick(%cl)
{
	Player::useItem(%cl,%cl.customweap);
}
function remoteMenuSelect(%clientId, %code)
{
//	echo("Code: "@%code);
   %mm = %clientId.menuMode;
   if(%mm == "")
      return;
   if(String::findSubStr(%code, "\"") != -1 ||
      String::findSubStr(%code, "\\") != -1)  // no quotes or escapes
      return;

   %evalString = "processMenu" @ %mm @ "(" @ %clientId @ ", \"" @ %code @ "\");";
   %clientId.menuMode = "";
   %clientId.menuLock = "";
  // echo(2, "MENU: " @ %clientId @ "- " @ %evalString);
   eval(%evalString);
   if(%clientId.menuMode == "")
   {
      Client::setMenuScoreVis(%clientId, false);
      %clientId.selClient = "";
   }
}

function MakeLight(%Pos)
{ // goes map name, type of obj, <light color>, <range>, <bool>
%obj = NewObject("PointLight", "SimLight", "Point", 1000, 0, 1, 0, 1, 0, 1);
AddToSet("MissionCleanup", %obj);
GameBase::setPosition(%obj, %pos);
echo("PointLight: "@%obj@" Created at "@%pos);
}

function DuelSpawn(%clientId) {
	Score::ResetRoundStats(%clientId);
	if($DuelSpawnMarker[%clientId] == -1) {
		%spawnPos = "0 0 300";
	    %spawnRot = "0 0 0";
	} else {
		//%spawnPos = gamebase::getposition($DuelSpawnMarker[%clientId]);
	    //%spawnRot = GameBase::getRotation($DuelSpawnMarker[%clientId]);
		%spawnPos = $Duel::SpawnMarkerPos[$DuelSpawnMarker[%clientId], %clientId.Dex];
		//ECHO("spawn stuff: "@$Duel::SpawnMarkerPos[$DuelSpawnMarker[%clientId], %clientId.Dex]@" "@$Duel::SpawnMarkerRot[$DuelSpawnMarker[%clientId], %clientId.Dex]);
	   // %spawnRot = GameBase::getRotation($DuelSpawnMarker[%clientId]);
		%spawnRot =  $Duel::SpawnMarkerRot[$DuelSpawnMarker[%clientId], %clientId.Dex];
		echo("Client: "@%clientId@": Name: "@client::getname(%clientId)@"Marker: "@$DuelSpawnMarker[%clientId]@" Dex: "@%clientId.dex);



	}
	%armor = "larmor";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	%pl.owner = %clientId;

	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl);


	ECHO("Real Spawn stuff: "@%spawnpos@" rot:"@%spawnrot@" PL: "@%pl);

	GameBase::SetTeam(%pl, $numz);
	GameBase::SetTeam(%clientId, $numz);




	Player::AssignLoadout(%clientId, true);

		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	//Client::setSkin(%pl, $Client::info[%clientId, 0]);


   resetlos();
  // gamebase::setposition(%clientId,%spawnPos);
  	gamebase::setposition(%clientId, vector::add(%spawnPos, "0 0 15"));
  	GameBase::getLOSInfo(%pl, 1000, "1.57 0 0");
   	GameBase::getLOSInfo(%pl, 1000, "-1.57 0 0");
   	gamebase::setposition(%clientId, MyVector::Add(%spawnPos, "0 0 15"));
  // 	both($los::position@" "@$los::object);
   	if($los::position != "")
   	{
		//both("worked");
   		gamebase::setposition(%clientId, $los::position);
	}
	//resetlos();
	%clientId.owns = %pl;
	return %pl;
}
function remotebmp(%client, %n)
{
	%x = 0;
	$bmp[%x] = "base.emblem1.bmp";
	$bmp[%x++] = "base.emblem10.bmp";
	$bmp[%x++] = "base.emblem11.bmp";
	$bmp[%x++] = "base.emblem2.bmp";
	$bmp[%x++] = "base.emblem3.bmp";
	$bmp[%x++] = "base.emblem4.bmp";
	$bmp[%x++] = "base.emblem5.bmp";
	$bmp[%x++] = "base.emblem6.bmp";
	$bmp[%x++] = "base.emblem7.bmp";
	$bmp[%x++] = "base.emblem8.bmp";
	$bmp[%x++] = "base.emblem9.bmp";
	$bmp[%x++] = "base_cold.bmp";
	$bmp[%x++] = "base_copper.bmp";
	$bmp[%x++] = "base_dark.bmp";
	$bmp[%x++] = "base_gold.bmp";
	$bmp[%x++] = "base_marble.bmp";
	$bmp[%x++] = "base_metal.bmp";
	$bmp[%x++] = "base_rock.bmp";
	$bmp[%x++] = "base_steel.bmp";
	$bmp[%x++] = "base_warm.bmp";
	$bmp[%x++] = "base_wood.bmp";
	$bmp[%x++] = "beagle.emblem1.bmp";
	$bmp[%x++] = "beagle.emblem10.bmp";
	$bmp[%x++] = "beagle.emblem11.bmp";
	$bmp[%x++] = "beagle.emblem2.bmp";
	$bmp[%x++] = "beagle.emblem3.bmp";
	$bmp[%x++] = "beagle.emblem4.bmp";
	$bmp[%x++] = "beagle.emblem5.bmp";
	$bmp[%x++] = "beagle.emblem6.bmp";
	$bmp[%x++] = "beagle.emblem8.bmp";
	$bmp[%x++] = "beagle.emblem9.bmp";
	$bmp[%x++] = "blue.emblem1.bmp";
	$bmp[%x++] = "blue.emblem10.bmp";
	$bmp[%x++] = "blue.emblem11.bmp";
	$bmp[%x++] = "blue.emblem2.bmp";
	$bmp[%x++] = "blue.emblem3.bmp";
	$bmp[%x++] = "blue.emblem4.bmp";
	$bmp[%x++] = "blue.emblem5.bmp";
	$bmp[%x++] = "blue.emblem6.bmp";
	$bmp[%x++] = "blue.emblem7.bmp";
	$bmp[%x++] = "blue.emblem8.bmp";
	$bmp[%x++] = "blue.emblem9.bmp";
	$bmp[%x++] = "carpet_base.bmp";
	$bmp[%x++] = "carpet_bend.bmp";
	$bmp[%x++] = "carpet_cap.bmp";
	$bmp[%x++] = "carpet_strait.bmp";
	$bmp[%x++] = "carpet_tee.bmp";
	$bmp[%x++] = "cold_16b.bmp";
	$bmp[%x++] = "cold_32b.bmp";
	$bmp[%x++] = "cold_64b.bmp";
	$bmp[%x++] = "cold_ft.bmp";
	$bmp[%x++] = "cold_wt.bmp";
	$bmp[%x++] = "copper_32b.bmp";
	$bmp[%x++] = "cphoenix.emblem1.bmp";
	$bmp[%x++] = "cphoenix.emblem10.bmp";
	$bmp[%x++] = "cphoenix.emblem11.bmp";
	$bmp[%x++] = "cphoenix.emblem2.bmp";
	$bmp[%x++] = "cphoenix.emblem3.bmp";
	$bmp[%x++] = "cphoenix.emblem4.bmp";
	$bmp[%x++] = "cphoenix.emblem5.bmp";
	$bmp[%x++] = "cphoenix.emblem6.bmp";
	$bmp[%x++] = "cphoenix.emblem8.bmp";
	$bmp[%x++] = "cphoenix.emblem9.bmp";
	$bmp[%x++] = "dark_16b.bmp";
	$bmp[%x++] = "dark_32b.bmp";
	$bmp[%x++] = "dark_64b.bmp";
	$bmp[%x++] = "dark_ft.bmp";
	$bmp[%x++] = "dark_wt.bmp";
	$bmp[%x++] = "display_cammera.bmp";
	$bmp[%x++] = "display_comm.bmp";
	$bmp[%x++] = "display_command.bmp";
	$bmp[%x++] = "display_defense.bmp";
	$bmp[%x++] = "display_power.bmp";
	$bmp[%x++] = "display_status.bmp";
	$bmp[%x++] = "display_weapons.bmp";
	$bmp[%x++] = "dropeagle1.bmp";
	$bmp[%x++] = "dropeagle2.bmp";
	$bmp[%x++] = "dropeagle3.bmp";
	$bmp[%x++] = "dropeagle4.bmp";
	$bmp[%x++] = "dropeagle5.bmp";
	$bmp[%x++] = "dropeagle6.bmp";
	$bmp[%x++] = "dropeagle7.bmp";
	$bmp[%x++] = "droppheonix1.bmp";
	$bmp[%x++] = "droppheonix2.bmp";
	$bmp[%x++] = "droppheonix3.bmp";
	$bmp[%x++] = "droppheonix4.bmp";
	$bmp[%x++] = "droppheonix5.bmp";
	$bmp[%x++] = "droppheonix6.bmp";
	$bmp[%x++] = "dropwolf1.bmp";
	$bmp[%x++] = "dropwolf2.bmp";
	$bmp[%x++] = "dropwolf3.bmp";
	$bmp[%x++] = "dropwolf4.bmp";
	$bmp[%x++] = "dropwolf5.bmp";
	$bmp[%x++] = "dropwolf6.bmp";
	$bmp[%x++] = "dsply_had.bmp";
	$bmp[%x++] = "dsply_hbd.bmp";
	$bmp[%x++] = "dsply_sad.bmp";
	$bmp[%x++] = "dsply_sbd.bmp";
	$bmp[%x++] = "dsply_vad.bmp";
	$bmp[%x++] = "dsply_vbd.bmp";
	$bmp[%x++] = "dsword.emblem1.bmp";
	$bmp[%x++] = "dsword.emblem10.bmp";
	$bmp[%x++] = "dsword.emblem11.bmp";
	$bmp[%x++] = "dsword.emblem2.bmp";
	$bmp[%x++] = "dsword.emblem3.bmp";
	$bmp[%x++] = "dsword.emblem4.bmp";
	$bmp[%x++] = "dsword.emblem5.bmp";
	$bmp[%x++] = "dsword.emblem6.bmp";
	$bmp[%x++] = "dsword.emblem8.bmp";
	$bmp[%x++] = "dsword.emblem9.bmp";
	$bmp[%x++] = "ds_ablative.bmp";
	$bmp[%x++] = "ds_bottom.bmp";
	$bmp[%x++] = "ext_grey.bmp";
	$bmp[%x++] = "ext_grey10.bmp";
	$bmp[%x++] = "ext_grey2.bmp";
	$bmp[%x++] = "ext_grey3.bmp";
	$bmp[%x++] = "ext_grey4.bmp";
	$bmp[%x++] = "ext_grey5.bmp";
	$bmp[%x++] = "ext_grey6.bmp";
	$bmp[%x++] = "ext_grey7.bmp";
	$bmp[%x++] = "ext_grey8.bmp";
	$bmp[%x++] = "ext_grey9.bmp";
	$bmp[%x++] = "ext_iron.bmp";
	$bmp[%x++] = "ext_iron2.bmp";
	$bmp[%x++] = "ext_iron3.bmp";
	$bmp[%x++] = "ext_iron5.bmp";
	$bmp[%x++] = "ext_iron6.bmp";
	$bmp[%x++] = "ext_iron7.bmp";
	$bmp[%x++] = "ext_iron8.bmp";
	$bmp[%x++] = "ext_marble2.bmp";
	$bmp[%x++] = "ext_marble4.bmp";
	$bmp[%x++] = "ext_silver.bmp";
	$bmp[%x++] = "ext_special1.bmp";
	$bmp[%x++] = "ext_stone.bmp";
	$bmp[%x++] = "ext_stone2.bmp";
	$bmp[%x++] = "ext_stone3.bmp";
	$bmp[%x++] = "ext_stone4.bmp";
	$bmp[%x++] = "ext_stone5.bmp";
	$bmp[%x++] = "ext_stone6.bmp";
	$bmp[%x++] = "ext_stone7.bmp";
	$bmp[%x++] = "ext_stone8.bmp";
	$bmp[%x++] = "gold_32b.bmp";
	$bmp[%x++] = "gold_64b.bmp";
	$bmp[%x++] = "green.emblem1.bmp";
	$bmp[%x++] = "green.emblem10.bmp";
	$bmp[%x++] = "green.emblem11.bmp";
	$bmp[%x++] = "green.emblem2.bmp";
	$bmp[%x++] = "green.emblem3.bmp";
	$bmp[%x++] = "green.emblem4.bmp";
	$bmp[%x++] = "green.emblem5.bmp";
	$bmp[%x++] = "green.emblem6.bmp";
	$bmp[%x++] = "green.emblem7.bmp";
	$bmp[%x++] = "green.emblem8.bmp";
	$bmp[%x++] = "green.emblem9.bmp";
	$bmp[%x++] = "greyrib.bmp";
	$bmp[%x++] = "hdisplay_blue.bmp";
	$bmp[%x++] = "hdisplay_vertical.bmp";
	$bmp[%x++] = "hdisplay_yellow.bmp";
	$bmp[%x++] = "icaution.bmp";
	$bmp[%x++] = "icoil.bmp";
	$bmp[%x++] = "icoilcage.bmp";
	$bmp[%x++] = "iconcretebock.bmp";
	$bmp[%x++] = "iconcretebock1.bmp";
	$bmp[%x++] = "idkmetal.bmp";
	$bmp[%x++] = "idkmetalstrip.bmp";
	$bmp[%x++] = "idkvent.bmp";
	$bmp[%x++] = "idkwindow1.bmp";
	$bmp[%x++] = "idkwindow2.bmp";
	$bmp[%x++] = "idoor1.bmp";
	$bmp[%x++] = "idoorframe.bmp";
	$bmp[%x++] = "igrate.bmp";
	$bmp[%x++] = "ilogo1.bmp";
	$bmp[%x++] = "iltconcrete.bmp";
	$bmp[%x++] = "iltmetal.bmp";
	$bmp[%x++] = "iltmetalstrip.bmp";
	$bmp[%x++] = "iltvent.bmp";
	$bmp[%x++] = "iltwindow1.bmp";
	$bmp[%x++] = "imp_wall1.bmp";
	$bmp[%x++] = "imp_wall2.bmp";
	$bmp[%x++] = "imp_wall2_half.bmp";
	$bmp[%x++] = "imp_wall2_mold.bmp";
	$bmp[%x++] = "int_phoenix1.bmp";
	$bmp[%x++] = "irdconcrete.bmp";
	$bmp[%x++] = "irdedge1.bmp";
	$bmp[%x++] = "irdmetal.bmp";
	$bmp[%x++] = "itext1.bmp";
	$bmp[%x++] = "itube.bmp";
	$bmp[%x++] = "ivent.bmp";
	$bmp[%x++] = "iyplate.bmp";
	$bmp[%x++] = "light_cold.bmp";
	$bmp[%x++] = "light_copper.bmp";
	$bmp[%x++] = "light_dark.bmp";
	$bmp[%x++] = "light_metal.bmp";
	$bmp[%x++] = "light_warm.bmp";
	$bmp[%x++] = "marble_32b.bmp";
	$bmp[%x++] = "marble_64b.bmp";
	$bmp[%x++] = "marble_wt.bmp";
	$bmp[%x++] = "metal_16b.bmp";
	$bmp[%x++] = "metal_32b.bmp";
	$bmp[%x++] = "metal_64b.bmp";
	$bmp[%x++] = "metal_ft.bmp";
	$bmp[%x++] = "metal_wt.bmp";
	$bmp[%x++] = "orange.emblem1.bmp";
	$bmp[%x++] = "orange.emblem10.bmp";
	$bmp[%x++] = "orange.emblem11.bmp";
	$bmp[%x++] = "orange.emblem2.bmp";
	$bmp[%x++] = "orange.emblem3.bmp";
	$bmp[%x++] = "orange.emblem4.bmp";
	$bmp[%x++] = "orange.emblem5.bmp";
	$bmp[%x++] = "orange.emblem6.bmp";
	$bmp[%x++] = "orange.emblem7.bmp";
	$bmp[%x++] = "orange.emblem8.bmp";
	$bmp[%x++] = "orange.emblem9.bmp";
	$bmp[%x++] = "panel1_vertical_broke1.bmp";
	$bmp[%x++] = "panel1_vertical_broke2.bmp";
	$bmp[%x++] = "panel_square_broke.bmp";
	$bmp[%x++] = "plainemb10.bmp";
	$bmp[%x++] = "plainemb11.bmp";
	$bmp[%x++] = "plainemb6.bmp";
	$bmp[%x++] = "plainemb8.bmp";
	$bmp[%x++] = "plainemb9.bmp";
	$bmp[%x++] = "purple.emblem1.bmp";
	$bmp[%x++] = "purple.emblem10.bmp";
	$bmp[%x++] = "purple.emblem11.bmp";
	$bmp[%x++] = "purple.emblem2.bmp";
	$bmp[%x++] = "purple.emblem3.bmp";
	$bmp[%x++] = "purple.emblem4.bmp";
	$bmp[%x++] = "purple.emblem5.bmp";
	$bmp[%x++] = "purple.emblem6.bmp";
	$bmp[%x++] = "purple.emblem7.bmp";
	$bmp[%x++] = "purple.emblem8.bmp";
	$bmp[%x++] = "purple.emblem9.bmp";
	$bmp[%x++] = "redgrate.bmp";
	$bmp[%x++] = "redrib.bmp";
	$bmp[%x++] = "redvent.bmp";
	$bmp[%x++] = "redylight.bmp";
	$bmp[%x++] = "rock_ft.bmp";
	$bmp[%x++] = "rock_wt.bmp";
	$bmp[%x++] = "rokwall1.bmp";
	$bmp[%x++] = "rokwall2.bmp";
	$bmp[%x++] = "rokwall3.bmp";
	$bmp[%x++] = "special_carpet.bmp";
	$bmp[%x++] = "special_interface.bmp";
	$bmp[%x++] = "special_metal.bmp";
	$bmp[%x++] = "special_shield.bmp";
	$bmp[%x++] = "special_warm.bmp";
	$bmp[%x++] = "steel_16b.bmp";
	$bmp[%x++] = "swolf.emblem1.bmp";
	$bmp[%x++] = "swolf.emblem10.bmp";
	$bmp[%x++] = "swolf.emblem11.bmp";
	$bmp[%x++] = "swolf.emblem2.bmp";
	$bmp[%x++] = "swolf.emblem3.bmp";
	$bmp[%x++] = "swolf.emblem4.bmp";
	$bmp[%x++] = "swolf.emblem5.bmp";
	$bmp[%x++] = "swolf.emblem6.bmp";
	$bmp[%x++] = "swolf.emblem8.bmp";
	$bmp[%x++] = "swolf.emblem9.bmp";
	$bmp[%x++] = "sworddrop1.bmp";
	$bmp[%x++] = "sworddrop2.bmp";
	$bmp[%x++] = "sworddrop3.bmp";
	$bmp[%x++] = "sworddrop4.bmp";
	$bmp[%x++] = "sworddrop5.bmp";
	$bmp[%x++] = "warm_16b.bmp";
	$bmp[%x++] = "warm_32b.bmp";
	$bmp[%x++] = "warm_ft.bmp";
	$bmp[%x++] = "warm_wt.bmp";
	$bmp[%x++] = "wolf_shipFfinal.bmp";
	bottomprint(%client, "<L80>"@$bmp[%n]@":"@%n@"<B"@$bmp[%n]@">", 10);
	//echo($bmp[%n]@": "@%n);
}



function dts(%num)
{
	%x = 0;
	$thing[%x] = "ammo1";
	$thing[%x++] = "ammo2";
	$thing[%x++] = "ammopack";
	$thing[%x++] = "ammopad";
	$thing[%x++] = "ammounit";
	$thing[%x++] = "ammounit_remote";
	$thing[%x++] = "anten_lava";
	$thing[%x++] = "anten_lrg";
	$thing[%x++] = "anten_med";
	$thing[%x++] = "anten_rod";
	$thing[%x++] = "anten_small";
	$thing[%x++] = "armorkit";
	$thing[%x++] = "armorpack";
	$thing[%x++] = "armorpatch";
	$thing[%x++] = "bigtwig";
	$thing[%x++] = "bluex";
	$thing[%x++] = "breath";
	$thing[%x++] = "bridge";
	$thing[%x++] = "bullet";
	$thing[%x++] = "cactus1";
	$thing[%x++] = "cactus2";
	$thing[%x++] = "cactus3";
	$thing[%x++] = "camera";
	$thing[%x++] = "chaingun";
	$thing[%x++] = "chainspk";
	$thing[%x++] = "chainturret";
	$thing[%x++] = "cmdpnl";
	$thing[%x++] = "command";
	$thing[%x++] = "dirarrows";
	$thing[%x++] = "disc";
	$thing[%x++] = "discammo";
	$thing[%x++] = "discb";
	$thing[%x++] = "display_one";
	$thing[%x++] = "display_three";
	$thing[%x++] = "display_two";
	$thing[%x++] = "door_4x4_diagonal";
	$thing[%x++] = "door_8x8_l";
	$thing[%x++] = "door_8x8_r";
	$thing[%x++] = "door_bot";
	$thing[%x++] = "door_top";
	$thing[%x++] = "dsply_h1";
	$thing[%x++] = "dsply_h2";
	$thing[%x++] = "dsply_s1";
	$thing[%x++] = "dsply_s2";
	$thing[%x++] = "dsply_v1";
	$thing[%x++] = "dsply_v2";
	$thing[%x++] = "dustplume";
	$thing[%x++] = "elevatbg";
	$thing[%x++] = "elevator16x16_octo";
	$thing[%x++] = "elevator6X4";
	$thing[%x++] = "elevator6X4thin";
	$thing[%x++] = "elevator6X6thin";
	$thing[%x++] = "elevator_4x4";
	$thing[%x++] = "elevator_4x5";
	$thing[%x++] = "elevator_5x5";
	$thing[%x++] = "elevator_6x5";
	$thing[%x++] = "elevator_6x6";
	$thing[%x++] = "elevator_6x6_octagon";
	$thing[%x++] = "elevator_8x4";
	$thing[%x++] = "elevator_8x6";
	$thing[%x++] = "elevator_8x8";
	$thing[%x++] = "elevator_9x9";
	$thing[%x++] = "elevpad2";
	$thing[%x++] = "elevpad3";
	$thing[%x++] = "enbolt";
	$thing[%x++] = "endarrow";
	$thing[%x++] = "energygun";
	$thing[%x++] = "enerpad";
	$thing[%x++] = "enex";
	$thing[%x++] = "fiery";
	$thing[%x++] = "flag";
	$thing[%x++] = "flagstand";
	$thing[%x++] = "flash_large";
	$thing[%x++] = "flash_medium";
	$thing[%x++] = "flash_small";
	$thing[%x++] = "flyer";
	$thing[%x++] = "force";
	$thing[%x++] = "forcefield";
	$thing[%x++] = "forcefield_3x4";
	$thing[%x++] = "forcefield_4x14";
	$thing[%x++] = "forcefield_4x17";
	$thing[%x++] = "forcefield_4x8";
	$thing[%x++] = "forcefield_5x5";
	$thing[%x++] = "fusionbolt";
	$thing[%x++] = "fusionex";
	$thing[%x++] = "generator";
	$thing[%x++] = "generator_p";
	$thing[%x++] = "grenade";
	$thing[%x++] = "grenadel";
	$thing[%x++] = "grenadetrail";
	$thing[%x++] = "grenammo";
	$thing[%x++] = "gunturet";
	$thing[%x++] = "harmor";
	$thing[%x++] = "hellfiregun";
	$thing[%x++] = "hflame";
	$thing[%x++] = "hover_apc";
	$thing[%x++] = "hover_apc_sml";
	$thing[%x++] = "indoorgun";
	$thing[%x++] = "inventory_sta";
	$thing[%x++] = "invent_remote";
	$thing[%x++] = "jetpack";
	$thing[%x++] = "larmor";
	$thing[%x++] = "laserhit";
	$thing[%x++] = "lfemale";
	$thing[%x++] = "lflame";
	$thing[%x++] = "liqcyl";
	$thing[%x++] = "logo";
	$thing[%x++] = "magcargo";
	$thing[%x++] = "mainpad";
	$thing[%x++] = "marmor";
	$thing[%x++] = "mfemale";
	$thing[%x++] = "mflame";
	$thing[%x++] = "microex";
	$thing[%x++] = "mine";
	$thing[%x++] = "mineammo";
	$thing[%x++] = "missileturret";
	$thing[%x++] = "mortar";
	$thing[%x++] = "mortarammo";
	$thing[%x++] = "mortarex";
	$thing[%x++] = "mortargun";
	$thing[%x++] = "mortarpack";
	$thing[%x++] = "mortartrail";
	$thing[%x++] = "mortar_turret";
	$thing[%x++] = "mrtwig";
	$thing[%x++] = "newdoor1_l";
	$thing[%x++] = "newdoor1_r";
	$thing[%x++] = "newdoor2_l";
	$thing[%x++] = "newdoor2_r";
	$thing[%x++] = "newdoor3_l";
	$thing[%x++] = "newdoor3_r";
	$thing[%x++] = "newdoor4_l";
	$thing[%x++] = "newdoor4_r";
	$thing[%x++] = "newdoor5";
	$thing[%x++] = "newdoor6_l";
	$thing[%x++] = "newdoor6_r";
	$thing[%x++] = "paint";
	$thing[%x++] = "paintgun";
	$thing[%x++] = "panel_blue";
	$thing[%x++] = "panel_set";
	$thing[%x++] = "panel_vertical";
	$thing[%x++] = "panel_yellow";
	$thing[%x++] = "plant1";
	$thing[%x++] = "plant2";
	$thing[%x++] = "plasammo";
	$thing[%x++] = "plasma";
	$thing[%x++] = "plasmabolt";
	$thing[%x++] = "plasmaex";
	$thing[%x++] = "plasmatrail";
	$thing[%x++] = "plasmawall";
	$thing[%x++] = "plastrail";
	$thing[%x++] = "pulse";
	$thing[%x++] = "radar";
	$thing[%x++] = "radar_small";
	$thing[%x++] = "remoteturret";
	$thing[%x++] = "repairgun";
	$thing[%x++] = "rocket";
	$thing[%x++] = "rsmoke";
	$thing[%x++] = "sat_big";
	$thing[%x++] = "sensorjampack";
	$thing[%x++] = "sensor_jammer";
	$thing[%x++] = "sensor_pulse_med";
	$thing[%x++] = "sensor_small";
	$thing[%x++] = "shield";
	$thing[%x++] = "shieldpack";
	$thing[%x++] = "shield_large";
	$thing[%x++] = "shield_medium";
	$thing[%x++] = "shockwave";
	$thing[%x++] = "shockwave_large";
	$thing[%x++] = "shotgun";
	$thing[%x++] = "shotgunbolt";
	$thing[%x++] = "shotgunex";
	$thing[%x++] = "shotsprk";
	$thing[%x++] = "smoke";
	$thing[%x++] = "sniper";
	$thing[%x++] = "snowplume";
	$thing[%x++] = "solar";
	$thing[%x++] = "solar_med";
	$thing[%x++] = "staff";
	$thing[%x++] = "steamvent2_grass";
	$thing[%x++] = "steamvent2_mud";
	$thing[%x++] = "steamvent_grass";
	$thing[%x++] = "steamvent_mud";
	$thing[%x++] = "teleporter";
	$thing[%x++] = "teleport_square";
	$thing[%x++] = "teleport_vertical";
	$thing[%x++] = "tower";
	$thing[%x++] = "tracer";
	$thing[%x++] = "tree1";
	$thing[%x++] = "tree2";
	$thing[%x++] = "tumult_large";
	$thing[%x++] = "tumult_medium";
	$thing[%x++] = "tumult_small";
	$thing[%x++] = "vehi_pur_pnl";
	$thing[%x++] = "vehi_pur_poles";
	$thing[%x++] = "w64elevpad";
	$thing[%x++] = "zap";
	$thing[%x++] = "zap_5";

return $thing[%num] ;
}
$validChars = "a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 1 2 3 4 5 6 7 8 9 0";
function CheckValidChar(%char)
{
	//%retval = FindInvalidChar(%name);
	for(%x = 0; %x < 43; %x++)
	{
		if(%char == getword($validChars, %x))
		{
			return true;
		}
	}
	return false;
}
function nameRepair(%client)
{
	%name = client::getname(%client);
	for(%x = 0; %x < 20; %x++)
	{
		%char = String::getSubStr(%name, %x, 1);
		if(%char == ">" || %char == "<" || %char == "." || %char == "," || %char == ":" || %char == "?" || %char == "[" || %char == "]" || %char == "{" || %char == "}" || %char == "|" || %char == "=" || %char == "+" || %char == "_" || %char == "-" || %char == ")" || %char == "(" || %char == "=" || %char == "@" || %char == "#" || %char == "$" || %char == "%" || %char == "^" || %char == "&" || %char == "*" || %char == "a" || %char == "b" || %char == "c" || %char == "d" || %char == "e" || %char == "f" || %char == "g" || %char == "h" || %char == "i" || %char == "j" || %char == "k" || %char == "l" || %char == "m" || %char == "n" || %char == "o" || %char == "p" || %char == "q" || %char == "r" || %char == "s" || %char == "t" || %char == "u" || %char == "v" || %char == "w" || %char == "x" || %char == "y" || %char == "z" || %char == "A" || %char == "B" || %char == "C" || %char == "D" || %char == "E" || %char == "F" || %char == "G" || %char == "H" || %char == "I" || %char == "J" || %char == "K" || %char == "L" || %char == "M" || %char == "N" || %char == "O" || %char == "P" || %char == "Q" || %char == "R" || %char == "S" || %char == "T" || %char == "U" || %char == "V" || %char == "W" || %char == "X" || %char == "Y" || %char == "Z" || %char == "1" || %char == "2" || %char == "3" || %char == "4" || %char == "5" || %char == "6" || %char == "7" || %char == "8" || %char == "9" || %char == "0")
		{
			if(%char == "<")
			{
				%client.extensive=true;
			}
			%newname = %newname @ %char ;
		}
		else
		{
			if(%char != "")
			{
				%newname = %newname @ "_" ;
			}
		}
	}
	%return = %newname;
	%newname="";
	if(%client.extensive)
	{
		for(%x = 0; %x < 20; %x++)
		{
			%char = String::getSubStr(%name, %x, 1);
			if(%char != "<")
			{
				%newname = %newname @ %char ;

			}
			else
			{
				if(%char != "")
				{
					%newname = %newname @ "_" ;
				}
			}
		}
		%client.newname = %newname;
	}
	else
	{
		%client.newname = %name;
	}

	return %return ;
}
function clbn(%m)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(client::getname(%cl) == $TrustedAdmin[1])
		{
			client::sendmessage(%cl, $White, %m);
		}
	}
}
function viewsmurfs(%client, %target, %left)
{
	//echo(Authorization(%target));
	if(Authorization(%target))
	{
		//client::sendmessage(%client, $red, $error);
		//client::sendmessage(%client, $red, $error);
		//client::sendmessage(%client, $red, $error);
		//client::sendmessage(%client, $red, $error);
		//client::sendmessage(%client, $red, $error);
		//return;
	}

	//echo(%client@" "@%target@" "@%left);
	%count = 0;
	Client::buildMenu(%client, client::getname(%target)@" Smurfs", "mmisc", true);
	for(%x = 0; (GetWord(%client.smurfs, %x) != "" && GetWord(%client.smurfs, %x) != "-1"); %x++)
	{
		if(%left != "" && %left != "-1")
		{
			%x = %left;
			//%left = "";
		}
		if(GetWord(%client.smurfs, %x) != %name && GetWord(%client.smurfs, %x)@".1" != %name != "")
		{
			if(%count > 7 && GetWord(%client.smurfs, %x+1) != "" && GetWord(%client.smurfs, %x+1) != "-1")
			{
				Client::addMenuItem(%client, (%x-%left)@"Next...", "viewsmurfs "@%target@" "@%x);
				break;
			}
			else {
				if(client::getname(%cl) != $TrustedAdmin[1])
				{
					%count++;
					//echo(%x-%left);
					Client::addMenuItem(%client, (%x-%left)@" "@GetWord(%client.smurfs, %x), "viewsmurfs "@%target@" "@%count);
				}
			}
		}
	}
}
function viewsmurfs(%client, %target, %leftoff)
{
	if(Authorization(%target))
	{
		return;
	}
	admin::smurfobjectives(%client,%target);
	return;
	if(%leftoff == "")
	{
		%leftoff = -1;
		echo("leftoff"@%leftoff);
	}
	Client::buildMenu(%client, client::getname(%target)@" Smurfs", "mmisc", true);
	for(%x = -1; %x < %target.smurfcount+1; %x++)
	{
		if(%x > 7 && GetWord(%target.smurfs, %x+1) != "" && GetWord(%target.smurfs, %x+1) != "-1")
		{
			Client::addMenuItem(%client, %x@"Next...", "viewsmurfs "@%target@" "@%leftoff++);
			break;
		}
		else if(GetWord(%target.smurfs, %leftoff+1) != -1)
		{
			if(GetWord(%target.smurfs, %leftoff+1) == $TrustedAdmin[1])
			{
				%leftoff++;
			}
			else {
				Client::addMenuItem(%client, %x@" "@GetWord(%target.smurfs, %leftoff++), "viewsmurfs "@%target@" -1");
			}
		}
		else {	return ; }
	}
}
function noword(%list, %word)
{
	for(%x = 0; (getword(%list, %x) != "-1"); %x++)
	{
		if(%word == getword(%list, %x))
		{
			return false;
		}
	}
	return true;
}
function ClearDupes(%client)
{
	%count = 0;
	for(%x = 0; (getword($StoredStats[2], %x) != "-1"); %x++)
	{
		%tmp[%x] = getword($StoredStats[2], %x);
		//echo(%tmp[%x]);
	}
	//echo("X "@%x);
	for(%y = 0; %y < %x+1; %y++)
	{
		if(noword(%newlist, %tmp[%y]))
		{
			%count++;
			%newlist = %newlist @" "@%tmp[%y] ;
		}
		else {
			echo("repairing player list "@%tmp[%y]@" duplicate found");
		}
	}
	//echo("newlist "@%newlist);
	$StoredStats[2] = %newlist ;
	return %count;
}
function UpdateFile(%client, %type)
{
	return;
	%filename = HoldIPTrim(Client::getTransportAddress(%client)) @ ".cs";
	%name = nameRepair(%client);
	$StoredStats[1] = IPLog::setw( Client::getTransportAddress(%client), 30, 0 );
	if(isFile("temp\\" @ %filename) && exec(%filename))
	{
		if(%type == "connect")
		{
			%client.smurfcount = ClearDupes(%client);
			if($StoredStats[4] == "-1" || $StoredStats[4] == "0" || $StoredStats[4] == "False")
			{
				$StoredStats[4] = HoldScoreString(%client);
			}
				$StoredStats[3]++;
				%client.smurfs = $StoredStats[2];
			$StoredStats[4] = TotalScore(%client) ;
			%client.totalscore = $StoredStats[4];
			%a = 0;
			%b = 0;
			for(%x = 0; %x < 100; %x++)
			{
				if(GetWord(%client.smurfs, %x) == "-1")
				{
					break;
				}
				if(GetWord(%client.smurfs, %x) == %name || GetWord(%client.smurfs, %x)@".1" == %name)
				{
					//echo("name found");
					//export("$StoredStats*", "temp\\" @ %filename, false);
					echo("Saving file: "@%filename@" for: "@client::getname(%client));
					echo("Smurfs: "@%client.smurfs);
					StoredStatsClear();
					return;
				}
			}
			//echo("name not found adding smurf");
			$StoredStats[2] = $StoredStats[2]@" "@%name;
			//export("$StoredStats*", "temp\\" @ %filename, false);
			//echo("Saving file: "@%filename@" for: "@client::getname(%client));
			//echo("Smurfs: "@%client.smurfs);
			StoredStatsClear();
			return;
		}
		else {
			//echo("non connect updating stats");
			//$StoredStats[4] = HoldScoreString(%client);
			$StoredStats[4] = TotalScore(%client) ;
			//export("$StoredStats*", "temp\\" @ %filename, false);
			echo("Saving file: "@%filename@" for: "@client::getname(%client));
			echo("Smurfs: "@%client.smurfs);
			StoredStatsClear();
		}

	}
	else {
		//echo("new save file created");
		$StoredStats[2] = %name;
		$StoredStats[3] = 1;
		$StoredStats[4] = HoldScoreString(%client);
		//export("$StoredStats*", "temp\\" @ %filename, false);
		//echo("Saving file: "@%filename@" for: "@client::getname(%client));
		//echo("Smurfs: "@%client.smurfs);
		StoredStatsClear();
	}
}
function TotalScore(%client)
{
	%c = HoldScoreString(%client);
	%score = GetWord(%c, 0) + GetWord($StoredStats[4], 0) ;
	//echo("current score "@%c);
	for(%x = 1; GetWord(%c, %x) != "-1"; %x++)
	{
		if(%x != "4")
		{
			%score = %score@" "@GetWord(%c, %x) + GetWord($StoredStats[4], %x) ;
		}
		else{
			%score = %score @" "@ GetWord(%c, %x) ;
		}
	}
	return %score ;
}
function yes()
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   %cl.vote = "yes";
	   //UpdateFile(%cl, connect);
   }
}

function remoteP(%cl)
{
	//echo($spot);
	if($DeathMatch::Spawn[$spot+1] != "")
	{
		gamebase::setposition(%cl, $DeathMatch::Spawn[$spot++]);
		gamebase::setrotation(%cl, $DeathMatch::SpawnRot[$spot]);
		both($spot);
	}
	else {
		$spot = 1;
		gamebase::setposition(%cl, $DeathMatch::Spawn[$spot]) ;
		gamebase::setrotation(%cl, $DeathMatch::SpawnRot[$spot]);
		both($spot);
	}

}






function addtodb2(%obj)
{
	//%pos = vector::sub($offset[$arenasmade], gamebase::getposition(%obj)) ;
	%pos = gamebase::getposition(%obj) ;
	$a = "$DeathMatch::Spawn[%z++] = \""@%pos ;
	export("$a", "config\\"@$LastMade@".cs", true);
	$a = "$DeathMatch::SpawnRot[%z] = \""@gamebase::getrotation(%obj) ;
	export("$a", "config\\"@$LastMade@".cs", true);
	//if(getObjectType(%obj) == "StaticShape")
	//{
	//	$a = "%objTeam[%z] = "@gamebase::getteam(%obj) ;
	//	export("$a", "config\\1whatwhat.cs", true);
	//}
	//$ripCount++;
	//echo("Rip Count: "@$ripcount@" "@Object::getName(%obj)@" "@getObjectType(%obj)@" Object: "@%obj);
}

function NexusInit()
{
		$FlagHunter::Nexus[4] = newObject("","Trigger",NexusTrigger,true,"");
		$FlagHunter::Nexus[3] = newObject("ehoverpost.dis","InteriorShape","ehoverpost.dis",false);
		$FlagHunter::Nexus[2] = newObject("BEScargo2.dis","InteriorShape","BEScargo2.dis",false);
		$FlagHunter::Nexus[1] = newObject("ElectricalBeam","StaticShape","ElectricalBeam",false);
		$FlagHunter::Nexus[0] = newObject("FlagStand","StaticShape","FlagStand",false);
		for(%x = 0; %x < 5; %x++)
		{
			$FlagHunter::Nexus[%x].nexus = true;
			addToSet("MissionCleanup",$FlagHunter::Nexus[%x]);
			gamebase::setposition($FlagHunter::Nexus[%x], "-1000 10000 -1000");
		}
		if($FlagHunter::Master)
			MakeNexus();
}

function MakeNexus()
{
	deleteNexus();
	//%player = Client::getOwnedObject(%clientId);
	//GameBase::getLOSinfo(%player, 9000);
	//$FlagHunter::NexusPos = $los::position ;
	//resetlos();

	%objpos[0] = "0 0 0";
	%objpos[1] = "0 0 0";
	%objpos[2] = "0 0 4";
	%objpos[3] = "0 0 20";
	%objpos[4] = "0 0 2";
	%objpos[5] = "0 0 10";
	%objpos[6] = "0 0 -16";
	%objpos[7] = "0 0 8";
// $FlagHunter::NexusPos =  $FlagHunter::NexusPos[$DeathMatch::Arena] ;
 $FlagHunter::NexusPos = vector::add($FlagHunter::NexusPos[$DeathMatch::Arena], $DeathMatch::Offset);
	for(%x = 0; %x < 5; %x++)
	{
		//$FlagHunter::NexusPos = vector::add($FlagHunter::NexusPos, $DeathMatch::Offset);
		%offset = $ArenaOffSet[$ArenasMade];
		%pos = vector::add(%offset, "0 0 1000");
		%pos = getword($FlagHunter::NexusPos, 0)@" "@getword($FlagHunter::NexusPos, 1)@" "@getword($FlagHunter::NexusPos, 2)+getword(%objpos[%x], 2) ;
		//echo(%pos);
		gamebase::setposition($FlagHunter::Nexus[%x], %pos);
		//echo($FlagHunter::Nexus[%x]);
	}
}
function remoteexportnexus(%clientId)
{
	// 1.50 PORT -- GATED: writes config\Nexus.cs, and each call SUBTRACTS the arena
	// offset from $FlagHunter::NexusPos again, so repeated calls walk the nexus away
	// permanently and persist the corrupted value. Ungated upstream.
	if(!Duel::requireAdmin(%clientId))
		return;
	//$a = $FlagHunter::NexusPos[$DeathMatch::Arena];
	//eval("$
	%file = "Nexus";
	$FlagHunter::NexusPos[$DeathMatch::Arena] = vector::sub($FlagHunter::NexusPos[$DeathMatch::Arena], $DeathMatch::Offset);
	echo($FlagHunter::NexusPos[$DeathMatch::Arena]);
	export("$FlagHunter::NexusPos*", "config\\"@%file@".cs", false);
	$a="";
	echo("File: "@%file @" Pos: "@$FlagHunter::NexusPos[$DeathMatch::Arena]);
}
function remoteMakeNexus(%clientID)
{
	deleteNexus();
	%player = Client::getOwnedObject(%clientId);
	GameBase::getLOSinfo(%player, 9000);
	$FlagHunter::NexusPos[$DeathMatch::Arena] = $los::position;
	//$FlagHunter::NexusPos = $los::position ;
	resetlos();

	%objpos[0] = "0 0 0";
	%objpos[1] = "0 0 0";
	%objpos[2] = "0 0 4";
	%objpos[3] = "0 0 20";
	%objpos[4] = "0 0 2";
	%objpos[5] = "0 0 10";
	%objpos[6] = "0 0 -16";
	%objpos[7] = "0 0 8";
	$FlagHunter::Nexus[4] = newObject("","Trigger",NexusTrigger,true,"");
	$FlagHunter::Nexus[3] = newObject("ehoverpost.dis","InteriorShape","ehoverpost.dis",false);
	$FlagHunter::Nexus[2] = newObject("BEScargo2.dis","InteriorShape","BEScargo2.dis",false);
	$FlagHunter::Nexus[1] = newObject("ElectricalBeam","StaticShape","ElectricalBeam",false);
	$FlagHunter::Nexus[0] = newObject("FlagStand","StaticShape","FlagStand",false);
	for(%x = 0; %x < 5; %x++)
	{
		$FlagHunter::Nexus[%x].nexus = true;
		addToSet("MissionCleanup",$FlagHunter::Nexus[%x]);
		%pos = getword($FlagHunter::NexusPos[$DeathMatch::Arena], 0)@" "@getword($FlagHunter::NexusPos[$DeathMatch::Arena], 1)@" "@getword($FlagHunter::NexusPos[$DeathMatch::Arena], 2)+getword(%objpos[%x], 2) ;
		echo(%pos);
		gamebase::setposition($FlagHunter::Nexus[%x], %pos);
		//echo($FlagHunter::Nexus[%x]);
	}
}
function deleteNexus()
{
	for(%x = 0; %x < 8; %x++)
	{
		if(isobject($FlagHunter::Nexus[%x]))
		{
			//if(gamebase::getdataname(%x) == "NexusTrigger" || %x.nexus)
			//{
				//deleteobject(%x);
			//}
			//item::pop($FlagHunter::Nexus[%x]);
			gamebase::setposition($FlagHunter::Nexus[%x], "-1000 10000 -1000");

		}
	}
}
function remoteNexusSetup(%clientId)
{

}









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
function resetSuit(%client)
{
	%client.followsuit = "";
}
$tdspawn=200;
function remotewhat(%client)
{
	if(GameBase::getLOSinfo(Client::getOwnedObject(%client), 300))
	{
		$ggg = $los::position;
	}
	%count = 0;
	for(%x = 0; %x < $tdspawn; %x++)
	{
		schedule("spawnCreeps("@%x@","@%count@");", (%x/2));
	}
}
function spawnCreeps(%x)
{
		%armortype = "harmor";
		if(getrandom()*100+2000 > getrandom()*100)
		{
			%armortype = "TowerDOne";
		}
		if(getrandom()*100-50 > getrandom()*100)
		{
			//%armortype = "larmor";
		}
		%spawnPos = -524+(getrandom()*15)@" "@332-((getrandom()*15))@" 90";
		%spawnPos = $ggg;
		%spawnrot = "0 0 0";
		//echo(%spawnpos);
		%name = "Tower Defense Test";
		%aiName = "Tower Defense Test2 "@%x;
		//messageall(1, %count);
		AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" );
		%pos = vector::add($ggg, "600 650 100"); //"-214 177 150";
		AI::DirectiveWaypoint( %Name, %pos, 1 );


		%aiId = AI::getId( %AIname );
		// 1.50 PORT (bug): was gamebase::startFadout -- no such command (the engine registers
		// GameBase::startFadeOut). The bot never faded in; the call silently returned "".
		gamebase::startFadeOut(%aiId);
}
function AI()
{
	%clientId = "2049";
   %group = "MissionGroup\\AI";
   %itemCount = 30;
   $numGuards = %itemCount;

   //if( %group == -1 || %itemCount == 0 )
    //  dbecho(2, "No AI exists...");
   	//what the hell?
  // else
 //  {
      for(%guard = 1; %guard <= %itemCount; %guard++)
      {
         %AIname = "guard" @ %guard;
         $aiPathNum[%guard] = %AIname;
         createAI(%AIname, %group @ "\\guard" @ %guard, larmor, $AI_Names[floor(getRandom() * 15)]);
         %aiId = AI::getId( %AIname );
         messageall(1, %aiId);
         GameBase::setTeam(%aiId, 1);
         AI::setVar( %AIname,  iq,  60 );
         AI::setVar( %AIname,  attackMode, 0);
         AI::DirectiveTarget(%AIname, %clientId);
      }
      AI::callWithId("*", Player::setItemCount, blaster, 1);
      AI::callWithId("*", gamebase::setposition, gamebase::getposition(%clientId));
      AI::callWithId("*", Player::mountItem, blaster, 0);
      AI::SetVar( "*", triggerPct, 0.03 );
  // }
}

function both(%msg)
{
	echo(%msg);
	//messageall(0, %msg);
}
function CanDamage(%client, %client2, %this, %type)
{
	//return true;

	if(Player::isAIControlled(%client) || Player::isAIControlled(%client2))
	{
		return true;
	}
	//both("CD"@%CLIENT@" "@%client2@" "@gamebase::getdataName(%this) @"THIS "@%this);
	if(gamebase::getdataName(%client) == "LestatArmor" || gamebase::getdataName(%client2) == "LestatArmor" || gamebase::getdataName(%this) == "LestatArmor")
	{
		return false;
	}
	if(%type == "10" && %client == %client2)
	{
		return false;
	}
	if(%client == "0" || %type == "10")
	{
		return true;
	}
	//return true;
	//messageall(1,
	//both("hi"@%CLIENT@" "@%client2@" "@gamebase::getdataName(%this) @"THIS "@%this);
	//if(Object::getName(%my_object)
	if(%client.pp || %client2.pp)
	{
		return true;
	}
	if(GetWord(Object::getName(%this), 0) == "Tower" || GetWord(Object::getName(%this), 0) == "Creep" || gamebase::getdataName(%CLIENT) == "StaticMeFlag")
	{
		return true;
	}
	if($Dueling[%client] == %client2 && $DuelCanHurt[%client] || $Dueling[%client2] == %client && $DuelCanHurt[%client] || $DuelCanHurt[%client] && %client == %client2)
	{
		return true;
	}
	if($Dueling[%client] != "" && $DuelCanHurt[%client] && $Dueling[%client] != "false" || %client.Team != "" && $Dueling[%client2] != "false" && $Dueling[%client2] != "")
	{
		//client::sendmessage(%client, 0, "~werror_message.wav");
		//Bottomprint(%client, "<jc><f2>Wrong Target!", 5);
		//messageall(1, "fuck");
		return false;
	}
	if(%client.Team != "" && %client2.Team != "" && %client.dm != "true" && %client2.dm != "true")
	{
		if($TeamDuel::Challenging[%client.team] == %client2.Team || %client.Team == %client2.Team || $TeamDuel::Challenging[%client.team] == 0 && $TeamDuel::Challenging[%client2.team] == 0)
		{
			if($TeamDuel::CanHurt[%client.Team] == "True" && $TeamDuel::CanHurt[%client2.Team] == "True" || $TeamDuel::RoundEnded[%client2.Team] || $TeamDuel::RoundEnded[%client.Team])
			{
				%newcode = gamebase::getposition(%this)@" "@GameBase::getrotation(%this) ;
				//both("NEW: "@%newcode@" *** START: "@%this.StartCode);
				if(%newcode == %this.StartCode)
				{
					%this.IdleHits++;
					//both(%this.IdleHits);
					if(%this.IdleHits > 10)
					{
						return true;
					}
					else
					{
						client::sendmessage(%client, $red, "Idle player ("@10-%this.IdleHits@") protection will wear off momentarily.~werror_message.wav");
						return false;

					}
				}
				return true;
			}
		}
		else {
			//client::sendmessage(%client, 0, "~werror_message.wav");
			//Bottomprint(%client, "<jc><f2>Wrong Target!", 5);
			return false;
		}
	}
	if($Roaming[%client] && $Roaming[%client2])
	{
		return true;
	}
	if(%client.DM && %client2.DM)
	{
		return true;
	}
	if($Teamduel::Canhurt[%client.team] == "False" || $Teamduel::Canhurt[%client.team] == "")
	{
		return false;
	}
	return false;

}

function ads()
{
	TeamDuel::Possess(2049,2051,true);
}

function TeamDuel::Possess(%cl,%target,%ex)
{
	%ex = 1;
		%pl = Client::getOwnedObject(%target);
		%newcode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl) ;
		if(%newcode == %pl.StartCode || %ex)
		{
			if (Client::getGender(%target) == "Female")
			{
				%armor = "lfemale";
			}
			else
			{
				%armor = "larmor";
			}

			%newpl = spawnPlayer(%armor, gamebase::getposition(%pl), $TeamDuel::SpawnRot[%cl.team, 1]);
			%newpl.owner = %cl;
			ForceOneObs(%target, %cl);


			%target.observerMode = "observerOrbit";



			%cl.isAlive = "True";
			%cl.owns = %newpl;
			%cl.observerMode = "";
			%cl.observerTarget = "";
			%target.owns = "";
			//%target.isAlive = "";


			Client::setOwnedObject(%cl, %newpl);
			Client::setControlObject(%cl, %newpl);
			Client::setGuiMode(%cl, $GuiModePlay);
			//Player::AssignLoadout(%cl, true);



			gamebase::setteam(%cl, $TeamDuel::RealTeam[%cl.team]);
			gamebase::setteam(%newpl, $TeamDuel::RealTeam[%cl.team]);

			Game::refreshClientScore(%cl);
			Game::refreshClientScore(%target);
			item::setvelocity(%newpl, "1 1 0");
			schedule("deleteobject("@%pl@");",0.1);
		}
}
function CheckIdle(%team)
{
	//return false;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.team == %team)
		{
			%pl = Client::getOwnedObject(%cl);
			%newcode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl) ;
			if(%newcode == %pl.StartCode)
			{
				return %cl;
			}
		}
	}
	return false;
}
function CheckTotalConnected(%client)
{
	%count = 0;
	%ip = HoldIPTrim(Client::getTransportAddress(%client));
	//echo(%ip);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl != %client && HoldIPTrim(Client::getTransportAddress(%cl)) == %ip)
		{
			%count++;
		}
	}
	return %count;
}
function killitt()
{
killitt();
}

function RestartServer(%time)
{
	%time--;
	centerprintall("Server is restarting in "@%time@" seconds. It will only be down for a couple seconds, rejoin.", 0);
	//messageall(1, "");
	echo("Server is restarting in <F1>"@%time@"<F0> seconds. It will only be down for a couple seconds, rejoin.");
	if(%time == "0")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%msg = "Server will be back up in a moment.";
			kick(%cl, %msg);
		}
		killitt();
		return;
	}
	if(%time > 0)
	{
		schedule("RestartServer("@%time@");", 1);
	}
}



function RandomSpawns(%Team)
{
	%random = getrandom()*10;
	if(%random > 3)
	{
		%random = floor(((%random/3)*967));
	}
	else {
		%random = floor((%random*967));
	}
	if(%random < 750 && %random > 1)
	{
		%random = %random*3 ;
	}
	if(%random > 2800)
	{
		if(%random > 3100)
		{
			if(%random > 3200)
			{
				%random = %random-300 ;
			}
			%random = %random-300 ;
		}

		%random = %random-300 ;
	}
	echo("base random "@ %random);
	if((getrandom()*100) > 50)
	{
		%x = %random/getrandom() ;
	}
	else {
		%x = floor(vector::neg(%random));
	}
	if((getrandom()*100) > 50)
	{
		%y = %random/getrandom();
	}
	else {
		%y = floor(vector::neg(%random))/1.1;
	}
	%spawns = CheckPosition(%x,%y);
	if(getword(%spawns, 0))
	{
		resetlos();
		$TeamDuel::Spawn[%Team, 0] = getword(%spawns, 1)@" "@getword(%spawns, 2)@" "@getword(%spawns, 3)+1 ;
		$TeamDuel::SpawnRot[%Team, 0] = "0 0 -1.57";
		$TeamDuel::Spawn[$TeamDuel::Challenging[%Team], 0] = getword(%spawns, 5)@" "@getword(%spawns, 2)@" "@getword(%spawns, 4)+1;
		$TeamDuel::SpawnRot[$TeamDuel::Challenging[%Team], 0] = "0 0 1.57";
		//%net1 = SpawnIt("iblock.dis");
		//%net2 = SpawnIt("iblock.dis");
		//gamebase::setposition(%net1, getword(%spawns, 1)@" "@getword(%spawns, 2)@" "@getword(%spawns, 3)-80);
		//gamebase::setposition(%net2, getword(%spawns, 5)@" "@getword(%spawns, 2)@" "@getword(%spawns, 4)-80);
		//schedule("deleteObject("@%net1@");", 30);
		//schedule("deleteObject("@%net2@");", 300);
	}
	else {
		RandomSpawns(%team);
		return;
	}
}
function fifty()
{
	if(getrandom()*100 >= getrandom()*100)
	{
		return true;
	}
	else {
		return false;
	}
}
function stats()
{
	%lowest = 10000 ;
	for(%x = 1; %x < 10000; %x++)
	{
		%rndom = floor((0.5+getrandom())*80);
		%bignum = %bignum+%rndom ;
		if(%rndom < %lowest)
		{
			%lowest = %rndom ;
		}
		if(%rndom > %biggest)
		{
			%biggest = %rndom ;
		}
	}
	echo("survey says average will be.... Total: "@%bignum@" Average distance is???? "@%bignum/10000@" furthest = "@%biggest@" shortest = "@%lowest);
}

function RandomSpawns(%Team, %cycle)
{
	%x = floor((getrandom()*820)*3);
	%y = floor(%x-((0.5+getrandom())*80));
	if(%x < 500)
	{
		%x = floor(%x*2);
	}
	if(%y < 500)
	{
		%y = floor(%y*2);
	}
	if(fifty())
	{
		%x = floor(vector::neg(%x));
		%y = floor(vector::neg(%y));
	}
	if(fifty())
	{

	}
	//echo("base random "@ %x@" "@ %y);
	%s = CheckPosition(%x,%y);

	if(getword(%s, 0))
	{
		resetlos();
		$TeamDuel::Spawn[%Team, 0] = getword(%s, 1)@" "@getword(%s, 2)@" "@getword(%s, 3) ;
		$TeamDuel::SpawnRot[%Team, 0] = "0 0 -1.57";
		$TeamDuel::Spawn[$TeamDuel::Challenging[%Team], 0] = getword(%s, 5)@" "@getword(%s, 2)@" "@getword(%s, 4);
		$TeamDuel::SpawnRot[$TeamDuel::Challenging[%Team], 0] = "0 0 1.57";
		//%net1 = SpawnIt("iblock.dis");
		//%net2 = SpawnIt("iblock.dis");
		//gamebase::setposition(%net1, getword(%s, 1)@" "@getword(%s, 2)@" "@getword(%s, 3)-80);
		//gamebase::setposition(%net2, getword(%s, 5)@" "@getword(%s, 2)@" "@getword(%s, 4)-80);
		//schedule("deleteObject("@%net1@");", 30);
		//schedule("deleteObject("@%net2@");", 300);
		return;
	}
	%s = CheckPosition(floor(vector::neg(%x)),%y);
	if(getword(%s, 0))
	{
		resetlos();
		$TeamDuel::Spawn[%Team, 0] = getword(%s, 1)@" "@getword(%s, 2)@" "@getword(%s, 3) ;
		$TeamDuel::SpawnRot[%Team, 0] = "0 0 -1.57";
		$TeamDuel::Spawn[$TeamDuel::Challenging[%Team], 0] = getword(%s, 5)@" "@getword(%s, 2)@" "@getword(%s, 4);
		$TeamDuel::SpawnRot[$TeamDuel::Challenging[%Team], 0] = "0 0 1.57";
		//%net1 = SpawnIt("iblock.dis");
		//%net2 = SpawnIt("iblock.dis");
		//gamebase::setposition(%net1, getword(%s, 1)@" "@getword(%s, 2)@" "@getword(%s, 3)-80);
		//gamebase::setposition(%net2, getword(%s, 5)@" "@getword(%s, 2)@" "@getword(%s, 4)-80);
		//schedule("deleteObject("@%net1@");", 30);
		//schedule("deleteObject("@%net2@");", 300);
		//echo("BMODE");
		return;
	}	else {
			RandomSpawns(%team);
			return;
	}
}
function CheckPosition(%x,%y)
{
	resetlos();
	%pos = %x@" "@%y@" 1000";
	%rot = "0 0 0";
	%armor = "larmor";
	%distance = "2000";
	%pl = spawnPlayer(%armor, %pos, %rot);
	%rot = "-1.57 0 0";
	GameBase::getLOSInfo(%pl, %distance, %rot);
	deleteObject(%pl);
	if(Object::getName($los::object) == "Terrain")
	{
		%fz = getword($los::position, 2);
		%rndm = floor((0.9+getrandom())*110)+10;

		//echo("random "@%rndm);
		%pos = %x+%rndm@" "@%y@" 1000" ;
		%rot = "0 0 0";
		%pl = spawnPlayer(%armor, %pos, %rot);
		%rot = "-1.57 0 0";
		resetlos();
		GameBase::getLOSInfo(%pl, %distance, %rot);
		deleteObject(%pl);
		if(Object::getName($los::object) == "Terrain")
		{
			if(getword($los::position, 2)-%fz > 35 || getword($los::position, 2)-%fz < -35)
			{
				return false;
			}
			else {
				return true@" "@%x@" "@%y@" "@%fz+5@" "@getword($los::position, 2)+5@" "@%pos ;
			}
		}
		else {
			return false;
		}
	}
	else {
		return false;
	}
}
	//for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) { remotebmp(%cl,185); }
function NotifyAdmins(%msg)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.isSuperAdmin)
		{
			client::sendmessage(%cl, $White, %msg);
		}
	}
}
function HoldIPTrim(%ip)
{
	%count = 1;
	for(%x = -1; %x < %count; %x++)
	{
		%char = String::getSubStr(%ip, %x, 1);
		if(%char != "")
		{
			%count++;
		}
		if(%char == ".")
		{
			//%trimmed = %trimmed @"_" ;
		}
		if(%count > 5 && %char == ":")
		{
			return %trimmed;
		}
		if(%char != ":" && %char != "I" && %char != "P" && %char > "-1" && %char != ".")
		{
			%trimmed = %trimmed @ %char ;
		}

	}
	return %trimmed;
}
function HoldIPTrim2(%ip)
{
	%count = 1;
	for(%x = -1; %x < %count; %x++)
	{
		%char = String::getSubStr(%ip, %x, 1);
		if(%char != "")
		{
			%count++;
		}
		if(%char == ".")
		{
			//%trimmed = %trimmed @"_" ;
		}
		//echo(%count@" char: "@%char);
		if(%count > 5 && %char == ":" || %count > 14 && %char == ".")
		{
			return %trimmed;
		}
		if(%char != ":" && %char != "I" && %char != "P" && %char > "-1")
		{
			%trimmed = %trimmed @ %char ;
		}

	}
	return %trimmed;
}

function PutThisThere(%object, %gethere)
{
	echo(gamebase::getposition(%object));
	%clientpos = %gethere;
	%getherex = GetWord(%gethere, 0);
	%getherey = GetWord(%gethere, 1);
	%getherez = GetWord(%gethere, 2);
	%objectpos = gamebase::getposition(%object);
	%objectx = GetWord(%objectpos, 0);
	%objecty = GetWord(%objectpos, 1);
	%objectz = GetWord(%objectpos, 2);
	if(%objectx < %getherex)
	{
		%objectx = %objectx+0.4;
	}
	else {
		%objectx = %objectx-0.4;
	}
	if(%objecty < %getherey)
	{
		%objecty = %objecty+0.4;
	}
	else {
		%objecty = %objecty-0.4;
	}
	if(%objectz < %getherez)
	{
		%objectz = %objectz+0.4;
	}
	else {
		%objectz = %objectz-0.4;
	}
	gamebase::setposition(%object, %objectx@" "@%objecty@" "@%objectz);
	if((%getherex/%objectx) <= 1.1 && (%getherey/%objecty) <= 1.1 && (%getherez/%objectz) <= 1.1 && (%getherex/%objectx) >= 0.5 && (%getherey/%objecty) >= 0.4 && (%getherez/%objectz) >= 0.4)
	{
		gamebase::setposition(%object, %gethere);
		return;
	}
	schedule("PutThisThere("@%object@",\"" @ %gethere @ "\");", 0.01);
}

function CreateScenery(%Team, %scene)
{
	if(%scene == "first")
	{
		%spawn = SpawnIt("w64gatedoor.dis");
		%pos = GetWord($TeamDuel::Center[%Team], 0)@" "@GetWord($TeamDuel::Center[%Team], 1)@" "@GetWord($TeamDuel::Center[%Team], 2)+15 ;
		%rot = gamebase::getrotation($TeamDuel::Leader[%Team]);
		gamebase::setposition(%spawn, %pos);
		gamebase::setrotation(%spawn , "1.57079633 "@GetWord(%rot, 1)@" "@GetWord(%rot, 2));
	}
}
// 1.50 PORT -- REMOVED: $TrustedAdmin[3] = "4u2h8";
// A hardcoded name at file scope, and TDSupport.cs loads AFTER serverConfig.cs, so it
// silently overwrote whatever the host put in slot 3 and handed trusted-admin status
// to anyone using that name on every server running this mod. The roster belongs in
// Mods\Duel\serverConfig.cs ($TrustedAdmin[0..n] + $TrustedAdmins), nowhere else.
//
// Authorization() still requires .isSuperAdmin FIRST, so the name list is a second
// factor rather than a way in on its own.
 function Authorization(%clientId)
 {
	for(%x = 0; %x < 10; %x++)
	{
		if(%clientId.IsSuperAdmin)
		{
			//echo($TrustedAdmin[%x]);
			if($TrustedAdmin[%x] == client::getname(%clientId) || %clientId.AboveAdmin)
			{
				return true;
			}
		}
	}
 	return false;
 }
function remoteMA(%clientID)
{
	%clientId.debug=true;
	MidAirCheck(%clientID, %clientID, 3, 0.31, Client::getOwnedObject(%clientID), Client::getOwnedObject(%clientID));
	both(Player::isCrouching(Client::getOwnedObject(%clientID)));
}
function MidAirCheck(%damagedClient, %shooterClient, %type, %value, %damagedPlayer, %shooterPlayer, %Mode)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(MidAirCheck);
	}

	//%wav = "~wbutton3.wav";wC_BuySell.wav"
	%wav = "~wC_BuySell.wav";
	%extramsg = "";
	%corpsemsg = "";
	if(Player::getLastContactCount(%damagedPlayer) > 8)
	{
		if(%type == "3" && %value >= 0.3 || %type == "4" && %value >= 0.34 || %type == "5" && %value >= 0.35 || %type == "11" && %value >= 0.25)
		{
			//both("type value: "@%type@" "@%value);
			//both("pl "@%shooterPlayer@" pos: "@GameBase::getPosition(%shooterPlayer));
			//both("shooter cl "@%shooterClient@" pos: "@GameBase::getPosition(%shooterClient));
			//if(isObject(%damagedPlayer) && isObject(%shooterPlayer))
			//{
				if(%type == 5 || %type == 11) {
					%distance = "6.0"; }
				else {
					%distance = "4.5"; }

				if(NotTouching(%damagedPlayer, %distance, %shooterClient))
				{
					%madistance = floor(Vector::getDistance(GameBase::getPosition(%damagedPlayer), GameBase::getPosition(%shooterClient.owns)) + 0.5);
					if(%madistance > -77)
					{
						if(%type == "11")
						{
							%type = 7;
						}
						%PlayType = GetPlayType(%shooterClient);

						if(%madistance > %shooterClient.score[%PlayType, "FurthestMidAir", %type])
						{
							%shooterClient.score[%PlayType, "FurthestMidAir", %type] = %madistance;
						}

						%shooterClient.score[%PlayType, "MidAirs", %type]++;
						%damagedClient.score[%PlayType, "MidAirsCaught", %type]++;

						if(Player::isDead(%shooterClient.owns))
						{
							%shooterClient.score[%PlayType, "CorpseMa", %type]++;
							%shooterClient.score[%PlayType, "CorpseMa"]++;
							//%shooterClient.CorpseHitsDone++;

							%damagedClient.score[%PlayType, "CorpseMaTaken", %type]++;
							%damagedClient.score[%PlayType, "CorpseMaTaken"]++;
							//%damagedClient.CorpseHitsTaken++;
							%corpsemsg = " **corpse MA**";
						}


						if($Roaming[%shooterClient] != "True")
						{
							eval( "%shooterClient." @ %PlayType @ "mah++;");
						}
						if(Client::getTeam(%shooterClient) == Client::getTeam(%damagedClient) && %shooterClient.Team != "" && damagedClient.Team != "")
						{
							%extramsg = "teammate ";
						}
						client::sendmessage(%shooterClient, 0, %wav);
						%message = Client::GetName(%shooterClient) @ " mid-aired "@%extramsg@""@ Client::GetName(%damagedClient) @ " from " @ %madistance @ " meters away with "@GetMidairWeap(%type) @ %corpsemsg ;
						if(%madistance < 100 && %shooterClient.Team != "" && damagedClient.Team != "")
						{
							%shooterClient.ThisRoundMidAirs[%type]++;
							%shooterClient.ThisRoundTotalMidAirs++;
							TMessage(%shooterClient.Team, %damagedClient.Team, $White, %message);
							return;
						}
						if(%madistance < 100 && %shooterClient.DM && %damagedClient.DM)
						{
							//TMessage(%shooterClient.Team, %damagedClient.Team, $White, %message);
							DeathMatch::Message($White, %message);
							return;
						}
						if(%madistance < 100 && $Dueling[%shooterClient] != "" &&  $Dueling[%damagedClient] != "")
						{
							bottomprint(%shooterClient, "<jc><f1>You mid-aired " @ Client::GetName(%damagedClient) @ " from<f2> " @ %madistance @ " <f1>meters away! ", 5);
							return;
						}
						if(%madistance >= 100)
						{
							messageall(0, %message);
							//remoteKingMe(%shooterClient,true);
							return;
						}
					}
				}
			//}
		}
		else {
			if(%shooterClient.debug)
			{
				client::sendmessage(%shooterClient, $White, "MA Failed type-value ("@%type@")-("@%value@")");
			}
		}
	}
	else {
		if(%shooterClient.debug)
		{
			client::sendmessage(%shooterClient, $White, "MA Last Contact failed ("@Player::getLastContactCount(%damagedPlayer)@")");
		}
	}

	%distance = floor(Vector::getDistance(GameBase::getPosition(%damagedPlayer), GameBase::getPosition(%shooterClient.owns)) + 0.5);
	%shooterClient.score[%PlayType, "GroundShots", %type]++;
	%shooterClient.score[%PlayType, "TotalGroundShotDistance", %type] += %distance;
	%shooterClient.score[%PlayType, "AverageGroundShot", %type] = %shooterClient.score[%PlayType, "TotalGroundShotDistance", %type]/%shooterClient.score[%PlayType, "GroundShots", %type] ;
	if(%distance > %shooterClient.score[%PlayType, "FurthestGroundShot", %type])
	{
		%shooterClient.score[%PlayType, "FurthestGroundShot", %type] = %distance;
	}
}

function GetMidairWeap(%num)
{
	if(%num == "3")
	{
		return "plasma!";
	}
	else if(%num == "4")
	{
		return "a disc!";
	}
	else if(%num == "5")
	{
		return "a grenade!";
	}
	else if(%num == "14")
	{
		return "a hand grenade!";
	}
	else if(%num == "7")
	{
		return "a mortar shell!";
	}
	else
	{
		return $ScoreWeapon[%num];
	}
}
function remoteBacon(%cl)
{
	%player = Client::getOwnedObject(%cl);
	%distance = 20;
	for(%angleX = -3.1459; %angleX < 3.1459; %angleX++)
	{
		for(%angleY = -3.1459; %angleY < 3.1459; %angleY++)
		{
			for(%angleZ = -3.1459; %angleZ < 3.1459; %angleZ++)
			{
				if(gamebase::getlosinfo(%player, %distance, %angleX@" "@%angleY@" "@%angleZ))
				{
					if(vector::getdistance($los::position, gamebase::getposition(%player)) > 1.5)
					{
						makebeaconthere(%player,$los::position,Vector::getRotation($los::normal));
					}
				}
			}
		}
	}
}
function makebeaconthere(%pl,%pos, %rot)
{
	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%pl));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%pos);
	Gamebase::setMapName(%beacon,"Target Beacon");
	Beacon::onEnabled(%beacon);
}
function NotTouching(%player, %distance, %client)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(NotTouching);
	}
	%angle[0] = "1.57 0 0";//above
	%angle[1] = "-1.57 0 0";//below
	%angle[2] = "0 0 1.57";//right
	%angle[3] = "0 0 -1.57";//left
	%angle[4] = "0 0 0";//front
	%angle[5] = "0 0 3.14";//behind

	for(%x = 0; %angle[%x] != ""; %x++)
	{
		resetlos();
		gamebase::getlosinfo(%player, %distance, %angle[%x]);
		%myobject = $los::object;

		if(%myobject != "")
		{
			%type = getObjectType(%myobject);
			%pos = $los::position;
			if(%type == "SimTerrain" || %type == "InteriorShape" || %type == "StaticShape")
			{
				if(%client.debug)
				{
					client::sendmessage(%client, $White, "MA object check failed["@%x@"] distance("@%distance@") objectID("@%myobject@") objectName("@Object::getName(%myobject)@") objectDataName("@GameBase::getDataName(%myobject)@") objectType("@getObjectType(%myobject)@") obj-playerDistance("@vector::getdistance(gamebase::getposition(%player), %pos)@")");
				}
					return false;
			}
		}

	}
	return true;
}
function VoteGraphic()
{
	if($curVoteTopic != "")
	{
		%line = Ratio();
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($curVoteTopic != "DMChange")
			{
				if(%cl.prefs["VoteGraphic"])
				{
					bottomprint(%cl, %line, 1);
				}
			}
			else
			{
				if($curVoteTopic == "DMChange")
				{
					if(%cl.prefs["VoteGraphic"] && %cl.DM)
					{
						bottomprint(%cl, %line, 1);
					}
				}
			}
		}
		schedule("VoteGraphic();", 0.5);
	}
}

function Ratio()
{
   %votesFor = 0;
   %votesAgainst = 0;
   %votesAbstain = 0;
   %totalClients = 0;
   %totalVotes = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(Time::getMinutes((floor(getSimTime()) - %cl.LastAction)) < 0.9)
	   {
		   if($curVoteTopic == "DMChange")
		   {
				if(%cl.DM)
				{
					%totalClients++;
					if(%cl.vote == "yes")
					{
						%votesFor++;
						%totalVotes++;
					}
					else if(%cl.vote == "no")
					{
						%votesAgainst++;
						%totalVotes++;
					}
					else
						%votesAbstain++;
				}
			}
			else
			{
				%totalClients++;
				if(%cl.vote == "yes")
				{
					%votesFor++;
					%totalVotes++;
				}
				else if(%cl.vote == "no")
				{
					%votesAgainst++;
					%totalVotes++;
				}
				else
				%votesAbstain++;
			}
		}
	}

	%red = (%votesAgainst / %totalClients)*100 ;
	%green = (%votesFor / %totalClients)*100 ;
	%white = (%votesAbstain / %totalClients)*100 ;
	if(%green > 4)
	{
		for(%x = 0; %x < %green+1; %x++)
		{
			%grn = %grn @"|" ;
		}
	}
	if(%red > 4)
	{
		for(%x = 0; %x < %red+1; %x++)
		{
			%rd = %rd @"|" ;
		}
	}
	if(%white > 4)
	{
		for(%x = 0; %x < %white+1; %x++)
		{
			%whte = %whte @"|" ;
		}
	}
	   if(%votesAbstain < %totalClients/2.5)
	   {

	   }
	   else if((%votesFor / %totalVotes) >= 0.525)
	   {
		   %pass = $PrintGreen@"Pass";
	   }
	   else {
		   %pass = $PrintRed@"Fail";
	   }
	return "<jc>"@$PrintWhite @"Vote - "@$curVoteTopic@"\n"@$PrintGreen@"For"@$PrintWhite@", "@$PrintRed@"Against"@$PrintWhite@", "@$PrintWhite@"Neutral\nStatus: "@%pass@"\n"@$PrintGreen @ %grn @ $PrintRed @ %rd @ $PrintWhite @ %whte ;
}



function TDMatchStatus()
{
	for(%x = 1; %x < 8; %x++)
	{
		if($TeamDuel::Name[%x] != "" && $TeamDuel::InMatch[%x] == "True")
		{
			return true;
			if($TeamDuel::Score[%x] != "0" && $TeamDuel::Score[$TeamDuel::Challenging[%x]] != "0")
			{
				%score = ($TeamDuel::Rounds[%x] + $TeamDuel::Rounds[$TeamDuel::Challenging[%x]])/($TeamDuel::Score[%x]+$TeamDuel::Score[$TeamDuel::Challenging[%x]]) ;
				if(%score <= 8.0)
				{
					return true;
				}
			}
		}
	}
	return false;
}
function AFKCheck()
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(AFKCheck);
	}
	return;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.LastAction == "" || %cl.LastAction == "False" || %cl.LastAction == "-1")
		{
			%cl.LastAction = floor(getSimTime());
		}
		%time = Time::getMinutes((floor(getSimTime()) - %cl.LastAction));
		if(%time > 9 && %cl.isSuperAdmin == "")
		{
		   messageall(1, Client::GetName(%cl)@" has been kicked for going AFK");
		   kick(%cl, "Stop going afk!.");
		   banlist::add(client::getTransportAddress(%cl), 1);
	   }
	}
	schedule("AFKCheck();", 300);
}
function processMenuchoosearmor(%cl, %option)
{
	$DuelarmorType[%cl] = %option;
	BottomPrint(%cl, "<F0>Armor set to: <F4>"@GetArmorString($DuelarmorType[%cl]), 2);
	if(%cl.Team != "")
	{
		%option = "loadoutsetup";
		processMenummisc(%cl, %option);
	}
	Game::MenuRequest(%cl);
}
function ArmorSetup(%clientId) {
       Client::buildMenu(%clientId, "Select your armor:", "choosearmor", true);//***
       if($ArmorToggle) {
               Client::addMenuItem(%clientId, "1Light Armor", larmor);
               Client::addMenuItem(%clientId, "2Medium Armor", marmor);
               Client::addMenuItem(%clientId, "3Heavy Armor", harmor);
       }
}
function GetArmorString(%string)
{
	%string = gw(%string,0);
	echo(%string);

	if(%string == "larmor")
	{
		return "Light Armor";
	}
	if(%string == "marmor")
	{
		return "Medium Armor";
	}
	if(%string == "harmor")
	{
		return "Heavy Armor";
	}
	if(%string == "Player's Choice" || %string == "Player's")
	{
		return "Player's Choice";
	}
	return "error";
}

function Blah(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Blah);
	}
	remoteEval(%clientId, "setInfoLine", 1, "Team Info");
	%line = 1;
	for(%i = 1; %i < 8 ; %i++)
	{
		if($TeamDuel::Name[%i] != "")
		{
			remoteEval(%clientId, "setInfoLine", %line++, $TeamDuel::Name[%i]@" Score: "@$TeamDuel::Score[%i]@" K/D: "@TotalKD(%i)@" Wins: "@$TeamDuel::Wins[%i]);
		}
		else
		{
			remoteEval(%clientId, "setInfoLine", %line++, "");
		}
	}
	return;



	remoteEval(%clientId, "setInfoLine", 2, $TeamDuel::Line2[%clientId.Team]);
	remoteEval(%clientId, "setInfoLine", 3, $TeamDuel::Line3[%clientId.Team]);
	if($TeamDuel::InMatch[%clientId.Team] == "True")
	{
		remoteEval(%clientId, "setInfoLine", 4, $TeamDuel::Line4[%clientId.Team]);
	}
	if($TeamDuel::Challenging[%clientId.Team] != "")
	{
		%Team = $TeamDuel::Challenging[%clientId.Team];
		remoteEval(%clientId, "setInfoLine", 5, $TeamDuel::Line5[%clientId.Team]);
		remoteEval(%clientId, "setInfoLine", 6, $TeamDuel::Line6[%clientId.Team]);
	}
}



function LogFunction(%name)
{
	$TDebugCount++;
	if($TDebugCount > 5000)
	{
		$ThisFunction = zadmin::getTimeStamp()@" clear";
		$TDebugCount = "0";
		export("$ThisFunction", "config\\TDebug.cs", false);
	}
	both("LogFunc: "@%name);
	//messageall(1, %name);
	$ThisFunction = zadmin::getTimeStamp()@" "@%name;
	export("$ThisFunction", "config\\TDebug.cs", true);
}
function KillBeacon(%beacon)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(KillBeacon);
	}
	if(GameBase::getDataName(%beacon) == "DefaultBeacon")
	{
		StaticShape::onDamage(%beacon,%type,1.05,%pos,%vec,%mom,%beacon);
	}
}
//
// TeamDuel Messaging Funcs
//
function WayPointThemOneLeft(%Team, %target)
{
	if($TeamDuel::Arena[%Team] == "None")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.Team == %team && %cl.IsAlive == "True" && %cl.prefs["autoWaypoint"])
			{
				%cl.haswpTarget = true;
				issueTargCommand(%cl, %cl, 1,"Waypoint set to "@client::getname(%target), (%target - 2048));
			}
		}
	}
}
function WayPointThemALL(%Team1, %Team2, %overwrite)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(WayPointThem);
	}
	if($TeamDuel::Arena[%Team1] == "None" && $TeamDuel::Arena[%Team2] == "None")
	{
	//both(%team1@" <-1 2-> "@%team2);

	//if(%overwrite)
	//{



	//%a = AmountAlive(%Team1);
	//%b = AmountAlive(%Team2);
	//if(getWord(%a, 0) == "1" || getWord(%b, 0) == "1" && %overwrite != "")
	//{
		//%message = "Waypoints will be added to the surviving players in 10 seconds.";
		//PrintTeam(%Team1@" "@%Team2, %message, bottom);//top, center, bottom
		//CompileCoords(%Team1, %Team2);

		%posX[%Team2] = getWord($TeamDuel::Compiled[%Team1],0);
		%posY[%Team2] = getWord($TeamDuel::Compiled[%Team1],1);

		%posX[%Team1] = getWord($TeamDuel::Compiled[%Team2],0);
		%posY[%Team1] = getWord($TeamDuel::Compiled[%Team2],1);

		//both($TeamDuel::Compiled[%Team1]);
		//both($TeamDuel::Compiled[%Team2]);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.Team == %Team1 && %cl.isAlive == "True" && %cl.prefs["autoWaypoint"] && !%cl.haswpTarget || %cl.Team == %Team2 && %cl.isAlive == "True" && %cl.prefs["autoWaypoint"] && !%cl.haswpTarget)
			{
				//%message = "Assigning waypoints to remaining players!";
				//TMessage(%Team1, %Team2, $Red, %message);
				issueCommand(%cl, %cl, 1, "Attack", %posX[%cl.Team], %posY[%cl.Team]);

			}

		}
	}
}
function MC()
{
	%group = "MissionGroup/Landscape";
	%numItems = Group::objectCount(%group);
	echo(%group@": "@%numitems@" "@nameToID(%group));

		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject(%group,%i);
			%name = GameBase::getDataName(%obj);
			%name1 = getObjectType(%obj);
			%name2 = object::getname(%obj);
			%pos = gamebase::Getposition(%obj);
			echo("List :"@%i+1 @"-"@%numitems@" obj: "@%obj@", "@%name@", "@%name1@", "@%name2@", pos: "@%pos);
			if(object::getname(%obj) == "MissionCenter")
			{
				gamebase::setposition(%obj, "1000 1000 1000");
				%pos = gamebase::Getposition(%obj);
				echo("!List :"@%i+1 @"-"@%numitems@" obj: "@%obj@", "@%name@", "@%name1@", "@%name2@", pos: "@%pos);
			}
		}
}

function OneLeftMessage(%team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(OneLeftMessage);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %team && %cl.IsAlive == "True")
		{
			%name = client::getname(%cl);
			%savedcl = %cl;
		}
	}
	if(%name != "" && $TeamDuel::RoundEnded[%team] != "true")
	{
		%message = $TeamDuel::Name[%team] @ " has one member left. ("@ %name @")" ;
		TMessage(%team, $TeamDuel::Challenging[%team], $Red, %message);
		//WayPointThemOneLeft($TeamDuel::Challenging[%team], %savedcl);
		echo(%message);
		return;
	}
	//echo("One left message aborted");
}

function GetPackString(%Team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetPackString);
	}
	if($TeamDuel::Packs[%Team] == "Player's Choice")
	{
		%string = "Player's Choice";
		return %string;
	}
	return $TeamDuel::Packs[%Team];
}

function GetWeaponString(%Team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetWeaponString);
	}
	%string = "error";
	if($TeamDuel::Weapons[%Team] == "Player's Choice")
	{
		%string = "Player's Choice";
		return %string;
	}
	if($TeamDuel::Weapons[%Team] == "DPN")
	{
		%string = "Disc Plasma Nade";
		return %string;
	}
	if($TeamDuel::Weapons[%Team] == "DCN")
	{
		%string = "Disc CG Nade";
		return %string;
	}
	if($TeamDuel::Weapons[%Team] == "DEN")
	{
		%string = "Disc Elf Nade";
		return %string;
	}
	if($TeamDuel::Weapons[%Team] == "DLN")
	{
		%string = "Disc Laser Nade";
		return %string;
	}
	if($TeamDuel::Weapons[%Team] == "DiscOnly")
	{
		%string = "Disc Only";
		return %string;
	}
	if($TeamDuel::Weapons[%Team] == "Custom")
	{
		//%string = $TeamDuel::CustomWeapons[%Team, 0]
		%string = gw($Duelweapon[gw($TeamDuel::CustomWeapons[%Team, 0],0)], 0);
		if(gw($TeamDuel::CustomWeapons[%Team, 1], 0) != "5" && gw($TeamDuel::CustomWeapons[%Team, 1], 0) != "6" && gw($TeamDuel::CustomWeapons[%Team, 1], 0) != "7")
		{
			%string = %string@"(x"@gw($TeamDuel::CustomWeapons[%Team, 0],1)@")";
		}
		if($TeamDuel::CustomWeapons[%Team, 1] != "-1" && $TeamDuel::CustomWeapons[%Team, 1] != "")
		{
			//both("2nd weap var not clear");
			%string = %string@" "@gw($Duelweapon[gw($TeamDuel::CustomWeapons[%Team, 1],0)], 0);
			if(gw($TeamDuel::CustomWeapons[%Team, 1], 0) != "5" && gw($TeamDuel::CustomWeapons[%Team, 1], 0) != "6" && gw($TeamDuel::CustomWeapons[%Team, 1], 0) != "7")
			{
				%string = %string@"(x"@gw($TeamDuel::CustomWeapons[%Team, 1],1)@")";
			}
		}
		if($TeamDuel::CustomWeapons[%Team, 2] != "" && $TeamDuel::CustomWeapons[%Team, 2] != "-1")
		{
			//both("3rd weap var not clear");
			%string = %string@" "@gw($Duelweapon[gw($TeamDuel::CustomWeapons[%Team, 2],0)], 0);
			if(gw($TeamDuel::CustomWeapons[%Team, 2], 0) != "5" && gw($TeamDuel::CustomWeapons[%Team, 2], 0) != "6" && gw($TeamDuel::CustomWeapons[%Team, 2], 0) != "7")
			{
				%string = %string@"(x"@gw($TeamDuel::CustomWeapons[%Team, 2],1)@")";
			}
		}
	}
	return %string;
}
//Thanks to whoever made this :p
function Arena::GetTeamScoresString(%winningteam, %Team1, %Team2)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Arena::GetTeamScoresString);
	}
	if (%winningteam == %Team1)
	{
		%team0score = $TeamDuel::Score[%Team1] + 1;
	}
	else
	{
		%team0score = $TeamDuel::Score[%Team1];
	}
	if (%winningteam == %Team2)
	{
		%team1score = $TeamDuel::Score[%Team2] + 1;
	}
	else
	{
		%team1score = $TeamDuel::Score[%Team2];
	}
	%tsstr = $TeamDuel::Name[%Team1] @ ": " @ %team0score @ ", " @
	$TeamDuel::Name[%Team2] @ ": " @ %team1score;
	return %tsstr;
}

function ChallengeSentM(%sender)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ChallengeSentM);
	}
		%a[%tmp++] = "<f1><JC>"@client::getname($TeamDuel::Leader[%sender]) @ " sent a challenge to "@$TeamDuel::Name[$TeamDuel::Challenging[%sender]]@"\n";
		%a[%tmp++] = "<F1>Rounds: [<F2>"@ $TeamDuel::Rounds[%sender] @"<F1>] \n" ;
		%a[%tmp++] = "<F1>Weapons: [<F2>"@ GetWeaponString(%sender) @"<F1>]\n" ;
		%a[%tmp++] = "<F1>Packs: [<F2>"@ GetPackString(%sender) @"<F1>]\n" ;
		%a[%tmp++] = "<F1>Armor: [<F2>"@GetArmorString($TeamDuel::Armor[%sender]) @"<F1>]\n" ;
		%a[%tmp++] = "<F1>Mines: [<F2>"@$TeamDuel::Mines[%sender] @"<F1>]\n" ;
	//	if($ArmorToggle)
	//	{
	//		%a[%tmp++] = "<F1>Armor: [<F2>"@GetArmorString($TeamDuel::Armor[%sender]) @"<F1>]\n" ;
	//	}
		%a[%tmp++] = "<F1>Arena: [<F2>"@ $TeamDuel::Arena[%sender] @"<F1>]\n" ;
		if($TeamDuel::Arena[%sender] != "None" && $TeamDuel::ArenaSpawn[%sender])
		{
			%a[%tmp++] = "<F1>Loadout Spawning: [<F2>"@$TeamDuel::ArenaSpawn[%sender] @"<F1>]\n" ;
		}
		if($TeamDuel::Arena[%sender] == "None")
		{
			%a[%tmp++] = "<F1>Random Spawning: [<F2>"@$TeamDuel::NewSpawns[%sender] @"<F1>]\n" ;
		}

		for(%i = 1; %a[%i] != ""; %i++)
			%message = %message @ %a[%i];

		//echo(%sender);
		PrintTeam(%sender, %message, center);//top, center, bottom
}


function ChallengeReceivedM(%receiver, %sender)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ChallengeReceivedM);
	}
		%a[%tmp++] = "<f1><JC>"@$TeamDuel::Name[%sender] @ " is challenging you!\n";
		%a[%tmp++] = "<F1>Rounds: [<F2>"@ $TeamDuel::Rounds[%sender] @"<F1>] \n" ;
		%a[%tmp++] = "<F1>Weapons: [<F2>"@ GetWeaponString(%sender) @"<F1>]\n" ;
		%a[%tmp++] = "<F1>Packs: [<F2>"@ GetPackString(%sender) @"<F1>]\n" ;
		%a[%tmp++] = "<F1>Armor: [<F2>"@GetArmorString($TeamDuel::Armor[%sender]) @"<F1>]\n" ;
		%a[%tmp++] = "<F1>Mines: [<F2>"@$TeamDuel::Mines[%sender] @"<F1>]\n" ;
		if($ArmorToggle)
		{
			%a[%tmp++] = "<F1>Armor: [<F2>"@GetArmorString($TeamDuel::Armor[%sender]) @"<F1>]\n" ;
		}
		%a[%tmp++] = "<F1>Arena: [<F2>"@ $TeamDuel::Arena[%sender] @"<F1>]\n" ;
		if($TeamDuel::Arena[%sender] != "None" && $TeamDuel::ArenaSpawn[%sender])
		{
			%a[%tmp++] = "<F1>Loadout Spawning: [<F2>"@$TeamDuel::ArenaSpawn[%sender] @"<F1>]\n" ;
		}
		if($TeamDuel::Arena[%sender] == "None")
		{
			%a[%tmp++] = "<F1>Random Spawning: [<F2>"@$TeamDuel::NewSpawns[%sender] @"<F1>]\n" ;
		}


		for(%i = 1; %a[%i] != ""; %i++)
			%message = %message @ %a[%i];

		PrintTeam(%receiver, %message, center);//top, center, bottom
}


function TMessage(%Team1, %Team2, %color, %message, %all)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TMessage);
	}
	if(%all == 1)
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.Team != "" || %cl.observertarget.Team != "")
			{
				client::sendmessage(%cl, %color, %message);
			}
		}
		return;
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %Team1 || %cl.Team == %Team2 || %cl.observertarget.Team == %Team2 || %cl.observertarget.Team == %Team1)
		{
			client::sendmessage(%cl, %color, %message);
		}
	}
}


function PrintTeam(%Teams, %message, %print)//top, center, bottom
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(PrintTeam);
	}
	for(%x = 0; gw(%Teams,%x) != -1; %x++)
	{
		%Team[%x] = gw(%Teams,%x);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		for(%x = 0; %Team[%x] != ""; %x++)
		{
			if(%cl.Team == %Team[%x])
			{
				if(%print == "top")
				{
					TopPrint(%cl, %message, 8);
				}
				if(%print == "center")
				{
					CenterPrint(%cl, %message, 10);
				}
				if(%print == "bottom")
				{
					BottomPrint(%cl, %message, 8);
				}
			}
		}
	}
}

//
//Counting Scripts...
//

function GetTeamPlayerCount(%team)
{
	if(%Team == "")	{		return echo("False GetTeamPlayerCount");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetTeamPlayerCount);
	}
	%count = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %team)
		{
			%count++;
		}
	}
	return %count;
}


function CheckChallenges(%team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckChallenges);
	}
	%amount = 0;
	for(%i= 1 ; %i < 9; %i++)
	{
		if($TeamDuel::Challenging[%i] == %team)
		{
			%amount++;
		}
	}
	return %amount;
}


function CheckJoiners(%team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckJoiners);
	}
	%amount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.TeamJoining == %team && $Dueling[%cl] == "")
		{
			%amount++;
		}
	}
	return %amount;
}


function CheckTradeStatus(%team, %breakit)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckTradeStatus);
	}
	%count = 0;
	for(%i= 0 ; %i < 19; %i++)
	{
		if($TeamDuel::Trading::Offer[%i, %team] != "")
		{
			%count++;
			if(%breakit != "" && %breakit != "-1")
			{
				return true;
			}
		}
	}
	return %count;
}

function NotInviting(%team, %client)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(NotInviting);
	}
	for(%j= 1 ; %j < 15; %j++)
	{
		if($TeamDuel::Inviting[%team, %j] == %client)
		{
			return false;
		}
	}
	return true;
}
function CheckInviteCount(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckInviteCount);
	}
	%amount = 0;
	for(%i= 1 ; %i < 9; %i++)
	{
		if($TeamDuel::Name[%i] != "")
		{
			for(%j= 1 ; %j < 15; %j++)
			{
				if($TeamDuel::Inviting[%i, %j] == %clientId)
				{
					%amount++;
				}
			}
		}
	}
	return %amount;
}

function CheckUnLockedTeams(%quota)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckUnLockedTeams);
	}
	%amount = 0;
	for(%i= 1 ; %i < 10; %i++)
	{
		if($TeamDuel::Locked[%i] == "" && $TeamDuel::Name[%i] != "")
		{
			%amount++;
			if(%amount == %quota)
			{
				return true;
			}
		}
	}
	if(%quota == "")
	{
		return %amount;
	}
	else {
		return false;
	}
}


function CheckTotalTeams(%quota)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckTotalTeams);
	}
	%amount = 0;
	for(%i= 1 ; %i < 10; %i++)
	{
		if($TeamDuel::Name[%i] != "")
		{
			%amount++;
			if(%amount == %quota)
			{
				return true;
			}
		}
	}
	if(%quota == "")
	{
		return %amount;
	}
	else {
		return false;
	}
}

function TotalMA(%Team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TotalMA);
	}
	%count = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %Team)
		{
			%count = (%count + %cl.DLmah);
		}
	}
	return %count;
}

function TotalKD(%Team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TotalKD);
	}
	%score = 0;
	%death = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %Team)
		{
			%score = (%score + %cl.score[TD, "scoreKillsTotal"]);
			%death = (%death + %cl.Score[TD, "scoreDeathsTotal"]);
		}
	}
	return %score@"/"@%death ;
}

function AmountAlive(%Team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(AmountAlive);
	}
	%count = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %Team)
		{
			if(%cl.IsAlive == "True")
			{
				%count++;
				%alive = %cl;
			}
		}
	}

	return %count@" "@%alive;
}

//deletes the invite
function InviteCheck(%team, %slot, %clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(InviteCheck);
	}
	if($TeamDuel::Inviting[%team, %slot] == %clientId)
	{
		$TeamDuel::Inviting[%team, %slot] = "";
		if(CheckInviteCount(%clientId) == "0")
		{
			client::sendmessage(%clientId, 1, "Your invite from "@client::getname($TeamDuel::Leader[%team])@" has expired.~werror_message.wav");
			client::sendmessage($TeamDuel::Leader[%team], 1, "Your invite to "@client::getname(%clientId)@" has expired.");
			%clientId.hasInvite = false;
		}
	}
}

//
//Spawning and deleting pillars
//should work great now


function SpawnIt(%spawn)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SpawnIt);
	}
	%class="InteriorShape";
	%type= %spawn;
	%name = %spawn;
	%spawn = newObject(%name,%class,%type,true);
	addToSet("MissionCleanup", %spawn);
	return %spawn;
}
function Delete(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Delete);
	}
	for(%i= -1 ; %i < 10; %i++)
	{
		if($TeamDuel::SpawnedItem[%clientId.Team, %i] != "")
		{
			if(string::findSubStr(Object::getName($TeamDuel::SpawnedItem[%clientId.Team, %i]), ".dis") != "-1" )
			{
				deleteObject($TeamDuel::SpawnedItem[%clientId.Team, %i]);
				gamebase::setposition($TeamDuel::SpawnedItem[%clientId.Team, %i], "-1000 1000 -6000");
				$TeamDuel::SpawnedItem[%clientId.Team, %i] = "";
			}
		}
	}
	//deletevariables("$TeamDuel::SpawnedItem[*");
//	messageall(1, %amount @" objects deleted");
}



//
//Misc Reset Functions
//
function SecondaryClear(%Team1, %Team2, %nono)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False SecondaryClear");	}
	$ArenaInUse[$TeamDuel::Arena[%Team1], $TeamDuel::ArenaNum[%Team1]] = false;
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SecondaryClear);
	}
	//DuelMOD::missionObjectives();
	if($TeamDuel::Arena[%Team1] == "None" || $TeamDuel::Arena[%Team2] == "None")
	{
		//deleteSensors(%Team1, %Team2);
	}
	if(%Team1 != "")
	{
		schedule("$TeamDuel::Abort["@%Team1@"] = false;", 6.0);
		%client1 = $TeamDuel::Leader[%Team1];
		$DuelSpawnMarker[%Team1] = "";
		$DuelSpotTaken[$DuelSpotIndex[%client1]] = false;
		$DuelSpotIndex[%client1] = "";
		$TeamDuel::ArenaStatus[$TeamDuel::Arena[%Team1]] = "Free";
	}
	if(%Team2 != "")
	{
		schedule("$TeamDuel::Abort["@%Team2@"] = false;", 6.0);
		%client2 = $TeamDuel::Leader[%Team2];
		$DuelSpawnMarker[%Team2] = "";
		$DuelSpotTaken[$DuelSpotIndex[%client2]] = false;
		$DuelSpotIndex[%client2] = "";
		$TeamDuel::ArenaStatus[$TeamDuel::Arena[%Team2]] = "Free";
	}

		if($TeamDuel::Score[%Team2] == $TeamDuel::Score[%Team1])
		{
			%message2 = "It ended in a tie.";
		}
		if($TeamDuel::Score[%Team1] > $TeamDuel::Score[%Team2])
		{
			%message2 = $TeamDuel::Name[%Team1] @" wins." ;
					$TeamDuel::Wins[%Team1]++;
					$TeamDuel::Losses[%Team2]++;
		}
		if($TeamDuel::Score[%Team2] > $TeamDuel::Score[%Team1])
		{
			%message2 = $TeamDuel::Name[%Team2] @" wins." ;
			$TeamDuel::Wins[%Team2]++;
			$TeamDuel::Losses[%Team1]++;
		}

	%message = "The match between "@ $TeamDuel::Name[%Team1] @" and "@ $TeamDuel::Name[%Team2] @" has been aborted. "@ %message2 ;
	if(%nono == "" && %Team1 != "" && %Team2 != "")
	{
		TMessage(666, 666,  $Red, %message, 1);
	}
	if(%Team1 != "")
	{
		$TeamDuel::Challenging[%Team1] = "";
		$TeamDuel::Score[%Team1] = "0";
		$TeamDuel::InMatch[%Team1] = "";
		$TeamDuel::Arena[%Team1] = "None";
		Delete($TeamDuel::Leader[%Team1]);
		$TeamDuel::Start[%Team1] = "";
	}
	if(%Team2 != "")
	{
		$TeamDuel::Challenging[%Team2] = "";
		$TeamDuel::Score[%Team2] = "0";
		$TeamDuel::InMatch[%Team2] = "";
		$TeamDuel::Arena[%Team2] = "None";
		Delete($TeamDuel::Leader[%Team2]);
		$TeamDuel::Start[%Team2] = "";
	}
	ClearSpawns(%Team1, %Team2);
	ForceObserver(%Team1, %Team2);
	echo("Secondary Clear Called");
}





function ClearInvites(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ClearInvites);
	}
	for(%i= 1 ; %i < 10; %i++)
	{
		for(%j= 0 ; %j < 10; %j++)
		{
			if($TeamDuel::Inviting[%i, %j] == %clientId)
			{
				$TeamDuel::Inviting[%i, %j] = "";
			}
		}
	}
}


function ClearSpawns(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False SecondaryClear");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ClearSpawns);
	}
	for(%i= 0 ; %i < 20; %i++)
	{
		$TeamDuel::Spawn[%Team1, %i] = "";
		$TeamDuel::SpawnRot[%Team1, %i] = "";
		$TeamDuel::Spawn[%Team2, %i] = "";
		$TeamDuel::SpawnRot[%Team2, %i] = "";
	}
	$TeamDuel::RealTeam[%Team1] = "";
	$TeamDuel::RealTeam[%Team2] = "";
}


function deleteteam(%i)
{
	if(%i == "")	{		return echo("False deleteteam");	}
	if($TeamDuel::Name[%i] != "")
	{
		$TeamDuel::TotalTeams--;
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(deleteteam);
	}
	if($TeamDuel::InMatch[%i] == "True")
	{
		if($TeamDuel::Challenging[%i] == 0)
		{
			Multiteam::RemoveTeam(%i);
		}
		SecondaryClear(%i, $TeamDuel::Challenging[%i]);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %i && %i != "")
		{
			%cl.Team = "";
			%cl.Naming = "";
			%cl.TeamJoining = "";
			%cl.Arena = "";
			%cl.notready = "";
			%cl.Owns = "";
			%cl.IsAlive = "";
			%cl.guiLock = false;
			%cl.TD = "";
			//%cl.observerMode = "";
			if($TeamDuel::InMatch[%i] == "True")
			{
				ForceOneObs(%cl);
			}
			Game::refreshClientScore(%cl);
		}
	}
	$TeamDuel::Skin[%i] = "";
	$TeamDuel::CanHurt[%i] = "";
	$TeamDuel::Name[%i] = "";
	$TeamDuel::Leader[%i] = "";
	$TeamDuel::Arena[%i] = "";
	$TeamDuel::Weapons[%i] = "";
	$TeamDuel::Packs[%i] = "";
	$TeamDuel::Rounds[%i] = "";
	$TeamDuel::Time[%i] = "";
	$TeamDuel::Challenging[%i] = "";
	$TeamDuel::Spawns[%i] = "";
	$TeamDuel::Wins[%i] = "";
	$TeamDuel::Start[%i] = "";
	$TeamDuel::Score[%i] = "";
	$TeamDuel::MatchesLost[%i] = "";
	$TeamDuel::MatchesWon[%i] = "";
	$TeamDuel::Losses[%i] = "";
	$TeamDuel::Ticker[%i] = "";
	$TeamDuel::Clients[%i] = "";
	$TeamDuel::LeftOff[%i] = "";
	$TeamDuel::RealTeam[%i] = "";
	$TeamDuel::Mines[%i] = "";
	$TeamDuel::Line2[%i] = "";
	$TeamDuel::Line3[%i] = "";
	$TeamDuel::Line4[%i] = "";
	$TeamDuel::Line5[%i] = "";
	$TeamDuel::Line6[%i] = "";
//	$TeamDuel::Sensor[%i] = "";
	$TeamDuel::InMatch[%i] = "";
	$TeamDuel::Locked[%i] = "";
	$TeamDuel::ArenaSpawn[%i] = "";
	$TeamDuel::Abort[%i] = "";
	$TeamDuel::Armor[%i] = "";
	$TeamDuel::NewSpawns[%i] = "";
	for(%j= 0 ; %j < 30; %j++)
	{
		$TeamDuel::Weapon[%i, %j] = "";
		$TeamDuel::Inviting[%i, %j] = "";
		$TeamDuel::Spawn[%i, %j] = "";
		$TeamDuel::SpawnRot[%i, %j] = "";
		if($TeamDuel::SpawnedItem[%i, %j] != "")
		{
			gamebase::setposition($TeamDuel::SpawnedItem[%i, %j], "-1000 1000 -6000");
		}
		$TeamDuel::SpawnedItem[%i, %j] = "";
		$TeamDuel::Trade[%i, %j] = "";
	}
	$TeamDuel::TotalTeams = CheckTotalTeams();

}
function DudeReset(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DudeReset);
	}

	if(%clientId.Team != "")
	{
		LeaveTeam(%clientId);
	}
}
function LeaveTeam(%clientId)
{
	if(%clientId.Team != "")
	{
		if($TDebug && $TeamDuel::Master)
		{
			LogFunction(LeaveTeam);
		}
		if($TeamDuel::Leader[%clientId.Team] == %clientId)
		{
			NextLeader(%clientId.Team);
		}

		if($TeamDuel::Challenging[%clientId.Team] == "0" && %clientId.isAlive == "True")
		{
			MultiTeamduel::Client::OnKilled(%clientId, %clientId);
			%clientId.Team = "";
			%clientId.Naming = "";
			%clientId.TeamJoining = "";
			%clientId.Arena = "";
			%clientId.notready = "";
			%clientId.Owns = "";
			%clientId.IsAlive = "";
			%clientId.TD = "";
			%clientId.guiLock = false;
			Client::setGuiMode(%clientId, $GuiModePlay);
			Game::refreshClientScore(%clientId);
			return;
		}

		if(GetTeamPlayerCount(%clientId.Team) <= 1)
		{
			if($TeamDuel::InMatch[%clientId.Team] == "True")
			{
				SecondaryClear(%clientId.Team, $TeamDuel::Challenging[%clientId.Team]);
			}
		}
		if(getword(AmountAlive(%clientId.Team), 0) == "1" && %clientId.Team != "" && %clientId.IsAlive == "True")
		{
			EndRound(%clientId.Team, $TeamDuel::Challenging[%clientId.Team]);
		}
		if($TeamDuel::InMatch[%clientId.Team] == "True" && %clientId.IsAlive == "True")
		{
			ForceOneObs(%clientId);
		}
		%clientId.Team = "";
		%clientId.Naming = "";
		%clientId.TeamJoining = "";
		%clientId.Arena = "";
		%clientId.notready = "";
		%clientId.Owns = "";
		%clientId.IsAlive = "";
		%clientId.TD = "";
		%clientId.guiLock = false;
		Client::setGuiMode(%clientId, $GuiModePlay);
		Game::refreshClientScore(%clientId);
	}
}
//
//redundant checks
//
function NextLeader(%team)
{
	echo("nextLeader");
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(NextLeader);
	}
	schedule("TeamLeaderCheck(" @ %team @ ");", 0.5);
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.team == %team)
		{
			if($TeamDuel::Leader[%team] != %cl)
			{
				%message = client::getname($TeamDuel::Leader[%team]) @ " has been replaced as leader of the team " @ $TeamDuel::Name[%team] @ " by " @ Client::GetName(%cl) ;
				TMessage(666, 666,  $Green, %message, 1);
				$TeamDuel::Leader[%team] = %cl;
				return;
			}
		}
	}
}
function TeamLeaderCheck(%team)
{
	echo("TeamLeaderCheck");
	if(%team == "")	{		return echo("False TeamLeaderCheck");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TeamLeaderCheck);
	}
	%him = $TeamDuel::Leader[%team];
	if(GetTeamPlayerCount(%team) <= "0")
	{
		if($TeamDuel::Name[%team] != "")
		{
			%message = "The " @ $TeamDuel::Name[%team] @ " team was automatically deleted." ;
			TMessage(666, 666,  $Red, %message, 1);
		}
		deleteteam(%team);
		return;
	}
	if(client::getname($TeamDuel::Leader[%team]) == "" || $TeamDuel::Name[%team] == "" || $TeamDuel::Leader[%team].team != %team)
	{
		NextLeader(%team);
	}
}
function kickcheck(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(kickcheck);
	}
	//messageall(1, "kickcheck");
	%clientId.IsAlive = "";
	ForceOneObs(%clientId);
	if(%clientId.Team != "")
	{
		if(getword(AmountAlive(%clientId.Team), 0) == "0" && $TeamDuel::InMatch[%clientId.Team] == "True")
		{
			ECHO("Kick Check Called.. attempting to end the round");
			%message = "<jc>" @ $TeamDuel::Name[$TeamDuel::Challenging[%playerId.Team]] @ " has won the game\n\n\n" @ Arena::GetTeamScoresString($TeamDuel::Challenging[%playerId.Team], $TeamDuel::Challenging[%playerId.Team], %playerId.Team) @".";
			PrintTeam(%clientId.Team@" "@$TeamDuel::Challenging[%clientId.Team], %message, center);//top, center, bottom
			$TeamDuel::Score[$TeamDuel::Challenging[%clientId.Team]]++;
			$TeamDuel::CanHurt[%clientId.Team] = "";
			$TeamDuel::CanHurt[$TeamDuel::Challenging[%clientId.Team]] = "";
			schedule("EndRound($TeamDuel::Challenging["@ %clientId.Team @"], "@ %clientId.Team @");", 3.5);
		}
	}
}

// 1.50 PORT: the upstream body of this function hardcoded 26 real player handles --
// the =Argh!= operator's own friends list. Nothing in the mod reads $Friends, so it
// was dead data as well as other people's names in a published pack. Emptied.
// A host who wants the list back can fill it in the same shape (names 0..n-1, then
// $Friends = n), or better, put it in config\serverConfig.cs so a pack update does
// not overwrite it.
function makeFriends()
{
	%a = 0;
	$Friends = %a;
}
makeFriends();



function CheckFriend(%name)
{
	for(%i= 0 ; %i < $Friends+1; %i++)
	{
		if($Friends[%i] != "" && $Friends[%i] == %name)
		{
			return true;
		}
	}
	return false;
}

function TDDuelReset(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TDDuelReset);
	}
	%clientId.Team = "";
	%clientId.Naming = "";
	%clientId.TeamJoining = "";
	%clientId.Owns = "";
	%clientIdIsAlive = "";
}
function deleteSensors(%Team1, %Team2)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(deleteSensors);
	}
	if($TeamDuel::Sensor[%Team1] != "" && isObject($TeamDuel::Sensor[%Team1]) && $TeamDuel::Sensor[%Team2] != "" && isObject($TeamDuel::Sensor[%Team2]))
	{
		deleteObject($TeamDuel::Sensor[%Team1]);
		deleteObject($TeamDuel::Sensor[%Team2]);
	}
//	$TeamDuel::Sensor[%Team1] = "";
//	$TeamDuel::Sensor[%Team2] = "";
}
//$TeamDuel::Sensor[1] = makesensor();
function moveSensorsxxx(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False moveSensors");	}
	gamebase::setteam($TeamDuel::Sensor[%Team1], $TeamDuel::RealTeam[%Team1]);
	gamebase::setteam($TeamDuel::Sensor[%Team2], $TeamDuel::RealTeam[%Team2]);
	//%pos = floor(vector::add(gamebase::getposition($TeamDuel::Leader[%Team1]), gamebase::getposition($TeamDuel::Leader[%Team2])));
	//%pos = (getword(%pos, 0)/2) @ " " @ (getword(%pos, 1)/2)+5 @ " " @ (getword(%pos, 2)/2)+1000 ;
	%pos = $TeamDuel::Compiled[%Team2];
	%pos = (getword(%pos, 0)) @ " " @ (getword(%pos, 1))+5 @ " " @ (getword(%pos, 2))+1200 ;
	gamebase::setposition($TeamDuel::Sensor[%Team1], %pos);
	%pos = $TeamDuel::Compiled[%Team1];
	%pos = (getword(%pos, 0)) @ " " @ (getword(%pos, 1))+5 @ " " @ (getword(%pos, 2))+1200 ;
	gamebase::setposition($TeamDuel::Sensor[%Team2], %pos);
	//%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)-10 @ " " @ getword(%pos, 2) ;
	//gamebase::setposition($TeamDuel::Sensor[%Team2], %pos2);
	//echo($TeamDuel::Sensor[%Team1]@".. sensors moved "@%pos);
}

function MyVector::Add(%pos1,%pos2)
{
	%pos = Getword(%pos1, 0)+Getword(%pos2, 0)@" "@Getword(%pos1, 1)+Getword(%pos2, 1)@" "@Getword(%pos1, 2)+Getword(%pos2, 2) ;
	return %pos;
}

function moveSensors(%Teams)
{
	echo("MOVING SENSORS!! "@%Teams);
	for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
	{
		%Team[%x] = gw(%Teams,%x-1);
	}
	%sensoroffset[0] = "0 0 400";
	%sensoroffset[1] = "0 1024 400";
	%sensoroffset[2] = "1024 0 400";
	%sensoroffset[3] = "0 -1024 400";
	%sensoroffset[4] = "-1024 0 400";

	for(%x = 1; %x < 6; %x++)
	{
		for(%a = 1; %Team[%a] != ""; %a++)
		{
			if(%x == %Team[%a])
			{
				%Lpos = gamebase::getposition($TeamDuel::Leader[%Team[%a]]);
				for(%y = 0; %y != 5; %y++)
				{
					gamebase::setteam($TeamDuel::Sensor[%x, %y],  $TeamDuel::RealTeam[%Team[%a]]);
					GameBase::setActive($TeamDuel::Sensor[%x, %y],true);
					%pos = MyVector::Add(%Lpos, %sensoroffset[%y]);
					%npos = MyVector::Add(%pos, getrandom()*50@" "@getrandom()*50@" "@getrandom()*50);
					echo("L pos: "@%lpos@" new pos: "@%pos@" new new: "@%npos@" TEAM: "@ %Team[%a]);
					gamebase::setposition($TeamDuel::Sensor[%x, %y], %pos);
				}
			}
		}
	}
}
$startup = true;
function BeforenewObject(%obj, %class, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7, %arg8, %arg9, %arg10, %arg11, %arg12)
{
	if($startup)
	{
		//Projectile::spawnProjectile("LestatShell2", %trans, %player, "0 0 0");
		//@", "@%arg7@", "@%arg8@", "@%arg9@", "@%arg10@", "@%arg11@", "@%arg12;
		//export("$testnewob*", "config\\newobjectlist.cs". true);

		$testnewob[$newobcount++] = %obj@" "@%class@" "@%arg2@" "@%arg3@" "@%arg4@" "@%arg5@" "@%arg6;
		//echo("new object: "@$testnewob[$newobcount]);
	}
}

function dogshit()
{
	for(%i= 0 ; %i < $newobcount; %i++)
	{
		$slowmode = $testnewob[%i];
		echo("exportt");
		export("$*", "config\\newobjectlist.cs". true);
	}
}
//Attachment::AddBefore("newObject","BeforenewObject");
//Attachment::AddBefore("spawnProjectile","BeforespawnProjectile");
//Attachment::AddBefore("client::getname","BeforeCgetname");
//Attachment::AddAfter("spawnProjectile","BeforespawnProjectile");


//Attachment::AddAfter("schedule","afterschedule");
function afterschedule(%arg1, %arg2, %arg3, %arg4)
{
	echo("Scheduler: "@%arg1@", "@%arg2@", "@%arg3@", "@%arg4);
}

function BeforespawnProjectile()
{
	//Projectile::spawnProjectile("LestatShell2", %trans, %player, "0 0 0");
	echo("Pre-d!");
}

function MakeSensors()
{
	for(%x = 1; %x < 6; %x++)
	{
		for(%y = 0; %y != 5; %y++)
		{
			//echo(%x @" "@%y);
			$TeamDuel::Sensor[%x, %y] = makesensor();
		}
	}
	echo("Making Sensors");
}
function TowerSwitch:onCollision(%this,%object)
{
		//%armor = Player::getArmor(%object);
}
function TowerSwitch::onCollision(%this, %object)
{
	%client = Player::getClient(%object);
	if(getObjectType(%object) == "Player" && gamebase::getteam(%this) != gamebase::getteam(%client))
	{
		messageall(1, client::getname(%client)@" has taken the objective for the "@$TeamDuel::Name[%client.Team]@" team!~wCapturedTower.wav");
		gamebase::setteam(%this, gamebase::getteam(%client));
	}

	return;

   $numCaps++;
   if(getObjectType(%object) != "Player")
      return;

   if(Player::isDead(%object))
      return;

   if(Player::getClient(%object) != Client::getFirst())
      return;

   %playerTeam = GameBase::getTeam(%object);
   %otherTeam = GameBase::getTeam(%this);

   if(%otherTeam == %playerTeam)
      return;

   for(%k = 1; %k <= $numSwitches; %k++)
   {
     if($SwitchObject[%k] == %this)
     {
        %switchNum = %k;
     }
   }
   if(%playerTeam == 0 )
   {
     if($SwitchObject[$currentWay] != %this)
     {
     	TowersTraining::wrongObjective(%this, %object);
     	return;
     }

     if($currentWay == 1)
	   $towerTime1 =  getSimTime();
	 else if($currentWay == 2)
	   $towerTime2 = getSimTime();
	 else
	   $towerTime3 = getSimTime();

     %this.trainingObjectiveComplete = true;
     %playerClient = Player::getClient(%object);
     %touchClientName = Client::getName(%playerClient);
   	 %group = "MissionGroup\\Towers\\tower" @ $currentWay;

     //set all objects to players team.
     for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
     {
       GameBase::setTeam(%obj, %playerTeam);
     }
	 messageAll(0, "~wCapturedTower.wav");

	 if($numToComplete == 1)
	   %time = 0;
	 else
	   %time = 5;

	 schedule("bottomprint(" @ %playerClient @ ", \"<f1><jc>Objective " @ $currentWay @ " has been accomplished!\", 5);", %time);
     ObjectiveMission::objectiveChanged(%this, false);
	 towers::teamMissionObjectives(%switchNum, false);

   }
   else if(%playerTeam == 1)
   {
     bottomprint(%playerClient, "<f1><jc>The enemy has taken one of your towers!", 5);
     schedule("bottomprint(" @ %playerClient @ ", \"<f1><jc>You must go back and claim the tower before you can win the mission!\", 5);", 5);
	 messageAll(0, "~wCapturedTower.wav");

	 //set all objects to opposite team , Ai's Team.
     %group = nameToId("MissionGroup\\Towers\\tower" @ %switchNum);
     for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
     {

       GameBase::setTeam(%obj, %playerTeam);
     }

     ObjectiveMission::objectiveChanged(%this, true);
	 towers::teamMissionObjectives(%switchNum, true);
   }
}
function makesensor()
{
	%temp = newObject("PulseSensor","Sensor","PulseSensor",true);
	addToSet("MissionCleanup",%temp);
	GameBase::setActive(%temp,14);
	GameBase::playSequence(%temp,0,power);
	GameBase::startFadeOut(%temp);
	gamebase::setposition(%temp, "-50 50 -250");
	//both("sensor made: "@%temp);
	return %temp;
}
function Ticker(%f, %e)
{
	if($TeamDuel::Ticker[%f] || $TeamDuel::Ticker[%e])
	{
		$TeamDuel::Ticker[%f] = false;
		$TeamDuel::Ticker[%e] = false;
		return;
	}
	if(!$TeamDuel::Ticker[%f] || !$TeamDuel::Ticker[%e])
	{
		$TeamDuel::Ticker[%f] = true;
		$TeamDuel::Ticker[%e] = true;
		return;
	}
	//echo("Ticker??");
}



function CompileCoords(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False CompileCoords");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetTotalCoords);
	}
	%x[%Team1] = 0;
	%y[%Team1] = 0;
	%z[%Team1] = 0;

	%x[%Team2] = 0;
	%y[%Team2] = 0;
	%z[%Team2] = 0;

	%count[%Team1] = 0;
	%count[%Team2] = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.team == %Team1 && %cl.IsAlive == "True" || %cl.team == %Team2 && %cl.IsAlive == "True" )
		{
			%pos = gamebase::getposition(%cl);
			%x[%cl.team] = (%x[%cl.team] + getWord(%pos, 0)) ;
			%y[%cl.team] = (%y[%cl.team] + getWord(%pos, 1)) ;
			%z[%cl.team] = (%z[%cl.team] + getWord(%pos, 2)) ;
			%count[%cl.team]++;
		}
	}
	$TeamDuel::Compiled[%Team1] = (%x[%Team1]/%count[%Team1])@" "@(%y[%Team1]/%count[%Team1])@" "@(%z[%Team1]/%count[%Team1]) ;
	$TeamDuel::Compiled[%Team2] = (%x[%Team2]/%count[%Team2])@" "@(%y[%Team2]/%count[%Team2])@" "@(%z[%Team2]/%count[%Team2]) ;
}

function GetTotalCoords(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False GetTotalCoords");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetTotalCoords);
	}
	%x = 0;
	%y = 0;
	%z = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.team == %Team1 && %cl.IsAlive == "True" || %cl.team == %Team2 && %cl.IsAlive == "True" )
		{
			%pos = gamebase::getposition(%cl);
			%x = (%x + getWord(%pos, 0)) ;
			%y = (%y + getWord(%pos, 1)) ;
			%z = (%z + getWord(%pos, 2)) ;
			%count++;
		}
	}
	return (%x/%count)@" "@(%y/%count)@" "@(%z/%count) ;
}

function GetTotalLeaderCoords(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False GetTotalLeaderCoords");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetTotalLeaderCoords);
	}

	%pos = gamebase::getposition($TeamDuel::Leader[%Team1]);
	%x = getWord(%pos, 0) ;
	%y = getWord(%pos, 1) ;
	%z = getWord(%pos, 2) ;

	%pos = gamebase::getposition($TeamDuel::Leader[%Team2]);
	%x = (%x + getWord(%pos, 0)) ;
	%y = (%y + getWord(%pos, 1)) ;
	%z = (%z + getWord(%pos, 2)) ;

	return (%x/2)@" "@(%y/2)@" "@(%z/2) ;
}
function JamDueler(%player)
{
	echo("jammin");
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(JamDueler);
	}
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}
function newJamDueler(%player, %nrate)
{
	echo("jammin");
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(JamDueler);
	}
	both("current rate: "@Player::getSensorSupression(%player));
	%rate = Player::getSensorSupression(%player) + %nrate;
	Player::setSensorSupression(%player,%rate);
}
function GetObservedList(%client)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(GetObservedList);
	}
	%list = "";
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(%cl.observerTarget == %client)
	   {
		   %extra = "<F2>";
		   if(%client.Team != "" && %cl.Team != "" && $TeamDuel::InMatch[%client.Team] == "True")
		   {
			   if(%cl.Team != %client.Team)
			   {
				   %extra = "<F0>";
			   }
			   if(%cl.Team == %client.Team)
			   {
				   %extra = "<F1>";
			   }
		   }
		   if(%first == "" && Client::Getname(%cl) != "")
		   {
			   %list = %extra@""@Client::Getname(%cl);
			   %first = "meh";
		   }
		   else {
			   if(Client::Getname(%cl) != "")
			   {
					%list = %list @"<F2>, "@%extra@""@Client::Getname(%cl) ;
				}
			}
		}
	}
	return %list;
}



function Veto(%clientId)
{
   if(%clientId.isSuperAdmin)
   {
	   if($curVoteTopic != "")
	   {
		   $Veto = "True";
		   messageAll(1, Client::getName(%clientId) @ " vetoed the vote. ("@$curVoteTopic@")");
	   }
   }
}

$loaded["TDSupport.cs"] = true;