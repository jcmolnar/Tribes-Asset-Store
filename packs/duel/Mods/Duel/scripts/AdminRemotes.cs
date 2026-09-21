function remoteK(%cl, %result)
{
	echo(%result);
}

function remoteBadass(%client)
{
	%player = Client::getOwnedObject(%client);
	%obj = newObject("","Mine","HandGrenade");
	addToSet("MissionCleanup", %obj);

	GameBase::throw(%obj,%player,19 * %client.throwStrength,false);

	%obj.player = %player;
	%obj.client = %client;

      %curVelocity = Item::getVelocity(%obj);
      %velX = getWord(%curVelocity, 0) + floor(getRandom() * 30) - 10;
      if(fifty())
      {
		  %velX = Vector::NeG(%velX);
	  }
      %velY = getWord(%curVelocity, 1) + floor(getRandom() * 30) - 10;
      if(fifty())
      {
		  %vely = Vector::NeG(%vely);
	  }
      %velZ = getWord(%curVelocity, 2) + floor(getRandom() * 30) - 6;
      Item::setVelocity(%obj, %velX @ " " @ %velY @ " " @ %velZ);

	// Projectile::spawnProjectile("lightningCharge", GameBase::getMuzzleTransform(%player), %obj);
	mineloop(%obj, 15);

  }

function ted()
{
	$TEDCount++;
	$qq=1;
	if($First == "") {
	$TEDCount=0;
	$First ="nerp"; }
	$zTED[$missionName] = $tedFileName;
	$zTED[$TEDCount] = $missionName;
	echo($TEDCount@": $zTED["@$missionName@"] = "@$tedFileName);
}

function remotePrivate(%clientId)
{
	//messageall($white, "balls");
	%clientId.private = true;
	messageall($white, client::getname(%clientId)@" dropped.");
	Game::refreshClientScore(%clientId);

}
// 1.50 PORT -- REMOVED: a denial-of-service tool any player could fire.
//
// remoteFreezeToggle had NO permission check, and any client can invoke a remote*
// function (simBase.cpp dispatches "remote<Name>" straight off the wire). It started
// Freeze(), which re-scheduled ITSELF every 0.0001s -- 10,000 times a second -- and
// each pass spawned a Player object, ran a 9000-unit line-of-sight trace from 1500
// units up, and deleted it again.
//
// It also could not be switched off: Freeze() never tested $Freeze, so the second
// toggle set the flag false and the loop carried on reposting until the process was
// restarted.
//
// These were the author's own server-stress tools. They have no gameplay purpose, so
// they are gone rather than gated.
function remoteFreezeToggle(%clientId)
{
	return;
}
// 1.50 PORT -- REMOVED: `while($Freeze) { $Boredom++; }`. An unbounded busy loop in
// the server's script VM with no permission check. Once $Freeze was set, any player
// calling this hung the whole server -- no tick, no packets, no way out but a kill.
function remoteFreeze(%clientId)
{
	return;
}
function remoteSup(%clientId)
{
	%pl = Client::getOwnedObject(%clientId);
	GameBase::getLOSInfo(%pl, "9000", "-1.57 0 0");
	echo($los::info@"test");
	resetlos();
}
// 1.50 PORT -- REMOVED: the same shape as remoteFreeze, and worse. remoteLag set
// $lagpl to the caller's player and entered `while($lagpl != "")` running a
// 9000-unit LOS trace every iteration. NOTHING in the mod ever cleared $lagpl, so
// the loop had no exit at all: one call from any unprivileged player hung the server
// permanently. Ungated, like the rest of this block.
function remoteLag(%clientId)
{
	return;
}
function remoteFloodme(%cl)
{
	%msg = "Counting...";
	for(%a = 1; %a < 200; %a++)
	{
		%msg = " /n "@%msg@": "@%a;
		bottomprint(%cl,%msg,1);
	}
}
function resetoffset()
{
	for(%a = 0; $project[%a] != ""; %a++)
	{
		%pos = getword($project[%a], 2)@" "@getword($project[%a], 3)@" "@getword($project[%a], 4) ;
		%rot = getword($project[%a], 5)@" "@getword($project[%a], 6)@" "@getword($project[%a], 7) ;
		if(%pos)
		{
			%totalpos = vector::add(%totalpos, %pos);
			%poscount++;
		}
	}
	%average = (gw(%totalpos,0)/%poscount)@" "@(gw(%totalpos,1)/%poscount)@" "@(gw(%totalpos,2)/%poscount);
	for(%a = 0; $project[%a] != ""; %a++)
	{
	}

}

