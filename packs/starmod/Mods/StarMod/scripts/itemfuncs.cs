
//======================================== Functions For Beacons and Other Ammos =============================
//
// Holds functions for varrious items in the game, including cloaking and stim, as well as varrious beacons 
// and other stuff. All are special functions specific to a given item.
//
//==================================================================================================== Det.Bug

//====================================== Checkhackable Returns TRUE if NOT in the list.
function checkHackable(%name, %shape)
{
	if(%shape == "generator" ||
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
	%shape == "ammounit" || 
	%shape == "sensor_pulse_med" ||
	%shape == "station_cmdpnl" ||
	%shape == "missileturret" ||
	%shape == "cmdpnl" ||
	%shape == "radar" ||
	%shape == "anten_lava")
	{
		return 0;
	}

	return 1;
}

ItemData DetBug
{	
	description = "Det Bug";
	className = "Ammo";
	shapeFile = "armorPatch";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
  	price = 2;
};

function DetBug::onCollision(%this,%object)
{
	if ($Debug) echo ("Det But Collide");
	%item = Item::getItemData(%this);
	%dropper = %this.dropper;
	
	if ($Debug) echo ("This " @ %this);
	if ($Debug) echo ("Obj. " @ %object);
	if ($Debug) echo ("Drp. " @ %dropper);
	
	if (getObjectType(%object) == "Player" && GameBase::getTeam(%this) != GameBase::getTeam(%object) && GameBase::getTeam(%this) != -1)
	{
		Player::incItemCount(%object,%item,1);
		Item::playPickupSound(%this);				
		DetBug::onUse(%object, %item, %dropper);
		deleteObject(%this);
	}
	else
		return;
}

function DetBug::Detonate(%this)
{
	%obj = newObject("","Mine","EMPBlast");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 1.5";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	deleteObject(%this);
	GameBase::setPosition(%obj, %pos);
	
	
}

function DetBug::onUse(%player,%item, %dropper)
{
	DetBug::CheckDet(%player, %item, %dropper, 10);
}

function DetBug::CheckDet(%player, %item, %dropper, %time)
{
	%clientId = Player::getClient(%player);
	%clientId.lastdropper = %dropper;
	if($debug) echo ("Checking");
	if($debug) echo ("Player  " @ %player);
	if($debug) echo ("Item    " @ %item);
	if($debug) echo ("Dropper " @ %dropper);
	if($debug) echo ("Time    " @ %time);

	if(%time > 0)
	{
		%time -= 2;
	        bottomprint(%clientId, "<jc><f2>You have a DetBug *YOU* will detonate in " @ %time @ " seconds.", 2);
		
		if (Player::getItemCount(%player,"DetBug"))
		{
			if  (!Player::isDead(%player)) 
			{  
				if($debug) echo ("Waiting");
				Player::setDamageFlash(%player,0.35);
				schedule("DetBug::CheckDet(" @ %player @ ", " @ %item @ ", " @ %dropper @ ", " @ %time @ ");",2, %player);
			}
			else
			{
				%time = 0;
				return;
			}
		}
		else
		{
			%time = 0;
			return;
		}
   	}
	else
	{
		%obj = newObject("","Mine","EMPBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%player), %padd);
		GameBase::setPosition(%obj, %pos);	

		%dammulta = (GameBase::getDataName(%player).maxDamage);
		%dammultb = GameBase::getDamageLevel(%player);
		%multiplier = (%dammulta - %dammultib) * 10;
		Player::blowUp(%player);
		GameBase::playSound(%player, SoundFireMortar, 0);
		
		GameBase::applyRadiusDamage($FlashDamageType, getBoxCenter(%player), (gamebase::GetRadius(%player) * 2), %multiplier, 5, %dropper);
		
		Client::sendMessage(%clientId,0,"...BOOM...");
	}	
}

function DetBug::onDrop(%player,%item)
{
	
	%clientId = Player::getClient(%player);
	%lastdropper = %clientId.lastdropper;
	
	if($debug) echo ("ITEM = " @ %item);
	if ($Debug) echo ("Last = " @ %lastdropper);
	if ($Debug) echo ("CL   = " @ %clientId);
	
	%obj = newObject("","Item",%item,1,false);
	schedule("Item::Pop(" @ %obj @ ");", 5.0, %obj);
	addToSet("MissionCleanup", %obj);
	%obj.dropper = %lastdropper;

	GameBase::SetTeam(%obj, -1);
	
	if (Player::isDead(%player)) 
		GameBase::throw(%obj,%player,10,true);
	else
	{
		GameBase::throw(%obj,%player,15,false);
		Item::playPickupSound(%obj);
	}
	Player::decItemCount(%player,%item,1);
	schedule("DetBug::Detonate(" @ %obj @ ");", 4);

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
	
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}			

		
}

//==================================================================================================== Satchel Deploy
	
function DeploySatchel(	%clientId, %player, %bec)
{
	%item = "SatchelPack";
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,3)) 
		{

			%obj = getObjectType($los::object);
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
					%camera = newObject("Camera","Turret",DeployableSatchel,true);
	   	   		    	addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
			
					Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen.");

					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++;
					if($debug) echo("MSG: ",%client," deployed a Satchel Charge.");
					Player::decItemCount(%player,%bec);
					return true;
					
				}
			}
			else 
			{
				Client::sendMessage(%client,0,"Deploy position out of range");		
			}
		}
		else																						  
	 		Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges");
	
		return false;
}

