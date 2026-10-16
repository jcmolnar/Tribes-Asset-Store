
//============================ Functions For Beacons and Other Ammos and Items ===============================
//
// Holds functions for varrious items in the game, including cloaking and stim, as well as varrious beacons 
// and other stuff. All are special functions specific to a given item.
//
//==================================================================================================== Det.Bug

//====================================== Checkhackable Returns TRUE if NOT in the list.
function checkHackable(%name, %shape)
{ 
	if(%shape == "generator" ||
	%shape == "Generator" ||
	%shape == "generator_p" ||
	%shape == "solar_med" ||
	%shape == "inventory_sta" ||
	%shape == "elevator_4x4" ||
	%shape == "elevator_6x6" ||
	%shape == "elevator_6x6_octagon" ||
	%shape == "elevator_8x4" ||
	%shape == "elevator_8x6" ||
	%shape == "elevator_9x9" ||
	%shape == "elevator16x16_octo" ||
	%shape == "elevator6X4" ||
	%shape == "elevator_6x5" ||
	%shape == "elevator_8x8" ||
	%shape == "elevator6x4thin" ||
	%shape == "elevator6x6thin" ||
	%shape == "elevator_5x5" ||
	%shape == "elevator_4x5" ||
	%shape == "door_top" ||
	%shape == "door_bot" ||
	%shape == "newdoor1_l" ||
	%shape == "newdoor1_r" ||
	%shape == "newdoor2_l" ||
	%shape == "newdoor2_r" ||
	%shape == "newdoor3_l" ||
	%shape == "newdoor3_r" ||
	%shape == "newdoor4_l" ||
	%shape == "newdoor4_r" ||
	%shape == "newdoor6_l" ||
	%shape == "newdoor6_r" ||
	%shape == "door_8x8_l" ||
	%shape == "door_8x8_r" ||
	%shape == "forcefield" ||
	%shape == "forcefield_3x4" ||
	%shape == "forcefield_4x17" ||
	%shape == "newdoor3_r" ||
	%shape == "newdoor4_l" || 
	%shape == "newdoor4_r" || 
	%shape == "newdoor6_l" ||
	%shape == "newdoor6_r"	||
	%shape == "forcefield_4x14" ||
	%shape == "forcefield_4x8" ||
	%shape == "forcefield_5x5" || 
	%shape == "door_4x4_diagonal" ||
	%shape == "tower" ||
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
	%shape == "anten_lava" ||
	%shape == "cactus1" ||
	%shape == "cactus2" ||
	%shape == "cactus3" ||
	%shape == "plant1" ||
	%shape == "plant2" ||
	%shape == "plasmawall" ||
	%shape == "vehi_pur_poles")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	
	if ($debug) echo  ("Hacking");
	
	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{
			echo ("TARGET   " @ %target);
			echo ("PTEAM    " @ %pTeam);
			echo ("PNAME    " @ %pName);
			echo ("TNAME    " @ %tName);
			echo ("NAME     " @ %name);
			echo ("TEAM     " @ %team);
			echo ("CLIENT   " @ %client);

schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true")
	{
		if ($debug) echo ("PT - " @ %pteam @ "");
		if ($debug) echo ("TT - " @ %team @ "");
		if ($debug) echo ("HK - " @ $hacking[%client] @ "");
		if ($debug) echo ("TG - " @ %target @ "");
		if ($debug) echo ("Tm - " @ %time @ "");

		if($hacking[%client] == "true")
		{
			if(%team == %pTeam)
			{
				if ($debug) echo ("infecting");
				%target.infected = "true";
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);
				Client::sendMessage(%client,1,"Your " @ %name @ " is now protected by viral infection, from hacking.");
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
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						echo ("hackerror");
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						echo ("hackerror");
						return;
					}
				}
				
				if(%name == "False" && %shape == "magcargo")
				{
					%rnd = floor(getRandom() * 10);
					if(%rnd == 1)
					{	
					    Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
						Mine::Detonate(" @ %this @ ");
						return;
					}
					else
					{	
					    Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}
				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					
					if($Shifter::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
					}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
				}	
			}
		}
	}
}

