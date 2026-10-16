//=========== CheckUNhackable Returns TRUE if NOT in the list.
function checkHackable(%name, %shape)
{
	//echo ("SHAPE " @ %shape);
	if(%shape == "chainturret" ||
	%shape == "remoteturret" ||
	%shape == "solar_med" ||
	%shape == "inventory_sta" ||
	%shape == "camera" ||
	%shape == "hellfiregun" ||
	%shape == "indoorgun" ||
	%shape == "mortar_turret" ||
	%shape == "ammounit" ||
	%shape == "sensor_pulse_med" ||
	%shape == "station_cmdpnl" ||
	%shape == "missileturret" ||
	%shape == "cmdpnl" ||
	%shape == "radar" ||
	%shape == "vehi_pur_pnl" ||
	%shape == "force" ||
	%shape == "bridge" ||
	%shape == "plasmawall" ||
	%shape == "anten_rod" ||
	%shape == "anten_small" ||
	%shape == "anten_lava" ||
	%shape == "anten_lrg" ||
	%shape == "anten_med" ||
	%shape == "dsply_h2" ||
	%shape == "enerpad" ||
	%shape == "vehi_pur_poles")

	{
		return 0;
	}
	else
		return 1;
}

function isPlayerBusy(%client)
{
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function hackingItem(%target, %pTeam, %pName, %tName, %team, %time, %client)
{
	%pName = Client::getName(%client); // PORT (2026-10-12): the name is no longer carried through the schedule() string
	%shape = (GameBase::getDataName(%target)).shapeFile;
	%name = GameBase::getMapName(%target);
	if(%name == "")
	{
		%name = (GameBase::getDataName(%player.repairTarget)).description;
	}
	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','" @ %client @ "','" @ %tName @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true")
	{
		if($hacking[%client] == "true")
		{
			if(%team == %pTeam)
			{
				if ($debug) echo ("infecting");
				%target.infected = "true";
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);
				%client.score = (%client.score + 2);
				if (%target.tc != "") systemMessage(%client,1,"Your " @ %name @ " is now firewalled, and free of sabotage.  Score +2 = " @ %client.score);
				else systemMessage(%client,1,"Your " @ %name @ " is now firewalled against hacking.  Score +2 = " @ %client.score);
				%target.tc = "";
				return;
			}
			else
			{

				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);
					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						systemMessage(%client,1,"You crack the firewall in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						%client.score = (%client.score + 2);
						systemMessage(%client,1,"You safely crack the firewall in the " @ %name @ ".  Score +2 = " @ %client.score);
						%target.infected = "false";
						return;
					}
				}

				if(%name == "False" && %shape == "liqcyl")
				{
					%rnd = floor(getRandom() * 10);
					if(%rnd == 1)
					{
					    systemMessage(%client,1,"OOPS! You cut the wrong wire...");
						Mine::Detonate(" @ %this @ ");
						return;
					}
					else
					{
					    systemMessage(%client,1,"You disarm the DetPack. Score +2 = " @ %client.score);
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}
				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					%client.score = (%client.score + 5);
					systemMessage(%client,1,"Your Score +5 = " @ %client.score);
					schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);
					GameBase::setTeam(%target,%pTeam);
					%target.tc = "";

					if($Wasteland::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Wasteland::HackedTime);
					}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
					if ($Wasteland::TurretKill && (%shape == "mortar_turret" || %shape == "camera" || %shape == "hellfiregun" || %shape == "indoorgun" || %shape == "chainturret" || %shape == "missileturret" || %shape == "remoteturret") )
					{
						%player = Client::getOwnedObject(%client);
						Client::setOwnedObject(%client, %target);
						Client::setOwnedObject(%client, %player);
					}
				}
			}
		}
	}
}

//==================== Check For Spawn Coverage.
function CheckForSpawn(%client,%pos)
{
	if ($noBuilding)
	{
		systemMessage(%client,1,"No deployables in this mission.");
		return False;
	}
	%playerteam = Client::getTeam(%client);
	if (%playerteam == 0) %team = 1; else %team = 0;
	%spntrpos = %playerteam.spntrpos;
	if (!%spntrpos) %spntrpos = "0 0 0";
 	%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
	%num = Group::objectCount(%group);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%group, %i);
		%homepos = GameBase::getPosition(%obj);
		if (Vector::getDistance(%pos,%homepos) < 30 && Vector::getDistance(%pos,%spntrpos) >30)
		{
			systemMessage(%client,1,"Too close to an enemy spawn point.");
			deleteObject(%set);
			return False;
		}
	}
	%i="";
	//======check for jail spawns
 	%group = nameToID("MissionCleanup/jailports");
	%num = Group::objectCount(%group);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%group, %i);
		%homepos = GameBase::getPosition(%obj);
		if (Vector::getDistance(%pos,%homepos) < 30)
		{
			systemMessage(%client,1,"Too close to a jail spawn point.");
			deleteObject(%set);
			return False;
		}
	}
	return True;
}

//=========================================== Deployables Functions
function checkDeployArea(%client, %pos, %l, %w, %h)
{
	if ($noBuilding)
	{
		systemMessage(%client,1,"No deployables in this mission.");
		return 0;
	}
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType| $SimInteriorObjectType;
  	%set=newObject("set",SimSet);
	if (%l && %w && %h)
	{
		%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType| $SimInteriorObjectType;
		containerBoxFillSet(%set,%Mask,%pos,%l,%w,%h,0);
	}
	else
	{
		%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType;
		containerBoxFillSet(%Set, %Mask, %pos, 1, 1, 1, 1);
	}
	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%set,%i);
		%datab = GameBase::getDataName(%obj);
		if (%obj != "-1")
		{
			if (%datab != "DeployablePlatform" && %datab != "BlastFloor" && %datab != "BlastWall")
			{
				if (%datab=="") %datab = "Item";
				if (getObjectType(%obj) == "Player")
				{
					if(Player::getClient(%obj) == %client) %datab="You're";
					else %datab = "Player";
				}
				Client::sendMessage(%client,1,"Unable to deploy - "@%datab@" in the way.");
				deleteObject(%set);
				return False;
			}
		}
	}
	deleteObject(%set);
	return True;
}

