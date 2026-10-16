StaticShapeData ShipAntenna
{
	shapeFile = "anten_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	shieldShapeName = "shield";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Small Antenna";
};





function DropShip::deployShape(%player,%name,%item,%length,%width,%height,%offset)
{
	%clientId = Player::getClient(%player);
	%team=GameBase::getTeam(%player);
	
	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item]) 
	{	
		Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,5)) 
	{	
		Client::sendMessage(%clientId,0,"Deploy position out of range");
		return false;
	}
	
	%pos = $los::position;
	if(!checkDeployArea(%clientId,%pos))return;
	
	
	if(getNumTeams()-1 == 2)
	{

		%playerTeam = Client::getTeam(%clientId);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
			
		%NormalisedPOS = getword($los::position,0) @" " @ getword($los::position,1) @" "@ getword($teamFlag[%enemyTeam].originalPosition,2);
		%dist = Vector::getDistance($teamFlag[%enemyTeam].originalPosition, %NormalisedPOS);
		//echo("ship/ flag dist ="@%NormalisedPOS@" flagdist ="@$FlagDistance);			
			
		if(%dist < ($FlagDistance * 0.4) && $FlagDistance != 0)
		{
			Client::sendMessage(%clientId,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{	
		Client::sendMessage(%clientId,0,"Can only deploy on terrain");
		return false;
	}
// check for other deployed ships.
	for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
		{
		%loc2 = getword($los::position,2);
		%posa = $DropShipPos[%i @ "CommandShip"];	//CommandShip,GunShip,SupplyShip
		%posb = $DropShipPos[%i @ "GunShip"];
		%posc = $DropShipPos[%i @ "SupplyShip"];
		
		// deal with extreme terrain grades or altered terrain rotations 
		%Pos1 = getword(%posa,0) @" "@ getword(%posa,1)@" "@%loc2;	
		%Pos2 = getword(%posb,0) @" "@ getword(%posb,1)@" "@%loc2;	
		%Pos3 = getword(%posc,0) @" "@ getword(%posc,1)@" "@%loc2;	
		
		%dist1 = Vector::getDistance(%Pos1,$los::position);
		%dist2 = Vector::getDistance(%Pos2,$los::position);
		%dist3 = Vector::getDistance(%Pos3,$los::position);

	//	echo("shippos ",%posa,%posb,%posc);

		if((%dist1 < 70 && %posa != "") || (%dist2 < 80 && %posb != "" ) || ( %dist3 < 70 && %posc != ""))
		{
			Client::sendMessage(%clientId,0,"You are too close to another ships landing position~waccess_denied.wav");
			return false;
		}
	}
//----------------
	if(!DropShip::CheckDeployArea(%clientId,%pos,%length,%width,%height,%offset))
		return false;

	
	DropShip::CreateSimGroup(%name,%team);
	
	%obj = newObject("Sensor1",StaticShape,ShipAntenna,false);
	NukeList(%obj);
	addToSet("MissionCleanup",%obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setPosition(%obj,%pos);
	%rot = "0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14;
	gamebase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@%team);
	$DropShip[%name@%team] = %pos;
	$DropShipBeacon[%name@%team] = %obj;
	%PlayerName = Client::getName(%clientId);
	DropshipTeamMessage(%team, 1, %PlayerName@" has set a "@%name@" Beacon, 20 seconds until De-Orbit Burn");
	$TeamItemCount[%team @ %item]++;
	echo("$TeamItemCount[%team @ %item] "@%team @ %item);
	echo("MSG: ",%clientId," deployed a " @ %name @ " Beacon");
	
	return %obj;
}

// for player rotations only (around z axis)  
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;

	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2); 
	%ray = %vec1;
	
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}


function ShipAntenna::onDestroyed(%this)
{
	echo("destroy drop ship small antennae");
	%this.nuetron = "";
	%team = GameBase::getTeam(%this);
	%name = Gamebase::getMapName(%this);
	$DropShipBeacon[%name] = "";
	schedule("deleteobject(" @ %this @ ");", 2);
}   

function DropshipTeamMessage(%team, %color, %msg)
{
//	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if(%team == %now)
		{
			Client::sendMessage(%cl,%color,%msg);
		}
	}
}