//==================================================================================== Deployables Functions
function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	%n = Group::objectCount(%set);	
	
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}

	%datab = GameBase::getDataName(Group::getObject(%set,0));
	%obj = (getObjectType(Group::getObject(%set,0)));
	
	if ((%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform"  || %datab == "BlastFloor" || %datab == "BlastWall"))
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
	{
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,1,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,1,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,1,"Unable to deploy - Item in the way");
	
	deleteObject(%set);
	return 0;
}

//======================================= Check For Objects In a Deployables way.
function CheckForObjects(%pos, %l, %w, %h)
{
	%Set = newObject("set",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	if (%l && %w && %h)
	{
		containerBoxFillSet(%Set, %Mask, %Pos, %l, %w, %h,0);
	}
	else
	{
		containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);	
	}

	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != "-1")
		{
			if (getObjectType(%obj) == "Player")
			{
			}
			else
			{
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
	for(%i=0;%i<%num;%i++)
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
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

$TurretBoxMinLength = 15;	//Define Min Length from another turret
$TurretBoxMinWidth =  15;	//Define Min Width from another turret
$TurretBoxMinHeight = 15;    	//Define Min Height from another turret

//=============================================================================================== Deployable Functions
// %player  = Player Id doing the deploy
// %item    = Item being deployed
// %type    = Type of item - Turret, StaticShape, Beacon - etc
// %name    = Name of item - Ion Turret
// %angle   = Check angel (to mount on walls, etc.) (True/False/Player) Checks angel - Does Not Check - Uses Players Rotation Reguardless
// %freq    = Check Frequency (True/False) = Too Many Of SAME Type Of Item
// %prox    = Check Proximity (True/False)
// %area    = Check Area (for objects in the way) (True/False)
// %surface = Check Surface Type  (True/False)
// %range   = Max deploy distance from player (number best between 3 and 5) meters from player.
// %limit   = Check limit (True/False)
// %flag    = Give Flag Defence Bonus 0 = None and higher for score ammount.
// %kill    = Count for kills (for turrets)
// %deploy  = The item to be deployed (actualy item data name)
// %count   = What item to count

function deployable(%player,%item,%type,%name,%angle,%freq,%prox,%area,%surface,%range,%limit,%flag, %kill, %deploy, %count)
{
	%client = Player::getClient(%player);
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

			if (%surface)
			{
				if (%obj == "SimTerrain" || %obj == "InteriorShape")
				{
				
				}
				else if (%datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "BlastFloor" || %datab == "BlastWall")
				{

				}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on terrain or buildings...");
					return;
				}
			}

			if (%prox)
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);
	
				if($MaxNumTurretsInBox > %num)
				{
				}
				else
				{
					Client::sendMessage(%client,1,"Frequency Overload - Too close to other remote turrets");
					return;
				}
			}

			if (%freq)
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,($TurretBoxMaxLength/2),($TurretBoxMaxWidth/2),($TurretBoxMaxHeight/2),0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);

				if(%num == 0)
				{
				
				}
				else
				{
					Client::sendMessage(%client,1,"Interference from other remote turrets in the area");
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
					Client::sendMessage(%client,1,"Can only deploy on flat surfaces");
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
			Client::sendMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;
			
			//echo("MSG: ",%client," deployed a " @ %name);

			if (%type == "Turret")
				Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			else
				Gamebase::setMapName(%turret, %name);

			if (%flagdist < %flag && %flag != 0)
			{
				%client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
				Game::refreshClientScore(%client);
			}

			if ($Shifter::TurretKill && %kill)
			{
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);
				%turret.deployer = %client;
			}
			return %turret;
		}
		else 
			Client::sendMessage(%client,1,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "'s.");
	return false;
}

//================================================================================================ Deploy Shape
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
						%sensor = newObject("","Sensor",%shape,true);
 	        	  	 		addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
					if ($Shifter::TurretKill && %kill)
					{
						%turret = newObject(%name,%type, %deploy,true);
						Client::setOwnedObject(%client, %turret);
						Client::setOwnedObject(%client, %player);
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}
//================================================================================================= Check Item Max

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