//===========================================
function CountObjects(%set,%name,%num)
{
	%count = 0;

	if (%name)
	{
		for(%i=0;%i<%num;%i++)
		{
			%obj=Group::getObject(%set,%i);
			if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
				%count++;
		}
	}
	else if (!%name)
	{
		for(%i=0;%i<%num;%i++)
		{
			%obj=Group::getObject(%set,%i);
			%object = getObjectType(%obj);
			%shape = GameBase::getDataName(%obj).shapeFile;
			if(%object == "Turret" || %shape == "flag")
				%count++;
		}
	}
	return %count;

}
//===========================================
function ixApplyKickback(%player, %strength, %lift)
{
	if((!%lift) && (%lift != 0))
		%lift = 0;

	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%dir = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}

function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function ixSin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

//---------------------------------------------------------------------------------
// Deployable Box
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 55;    	//Define Max Length of the area
$TurretBoxMaxWidth =  55;    	//Define Max Width of the area
$TurretBoxMaxHeight = 55;    	//Define Max Height of the area

$TurretBoxMinLength = 25;	//Define Min Length from another turret
$TurretBoxMinWidth =  25;	//Define Min Width from another turret
$TurretBoxMinHeight = 15;    	//Define Min Height from another turret

//================================= Deployable Functions
// %player  = Player Id doing the deploy
// %item    = Item being deployed
// %type    = Type of item - Turret, StaticShape, Beacon - etc
// %name    = Name of item - Ion Turret
// %angle   = Check angel (to mount on walls, etc.) (True/False/Player) Checks angel - Does Not Check - Uses Players Rotation Reguardless
// %freq    = Check Frequency (True/False) = Too Many Other Turrets
// %prox    = Check Proximity (True/False) = Too Many Of SAME Type Of Item
// %noinside= Checks to see if deployment is IN a building. (True - Checks To See, And will not allow a turret to be deployed inside)
// %area    = Check Area (for objects in the way) (True/False)
// %surface = Check Surface Type  (True/False)
// %range   = Max deploy distance from player (number best between 3 and 5) meters from player.
// %limit   = Check limit (True/False)
// %flag    = Give Flag Defence Bonus 0 = None and higher for score ammount.
// %kill    = Count for kills (for turrets)
// %deploy  = The item to be deployed (actualy item data name)
// %count   = What item to count

function deployable(%player,%item,%type,%name,%angle,%freq,%prox,%noinside,%area,%surface,%range,%limit,%flag, %kill, %deploy, %count)
{
	%client = Player::getClient(%player);
	%clientname = Client::getName(%client);
	%playerteam = Client::getTeam(%client);
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);

	if($TeamItemCount[GameBase::getTeam(%player) @ %count] < $TeamItemMax[%count])
	{
		if (GameBase::getLOSInfo(%player,%range))
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);
			%pos = $los::position;
			if (%type == "Turret" && %deploy != "DeployableSatchel")//==avoid spawn
			{
				if(!CheckForSpawn(%client,%playerpos))
				{
					return 0;
				}
			}
			if (%surface)
			{
				if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "BlastFloor" || %datab == "BlastWall"){}
				else
				{
					systemMessage(%client,1,"Can only deploy on terrain or buildings...");
					return;
				}
			}
			if (%prox)
			{
				%set = newObject("proxset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,%pos,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num){}
				else
				{
					systemMessage(%client,1,"Frequency Overload - Too close to other " @ %deploy @ "s.");
					return;
				}

				%set = newObject("minimumset",SimSet);
				%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, %pos, 2.5,2.5,2.5, 0);
				%num = CountObjects(%set,"",%num);
				deleteObject(%set);
				if(!%num){}else
				{
					systemMessage(%client,1,"Frequency Overload - Too close to other remote turrets");
					return;
				}
			}

			if (%noinside)
			{
				%padd = "0 0 10";%poss = Vector::add(%pos, %padd);
				for (%b=1; %b < 15; %b++)
				{
					%padd = "0 0 " @ %b;
					%poss = Vector::add(%pos, %padd);
					if(!GameBase::testPosition(%player, %poss))
						%nope = 1;
				}
				if (%nope == 1)
				{
					systemMessage(%client,0,"You can not deploy " @ %name @ ", space to enclosed.");
					return;
				}


			}
			if (%freq)
			{
				%set = newObject("freqset",SimSet);%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, $los::position, $TurretBoxMaxLength/2,$TurretBoxMaxWidth/2,$TurretBoxMaxHeight/2, 0);
				%num = CountObjects(%set,"",%num);
				deleteObject(%set);
				if(%num > 0)
				{
					systemMessage(%client,1,"Other objects in the way.");
					return;
				}
			}

			if (%angle == "True")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);

					if (Vector::dot($los::normal,"0 0 1") > 0.6)
					{
						%rot = "0 0 " @ %zRot;
					}
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
						{
							%rot = "3.14159 0 " @ %zRot;
						}
						else
						{
							%rot = Vector::getRotation($los::normal);
						}
					}
				}
				else
				{
					systemMessage(%client,1,"Can only deploy on flat surfaces");
					return 0;
				}
			}
			else if (%angle == "Player")
			{
				%rot = GameBase::getRotation(%player);
			}
			else if(%angle == "Flat")
			{
				%rot = "-1.54564 0.02591 -3.09105";

			}
			else if (!%angle || %angle == "False")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
			}

			if (%area)
			{
				if(!checkDeployArea(%client,$los::position))
				{
					return 0;
				}
			}

			%turret = newObject(%name,%type, %deploy,true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			systemMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;

			if (%type == "Turret")
				Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ %clientname);
			else
				Gamebase::setMapName(%turret, %name);

			if (%flagdist < %flag && %flag != 0)
			{
				%client.score = %client.score + $Score::FlagDef;
				bottomprint(%Client, "<jc>Score + " @ $Score::FlagDef @ " Flag Defense = " @ %client.score,3);
				Game::refreshClientScore(%client);
			}

			if ($Wasteland::TurretKill && %kill)
			{
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);
			}
			%turret.nukable = "True";
			echo("MSG: *****",%clientname," deployed a ",%name);
			return %turret;
		}
		else
			systemMessage(%client,1,"Deploy position out of range");
	}
	else
	 	systemMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "'s.");
	return false;
}

//=============================== Check Item Max
function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) )
		{
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}

//========================== Return All Items To Zero After Mission
function recountitem(%itemname)
{
	if ($debug) echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 8 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}