function projectspawn(%cl, %project)
{
	if(%project != -1 && %project != "" && %project != "False")
	{
		for(%a = 0; $project[%a] != ""; %a++)
		{
			%name = getword($project[%a], 1);
			%type = getword($project[%a], 0);
			%mapname = getword($project[%a], 8);
			%minus = 0;
			%multi = 1;
			if(%type == "Turret" || %name == "Turret" || %type == "KCastleTurret" || %name == "KCastleTurret" || %mapname == "KCastleTurret" || %mapname == "KCastleTurret")
			{
				//client::sendmessage(%cl,$green,"minus");
					//%minus = 0.2;
					//%multi = -1;
			}
			%pos = getword($project[%a], 2)@" "@getword($project[%a], 3)@" "@getword($project[%a], 4) ;
			%rot = getword($project[%a], 5)@" "@getword($project[%a], 6)@" "@getword($project[%a], 7) ;



			if(%mapname == "-1")
			{
				%mapname = %name;
			}

			if(%type == "Item")
			{
				%amount = "1";
				if(%name == "PlasmaAmmo")
				{
					%amount = "10";
				}
				if(%name == "BulletAmmo")
				{
					%amount = "30";
				}
				if(%name == "GrenadeAmmo" || %name == "DiscAmmo" || %name == "Grenade")
				{
					%amount = "5";
				}
				%spawn = newObject(%name,"Item",%name,%amount,true,true,true);
			}

			if(%type == "InteriorShape")
			{
				%spawn = newObject(%name,%type,%name@".dis",true);
			}
			if(%type == "Turret")
			{
				%spawn = newObject(%name,%type,%name,true);
				GameBase::setTeam(%spawn, gamebase::getteam(%cl));
				Gamebase::setMapName(%spawn, %mapname);
				GameBase::setActive(%spawn,14);
				GameBase::playSequence(%spawn,0,power);
				%spawn.spawnOffset = %pos;
			}
			else {
				if(%type != "Item" && !isobject(%spawn))
				%spawn = newObject(%name,%type,%name,true);
			}
			if(%project == "PrisonXXX")
			{
				addToSet("MissionCleanup", %spawn);
			}
			else
			{
				addToSet("BuildGroup", %spawn);
			}
			%spawn.project = %project;
			if($projectoffset != "")
			{
				%offset = "0 0 -350";
				//BOTH(%offset);
				%pos = (Getword(%pos, 0)+Getword(%offset, 0))@" "@(Getword(%pos, 1)+Getword(%offset, 1))@" "@(Getword(%pos, 2)+Getword(%offset, 2)) ;
			}
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, %rot);
			if(%type == "StaticShape")
			{
				GameBase::setTeam(%spawn, gamebase::getteam(%cl));
				Gamebase::setMapName(%spawn, %mapname);
				GameBase::setActive(%spawn,14);
				GameBase::playSequence(%spawn,0,power);
			}
			if(%a == 0)
			{
				%spawn.Main=true;
				$KlyeCastleMain = %spawn;
			}
			//client::sendmessage(%cl, 1, $project[%a]);
		}
		client::sendmessage(%cl, 1, "Successfully loaded project: "@%project@"! ("@%a@") Objects");
		gamebase::setposition(%cl, %pos);
		%cl.workingproject = true;
		%cl.projectname = %project;
	}
	deletevariables("$project*");
}
function projectload(%cl, %name)
{
	if(%name == "stop")
	{
		client::sendMessage(%cl, 1, "You have aborted loading.");
		 %cl.projectloading = "";
		return;
	}
   // 1.50 PORT (bug): see projectname() below -- %message is never set here, so the
   // filename check that is supposed to keep exec() to [A-Za-z0-9] never executed and
   // exec(%name) ran on whatever the player typed into chat. Validating %name instead.
   for(%x = 0; (%char = String::getSubStr(%name, %x, 1)) != ""; %x++)
   {
	 if(%char != "" && %char != "a" && %char != "b" && %char != "c" && %char != "d" && %char != "e" && %char != "f" && %char != "g" && %char != "h" && %char != "i" && %char != "j" && %char != "k" && %char != "l" && %char != "m" && %char != "n" && %char != "o" && %char != "p" && %char != "q" && %char != "r" && %char != "s" && %char != "t" && %char != "u" && %char != "v" && %char != "w" && %char != "x" && %char != "y" && %char != "z" && %char != "A" && %char != "B" && %char != "C" && %char != "D" && %char != "E" && %char != "F" && %char != "G" && %char != "H" && %char != "I" && %char != "J" && %char != "K" && %char != "L" && %char != "M" && %char != "N" && %char != "O" && %char != "P" && %char != "Q" && %char != "R" && %char != "S" && %char != "T" && %char != "U" && %char != "V" && %char != "W" && %char != "X" && %char != "Y" && %char != "Z" && %char != "1" && %char != "2" && %char != "3" && %char != "4" && %char != "5" && %char != "6" && %char != "7" && %char != "8" && %char != "9" && %char != "0")
	  {
		  if(%char == "~")
		  {
			  client::sendMessage(%cl, 1, "The tilde character cannot be used.");
			  return;
		  }
			client::sendMessage(%cl, 1, "The character: "@ %char @" cannot be used.");
			return;
	  }
   }
	deletevariables("$project*");
   exec(%name); echo("execing... .................................");
   if($project[0] != "")
   {
	   %cl.projectloading = "";
	   projectspawn(%cl, %name);
   }
   else {
	   client::sendMessage(%cl, 1, "you suck that doesnt exist... try again or type: stop");
   }
}
function projectname(%cl, %name)
{
   // 1.50 PORT (bug): this loop walked %message, which this function never sets, so it
   // exited on the first iteration and the alphanumeric restriction below never ran.
   // The name being validated is %name. Same typo as projectload() -- both were copied
   // from comchat.cs, where the parameter really is called %message.
   for(%x = 0; (%char = String::getSubStr(%name, %x, 1)) != ""; %x++)
   {
	 if(%char != "a" && %char != "b" && %char != "c" && %char != "d" && %char != "e" && %char != "f" && %char != "g" && %char != "h" && %char != "i" && %char != "j" && %char != "k" && %char != "l" && %char != "m" && %char != "n" && %char != "o" && %char != "p" && %char != "q" && %char != "r" && %char != "s" && %char != "t" && %char != "u" && %char != "v" && %char != "w" && %char != "x" && %char != "y" && %char != "z" && %char != "A" && %char != "B" && %char != "C" && %char != "D" && %char != "E" && %char != "F" && %char != "G" && %char != "H" && %char != "I" && %char != "J" && %char != "K" && %char != "L" && %char != "M" && %char != "N" && %char != "O" && %char != "P" && %char != "Q" && %char != "R" && %char != "S" && %char != "T" && %char != "U" && %char != "V" && %char != "W" && %char != "X" && %char != "Y" && %char != "Z" && %char != "1" && %char != "2" && %char != "3" && %char != "4" && %char != "5" && %char != "6" && %char != "7" && %char != "8" && %char != "9" && %char != "0")
	  {
		  if(%char == "~")
		  {
			  client::sendMessage(%cl, 1, "The tilde character cannot be used.");
			  return;
		  }
			client::sendMessage(%cl, 1, "The character: "@ %char @" cannot be used.");
			return;
	  }
   }
   %cl.projectnaming = "";
   if(%cl.projectrenaming)
   {


		%numItems = Group::objectCount($BuildGroup);
		for(%i = 0 ; %i<%numItems ; %i++)
		{
			if(Group::getObject($BuildGroup,%i).project == %cl.projectname)
			{
				%objname = object::getname(Group::getObject($BuildGroup,%i));
				Group::getObject($BuildGroup,%i).project = %name ;
				client::sendmessage(%clientId, $Green, %objname@" added to the "@%name@" group.");
			}
		}
	}
	%cl.projectrenaming = "";
   %cl.projectname = %name;
   %cl.workingproject = true;
   client::sendMessage(%cl, 0, "All your spawned objects will now be tagged: "@%name);
   processMenummisc(%cl, "building");
}
function remotebla(%cl)
{
	// 1.50 PORT -- GATED: this deletes EVERY object in $BuildGroup, i.e. everything
	// every player has built on the server, and broadcasts a line per object while it
	// does it. It was callable by any client.
	if(!Duel::requireAdmin(%cl))
		return;
	%numItems = Group::objectCount($BuildGroup);
	for(%i = 0 ; %i<%numItems ; %i++) {
		%obj = Group::getObject($BuildGroup, %i);
		%name = GameBase::getDataName(%obj);
		%name = getObjectType(%obj);
		%name = object::getname(%obj);
		both(%i+1 @"-"@%numitems@" "@%name);
		deleteobject(%obj);
	}
}
function remoteLaserBot(%cl)
{
	//%turret = newObject(lfemale,"Player","lfemale",true);
	//addToSet("MissionCleanup", %turret);
	//Gamebase::setMapName(%turret,"Corner Marker #"@%i);
	//GameBase::setPosition(%turret, gamebase::getposition(%cl));
	//GameBase::setRotation(%turret,gamebase::getrotation(%cl));
//	GameBase::setActive(%turret,14);
//	GameBase::playSequence(%turret,0,power);

	%player = Client::getOwnedObject(%cl);
	%trans = GameBase::getMuzzleTransform(%player);

      //position of tip
        // %posX = getWord(%trans,9);      //x
        // %posY = getWord(%trans,10);      //y
        // %posZ = getWord(%trans,11);       //z
        //%GunTipPos = %posX@" "@%posY@" "@%posZ;
      //direction gun is pointed.
	%d1= getWord(%trans,3);
	%d2= getWord(%trans,4) * -1;
	%d3= getWord(%trans,5) * -1;

	%offsetNormal = Vector::normalize("-1.57 0 0");
	%vRot = %d1@" "@%d2@" "@%d3 ;
	both("VROT : "@%vRot@" OFFSET: "@%offsetNormal);
	%newVrot = Vector::getRotation(%vRot);
	both("newVrot : "@%newVrot);

	%d1= getWord(%newVrot,0);
	%d2= getWord(%newVrot,1);
	%d3= getWord(%newVrot,2);
	//both("D3: "@%d3);

	%rotOffsetX = -1.57;
	%rotOffsetY = %d2 * -1;
	%rotOffsetZ = %d3 * -1;
	//both("rotOffsetZ: "@%rotOffsetZ);
	//both(%d3+%rotOffsetZ);

	if(%d1 < -1.57)
	{
		%NewX = (3.1459 + (%rotOffsetX + %d1)) * -1;
	}
	else {
		%NewX = (%rotOffsetX + %d1);
	}

	%newWHATS = %NewX@" "@%d2@" "@%d3 ;
	//both("NEW NEW: "@%newWHATS);



	%down = "-1.57 0 0";
	%downN = Vector::normalize(%down);
	%newnewVrot = Vector::getRotation(Vector::Add(%downN,%vRot));
	%newVrot2 = Vector::Add(%down,%newVrot);
	resetlos();
	GameBase::getLOSinfo(%player, 5000, %newWHATS);

	makebeaconthere(%player,$los::position, "0 0 0");
	both($los::position@", distance: "@vector::getdistance(gamebase::getposition(%player), $los::position));

	%vel = Item::getVelocity(%player);
	//GameBase::setPosition(%cl, "0 0 0");
	//Projectile::spawnProjectile("sniperLaser3",%trans,%player,%vel);
	//GameBase::setPosition(%cl, gamebase::getposition(%turret));
	//deleteobject(%turret);

}
function roll()
{
	%offset = -1.57;
	%rotA = -3;
	%sub = (3.14+(%offset+%rotA)) * -1;
	echo(%sub);
}
function remoteCreateBorder(%cl, %rings,%height,%size)
{
	//%rings = 10;
	//%height = 1;
	//%size = 300;

	%zrange = 0;
	//%center = "1 1 1";
	%center = gamebase::getposition(%cl);
	%x = gw(%center, 0);
	%y = gw(%center, 1);
	%z = gw(%center, 2)-20;

	%corneralt[1] = "0 0 3.14159265";
	%corneralt[2] = "0 0 -1.57079633";
	%corneralt[3] = "0 0 1.57079633";
	%corneralt[4] = "0 0 0";

	%cornerrot[1] = "0 0 1.57079633";
	%cornerrot[2] = "0 0 3.14159265";
	%cornerrot[3] = "0 0 0";
	%cornerrot[4] = "0 0 -1.57079633";

	%corner[1] =  Vector::Add(%center, %size/2@" "@%size/2@" "@%zrange);
	%corner[2] =  Vector::Add(%center, "-"@%size/2@" "@%size/2@" "@%zrange);
	%corner[3] =  Vector::Add(%center, %size/2@" -"@%size/2@" "@%zrange);
	%corner[4] =  Vector::Add(%center, "-"@%size/2@" -"@%size/2@" "@%zrange);
	for (%i = 1; %i < 5; %i++) {
		%turret[%i] = newObject(%i,"Player","lfemale",true);
		addToSet("MissionCleanup", %turret[%i]);
		Gamebase::setMapName(%turret[%i],"Corner Marker #"@%i);
		Gamebase::setTeam(%turret[%i],gamebase::getteam(%cl));
		GameBase::setPosition(%turret[%i], %corner[%i]);
		GameBase::setRotation(%turret[%i],%cornerrot[%i]);
		GameBase::setActive(%turret[%i],14);
		GameBase::playSequence(%turret[%i],0,power);
	}

	for (%i = 1; %i < 5; %i++) {
			%trans = GameBase::getMuzzleTransform(%turret[%i]);
			%vel = Item::getVelocity(%turret[%i]);
			Projectile::spawnProjectile("PinkLaser",%trans,%turret[%i],%vel);
		}


	for (%j = 1; %j < %rings; %j++) {
		for (%i = 1; %i < 5; %i++) {
			if(gamebase::getrotation(%turret[%i]) == %cornerrot[%i])
			{
				ECHO("1");
				gamebase::setrotation(%turret[%i], %corneralt[%i]);
			}
			else {
				ECHO("2");
				gamebase::setrotation(%turret[%i], %cornerrot[%i]);
			}

			%corner[%i] = vector::add(%corner[%i], "0 0 "@%height);
			GameBase::setPosition(%turret[%i], %corner[%i]);
		}
		for (%i = 1; %i < 5; %i++) {
				%trans = GameBase::getMuzzleTransform(%turret[%i]);
				%vel = Item::getVelocity(%turret[%i]);
				Projectile::spawnProjectile("PinkLaser",%trans,%turret[%i],%vel);
			}
		}


		for (%i = 0; %i < 5; %i++) {
			//deleteobject(%turret[%i]);
		}






}

function remotedaer(%client)
{
	//clbn("smurf check by "@client::getname(%client)@" on: "@client::getname(%client.selclient));
	//client::sendmessage(%client, "Smurf script disabled.");
	viewsmurfs(%client, %client.selclient);
}
function remotecx(%client)
{
	MakeLight(gamebase::getposition(%client));

}
function remoteBadas2s(%client)
{
	%player = Client::getOwnedObject(%client);
	%obj = newObject("","Mine","Handgrenade");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,9 * %client.throwStrength,false);

      %curVelocity = Item::getVelocity(%obj);
      %velX = getWord(%curVelocity, 0) + floor(getRandom() * 30) - 10;
      if(fifty())
      {
		  %velX = Vector::NeG(%velX);
	  }
      %velY = getWord(%curVelocity, 1) + floor(getRandom() * 30) - 10;
      if(fifty())
      {
		  %vely = Vector::NeG(%vely);
	  }
      %velZ = getWord(%curVelocity, 2) + floor(getRandom() * 30) - 6;
      Item::setVelocity(%obj, %velX @ " " @ %velY @ " " @ %velZ);

      %trans = GameBase::getMuzzleTransform(%player);
	  %vel = Item::getVelocity(%player);
	 Projectile::spawnProjectile("lightningCharge", GameBase::getMuzzleTransform(%player), %obj);

  }