//============================================================================== Return All Items To Zero After Mission
function recountitem(%itemname)
{
	if ($debug) echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 8 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}
//==============================================================
function Mission::reinitData()
{
	recountitem("DeployableAmmoPack");
	recountitem("DeployableInvPack");
	recountitem("TurretPack");
	recountitem("CameraPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("PulseSensorPack");
	recountitem("MotionSensorPack");
	recountitem("ScoutVehicle");
	recountitem("LAPCVehicle");
	recountitem("HAPCVehicle");
	recountitem("Beacon");
	recountitem("mineammo");
	recountitem("RocketPack");
	recountitem("ForceFieldPack");
	recountitem("LaserPack");
	recountitem("DeployableComPack");
	recountitem("PlasmaTurretPack");
	recountitem("FusionTurretPack");
	recountitem("DeployableTeleport");
	recountitem("WraithVehicle");
	recountitem("JetVehicle");
	recountitem("BlastWallPack");
	recountitem("BlastFloorPack");
	recountitem("ShockPack");
	recountitem("PlatformPack");
	recountitem("TreePack");
	recountitem("LargeForceFieldPack");
	recountitem("TargetPack");
	recountitem("PlantPack");
	recountitem("hologram");
	recountitem("SatchelPack");
	recountitem("LaunchPack");
	recountitem("proxLaserT");
	recountitem("AccelPPack");
	recountitem("AirAmmoPad");
	recountitem("AirBase");
	recountitem("CoolLauncher");
	recountitem("AOE");
	recountitem("EngBeacons");
	recountitem("TeleBeacons");
	recountitem("EmplacementPack");
	recountitem("LargeShockForceFieldPack");
	recountitem("ArbitorBeaconPack");
	recountitem("EMPBeaconPack");
	recountitem("ShieldBeaconPack");
	recountitem("SuicidePack");
	recountitem("MFGLAmmo");
	recountitem("PowerGeneratorPack");
	recountitem("BarragePack");
	recountitem("NukePack");
	recountitem("FragPack");
	recountitem("GHPack");
	recountitem("DeployableGrav");
	recountitem("DeployableElf");
	recountitem("BoomPack");
	recountitem("DeployableInv2Pack");
	recountitem("HyperBPack");
	recountitem("ShockFloorPack");
	recountitem("ShockForceFieldPack");
	for(%i = 0; %i < 8; %i++) //====== For Guided Missiles
	{
		$TeamItemCountAOE[%i] = 0;
	}

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 

	//======================= Kill All Mission Varialbles (Global) That are not needed...
	DeleteVariables($funk::var);
}

function telebeacon(%clientId)
{
	%armor = Player::getArmor(%clientId);
	
	if (%armor == "aarmor" || %armor == "afemale")
	{
		%obj = newObject("","Mine","Telebeacon");
	 	addToSet("MissionCleanup", %obj);
	 	%obj.deployer = %clientId;
	 	%clientId.telebeacon = %obj;
		GameBase::throw(%obj,%clientId,15 * %clientId.throwStrength,false);
		%clientId.throwTime = getSimTime() + 0.5;
		GameBase::setTeam (%obj,GameBase::getTeam (%clientId));
		
		$TeamItemCount[GameBase::getTeam(%clientId) @ "TeleBeacons"]++;
	}
}

//========================================================================================================= Scout Stim

function ScoutStim(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);

	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	
	if ($stimTime[%clientId] > 0)
	{
		Client::sendMessage(%clientId,0,"Already Stimmed!");
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
		Client::sendMessage(%clientId,0,"You used a Stim Pack!");
		$stimTime[%clientId] = 10;
		CheckStim(%clientId, %player);		
	}
}

function OverDoseStim (%clientId, %player)
{
		Client::sendMessage(%clientId,0,"You took a little too much.");
		messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
		$StimTime[%clientId]=0;
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
}