//=========================
function Mission::reinitData()
{
	recountitem("AccelPPack");
	recountitem("AirAmmoPad");
	recountitem("AirBase");
	recountitem("AirFuserPad");
	recountitem("AntennaPack");
	recountitem("AOE");
	recountitem("ArbitorBeaconPack");
	recountitem("BasePack");
	recountitem("BarragePack");
	recountitem("BlastDoorPack");
	recountitem("BlastFloorPack");
	recountitem("BlastWallPack");
	recountitem("BooM");
	recountitem("CameraPack");
	recountitem("CoolLauncher");
	recountitem("DeployableAmmoPack");
	recountitem("DeployableComPack");
	recountitem("DeployableElf");
	recountitem("DeployableInvPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("DeployableTeleport");
	recountitem("EmergencyInvPack");
	recountitem("EMPBeaconPack");
	recountitem("EnergyRifle");
	recountitem("BunkerPack");
	recountitem("EmpM");
	recountitem("EngBeacons");
	recountitem("EShield");
	recountitem("ForceFieldPack");
	recountitem("FighterVehicle");
	recountitem("GAPCVehicle");
	recountitem("GasM");
	recountitem("GunTuretPack");
	recountitem("HAPCVehicle");
	recountitem("InveiglerPack");
	recountitem("HolePack");
	recountitem("HoloPack");
	recountitem("MalicePack");
	recountitem("JammerBeaconPack");
	recountitem("LAPCVehicle");
	recountitem("LargeForceFieldPack");
	recountitem("LargeShockForceFieldPack");
	recountitem("LaserPack");
	recountitem("LaserMine");
	recountitem("LaunchPack");
	recountitem("MagBridgePack");
	recountitem("MechPack");
	recountitem("MFGLAmmo");
	recountitem("mineammo");
	recountitem("MotionSensorPack");
	recountitem("NukGen");
	recountitem("NapM");
	recountitem("BallM");
	recountitem("PhoenixM");
	recountitem("Pigment");
	recountitem("PlantPack");
	recountitem("PlasmaTurretPack");
	recountitem("PowerGeneratorPack");
	recountitem("prismPack");
	recountitem("ProbeDroidPack");
	recountitem("ProwlerVehicle");
	recountitem("SmartPack");
	recountitem("SpawnPack");
	recountitem("SwitchPack");
	recountitem("PulseSensorPack");
	recountitem("RocketPack");
	recountitem("ReconPack");
	recountitem("SatchelPack");
	recountitem("ScoutVehicle");
	recountitem("SeedPack");
	recountitem("Sentry");
	recountitem("ShieldBeaconPack");
	recountitem("ShockFloorPack");
	recountitem("ShockPack");
	recountitem("SpyPod");
	recountitem("SuicidePack");
	recountitem("TargetPack");
	recountitem("TeleportPack");
	recountitem("TeleBeacons");
	recountitem("TargetPack1");
	recountitem("TargetPack2");
	recountitem("TargetPack3");
	recountitem("TargetPack4");
	recountitem("TargetPack5");
	recountitem("TrapPack1");
	recountitem("TrapPack2");
	recountitem("TrapPack3");
	recountitem("TrapPack4");
	recountitem("TrapPack5");
	recountitem("TreePack");
	recountitem("TurretPack");
	//Additions
	recountitem("JailPack");
	recountitem("JailCapPack");
	recountitem("RailTurretPack");
	recountitem("FlameTurretPack");
	recountitem("ConPack");
	recountitem("ChaingunTurretPack");
	recountitem("FlakPack");
	recountitem("VulcanTurretPack");
	recountitem("DetBug");
	recountitem("AGravPack");
	recountitem("HGravTurretPack");
	recountitem("ElectricWeb");
	recountitem("ElectricFloor");
	recountitem("Elevator");
	recountitem("SkyEyePack");
	recountitem("ZepplinPack");
	recountitem("LockOutPack");

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
	{
		$TeamEnergy[%i] = $DefaultTeamEnergy;
		$OBones[%i] = 0;
		$CBall[%i] = "";  //human cannonball
		%i.scramb = False;  //team chat encryptor off
		%i.anten = False;  //team antenna off
		%i.newspawn = "";  //for new spawn marker
		%i.smrtpck = "";  //for Base Vigil Security
		%i.nukgen = "";  //for Nuclear Generator
		$TeamItemCountAOE[%i] = 0;  //For Guided Missiles
		$elim[%i] = "";  // Eliminator maps
		$TeamTitan[%i] = "";  // Titan Maps
	}
	$Server::timeLimit = 40;
	$Wasteland::FairCheck = "30";
	$Wasteland::FairEvens = "80";
	$EngDude = "";
	$ClanSet = "";
	$Banish = "";
	$Bone = "";
	$laps = "";
	$noBuilding = "";
	$TDM = "";
	$Lava = "";
}

function telebeacon(%clientId)
{
	%armor = Player::getArmor(%clientId);

	if (%armor == "aarmor" || %armor == "afemale" || %armor = "rarmor")
	{
		%team = Client::getTeam(%clientId);
		%obj = newObject("","Mine","Telebeacon");
	 	addToSet("MissionCleanup", %obj);
	 	%obj.deployer = %clientId;
	 	%clientId.telebeacon = %obj;
		GameBase::throw(%obj,%clientId,15 * %clientId.throwStrength,false);
		%clientId.throwTime = getSimTime() + 0.5;
		GameBase::setTeam (%obj,%team);
		$TeamItemCount[%team @ "TeleBeacons"]++;
	}
}

//================================== Scout Stim

function ScoutStim(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);

	if ($stimTime[%clientId] > 0)
	{
		systemMessage(%clientId,0,"Already Stimmed!");
		$StimTime[%clientId]=0;
	}
	else
	{
		if (%armor == "sarmor")
		{
			Player::setArmor(%player,stimarmor);
		}
		else if (%armor == "sfemale")
		{
			Player::setArmor(%player,stimfemale);
		}
		Player::decItemCount(%player, %item);
		systemMessage(%clientId,0,"You used a Stim Pack!");
		$stimTime[%clientId] = 10;
		CheckStim(%clientId, %player);
	}
}

function OverDoseStim(%clientId, %player)
{
		if  (Player::isDead(%player))
			return;

		systemMessage(%clientId,0,"You took a little too much.");
		messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
		$StimTime[%clientId]=0;
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
}