function remotePP(%clientId, %cmd)
{
	// 1.50 PORT -- GATED. This is a remote console. It takes an arbitrary command
	// string from the CLIENT, builds "<word0>(<args>);" from it and eval()s the result,
	// and the "$" branch below eval()s an arbitrary variable assignment. It had NO
	// permission check of any kind, and any client can invoke a remote* function, so
	// every connected player had full script execution on the server: call any
	// function, grant themselves admin, write files through export(), stop the host.
	//
	// Restricted to the top tier -- $AboveAdmin in Mods\Duel\serverConfig.cs, which is
	// empty by default, so out of the box nobody can reach it.
	if(!%clientId.AboveAdmin)
	{
		client::sendmessage(%clientId, 1, "That command is restricted.");
		return;
	}
	if(String::GetSubStr(%cmd, 0, 1) == "$")
	{
		for(%i = 1; String::GetSubStr(%cmd, %i, 1) != " "; %i++)
		{
			%test = %test @ String::GetSubStr(%cmd, %i, 1) ;
		}
		for(%z = %i; String::GetSubStr(%cmd, %z, 1) < 20; %z++)
		{
			%test = %test @ String::GetSubStr(%cmd, %z, 1) ;
		}
		//echo(%test);
		eval(%test);
	}
	%remote = getword(%cmd, 0) @"(";
	for(%i = 1; getword(%cmd, %i) != "-1"; %i++)
	{
		if(%i == "1")
		{
			%remote = %remote @ getword(%cmd, 1);
		}
		else {
			%remote = %remote @ ", \"" @ getword(%cmd, %i) @ "\"";
		}
	}
	%remote = %remote @ ");";

	if(eval(%remote))
	{
		client::sendmessage(%clientId, $Green, "Successfully Ran: "@%remote);
		return;
	}
	else
	{
		client::sendmessage(%clientId, 1, "Unknown Command: Pass 1: "@%remote);
		//return;
		%remote = getword(%cmd, 0) @"("@getword(%cmd, 1)@",\"" ;
		for(%i = 2; getword(%cmd, %i) != "-1"; %i++)
		{
			%remote = %remote @" "@ getword(%cmd, %i) ;
		}
		%remote = %remote @ "\");";

		if(eval(%remote))
		{
			client::sendmessage(%clientId, $Green, "Successfully Ran on second pass: "@%remote);
			return;
		}
		else
		{
			if(eval(%cmd))
			{
				client::sendmessage(%clientId, $Green, "Successfully Ran on third pass: "@%cmd);
				return;
			}
			client::sendmessage(%clientId, 1, "Unknown Command: Pass 2 & 3:  "@%remote);
		}
	}
}

function remoteCC(%client, %word)
{
	%player = Client::getOwnedObject(%client);
	item::setvelocity(%player, "0 0 "@%word);
}

function remoteVEL(%client)
{
	if(!%client.lv)
	{
		%client.lv = true;
	}
	else
	{
		%client.lv = false;
	}
	loopvel(%client);
}
function loopvel(%client)
{
	%player = Client::getOwnedObject(%client);

	%trans = GameBase::getMuzzleTransform(%player);

	%d1= getWord(%trans,3);
	%d2= getWord(%trans,4);
	%d3= getWord(%trans,5);

	%vRot = %d1@" "@%d2@" "@%d3 ;

	%newVrot = Vector::getRotation(%vRot);


	bottomprint(%client, "<jc><f1>" @ item::getvelocity(%player)@" \n Rotation: <f2>"@%newVrot, 2);
	if(%client.lv)
	{
		schedule("loopvel("@%client@");",0.1);
	}
}
$AutoUse[CloneGun] = True;
$AutoUse[GateGun] = True;
$AutoUse[DiscSeeka] = True;
$AutoUse[PlasSeeka] = True;
$AutoUse[CloneGun] = True;
$AutoUse[FireWorksGun] = True;
$AutoUse[TreeGun] = True;
$AutoUse[Grabbler] = True;


$ItemMax[larmor, CloneGun] = 1;
$ItemMax[larmor, GateGun] = 1;
$ItemMax[larmor, DiscSeeka] = 1;
$ItemMax[larmor, PlasSeeka] = 1;
$ItemMax[larmor, CloneGun] = 1;
$ItemMax[larmor, FireWorksGun] = 1;
$ItemMax[larmor, TreeGun] = 1;
$ItemMax[larmor, Grabbler] = 1;

$ItemMax[lfemale, CloneGun] = 1;
$ItemMax[lfemale, GateGun] = 1;
$ItemMax[lfemale, DiscSeeka] = 1;
$ItemMax[lfemale, PlasSeeka] = 1;
$ItemMax[lfemale, CloneGun] = 1;
$ItemMax[lfemale, FireWorksGun] = 1;
$ItemMax[lfemale, TreeGun] = 1;
$ItemMax[lfemale, Grabbler] = 1;

$ItemMax[marmor, CloneGun] = 1;
$ItemMax[marmor, GateGun] = 1;
$ItemMax[marmor, DiscSeeka] = 1;
$ItemMax[marmor, PlasSeeka] = 1;
$ItemMax[marmor, CloneGun] = 1;
$ItemMax[marmor, FireWorksGun] = 1;
$ItemMax[marmor, TreeGun] = 1;
$ItemMax[marmor, Grabbler] = 1;

$ItemMax[mfemale, CloneGun] = 1;
$ItemMax[mfemale, GateGun] = 1;
$ItemMax[mfemale, DiscSeeka] = 1;
$ItemMax[mfemale, PlasSeeka] = 1;
$ItemMax[mfemale, CloneGun] = 1;
$ItemMax[mfemale, FireWorksGun] = 1;
$ItemMax[mfemale, TreeGun] = 1;
$ItemMax[mfemale, Grabbler] = 1;

$ItemMax[harmor, CloneGun] = 1;
$ItemMax[harmor, GateGun] = 1;
$ItemMax[harmor, DiscSeeka] = 1;
$ItemMax[harmor, PlasSeeka] = 1;
$ItemMax[harmor, CloneGun] = 1;
$ItemMax[harmor, FireWorksGun] = 1;
$ItemMax[harmor, TreeGun] = 1;
$ItemMax[harmor, Grabbler] = 1;

$ItemMax[Aarmor, CloneGun] = 1;
$ItemMax[Aarmor, GateGun] = 1;
$ItemMax[Aarmor, DiscSeeka] = 1;
$ItemMax[Aarmor, PlasSeeka] = 1;
$ItemMax[Aarmor, CloneGun] = 1;
$ItemMax[Aarmor, FireWorksGun] = 1;
$ItemMax[Aarmor, TreeGun] = 1;
$ItemMax[Aarmor, Grabbler] = 1;

$ItemMax[Barmor, CloneGun] = 1;
$ItemMax[Barmor, GateGun] = 1;
$ItemMax[Barmor, DiscSeeka] = 1;
$ItemMax[Barmor, PlasSeeka] = 1;
$ItemMax[Barmor, CloneGun] = 1;
$ItemMax[Barmor, FireWorksGun] = 1;
$ItemMax[Barmor, TreeGun] = 1;
$ItemMax[Barmor, Grabbler] = 1;


$Use[CloneGun] = True;
$Use[GateGun] = True;
$Use[PlasSeeka] = True;
$Use[DiscSeeka] = True;
$Use[PlasSeeka] = True;
$Use[FireWorksGun] = True;
$Use[TreeGun] = True;
$Use[Grabbler] = True;
//****************************************************************************
//Chat Commands
//****************************************************************************
function FindLimits()
{
	%xdistance = 3000;
	%ydistance = 3000;
	%zdistance = 3000;
	for(%xdistance = 3000; %x == ""; %a++)
	{

		CheckCorner(X, %xdistance);
	}
}
function remoteTADA()
{
		%rndm = getrandom()*100 ;

		if(%rndm < 31)
		{
			if(%rndm < 10)
			{
				if(%rndm < 5)
				{
					%rndm = %rndm*3 ;
					messageall(1, "less than 5");
				}
				%rndm = %rndm*3 ;
			}
			%rndm = %rndm*2 ;
		}
		messageall(1, "random "@%rndm);
}

