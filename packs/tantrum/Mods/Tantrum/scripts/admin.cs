exec("botgun.cs");
$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$info = "";

$t1botty = "none";
$t2botty = "none";

function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   %index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	else $TypeStart = 1;
   for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
      if($MLIST::Type[%type] != "Training")
      {
         Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
         %index++;
      }
}

function processMenuCMType(%clientId, %options)
{
   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
         break;
      }
      Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
   }
}

function processMenuCMission(%clientId, %option)
{
   if(getWord(%option, 0) == "more")
   {
      %first = getWord(%option, 1);
      %type = getWord(%option, 2);
      processMenuCMType(%clientId, %type @ " " @ %first);
      return;
   }
   %mi = getWord(%option, 0);
   %mt = getWord(%option, 1);

   %misName = $MLIST::EName[%mi];
   %misType = $MLIST::Type[%mt];

   // verify that this is a valid mission:
   if(%misType == "" || %misType == "Training")
      return;
   for(%i = 0; true; %i++)
   {
      %misIndex = getWord($MLIST::MissionList[%mt], %i);
      if(%misIndex == %mi)
         break;
      if(%misIndex == -1)
         return;
   }
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
      Server::loadMission(%misName);
   }
   else
   {
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}

function remoteAdminPassword(%client, %password)
{
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
   }
}

function remoteSetPassword(%client, %password)
{
   if(%client.isSuperAdmin)
      $Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time)
{
   %time = floor(%time);
   if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
      return;
   if(%client.isAdmin)
   {
      $Server::timeLimit = %time;
      if(%time)
         messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
      else
         messageAll(0, Client::getName(%client) @ " disabled the time limit.");
         
   }
}


function processMenuweapsmenu(%clientId, %pck)
{
%r = 0;
%nane = 0;
	if ($spawnBuyList[3] != "") {
		if ($spawnBuyList[4] == "") 
			%r = 4;
		else if ($spawnBuyList[4] != "") {
			if ($spawnBuyList[5] == "")
				%r = 5;
			else if ($spawnBuyList[5] != "") {
				if ($spawnBuyList[6] == "")
					%r = 6;
				else if ($spawnBuyList[6] != "") {
					if ($spawnBuyList[7] == "")
						%r = 7;
					else if ($spawnBuyList[7] != "") {
						if ($spawnBuyList[8] == "")
							%r = 8;
					}
				}
			}
		}
	}

	else if ($spawnBuyList[3] == "")
		%r = 3;

		if (%r == 3)
			%slot = 1;
		if (%r == 4)
			%slot = 2;
		if (%r == 5)
			%slot = 3;
		if (%r == 6)
			%slot = 4;
		if (%r == 7)
			%slot = 5;
		if (%r == 8)
			%slot = 6;
	

   if(%pck == -7) {
		if (%slot == 1) {
			$spawnBuyList[3] = DiscLauncher;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = DiscLauncher;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = DiscLauncher;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = DiscLauncher;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = DiscLauncher;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = DiscLauncher;
		}
  }
   else if(%pck == -6) {
		if (%slot == 1) {
			$spawnBuyList[3] = Chaingun;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = Chaingun;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = Chaingun;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = Chaingun;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = Chaingun;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = Chaingun;
		}

  }

   else if(%pck == -5) {
	if ($spawnBuyList[0] == JuggernautArmor || $spawnBuyList[0] == EngineerArmor) {
		if (%slot == 1) {
			$spawnBuyList[3] = Shotgun;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = Shotgun;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = Shotgun;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = Shotgun;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = Shotgun;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = Shotgun;
		}
 	}
 	else if($spawnBuyList[0] != JuggernautArmor || $spawnBuyList[0] != EngineerArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Shotguns are for Engineers and Juggernauts only", 5);
	}
  }

   else if(%pck == -4) {
	if ($spawnBuyList[0] == SniperArmor) {
		if (%slot == 1) {
			$spawnBuyList[3] = SniperRifle;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = SniperRifle;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = SniperRifle;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = SniperRifle;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = SniperRifle;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = SniperRifle;
		}
 	}
	else if($spawnBuyList[0] != SniperArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Sniper Rifles are for Assassins only", 5);
	}
  }

   else if(%pck == -3) {
	if ($spawnBuyList[0] == JuggernautArmor) {
		if (%slot == 1) {
			$spawnBuyList[3] = Mortar;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = Mortar;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = Mortar;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = Mortar;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = Mortar;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = Mortar;
		}
 	}
 	else if($spawnBuyList[0] != JuggernautArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Mortars are for Juggernauts only", 5);
	}
  }

   else if(%pck == -2) {
	if ($spawnBuyList[0] == JuggernautArmor) {
		if (%slot == 1) {
			$spawnBuyList[3] = bio;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = bio;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = bio;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = bio;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = bio;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = bio;
		}
 	}
 	else if($spawnBuyList[0] != JuggernautArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Argon is for Juggernauts only", 5);
	}
  }

   else if(%pck == -1) {
	if ($spawnBuyList[0] == JuggernautArmor) {
		if (%slot == 1) {
			$spawnBuyList[3] = moondustLauncher;
		}
		else if (%slot == 2) {
			$spawnBuyList[4] = moondustLauncher;
		}
		else if (%slot == 3) {
			$spawnBuyList[5] = moondustLauncher;
		}
		else if (%slot == 4) {
			$spawnBuyList[6] = moondustLauncher;
		}
		else if (%slot == 5) {
			$spawnBuyList[7] = moondustLauncher;
		}
		else if (%slot == 6) {
			$spawnBuyList[8] = moondustLauncher;
		}
 	}
 	else if($spawnBuyList[0] != JuggernautArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Moon Cannons are for Juggernauts only", 5);
	}
  }
}


