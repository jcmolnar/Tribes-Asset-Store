function Client::getStatus(%Id)// Basically the same as plas's funct.
{
	if(Client::getOwnedObject(%Id) == -1 && Client::getTeam(%Id) != -1)
	{ %status = "(Dead)"; }
	else if(Client::getOwnedObject(%Id) != -1 && Client::getTeam(%Id) != -1)
	{ %status = "(Live)"; }
	else if(Client::getTeam(%Id) == -1)
	{ %status = "(Observing)"; }
	return %status;
}

function Posses(%clientId, %cl, %opt)
{
	if($Debug){ Echo("****** Possess ******"); }
	
	%posseeId = %cl;
	%posseeName = Client::getName(%cl);
	%posseePlayer = Client::getOwnedObject(%cl);
	%posseeStatus = Client::getStatus(%posseeId);
	
	%posserId = %clientId;
	%posserName = Client::getName(%clientId);
	%posserPlayer = Client::getOwnedObject(%clientId);
	%posserStatus = Client::getStatus(%posserId);
	
	if(%opt == "Poss")
	{
		if(%posserId == %posseeId)
		{ Client::sendMessage(%posserId, 1, "ERROR: Cannot Possess Yourself.~wAccess_Denied.Wav"); return; }
		
		if(%posseeId.isFrozen == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Frozen.~wAccess_Denied.Wav"); return; }
		
		if(%posseeId.isPossessing == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessing Someone.~wAccess_Denied.Wav"); return; }
		
		if(%posseeId.isPossessed == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessed.~wAccess_Denied.Wav"); return; }
		
		if(%posseeStatus == "(Dead)")
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Dead.~wAccess_Denied.Wav"); return; }   
		
		if(%posseeStatus == "(Observing)")
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Observing.~wAccess_Denied.Wav"); return; }
		
		// Possesed Person data.
		%posseeId.isPossessed = true;
		%posseePlayer.shieldStrength = 350.0;
		%posseeId.Possby = %posserId;
		%posseeId.noSuicide = 1;
		%posseeId.guiLock = true;
		%posseePlayer.guiLock = true;
		
		// Possesser data. 
		%posserPlayer.shieldStrength = 350.0;
		%posserId.isPossessing = true;
		%posserId.hasPossPlayer = %posseePlayer;
		%posserId.hasPossClient = %posseeId;
		
		// Set possessed client as an observer.
		Client::setControlObject(%posseeId, Client::getObserverCamera(%posseeId));
		
		
		// Set possessed client to obs his body.
		Observer::setOrbitObject(%posseeId, %posseePlayer, 3, 3, 3);
		CenterPrint(%posseeId, "<jl><BSkull_Big.Bmp><jc><f1>You have been possessed by <f2>"@ %posserName @", <f1>enjoy the ride..<jr><BSkull_Big.Bmp>", 10);
		
		
		// Set the possesser player as the possessee player.
		Client::setControlObject(%posserId, %posseePlayer);
		
		if($Debug)
		{
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
	else if(%opt == "UNPoss")
	{
		// If the client you've selected isn't possessed, I'll let ya know your a retard... :)
		if(!%posseeId.isPossessed)
		{ Client::sendMessage(%posserId, 0, "Selected Client Is Not Possessed.~wAccess_Denied.Wav"); return; }
		
		// If the client calling this function is not the actual possesser, then we need
		// to reset the id, the name, and the player to the right one.
		if(%posserId != %posseeId.Possby)
		{
			%posserId = %posseeId.Possby;
			%posserName = Client::getName(%posserId);
			%posserPlayer = Client::getOwnedObject(%posserId);
		}
			
		// Possessed Player data.
		%posseeId.isPossessed = false;
		%posseePlayer.shieldStrength = 0.0;
		%posseeId.Possby = "";
		%posseeId.noSuicide = 0;
		%posseeId.guiLock = false;
		%posseePlayer.guiLock = false;
		
		// Possesser Player data.
		%posserPlayer.shieldStrength = 0.0;
		%posserId.isPossessing  = false;
		%posserId.hasPossPlayer = "";
		%posserId.hasPossClient = "";
		
		CenterPrint(%posseeId, "<jc><f1>"@ %posserName @" says 'I can't take the smell anymore. Take A Shower Boy! Damn You Stink!'", 5);
		
		// Reset clients to their normal bodies.
		Client::setControlObject(%posserId, %posserPlayer);
		Client::setControlObject(%posseeId, %posseePlayer);
		
		if($Debug)
		{
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
}

// after this time the client will be unfroze automatically.
$FreezePadTime = 25;

// I use this funct for a deployable freezing pad and as an admin opt.
function Freeze(%clientId, %var)
{
	%player = Client::getOwnedObject(%clientId);
	%playername = Client::getName(%clientId);
	
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %var == "on")
	{
		%clientId.isfrozen = 1;
		%clientId.noSuicide = 1;
		
		Client::sendMessage(%clientId, 0, "Freeze!~wmale1.wwshoot1.wav");
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		CenterPrint(%clientId, "<jc><f1>"@ $Server::HostName @"\n "@ %playername @", You have been frozen!\n Get comfy you have "@ $StandardFreezeTime @" Seconds to unthaw", 10);
		Schedule("FreezeCheck("@ %clientId @");", $FreezePadTime);
		return;
	}
	
//	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %var == "off")
	else if(%var == "off")
	{ 
		Client::setControlObject(%clientId, %player);
		Client::sendMessage(%clientId, 0, "Ok There ya go "@ %playername @"~wmale1.wsorry.wav");
		
		%clientId.isfrozen = 0;
		%clientId.nosuicide = 0;
		return;
	}
}

function FreezeCheck(%clientId)
{
//	Echo("FreezeCheck("@ %clientId @");"); 
	if(%clientId.isfrozen)
	{ Echo("Freeze Check: Client has been unfroze"); Freeze(%clientId, "off"); }
}