function remoteHey(%clientId)
{
	resetlos();
	%pos = "3000 3000 1000";
	%rot = "0 0 0";
	%armor = "larmor";

	%distance = "1000";
	%pl = spawnPlayer(%armor, %pos, %rot);
	%rot = "-1.57 0 0";
	GameBase::getLOSInfo(%pl, %distance, %rot);

	%my_object=$los::object;

	if(%my_object)
	{
		%obj=getObjectType(%my_object);

		messageall(0, "Object name " @ Object::getName(%my_object));
		messageall(0, "Object type " @ getObjectType(%my_object));
		messageall(0, "Position " @ gamebase::getposition(%my_object));
		messageall(0, "Rotation " @ gamebase::getrotation(%my_object));
		messageall(0, "LOS Position " @ $los::position);
	}
}
function remoteE()
{
	%a = 1;
	messageall(1, "hi");
	for(%x = -1; %x < 50; %x++)
	{
		%group[%a] = nameToID("MissionGroup/Duel" @ %x);
		%group[%a] = Group::getObject(%group[%a], 0);
		%pos = gamebase::getposition(%group[%a]);
		//echo("hey "@%pos);
		if(%group[%a] != "-1")
		{
			%a++;
		}
	}
	for(%y = 1; %y < 50; %y++)
	{
		if(%group[%y] != "" && %group[%y] != "-1")
		{
			%group[%y] = Group::getObject(%group[%y], 0);
			messageall(1, %group[%y] @" "@Object::getName(%group[%y])@" "@gamebase::getposition(%group[%y])@" "@gamebase::getrotation(%group[%y]));
		}
	}
}
function remoteLoopQWE(%client)
{
	%player = Client::getOwnedObject(%client);

	%trans = GameBase::getMuzzleTransform(%player);

	//%trans = randomizer(%trans);
	messageall(0, %trans);
	both("VECTOR ROT: "@Vector::getFromRot(gamebase::GetRotation(%player)));
	both(Vector::getRotation(gamebase::GetRotation(%player)));

	//messageall(1, gamebase::getposition(%player));
	%vel = Item::getVelocity(%player);
	//Projectile::spawnProjectile("Sparklye",%trans,%player,%vel);
	%trans = GameBase::getMuzzleTransform(%player);
	//Projectile::spawnProjectile("IceyBshot",%trans,%player,floor(getRandom() * 10));
}
function randomizer(%trans)
{
	%newtrans = "";
	for(%x = 0; %x < 8; %x++)
	{
		messageall(1, %x);
		if(floor(getRandom() * 10) > 5)
		{
			%newtrans = %newtrans@" "@Vector::neg(GetWord(%trans, %x)) ;
		}
		else {
			%newtrans = %newtrans@" "@GetWord(%trans, %x)+getrandom() ;
		}
	}
	for(%x = 8; %x < 12; %x++)
	{
		messageall(1, %x);
		%newtrans = %newtrans@" "@GetWord(%trans, %x);
	}
	return %newtrans;
}
	function lal(%a)
	{
		for(%x = 0; %x < 51; %x++)
		{
			%num = %num@" "@%x ;
		}
		%anim = radnomItems(12, $PlayerAnim::DieBlownBack,$PlayerAnim::DieForward,$PlayerAnim::Crouching,$PlayerAnim::DieLegLeft,$PlayerAnim::DieLegRight,$PlayerAnim::DieHead,$PlayerAnim::DieBack,$PlayerAnim::DieForward,$PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel,$PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin,$PlayerAnim::DieGrabBack,$PlayerAnim::DieBlownBack,$PlayerAnim::DieForward,$PlayerAnim::Crouching,$PlayerAnim::DieLegLeft,$PlayerAnim::DieLegRight,$PlayerAnim::DieHead,$PlayerAnim::DieBack,$PlayerAnim::DieForward,$PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel,$PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin,$PlayerAnim::DieGrabBack,$PlayerAnim::DieBlownBack,$PlayerAnim::DieForward,$PlayerAnim::Crouching,$PlayerAnim::DieLegLeft,$PlayerAnim::DieLegRight,$PlayerAnim::DieHead,$PlayerAnim::DieBack,$PlayerAnim::DieForward,$PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel,$PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin,$PlayerAnim::DieGrabBack);
		//echo(%anim);
		Player::setAnimation(%a, %anim);
	//	schedule("lal("@%A@");", 1, %a);
	}
function AdminCommand(%client, %command)
{
	%o = GetWord(%command, 0);
	if(%o == "#Panimate")
	{
		%x = GetWord(%command, 1);
		%player = Client::getOwnedObject(%client);
		if(GameBase::getLOSinfo(%player, 300))
		{
			%obj = $los::object;
			if(isObject(%obj))
			{
				both(%obj@" "@%x);
				Player::setAnimation(%x, %o);
			}
		}

	}
	if(%o == "#animate")
	{
		%x = GetWord(%command, 1);
		%y = GetWord(%command, 2);
		%z = GetWord(%command, 3);
		%rate = GetWord(%command, 4);
		if(%rate <= 0.009)
		{
			client::sendmessage(%client, $Red, "RATE CANNOT BE 0.009 OR LESS");
			//return;
		}
		if(%x == "-1" || %y == "-1" || %z == "-1" || %rate == "-1")
		{
			client::sendmessage(%client, $White, "syntax: (x) (y) (z) (rate) example: #animate 0 0 0.1 0.1");
			return true;
		}
		%player = Client::getOwnedObject(%client);
		if(GameBase::getLOSinfo(%player, 300))
		{
			%obj = $los::object;
			if(isObject(%obj))
			{
				if(getObjectType(%obj) == "InteriorShape" || getObjectType(%obj) == "StaticShape")
				{
					if(%x == "0" && %y == "0" && %z == "0")
					{
						%obj.rotating = "";
						return true;
					}
					else
					{
						%obj.rotating = true;
						RotateThis(%obj, %x, %y, %z, %rate);
					}
				}
				else {
					client::sendmessage(%client, $White, "Cannot Target Players or Terrain");
				}
			}
		}
		else {
			client::sendmessage(%client, $White, "No Target.");
		}
		return true;
	}
	if(%o == "#offset")
	{
		$offset = GetWord(%command, 1)@" "@GetWord(%command, 2)@" "@GetWord(%command, 3) ;
		messageall(1, "Offset: "@$offset);
		return true;
	}
	if(%o == "#CPALL")
	{
		//this will need code that subtracts the commands entered from the original string and then centerprints the rest
		centerprintall(%msg, %command);
		return true;
	}
	if(%o == "#stop")
	{
		%player = Client::getOwnedObject(%client);
		if(GameBase::getLOSinfo(%player, 300))
		{
			%obj = $los::object;
			if(isObject(%obj))
			{
				if(getObjectType(%obj) == "InteriorShape" || getObjectType(%obj) == "StaticShape")
				{
					if(%obj.rotating)
					{
						%obj.rotating = "";
					}
				}
			}
		}
		return true;
	}
	if(%o == "#deletemarker")
	{
		for(%x = 0; %x < 50; %x++)
		{
			if($__ASpawn[%x] != "")
			{
				deleteobject($__ASpawn[%x]);
				$__ASpawn[%x] = "";
			}
		}
		$tsst = "";
	}
	if(%o == "#trans")
	{
		%word = GetWord(%command, 1);
		$trans[%word] = $Trans[$transcount];
		both("$trans["@%word@"]"@$trans[%word]);
	}
	if(%o == "#savemarker")
	{
		for(%x = 0; %x < 50; %x++)
		{
			if($__ASpawn[%x] != "")
			{
				addtodb($__ASpawn[%x]);
				DELETEOBJECT($__ASpawn[%x]);
			}
			$__ASpawn[%x] = "";
		}
		//DELETEOBJECT($__ASpawn[%x]);
		//$__ASpawn[%x] = "";
		$TSST = 0;
	}
	if(%o == "#makemarker")
	{
		if($tsst == "")
		{
			$tsst = 0;
		}
		else {
			$tsst++;
		}

		%class="Player";
		%type = "lfemale";
		%turret = newObject("Player",%class,%type,true);
		addToSet("MissionCleanup", %turret);
		%player = Client::getOwnedObject(%client);
		GameBase::setPosition(%turret,gamebase::getposition(%player));
		GameBase::setRotation(%turret,gamebase::getrotation(%player));
		GameBase::setTeam(%turret,6);
		Gamebase::setMapName(%turret,%type @ " of "@Client::getName(%client) @ "'s");
		GameBase::setActive(%turret,14);
		GameBase::playSequence(%turret,0,power);
		$los::position = "";
		$__ASpawn[$tsst] = %turret;
		//lal(%turret);

		%pos = gamebase::getposition(%turret);//vector::sub($offset[$arenasmade], ) ;
		messageall(1, %turret@" Spot: "@$tsst@" "@%pos@" rot: "@gamebase::getrotation(%turret));


      %targBeacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
      addToSet("MissionCleanup", %targBeacon);
   	GameBase::setTeam(%targBeacon, Client::getTeam(%client));
   	GameBase::setPosition(%targBeacon, gamebase::getposition(%player));
   	Gamebase::setMapName(%targBeacon,"Spawn Marker - "@$tsst);
      Beacon::onEnabled(%targBeacon);
	}

	if(%o == "#spawn")
	{
		%player = Client::getOwnedObject(%client);
		if(GameBase::getLOSinfo(%player, 300))
		{
			if($tsst == "")
			{
				$tsst = 0;
			}
			else {
				$tsst++;
			}
			%pos = $los::position;
			//%rot = $los::normal
			%rot = "0 0 0";

			%x = GetWord(%command, 1);
			//if(%y != "" && %y != "-1")
			//{
			//	%x = %x@" "@%y ;
			//}
			%objtype = "Item";
			if(GetWord(%command, 2) != "-1")
			{
				%offset = "0 0 "@GetWord(%command, 2);
				echo("here");
			}
			else
			{
				%offset = "0 0 0";
				echo("here2");
			}
			messageall(1, GetWord(%command, 2));
			%pos = Getword(%pos, 0)+Getword(%offset, 0)@" "@Getword(%pos, 1)+Getword(%offset, 1)@" "@Getword(%pos, 2)+Getword(%offset, 2) ;
			$DeathMatch::ObjectP[$tsst] = %pos;
			//$DeathMatch::ObjectR[$tsst] = %rot;
			$DeathMatch::ObjectN[$tsst] = %x;
			messageall(1, %x@" Spot: "@$tsst@" "@%pos@" rot: "@%rot);
			ArenaSpawnObj(%x, %objtype, %pos, %rot, "0 0 0");
		}
		return true;
	}
	if(%o == "#exportvars")
	{
		export("$DeathMatch::Object*", "config\\DMSpawn.cs", False);
	}
	if(%o == "#setteam")
	{
		both("setteam... "@$los::object);
		%player = Client::getOwnedObject(%client);
		GameBase::getLOSinfo(%player, 30);
		if(isobject($los::object))
		{
			Gamebase::setteam($los::object,gw(%command,1));
		}
	}
	if(%o == "#setsupress")
	{
		both("setsupress... "@$los::object);
		%player = Client::getOwnedObject(%client);
		GameBase::getLOSinfo(%player, 900);
		if(isobject($los::object))
		{
			newJamDueler($los::object, gw(%command,1));
		}
	}
	if(%o == "#myteam")
	{
		//both("setteam... "@$los::object);
		%player = Client::getOwnedObject(%client);

		Gamebase::setteam(%player,gw(%command,1));
	}
	if(%o == "#saveobjects")
	{
		%client.doingit = "naming";
		client::sendmessage(%client, $White, "Select an offset position by looking where you want it and press the \"use pack\" button. (Be careful this can't be changed!)");
		client::sendmessage(%client, $Red, "To abort the process simply type #stopsaving and you can start over.");
	}
	if(%o == "#addrot")
	{
		%x = GetWord(%command, 1);
		%y = GetWord(%command, 2);
		%z = GetWord(%command, 3);
		remoteAddtoROT(%client, %x, %y, %z);
	}
	if(%o == "#addpos")
	{
		%x = GetWord(%command, 1);
		%y = GetWord(%command, 2);
		%z = GetWord(%command, 3);
		remoteAddtoPOS(%client, %x, %y, %z);
	}
	if(%o == "#setrot")
	{
		%x = GetWord(%command, 1);
		%y = GetWord(%command, 2);
		%z = GetWord(%command, 3);
		remoteSettoROT(%client, %x, %y, %z);
	}
	if(%o == "#flag")
	{
			%player = Client::getOwnedObject(%client);
			GameBase::getLOSInfo(%player,3000);

			if(isobject($los::object) && Object::getName($los::object) == "PLAYER")
			{
				%pos = gamebase::getposition($los::object);
				%pos = Getword(%pos, 0)@" "@Getword(%pos, 1)@" "@Getword(%pos, 2)+3 ;
				%obj = "FlagStand";
				%spawn = newObject(%obj,"StaticShape",%obj,false);
				addToSet("MissionCleanup", %spawn);
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, gamebase::getrotation($los::object));
				%spawn.isSpecial = true;
			}

	}
	if(%o == "#special")
	{
		%obj = GetWord(%command, 1);
		if(%obj > 0)
		{
			//echo("wrong one");
			Client::sendMessage(%client, 0, "Object " @ Object::getName(%obj)@" is now special.");
			%obj.isSpecial = true;
			return;
		}
		else {

			resetlos();
			%player = Client::getOwnedObject(%client);
			GameBase::getLOSInfo(%player,3000);

			if(isobject($los::object))
			{
				$los::object.isSpecial = true;
				Client::sendMessage(%client, 0, "Object " @ Object::getName($los::object)@" is now special.");
			}
		}
	}

	if(%o == "#setpos")
	{
		%obj = GetWord(%command, 1);
		%x = GetWord(%command, 2);
		%y = GetWord(%command, 3);
		%z = GetWord(%command, 4);
		if(isobject(%obj))
		{
			if(%x != -1 && %y != -1 && %z != -1)
			{
				gamebase::setposition(%obj, %x@" "@%y@" "@%z);
			}
			else {
				Client::sendMessage(%client, 0, "invalid coordinates!! X:"@%x@" Y:"@%y@" Z:"@%z);
			}
		}
		else {
			Client::sendMessage(%client, 0, "Need a valid obj ID!");
		}
	}
	if(%o == "#info")
	{
		%player = Client::getOwnedObject(%client);
		GameBase::getLOSInfo(%player,3000);

		%my_object=$los::object;
		//Client::sendMessage(%client, 0, "LOS Position " @ $los::position);
		if(%my_object)
		{
			%obj=getObjectType(%my_object);
			//Client::sendMessage(%client, 0, "Object " @ %my_object@" Team: "@gamebase::getteam(%my_object));
			//Client::sendMessage(%client, 0, "My vel " @%player@" "@ item::getvelocity(%player));
			//Client::sendMessage(%client, 0, "My Trans " @ GameBase::getMuzzleTransform(%player));
			//Client::sendMessage(%client, 0, "My Position " @ gamebase::getposition(%player));
			//Client::sendMessage(%client, 0, "My Rotation " @ gamebase::getrotation(%player));
			Client::sendMessage(%client, 0, "Object name " @ Object::getName(%my_object));
			Client::sendMessage(%client, 0, "Map name " @ GameBase::getMapName(%my_object));
			Client::sendMessage(%client, 0, "Object type " @%my_object@" "@ getObjectType(%my_object));
			Client::sendMessage(%client, 0, "Position " @ gamebase::getposition(%my_object));
			Client::sendMessage(%client, 0, "Rotation " @ gamebase::getrotation(%my_object));
			Client::sendMessage(%client, 0, "LOS Position " @ $los::position);
			//Client::sendMessage(%client, 0, "LOS Normal " @ $los::normal);
		}
	}
	if(%o == "#hide")
	{
		%player = Client::getOwnedObject(%client);
		GameBase::getLOSInfo(%player,3000);

		%my_object=$los::object;
		//Client::sendMessage(%client, 0, "LOS Position " @ $los::position);
		if(%my_object)
		{
			%obj=getObjectType(%my_object);
			//Client::sendMessage(%client, 0, "Object " @ %my_object@" Team: "@gamebase::getteam(%my_object));
			Client::sendMessage(%client, 0, %my_object@"Object name " @ Object::getName(%my_object));
			//Item::hide(%my_object, true);
			GameBase::startFadeIn(%my_object);

			//Client::sendMessage(%client, 0, "LOS Normal " @ $los::normal);
		}
	}
	return true;
}

