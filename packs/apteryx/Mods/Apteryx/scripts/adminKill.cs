// Part two of admin
//Plasmatic

// a little something for everyone...
// fetchdata is called by players mining in rpg
// someone wrote a script for it, and it spams server text windows crazy like...
// plasmatic
function remotefetchdata(%client, %password)
{
	%name = Client::getName(%client);
	%ip = Client::getTransportAddress(%client);
	%client.fetchdata ++;
	//echo(%client.fetchdata);
	if(%client.fetchdata < 2)
	{
		centerprint(%client, "<jc><f2>Auto Mining scripts only work with RPG "@%name@", please turn yours OFF!", 30);
		Client::sendMessage(%client, 1, "Auto mining only works with RPG mod, "@%name@".");
		//messageAllExcept(%client, 0, %name@" is a confirmed bonehead, kill him.");echo("<2");
	}
	else if(%client.fetchdata > 1)
	{
		bottomprint(%client,"<jc><f2>"@ %name@". Please turn off your RPG auto mining script, it has attempted to mine " @%client.fetchdata@ " times", 30);
		if((%client.fetchdata % 100 )< 1)
		{
			//messageAllExcept(%client, 0, %name@" is a confirmed bonehead, kill him.");
			echo(%name@" is a confirmed bonehead, kill him.");echo("%");
		}
		//Client::sendMessage(%client, 1, "your RPG mining script has tried to mine " @%client.fetchdata@ " times");
	}
}


//==========================================================
// this needs to be tied into repair pack code
// -plasmatic
function fixable(%player,%target)
{
	%client = Player::getClient(%player);
	%tname = GameBase::getMapName(%target);
	%name = (GameBase::getDataName(%player.repairTarget)).description;
	%data = GameBase::getDataName(%player.repairTarget);
	if($NoMapTurrets && (%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret"))
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Turrets have been disabled by admin.");
		return false;
	}
	else if($NoInv && %data == "InventoryStation" )
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Inventories have been disabled by admin.");
		return false;
	}
	else if($NoGenerator &&(%data == "Generator" || %data == "PortGenerator" || %data == "SolarPanel"))
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Generators have been disabled by admin.");
		return false;
	}
	else if($NoVehicle &&(%data == "VehicleStation" || %data == "VehiclePad"))
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Vehicle Stations have been disabled by admin.");
		return false;
	}
	else
		return true;
}
//======================================================================

function AutoRepair(%fixRate)
{
	for(%i = 8200; %i< 9300; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
		if (%data.className == Generator || %data.className == Station) 
		{					
			//echo(%data,%count);		
			%rate = GameBase::getAutoRepairRate(%i) + %fixrate;	
			GameBase::setAutoRepairRate(%i,%rate);
		}
	}	
}

function whoison() 
{ 
	echo(" # cl: CLIENT nm: NAME ip: ADDRESS"); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		%name = Client::getName(%pl); 
		%ip = Client::getTransportAddress(%pl); 
		echo("  " @ %i+1 @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip); 
	} 
}



//log al this crap -Plasmatic
function logAdminAction(%clientId,%message)
	{	
		//echo(%clientId,%message);
		%ip = Client::getTransportAddress(%clientId);
		%name = Client::getName(%clientId);
		if(%clientId != -1)
			$Admin = %name @" "@%ip @" -"@ %message ; 
	 	else
	 	  	$Admin = %message; 
  		export("Admin","config\\Admin.log",true);
  		echo($admin);
	}


//===============================================
// Kill/ fix stuff

// in descending order of ocurance
$PlasmaticNoKill = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Trigger GroupTrigger towerswitch towerSwitch flagstand MapMarker";

function NoPurge(%data)
	{ 
		for(%i = 0; !getWord($PlasmaticNoKill, %i); %i++){ 
 		//echo(getWord($PlasmaticNoKill, %i)); 
		if (%data == getWord($PlasmaticNoKill, %i)) return true; 
		}
	return false;
	}



