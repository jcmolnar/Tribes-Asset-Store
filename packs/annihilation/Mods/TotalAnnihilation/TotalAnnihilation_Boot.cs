
//$AutoLock = false;
      // Automatically locks (by password)  the server when the max players is reached and adds the number below to the max players amount, when the number drops below default max server amount, the server will unlock.
 
//$AutoLockAdd = 2;
      // Says how many player slots to add to the Max Players when the server is locked. (AutoLockAdd is the amount of reserved spot(s) to be added to the Maximum Players amount) 
 
//$AutoLockPassword = "CHaNGE_tHIS";
      // The password required by the server to allow any more people in.
 
//$AutoLockDisplay = false;
      // Display $AutoLockMsgLocked message when the server is locked and the $AutoLockMsgUnLocked message when the server is unlocked. (Only Displayed when the change is made)
 
//$AutoLockMsgLocked = "Server is now locked!";
      // This will display if the $AutoLockDisplay is true and the server gets locked.
 
//$AutoLockMsgUnLocked = "The server is now unlocked!";
      // Same as above but for unlocked.
 
// << AutoLock
 
// >> Auto Base Damage
 
$AutoBaseDamage = true;
      // Enable Auto-Base Damage?  True = When each team reaches the amount of players required for each team (set in $AutoBDMinTeam) base damage will be enabled, if the team go below that number, base damage will be disabled.
 
$AutoBDMinTeam = 0;  // changed from 6 to 0 -death666 3.24.17
      // The minimal amount of people required for base damage to be enabled.
 
// << Auto Base Damage
 
// >> Disable Weapons
 
$DisableNuke = false;
      // Some people really hate nukes, esp. when they are spammed.

$DisableDPT = false;
      // Adding in disabling of deployable turrets -death666

$DisableOS = false;
      // Half of the famous KlanKind weapon disable. Disables the Optical Seeking Rocket Laucher. (Does not show and is not usable)
 
$DisableJail = false;
      // The other half of the famous KlanKind weapon disable. Disables the Jailer and Jail Tower from the game. (If $HaveFun is true then Jail Tower is enabled, for fun, but the Jailgun will remain disabled thus the Jail is not useable)
 
$DisableDropShips = false;
      // DropShips can cause the server to crash because of the large size of data required to be held by the server for the new objects...
 
$DisableDroids = false;
      // Some people really hate droids...
 
$DisableMobilePower = false;
      // Donno why I added this but whatever, you can disable mobile power objects with this (i.e. Mobile Invo, Portable Gen, and Portable Solar).
 
$DisableAmmoForDisabled = true;
      // Disables the ammo for the weapons that are disabled.
 
$HaveFun = false;
      // Enables Jail Tower but leaves Jailgun disabled.
 
// << Weapon Disable
 
// >> Prevent Change
 
$PCTeamDamage = false;
      // Prevents Team Damage from being changed by anyone in game (includes admins of all levels, same will be for all PC settings).
 
$PCBaseDamage = false;
      // Prevents change in Base Damage, does not interfere with Auto Base Damage if enabled.
 
$PCBuilder = false;
      // Prevents change in the Builder setting.
 
$PCObserverAlert = false;
      // Prevents Observer Alert setting from being changed.
 
$PCTimeLimit = false;
      // Prevents the time limit from being changed.
 
$PCBaseHeal = false;
      // Prevents Base Healing setting from being changed.
 
$PCVoteAdmin = true;
      // Prevents Vote Admin from being enabled/disabled. (This also closes a security hole in Annihilation that allows a Super to enabled vote admin then vote someone to power (used when SA's cannot give admin the normal way).)
 
$SilentMode = false;
      // If true, does not say anything when it changes a setting back to default value after something changes it.
 
// << Prevent Change

// >> Name Ban

$UseNameBan = false;
   // If true, bans people with certain names.

$NameBan[0] = "";

// << Name Ban
 
// << Settings
 
// >> Temp
 
if ($AutoLockEnabled != true && $AutoLockEnabled != false)
{
      $AutoLockEnabled = false;
      $AutoLockTempMax = $Server::MaxPlayers;
      $AutoLockTempPass = $Server::Password;
      $PCTempTeamDmg = $Server::TeamDamageScale;
      $PCTempBaseDmg = $Annihilation::SafeBase;
      $PCTempBuilder = $build;
      $PCTempObsAlert = $Annihilation::obsAlert;
      $PCTempVAdmin = $Annihilation::VoteAdmin;
      $PCTempTime = $Server::TimeLimit;
      $PCBaseHeal = $Annihilation::BaseHeal;
}
 