function CheckStim(%clientId, %player)
{
	if  (Player::isDead(%player))
		return;

	if($StimTime[%clientId] > 0)
	{
		Player::trigger(%client,$BackpackSlot,false);

		$StimTime[%clientId] -= 2;

		%drrate = GameBase::getDamageLevel(%player) - 0.035; //==== Damage Rate When Stimmed
		%clientId.damagelevel = %drrate;
		GameBase::setDamageLevel(%player,%drrate);

		%clientId.ovd = %clientId.ovd + floor(getRandom() * 10);
	        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Increased By " @ %clientId.ovd @ "%.", 2);
		%rnd = floor(getRandom() * 100);

		if (%rnd > (150 - %clientId.ovd))
		{
			%clientId.ovd = 0;
			OverDoseStim(%clientId, %player);
			Player::setDamageFlash(%player,0.95);
			return;
		}


		if  (!Player::isDead(%player))
		{
			Player::setDamageFlash(%player,0.35);
			GameBase::setDamageLevel(%player, %drrate);

			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$StimTime[%clientId] = 0;
				return;
			}

		}
		else
		{
			$StimTime[%clientId] = 0;
		}
		schedule("CheckStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
   	}
	else
	{
		systemMessage(%clientId,0,"Stim Effect Wears Off.");
		%armor = Player::getArmor(%player);

		if (%armor == "stimarmor")
		{
			Player::setArmor(%player,sarmor);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		}
		else if (%armor == "stimfemale")
		{
			Player::setArmor(%player,sfemale);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		}
	}
}

//===================== Start Shielding

function Renegades_startShield(%clientId, %player)
{
	systemMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

	if (%armor == "jarmor")
		%player.shieldStrength = 0.016;
	else
		%player.shieldStrength = 0.006;

	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 20;
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($shieldTime[%clientId] > 0)
	{
		$shieldTime[%clientId] -= 2;

		if  ((!Player::isDead(%player)) && (%armor == "harmor" || %armor == "jarmor"))
		{
			if  (Player::isDead(%player))
			{
			}
		}
		else
		{
			$shieldTime[%clientId] = 0;
		}


		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		systemMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}

//====================================== Start Cloaking

function Renegades_startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);

	if($cloakTime[%clientId] == 0)
	{
		$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
		systemMessage(%clientId,0,"Cloaking On");
	}
	else
	{
		$cloakTime[%clientId] = 20;
		if  (%armor == "aarmor" || %armor == "afemale")
		{
			Client::setOwnedObject(%clientId, -1);
			Player::unMountItem(%player,$WeaponSlot);
			systemMessage(%clientId,0,"Special Stealth Cloak On");
			GameBase::playSound(%player,SoundBeaconUse,0);
		}
		else systemMessage(%clientId,0,"Cloaking...");
	}
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($cloakTime[%clientId] > 0)
	{
		$cloakTime[%clientId] -= 2;

		if  ((!Player::isDead(%player)) &&  (%armor == "aarmor" || %armor == "afemale" || %armor == "rarmor" ) ) {}
		else
		{
			$cloakTime[%clientId] = 0;
		}
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		%check = client::getownedobject(%clientId);
		if  (%check != %player)
		{
			if (Player::isDead(%player))
			{
				if (GameBase::getControlClient(%player) == %clientId)
				{
					Client::setOwnedObject(%clientId, %player);
					Player::onKilled(%player);
				}
			}
			else
			{
				Client::setOwnedObject(%clientId, %player);
			}
			systemMessage(%clientId,0,"Stealth Cloak Off");
		}
		else systemMessage(%clientId,0,"Cloaking Off");
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}

//============================= Engineer Beacon
function EngBeacon(%clientId, %player, %bec)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
		%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
		deleteObject(%set);
		if(!%num)
		{
			%team = GameBase::getTeam(%player);
			%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"Target Beacon");
			Beacon::onEnabled(%beacon);
			systemMessage(%client,0,"Beacon deployed");
			playSound(SoundPickupBackpack,$los::position);
			return true;
		}
		else
			systemMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
	{
		systemMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//=========================== Engineer Camera

function EngCamera(%clientId, %player, %bec)
{
	%item = "CameraPack";
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					systemMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($debug) echo("MSG: ",%client," deployed a Camera");
					Player::decItemCount(%player,%bec);
					GameBase::startFadeOut(%camera);
						return true;
				}
			}
			else
			{
				systemMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			systemMessage(%client,0,"Deploy position out of range");
		}
return false;
}


function getflagtoplayer(%playerId, %dist)
{
	%playerteam = GameBase::getTeam(%playerId);
	%playerpos = GameBase::getPosition(%playerId);
	%homepos = ($teamFlag[%playerteam]).originalPosition;

	%flagdist = Vector::getDistance(%playerpos,%homepos);  	//== Player To Flag Distance
	if (%flagdist < %dist)
	{
		return %flagdist;
		if ($debug) echo ("Player " @ %player @ " Is With In " @ %dist @ " Of Thier Own Flag . Dist = " @ %flagdist);
	}

}