// in descending order of ocurance, objects in map pre deployed
$PlasmaticNoKillmap = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Generator GroupTrigger InventoryStation IndoorTurret MortarTurret rocketTurret RocketTurret Elfturret PlasmaTurret SolarPanel CommandStation AmmoStation VehicleStation VehiclePad PulseSensor MediumPulseSensor Trigger towerswitch towerSwitch flagstand ObserverCamera MapMarker";

function NoPurgeMap(%data)
	{ 
		for(%i = 0; !getWord($PlasmaticNoKillmap, %i); %i++){ 
 		//echo(getWord($PlasmaticNoKill, %i)); 
		if (%data == getWord($PlasmaticNoKillmap, %i)) return true; 
		}
	return false;
	}




function KillClass(%clientId,%kill,%classname){

		for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
			if (%data.className == %classname) {					
			//echo(%data,%count);
			
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
	if (%kill){				
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL "@%classname@"s. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL "@%classname@"s.", 3);
	}
	else{				
	messageAll(0, Client::getName(%clientId) @ " Fixed ALL "@%classname@"s. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL "@%classname@"s.", 3);		
	}		
		
}

function KillDepGen(%clientId){


		for(%i = 8200; %i< $maxdepObj; %i++)
		{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
			if (%data == "PortableGenerator" ) 					
				GameBase::setDamageLevel(%i, %data.maxDamage);
		}
	
				
	messageAll(0, Client::getName(%clientId) @ " Destroyed all deployable generators. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed all deployable generators.", 3);
	
}

function KillMapInv(%clientId,%base,%kill){

	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
			if (%data == "InventoryStation" ) 
			{					
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
	if (%kill){				
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base Inventories. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Base Inventories.", 3);
	}
	else{				
	messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base Inventories. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base Inventories.", 3);
	}		
	}		
	if(!%base)
	{
		for(%i = 8200; %i< $maxDepObj; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
			if (%data != "") %object = getObjectType(%i);						
			if (%data == "MobileInventory" || %data == "DeployableInvStation") 					
				GameBase::setDamageLevel(%i, %data.maxDamage);	
		}		
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable Inventories.~wCapturedTower.wav");	
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable Inventories.", 3);	
	}		
}

function KillMapTurrets(%clientId,%base,%kill){
	
	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++)
		{
		//1100 objects should be enough for now. -Plasmatic
		//%object = getObjectType(%i);			
			%data = GameBase::getDataName(%i);		
			if (%data != "" && $debug) 
			{
				%count++;
				%object = getObjectType(%i);
				$object = %object@" "@%data@" "@%count@" "@%i; 
				export("object","config\\object.log",true);
			}
				
			if (%data != "") %object = getObjectType(%i);	
			if (%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret") 
			{								
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
	if (%kill){				
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base turrets. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Base turrets.", 3);
	}
	else{				
	messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base turrets. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base turrets.", 3);
	}		
	}		
			
			
	
	if(!%base)
	{
		for(%i = 8200; %i< $maxDepObj; %i++){
		//1100 objects should be enough for now. -Plasmatic
		//%object = getObjectType(%i);			
			%data = GameBase::getDataName(%i);
			
			if (%data != "" && $debug) 
			{
				%count++;
				%object = getObjectType(%i);
				$object = %object@" "@%data@" "@%count@" "@%i; 
				export("object","config\\object.log",true);
			}
				
			if (%data != "") %object = getObjectType(%i);						
			if (%data == "rocketTurret" || %data != "RocketTurret" && %data != "IndoorTurret" &&  %data != "Elfturret" &&  %data != "MortarTurret" && %data != "PlasmaTurret" && %object == "Turret") 					
				GameBase::setDamageLevel(%i, %data.maxDamage);	
		}		
		
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable turrets.~wCapturedTower.wav");	
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable turrets.", 3);	
	}	
}

function KillPurge(%clientId,%kill)
{
	if (%kill)
	{
		KillDeploy(%clientId);						
		messageAll(0, Client::getName(%clientId) @ " set off a NEUTRON BOMB. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " set off a NEUTRON BOMB.", 3);
	}
	else
	{
		fixDeploy(%clientId);				
		messageAll(0, Client::getName(%clientId) @ " Fixed ALL equipment. ~wCapturedTower.wav");
		schedule("Client::sendMessage("@%clientId@", 1,\"{-o-} Plasmatic: Thank's... ;)\");", 2);
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL equipment.", 3);
	}

	if($maxdepObj > 9300) %maxpurge = $maxdepObj;
	else %maxpurge = 9300;

	for(%i = 8200; %i < %maxpurge; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data!="") %object = getObjectType(%i);	
		if(!NoPurge(%data))
		{	
			if (%data.maxDamage < 500 && !NoPurge(%object)) 
			{									
				if ($debug) 
				{
					%count++;
					$object = "OB "@%object@" DA "@%data@" "@%count@" "@%i; 
					//echo($object);
					//export("object","config\\object.log",true);
				}
								
				if(%kill)
				{
					if(%i.nuetron && $build)
					{
						%i.nuetron = "";
						deleteObject(%i);
					}
					else
						GameBase::setDamageLevel(%i, %data.maxDamage + 1);
				}
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	}
}


$maxMapObj = 9300;
$maxDepObj = "";
// we're gonna set up a min and max object id # to check if NEUTRON BOMB is called.
function NukeBaselist(%obj)
{
	if(%obj < 8200) return;		
	if(%obj < $maxMapObj)$maxMapObj = %obj;		
}

function NukeList(%obj)
{
	if(%obj < 8200) return;
	if(%obj > $maxDepObj -10 )$maxDepObj = %obj + 10;		
	%obj.nuetron = true;	
}


function AdminKillDeploy(%clientId)
{
	messageAll(0, Client::getName(%clientId) @ " set off a deployable NEUTRON BOMB. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " set off a deployable NEUTRON BOMB.", 3);		
	KillDeploy(%clientId);
}

function KillDeploy(%clientId)
{
	for(%i = 8200; %i < ($maxDepObj + 1); %i++)
	{	
		if(%i.nuetron)
		{
			%i.nuetron = "";
			if(!$build)
				GameBase::setDamageLevel(%i, GameBase::getDataName(%i).maxDamage + 1);
			else
				deleteObject(%i);			
		}
	}				
} 

function FixDeploy(%clientId)
{
	if($debug) echo($maxMapObj,$maxDepObj);
	
	for(%i = 8200; %i < ($maxDepObj + 1); %i++)
	{	
		if(%i.nuetron)GameBase::setDamageLevel(%i, 0);
	}				
}
function KillMapVehicle(%clientId,%base,%kill){

	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
			if (%data == "VehicleStation" || %data == "VehiclePad") 
			{					
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
	if (%kill){				
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base Vehicle Stations. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Vehicle Stations.", 3);
	}
	else{				
	messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base Vehicle Stations. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base Vehicle Stations.", 3);
	}		
	}		
	if(!%base)
	{
		for(%i = 8200; %i< $maxDepObj; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
			if (%data != "") %object = getObjectType(%i);						
			if (%data == "MobileInventory" || %data == "DeployableInvStation") 					
				GameBase::setDamageLevel(%i, %data.maxDamage);	
		}		
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable Vehicle Stations.~wCapturedTower.wav");	
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable Vehicle Stations.", 3);	
	}		
}

//---------------------------
// player tortures, kills, penaltys, other
function Admin::observe(%clientId, %cl)
{
	
	%clientId.AdminobserverMode = "AdminObserve";
	%clientId.observerTarget = %cl;	
	bottomprint(%clientiD, "<jc>Observing " @ Client::getName(%cl)@", Press Space bar (Jump) to return to game.", 25);
	%player = Client::getOwnedObject(%clientId);
	%player.invulnerable = true;
	%clientId.observerTarget = %cl;
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	//Observer::setOrbitObject(%clientId, %cl, 5, 5, 5);
	Observer::setAnnihilationOrbit(%clientId, %cl);	
	
	if($debug)echo("observer "@%clientId@" observeee "@ %cl);	
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
			messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.~wCapturedTower.wav");
		}
		else
		{ 	
			centerprintall("<jc>"@Client::getName(%clientId) @ " Tried to hack admin... and FAILED!!");
			messageAll(0, Client::getName(%clientId) @ " Tried to hack admin... and FAILED!!~wfemale1.wdsgst4.wav");
			Admin::BlowUp(%clientId);			
			return;			
		}
	}
	Game::menuRequest(%clientId);
}

function ProcessMenuPlayer(%clientId, %option)
{
	if(!%clientid.isadmin) return;
//	Client::sendMessage(%clientId, 0,"process Player " @ %option);		
	%opt = getWord(%option, 0);
	%cl = floor(getWord(%option, 1));
	if(%cl.isSuperAdmin && !%clientId.isSuperAdmin && %cl != %clientId) { Client::sendMessage(%clientId, 0, "A super admin cannot be managed by a public admin."); return; }
	%player = Client::getOwnedObject(%cl);	
	%name = Client::getName(%cl);
//mute   
   	if(%opt == "silence")  		
	Admin::fun(%clientId, %cl,"De-Tongued");	
   	if(%opt == "unsilence")  		
	Admin::fun(%clientId, %cl,"Un-Muted");	
//obsingame   
   	if(%opt == "obsingame")  		
	Admin::observe(%clientId, %cl);	
//   	if(%opt == "unsilence")  		
//	Admin::fun(%clientId, %cl,"Un-Muted");	
	
	
//admin   
//   	if(%opt == "Admin")  		
//	Admin::fun(%clientId, %cl,"Admined");	
   	if(%opt == "stripAdmin" && %clientId.isSuperAdmin)  		
	Admin::fun(%clientId, %cl,"De -admined");	
//kicks   
//   	if(%opt == "kick")  		
//	Admin::fun(%clientId, %cl,"Kicked");	
// 	if(%opt == "ban")  		
//	Admin::fun(%clientId, %cl,"Banned");	
	
	else if(%opt == "Kick" && %clientId.isadmin)
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "Admin")
	{
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "Ban" && %clientId.isadmin && %clientId.issuperadmin)
	{
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}	
	
	
	
// ClearScore	
	else if(%opt == "ClearScore")
	{
		%cl.score = 0;
		Game::refreshClientScore(%cl);	
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Cleared your score.", 5);		
		messageAll(0, Client::getName(%clientId) @ " cleared "@ %name @"'s score.");
		logAdminAction(%clientId," cleared " @ %name @"'s score");		
		return;
	}	
// StripFlag		
	else if(%opt == "StripFlag")
	{	
	%type = Player::getMountedItem(%cl, $FlagSlot);
	if(%type != -1)
		Player::dropItem(%cl, %type);		
		
		
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" stripped your flag.", 5);		
		messageAll(0, Client::getName(%clientId) @ " stripped "@ %name @"'s flag.~wCapturedTower.wav");
		logAdminAction(%clientId," stripped " @ %name @"'s flag.");		
		return;
	}	
	
// ReturnFlag
	else if(%opt == "ReturnFlag")
	{
	
	%player = Client::getOwnedObject(%cl);	
	%this = %player.carryFlag;
	
	%type = Player::getMountedItem(%cl, $FlagSlot);
	if(%type != -1){
		Player::dropItem(%cl, %type);			
	//echo("flag id "@%type);

	// the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
			%this.atHome = true;
		%cl.flagcarried = "";
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" returned your flag.", 5);		
		messageAll(0, Client::getName(%clientId) @ " returned "@ %name @"'s flag.~wCapturedTower.wav");
		logAdminAction(%clientId," returned " @ %name @"'s flag.");		
		return;
	}	
	}
// FlagCurse
	else if(%opt == "FlagCurse")
	{
		%cl.FlagCurse = true;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" gave you the dreaded Flag Curse.", 5);		
		messageAll(0, Client::getName(%clientId) @ " gave "@ %name @" the flag curse.");
		logAdminAction(%clientId," flag cursed " @ %name @".");	
		
		%type = Player::getMountedItem(%cl, $FlagSlot);
		if(%type != -1)	schedule("PlayerFlagCurse("@%cl@");",2);	
			
		return;
	}	
	
	else if(%opt == "NoFlagCurse")
	{
		%cl.FlagCurse = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" removed the flag curse.", 5);		
		messageAll(0, Client::getName(%clientId) @ " removed "@ %name @"'s flag curse.");
		logAdminAction(%clientId," un flag cursed " @ %name @".");	
		return;
	}	