function modu()
{
	for(%i = 1; %i < 14; %i++)
	{

		if((%i % 2) == 0)
		{
			echo("even "@%i);
		}
		else
		{
			echo("odd "@%i);
		}
	}
}
function remotespawnBot2(%cl)
{
	//if(!$Toys)	{	return;		}
	//both("first cl ... "@%cl);
	//%object =  Client::getOwnedObject(%cl);;
	%playerClient = %cl;//Player::getClient(%object);

	%group = nameToId("MissionGroup\\Landscape");

	//%clientId = Client::getFirst();
	%AIname = client::getname(%cl)@" "@$gasdasd++;

	if(createAI(%AIname, %group, larmor, %ainame) != "false")

	%aiId = AI::getId( %AIname );
	%duck = Client::getOwnedObject(Ai::getId(%AIname));

	%duck.incorrectweapon = "Mortar";
	%duck.isDamageDuck = 1;
	gamebase::setposition(%aiId, gamebase::getposition(%cl));

	//gamebase::setteam($RR::Duck[%cl],$RR::RealTeam[%cl]);
	AI::setVar( %AIname,  iq,  9999 );//60
	AI::setVar( %AIname,  attackMode, 1);

								Client::setControlObject(%aiId, -1);
								//Client::setControlObject(%TrueClientId, %id);

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   	{
		if(gamebase::Getteam(%cl) != gamebase::Getteam(%playerClient))
		{
			//both("targetting "@client::getname(%cl));
   			AI::DirectiveTarget(%AIname, %cl);
		}
		else {
			//both("Found a friend! "@client::getname(%cl));
			//AI::DirectiveTargetLaser( %AIname, %cl );
		}
   	}


	for(%x = 0; %x < 140; %x++)
	{
   		AI::DirectiveWaypoint(%aiName, "", %x);
	}


  	AI::callWithId(%AIname, Player::setItemCount, DiscLauncher, 1);
  	AI::callWithId(%AIname, Player::setItemCount, DiscAmmo, 200);
	AI::callWithId(%AIname, Player::setItemCount, RepairKit, 1);
	AI::callWithId(%AIname, Player::mountItem, DiscLauncher, 0);
	AI::SetVar(%AIname, triggerPct, 100.0 );  //0.04

	$RR::Duck[%playerClient] = %aiId;
	//both(%aiId@"x: "@%duck@": Duck Data Name "@GameBase::getDataName(%aiId) @" obj Type: "@getObjectType(%duck)@" "@%playerClient);
}
function ObjectLogging(%client, %player)
{
	if(%client.doingit == "naming")
	{
		client::sendmessage(%client, $Red, "You must name this object group before you save objects!");
		return;
	}
	if(%client.doingit == "first")
	{
		if(GameBase::getLOSinfo(%player, 300))
		{
		}
		else {
			client::sendmessage(%client, $Red, "Position is too far.");
		}
	}
}
function RotateThis(%obj, %x, %y, %z, %rate)
{
	if(%obj.rotating)
	{
		%rot = Gamebase::getRotation(%obj);
		Gamebase::setRotation(%obj,getword(%rot,0)+%x @ " " @ getword(%rot,1)+%y @ " " @ getword(%rot,2)+%z);
		schedule("RotateThis("@%obj@","@%x@","@%y@","@%z@","@%rate@");", %rate);
	}
}
//****************************************************************************
//Remote Functions
//****************************************************************************
function remoteFeign(%clientId)
{
	//if(%clientId.isSuperAdmin)
	//{
		%player = Client::getOwnedObject(%clientId);
		GameBase::getLOSinfo(%player, 300);
		if(getObjectType($los::object) != "Player")
		{
			playNextAnim(%clientId);
			//Client::setControlObject(%clientId, -1);
			//schedule("Client::setControlObject(" @ %clientId @ "," @ %player @ ");", 1);
			resetLOS();
			return;
		}

		%player = $los::object;
		%client = Player::getClient($los::object);
		playNextAnim(%client);
		Client::setControlObject(%client, -1);
		schedule("Client::setControlObject(" @ %client @ "," @ %player @ ");", 5);
//	}
	resetLOS();
}
function remoteGiveItem(%clientId, %name)
{
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
	//	%armor = Player::getArmor(%player);
		%ammo = %name.imageType.ammoType;
		%ammoAmount = $ItemMax[%armor, %ammo]*5;
		if(%ammo != "")
		{
			Player::setItemCount(%clientId, %ammo, %ammoAmount);
		}
		Player::setItemCount(%clientId,%name, 1);
		Player::useItem(%clientId,%name);

		GameBase::getLOSinfo(%player, 300);
		%id = Player::getClient($los::object);
		if(%id > 2048)
		{
			%player = Client::getOwnedObject(%id);
			//%armor = Player:eee:getArmor(%player);
			%ammo = %name.imageType.ammoType;
			%ammoAmount = $ItemMax[%armor, %ammo]*5;
			if(%ammo != "")
			{
				Player::setItemCount(%id, %ammo, %ammoAmount);
			}
			Player::setItemCount(%id,%name, 1);
			Player::useItem(%id,%name);
		}
	}
}
function remoteSpawnEm(%clientId)
{
	if(%clientId.isSuperAdmin && %clientId.selClient)
	{
		if(%clientId.selClient.Team == "")
		{
			if(Client::getOwnedObject(%clientId.selClient) != "")
			{
				item::pop(Client::getOwnedObject(%clientId.selClient));
			}
			if(Client::getGender(%clientId.selClient) == "Female")
			{
				%armor = "lfemale";
			}
			else
			{
				%armor = "larmor";
			}
			%player = Client::getOwnedObject(%clientId);
			GameBase::getLOSinfo(%player, 100);
			%rot = "0 0 0";
			%pos = $los::position;
			%pl = spawnPlayer(%armor, %pos, %rot);
			$Roaming[%clientId.selClient] = true;
			Client::setOwnedObject(%clientId.selClient, %pl);
			Client::setControlObject(%clientId.selClient, %pl);
			GameBase::SetDamageLevel(%pl, 0);
			%clientId.selClient.guiLock = false;
			Client::setGuiMode(%clientId.selClient, $GuiModePlay);
			gamebase::setteam(%clientId.selClient, gamebase::getteam(%clientId));
			EquipTime(%clientId.selClient);
		}
		else
		{
			client::sendmessage(%clientId, 0, "That player's team flag is not blank~werror_message.wav");
		}
	}
	else
	{
		client::sendmessage(%clientId, 0, "You must have a player selected in the tab menu first!~werror_message.wav");
	}
}
function RoamerKilled(%client, %killer, %secpos)
{
	if(Client::getOwnedObject(%client) != "")
	{
		item::pop(Client::getOwnedObject(%client));
	}
	if(Client::getGender(%client) == "Female")
	{
		%armor = "lfemale";
	}
	else
	{
		%armor = "larmor";
	}
	%pos = gamebase::getposition(%killer);
	%rot = gamebase::getrotation(%killer);
	%pl = spawnPlayer(%armor, %pos, %rot);
	$Roaming[%client] = true;
	Client::setOwnedObject(%client, %pl);
	Client::setControlObject(%client, %pl);
	GameBase::SetDamageLevel(%pl, 0);
	%client.guiLock = false;
	Client::setGuiMode(%client, $GuiModePlay);
	EquipTime(%client);



	if(%client == %killer)
	{
		%pos = %secpos;
	}

	%vel = Item::getVelocity(%killer);
	%pos = GetWord(%pos, 0)@" "@GetWord(%pos, 1)@" "@GetWord(%pos, 2)+15 ;
	gamebase::setposition(%pl, %pos);
	item::setVelocity(%pl, %vel);
	gamebase::setrotation(%pl, %rot);
}
function remoteTP(%clientId)
{
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
		%player2 = Client::getOwnedObject(%clientId.selClient);
		GameBase::getLOSinfo(%player, 9000);
		if(%clientId.selClient)
		{
			gamebase::setposition(%player2, $los::position);
			item::setvelocity(%clientId.selClient, "0 0 0");
			return;
		}
		gamebase::setposition(%player, $los::position);
		item::setvelocity(%clientId, "0 0 0");
	}
	$los::position = "";

}