function DropShip::CheckDeployArea(%clientId,%pos,%length,%width,%height,%offset)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $SimInteriorObjectType ,%pos,%length,%width,%height,%offset);
	//%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,%length,%width,%height,%offset);
	if(!%num) 
	{
		deleteObject(%set);
		return true;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %clientId) 
			Client::sendMessage(%clientId,0,"Unable to deploy - You're in the way");
		else 
			Client::sendMessage(%clientId,0,"Unable to deploy - Player in the way");
	}
	else if(%num == 1)
	{
		%obj = Group::getObject(%set,0);
		//%name = GameBase::getMapName(%obj);
		%type = getObjectType(%obj);
		Client::sendMessage(%clientId,0,"Unable to deploy - " @ %type @ " in the landing zone");
	}
	else if(%num > 1)
		Client::sendMessage(%clientId,0,"Unable to deploy - Multiple items in the landing zone");
	else
		Client::sendMessage(%clientId,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return false;
}

function DropShip::CreateSimGroup(%name,%team)
{
	%teleset = nameToID("MissionCleanup/"@%name@%team);
	if(%teleset == -1)
	{	
		%group = newObject(%name@%team,SimGroup);
		addToSet("MissionCleanup",%group);
	}
}
//$DropShipPos[%team @ %shipname @ "ShipPack"] = "";
function DropShip::CreateShip(%name,%shape,%pos,%team)
{
	$DropShipPos[%team @ %name] = %pos;	//CommandShip,GunShip,SupplyShip
	$ship = $ship +1;

	%obj = newObject(%name,InteriorShape,%shape);
	GameBase::startFadeIn(%obj);
	echo("Created Dropship name: "@ %name @ " object#: " @ %obj);
	addToSet("MissionCleanup/"@%name@%team, %obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,%team);
	return(%obj);
}

function DropShip::MoveShip(%this,%steps,%name)
{	
	
	%movement = 0.100000;
	%pos = GameBase::GetPosition(%this);
	%team = GameBase::getTeam(%this);
	%VertPos = getWord(%pos,2);
	
	%pos = Vector::add(%pos,"0 0 -" @ %movement);
	GameBase::SetPosition(%this,%pos);
	%steps--;
	
	if($debug)
		echo("moveship "@$DropShipPos[%team @ %name]);
		
	//$DropShipPos[%team @ %name] = %pos;	//CommandShip,GunShip,SupplyShip

	if(%steps > 0)
		schedule("DropShip::MoveShip(" @ %this @ "," @ %steps @ "," @ %name @ ");", 0.01, %this);
	else if( %VertPos <= getWord($DropShipPos[%team @ %name],2))	//dealing with tribes imprecision here 
		{
		%this.inmotion = "";
		schedule(%name@"::DeployItems(" @ %this @ ");", 3, %this);
		$DropShipPos[%team @ %name] = "";	// were done moving, so we can delete this..
		}
}



function DropShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($debug)
		echo("DropShipGen::onDamage "@%this);
	
	if(GameBase::getDamageState(%this) == "Destroyed")
	 	return;	
	%client = Player::getClient(%object);
	%name = GameBase::getDataName(%this);
	%player = Client::getOwnedObject(%client);
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + (%value/2);	
	GameBase::setDamageLevel(%this,%dValue);
	
	if(GameBase::getDamageState(%this) == "Destroyed") 
	{
		//gen damage
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
	//	calcRadiusDamage(%this, $DebrisDamageType, 5.0, 0.1 , 25, 13, 3, 5.0, 2.5 , 250, 170);			
		GameBase::playSound(%this, SoundFirePlasma, 0);
		
		%DropTeam = GameBase::getTeam(%this);
		%client = Player::getClient(%object);
		%KillerTeam = GameBase::getTeam(%client);
		echo("destroy gunship gen");	
		if(%KillerTeam == %DropTeam)
		{
			bottomprint(%client, "<jc>You have just LOST <f2>2<f0> POINTS for destroying your teams "@ %name.className);	
	
			echo("MSG: ", %client, " Destroyed a team ",  %name.description);
			DropshipTeamMessage(%KillerTeam, 3, "Team member "@Client::getName(%client)@" has destroyed your teams's "@ %name.description);
			%client.score-=2;
			Game::refreshClientScore(%client);		
		}
		else
		{
			if(%this.LastRepairCl !=  %client)
			{	
				bottomprint(%client, "<jc>You have just recieved <f2>2<f0> POINTS for destroying the enemys "@ %name.description);
				%client.score+= 2;
				Game::refreshClientScore(%client);			
			}	
			echo("MSG: ", %client, " Destroyed enemy  ",  %name.description);
			DropshipTeamMessage(%DropTeam, 3, "WARNING "@Client::getName(%client)@" has destroyed your teams's "@ %name.description);
		}
		messageAll(0, "Warp core breach detected in "@ %name.description@". Reaching Critical levels in "@$DropshipExplosionTime@" seconds!!~wCapturedTower.wav");
		WarpcoreCheck(%this,$DropshipExplosionTime);
		
		// kill off damaging player.. maybe..
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
		{
			%Pos = GameBase::getPosition(%player); 
		   	%vel = Item::getVelocity(%player);
			%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
			%obj = Projectile::spawnProjectile("DropShell", %trans, %player, %vel);
			Projectile::spawnProjectile(%obj);
			Item::setVelocity(%obj, %vel);
			//Player::blowUp(%client);
			//playNextAnim(%client);   
			//Player::kill(%client); 
			//messageall(0,Client::getName(%client) @" overdosed on dark matter.");
		}					
	}	
}