// lock team	
	else if(%opt == "lock")
	{
		%cl.locked = true;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" removed your team changing privileges.", 5);		
		messageAll(0, Client::getName(%clientId) @ " locked "@ %name @"'s team.");
		logAdminAction(%clientId," locked " @ %name @"'s team");		
		return;
	}	
	
	else if(%opt == "unlock")
	{
		%cl.locked = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" restored your team changing privileges.", 5);		
		messageAll(0, Client::getName(%clientId) @ " unlocked "@ %name @"'s team.");
		logAdminAction(%clientId," unlocked " @ %name @"'s team");	
		return;
	}	

//na -plasmatic   
   	else if(%opt == "return")  	
	Game::menuRequest(%clientId);		
//return to flag menu
   	else if(%opt == "Freturn")  	
	PlayerFlag(%clientId, %cl);		
   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      %teamnow = Client::getTeam(%cl);
      %tname = getTeamName(%teamnow);
      if (%tname == unnamed) %tname = "Observer";
      Client::buildMenu(%clientId, Client::getName(%cl)@", "@%tname, "FPickTeam", true);
      if(Client::getTeam(%cl) != -1) 
      		Client::addMenuItem(%clientId, "0Observer", -2);
      if(Game::assignClientTeam(%clientId,true) != %teamnow)
		Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams()-1; %i = %i + 1){
      	if(Client::getTeam(%cl) != %i)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         	}
      return;
   }      
