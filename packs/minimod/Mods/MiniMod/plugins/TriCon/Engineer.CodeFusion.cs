///-----------------------------------------------
/// Engineer
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "Engineer.CodeFusion.cs", "Engineer Plugin");

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
        %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		
		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		
		Client::sendMessage(%client,0,"Repairing " @ %name);
		
		$PlayerRepairing[%player] = "True";												//=== Player Is Repairing
		$PlayerRepairTar[%player] = (GameBase::getDamageLevel(%player.repairTarget));   //=== Amount Of Damage Starting

		echo ("***  Repair Progress Started " @ $PlayerRepairing[%player] @ " Starting Damage Level = " @ $PlayerRepairTar[%player]);
	}
	
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);

	$PlayerRepairing[%player] = "False";
	echo ("***  Repair Progress Stopped " @ $PlayerRepairing[%player]);
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
        if (%rate < 0)
      		%rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	%client = Player::getClient(%player);

//  echo ("*** Checking Repair Progress On Player " @ $PlayerRepairing[%player]);

	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
	{
		%object = %player.repairTarget;
		
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0)
			{
				echo ("Repair Stopped - Done");
				$PlayerRepairing[%player] = "False";
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				if ($PlayerRepairing[%player] = True)
				{
						%objname = (GameBase::getDataName(%object)).description;
					
					%objectTeam = GameBase::getTeam(%object);								//=== Team Object.
					%playerTeam = GameBase::getTeam(%player); 								//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);	

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Point Defense Laser Mine")	%pntval = $Score::ObjTurretS;
					else if (%objname == "EMP Turret")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Satchel Charge")				%pntval = $Score::ObjTurretS;
					else if (%objname == "ELF Turret")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Camera")						%pntval = $Score::ObjTurretS;
					else if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Sensor Jammer")		%pntval = $Score::ObjSensorS;		
					else if (%objname == "Generator")					%pntval = $Score::ObjGeneratorB;
					else if (%objname == "Solar Panel")					%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Portable Generator")			%pntval = $Score::ObjGeneratorS;		
					else if (%objname == "Ammo Supply Unit")	   		%pntval = $Score::ObjStationA;
					else if (%objname == "Station Supply Unit")			%pntval = $Score::ObjStationS;
					else if (%objname == "Command Station")				%pntval = $Score::ObjStationA;
					else if (%objname == "Remote Ammo Unit")			%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Inv Unit")				%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Command Station")		%pntval = $Score::ObjStationR;
					else if (%objname == "Station Vehicle Unit")		%pntval = $Score::ObjFlier;
					else if (%objname == "Vehicle Pad")					%pntval = $Score::ObjFlier;					

					%bonus = (floor($PlayerRepairTar[%player] * %pntval));
					%score = ($Score::RepairObject + %bonus);
					%lastdamage = $lastdamageobj[%object];
					%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
					%objname = GameBase::getMapName(%object);
					if(%objname == "") 
						%objname = (GameBase::getDataName(%object)).description;					

					if (%lastdpl == %client)
					{
							if ((%objectteam == %playerteam || %objectteam == "-1") && (%object.lastDamageTeam == %playerTeam))
							{
								if ($ScoreOn) bottomprint(%client, "No points awarded, you were the last damager.");						
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{
								%client.score = (%client.score + %score);
								if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
						}
						else
						{
							%client.score = (%client.score + %score);
							if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
						}
					}
						
					$PlayerRepairing[%player] = "False";
					Game::refreshClientScore(%client);

				}
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//------------------------------------------------------------------------------------------------
// Hack Gun Beam Used this from the RSP - Is now alternate weapon setting for EngRepairGun
//------------------------------------------------------------------------------------------------
RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onAcquire(%this, %player, %target)
{
	$Shifter::AllowHacking = "True";
	if($Shifter::AllowHacking)
	{

		%client = Player::getClient(%player);
	
		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player); //added
			%pName = Client::getName(%client); //added
			%tName = getTeamName(%team); //added
			
			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
	
			if(%team == %pTeam)
			{
				Client::sendMessage(%client,0,"You can not hack your own " @ %name);	
				return;
			}
				
			if(checkHackable(%name, %shape) || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player")
				{
					Client::sendMessage(%client,0,"You can not hack another player.");
				}
				else
				{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking = "true";
				if(!$origTeam[%target])
				{
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $RSP::HackTime, %client);
			}
		}	
	}
	else
	{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

function HackBolt::onRelease(%this, %player)
{
	$hacking = false;
}

function checkHackable(%name, %shape)
{
	if(%shape == "generator" || %shape == "generator_p" || %shape == "solar_med" || %shape == "inventory_sta" || %shape == "elevator_4x4"	|| %shape == "elevator_6x6" || %shape == "elevator_6x6_octagon" || %shape == "elevator_8x4" || %shape == "elevator_8x6" || %shape == "elevator_9x9"	|| %shape == "elevator16x16_octo" || %shape == "elevator6X4" || %shape == "elevator_6x5" || %shape == "elevator_8x8" || %shape == "elevator6x4thin"	|| %shape == "elevator6x6thin" || %shape == "elevator_5x5" || %shape == "elevator_4x5" || %shape == "door_top" || %shape == "door_bot"	|| %shape == "newdoor1_l" || %shape == "newdoor1_r" || %shape == "newdoor2_l" || %shape == "newdoor2_r" || %shape == "newdoor3_l"
	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"	|| %shape == "door_8x8_l" || %shape == "door_8x8_r" || %shape == "forcefield" || %shape == "forcefield_3x4" || %shape == "forcefield_4x17"	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"	|| %shape == "forcefield_4x14" || %shape == "forcefield_4x8" || %shape == "forcefield_5x5" || %shape == "door_4x4_diagonal" || %shape == "tower" || %shape == "camera" || %shape == "hellfiregun" || %shape == "indoorgun" || %shape == "ammounit" || %shape == "sensor_pulse_med" || %shape == "station_cmdpnl" || %shape == "missileturret" || %shape == "cmdpnl" || %shape == "radar" || %shape == "anten_lava")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	// PORT: the three names are looked up again here and no longer travel through the schedule() string below.
	// A ' in a player, team or object name ended the quoted argument there and the rest of the name ran as code.
	%pName = Client::getName(%client);
	%tName = getTeamName(%team);
	%name = GameBase::getMapName(%target);
	if(%name == "")
		%name = (GameBase::getDataName(%target)).description;
	%shape = (GameBase::getDataName(%target)).shapeFile;
	if(%time > 0)
	{
		if($hacking)
		{		
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','','','','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		if($hacking)
		{
			if($isInfected[%target]) 
			{
				showDeathAnim(%client);
				Player::Kill(%client);
				messageallexcept(%client,0,%pName @ " thought it would be safe to hack the infected " @ %name @ ".");
			
				%randNum = getRandom() * 100;
			
				if(%randNum >= 50)
				{
					$isInfected[%target] = "false";
					Client::sendMessage(%client,0,"The viral infection was destroyed for the price of your life.");
				}
				else
				{
					Client::sendMessage(%client,0,"Your hacking attempt wasn't able to destroy the virus. What a pitiful waste of life.");
				}
				return 1;
			}
			//Client::sendMessage(%client,0,"Welcome " @ %pName @ " :)");
			else
			{
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
					if($RSP::HackedTime)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $RSP::HackedTime);
					}
					else
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", "120");
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


//------------------------------------------------------------------------------------------------------------------------
// Disasymbler - Alternate To Engineer Repair Gun.
//------------------------------------------------------------------------------------------------------------------------
RepairEffectData DisaBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function DisaBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target != %player)
	{
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		%team = GameBase::getTeam(%target);
		%pTeam = GameBase::getTeam(%player); //added
		%pName = Client::getName(%client); //added
		%tName = getTeamName(%team); //added
		
		if(%name == "")
		{
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

		if(%team != %pTeam)
		{
			Client::sendMessage(%client,0,"You can not disassymble another teams " @ %name);	
			return;
		}
			
		if(getObjectType(%player.repairTarget) == "Player")
		{
			Client::sendMessage(%client,0,"You can not disassymble another player.");
		}
		else
		{
			Client::sendMessage(%client,0,"Disassymbling " @ %name @ ". Please wait...");
			%disatime = 5;
			$disassymble[%player] = True;
			objectColapsable(%target, %player, %name, %shape, %disatime);
			echo ("Done.");
		}
	}	
}

function DisaBolt::onRelease(%this, %player)
{
	$disassymble[%player] = false;
}


function removeflagdefpoints(%player)
{
	%client = Player::getClient(%player);
	%client.score = %client.score - $Score::FlagDef;
	if ($ScoreOn) bottomprint(%Client, "Score - " @ $Score::FlagDef @ " = " @ %client.score @ " Total Score, for removing flag defencive." ,3);
	Game::refreshClientScore(%client);
}

function objectColapsable(%this, %player, %name, %shape, %disatime)
{	
	%client = Player::getClient(%player);
	%pos = gamebase::GetPosition (%this);
	%description = %name;
	%playerteam = Client::getTeam(%client);				//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%pos,%homepos);

	if (Player::getmounteditem(%player, $BackPackSlot) != "-1")
	{
		bottomprint( %client, "<jl><f1> You can not disassymble the " @ %description @ ", drop your current pack first...", 3);
		return 0;
	}

	if ($disassymble[%player])
	{
		if (%disatime > 0)
		{
			%disatime = %disatime - 1;
			schedule ("objectColapsable ( '" @ %this @ "', '" @ %player @ "', '" @ %name @ "', '" @ %shape @ "', '" @ %disatime @ "'); ",1);
			return 0;
		}
	}
	else
	{
		return 0;
	}
	//================================================================================================= Ion Turret
	if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;
		
			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		if (%flagdist < 35) removeflagdefpoints(%player);
		return 1;
	}

	//================================================================================================= Command Station
	if (String::findSubStr(%name, "Command Station") >= 0)
	{
		%item = "DeployableComPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableComPack"]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		return 1;
	}	
	//================================================================================================= Sensor Jammer
	if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Pulse Sensor
	if (String::findSubStr(%name, "Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Camera 
	if (String::findSubStr(%name, "Camera") >= 0)
	{
		%item = "CameraPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Blast Wall
	if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Rocket Turret
	if (String::findSubStr(%name, "RMT Rocket") >= 0)
	{
		%item = "RocketPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 100) removeflagdefpoints(%player);
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Plasma Turret
	if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 35) removeflagdefpoints(%player);
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Elf Turret
	if (String::findSubStr(%name, "Deployable ELF") >= 0)
	{
		%item = "DeployableElf";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 20) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= EMP Turret
	if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 10) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Remote Mortar
	if (String::findSubStr(%name, "RMT Mortar Turret") >= 0)
	{
		%item = "TargetPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Laser Turret
	if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}


	Client::sendMessage(%client,0,"Disassymbling " @ %name @ " failed...");
	Player::trigger(%client,$WeaponSlot,false);
	$disassymble[%player] = false;
	return 0;
}

$AutoUse[Fixit] = False;
MiniMod::WeaponCycle(Blaster, Fixit, PlasmaGun);
$AutoUse[Hackit] = False;
MiniMod::WeaponCycle(Blaster, Hackit, PlasmaGun);
$AutoUse[Disit] = False;
MiniMod::WeaponCycle(Blaster, Disit, PlasmaGun);

ItemImageData FixitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "RepairBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = FixitImage;
	price         = 350;
	showWeaponBar = true;
};

ItemImageData HackitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "HackBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hackit
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = HackitImage;
	price         = 1000;
	showWeaponBar = true;
};

ItemImageData DisItImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "DisaBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DisIt
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = DisItImage;
	price         = 1000;
	showWeaponBar = true;
};

$ArmorType[Male, EngArmor] = earmor;
$ArmorType[Female, EngArmor] = efemale;

$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;

$MaxWeapons[earmor] = 3;
$MaxWeapons[efemale] = 3;

ItemData EngArmor
{
   heading = "aArmor";
        description = "Engineer";
        className = "Armor";
        price = 250;
};
$DamageScale[earmor, $LandingDamageType] = 1.0;
$DamageScale[earmor, $ImpactDamageType] = 1.0;
$DamageScale[earmor, $CrushDamageType] = 1.0;
$DamageScale[earmor, $BulletDamageType] = 1.0;
$DamageScale[earmor, $PlasmaDamageType] = 1.0;
$DamageScale[earmor, $EnergyDamageType] = 1.0;
$DamageScale[earmor, $ExplosionDamageType] = 1.0;
$DamageScale[earmor, $MissileDamageType] = 1.0;
$DamageScale[earmor, $ShrapnelDamageType] = 1.0;
$DamageScale[earmor, $DebrisDamageType] = 1.0;
$DamageScale[earmor, $LaserDamageType] = 1.0;
$DamageScale[earmor, $MortarDamageType] = 1.0;
$DamageScale[earmor, $BlasterDamageType] = 1.0;
$DamageScale[earmor, $ElectricityDamageType] = 1.0;
$DamageScale[earmor, $MineDamageType] = 1.0;


$DamageScale[efemale, $LandingDamageType] = 1.0;
$DamageScale[efemale, $ImpactDamageType] = 1.0;
$DamageScale[efemale, $CrushDamageType] = 1.0;
$DamageScale[efemale, $BulletDamageType] = 1.0;
$DamageScale[efemale, $EnergyDamageType] = 1.0;
$DamageScale[efemale, $PlasmaDamageType] = 1.0;
$DamageScale[efemale, $ExplosionDamageType] = 1.0;
$DamageScale[efemale, $MissileDamageType] = 1.0;
$DamageScale[efemale, $ShrapnelDamageType] = 1.0;
$DamageScale[efemale, $DebrisDamageType] = 1.0;
$DamageScale[efemale, $LaserDamageType] = 1.0;
$DamageScale[efemale, $MortarDamageType] = 1.0;
$DamageScale[efemale, $BlasterDamageType] = 1.0;
$DamageScale[efemale, $ElectricityDamageType] = 1.0;
$DamageScale[efemale, $MineDamageType] = 1.0;

$ItemMax[earmor, Blaster] = 1;
$ItemMax[earmor, Chaingun] = 1;
$ItemMax[earmor, Disclauncher] = 1;
$ItemMax[earmor, GrenadeLauncher] = 1;
$ItemMax[earmor, Mortar] = 0;
$ItemMax[earmor, PlasmaGun] = 1;
$ItemMax[earmor, LaserRifle] = 1;
$ItemMax[earmor, EnergyRifle] = 1;
$ItemMax[earmor, TargetingLaser] = 1;
$ItemMax[earmor, MineAmmo] = 3;
$ItemMax[earmor, Grenade] = 5;
$ItemMax[earmor, Beacon] = 3;

$ItemMax[earmor, BulletAmmo] = 100;
$ItemMax[earmor, PlasmaAmmo] = 30;
$ItemMax[earmor, DiscAmmo] = 15;
$ItemMax[earmor, GrenadeAmmo] = 10;
$ItemMax[earmor, MortarAmmo] = 10;

$ItemMax[earmor, EnergyPack] = 1;
$ItemMax[earmor, RepairPack] = 1;
$ItemMax[earmor, ShieldPack] = 1;
$ItemMax[earmor, SensorJammerPack] = 1;
$ItemMax[earmor, MotionSensorPack] = 1;
$ItemMax[earmor, PulseSensorPack] = 1;
$ItemMax[earmor, DeployableSensorJammerPack] = 1;
$ItemMax[earmor, CameraPack] = 1;
$ItemMax[earmor, TurretPack] = 0;
$ItemMax[earmor, AmmoPack] = 1;
$ItemMax[earmor, RepairKit] = 1;
$ItemMax[earmor, DeployableInvPack] = 0;
$ItemMax[earmor, DeployableAmmoPack] = 0;

$ItemMax[efemale, Blaster] = 1;
$ItemMax[efemale, Chaingun] = 1;
$ItemMax[efemale, Disclauncher] = 1;
$ItemMax[efemale, GrenadeLauncher] = 1;
$ItemMax[efemale, Mortar] = 0;
$ItemMax[efemale, PlasmaGun] = 1;
$ItemMax[efemale, LaserRifle] = 1;
$ItemMax[efemale, EnergyRifle] = 1;
$ItemMax[efemale, TargetingLaser] = 1;
$ItemMax[efemale, MineAmmo] = 3;
$ItemMax[efemale, Grenade] = 5;
$ItemMax[efemale, Beacon] = 3;

$ItemMax[efemale, BulletAmmo] = 100;
$ItemMax[efemale, PlasmaAmmo] = 30;
$ItemMax[efemale, DiscAmmo] = 15;
$ItemMax[efemale, GrenadeAmmo] = 10;
$ItemMax[efemale, MortarAmmo] = 10;

$ItemMax[efemale, EnergyPack] = 1;
$ItemMax[efemale, RepairPack] = 1;
$ItemMax[efemale, ShieldPack] = 1;
$ItemMax[efemale, SensorJammerPack] = 1;
$ItemMax[efemale, MotionSensorPack] = 1;
$ItemMax[efemale, PulseSensorPack] = 1;
$ItemMax[efemale, DeployableSensorJammerPack] = 1;
$ItemMax[efemale, CameraPack] = 1;
$ItemMax[efemale, TurretPack] = 0;
$ItemMax[efemale, AmmoPack] = 1;
$ItemMax[efemale, RepairKit] = 1;
$ItemMax[efemale, DeployableInvPack] = 0;
$ItemMax[efemale, DeployableAmmoPack] = 0;




PlayerData earmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = true;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

        maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;


        maxEnergy = 90;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;


   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
        animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

        // Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds =
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  };
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


PlayerData efemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

   canCrouch = true;
        maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;

        maxEnergy = 90;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 125;
   jumpSurfaceMinDot = 0.2;

     // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };

   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
        animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

        // Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds =
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  };
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

MiniMod::MonitorFile(stop, "Engineer.CodeFusion.cs", "Engineer Plugin");
