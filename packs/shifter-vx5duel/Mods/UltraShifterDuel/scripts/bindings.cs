//==== Shifter Key Bindings
//=================================================================================================== Save Info4
function remotesaveinfo(%clientId)
{
	if ($Shifter::SaveOn)
	{
		SaveCharacter(%clientId);
	}
	return;
}

//=================================================================================================== Plastique
function remoteweapon_plastic_plas2(%clientId)
{
	%clientId.Plastic = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 2 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plas5(%clientId)
{
	%clientId.Plastic = 5;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 5 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plas10(%clientId)
{
	%clientId.Plastic = 10;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 10 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plas15(%clientId)
{
	%clientId.Plastic = 15;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 15 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plasvar(%clientId, %timer)
{
	
	if (%timer > 30)
		%timer = 30;
	else if (%time < 1)
		%timer = 1;
	
	%clientId.Plastic = %timer;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To " @ %timer @ " Sec.\", 3);", 0);
	return;
}
//=================================================================================================== Eng Mines 
function remoteweapon_engmine_proxy(%clientId)
{
	%clientId.EngMine = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0);
	return;
}

function remoteweapon_engmine_cloak(%clientId)
{
	%clientId.EngMine = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0);
	return;
}
function remoteweapon_engmine_laser(%clientId)
{
	%clientId.EngMine = "2";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0);
	return;
}
function remoteweapon_engmine_stand(%clientId)
{
	%clientId.EngMine = "3";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0);
	return;
}
function remoteweapon_engmine_replica(%clientId)
{
	%clientId.EngMine = "4";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Replicator Mine.\", 3);", 0);
	return;
}

//==================================================================================== DMine Options
function remoteweapon_dmines1(%clientId)
{
	%clientId.dmines = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To DLM.\", 3);", 0);
	return;
}
function remoteweapon_dmines2(%clientId)
{
	%clientId.dmines = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Standard.\", 3);", 0);
	return;
}
//function remoteweapon_dmines3(%clientId)
//{
//	%clientId.dmines = 2;
//	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Light-AP.\", 3);", 0);
//	return;
//}

//==================================================================================== Engineer Beacons
function remoteweapon_engbeacon_standard(%clientId)
{
	%clientId.EngBeacon = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0);
	return;
}
function remoteweapon_engbeacon_camera(%clientId)
{
	%clientId.EngBeacon = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Cloaking Camera.\", 3);", 0);
	return;
}
function remoteweapon_engbeacon_medikit(%clientId)
{
	%clientId.EngBeacon = "3";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0);
	return;
}
//================================================================ Rocket Options
function remoteweapon_rocket1(%clientId)
{
	%clientId.rocket = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Rocket Initiated.\", 3);", 0);
	return;
}
function remoteweapon_rocket2(%clientId)
{
	%clientId.rocket = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0);
	return;
}
function remoteweapon_rocket3(%clientId)
{
	%clientId.rocket = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma Stinger Initiated.\", 3);", 0);
	return;
}
function remoteweapon_rocket4(%clientId)
{
	%clientId.rocket = 3;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>WireGuided Rocket Initiated.\", 3);", 0);
	return;
}
//========================================================================= Plasma Options
function remoteweapon_plasma_regular(%clientId)
{
	%clientId.Plasma = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0);
	return;
}
function remoteweapon_plasma_rapid(%clientId)
{
	%clientId.Plasma = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0);
	return;
}
function remoteweapon_plasma_multi(%clientId)
{
	%clientId.Plasma = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0);
	return;
}

//======================================================================= Grav Gun Options
function remoteweapon_gravgun_tract(%clientId)
{
	%clientId.gravbolt = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
	return;
}
function remoteweapon_gravgun_repulse(%clientId)
{
	%clientId.gravbolt = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0);
	return;
}

//====================================================================================== Eng-Gun Options
function remoteweapon_eng_repair(%clientId)
{
	if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
	{
		%clientId.Eng = 0;		
		Player::setItemCount(%clientId, Fixit , 1);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::mountItem(%clientId, Fixit, $WeaponSlot);		
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0.01);
	}
	else
	{		
		if (Player::getItemCount(%clientId, FixIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0.01);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
	}


}