// << Temp
 
// echo("AutoBaseDamage: "@$AutoBaseDamage@", AutoBDMinTeam: "@$AutoBDMinTeam@",");
// echo("AutoLock: "@$AutoLock@", AutoLockAdd: "@$AutoLockAdd@", AutoLockDisplay: "@$AutoLockDisplay@",");
// echo("DisableNuke: "@$DisableNuke@", DisableOS: "@$DisableOS@", DisableJail: "@$DisableJail@",");
// echo("DisableDroids: "@$DisableDroids@", DisableMobilePower: "@$DisableMobilePower@",");
// echo("DisableAmmoForDisabled: "@$DisableAmmoForDisabled@", HaveFun: "@$HaveFun@".");

function autodoeverythingfun()
{
	if($Server::TourneyMode)
		return;
 
	purgeResources(); 

 // Prevent Change (PC) code
 if ($PCTempTeamDmg != $Server::TeamDamageScale && $PCTeamDamage == true)
 {
  $Server::TeamDamageScale = $PCTempTeamDmg;
  if ($SilentMode != true)
   messageAll(1,"Team Damage cannot be changed!!!~waccess_denied.wav");
 }
 
 if ($PCTempBuilder != $build && $PCBuilder == true)
 {
  $build = $PCTempBuilder;
  if ($SilentMode != true)
   messageAll(1,"Building Mode cannot be enabled on this map type. ~waccess_denied.wav");
 }
 
 if ($PCTempBaseDmg != $Annihilation::SafeBase && $PCTeamDamage == true)
 {
  $Annihilation::SafeBase = $PCTempBaseDmg;
  if ($SilentMode != true)
   messageAll(1,"Base Damage cannot be changed!!!~waccess_denied.wav");
 }
 
 if ($PCTempObsAlert != $Annihilation::obsAlert && $PCObserverAlert)
 {
  $Annihilation::obsAlert = $PCTempObsAlert;
  if ($SilentMode != true)
   messageAll(1,"Observer Alert cannot be changed!!!~waccess_denied.wav");
 }
 
 if ($PCTempTime != $Server::TimeLimit && $PCTimeLimit == true)
 {
  $Server::TimeLimit = $PCTempTime;
  if ($SilentMode != true)
   messageAll(1,"The Time Limit cannot be changed!!!~waccess_denied.wav");
 }
 
 if ($PCTempBaseHeal != $Annihilation::BaseHeal && $PCBaseHeal == true)
 {
  $Annihilation::BaseHeal = $PCTempBaseHeal;
  if ($SilentMode != true)
   messageAll(1,"Base Heal cannot be changed!!!~waccess_denied.wav");
 }

 // Disable Nuke
 if ($DisableNuke == true)
 {
  PopulateItemMax(BabyNukeMortar);
  if ($DisableAmmoForDisabled == true)
   PopulateItemMax(BabyNukeAmmo);
 }

       
      //Disable DropShips
      if ($DisableDropShips == true)
      {
            PopulateItemMax(CommandShipPack);
            PopulateItemMax(GunShipPack);
            PopulateItemMax(SupplyShipPack);
      }
 
      // Disable Jail
      if ($DisableJail == true)
      {
            PopulateItemMax(Jailgun);
            if ($HaveFun == false)
                  PopulateItemMax(JailTower);
            // I thought it would be funny to see someone put up a jail and make defense all around it to end up learning that (s)he can't use it.
      }
 
      // Disable OS (Optical Seeking rocket)
      if ($DisableOS == true)
      {
            PopulateItemMax(OSLuncher);
            if ($DisableAmmoForDisabled == true)
                  PopulateItemMax(OSAmmo);
      }
 
      // Disable Droids
      if ($DisableDroids == true)
    {
            PopulateItemMax(ProbeDroidPack);
            PopulateItemMax(SuicideDroidPack);
            PopulateItemMax(SurveyDroidPack);
      }
 
      // Disable Mobile Power
      if ($DisableMobilePower == true)
      {
            PopulateItemMax(MobileInventoryPack);
            PopulateItemMax(PortableSolarPack);
            PopulateItemMax(PortableGeneratorPack);
      }
       
      // The below code is now also used by AutoLock now.
      %numPlayers = getNumClients();
 
      // Auto Lock Code
      if ($AutoLock == true)
      {
            if ($AutoLockTempMax <= %numPlayers)
            {
                  if (!($AutoLockEnabled))
                  {
                        echo("AutoLock: Server was locked because of max user limit reached!");
                        if ($AutoLockDisplay == true) messageAll(3,$AutoLockMsgLocked);
                        $AutoLockTempMax = $Server::MaxPlayers;
                        $AutoLockTempPass = $Server::Password;
                        $AutoLockEnabled = true;
                  }
                  if ($Server::Password == $AutoLockTempPass) $Server::Password = $AutoLockPassword;
                  if ($Server::MaxPlayers == $AutoLockTempMax) $Server::MaxPlayers = $Server::MaxPlayers + $AutoLockAdd;
            }
            if ($AutoLockTempMax > %numPlayers && $AutoLockEnabled == true)
            {
                  $AutoLockEnabled = false;
                  $Server::MaxPlayers = $AutoLockTempMax;
                  $Server::Password = $AutoLockTempPass;
                  echo("AutoLock: Server unlocked because of less than the max user limit!");
                  if ($AutoLockDisplay == true)
                        messageAll(1,$AutoLockMsgUnLocked);
            }
      }

   // Name Bans
   if ($UseNameBan == true)
   {
       for(%i = 0; %i < %numPlayers; %i = %i +1)
            {
			%cl = getClientByIndex(%i);
			%name = Client::getName(%cl);
			for (%k = 0; $NameBan[%k] != ""; %k = %k +1)
			{
				if ($NameBan[%k] == %name || $NameBan[%k]@".1" == %name)
				{
					echo("BAN: "@%name@" has been name banned from this server!");
					schedule("net::kick("@%cl@", \"You have been Banned!\");", 3);
					%ip = Client::getTransportAddress(%client);
					BanList::add(%ip, $Annihilation::BanTime);
					BanList::export("config\\banlist.cs");
				}   
			}
		}
	}
   
     
	// Auto Base Damage Code
	if ($AutoBaseDamage == true)
	{
		%numTeams = getNumTeams()-1;
		%fp = %numTeams +1;
		for(%i = 0; %i < %numTeams; %i = %i +1) %numTeamPlayers[%i] = 0;
 
		for(%i = 0; %i < %numPlayers; %i = %i +1)
		{
			%cl = getClientByIndex(%i);
			if(!%cl.inArena && !%cl.inDuel) 
			{
				%team = Client::getTeam(%cl);
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
			}
		}
 
		%greater = true;
 
		for(%i = 0; %i < %numTeams; %i = %i + 1)
		{
			if (%numTeamPlayers[%i] < $AutoBDMinTeam) %greater = false;
		}
 
		if ($Annihilation::SafeBase == true && %numTeams > 0 && %greater == true)
		{
			$Annihilation::SafeBase = false;
			$PCTempBaseDmg = false;
			echo("GAME: Auto-Base Damage: Base Damage ENABLED because of more than "@$AutoBDMinTeam@" vs "@$AutoBDMinTeam@".");
			messageAll(3, "Base Damage ENABLED because of more than "@$AutoBDMinTeam@" vs "@$AutoBDMinTeam@".~wCapturedTower.wav");
 		}
		else if (($Annihilation::SafeBase == false && %greater == false) || %numTeams == 0)
		{
			$Annihilation::SafeBase = true;
			$PCTempBaseDmg = true;
			echo("GAME: Auto-Base Damage: Base Damage DISABLED because of less than "@$AutoBDMinTeam@" vs "@$AutoBDMinTeam@".");
			messageAll(1, "Base Damage DISABLED because of less than "@$AutoBDMinTeam@" vs "@$AutoBDMinTeam@".~wCapturedTower.wav");
		}
	}
       
	// Call back.
	schedule("autodoeverythingfun();", 2);
}

if(!$Server::TourneyMode) //lets kill this if tourny mode
	autodoeverythingfun();	

function Duck::PullMA()
{
	if($TA::PullMA)
	{
		%ducksite = 0;
		duck::Pull(%ducksite, false);
		%ducksite = 1;
		duck::Pull(%ducksite, false);
		%ducksite = 2;
		duck::Pull(%ducksite, false);
		%ducksite = 3;
		duck::Pull(%ducksite, false);
		%ducksite = 24;
		duck::Pull(%ducksite, false);
		%ducksite = 25;
		duck::Pull(%ducksite, false);
		%ducksite = 26;
		duck::Pull(%ducksite, false);
		%ducksite = 27;
		duck::Pull(%ducksite, false);
		schedule("Duck::PullMA();",6);
	}
	else
		return;
}