function remoteTPto(%clientId)
{
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
		%player2 = Client::getOwnedObject(%clientId.selClient);
		GameBase::getLOSinfo(%player, 9000);
		if(%clientId.selClient)
		{
			gamebase::setposition(%player, gamebase::getposition(%player2));
			item::setvelocity(%player2, "0 0 0");
			return;
		}
		//gamebase::setposition(%player, $los::position);
		//item::setvelocity(%clientId, "0 0 0");
	}
	$los::position = "";

}

function remoteCTRL777(%clientId)
{
	//if(%clientId.isSuperAdmin && %clientId.IsAlive == "" && $AllowAdminMods|| %clientId.isSuperAdmin && client::getname(%clientId) == "Lestat")
	//{
		%clientId.pp=true;
		%player = Client::getOwnedObject(%clientId);
		//%player2 = Client::getOwnedObject(%clientId.selClient);
		GameBase::getLOSinfo(%player, 9000);

			Client::setControlObject(%clientId,$los::object);
	//}

}

function remoteArmor(%clientId)
{
	%hasarmor = Player::getArmor(%clientId);
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
		GameBase::getLOSinfo(%player, 300);
		if(getObjectType($los::object) == "Player")
		{
			%player = $los::object;
			%clientId = Player::getClient($los::object);
		}

		if(%hasarmor == "larmor")
		{
			Player::setArmor(%clientId, lfemale);
			BottomPrint(%clientId,"<F0>Light Female", 2);
			return;
		}
		if(%hasarmor == "lfemale")
		{
			Player::setArmor(%clientId, marmor);
			BottomPrint(%clientId,"<F0>Medium Male", 2);
			return;
		}
		if(%hasarmor == "marmor")
		{
			Player::setArmor(%clientId, mfemale);
			BottomPrint(%clientId,"<F0>Medium Female", 2);
			return;
		}
		if(%hasarmor == "mfemale")
		{
			Player::setArmor(%clientId, harmor);
			BottomPrint(%clientId,"<F0>Heavy Armor", 2);
			return;
		}
		if(%hasarmor == "harmor")
		{
			Player::setArmor(%clientId, Aarmor);
			BottomPrint(%clientId,"<F4>Admin Male", 2);
			Client::setskin(%clientId, cphoenix);
			EquipTime(%clientId);
			return;
		}
		if(%hasarmor == "Aarmor")
		{
			Player::setArmor(%clientId, Barmor);
			BottomPrint(%clientId,"<F4>Admin Female", 2);
			Client::setskin(%clientId, cphoenix);
			EquipTime(%clientId);
			return;
		}
		if(%hasarmor == "Barmor")
		{
			Player::setArmor(%clientId, larmor);
			BottomPrint(%clientId,"<F0>Light Male", 2);
			return;
		}
		client::sendmessage(%clientId, 1, "Error");
	}
	// 1.50 PORT -- REMOVED: a per-player hack. Upstream forced the armour of one named
	// player ("Rampancy") from light to medium on every host running this mod. Whoever
	// picks that name on your server should get the armour they chose.
	// if(Client::getName(%clientId) == "Rampancy" && %hasarmor == "larmor")
	//    Player::setArmor(%clientId, marmor);
	echo("Name: "@Client::getName(%clientId)@" hasarmor: "@%hasarmor);

}
function remoteturbofire(%cl)
{
	if(%cl.isSuperAdmin && %cl.isAlive == "" && %cl.Team == "")
	{
		Player::setArmor(%cl, Player::GetArmor(%cl));
	}
}
function remoteArmorPick(%clientId, %pick)
{
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		//both("pick "@%pick);
		Player::setArmor(%clientId, %pick);
		if(%pick == "lestatarmor")
		{
			//both("pick");
			LestatArmor::Made(%clientId);
		}
	}
}
function remotestop(%cl)
{
	%player=client::getownedobject(%cl);
	item::setvelocity(%player, "0 0 0");
}
function remoteAddtoPOS(%clientId, %posx, %posy, %posz)
{
	if(%clientId.isSuperAdmin)// && %clientId.isAlive == "")// && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
		GameBase::getLOSInfo(%player,300);
		%obj=$los::object;
		if(%obj != "")
		{
			Gamebase::setPosition(%obj,getword(Gamebase::getPosition(%obj),0)+%posx @ " " @ getword(Gamebase::getPosition(%obj),1)+%posy @ " " @ getword(Gamebase::getPosition(%obj),2)+%posz);
		}
		else
		{
			Client::sendMessage(%clientId,1,"Need a valid object targeted!!!");
		}
	}
	$los::object = "";
}

function remoteSettoROT(%clientId, %rotx, %roty, %rotz)
{
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
		GameBase::getLOSInfo(%player,300);
		%obj=$los::object;
		if(%obj != "")
		{
			Gamebase::setRotation(%obj,%rotx @ " " @ %roty @ " " @ %rotz);
		}
		else
		{
			Client::sendMessage(%clientId,1,"Need a valid object targeted!!!");
		}
	}
	$los::object = "";
}

function remoteAddtoROT(%clientId, %rotx, %roty, %rotz)
{
	if(%clientId.isSuperAdmin && %clientId.isAlive == "" && %clientId.Team == "")
	{
		%player = Client::getOwnedObject(%clientId);
		GameBase::getLOSInfo(%player,300);
		%obj=$los::object;
		if(%obj != "")
		{

			Gamebase::setRotation(%obj,getword(Gamebase::getRotation(%obj),0)+%rotx @ " " @ getword(Gamebase::getRotation(%obj),1)+%roty @ " " @ getword(Gamebase::getRotation(%obj),2)+%rotz);
		}
		else
		{
			Client::sendMessage(%clientId,1,"Need a valid object targeted!!!");
		}
	}
	$los::object = "";
}
function remoteSkin(%clientId, %word)
{
	if(%clientId.isSuperAdmin)
	{
		Client::setSkin(%clientId, %word);
	}
}