function itemFuncs::AmmoBoom(%playerId)
{
	%clientId = player::getclient(%playerId);
	%chance = 0;
	%max = getNumItems();
	%armor = Player::getArmor(%playerId);
	%maxcount = 0;
	%k = 0;
	%boom = "BOOM";

	if (%armor == "larmor") 	  {%kval = 200;}
	else if (%armor == "lfemale")	  {%kval = 200;}
	else if (%armor == "marmor")	  {%kval = 500;}
	else if (%armor == "mfemale")	  {%kval = 500;}
	else if (%armor == "earmor") 	  {%kval = 700;}
	else if (%armor == "efemale")	  {%kval = 700;}
	else if (%armor == "spyarmor")    {%kval = 200;}
	else if (%armor == "spyfemale")   {%kval = 200;}
	else if (%armor == "sarmor")	  {%kval = 200;}
	else if (%armor == "sfemale")	  {%kval = 200;}
	else if (%armor == "stimarmor")	  {%kval = 200;}
	else if (%armor == "stimfemale")  {%kval = 200;}
	else if (%armor == "barmor") 	  {%kval = 800;}
	else if (%armor == "bfemale")	  {%kval = 800;}
	else if (%armor == "harmor")	  {%kval = 900;}
	else if (%armor == "aarmor")	  {%kval = 200;}
	else if (%armor == "afemale")	  {%kval = 200;}
	else if (%armor == "jarmor")	  {%kval = 1000;}
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%count = Player::getItemCount(%playerId,%i);
		%itemname = getItemData(%i);
		%rnd = (floor (getRandom() * 300)+1);

		if (%itemname == "Grenade") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;}}
		else if (%itemname == "mineammo") {%mod = (5*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
		else if (%itemname == "RocketAmmo") {%mod = (4*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "FlierRocket " @ %i;%k++;}}
		else if (%itemname == "BulletAmmo") {%mod = (0.1*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "ChaingunBullet " @ %i;%k++;}}
		else if (%itemname == "GrenadeAmmo") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
		else if (%itemname == "MortarAmmo") { %mod = (12*%count); %chance = %chance + %mod; if (%rnd - %mod < 0) { %boom[%k] = "MortarShell " @ %i; %k++; } }
		else if (%itemname == "MfglAmmo") {%mod = (75*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "FgcShell " @ %i;%k++;}}
		else if (%itemname == "AutoRocketAmmo") {%mod = (10*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "FlierRocket " @ %i;%k++;}}
	}

	%rnd = (floor (getRandom() * %kval));
	%dif = (%rnd - %chance);
	%pos = (gamebase::getposition(%playerId));

	if (%dif < 0 && getflagtoplayer(%playerId) > 150)
	{
		for (%k = 0; %boom[%k] != ""; %k++)
		{
			%blammo = %boom[%k];

			%cnt = getWord(%blammo, 1);

			if (getItemData(%cnt) == "MfglAmmo")
				%cnt = Player::getItemCount(%playerId,%cnt) + 1;
			else
				%cnt = floor(Player::getItemCount(%playerId,%cnt) / 3);

			%cnt = (floor(getRandom() * %cnt));


			%blammo = getword(%blammo, 0);
			for (%j=0; %j < %cnt; %j++)
			{
				%dir = (getRandom() @ " " @ getRandom() @ " " @ "-0.65");
				Projectile::spawnProjectile(%blammo,(%dir @ " " @ %dir @ " -0.1 -0.7 -0.1 " @ %pos),%playerId,"0 0 0");
			}
		}
	}
}

function Mine::Detonate(%this)
{
	%client = %this.deployer;
	%player = client::getownedobject(%client);

	Client::setOwnedObject(%client, %this);
	Client::setOwnedObject(%client, %player);

	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}


function StealBase (%this,%range,%client)
{
	%numGen=0;
	%team = Client::getTeam(%client);
	%set = newObject("set",SimSet);
	%pos = GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team!=%tgtTeam)	
			{	if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
				{	%nset=getGroup(%tgt);
					if(GameBase::getDamageState(%tgt) == "Enabled")
					{
						TeamMessages(1, %team, "Enemy network found, inserting switch control...~wrmt_turret.wav", -2, "null", "Oh No!!!! " @ Client::getName(%client) @ " did it! We have a control switch for our base now! That's not good!~wfemale1.wdefobj.wav");
						TeamMessages(1, %team, "", -2, "null", Client::getName(%client) @ "Inserted a capturable switch into your base's Item Control Network near a power source!~waccess_denied.wav");
						schedule("systemMessage(" @ %client @ ",1,\"Switch Control Established!~wfemale1.wcheer2.wav\");",3);
						if(%nset)
						{
							GameBase::setTeam(%this,%tgtTeam);
							Gamebase::setMapName(%this,getTeamName(%tgtTeam) @ " Base Switch");
							addToSet(%nset,%this);
							%this.powerset=%nset;
							%this.oteam = %tgtteam;
							%i=%tnum;
						}
						%numGen++;
					}
					else if(%nset) %this.powerset=%nset;
				}
			}
		}
	}
	deleteObject(%set);
	if (%numGen==0)
	{
		schedule("systemMessage(" @ %client @ ",1,\"Unable to find nearby enemy power source!~wfemale1.wcolor7.wav\");",3);	
		schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 5);
               $TeamItemCount[Client::getTeam(%client) @ "SwitchPack"]--;
		return (false);
	}
	return (true);
}

function LockBase (%this,%range,%client)
{
	%numGen=0;
	%team = Client::getTeam(%client);
	%set = newObject("set",SimSet);
	%pos = GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam)	
			{	if(%name == "BaseSwitch" || %name == "TowerSwitch")
				{
					schedule("systemMessage(" @ %client @ ",1,\"Friendly switch found, locking network...~wrmt_turret.wav\");",0);
					schedule("systemMessage(" @ %client @ ",1,\"Switch Network Security System Enabled!~wfemale1.wbsclr2.wav\");",3);
					%tgt.lockout = True;
					%numGen++;
				}
			}
		}
	}
	deleteObject(%set);
	if (%numGen==0)
	{
		schedule("systemMessage(" @ %client @ ",1,\"Unable to find nearby friendly Switch!~wfemale1.wcolor7.wav\");",3);	
		schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 5);
            $TeamItemCount[Client::getTeam(%client) @ "LockOutPack"]--;
		return (false);
	}
	return (true);
}
function UnLockBase (%this,%range)
{
	%numGen=0;
	%team = GameBase::getTeam(%this);
	%set = newObject("set",SimSet);
	%pos = GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam)	
			{	if(%name == "BaseSwitch" || %name == "TowerSwitch")
				{
					%tgt.lockout = False;
					%numGen++;
				}
			}
		}
	}
	deleteObject(%set);
	if (%numGen==0)
	{
		return (false);
	}
	return (true);
}

//======================== Check Sabotagable Returns False if NOT in the list.
function checkSabable(%name, %shape)
{

	//echo ("SHAPE " @ %shape);
	if(%shape == "inventory_sta" ||
	%shape == "ammounit" ||
	%shape == "invent_remote" ||
	%shape == "cmdpnl" ||
	%shape == "vehi_pur_pnl")

	{
		return 0;
	}
	else
		return 1;
}

function sabingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	// PORT (2026-10-12): names are no longer carried through the schedule() string (a deployable's
	// map name can hold its owner's player name).
	%pName = Client::getName(%client);
	%name = GameBase::getMapName(%target);
	if(%name == "") %name = (GameBase::getDataName(%target)).description;
	%shape = (GameBase::getDataName(%target)).shapeFile;

	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{
			schedule("sabingItem('" @ %target @ "','" @ %pTeam @ "','" @ %client @ "','" @ %tName @ "','" @ %target @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true")
	{
		if (%target.infected == "true")
		{
			schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
			systemMessage(%client,1,"This station is Fire-Walled, and it cost you!!!");
			%player = Client::getOwnedObject(%client);
			GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
			return;
		}
		else
		{
			TeamMessages(1, %pTeam, %pName @ " sabotaged the " @ %tName @ "'s " @ %name @ "!");
			%target.tc = %client;
			schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);	
		}
	}
}

