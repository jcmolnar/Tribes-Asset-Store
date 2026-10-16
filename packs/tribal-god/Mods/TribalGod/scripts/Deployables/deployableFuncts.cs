//========== Establish Inv Setup ==========//
AddToInv(DeployableSensorJammerPack, 1, 0);
AddToInv(DeployableSolarPanel, 1, 1);
AddToInv(TG::BlastFloorPack, 1, 0);
AddToInv(medaForceFieldPack, 1, 1);
AddToInv(medbForceFieldPack, 1, 1);
AddToInv(medcForceFieldPack, 1, 1);
AddToInv(DeployableAmmoPack, 1, 0);
AddToInv(lgaForceFieldPack, 1, 1);
AddToInv(lgbForceFieldPack, 1, 1);
AddToInv(DeployableInvPack, 1, 0);
AddToInv(MotionSensorPack, 1, 0);
AddToInv(PulseSensorPack, 1, 0);
AddToInv(TGBlastDoorPack, 1, 0);
AddToInv(CloakDroidPack, 1, 1);
AddToInv(Deployablebase, 1, 0);
AddToInv(ProbeDroidPack, 1, 1);
AddToInv(DecoyCarrier, 1, 0);
AddToInv(TeleportPack, 1, 0);
AddToInv(AirBasePack, 1, 0);
AddToInv(JailCapPack, 1, 1);
AddToInv(TG::KillPad, 1, 1);
AddToInv(FreezePack, 1, 1);
AddToInv(BlastWall, 1, 0);
AddToInv(ClonePack, 1, 1);
AddToInv(FlyerPack, 1, 1);
AddToInv(hugewall, 1, 0);
AddToInv(JailPack, 1, 0);
AddToInv(HoloPack, 1, 1);
AddToInv(HolePack, 1, 0);
AddToInv(IBlock, 1, 0);

//=========================================//

//========== ItemMax's ==========//
ItemMax(DeployableSensorJammerPack, 0, 0, 1, 1, 1, 1);
ItemMax(DeployableSolarPanel, 0, 0, 1, 1, 1, 1);
ItemMax(medaForceFieldPack, 0, 0, 1, 1, 1, 1);
ItemMax(medbForceFieldPack, 0, 0, 1, 1, 1, 1);
ItemMax(medcForceFieldPack, 0, 0, 1, 1, 1, 1);
ItemMax(TG::BlastFloorPack, 0, 0, 1, 1, 1, 1);
ItemMax(DeployableAmmoPack, 0, 0, 1, 1, 1, 1);
ItemMax(lgaForceFieldPack, 0, 0, 1, 1, 1, 1);
ItemMax(lgbForceFieldPack, 0, 0, 1, 1, 1, 1);
ItemMax(DeployableInvPack, 0, 0, 1, 1, 1, 1);
ItemMax(MotionSensorPack, 0, 0, 1, 1, 1, 1);
ItemMax(PulseSensorPack, 0, 0, 1, 1, 1, 1);
ItemMax(TGBlastDoorPack, 1, 1, 1, 1, 1, 1);
ItemMax(CloakDroidPack, 1, 1, 0, 0, 0, 1);
ItemMax(Deployablebase, 0, 0, 1, 1, 1, 1);
ItemMax(ProbeDroidPack, 1, 1, 1, 1, 1, 1);
ItemMax(DecoyCarrier, 1, 1, 1, 1, 1, 1);
ItemMax(TeleportPack, 0, 0, 1, 1, 1, 1);
ItemMax(AirBasePack, 0, 0, 1, 1, 1, 1);
ItemMax(JailCapPack, 0, 0, 1, 1, 1, 1);
ItemMax(TG::KillPad, 0, 0, 1, 1, 1, 1);
ItemMax(FreezePack, 0, 0, 1, 1, 1, 1);
ItemMax(BlastWall, 0, 0, 1, 1, 1, 1);
ItemMax(FlyerPack, 0, 0, 1, 1, 1, 1);
ItemMax(ClonePack, 1, 1, 1, 1, 1, 1);
ItemMax(HolePack, 1, 1, 1, 1, 1, 1);
ItemMax(hugewall, 0, 0, 1, 1, 1, 1);
ItemMax(JailPack, 0, 0, 1, 1, 1, 1);
ItemMax(HoloPack, 0, 0, 1, 1, 1, 1);
ItemMax(IBlock, 0, 0, 1, 1, 1, 1);

//===============================//