//============================================================================================== Engineer TeleDisruptor
function EngTeleDisruptor(%clientId, %player, %item)
{
	%client = Player::getClient(%player);
	//if (GameBase::getLOSInfo(%player,5))
	//{
		%obj = getObjectType($los::object);
		%set=newObject("set",SimSet);
		
		//%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
		//deleteObject(%set);
		//if(!%num)
		//{
			%team = GameBase::getTeam(%player);
			
			%teleset = nameToID("MissionCleanup/TeleJammer");
			
			if(%teleset == -1)
			{
				newObject("TeleJammer",SimSet);
				addToSet("MissionCleanup","TeleJammer");
				%teleset = nameToID("MissionCleanup/TeleJammer");				
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

			%beacon = newObject("TelePoint Jammer", "StaticShape", "BeaconTwo", true);
			addToSet("MissionCleanup/TeleJammer", %beacon);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,GameBase::GetPosition(%player));
			Gamebase::setMapName(%beacon,"TeleJammer");
			Client::sendMessage(%client,0,"TelePoint Disruptor deployed");
			playSound(SoundPickupBackpack,$los::position);
			return true;
		//}
		//else
		//	Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	//}
	//else
	//{
	//	Client::sendMessage(%client,0,"Deploy position out of range");
	//}
	return false;
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
function CheckTeleJammer(%player)
{
	%teleset = nameToID("MissionCleanup/TeleJammer");
	%pteam = Gamebase::getTeam(%player);

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam = Gamebase::getTeam(%o);
		%ppos = GameBase::getPosition(%player);
		%opos = GameBase::getPosition(%o);

		if ($Debug) echo ("Tele Jammer Number  = ", %o);
		if ($Debug) echo ("Tele Jammer Team    = ", %oteam);
		if ($Debug) echo ("Players Team        = ", %pteam);
		
		%dist = Vector::getDistance(%ppos,%opos);  	//== Player To Jammer Distance		
		
		if (%dist < 125 && %pteam != %oteam)
		{
			if ($Debug) echo ("Jammed");
			bottomprint(%client, "<jc><f2>Lock Failed, You are being JAMMED! 125m From Jammer Required!.", 2);
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
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($debug) echo("MSG: ",%client," deployed a Camera");
					Player::decItemCount(%player,%bec);
					GameBase::startFadeOut(%camera);
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

//==================================================================================================== Plastique Deploy

ItemData Plastique
{
   description = "Plastique";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Plastique::onUse(%player,%item)
{
	if($matchStarted) 
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Nukebomb");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,4 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in " @ %player.Plastic @ " seconds"); 
		}
	}

}

//==================================================================================================== Repair Patch
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
    	heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") 
	{
		if(GameBase::getDamageLevel(%object)) 
		{
			RepairPatch::onUse(%object, %this);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	if ($debug) echo ("Use Patch");

	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);
	
	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	

	if ($poisonTime[%clientId])
	{
		$poisonTime[%clientId] =0;
	        bottomprint(%clientId, "<jc><f2>Poison cured.", 5);	
	}

	if (%armor == "sarmor" || %armor == "sfemale"  || %armor == "stimarmor" || %armor == "stimfemale")
	{		
		if (%clientId.ovd > 15)
		{	
			%overd = %clientId.ovd;
			
			if ($debug) echo ("OD- " @ %clientId.ovd @ "");
			if ($debug) echo ("O1- " @ %overd @ "");
			%repair = (20 + floor(getRandom() * 25));
			%clientId.ovd = %clientId.ovd - %repair;
			if (%clientId.ovd < 0)
			{
				%clientId.ovd = 0;
			        bottomprint(%clientId, "<jc><f2>Over Dose Down to " @ %clientId.ovd @ "%.", 5);	
			}

			if ($debug) echo ("AD- " @ %clientId.ovd @ "");
		        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Decreased from " @ %overd @ " to " @ %clientId.ovd @ "%.", 5);	
	        }	        
		GameBase::repairDamage(%player,0.1);
	}
	
	else if(%armor == "larmor" || %armor == "lfemale")
	{
		GameBase::repairDamage(%player,0.1);
	}
	else if(%armor == "earmor" || %armor == "efemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "spyarmor" || %armor == "spyfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "aarmor" || %armor == "afemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "harmor")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "barmor" || %armor == "bfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "darmor")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else
	{
		GameBase::repairDamage(%player,0.1);
	}
}

function getflagtoplayer(%playerId, %dist)
{
	%playerteam = Client::getTeam(%playerId);
	%playerpos = GameBase::getPosition(%playerId);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	
	%flagdist = Vector::getDistance(%playerpos,%homepos);  	//== Player To Flag Distance		

	echo ("PT " @ %playerteam);
	echo ("PP " @ %playerpos);
	echo ("HP " @ %homepos);
	echo ("FD " @ %flagdist);

	if (%flagdist < %dist)
	{
		return %flagdist;
		if ($debug) echo ("Player " @ %player @ " Is With In " @ %dist @ " Of Thier Own Flag . Dist = " @ %flagdist);
	}

}