function CheckStim(%clientId, %player)
{

	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	if($debug) echo ("S- " @ %ClientId.ovd @ "");

	if($StimTime[%clientId] > 0)
	{
		Player::trigger(%client,$BackpackSlot,false);

		$StimTime[%clientId] -= 2; 
		
		%drrate = GameBase::getDamageLevel(%player) - 0.035; //==== Damage Rate When Stimmed
		%clientId.damagelevel = %drrate;
		GameBase::setDamageLevel(%player,%drrate);
		
		if ($Debug) echo("DR " @ %drrate @ "");
		if ($Debug) echo("ID " @ %clientId @ "");
		if ($Debug) echo("PL " @ %player @ "");
		
		%clientId.ovd = %clientId.ovd + floor(getRandom() * 10);
	        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Increased By " @ %clientId.ovd @ "%.", 2);
		%rnd = floor(getRandom() * 100);

		if (%rnd > (150 - %clientId.ovd))
		{
			%clientId.ovd = 0;
			OverDoseStim(%clientId, %player);
			Player::setDamageFlash(%player,0.95);  
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
		Client::sendMessage(%clientId,0,"Stim Effect Wears Off.");
		%armor = Player::getArmor(%player);

		if(Player::isDead(%player))
		{
		}
		else
		{
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
}

//===================================================================================================== Start Shielding

function Renegades_startShield(%clientId, %player)
{
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
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

		if  ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale" || %armor == "jarmor"))
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
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);	
	}			

		
}

//=================================================================================================== Start Cloaking

function Renegades_startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"Cloaking On");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
	
	//Player::setDetectParameters(%player , 50,150);

	if($cloakTime[%clientId] == 0)
	{
		$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else
		$cloakTime[%clientId] = 20;
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($cloakTime[%clientId] > 0)
	{
		$cloakTime[%clientId] -= 2;  
		
		if  ((!Player::isDead(%player)) &&  (%armor == "aarmor" || %armor == "afemale"))
		{
		
		}
		else
		{
			$cloakTime[%clientId] = 0;
		}
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		Client::sendMessage(%clientId,0,"Cloaking Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		
		//Player::setDetectParameters(%player , 0.027, 0);

		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}


//============================================================================================ Eng Missile Lock
function EngMissileLock(%clientId, %player, %item)
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
			
			%teleset = nameToID("MissionCleanup/MJammer");
			
			if(%teleset == -1)
			{
				newObject("MJammer",SimSet);
				addToSet("MissionCleanup","MJammer");
				%teleset = nameToID("MissionCleanup/MJammer");				
			}
			
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

			%beacon = newObject("MJammer Jammer", "StaticShape", "BeaconTwo", true);
			addToSet("MissionCleanup/MJammer", %beacon);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"MJammer");
			Client::sendMessage(%client,0,"MJammer Disruptor deployed");
			playSound(SoundPickupBackpack,$los::position);
			return true;
		}
		else
			Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

function CheckMissileJammer(%player)
{
	%teleset = nameToID("MissionCleanup/MJammer");
	%pteam = GameBase::getTeam(%player);

	if ($debug) echo ("checking jammer is set "  @ %teleset);
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam = GameBase::getTeam(%o);
		%ppos = GameBase::getPosition(%player);
		%opos = GameBase::getPosition(%o);

		if ($Debug) echo ("MissileJammer = ", %o);
		if ($debug) echo ("OTeam " @ %oteam);
		if ($debug) echo ("PPos  " @ %ppos);
		if ($debug) echo ("Opos  " @ %opos);
		if ($debug) echo ("PTeam " @ %pteam);
		
		%dist = Vector::getDistance(%ppos,%opos);  	//== Player To Jammer Distance		
		if ($debug) echo ("Distance " @ %dist);
		
		if (%dist < 125 && %pteam != %oteam)
		{
			if ($Debug) echo ("Jammed");
			%data = GameBase::getDataName(%o);
			if (GameBase::setDamageLevel(%o, %data.maxDamage))
				if ($debug) echo ("BOOM");
			return true;
		}
	}
	return false;
}

//==================================================================================================== Engineer Beacon
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
			Client::sendMessage(%client,0,"Beacon deployed");
			playSound(SoundPickupBackpack,$los::position);
			return true;
		}
		else
			Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//==================================================================================================== Engineer Camera