//========== Defualt Deploy Function ==========//
function Item::deployShape(%player, %name, %shape, %item)
{
	%client = Player::getClient(%player);
	%o = ($los::object);
	%datab = GameBase::getDataName(%o);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; }
	if(!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %datab != "DeployablePlatform" && %datab != "LargeAirBasePlatform" && %datab != "BlastFloor" && %datab != "BlastWall" && %datab != "LargeEmplacementPlatform")
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }
	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client, 0, "Can only deploy on flat surfaces"); return false; }
	if(!checkDeployArea(%client,$los::position))
	{ return false; }
	%sensor = newObject("", "Sensor", %shape, true);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor, GameBase::getTeam(%player));
	GameBase::setPosition(%sensor, $los::position);
	Gamebase::setMapName(%sensor, %name);
	Client::sendMessage(%client, 0, %item.description @" deployed");
	playSound(SoundPickupBackpack, $los::position);
	Echo("MSG: "@ Client::getName(%client) @"("@ %client @") deployed a "@ %name);
	return true;
}
//=============================================//

function checkDeployArea(%client,%pos)
{
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType | $ItemObjectType | $SimPlayerObjectType, %pos, 1, 1, 1, 1);
	if(!%num)
	{ deleteObject(%set); return 1; }
	
	else if(%num == 1 && getObjectType(Group::getObject(%set, 0)) == "Player")
	{ 
		%obj = Group::getObject(%set, 0);	
		if(Player::getClient(%obj) == %client)	
		{ Client::sendMessage(%client,0,"Unable to deploy - You're in the way"); }
		else
		{ Client::sendMessage(%client,0,"Unable to deploy - Player in the way"); }
	}
	
	else
	{ Client::sendMessage(%client,0,"Unable to deploy - Item in the way"); }
	deleteObject(%set);
	return 0;
}