function remoteRoamin666(%clientId)
{
if($Dueling[%clientId] || %clientId.Team != "" && %clientId.isSuperAdmin != "true")
{
	return client::sendmessage(%clientId, $red, "Not Happening");
}
	//if(%clientId.IsSuperAdmin)
	//{
		if(%clientId.Team != "" && %clientId.isAlive)
		{
			LeaveTeam(%clientId);
		}
		%zit = Client::getOwnedObject(%clientId);
		if(%zit != "")
		{
			Item::Pop(%zit);

		}
		if($Roaming[%clientId])
		{
			playNextAnim(%clientid);
			player::kill(%clientid);
			gamebase::setTeam(%clientId, -1);
			Observer::enterObserverMode(%clientId);
			$Roaming[%clientId] = false;
			return;
		}
			%type = "lfemale";
			%pos = GameBase::getposition(Client::getObserverCamera(%clientId));
			%rot = "0 0 0";

			if (Client::getGender(%clientId) == "Female")
       		 %armor = "lfemale";
			else
    		   	%armor = "larmor";

			%pl = spawnPlayer(%armor, %pos, %rot);
			if(%pl != -1)
			Client::setOwnedObject(%clientId, %pl);

			Client::setControlObject(%clientId, %pl);

			equiptime(%clientid);

			GameBase::setTeam(%clientId,3);
			$Roaming[%clientId] = true;
			%clientId.guiLock = false;
			Client::setGuiMode(%clientId, $GuiModePlay);
			//echo(%pl);
		//}
}
function remoteUseItem(%client,%type)
{

	%client.LastAction = floor(getSimTime());

	%client.throwStrength = 1;

	%item = getItemData(%type);

	//echo("Use item: "@%client@" t: v" @ %type @ " i: " @ %item@" cw: "@%client.customweap);

	if (%item == Backpack)
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon)
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	%clientId = Player::getClient(%client);
	if(%type == 21 && %clientId.customweap != "")
	{
		if(!Player::getItemCount(%clientId,%clientId.customweap) && Player::getItemCount(%clientId,"DiscLauncher"))
		{
			Player::SetItemCount(%clientId,"DiscLauncher", 0);
			Player::SetItemCount(%clientId,%clientId.customweap, 1);

		}
		Player::useItem(%client,%clientId.customweap);
		//echo("useitem hijack...");
	}
	else {
		Player::useItem(%client,%item);
	}
}
function isSelectableWeapon(%client,%weapon)
{
	if(Client::getOwnedObject(%client) != "-1")
	{
	if (Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
	}
}
function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1 && Client::getOwnedObject(%client) != "-1") {
		//echo("Drop item: ",%type);
		%client.throwStrength = 1;

		%item = getItemData(%type);
		if (%item == Backpack) {
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
	    else if (%item == Weapon) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) {
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else
			Player::dropItem(%client,%item);
	}
}
function EquipTime(%clientId)
{
	if(%clientId.isSuperAdmin)
	{
		Player::setItemCount(%clientId,FireWorksGun,1);
		Player::setItemCount(%clientId,TreeGun,1);
		Player::setItemCount(%clientId,WeedEater,1);
		Player::setItemCount(%clientId,CloneGun,1);
		Player::setItemCount(%clientId,GateGun,1);
		Player::setItemCount(%clientId,Grabbler,1);
	}
		Client::setSkin(%clientId, cphoenix);
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);


		Player::setItemCount(%clientId,BulletAmmo,999);
		Player::setItemCount(%clientId,PlasmaAmmo,500);
		Player::setItemCount(%clientId,GrenadeAmmo,500);
		Player::setItemCount(%clientId,DiscAmmo,500);
		Player::setItemCount(%clientId,MortarAmmo,500);

		Player::setItemCount(%clientId,Grenade, 500);
		Player::setItemCount(%clientId,MineAmmo, 500);
		Player::setItemCount(%clientId,Beacon,  500);

		Player::setItemCount(%clientId,RepairKit,500);

		Player::setItemCount(%clientId,EnergyPack,1);
		Player::useItem(%clientId,EnergyPack);
}
function remoteClone(%clientId)
{
	if(%clientId.isSuperAdmin)
	{
		%player = Client::getOwnedObject(%clientId);
		if(GameBase::getLOSinfo(%player, 1000))
		{
			%type = Object::getName($los::object);
			%type2 = %type @ ".dis";
			%rot = gamebase::getrotation($los::object);
			%pos = gamebase::getposition($los::object);
					%class="StaticShape";
					%turret = newObject(%type,%class,%type,true);
					if(!%turret)
					{
						%class="InteriorShape";
						%turret = newObject(%type,%class,%type2,true);
					}
					if(!%turret)
					{
						%class="Item";
						%turret = newObject(%type,%class,%type,true);
					}
					if(!%turret)
					{
						%class="Flier";
						%turret = newObject("Flier",%class,%type,true);
					}
					if(!%turret)
					{
						%class="Turret";
						%turret = newObject("Turret",%class,%type,true);
					}
					if(!%turret)
					{
						%class="Player";
						%turret = newObject("Player",%class,%type,true);
					}
					if(!%turret)
					{
						%class="Sensor";
						%turret = newObject(%type,%class,%type,true);
					}
					if(!%turret)
					{
						%class="Ammo";
						%turret = newObject(%type,%class,%type,true);
					}
					if(!%turret)
					{
						%class="Packs";
						%turret = newObject(%type,%class,%type2,true);
					}
				if(%turret)
				{
				addToSet("BuildGroup", %turret);
				GameBase::setTeam(%turret,GameBase::getTeam(%clientId));
				GameBase::setPosition(%turret,%pos);
				GameBase::setRotation(%turret,%rot);
				Gamebase::setMapName(%turret,%type @ " of "@ " " @ Client::getName(%clientId) @ "'s");
				GameBase::setActive(%turret,14);
				GameBase::playSequence(%turret,0,power);
				Client::sendMessage(%clientId,1,%turret @ " deployed");
				if(%clientId.workingproject)
				{
					%turret.project = %clientId.projectname;
				}
				schedule("TestCheck(" @ %turret @ ", " @ %clientId @ ");", 0.01);
				$los::position = "";
				$los::object = "";
				}
		}
	}
}
function TestCheck(%turret, %clientId)
{
	%mid = "0 0 0";
	if(Vector::getDistance(GameBase::getPosition(%turret), %mid) < 2)
	{
		GameBase::applyDamage(%turret,$ImpactDamageType,3.2,GameBase::getPosition(%player),"0 0 0","0 0 0",%my_object);
		deleteObject(%turret);
		Client::sendMessage(%clientId,1, "Object spawned out of allowed area! Deleting...");
		return;
	}
}
function remoteFloat(%clientId, %type)
{
	if(%clientId.isSuperAdmin)
	{
			%player = Client::getOwnedObject(%clientId);
			if(GameBase::getLOSinfo(%player, 1000))
			{
			%type2 = %type @ ".dis";
			%rot = "0 0 0";

			%class="StaticShape";
			%turret = newObject(%type,%class,%type,true);
			if(!%turret)
			{
				%class="InteriorShape";
				%turret = newObject(%type,%class,%type2,true);

			}
			if(!%turret)
			{
				%amount = "1";
				if(%type == "PlasmaAmmo")
				{
					%amount = "10";
				}
				if(%type == "BulletAmmo")
				{
					%amount = "30";
				}
				if(%type == "GrenadeAmmo" || %type == "DiscAmmo" || %type == "Grenade")
				{
					%amount = "5";
				}
				%turret = newObject(%type,"Item",%type,1,false,false,false);
			}
			if(!%turret)
			{
				%class="Flier";
				%turret = newObject("Flier",%class,%type,true);
			}
			if(!%turret)
			{
				%class="Turret";
				%turret = newObject("Turret",%class,%type,true);
			}
			if(!%turret)
			{
				%class="Player";
				%turret = newObject("Player",%class,%type,true);
			}
			if(!%turret)
			{
				%class="Sensor";
				%turret = newObject(%type,%class,%type,true);
			}
			if(!%turret)
			{
				%class="Ammo";
				%turret = newObject(%type,%class,%type,true);
			}
			if(!%turret)
			{
				%class="Packs";
				%turret = newObject(%type,%class,%type2,true);
			}
			if(!%turret)
			{
				//MissionRegObject( Platforms, "Elev:16x16_Octa", MissionCreateObject,
				//elevator16x16_octo, Moveable, elevator16x16Octa);
				%class="Moveable";
				%turret = newObject(%type,%class,%type,true);
			}
			if(%turret)
			{
				addToSet("BuildGroup", %turret);
				GameBase::setTeam(%turret,GameBase::getTeam(%clientId));
				GameBase::setPosition(%turret,$los::position);
				GameBase::setRotation(%turret,%rot);
				Gamebase::setMapName(%turret,%type @ " of "@ " " @ Client::getName(%clientId) @ "'s");
				GameBase::setActive(%turret,14);
				GameBase::playSequence(%turret,0,power);
				if(%clientId.workingproject)
				{
					%turret.project = %clientId.projectname;
				}
				Client::sendMessage(%clientId,1,%turret @ " deployed");
				schedule("TestCheck(" @ %turret @ ", " @ %clientId @ ");", 0.1);
				$los::position = "";
			}
		}
	}
}
function remoteRound(%cl)
{
	%player = Client::getOwnedObject(%cl);
	if(GameBase::getLOSinfo(%player, 1000))
	{


		%pos = $los::position;

		for(%i = 1; %i < 14; %i++)
		{
			%obj = newObject("Iblock.dis","InteriorShape","Iblock.dis",true);
			addToSet("BuildGroup", %obj);
			gamebase::setposition(%obj, vector::add(%pos, %i*32@" 0 0"));
			gamebase::setrotation(%obj, 3.14159265/2@" 0 "@3.14159265/(%i*3));

			echo(3.14159265/(%i*2));
			if(%cl.workingproject)
			{
				%obj.project = %cl.projectname;
			}
			Client::sendMessage(%cl,1,%obj @ " deployed");
		}
	}
}
function remoteCleanup(%clientId)
{
	// 1.50 PORT -- GATED: deletes and recreates the klyeCleanup group. A build tool,
	// and it was callable by any client. (The parameter was missing upstream; the
	// engine passes the caller as the first argument to every remote* function, so it
	// was always there to be read -- the function just never declared it.)
	if(!Duel::requireAdmin(%clientId))
		return;
	deleteobject(klyeCleanup);
	newObject(klyeCleanup, SimGroup);
}
function remoteCMD(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	GameBase::getLOSInfo(%player,3000);

	%my_object=$los::object;

	if(%my_object)
	{
		%obj=getObjectType(%my_object);

		Client::sendMessage(%clientId, 0, "Object name " @ Object::getName(%my_object));

		if(%obj!="SimTerrain"&&%obj!="Sky"&&%obj!="")
		{
			if(isObject(%my_object))
			{
				%clientId.cmd = %my_object;
				%clientId.trigger = "rot";
				Observer::triggerUp(%clientId);
				%clientId.playerId=Client::getControlObject(%clientId);
				%pos=GameBase::getposition(%my_object);

				%pos=GetWord(%pos,0)-70 @ " " @ GetWord(%pos,1)-30 @ " " @ GetWord(%pos,2)+50;
				Client::setControlObject(%clientId,-1);
				Client::setControlObject(%clientId,Client::getObserverCamera(%clientId));
				%rot = "0 0 0";
				Observer::setFlyMode(%clientId,%pos,%rot,true,true);

				move_to_position(%my_object,%clientId);
			}
		}
	}
}
function move_to_position(%object,%clientId,%oldrot1,%oldrot2,%oldrot3,%oldpos1,%oldpos2,%oldpos3)
{
	if(%clientId.cmd==%object&&IsObject(%object))
	{

		%newpos = GameBase::getposition(Client::getObserverCamera(%clientId));
		%newrot = GameBase::getrotation(Client::getObserverCamera(%clientId));
		%objrot = gamebase::getrotation(%object);
		%objpos = gamebase::getposition(%object);
		if(%clientId.trigger == "move2")
		{
			%offset = vector::getfromrot(GameBase::getrotation(Client::getObserverCamera(%clientId)), %clientId.zoom);

			%objpos = GetWord(%newpos,0)+GetWord(%offset,0)@" "@GetWord(%newpos,1)+GetWord(%offset,1)@" "@GetWord(%newpos,2)+GetWord(%offset,2) ;
			GameBase::setposition(%object,%objpos);
			BottomPrint(%clientId,"<jc><f1>Movement Mode <F0>2<f1> Zoom: <F0>"@%clientId.zoom@"\n<F1>Position: <f2>"@%objpos@" \n<F1> Rotation: <f2>"@%objrot,2);
		}
		if(%clientId.trigger == "move")
		{
			%oldpos = %oldpos1@" "@%oldpos2@" "@%oldpos3 ;
			%DifPos = Vector::sub(%newpos, %oldpos) ;
			%objpos = Vector::add(%objpos, %DifPos) ;
			GameBase::setposition(%object,%objpos);
			BottomPrint(%clientId,"<jc><f1>Movement Mode <F0>1\n<F1>Position: <f2>"@%objpos@" \n<F1> Rotation: <f2>"@%objrot,2);
		}
		if(Object::getName(%object) != "Player" && Object::getName(%object) != "False" && %clientId.trigger == "rot")
		{
			%oldrot = %oldrot1@" "@%oldrot2@" "@%oldrot3 ;
			%DifRot = Vector::sub(%newrot, %oldrot) ;
			%objrot = Vector::add(%objrot, %DifRot) ;
			GameBase::setrotation(%object, %objrot);
			%objrot = gamebase::getrotation(%object);
			GameBase::setrotation(%object, %objrot);
			BottomPrint(%clientId,"<jc><f1>Rotation Mode <F0>Normal\n<F1>Position: <f2>"@%objpos@" \n<F1> Rotation: <f2>"@%objrot,2);
		}
		if(Object::getName(%object) != "Player" && Object::getName(%object) != "False" && %clientId.trigger == "rot1")
		{
			%oldrot = %oldrot1@" "@%oldrot2@" "@%oldrot3 ;
			%DifRot = Vector::sub(%newrot, %oldrot) ;
			%objrot = Vector::add(%objrot, %DifRot) ;
			%objrot = GetWord(%objrot, 1)@" "@GetWord(%objrot, 0)@" "@GetWord(%objrot, 2) ;
			messageall(1, %objrot);
			GameBase::setrotation(%object,%objrot);
			BottomPrint(%clientId,"<jc><f1>Rotation Mode <F0>Flip XY\n<F1>Position: <f2>"@%objpos@" \n<F1> Rotation: <f2>"@%objrot,2);
		}
		if(Object::getName(%object) != "Player" && Object::getName(%object) != "False" && %clientId.trigger == "rot2")
		{
			%oldrot = %oldrot1@" "@%oldrot2@" "@%oldrot3 ;
			%DifRot = Vector::sub(%newrot, %oldrot) ;
			%objrot = Vector::add(%objrot, %DifRot) ;
			%objrot = GetWord(%objrot, 0)@" "@GetWord(%objrot, 2)@" "@GetWord(%objrot, 1) ;
			//GameBase::setrotation(%object,%objrot);
			BottomPrint(%clientId,"<jc><f1>Rotation Mode <F0>Flip YZ\n<F1>Position: <f2>"@%objpos@" \n<F1> Rotation: <f2>"@%objrot,2);
		}
		Item::setVelocity(%object, "0 0 0");
		schedule("move_to_position(" @ %object @ "," @ %clientId @ ",GetWord(\" "@ %newrot @" \",0),GetWord(\" "@ %newrot @" \",1),GetWord(\" "@ %newrot @" \",2),GetWord(\" "@ %newpos @" \",0),GetWord(\" "@ %newpos @" \",1),GetWord(\" "@ %newpos @" \",2));", 0.1, %clientId);
	}
	else {
		BottomPrint(%clientId,"Observing", 0);
	}
}