function processMenueweapsmenu(%clientId, %pk)
{
	if ($spawnBuyList[3] != "") {
		if ($spawnBuyList[4] == "") 
			%q = 4;
		else if ($spawnBuyList[4] != "") {
			if ($spawnBuyList[5] == "")
				%q = 5;
			else if ($spawnBuyList[5] != "") {
				if ($spawnBuyList[6] == "")
					%q = 6;
				else if ($spawnBuyList[6] != "") {
					if ($spawnBuyList[7] == "")
						%q = 7;
					else if ($spawnBuyList[7] != "") {
						if ($spawnBuyList[8] == "")
							%q = 8;
					}
				}
			}
		}
	}

	else if ($spawnBuyList[3] == "")
		%q = 3;

		if (%q == 3)
			%sass = 1;
		if (%q == 4)
			%sass = 2;
		if (%q == 5)
			%sass = 3;
		if (%q == 6)
			%sass = 4;
		if (%q == 7)
			%sass = 5;
		if (%q == 8)
			%sass = 6;

   if(%pk == -4) {
	if ($spawnBuyList[0] == ELFEliteForceArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sass @ ": <f0>Taser", 5);
   		%weapon = poly;
 	}
	else if($spawnBuyList[0] != ELFEliteForceArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Tasers can only be carried by Gyps", 5);
	}
  }
   else if(%pk == -3) {
	if ($spawnBuyList[0] == ELFEliteForceArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sass @ ": <f0>Energy Screen", 5);
   		%weapon = encan;
 	}
	else if($spawnBuyList[0] != ELFEliteForceArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Energy Screens can only be carried by Gyps", 5);
	}
  }
   else if(%pk == -2) {
	if ($spawnBuyList[0] == ELFEliteForceArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sass @ ": <f0>EMP", 5);
   		%weapon = wavegun;
 	}
	else if($spawnBuyList[0] != ELFEliteForceArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Electro-Magnetic Pulses can only be executed by a Gyp", 5);
	}
  }
   else if(%pk == -1) {
	if ($spawnBuyList[0] == MedicArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sass @ ": <f0>Welding Gun", 5);
   		%weapon = Replauncher;
 	}
	else if($spawnBuyList[0] != MedicArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Repair Tools can only be carried by Medics", 5);
	}
  }
 $spawnBuyList[%q] = %weapon;
}

function processMenupweapsmenu(%clientId, %pec)
{
	if ($spawnBuyList[3] != "") {
		if ($spawnBuyList[4] == "") 
			%y = 4;
		else if ($spawnBuyList[4] != "") {
			if ($spawnBuyList[5] == "")
				%y = 5;
			else if ($spawnBuyList[5] != "") {
				if ($spawnBuyList[6] == "")
					%y = 6;
				else if ($spawnBuyList[6] != "") {
					if ($spawnBuyList[7] == "")
						%y = 7;
					else if ($spawnBuyList[7] != "") {
						if ($spawnBuyList[8] == "")
							%y = 8;
					}
				}
			}
		}
	}

	else if ($spawnBuyList[3] == "")
		%y = 3;

		if (%y == 3)
			%sac = 1;
		if (%y == 4)
			%sac = 2;
		if (%y == 5)
			%sac = 3;
		if (%y == 6)
			%sac = 4;
		if (%y == 7)
			%sac = 5;
		if (%y == 8)
			%sac = 6;
	

   if(%pec == -4) {
	if ($spawnBuyList[0] == PyroArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sac @ ": <f0>Flame Thrower", 5);
   		%weapsel = plasflam;
 	}
	else if($spawnBuyList[0] != PyroArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Flame Throwers can only be carried by Pyros", 5);
	}
  }
   else if(%pec == -3) {
	if ($spawnBuyList[0] == PyroArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sac @ ": <f0>Hand Rockets", 5);
   		%weapsel = torch;
 	}
	else if($spawnBuyList[0] != PyroArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Hand Rockets can only be carried by Pyros", 5);
	}
  }
   else if(%pec == -2) {
	if ($spawnBuyList[0] == PyroArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sac @ ": <f0>Split Rocket Launcher (Napalm)", 5);
   		%weapsel = napalmfire;
 	}
	else if($spawnBuyList[0] != PyroArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Napalm can only be carried by a Pyro", 5);
	}
  }
   else if(%pec == -1) {
	if ($spawnBuyList[0] == PyroArmor) {
   		bottomprint(%clientId, "<jc><f2>Slot " @ %sac @ ": <f0>Plasma Launcher", 5);
   		%weapsel = plasmalauncher;
 	}
	else if($spawnBuyList[0] != PyroArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Plasma Launchers can only be carried by a Pyro", 5);
	}
  }
 $spawnBuyList[%y] = %weapsel;
}