//kill
	else if(%opt == "respawn")
	{	
		playNextAnim(%cl);
		Player::kill(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" respawned you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " respawned "@ %name);
		logAdminAction(%clientId," respawned " @ %name);
		//processMenuPickTeam(%cl, -1, %clientId);		
		Game::playerSpawn(%cl, true);
		return;
	}
	
			
	else if(%opt == "BlowUp")
	{	
	%player = Client::getOwnedObject(%cl);

		Admin::BlowUp(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" blew you up", 5);
		messageAll(0, Client::getName(%clientId) @ " blew up "@ %name@".");
		logAdminAction(%clientId," Blew up " @ %name);
		return;
	}
	else if(%opt == "Sniper")
	{
		GameBase::playSound(%cl, ricochet1, 0);
		%curDie = radnomItems(3, $PlayerAnim::DieHead, $PlayerAnim::DieBack,$PlayerAnim::DieForward);
		Player::setAnimation(%this, %curDie);
		playNextAnim(%cl);
		Player::kill(%cl);
		messageAll(0, Client::getName(%clientId) @ " put a bullet through "@ %name@"'s ear");
		logAdminAction(%clientId," Killed " @ %name@" with a sniper shot");
		//processMenuPickTeam(%cl, -1, %clientId);		
		//Game::playerSpawn(%cl, true);
		return;
	}	
	else if(%opt == "Burn")
	{
		BurnUp(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" set you on fire.", 5);		
		messageAll(0, Client::getName(%clientId) @ " set "@ %name@" on fire.");
		logAdminAction(%clientId," set " @ %name@" on fire.");		
		return;
	}
	else if(%opt == "Poison")
	{
		KillRatDead(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" poisoned you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " fed "@ %name@" some rat poison.");
		logAdminAction(%clientId," Poisoned " @ %name);		
		return;
	}
	
//annoy	
	else if(%opt == "Disarm")
	{
		%player = Client::getOwnedObject(%cl);
		%item = Player::getMountedItem(%cl,$WeaponSlot);
		Player::trigger(%player, $WeaponSlot, false);
		Player::dropItem(%cl,%item);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" disarmed you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " stole "@ %name@"'s weapon.");
		logAdminAction(%clientId," disarmed " @ %name);		
		return;
	}
	else if(%opt == "Strip")
	{
		%player = Client::getOwnedObject(%cl);
		%Player.rThrow = true;
		%player.rThStr = 10;
	for(%x = 0; %x < 15; %x = %x++){		
		%item = Player::getMountedItem(%cl,$WeaponSlot);
		//if(!%item) return;
		Player::trigger(%player, $WeaponSlot, false);
		Player::dropItem(%cl,%item);
		remoteNextWeapon(%cl);
		}
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Stripped your weapons.", 5);		
		messageAll(0, Client::getName(%clientId) @ " had a yard sale with "@ %name@"'s weapons.");
		logAdminAction(%clientId," stripped weapons " @ %name);	
		%Player.rThrow = "";
		%player.rThStr = "";			
		return;
	}	
	else if(%opt == "Moon")
	{
	%rotZ = getWord(GameBase::getRotation(%cl),2); 
	GameBase::setRotation(%cl, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),0,3000); 
	Player::applyImpulse(%cl,%forceDir); 
	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
//	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the moon!", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the moon.");
		logAdminAction(%clientId," Sent to the moon " @ %name);		
		return;
	}	
	
	else if(%opt == "Slap")
	{
	%rotZ = getWord(GameBase::getRotation(%cl),2); 
	GameBase::setRotation(%cl, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),3000,1000); 
	Player::applyImpulse(%cl,%forceDir); 
	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
//	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Slapped you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " slapped "@ %name@".");
		logAdminAction(%clientId," Slapped " @ %name);		
		return;
	}	
	else if(%opt == "Blind")
	{
		%player.blind = true;
		HotPoker(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" poked your eyes out.", 5);		
		messageAll(0, Client::getName(%clientId) @ " scooped "@ %name@"'s eyes out with a spoon.");
		logAdminAction(%clientId," poked " @ %name@" eyes.");		
		return;
	}	

	else if(%opt == "UnBlind")
	{
		%player.blind = false;
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" restored your sight.", 5);		
		messageAll(0, Client::getName(%clientId) @ " restored "@ %name@"'s sight.");
		logAdminAction(%clientId," restored " @ %name@" eyes.");		
		return;
	}	
	else if(%opt == "Freeze")
	{
		freeze(%cl);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" froze you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " froze "@ %name@" into a block of ice.");
		logAdminAction(%clientId," froze " @ %name);		
		return;
	}
	else if(%opt == "Defrost")
	{
		freeze(%cl,true);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" Defrosted you.", 5);		
		messageAll(0, Client::getName(%clientId) @ " Defrosted "@ %name@".");
		logAdminAction(%clientId," Defrost " @ %name);		
		return;
	}