//========== Taken From BioWasteLand Mod And Modified To Fit [TG] ==========//
$TotalNumonTurrets = 0;
function deployable(%player, %item, %type, %name, %angle, %freq, %prox, %fairplay, %noinside, %area, %surface, %range, %limit, %flag, %kill, %deploy, %count)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);
	
	if(%client.jailed == 1)
	{ Client::sendMessage(%client, 0, "Your Not Allowed To Deploy ANYTHING In Jail."); return false; }

	if($TeamItemCount[GameBase::getTeam(%player) @ %count] < $TeamItemMax[%count])
	{
		if (GameBase::getLOSInfo(%player,%range))
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);
			%pos = $los::position;

			if(%surface)
			{
				if(%obj == "SimTerrain" || %obj == "InteriorShape")
				{}
				else if (%datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "LargeEmplacementPlatform")
				{}
				else
				{ Client::sendMessage(%client,1,"Can only deploy on terrain or buildings..."); return; }
			}

			if (%prox)
			{
				%set = newObject("proxset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,%pos,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num){}
				else
				{ Client::sendMessage(%client,1,"Frequency Overload - Too close to other " @ %deploy @ "s."); return; }

				%set = newObject("minimumset",SimSet);
				%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, %pos, 2.5,2.5,2.5, 0);
				%num = CountObjects(%set,"",%num);
				deleteObject(%set);
				if(!%num)
				{}
				else
				{ Client::sendMessage(%client,1,"Frequency Overload - Too close to other remote turrets"); return; }
			}
			
			// Recoding done here to fix major fairplay problems.. Dustin B.
			if (%fairplay)
			{
				%Set = newObject("fairplayset", SimSet);
				%Mask = $SimPlayerObjectType | $StaticObjectType | $VehicleObjectType | $ItemObjectType | $MineObjectType | $SimInteriorObjectType;
				%Pos = $los::position;
				containerBoxFillSet(%Set, %Mask, %Pos, 300, 300, 300, 0);
				%num = Group::objectCount(%Set);
				
				for(%i = 0; %i < %num; %i++)
				{
					%obj = Group::getObject(%Set, %i);
					%datab = GameBase::getDataName(%obj);
					
					if(%datab == "InventoryStation" || %datab == "AmmoStation" || %datab.classname == "Turret" || (%datab.classname == "Generator" && %datab != "EmplacementGenerator"))
					{
						if((GameBase::getTeam(%obj) != GameBase::getTeam(%client) && GameBase::getTeam(%obj) != -1) || ($OrigTeam[%obj] != GameBase::getTeam(%client) && $OrigTeam[%obj] != -1 && $OrigTeam[%obj] != ""))
						{ %enemydata = true; }
						
						if(GameBase::getTeam(%obj) == GameBase::getTeam(%client))
						{ %friendlydata = true; }
					}
				}
				deleteobject(%Set);
				
				if(%enemydata == true && !%client.isGodAdmin)// && (%friendlydata != true || %datab.classname == "Turret"))
				{ Client::sendMessage(%client, 0, "There Are Enemy Items To Close To Your Position!~waccess_denied.wav"); return false; }
			}
			
			if (%noinside)
			{
				%padd = "0 0 10"; 
				%poss = Vector::add(%pos, %padd);
				for (%b=1; %b < 15; %b++)
				{
					%padd = "0 0 "@ %b;
					%poss = Vector::add(%pos, %padd);
					if(!GameBase::testPosition(%player, %poss))
					{ %nope = 1; }
				}
				if (%nope == 1)
				{ Client::sendMessage(%client, 0, "You can not deploy "@ %name @", space to enclosed."); return; }


			}
			if (%freq)
			{
				%set = newObject("freqset",SimSet);%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, $los::position, $TurretBoxMaxLength/2,$TurretBoxMaxWidth/2,$TurretBoxMaxHeight/2, 0);
				%num = CountObjects(%set,"",%num);
				deleteObject(%set);
				if(%num > 0)
				{ Client::sendMessage(%client, 1, "Other objects in the way."); return; }
			}

			if (%angle == "True")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);

					if (Vector::dot($los::normal,"0 0 1") > 0.6)
					{ %rot = "0 0 "@ %zRot; }
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
						{ %rot = "3.14159 0 " @ %zRot; }
						else
						{ %rot = Vector::getRotation($los::normal); }
					}
				}
				else
				{ Client::sendMessage(%client,1,"Can only deploy on flat surfaces"); return 0; }
			}
			else if (%angle == "Player")
			{ %rot = GameBase::getRotation(%player); }
			else if(%angle == "Flat")
			{ %rot = "-1.54564 0.02591 -3.09105"; }
			else if (!%angle || %angle == "False"){
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{ %rot = "0 0 "@ %zRot; }
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{ %rot = "3.14159 0 "@ %zRot; }
					else
					{ %rot = Vector::getRotation($los::normal); }
				}
			}

			if (%area)
			{ if(!checkDeployArea(%client, $los::position)){ return 0; } }

			%turret = newObject(%name,%type, %deploy,true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Client::sendMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;
			
			// fixed so nuketurret will kill the deployer if he changes teams.
			if(%name != "Nuclear Turret")
			{
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);
			}

			Gamebase::setMapName(%turret, %name @" # "@ $TotalNumonTurrets++ @" "@ Client::getName(%client)); 
            %client.score += $TG::FlagDefencePoints;
            if($TG::FlagDefencePoints == 1)
            { %Pluralize = ""; }else{ %Pluralize = "s"; }
            BottomPrint(%client, "<jl><Bskull_big.bmp><jr><Bskull_big.bmp><jc><f0>You Recieve <f2>"@ $TG::FlagDefencePoints @" <f0>Point"@ %Pluralize @" For Defending Your Flag With A \n<f1>"@ %name @"\n<jc><f0>DeathCount: <f2>"@ %client.scoreKills @"   <f0>Kill Count: <f2>"@ %client.scoreKills @"\n<f0>Current Score: <f2>"@ %client.score @"  <f0>Kill\Death Ratio: "@ %client.ratio @"", 7);
            Game::refreshClientScore(%client);
			return %turret;
		}
		else
		{ Client::sendMessage(%client,1,"Deploy position out of range"); }
	}
	else
	{ Client::sendMessage(%client,1,"Deployable Item limit reached for "@ %item.description @ "'s."); }
	return false;
}
//==========================================================================//


function CountObjects(%set, %name, %num) 
{
	%count = 0;
	for(%i = 0; %i < %num; %i++)
	{ %obj = Group::getObject(%set, %i); if(GameBase::getDataName(Group::getObject(%set, %i)) == %name){ %count++; } }
	return %count;
}