function processMenucpack(%clientId, %pqck)
{
   if(%pqck == -6) {
	if ($spawnBuyList[0] == MedicArmor) {
   		bottomprint(%clientId, "<jc><f2>Backpack: <f0>Medical-Kit", 5);
   		$spawnBuyList[1] = RepairPack;
 	}
	else if($spawnBuyList[0] != MedicArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Medical-Kit can only be carried by Medics", 5);
	}
  }

   else if(%pqck == -5) {
	if ($spawnBuyList[0] == ELFEliteForceArmor) {
  	 	bottomprint(%clientId, "<jc><f2>Backpack: <f0>EnergyPack", 5);
   		$spawnBuyList[1] = EnergyPack;
 	}
	else if($spawnBuyList[0] != ELFEliteForceArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   EnergyPack is crafted for Gyp Armor", 5);
	}
  }
   else if(%pqck == -4) {
	if ($spawnBuyList[0] == PyroArmor) {
  	 	bottomprint(%clientId, "<jc><f2>Backpack: <f0>Gas Tank", 5);
   		$spawnBuyList[1] = GasTankPack;
 	}
	else if($spawnBuyList[0] != PyroArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Gas Tanks can only be carried by Pyros", 5);
	}

  }

   else if(%pqck == -3) {
	if ($spawnBuyList[0] == JuggernautArmor) {
  		bottomprint(%clientId, "<jc><f2>Backpack: <f0>Shield Pack", 5);
		$spawnBuyList[1] = ShieldPack;
 	}
 	else if($spawnBuyList[0] != JuggernautArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Shield Pack is crafted for Juggernaut Armor", 5);
	}
  }

   else if(%pqck == -2) {
	if ($spawnBuyList[0] == EngineerArmor) {
   		bottomprint(%clientId, "<jc><f2>BackPack: <f0>Teleportation Pack", 5);
   		$spawnBuyList[1] = TPack;
 	}
	else if($spawnBuyList[0] != EngineerArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Teleportation is an Engineer utility", 5);
	}
  }

   else if(%pqck == -1) {
	if ($spawnBuyList[0] == SniperArmor) {
   	 	bottomprint(%clientId, "<jc><f2>Backpack: <f0>Cloak", 5);
   		$spawnBuyList[1] = CloakingDevice;
 	}
	else if($spawnBuyList[0] != SniperArmor) {
		bottomprint(%clientId, "<jc><f1>Error:   Only Assassins may carry a Cloak", 5);
	}
  }
}

function wepsel(%e, $info)
{
   	centerprint(%clientId, "<jc><f2>weapon is " @ $info @ ".", 5);
	$spawnBuyList[%e] = $info;
}