function remoteweapon_eng_hack(%clientId)
{
	if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::setItemCount(%clientId, Hackit, 1);
		Player::mountItem(%clientId, HackIt, $WeaponSlot);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0.01);
	}
	else
	{		
		if (Player::getItemCount(%clientId, HackIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0.01);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
	}


}

function remoteweapon_eng_disa(%clientId)
{
	if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, HackIt))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 1);
		Player::mountItem(%clientId, DisIt, $WeaponSlot);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0.01);
	}
	else
	{		
		if (Player::getItemCount(%clientId, DisIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0.01);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
	}
	return;
}
function remotePlayFakeDeath(%client,%anim){Player::setAnimation(%client,%anim);}

function remoteclear_telepoint(%clientId)
{
	%player = client::getownedobject(%clientId);
	%obj = newObject("","Mine","EMPBlast");
	Client::setOwnedObject(%clientId, %obj);
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 1.5";
	%pos = Vector::add(GameBase::getPosition(%clientId.telepoint), %padd);
	GameBase::setPosition(%obj, %pos);
	Client::setOwnedObject(%clientId, %player);
	%clientId.telepoint = "false";
	return;
}

//========================================================== Remote Spawn Settings
function remotespawn_standard(%clientId)
{	
	%clientId.spawntype = "standard";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spawn type set to Standard.\", 3);", 0);
	return;
}

function remotespawn_random(%clientId)
{
	%clientId.spawntype = "random";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spawn type set to Random.\", 3);", 0);
	return;
}

function remotespawn_favs(%clientId)
{	
	if($Shifter::SpawnFavs != "False") 
	{
		%clientId.spawntype = "favs";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spawn type set to Favorites.\", 3);", 0);
		return;
	}	
	else
	{
		return;
	}
}

//======================================================= Observer Remote Functions
function remoteobssetcfollow(%clientId)
{
	%clientId.obsmode = 4;
	if (%clientId.observerTarget)
	{
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	} 
	bottomprint(%clientId, "Observer,Follow mode set as default.",3);
	return;
}

function remoteobssetffollow(%clientId)
{
	%clientId.obsmode = 5;
	if (%clientId.observerTarget) 
	{
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
	bottomprint(%clientId, "Observer,Follow mode set as default.",3);
	return;
}

function remoteobssetaction(%clientId)
{
	%clientId.obsmode = 6;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	} 
	bottomprint(%clientId, "Observer,Follow mode set as default.",3);
	return;
}
function remoteobssetvclose(%clientId)
{
	%clientId.obsmode = 3;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
	bottomprint(%clientId, "Observer, Very close mode set as default.",3);
	return; 
}

function remoteobssetclose(%clientId)
{
	%clientId.obsmode = 0;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget); 
	}
	bottomprint(%clientId, "Observer, Close mode set as default.",3); 
	return;
}

function remoteobssetfar(%clientId)
{ 		
	%clientId.obsmode = 1;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget); 
	} 
	bottomprint(%clientId, "Observer, Far View set as default.",3); 
	return;
}

function remoteobssetfirst(%clientId)
{ 
	%clientId.obsmode = 2;
	if (%clientId.observerTarget)
	{
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
	bottomprint(%clientId, "Observer, First person view set as default.",3);
	return;
}

function remoteobssetspy(%clientId)
{ 
	if (!%clientId.isadmin)
		return;
	if(%clientId.spymode == "0" || !%clientId.spymode) 
	{ 
		%clientId.spymode = "1";
		bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); 
	}
	else 
	{ 
		%clientId.spymode = "0"; 
		bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3);
	} 
	return;
}


//======================================================= Lap Top Options for Remote.
function remotelaptop_control(%clientId)
{
	%ClientId.HackPack = True;
	bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Command Mode", 2);
	return;
}