// Penalty	
	else if(%opt == "15Penalty")
	{
		Penalty(%cl,false,15);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the penalty box for 15 seconds.", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the penalty box for 15 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
	else if(%opt == "30Penalty")
	{
		Penalty(%cl,false,30);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the penalty box for 30 seconds.", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the penalty box for 30 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
	else if(%opt == "60Penalty")
	{
		Penalty(%cl,false,60);
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" sent you to the penalty box for 60 seconds.", 5);		
		messageAll(0, Client::getName(%clientId) @ " sent "@ %name@" to the penalty box for 60 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
//mutes
	else if(%opt == "60mute")
	{
		%cl.silenced = true;
		schedule(%cl@".silenced = false;",60);
		schedule("Client::sendMessage("@%cl@", 0,\"You may speak again, use your voice wisely.. \");", 65);
		
		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" muted you for 60 seconds.", 15);		
		messageAll(0, Client::getName(%clientId) @ " muted "@ %name@" for 60 seconds.");
		logAdminAction(%clientId," muted 60 seconds " @ %name);		
		return;
	}
	else if(%opt == "120mute")
	{
		%cl.silenced = true;
		schedule(%cl@".silenced = false;",120);
		schedule("Client::sendMessage("@%cl@", 0,\"You may speak again, use your voice wisely.. \");", 125);

		centerprint(%cl, "<jc><f1>"@Client::getName(%clientId)@" muted you for 120 seconds.", 15);		
		messageAll(0, Client::getName(%clientId) @ " muted "@ %name@" for 120 seconds.");
		logAdminAction(%clientId," muted 120 seconds " @ %name);		
		return;
	}


//   if(!Player::isDead(%sel)){
//        	 Client::addMenuItem(%clientId, %curItem++ @ "Co- Pilot " @ %name , "CoPilot " @ %sel);        
//        	 Client::addMenuItem(%clientId, %curItem++ @ "Possess " @ %name , "Possess " @ %sel);  
//        	 }
}

function Admin::BlowUp(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		%Pos = GameBase::getPosition(%player); 
		%vel = Item::getVelocity(%player);
		%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
		%obj = Projectile::spawnProjectile("suicideShell", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		Item::setVelocity(%obj, %vel);
		player::blood(%player);
		Player::blowUp(%clientId);
		playNextAnim(%clientId);   
		Player::kill(%clientId); 
	}	
}


function BurnUp(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
 	  { 
		%vel = Item::getVelocity(%player);
		%Pos = getBoxCenter(%player);
		  %xpos = getWord(%Pos,0);
		  %ypos = getWord(%Pos,1);
		  %zpos = getWord(%Pos,2)+ 0.1;	
		  %npos = %xpos @" "@ %ypos @" "@ %zpos;	
		%trans =  "0 0 0 0 0 0.1 0 0 0 " @ %npos; 
		%obj = Projectile::spawnProjectile("PlasmaBurn", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		//Item::setVelocity(%obj, %vel);
		schedule("BurnUp("@%clientId@");", 0.2);
  		 }
	  //else messageall(0, Client::getName(%clientId) @ " went to hell.");
}
function KillRatDead(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
 	  {
		//%Pos = GameBase::getPosition(%player); 
		%vel = Item::getVelocity(%player);
		%Pos = getBoxCenter(%player);
		%xpos = getWord(%Pos,0);
		%ypos = getWord(%Pos,1);
		%zpos = getWord(%Pos,2)+0.5;
		%npos = %xpos @" "@ %ypos @" "@ %zpos;
		%trans =  "0 0 1 0 0 0 0 0 1 " @ %npos; 
		%obj = Projectile::spawnProjectile("RatPoison", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		Item::setVelocity(%obj, %vel);
		schedule("KillRatDead("@%clientId@");", 1.0);
  		 }
	  //else messageall(0, Client::getName(%clientId) @ " went to hell.");
}

function Freeze(%clientId,%option) 
{
	%player = Client::getOwnedObject(%clientId);
	%player.frozen = true;
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& !%option)
	{ 
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		schedule("Freeze("@%clientId@",true);", 120);// 2 minutes is plenty
  	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& %option)
	{ 
		Client::setControlObject(%clientId, %clientId);
		%player.frozen = false;
  	}
  	if(%option)
  		%player.frozen = false;
}

function Penalty(%clientId,%option,%time) 
{
	%player = Client::getOwnedObject(%clientId);
	%player.frozen = true;
	%clientId.silenced = true;
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& !%option)
	{ 
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		schedule("Penalty("@%clientId@",true);", %time);
	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& %option)
	{ 
		Client::setControlObject(%clientId, %clientId);
		%player.frozen = false;
	}
  	if(%option)
  	{
  		//release em
  		%player.frozen = false;
  		%clientId.silenced = false;
  		centerprint(%clientId, "<jc><f1>Your penalty is over.", 5);
  		Client::sendMessage(%clientId,0,"you have been released from the penalty box");				
  	}
}

function HotPoker(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ 
		Player::setDamageFlash(%clientId,1.0);
		if(%player.blind)
			schedule("HotPoker("@%clientId@");", 1.5);
  	}
	else
		Client::sendMessage(%clientId, 1, "In death you will see again.");
}

function PlayerFlagCurse(%Client){
//	%cl = Player::getClient(%player);
	
	if ($debug)echo("curse ",%Client);
	
	if(!%Client.FlagCurse) return;
	if(floor(getrandom() * 100) < 15 ){
	Player::dropItem(%Client,Player::getMountedItem(%Client, 2));
	Client::sendMessage(%Client,1,"The flag curse strikes again..~wError_Message.wav");	
	}
	else  schedule("PlayerFlagCurse("@%Client@");",2);
//	%type = Player::getMountedItem(%cl, $FlagSlot);
//	if(%type != -1)
//		Player::dropItem(%cl, %type);
	
}