function processMenucspawn(%clientId, %warrior)
{
   if(%warrior == -6) {
   bottomprint(%clientId, "<jc><f2>Class: <f0>Medic", 5);
   $spawnBuyList[0] = MedicArmor;
   if ($spawnBuyList[1] != "") {
	$spawnBuyList[1] = "";
   }
   if ($spawnBuyList[2] != "") {
	$spawnBuyList[2] = "";
   }
   if ($spawnBuyList[3] != "") {
	$spawnBuyList[3] = "";
   }
   if ($spawnBuyList[4] != "") {
	$spawnBuyList[4] = "";
   }
   if ($spawnBuyList[5] != "") {
	$spawnBuyList[5] = "";
   }
   if ($spawnBuyList[6] != "") {
	$spawnBuyList[6] = "";
   }
   if ($spawnBuyList[7] != "") {
	$spawnBuyList[7] = "";
   }
   if ($spawnBuyList[8] != "") {
	$spawnBuyList[8] = "";
   }
}

   else if(%warrior == -5) {
   bottomprint(%clientId, "<jc><f2>Class: <f0>Gyp", 5);
   $spawnBuyList[0] = ELFEliteForceArmor;
   if ($spawnBuyList[1] != "") {
	$spawnBuyList[1] = "";
   }
   if ($spawnBuyList[2] != "") {
	$spawnBuyList[2] = "";
   }
   if ($spawnBuyList[3] != "") {
	$spawnBuyList[3] = "";
   }
   if ($spawnBuyList[4] != "") {
	$spawnBuyList[4] = "";
   }
   if ($spawnBuyList[5] != "") {
	$spawnBuyList[5] = "";
   }
   if ($spawnBuyList[6] != "") {
	$spawnBuyList[6] = "";
   }
   if ($spawnBuyList[7] != "") {
	$spawnBuyList[7] = "";
   }
   if ($spawnBuyList[8] != "") {
	$spawnBuyList[8] = "";
   }
}

   else if(%warrior == -4) {
   bottomprint(%clientId, "<jc><f2>Class: <f0>Pyro", 5);
   $spawnBuyList[0] = PyroArmor;
   if ($spawnBuyList[1] != "") {
	$spawnBuyList[1] = "";
   }
   if ($spawnBuyList[2] != "") {
	$spawnBuyList[2] = "";
   }
   if ($spawnBuyList[3] != "") {
	$spawnBuyList[3] = "";
   }
   if ($spawnBuyList[4] != "") {
	$spawnBuyList[4] = "";
   }
   if ($spawnBuyList[5] != "") {
	$spawnBuyList[5] = "";
   }
   if ($spawnBuyList[6] != "") {
	$spawnBuyList[6] = "";
   }
   if ($spawnBuyList[7] != "") {
	$spawnBuyList[7] = "";
   }
   if ($spawnBuyList[8] != "") {
	$spawnBuyList[8] = "";
   }
}

   else if(%warrior == -3) {
   bottomprint(%clientId, "<jc><f2>Class: <f0>Assassin", 5);
   $spawnBuyList[0] = SniperArmor;
   if ($spawnBuyList[1] != "") {
	$spawnBuyList[1] = "";
   }
   if ($spawnBuyList[2] != "") {
	$spawnBuyList[2] = "";
   }
   if ($spawnBuyList[3] != "") {
	$spawnBuyList[3] = "";
   }
   if ($spawnBuyList[4] != "") {
	$spawnBuyList[4] = "";
   }
   if ($spawnBuyList[5] != "") {
	$spawnBuyList[5] = "";
   }
   if ($spawnBuyList[6] != "") {
	$spawnBuyList[6] = "";
   }
   if ($spawnBuyList[7] != "") {
	$spawnBuyList[7] = "";
   }
   if ($spawnBuyList[8] != "") {
	$spawnBuyList[8] = "";
   }
}

   else if(%warrior == -2) {
   bottomprint(%clientId, "<jc><f2>Class: <f0>Engineer", 5);
   $spawnBuyList[0] = EngineerArmor;
   if ($spawnBuyList[1] != "") {
	$spawnBuyList[1] = "";
   }
   if ($spawnBuyList[2] != "") {
	$spawnBuyList[2] = "";
   }
   if ($spawnBuyList[3] != "") {
	$spawnBuyList[3] = "";
   }
   if ($spawnBuyList[4] != "") {
	$spawnBuyList[4] = "";
   }
   if ($spawnBuyList[5] != "") {
	$spawnBuyList[5] = "";
   }
   if ($spawnBuyList[6] != "") {
	$spawnBuyList[6] = "";
   }
   if ($spawnBuyList[7] != "") {
	$spawnBuyList[7] = "";
   }
   if ($spawnBuyList[8] != "") {
	$spawnBuyList[8] = "";
   }
}

   else if(%warrior == -1) { 
   bottomprint(%clientId, "<jc><f2>Class: <f0>Juggernaut", 5);
   $spawnBuyList[0] = JuggernautArmor;
   if ($spawnBuyList[1] != "") {
	$spawnBuyList[1] = "";
   }
   if ($spawnBuyList[2] != "") {
	$spawnBuyList[2] = "";
   }
   if ($spawnBuyList[3] != "") {
	$spawnBuyList[3] = "";
   }
   if ($spawnBuyList[4] != "") {
	$spawnBuyList[4] = "";
   }
   if ($spawnBuyList[5] != "") {
	$spawnBuyList[5] = "";
   }
   if ($spawnBuyList[6] != "") {
	$spawnBuyList[6] = "";
   }
   if ($spawnBuyList[7] != "") {
	$spawnBuyList[7] = "";
   }
   if ($spawnBuyList[8] != "") {
	$spawnBuyList[8] = "";
   }
 }
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
   if(%team >= 0 && %team < 8 && %client.isAdmin)
   {
      $Server::teamName[%team] = %teamName;
      $Server::teamSkin[%team] = %skinBase;
      messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
   }
}

function remoteVoteYes(%clientId)
{
   %clientId.vote = "yes";
   centerprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
   %clientId.vote = "no";
   centerprint(%clientId, "", 0);
}

function Admin::startMatch(%admin)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(!$CountdownStarted && !$matchStarted)
      {
         if(%admin == -1)
            messageAll(0, "Match start countdown forced by vote.");
         else
            messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));
      
         Game::ForceTourneyMatchStart();
      }
   }
}

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

function Admin::kick(%admin, %client, %ban)
{
   if(%admin != %client && (%admin == -1 || %admin.isAdmin))
   {
      if(%ban && !%admin.isSuperAdmin)
         return;
         
      if(%ban)
      {
         %word = "banned";
         %cmd = "BAN: ";
      }
      else
      {
         %word = "kicked";
         %cmd = "KICK: ";
      }
      if(%client.isSuperAdmin)
      {
         if(%admin == -1)
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
         Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
      }
   }
}