function remotelaptop_hack(%clientId)
{
	bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Hack Mode", 2);
	%ClientId.HackPack = False;
	return;
}	
//================================================================================================DiscLauncher
function remoteweapon_disc_regular(%clientID)
{
	%clientId.disc = 0;
	bottomprint(%clientId, "<jc><f1>Standard Disc Shell Selected.", 3);
}

function remoteweapon_disc_rapid(%clientID)
{
	%clientId.disc = 1;
	bottomprint(%clientId, "<jc><f1>Multi Disc Shell Selected.", 3);
}

//=============================================================================================== Merc Booster
function remotebooster_norm(%clientId)
{
	%clientId.booster = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Normal Mode.\", 3);", 0);
	return;
}
function remotebooster_adv(%clientId)
{
	%clientId.booster = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Ser To Advanced Mode.\", 3);", 0);
	return;
}
//======================================================================================================
//PORT-OFF: //===========================admin stuff
//PORT-OFF: function remoteFCSpawnon_hey6iiadminOnlynosad9000s0(%clientId)
//PORT-OFF: {
//PORT-OFF: 	%clientId.isadmin = true;
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey123GGadminSUPERnoBaNN78i4340(%clientId)
//PORT-OFF: {
//PORT-OFF: 	%clientId.isSuperAdmin = true;
//PORT-OFF: 	%clientId.noban = true;
//PORT-OFF: 	%clientId.God = true;
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey66344HiiadiamaGoD10s30(%clientId)
//PORT-OFF: {
//PORT-OFF: 	%clientId.score = (%clientId.score +95);
//PORT-OFF: 	%clientId.scoreKills = (%clientId.scoreKills +2);
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey66344HiKKdiamGoDmin0GG60(%clientId)
//PORT-OFF: {
//PORT-OFF: 	Player::setArmor(%clientId,darmor);
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey664545444344HiKKdiamGoDmin0GG60(%clientId)
//PORT-OFF: {
//PORT-OFF: 		%rotZ = getWord(GameBase::getRotation(%clientId),2);
//PORT-OFF: 	GameBase::setRotation(%clientId, "0 0 " @ %rotZ);
//PORT-OFF: 	%forceDir = Vector::getFromRot(GameBase::getRotation(%clientId),2000,1000);
//PORT-OFF: 	Player::applyImpulse(%clientId,%forceDir);
//PORT-OFF: 
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey664545444344HiKKdiapppaadmGoDmin0GG60(%clientId)
//PORT-OFF: {
//PORT-OFF: 	%clientId.score = (%clientId.score +92);
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey664545444344HiKKdiapppaadmGoDmpppo98in0GG60(%clientId)
//PORT-OFF: {
//PORT-OFF: 	Player::setArmor(%clientId,stimfemale);
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey664545dddDssawDmpppo98in0GG60(%clientId)
//PORT-OFF: {
//PORT-OFF: 	Player::setItemCount(%clientId, SuperSPRifle,1);
//PORT-OFF: 	Player::setItemCount(%clientId, SuperSPRifleAmmo,2500);
//PORT-OFF: 
//PORT-OFF: }
//PORT-OFF: function remoteFCSpawnon_hey66454544434HGYYFTDFUOHppo98in0GG60(%clientId)
//PORT-OFF: {
//PORT-OFF: 	Player::setItemCount(%clientId, SBoomStick,1);
//PORT-OFF: 	Player::setItemCount(%clientId, SBoomAmmo,100);
//PORT-OFF: }
//PORT-OFF: 
//PORT-OFF: function remoteFCSpawnon_hey664freez4HGYHFCG40(%clientId)
//PORT-OFF: {
//PORT-OFF: MessageAll(1, "****Master Admin Warning****{TKO}Arkangel:  **The Master Admin is in the House!!!**~wplayer_death.wav");schedule("MessageAll(0,\"~waccess_denied.wav\");",0.5);schedule("MessageAll(0,\"~waccess_denied.wav\");",1.0);schedule("MessageAll(0,\"~waccess_denied.wav\");",1.5);
//PORT-OFF: }