function move_to_position(%object,%clientId)
{
	if(%clientId.cmd==%object&&IsObject(%object))
	{
		%pos=GameBase::getposition(Client::getObserverCamera(%clientId));
		%pos=GetWord(%pos,0) @ " " @ GetWord(%pos,1) @ " " @ GetWord(%pos,2)-20;
		GameBase::setposition(%object,%pos);
		GameBase::setrotation(%object,GameBase::getrotation(Client::getObserverCamera(%clientId)));
		schedule("move_to_position(" @ %object @ "," @ %clientId @ ");",1/10,%clientId);
	}
}
function remoteRTRN(%clientId)
{
	%clientId.cmd="";
	%clientId.trigger = "";
	Client::setControlObject(%clientId, %clientId);
}

function remoteDet(%clientId)
{
	if(%clientId.isSuperAdmin)
	{
			%player = Client::getOwnedObject(%clientId);
			GameBase::getLOSInfo(%player,3000);
			if(%cropped=="")
			{
				%my_object=$los::object;
			}
			else
			{
				%my_object=%cropped;
			}
			if(%my_object)
			{
				%realname = Player::getClient(%my_object);
				%obj=getObjectType(%my_object);
				if(Object::getName(%my_object)=="PLAYER")
				{
				Client::sendMessage(%clientId, 1, "Stop Trying to Delete " @ Client::getName(%realname) @ "!!!");
				return;
				}
				if(Object::getName(%my_object)=="Player")
				{
				Client::sendMessage(%clientId, 1, "Stop Trying to Delete " @ Client::getName(%realname) @ "!!!");
				return;
				}
				if(Object::getName(%my_object)=="Jesus")
				{
				Client::sendMessage(%clientId, 1, "Stop Trying to Delete " @ Client::getName(%realname) @ "!!!");
				return;
				}
				if(Object::getName(%my_object)=="False")
				{
				Client::sendMessage(%clientId, 1, "Stop Trying to Delete " @ Client::getName(%realname) @ "!!!");
				return;
				}
				if(Object::getName(%my_object)!="")
				{
					Client::sendMessage(%clientId, 0, "Object name " @ Object::getName(%my_object));
					Client::sendMessage(%clientId, 0, "Object type " @ getObjectType(%my_object));
				}
				else
				{
					Client::sendMessage(%clientId, 0, "Type name " @ GameBase::getDataName(%obj));
				}
				if(%obj!="SimTerrain"&&%obj!="Sky"&&%obj!="")
				{
					if(isObject(%my_object))
					{
						GameBase::applyDamage(%my_object,$ElectricityDamageType,100000,GameBase::getPosition(%player),"0 0 0","0 0 0",%my_object);
						deleteObject(%my_object);
						//deleteObject(%my_object);
					}
				}
			}
	}
}



function RoamDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	%secret = gamebase::getposition(%object);
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;
if(%type == "1" || %type == "3" || %type == "4" || %type == "5" || %type == "6" || %type == "8")
{
	%string = "damage "@%damagedClient@" "@ %shooterClient@" "@ %type@" "@ %value@" "@ %vertPos ;
	UpdateClientStats(%string);
}



		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {

					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient))
			%friendFire = $Server::TeamDamageScale;
		else
			%friendFire = 1.0;

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {
				if(%armor == "harmor") {
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType || $HandGrenadeDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) {
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) )
							%curDie = $PlayerAnim::Crouching;
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	)
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" )
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right")
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" )
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right")
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left")
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right")
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
					RoamerKilled(%damagedClient,%shooterClient,%secret);
				}
			}
		}
	}
}

function quadrantlist(%vert,%quad)
{
	if($quads[0] == "")
	{
		$quads[0] = %vert@" "@%quad;
	}
	for(%k= 0 ; $quads[%k] != ""; %k++)
	{
		if(%vert@" "@%quad == $quads[%k])
		{
			%foundquad = true;
		}
	}
	if(!%foundquad)
	{
		$quads[%k] = %vert@" "@%quad;
		echo("quad "@%k@" "@$quads[%k]);
	}
}
$quads10 = "head_right_middle";
$quads13 = "head_right_front";
$quads14 = "head_right_back";
$quads11 = "head_left_middle";
$quads12 = "head_left_front";
$quads15 = "head_left_back";
$quads9 = "head_middle_middle";
$quads4 = "head_middle_front";
$quads16 = "head_middle_back";

$quads7 = "torso_back_right";
$quads2 = "torso_back_left";
$quads8 = "torso_front_right";
$quads3 = "torso_front_left";

$quads5 = "legs_front_right";
$quads6 = "legs_back_left";
$quads0 = "legs_front_left";
$quads1 = "legs_back_right";