function Admin::setModeFFA(%clientId)
{
   if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
   {
      $Server::TeamDamageScale = 0;
      if(%clientId == -1)
         messageAll(0, "Server switched to Free-For-All Mode.");
      else
         messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");

      $Server::TourneyMode = false;
      centerprintall(); // clear the messages
      if(!$matchStarted && !$countdownStarted)
      {
         if($Server::warmupTime)
            Server::Countdown($Server::warmupTime);
         else   
            Game::startMatch();
      }
   }
}

function Admin::setModeTourney(%clientId)
{
   if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
   {
      $Server::TeamDamageScale = 1;
      if(%clientId == -1)
         messageAll(0, "Server switched to Tournament Mode.");
      else
         messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");

      $Server::TourneyMode = true;
      Server::nextMission();
   }
}

function Admin::voteFailed()
{
   $curVoteInitiator.numVotesFailed++;

   if($curVoteAction == "kick" || $curVoteAction == "admin")
      $curVoteOption.voteTarget = "";
}

function Admin::voteSucceded()
{
   $curVoteInitiator.numVotesFailed = "";
   if($curVoteAction == "kick")
   {
      if($curVoteOption.voteTarget)
         Admin::kick(-1, $curVoteOption);
   }
   else if($curVoteAction == "admin")
   {
      if($curVoteOption.voteTarget)
      {
         $curVoteOption.isAdmin = true;
         messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
         if($curVoteOption.menuMode == "options")
            Game::menuRequest($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "cmission")
   {
      messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
      Server::loadMission($curVoteOption);
   }
   else if($curVoteAction == "tourney")
      Admin::setModeTourney(-1);
   else if($curVoteAction == "ffa")
      Admin::setModeFFA(-1);
   else if($curVoteAction == "etd")
      Admin::setTeamDamageEnable(-1, true);
   else if($curVoteAction == "dtd")
      Admin::setTeamDamageEnable(-1, false);
   else if($curVoteOption == "smatch")
      Admin::startMatch(-1);
}

function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
      return;

   %votesFor = 0;
   %votesAgainst = 0;
   %votesAbstain = 0;
   %totalClients = 0;
   %totalVotes = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
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
   %minVotes = floor($Server::MinVotesPct * %totalClients);
   if(%minVotes < $Server::MinVotes)
      %minVotes = $Server::MinVotes;

   if(%totalVotes < %minVotes)
   {
      %votesAgainst += %minVotes - %totalVotes;
      %totalVotes = %minVotes;
   }
   %margin = $Server::VoteWinMargin;
   if($curVoteAction == "admin")
   {
      %margin = $Server::VoteAdminWinMargin;
      %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
      if(%totalVotes < %minVotes)
         %totalVotes = %minVotes;
   }
   if(%votesFor / %totalVotes >= %margin)
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteSucceded();
   }
   else  // special team kick option:
   {
      if($curVoteAction == "kick") // check if the team did a majority number on him:
      {
         %votesFor = 0;
         %totalVotes = 0;
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
            {
               %totalVotes++;
               if(%cl.vote == "yes")
                  %votesFor++;
            }
         }
         if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
         {
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)
{
   if(%clientId.lastVoteTime == "")
      %clientId.lastVoteTime = -$Server::MinVoteTime;

   // we want an absolute time here.
   %time = getIntegerTime(true) >> 5;
   %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

   if(%diff > 0)
   {
      Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
      return;
   }
   if($curVoteTopic == "")
   {
      if(%clientId.numFailedVotes)
         %time += %clientId.numFailedVotes * $Server::VoteFailTime;

      %clientId.lastVoteTime = %time;
      $curVoteInitiator = %clientId;
      $curVoteTopic = %topic;
      $curVoteAction = %action;
      $curVoteOption = %option;
      if(%action == "kick")
         $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
      $curVoteCount++;
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         %cl.vote = "";
      %clientId.vote = "yes";
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(%cl.menuMode == "options")
            Game::menuRequest(%clientId);
      schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
   }
   else
   {
      Client::sendMessage(%clientId, 0, "Voting already in progress.");
   }
}

function Game::menuRequest(%clientId, %player)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
      Client::addMenuItem(%clientId, %curItem++ @ "[ Spawn Setup Menu ]", "smenu");
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
//	%checkmaster = $t1botmaster;
//	%checkmaster2 = $t2botmaster;
	%teamchoice = Client::getTeam(%clientId);
	if (%teamchoice == 0){
		$t1botty = %name;
//           bottomprint(%clientId, "<jc><f2>T1: " @ %name, 3);
	}
	else if (%teamchoice == 1){
		$t2botty = %name;
//           bottomprint(%clientId, "<jc><f2>T2: " @ %name, 3);
	}
	%teamtwo = Client::getTeam(%clientId.selClient);
		if(%teamtwo == %teamchoice) {
        	 Client::addMenuItem(%clientId, %curItem++ @ "Follow " @ %name @ " with a Droid", "fdroid " @ %sel);
		}
		else if(%teamtwo != %teamchoice) {
       		  Client::addMenuItem(%clientId, %curItem++ @ "Attack " @ %name @ " with a Droid", "fdroid " @ %sel);
		}
      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
      remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
   }
}