function EngCamera(%clientId, %player, %bec)
{
	%item = "CameraPack";
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,5))  //was 3
		{
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform" || %obj == "BlastFloor")
//			{
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
//				if(checkDeployArea(%client,$los::position))
//				{
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($debug) echo("MSG: ",%client," deployed a Camera");
					Player::decItemCount(%player,%bec);
					GameBase::startFadeOut(%camera);
						return true;
//				}
//			}
//			else 
//			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//			}
		}
		else 
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
return false;
}

function EngMotion(%clientId, %player, %bec)
{
	%item = "MotionSensorPack";
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,5))  //was 3
		{
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform" || %obj == "BlastFloor")
//			{
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
//				if(checkDeployArea(%client,$los::position))
//				{
					%camera = newObject("Motion Sensor","Sensor",DeployableMotionSensor,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Motion Sensor#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($debug) echo("MSG: ",%client," deployed a Motion Sensor");
					Player::decItemCount(%player,%bec);
					GameBase::startFadeOut(%camera);
						return true;
//				}
//			}
//			else 
//			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//			}
		}
		else 
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
return false;
}

//==================================================================================================== Sniper Jammer

function SniperJammer(%clientId, %player, %bec)
{
	%item = "DeployableSensorJammerPack";
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
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
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"SensorJammer");
					Client::sendMessage(%client,0,"SensorJammer deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++;
					if($debug) echo("MSG: ",%client," deployed a Sensor Jammer");
					Player::decItemCount(%player,%bec);
					return true;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//==================================================================================================== Scout Sensor

function ScoutSensor(%clientId, %player, %bec)
{
	%item = "PulseSensorPack";
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
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
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("radar_small","Sensor",DeployablePulseSensor,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Pulse Sensor");
					Client::sendMessage(%client,0,"Pulse Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++;
					if($debug) echo("MSG: ",%client," deployed a Pulse Sensor");
					Player::decItemCount(%player,%bec);
					return true;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

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
	else if (%armor == "sarmor")	  {%kval = 1000;}  //was 200
	else if (%armor == "sfemale")	  {%kval = 1000;}  //was 200
	else if (%armor == "stimarmor")	  {%kval = 1000;}  //was 200
	else if (%armor == "stimfemale")  {%kval = 1000;}  //was 200
	else if (%armor == "barmor") 	  {%kval = 800;}
	else if (%armor == "bfemale")	  {%kval = 800;}
	else if (%armor == "darmor") 	  {%kval = 900;}
	else if (%armor == "harmor")	  {%kval = 1000;}
	else if (%armor == "aarmor")	  {%kval = 200;}
	else if (%armor == "afemale")	  {%kval = 200;}
	else if (%armor == "dmarmor")	  {%kval = 500;}
	else if (%armor == "dmfemale")    {%kval = 500;}
	else if (%armor == "parmor")      {%kval = 0;}
	else if (%armor == "jarmor")	  {%kval = 1000;}
	
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%count = Player::getItemCount(%playerId,%i);
		%itemname = getItemData(%i);
		%rnd = (floor (getRandom() * 300)+1);

		if (%itemname == "Grenade") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;}}		
		else if (%itemname == "mineammo") {%mod = (5*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "MineShell " @ %i;%k++;}}  //was GrenadeShell
		else if (%itemname == "RocketAmmo") {%mod = (4*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "StingerMissile " @ %i;%k++;}}
		else if (%itemname == "BulletAmmo") {%mod = (0.1*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "ChaingunBullet " @ %i;%k++;}}
		else if (%itemname == "VulcanAmmo") {%mod = (0.15*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "VulcanBullet " @ %i;%k++;}}
		else if (%itemname == "GrenadeAmmo") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
		else if (%itemname == "MortarAmmo") { %mod = (12*%count); %chance = %chance + %mod; if (%rnd - %mod < 0) { %boom[%k] = "MortarShell " @ %i; %k++; } }
//		else if (%itemname == "MfglAmmo") {%mod = (75*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "FgcShell " @ %i;%k++;}}  //barred out due to server crash
		else if (%itemname == "AutoRocketAmmo") {%mod = (10*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "StingerMissile " @ %i;%k++;}}
		else if (%itemname == "HammerAmmo") {%mod = (10*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GodHammer " @ %i;%k++;}}
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