//========== New FairPlay Funct For Items NOT Using function deployable ==========//
function TG::CheckFairPlay(%player, %item, %set, %num)
{
	%client = Player::getClient(%player);
	%name = %item.description;
	
	for(%i = 0; %i < %num; %i++)
	{
		%item = Group::getObject(%set, %i);
		if(GameBase::getTeam(%item) == GameBase::getTeam(%player))
		{ %friendlyData = true; }
		else if(GameBase::getTeam(%item) != GameBase::getTeam(%player))
		{ %enemyData = true; }
	}
	deleteObject(%set);
	
	if(%enemyData == true && %friendlyData != true)
	{
		Client::sendMessage(%client, 0, "Fair Play Distance Exceeded.");
		BottomPrint(%client, "<jc><f1>Fair Play Distance Exceeded.", 5);
		return 0;
	}
	else if(%enemyData == true && %friendlyData == true)
	{
		Client::sendMessage(%client, 0, "To close to enemy items.~wAccess_Denied.Wav");
		BottomPrint(%client, "<jc><f1>To close to enemy items.", 5);
		return 0;
	}
	else if(%enemyData != true && %friendlyData != true)
	{
		Client::sendMessage(%client, 0, "Maximum Deployable Distance Exceded.~wAccess_Denied.Wav");
		BottomPrint(%client, "<jc><f1>Maximum Deployable Distance Exceded.", 5);
		return 0;
	}
	else{ return 1; }
}
//================================================================================//

function CheckForObjects(%pos, %l, %w, %h){
	%Set = newObject("set",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
	
	if(%l && %w && %h){
		containerBoxFillSet(%Set, %Mask, %Pos, %l, %w, %h,0);
	}else{
		containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);	
	}
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++){
		%obj = Group::getObject(%Set, %i);
		if(%obj != "-1"){
			if (getObjectType(%obj) == "Player")
			{
			}else{
				deleteObject(%set);
				return False;
			}
		}
	}
	deleteObject(%set);
	return True;
}
function CheckProximityByClass(%position, %client, %class){
	if(%class == "Free")
		return 1;

	if(%class == "Obelisk"){
		%length = $AntiMatterTurretBoxMaxLength;
		%width = $AntiMatterTurretBoxMaxWidth;
		%height = $AntiMatterTurretBoxMaxHeight;
		%maxnum = $MaxNumAntiMatterTurretsInBox;
	}else{
		%length = $TurretBoxMaxLength;
		%width = $TurretBoxMaxWidth;
		%height = $TurretBoxMaxHeight;
		%maxnum = $MaxNumTurretsInBox;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%position,%length,%width,%height,0);
	%count = 0;
	for(%i =1; %i <= $TurretClass[%class,0]; %i++){
	//	echo("Looking for " @ $TurretClass[%class,%i].description @ "s.");
		%count += CountObjects(%set,$TurretClass[%class,%i],%num);
	//	echo("Count is " @ %count);
	}
	deleteObject(%set);

	if(%count >= %maxnum){
		Client::sendMessage(%client,1,"Interference from other " @ %class @ " turrets in the area");
		return 0;
	}

	if(%class == "Obelisk"){
		%length = $AntiMatterTurretBoxMinLength;
		%width = $AntiMatterTurretBoxMinWidth;
		%height = $AntiMatterTurretBoxMinHeight;
	}else{
		%length = $TurretBoxMinLength;
		%width = $TurretBoxMinWidth;
		%height = $TurretBoxMinHeight;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%position,%length,%width,%height,0);
	%count = 0;
	for(%i =1; %i <= $TurretClass[%class,0]; %i++){
		%count += CountObjects(%set,$TurretClass[%class,%i],%num);
	}
	deleteObject(%set);
	if(%count > 0){
		Client::sendMessage(%client,1,"Frequency Overload - Too close to other " @ %class @ " turrets");
		return 0;
	}				
	echo("Passed proximity check.");
}
function CheckIfInBase(%position,%client){
	%Set = newObject("set",SimSet); 
	%Mask = $StaticObjectType; 
	%num = containerBoxFillSet(%Set, %Mask, %position, 70, 70, 50,0);
	for(%i; %i < %num; %i++){
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%client)){
			%inbase = true;
			break;
		}
	}
	deleteObject(%Set);
	if(%inbase)
		return 1;
	else{
		Client::sendMessage(%client,0,"Can only be deployed within your base.");
		return 0;
	}
}
function CheckIfPowerSource(%position,%client){
	%Set = newObject("set",SimSet); 
	%Mask = $StaticObjectType; 
	%num =containerBoxFillSet(%Set, %Mask, %position, 70, 70, 50,0);
	for(%i; %i < %num; %i++){
		%gen = Group::getObject(%Set, %i);
		if(%gen.obeliskpower && %gen.obelisk == ""){
			%powered = %gen;
			break;
		}
	}
	deleteObject(%Set);
	if(%powered){
		return %powered;
	}else{
		Client::sendMessage(%client, 0, "Must be within range of an unused Obelisk Power Source");
		return 0;
	}
}