function processMenuspizzawn(%clientId, %pick)
{
	if(%pick == -7) {
           bottomprint(%clientId, "<jc><f2>You Will Spawn as a <f0>Medic", 3);
//		$spawnBuyList[0] = MedicArmor;
//		$spawnBuyList[1] = RepairPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = Chaingun;
//		$spawnBuyList[5] = RepLauncher;
//		$spawnBuyList[6] = Flagger;
//		$spawnBuyList[7] = MineAmmo;
//		$spawnBuyList[8] = grenade;
//		$spawnBuyList[9] = lightgun;
//		$spawnBuyList[10] = "";
$spawnChoice[%clientId] = "Medic";
$spawnArmor[%clientId] = "MedicArmor";
	}
	if(%pick == -6) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as an <f0>Assassin", 3);
//		$spawnBuyList[0] = SniperArmor;
//		$spawnBuyList[1] = Claking;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = SniperRifle;
//		$spawnBuyList[5] = dagger;
//		$spawnBuyList[6] = lightgun;
//		$spawnBuyList[7] = MineAmmo;
//		$spawnBuyList[8] = grenade;
//		$spawnBuyList[9] = "";
$spawnChoice[%clientId] = "Assassin";
$spawnArmor[%clientId] = "SniperArmor";
	}
	if(%pick == -5) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as an <f0>Energy Gyp", 3);
//		$spawnBuyList[0] = ELFEliteForceArmor;
//		$spawnBuyList[1] = EnergyPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = poly;
//		$spawnBuyList[5] = Burster;
//		$spawnBuyList[6] = WaveGun;
//		$spawnBuyList[7] = MineAmmo;
//		$spawnBuyList[8] = grenade;
//		$spawnBuyList[9] = "";
$spawnChoice[%clientId] = "EnergyGyp";
$spawnArmor[%clientId] = "ELFArmor";
	}
	if(%pick == -4) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as a <f0>Pyro", 3);
//		$spawnBuyList[0] = PyroArmor;
//		$spawnBuyList[1] = GasTankPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = torch;
//		$spawnBuyList[4] = plasflam;
//		$spawnBuyList[5] = Flamer;
//		$spawnBuyList[6] = PlasmaGun;
//		$spawnBuyList[7] = MineAmmo;
//		$spawnBuyList[8] = grenade;
//		$spawnBuyList[9] = "";
$spawnChoice[%clientId] = "Pyro";
$spawnArmor[%clientId] = "PyroArmor";
	}
	if(%pick == -3) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as an <f0>Engineer", 3);
//		$spawnBuyList[0] = EngineerArmor;
//		$spawnBuyList[1] = TalePack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = GrenadeLauncher;
//		$spawnBuyList[5] = Shotgun;
//		$spawnBuyList[6] = Chaingun;
//		$spawnBuyList[7] = MineAmmo;
//		$spawnBuyList[8] = grenade;
//		$spawnBuyList[9] = "";
$spawnChoice[%clientId] = "Engineer";
$spawnArmor[%clientId] = "EngineerArmor";
	}
	if(%pick == -2) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as a <f0>Trooper", 3);
//		$spawnBuyList[0] = TrooperArmor;
//		$spawnBuyList[1] = EnergyPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = latgun;
//		$spawnBuyList[4] = Shotgun;
//		$spawnBuyList[5] = RocketLauncher;
//		$spawnBuyList[6] = GrenadeLauncher;
//		$spawnBuyList[7] = MineAmmo;
//		$spawnBuyList[8] = grenade;
//		$spawnBuyList[9] = "";
$spawnChoice[%clientId] = "Trooper";
$spawnArmor[%clientId] = "TrooperArmor";
	}
	if(%pick == -1) {
      		Client::buildMenu(%clientId, "Select Class:", "jugSpawn", true);
      		Client::addMenuItem(%clientId, "1Offesnive Juggernaut", -3);
      		Client::addMenuItem(%clientId, "2Kamikaze Juggernaut (Offense)", -2);
      		Client::addMenuItem(%clientId, "3Flag/Base Defending Juggernaut", -1);
  	    	return;
	}
}