//BlowShitUp(%this,%dettime, %radius)
function WarpCoreCheck(%this,%time)
{	
	%time--;
	%name = GameBase::getDataName(%this);
	%shipname = getWord(%name.description,0);	
	if(GameBase::getDamageState(%this) == "Destroyed") 
	{
		if(%time <= 0)
		{
			//messageAll(0, "Warp core going critical!!~wCapturedTower.wav");
			//echo("WarpCoreCheck "@%shipname);
			%team = GameBase::getTeam(%this);			
			BlowShitUp(%this,5, 100.0);		
			$TeamItemCount[ %team @ %shipname @ "ShipPack"]--;
		}
		else
		{
			schedule("WarpCoreCheck("@%this@","@%time@");",1);
		}	
	}	
	else
		messageAll(0, "Warp core breach in "@%shipname@" ship averted ");
		


}




$DropshipExplosionTime = 45;
// function by Scavenger
function BlowShitUp(%this,%dettime, %radius)
{
	%group = GetGroup(%this);	//%group = nameToID("MissionCleanup/GunShip"@%thisteam); same thing
	Messageall(1,"The " @ $Server::teamName[GameBase::getTeam(%this)] @ " " @ GameBase::getDataName(%this).description @ " is going to blow in " @ %dettime @ " seconds!! RUN!!");

	//Final clean up explosion
	%centerPos = getBoxCenter(%this);
	%centerPosX = getWord(%centerPos,0);
	%centerPosY = getWord(%centerPos,1);
	%centerPosZ = getWord(%centerPos,2);
	schedule("ApplyDSRadiusDamage(" @ %this @ "," @ %centerPosX @ "," @ %centerPosY @ "," @ %centerPosZ @ "," @ %radius @");",(%dettime + 0.1));
	schedule("ApplyDSRadiusDamage(" @ %this @ "," @ %centerPosX @ "," @ %centerPosY @ "," @ %centerPosZ @ "," @ %radius @");",(%dettime + 0.2));
	schedule("ApplyDSRadiusDamage(" @ %this @ "," @ %centerPosX @ "," @ %centerPosY @ "," @ %centerPosZ @ "," @ %radius @");",(%dettime + 0.3));
		
	//Fade out, blow up, and delete all dropship objects
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{
		%time = (%dettime - 2.5) + (%i * 0.5);
		if(%obj.group)
		{
			echo("found sub group for "@GameBase::getDataName(%obj));
			for(%j = 0; (%object = Group::getObject(%obj.group, %j)) != -1; %j++)
			{	
					
				%data = GameBase::getDataName(%object);	
				echo("sub group object ="@%data);
				if(%data.maxDamage && %object != %obj) GameBase::setDamageLevel(%object, %data.maxDamage);
				else schedule("deleteObject(" @ %object @ ");", %dettime);	
			}
		}
		
		else{
			%data = GameBase::getDataName(%obj);	
			GameBase::setDamageLevel(%obj, %data.maxDamage);	
		}	
		
		schedule("BombSpread(" @ %obj @ ");",%time,%obj); //Uses Baby Nuke's
		schedule("GameBase::startFadeOut(" @ %obj @ ");", (%dettime - 3.0) );
		schedule("deleteObject(" @ %obj @ ");", %dettime);
		
		//%this.group
		
	}
}



function ApplyDSRadiusDamage(%this, %centerPosX, %centerPosY, %centerPosZ, %radius)
{
	GameBase::applyRadiusDamage($DebrisDamageType,%centerPosX @ " " @ %centerPosY @ " " @ %centerPosZ, %radius, 40.0, 1000.0,%this);
}