function SmartBase::check(%this)
{
	%team = gamebase::getteam(%this);
	if (%team.smrtpck)
	{
		%Set = newObject("laptopset",SimSet);
		%Pos = GameBase::getPosition(%this);
		%Mask = $SimPlayerObjectType|$StaticObjectType|$MineObjectType;
		containerBoxFillSet(%Set, %Mask, %Pos, 150, 150, 75,0);
		%num = Group::objectCount(%Set);
		if (%num > 0 )
		{
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			%opos = GameBase::getPosition(%obj);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			%type = getObjectType(%obj);
			%data = GameBase::getDataName(%obj);
			if (gamebase::getteam(%obj) != %team && gamebase::getteam(%obj) != "-1") %enob = "True";
			else %enob = "False";
			if ( %data == "JammerBeacon" && %enob ) teamwaypointer(%this.tc, %team, "Missile Defense at WayPoint", %posX, %posY);
			else if (%type == "Mine" && gamebase::getteam(%obj) != %team ) teamwaypointer(%this.tc, %team, "" @ %type @ " at WayPoint", %posX, %posY);
			else if ( %data == "EMPBeacon" && %enob ) teamwaypointer(%this.tc, %team, "EMP Beacon at WayPoint", %posX, %posY);
			else if ( %type == "Turret" && %enob && GameBase::getDamageState(%obj) == "Enabled" && %data != "RepairPost" ) teamwaypointer(%this.tc, %team, "" @ %data @ " at WayPoint", %posX, %posY);
			else if ( %data == "TeleJammer" ) teamwaypointer(%this.tc, %team, "TeleBeacon at WayPoint", %posX, %posY);
			else if ( %data == "DeployableTeleport" && %enob ) teamwaypointer(%this.tc, %team, "Teleport at WayPoint", %posX, %posY);
			else if ( %data == "CargoBarrel" && %enob && GameBase::getDamageState(%obj) == "Enabled" ) teamwaypointer(%this.tc, %team, "Nuke Container at WayPoint", %posX, %posY);
			else if ( %data == "DeployableSensorJammer" && %enob ) teamwaypointer(%this.tc, %team, "Jammer at WayPoint", %posX, %posY);
			else if ( %data == "DeployablePulseSensor" && %enob ) teamwaypointer(%this.tc, %team, "Sensor at WayPoint", %posX, %posY);
			else if ( %data == "BaseKill" && %enob ) teamwaypointer(%this.tc, %team, "Invasion at WayPoint", %posX, %posY);
			}
		}
		deleteObject(%set);
		schedule ("SmartBase::check(" @ %this @ ");",60);
	}
	else
		return;
}

function teamwaypointer(%this, %team, %message, %posX, %posY)
{
	%msg = "Vigil: " @ %message;
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%id = getClientByIndex(%i);
		if(Client::getTeam(%id) == %team && %id.novigil != true)
		{
			issueCommand(%this, %id, 0,%msg, %posX, %posY);
			systemMessage(%id,0,"~wshell_hilite.wav");
		}
	}
}

function LapTopImage::check(%player)
{
	%weapon = Player::getMountedItem(%player,$BackpackSlot);
	%armor = Player::getArmor(%player);
	if ( %weapon != Laptop || (%armor != sarmor && %armor != sfemale) ) return;
	%client = Player::getClient(%player);
	if (%client.Laptop == "True")
	{
		%Set = newObject("laptopset",SimSet);
		%Pos = GameBase::getPosition(%player);
		%Mask = $StaticObjectType;
		containerBoxFillSet(%Set, %Mask, %Pos, 900, 900, 200,0);
		%num = Group::objectCount(%Set);
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			%opos = gamebase::getposition(%obj);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			%type = getObjectType(%obj);
			%data = GameBase::getDataName(%obj);
			%distance = Vector::getDistance(%Pos, %opos);
			if (gamebase::getteam(%obj) != gamebase::getteam(%player) && gamebase::getteam(%obj) != "-1") %enob = "True";
			else %enob = "False";
			if ( %data == "DeployableTeleport" && %enob )
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint", %posX, %posY);
			}
			else if ( %data == "PortGenerator" && %enob && GameBase::getDamageState(%obj) == "Enabled" )
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint", %posX, %posY);
			}
			else if ( %data == "DeployableSensorJammer" && %enob)
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint", %posX, %posY);
			}
			else if ( %data == "DeployablePulseSensor" && %enob )
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint", %posX, %posY);
			}
			else if ( %data == "SatSensor" && %enob )
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: Sat Dish at WayPoint", %posX, %posY);
			}
			else if ( %data == "HTwoPanel" && %enob )
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: Encryptor at WayPoint", %posX, %posY);
			}
			else if ( (%data == "ArrayAntenna" || %data = "LargeAntenna" || %data = "MediumAntenna" || %data = "RodAntenna" || %data = "SmallAntenna") && %enob )
			{
				systemMessage(%client,0,"~wbuysellsound.wav");
				issueCommand(%client, %client, 0,"Recon: Antenna at WayPoint", %posX, %posY);
			}
		}
		deleteObject(%set);
		schedule ("LapTopImage::check(" @ %player @ ");",40);
	}
	if (%client.Laptop == "False")
	{
		%Set = newObject("laptopset",SimSet);
		%Pos = GameBase::getPosition(%player);
		%Mask = $SimPlayerObjectType|$StaticObjectType|$MineObjectType;
		containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 100,0);
		%num = Group::objectCount(%Set);
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			%opos = GameBase::getPosition(%obj);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			%type = getObjectType(%obj);
			%data = GameBase::getDataName(%obj);
			%distance = Vector::getDistance(%Pos, %opos);
			if (gamebase::getteam(%obj) != gamebase::getteam(%player) && gamebase::getteam(%obj) != "-1") %enob = "True";
			else %enob = "False";
			if ( %type == "Player" && %enob )
			{
				if (%data == rarmor)
				{
					%obar = "Runner";
				}
				else if (%data == larmor || %data == lfemale)
				{
					%obar = "Assassin";
				}
				else if (%data == aarmor || %data == afemale)
				{
					%obar = "Stealth";
				}
				else if (%data == barmor || %data == bfemale)
				{
					%obar = "Goliath";
				}
				else if (%data == earmor || %data == efemale)
				{
					%obar = "Engineer";
				}
				else if (%data == marmor || %data == mfemale)
				{
					%obar = "Patriot";
				}
				else if (%data == sarmor || %data == sfemale)
				{
					%obar = "Recon";
				}
				else if (%data == spyarmor || %data == spyfemale)
				{
					%obar = "Spy";
				}
				else if (%data == jarmor || %data == harmor)
				{
					%obar = "Heavy";
				}
				else %obar = "Soldier";
				%damagedClient = Player::getClient(%obj);
				%dude = Client::getName(%damagedClient);
				bottomprint(%client, "<jc><f2>" @ %obar @ " " @ %dude @ " " @ floor(%distance) @ " meters away.", 3);
				systemMessage(%client,0,"~wbuysellsound.wav");
				%numPlayers = getNumClients();
				for(%j = 0; %j < %numPlayers; %j = %j + 1)
					if (getClientByIndex(%j) == %damagedClient) %targIdx = %j+1;
				issueTargCommand(%client, %client, 1, "Recon: " @ %dude @ " at WayPoint.", %targIdx);
			}
			else if ( %data == "ArbitorBeacon" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: Area Stealth at WayPoint.", %posX, %posY);
			}
			else if ( %data == "JammerBeacon" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: Missle Defense at WayPoint.", %posX, %posY);
			}
			else if ( %data == "SatSensor" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: Sat Dish at WayPoint.", %posX, %posY);
			}
			else if ( %data == "HTwoPanel" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: Encryptor at WayPoint.", %posX, %posY);
			}
			else if (%type == "Mine" && gamebase::getteam(%obj) != gamebase::getteam(%player) )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: Mine at WayPoint.", %posX, %posY);
			}
			else if ( %type == "Turret" && %enob && GameBase::getDamageState(%obj) == "Enabled" )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint.", %posX, %posY);
			}
			else if ( %data == "TeleJammer" )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: TeleBeacon at WayPoint.", %posX, %posY);
			}
			else if ( %data == "DeployableTeleport" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint.", %posX, %posY);
			}
			else if ( %data == "PortGenerator" && %enob && GameBase::getDamageState(%obj) == "Enabled" )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint.", %posX, %posY);
			}
			else if ( %data == "DeployableSensorJammer" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint.", %posX, %posY);
			}
			else if ( %data == "DeployablePulseSensor" && %enob )
			{
				systemMessage(%client,0,"~wshell_hilite.wav");
				issueCommand(%client, %client, 0,"Recon: " @ %data @ " at WayPoint.", %posX, %posY);
			}
		}
		deleteObject(%set);
		schedule ("LapTopImage::check(" @ %player @ ");",5);
	}
	else
		return;
}