function processMenucdroid(%clientId, %chj)
{
	%tawn = Client::getTeam(%clientId);
if (%tawn == 0){
	%enewername = $t1botty;
      %fname = $t1firstbot;
      %sname = $t1secondbot;
      %tname = $t1thirdbot;
      %rrname = $t1fourthbot;
	if(%chj == -4) {
	     AI::DirectiveFollow(%fname,%enewername);
	     AI::SetAutomaticTargets(%fname);
            bottomprint(%clientId, "<jc><f0>" @ %fname @ " priority: <f2>" @ %enewername, 4);
	}
	if(%chj == -3) {
	     AI::DirectiveFollow(%sname,%enewername);
	     AI::SetAutomaticTargets(%sname);
            bottomprint(%clientId, "<jc><f0>" @ %sname @ " priority: <f2>" @ %enewername, 4);
	}
	if(%chj == -2) {
	     AI::DirectiveFollow(%tname,%enewername);
	     AI::SetAutomaticTargets(%tname);
            bottomprint(%clientId, "<jc><f0>" @ %tname @ " priority: <f2>" @ %enewername, 4);
	}
	if(%chj == -1) {
	     AI::DirectiveFollow(%rrname,%enewername);
	     AI::SetAutomaticTargets(%rrname);
            bottomprint(%clientId, "<jc><f0>" @ %rrname @ " priority: <f2>" @ %enewername, 4);
	}
}
else if (%tawn == 1){
	%nnewername = $t2botty;
      %frname = $t2firstbot;
      %srname = $t2secondbot;
      %trname = $t2thirdbot;
      %rsname = $t2fourthbot;
	if(%chj == -4) {
	     AI::DirectiveFollow(%frname,%nnewername);
	     AI::SetAutomaticTargets(%frname);
            bottomprint(%clientId, "<jc><f0>" @ %frname @ " priority: <f2>" @ %nnewername, 4);
	}
	if(%chj == -3) {
	     AI::DirectiveFollow(%srname,%newername);
	     AI::SetAutomaticTargets(%srname);
            bottomprint(%clientId, "<jc><f0>" @ %srname @ " priority: <f2>" @ %nnewername, 4);
	}
	if(%chj == -2) {
	     AI::DirectiveFollow(%trname,%newername);
	     AI::SetAutomaticTargets(%trname);
            bottomprint(%clientId, "<jc><f0>" @ %trname @ " priority: <f2>" @ %nnewername, 4);
	}
	if(%chj == -1) {
	     AI::DirectiveFollow(%rsname,%nnewername);
	     AI::SetAutomaticTargets(%rsname);
            bottomprint(%clientId, "<jc><f0>" @ %rsname @ " priority: <f2>" @ %nnewername, 4);
	}
}
}

function processMenujugSpawn(%clientId, %pake)
{
	if(%pake == -3) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as a <f0>Demolitions Juggernaut", 4);
//		$spawnBuyList[0] = JuggernautArmor;
//		$spawnBuyList[1] = EnergyPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = Shotgun;
//		$spawnBuyList[5] = Mortar;
//		$spawnBuyList[6] = bio;
//		$spawnBuyList[7] = moondustlauncher;
//		$spawnBuyList[8] = MineAmmo;
//		$spawnBuyList[9] = grenade;
//		$spawnBuyList[10] = "";
$spawnChoice[%clientId] = "Juggernaut1";
$spawnArmor[%clientId] = "JuggernautArmor";
	}
	if(%pake == -2) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as a <f0>Juggernaut<f2> with a Kamikaze Bomb - <f1>Use it wisely!", 4);
//		$spawnBuyList[0] = JuggernautArmor;
//		$spawnBuyList[1] = EnergyPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = Shotgun;
//		$spawnBuyList[5] = bio;
//		$spawnBuyList[6] = moondustlauncher;
//		$spawnBuyList[7] = thrower;
//		$spawnBuyList[8] = MineAmmo;
//		$spawnBuyList[9] = grenade;
//		$spawnBuyList[10] = "";
$spawnChoice[%clientId] = "Juggernaut2";
$spawnArmor[%clientId] = "JuggernautArmor";

	}
	if(%pake == -1) {
            bottomprint(%clientId, "<jc><f2>You Will Spawn as a <f0>Defensive Juggernaut", 4);
//		$spawnBuyList[0] = JuggernautArmor;
//		$spawnBuyList[1] = ShieldPack;
//		$spawnBuyList[2] = Repairkit;
//		$spawnBuyList[3] = DiscLauncher;
//		$spawnBuyList[4] = macgun;
//		$spawnBuyList[5] = Shotgun;
//		$spawnBuyList[6] = Mortar;
//		$spawnBuyList[7] = bio;
//		$spawnBuyList[8] = MineAmmo;
//		$spawnBuyList[9] = grenade;
//		$spawnBuyList[10] = "";
$spawnChoice[%clientId] = "Juggernaut3";
$spawnArmor[%clientId] = "JuggernautArmor";

	}
}


function processMenuSpawnmenu(%clientId, %pick)
{
   if(%pick == -7) {
      Client::buildMenu(%clientId, "Select Class:", "cspawn", true);
      Client::addMenuItem(%clientId, "0Medic", -6);
      Client::addMenuItem(%clientId, "1Energy gyp", -5);
      Client::addMenuItem(%clientId, "2Pyro", -4);
      Client::addMenuItem(%clientId, "3Assassin", -3);
      Client::addMenuItem(%clientId, "4Engineer", -2);
      Client::addMenuItem(%clientId, "5Juggernaut", -1);
      return;
   }
   if(%pick == -6) {
      Client::buildMenu(%clientId, "Select Backpack:", "cpack", true);
      Client::addMenuItem(%clientId, "0Medical-Kit", -6);
      Client::addMenuItem(%clientId, "1EnergyPack", -5);
      Client::addMenuItem(%clientId, "2Gas Tank", -4);
      Client::addMenuItem(%clientId, "3Shield Pack", -3);
      Client::addMenuItem(%clientId, "4Teleportation Pack", -2);
      Client::addMenuItem(%clientId, "5Cloak", -1);
      return;
   }
   if(%pick == -5) {
      Client::buildMenu(%clientId, "Select a Weapon:", "weapsmenu", true);
      Client::addMenuItem(%clientId, "0Spynfuser", -7);
      Client::addMenuItem(%clientId, "1Chaingun", -6);
      Client::addMenuItem(%clientId, "2Shotgun", -5);
      Client::addMenuItem(%clientId, "3Sniper Rifle", -4);
      Client::addMenuItem(%clientId, "4Mortar", -3);
      Client::addMenuItem(%clientId, "5Argon Split", -2);
      Client::addMenuItem(%clientId, "6Moon Cannon", -1);
      return;
   }
   if(%pick == -4) {
      Client::buildMenu(%clientId, "Select a Weapon:", "eweapsmenu", true);
      Client::addMenuItem(%clientId, "0Magnet Taser", -4);
      Client::addMenuItem(%clientId, "1Energy screen", -3);
      Client::addMenuItem(%clientId, "2EMP Shockwave", -2);
      Client::addMenuItem(%clientId, "3Welding Gun  (Repair)", -1);
      return;
   }
   if(%pick == -3) {
      Client::buildMenu(%clientId, "Select a Weapon:", "pweapsmenu", true);
      Client::addMenuItem(%clientId, "0Flame Thrower", -4);
      Client::addMenuItem(%clientId, "1Hand Rockets", -3);
      Client::addMenuItem(%clientId, "2Napalm Split", -2);
      Client::addMenuItem(%clientId, "3Plasma Launcher", -1);
      return;
   }
   if(%pick == -2) {
      Client::buildMenu(%clientId, "Select a Deployable:", "dpack", true);
      Client::addMenuItem(%clientId, "0D-t", -6);
      Client::addMenuItem(%clientId, "1Turret", -5);
      Client::addMenuItem(%clientId, "2Gxcxz", -4);
      Client::addMenuItem(%clientId, "3Shozt", -3);
      Client::addMenuItem(%clientId, "4Telep", -2);
      Client::addMenuItem(%clientId, "5Clousto", -1);
      return;
   }
   if(%pick == -1) {
      Client::buildMenu(%clientId, "Special Items:", "specials", true);
      Client::addMenuItem(%clientId, "0Flag-Decoy", -6);
      Client::addMenuItem(%clientId, "1sas", -5);
      Client::addMenuItem(%clientId, "2Gk", -4);
      Client::addMenuItem(%clientId, "3Shick", -3);
      Client::addMenuItem(%clientId, "4Teleportack", -2);
      Client::addMenuItem(%clientId, "5Cloke", -1);
      return;
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
   {
      if(Observer::enterObserverMode(%clientId))
      {
         %clientId.notready = "";
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   Game::refreshClientScore(%clientId);
		}
      return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

   Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "smenu")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "[ Spawn Setup ]", "Spizzawn", true);
      Client::addMenuItem(%clientId, "1Medic", -7);
     Client::addMenuItem(%clientId, "2Assassin", -6);
      Client::addMenuItem(%clientId, "3Energy Gyp", -5);
      Client::addMenuItem(%clientId, "4Pyro", -4);
      Client::addMenuItem(%clientId, "5Engineer", -3);
      Client::addMenuItem(%clientId, "6Trooper", -2);
      Client::addMenuItem(%clientId, "7Juggernaut", -1);
      return;
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "fdroid")
   {
      %ci.voteTarget = true;
	%arcut = Client::getName(%ci);
      %clientId.ptc = %cl;
	%tawn = Client::getTeam(%clientId);
if (%tawn == 0){
      %fname = $t1firstbot;
      %sname = $t1secondbot;
      %tname = $t1thirdbot;
      %trename = $t1fourthbot;
      Client::buildMenu(%clientId, "[ Choose a droid ]", "cdroid", true);
      Client::addMenuItem(%clientId, "1" @ %fname, -4);
      Client::addMenuItem(%clientId, "2" @ %sname, -3);
      Client::addMenuItem(%clientId, "3" @ %tname, -2);
      Client::addMenuItem(%clientId, "4" @ %trename, -1);
      return;
}
else if (%tawn == 1){
      %frname = $t2firstbot;
      %srname = $t2secondbot;
      %trname = $t2thirdbot;
      %tsrname = $t2fourthbot;
      Client::buildMenu(%clientId, "[ Choose a droid ]", "cdroid", true);
      Client::addMenuItem(%clientId, "1" @ %frname, -4);
      Client::addMenuItem(%clientId, "2" @ %srname, -3);
      Client::addMenuItem(%clientId, "3" @ %trname, -2);
      Client::addMenuItem(%clientId, "4" @ %tsrname, -1);
      return;
}
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}