function CargoBarrel::check(%this)
{
	%team = GameBase::getTeam(%this);
	if (%team.nukgen == "true")
	{
		if ($TeamItemCount[%team @ "MfglAmmo"] > $Wasteland::NukeLimit)
		{
			TeamMessages(3, %team, "New nuclear warhead available.~wfemale2.wready.wav");
			$TeamItemCount[%team @ "MfglAmmo"]--;
			if ($TeamItemCount[%team @ "MfglAmmo"] < $Wasteland::NukeLimit) $TeamItemCount[%team @ "MfglAmmo"] = $Wasteland::NukeLimit;
		}
		schedule ("CargoBarrel::check(" @ %this @ ");",$Wasteland::DetPackLimit);
	}
	else {}
}

function PowerPrisms(%this,%range,%client,%type)
{
	systemMessage(%client,1,"searching...");
	%numGen=0;
	%team = Client::getTeam(%client);
	%set = newObject("set",SimSet);
	%pos = GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType,%pos,%range,%range,%range,0);
	if (%tnum>0)
	{
		for (%i=0;%i<%tnum;%i++)
		{
			%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam)	
			{
				if(%name.className == Generator)
				{
					if(GameBase::getDamageState(%tgt) == "Enabled")
					{
						if (%type)
						{
							schedule("systemMessage(" @ %client @ ",1,\"Pyramid power source found within range!~wfemale1.wcheer2.wav\");",3);
							schedule("systemMessage(" @ %client @ ",1,\"Prism deployed and powered.\");",3);
						}
						%i=%tnum;
						%numGen++;
					}
				}
			}
		}
	}
	deleteObject(%set);
	if (%numGen==0 && %type)
	{
		schedule("systemMessage(" @ %client @ ",1,\"Unable to find Pyramid's power source within range!~wfemale1.wcolor7.wav\");",3);	
		schedule("Grenade::Plastic_Detonate( " @ %this @ " );", 5);
		return (false);
	}
	return (true);
}

function eliminate(%client)
{
  if ($Game::missionType == "ELIM")
  {
	%client.elim = "true";
	for(%i = 0; %i < getNumTeams() ; %i++)
	{
		$TCounter[%i] = 0;
		$Telim[%i] = 0;
		$elim[%i] = "true";
	}
	%elimIn = 0;
	%numPlayers = getNumClients();
	for(%j = 0; %j < %numPlayers; %j = %j + 1)
	{
		%id = getClientByIndex(%j);
		%i = Client::getTeam(%id);
		$TCounter[%i]++;
		if (%id.elim == "true")
		{
			$Telim[%i]++;
		}
		else $elim[%i] = "";
	}
	for(%i = 0; %i < getNumTeams() ; %i++)
	{
		if ($elim[%i] != "true")
		{
			if ($TCounter[%i]>0) %elimIn++;
		}
		else if ($TCounter[%i] == $Telim[%i] && %i == Client::getTeam(%client) && !%client.race)
		{
			teamMessages(1, %i, "Your team is out of this round!~wwbiok.wav", -1, "The " @ getTeamName(%i) @ " Team is out of this round.~wwbiok.wav", "The " @ getTeamName(%i) @ " Team is out of this round.~wwbiok.wav");
		}
	}
	if (%elimIn >1)
	{
		%f=0;
		for(%i = 0; %i < getNumTeams() ; %i++)
		{
			if ($elim[%i] == "")
			{
				for(%j = 0; %j < %numPlayers; %j = %j + 1)
				{
					%id = getClientByIndex(%j);
					if (%id.elim != "true" && %i == Client::getTeam(%id))
					{
						%f = %i;
						if (%f>2)%f=0;
						%left = %left @ "<f"@%f@"> " @ Client::getName(%id);
					}
				}
			}
		}
		schedule("bottomprintall(\"<jc>"@%left@"\");",5);
		return;
	}
	else if ($ScreamerDelay == "elim") return;
	else
	{
		$ScreamerDelay = "elim";
		for(%i = 0; %i < getNumTeams() ; %i++)
		{
			if ($elim[%i] == "")
			{
				$teamScore[%i]++;
				teamMessages(3, %i, "Your team won this round!~wfemale2.wcheer3.wav", -1, "The " @ getTeamName(%i) @ " team won this round.", "Your team lost this round to the " @ getTeamName(%i) @ " team.~wmale5.wdeath.wav");
				teamMessages(1, %i, "~wwbioj.wav", -1, "~wwturretfad.wav", "~wPoopScream.wav");
			}
		}
		for(%j = 0; %j < %numPlayers; %j = %j + 1)
		{
			%id = getClientByIndex(%j);
			schedule("centerprint(" @ %id @ ",\"<jc><f2>Prepare for another round of Elimination.\");",5);
			if (%id.elim != "true" && Client::getTeam(%id) != -1)
			{
				%id.score = %id.score + 25;
				centerprint(%id, "<jc>Survivor Bonus 25 points = " @ %id.score @ " points.");
				Game::refreshClientScore(%id);
			}
			schedule("reeliminate( " @ %id @ " );", 10);
		}
	}
  }
}

function reeliminate(%client)
{
	$ScreamerDelay = "";
	%client.elim = "";
	%client.race = "";
	%client.laps = "";
	%client.leg = "";
	if (Client::getTeam(%client) != -1 &&  %client.dead == 1) Game::playerSpawn(%client, "true");
}

function butter(%player, %shooterClient)
{
	%client = Player::getClient(%player);
	systemMessage(%client,1,"You've got butter fingers.");
	Player::dropItem(%client,Flag);
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	systemMessage(%client,1,"numweap"@%numweapon);
	%max = getNumItems();
	systemMessage(%client,1,"max"@%max);
	%num=0;
	for (%i = 0; %i < %max; %i = %i + 1)
	{ 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item);
		if(%count)
		{
			%num++;
			schedule("Player::dropItem(" @ %client @ ", " @ %item @ ");",%num,%player);
		}
	}
	Player::setDamageFlash(%client,0.5);
}

function lasso(%player, %shooterClient)
{
	%client = Player::getClient(%player);
	%pos = Vector::add(GameBase::getPosition(%player), "0 0 3");
	%rot = Vector::add(Gamebase::getRotation(%player), "3.14 0 0");
	%inv = newObject("Lasso","Turret","DeployableSatchel",true);
	addToSet("MissionCleanup", %inv);
	GameBase::setTeam(%inv,Client::getTeam(%shooterClient));
	GameBase::setRotation(%inv,%rot);
	GameBase::setPosition(%inv,%pos);
	Player::setMountObject(%player, %inv, 1);
	Player::setDamageFlash(%client,0.5);
	systemMessage(%client,1,"You've been caught in a lasso.");
	Player::dropItem(%client,Flag);
	%max = getNumItems();
	%num=0;
	for (%i = 0; %i < %max; %i = %i + 1)
	{ 
		%item = getItemData(%i);
		%count = Player::getItemCount(%client,%item);
		if(%count)
		{
			%num++;
			if (!%alt)
			{
				%alt = true;
				schedule("Player::dropItem(" @ %client @ ", " @ %item @ ");",%num,%player);
			}
			else %alt = "";
		}
	}
}

function indoormap()
{
	schedule("disableholes();", 10);
}

function disableholes()
{
	Messageall(1, "indoormap(); //outside access disabled");
	//===disable these packs for all 8 teams
	for(%i=0; %i < 8 ; %i++)
	{
		$TeamItemCount[%i@"airbase"]++;
		$TeamItemCount[%i@"Elevator"]++;
		$TeamItemCount[%i@"EnergyRifle"]++;
		$TeamItemCount[%i@"HolePack"]++;
		$TeamItemCount[%i@"jailpack"]=2;
		$TeamItemCount[%i@"MechPack"]=5;
		$TeamItemCount[%i@"TrapPack4"]=3;
		$TeamItemCount[%i@"WarpPack"]++;
	}
}
function freeturrets(%client, %oldteam)
{
	%name = Client::getName(%client);
	%team = Client::getTeam(%client);
	%set = nameToID("MissionCleanup");
	%num = Group::objectCount(%set);
	%numPlayers = getNumClients();
	for(%j = 0; %j < %numPlayers; %j = %j + 1)
	{
		%id = getClientByIndex(%j);
		if (Client::getTeam(%id) == %oldteam)
		{
			%teammate = %id;
		}
	}
	%player = Client::getOwnedObject(%client);
	%teamplayer = Client::getOwnedObject(%teammate);
	for(%i = 0; %i < %num; %i++)
	{
		%obj = Group::getObject(%set, %i);
		%objname = GameBase::getMapName(%obj);
		if(getObjectType(%obj) == "Turret" && String::findSubStr(%objname, %name) >= 0)
		{
			if (%team == GameBase::getTeam(%obj))
			{
				Client::setOwnedObject(%client, %obj);
				Client::setOwnedObject(%client, %player);
				systemMessage(%client,1,"You reclaim your " @ GameBase::getDataName(%obj).description @ ".") ;
			}
			else if (%oldteam == GameBase::getTeam(%obj))
			{
				if (!%teammate)
				{
					schedule("Grenade::Plastic_Detonate( " @ %obj @ " );", 1);
					systemMessage(%client,1,"Your " @ GameBase::getDataName(%obj).description @ " is destroyed.");
				}
				else
				{
					Client::setOwnedObject(%teammate, %obj);
					Client::setOwnedObject(%teammate, %teamplayer);
					systemMessage(%teammate,1,"You inherit " @ %name @"'s " @ GameBase::getDataName(%obj).description @ ".") ;
					systemMessage(%client,1,Client::getName(%teammate) @ " inherits your " @ GameBase::getDataName(%obj).description @ ".") ;
				}
			}
		}
	}
}




function noDeployables()
{
	schedule("$noBuilding=1;", 10);
	schedule("messageall(1,\"noDeployables(); //deployables disabled.\");",10);
}

function teamDM()
{
	schedule("$TDM=1;", 10);
	schedule("messageall(1,\"teamDM(); //kills score for the team.\");",10);
}