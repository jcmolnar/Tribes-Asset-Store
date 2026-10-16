//=========================================================================================================================================
// 																AI::setWeapons()
//=========================================================================================================================================
//
//   Modified by Werewolf
//
//      The AI:setWeapons was removed to this file BotGear for the simple reason of makeing the bots more configurable in an easier manner.
// Mostly for developers of mods that contain bots. This way if you have different weapons and armor types...
//
//  								    The following contains the AI::setWeapons and AI::periodic
//
//  									Moved to the BotGear file for configurability by Emo1313...
//
//=========================================================================================================================================

//function AI::setWeapons(%aiName)
function AI::setWeapons(%aiId)
{
//	%aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;


	if (!BotFuncs::CheckAlive(%aiId))
	{
		return;
	}

	%aiName = Client::GetName(%aiId);

	AI::setVar(%aiName, iq, $Spoonbot::IQ );

	//== In case some moron ignorant mapmaker (just kidding ;-)) forgot to name the bots according to the readme,
	//== they'll spawn with the ugly-useless standard weapons.
	//== by Werewolf

	Player::setItemCount(%aiId, PPC, 1);
	Player::setItemCount(%aiId, STR2, 0);
	Player::setItemCount(%aiId, Ultra5, 0);
	Player::setItemCount(%aiId, STRammo, 0);
	Player::setItemCount(%aiId, Ultra5Ammo, 0);

	%aiTeam = GameBase::getTeam( %aiId );

	AI::SetVar(%aiName, triggerPct, 0.03 );
	AI::setVar(%aiName, attackMode, 1);
	AI::setAutomaticTargets( %aiName );
//	AI::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);

	$Spoonbot::LastAttackerId[%aiId] = -1;
	$Spoonbot::AttackerId[%aiId] = -1;

	AI::PeriodicWeaponChange(%aiName);

//=========================================================== If Mission Type Death Match, Set Basics And Return

   if(Game::missionType == "DM")
   {	
        Player::setItemCount(%aiId, blaster, 1);
			$Spoonbot::ArmorWeight[%AiId] = 1;
		Player::mountItem(%aiId, PPC, 0);
	    return;
   }
//=========================================================== Mortar Bot Set Up
	if(String::findSubStr(%aiName, "Mortar") >= 0)
	{
	    AI::setVar(%aiName, iq, $Spoonbot::IQ );
	   	   for(%i = 0; $Spoonbot::MortarGear[%i] != ""; %i++)
		   {
	 	        Player::setItemCount(%aiId, $Spoonbot::MortarGear[%i], $SpoonBot::MortarAmmo[%i]);
		   }
		   Player::mountItem(%aiId, $SpoonBot::MortarLong, 0);
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::MortarObject;
	Player::mountItem(%aiId, $SpoonBot::MortarPack, 1);
	}
//=========================================================== Atlas Bot Set Up
	if(String::findSubStr(%aiName, "Atlas") >= 0)
	{
	    AI::setVar(%aiName, iq, $Spoonbot::IQ );
			$Spoonbot::ArmorWeight[%AiId] = 3;
	   	   for(%i = 0; $Spoonbot::AtlasGear[%i] != ""; %i++)
		   {
	 	        Player::setItemCount(%aiId, $Spoonbot::AtlasGear[%i], $SpoonBot::AtlasAmmo[%i]);
		   }
		   Player::mountItem(%aiId, $SpoonBot::AtlasLong, 0);
		   if ($SpoonBot::AtlasLong == "ArrowIV") 
			{
			Player::useItem(%aiId, FCCPod);
			}
			AI::SetVar(%aiName, spotDist, 301);		
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::AtlasObject;
	Player::mountItem(%aiId, $SpoonBot::AtlasPack, 1);
	}
	
//=========================================================== Panther Bot Setup
	else if(String::findSubStr(%aiName, "Panther") >= 0)
	{
	    AI::setVar(%aiName, iq, $Spoonbot::IQ );
			$Spoonbot::ArmorWeight[%AiId] = 1;
	   		for(%i = 0; $Spoonbot::PantherGear[%i] != ""; %i++)
			{
	 	        Player::setItemCount(%aiId, $Spoonbot::PantherGear[%i], $SpoonBot::PantherAmmo[%i]);
	        }
			Player::mountItem(%aiId, $SpoonBot::PantherLong, 0);
			AI::SetVar(%aiName, spotDist, 301);		
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::PantherObject;
	Player::mountItem(%aiId, $SpoonBot::PantherPack, 1);
	}
//=========================================================== BattleMaster Bot Setup
	else if(String::findSubStr(%aiName, "BattleMaster") >= 0)
	{
	    AI::setVar(%aiName, iq, $Spoonbot::IQ );
			$Spoonbot::ArmorWeight[%AiId] = 2.3;
   		for(%i = 0; $Spoonbot::BattleMasterGear[%i] != ""; %i++)
 	       Player::setItemCount(%aiId, $Spoonbot::BattleMasterGear[%i], $SpoonBot::BattleMasterAmmo[%i]);
        Player::mountItem(%aiId, $SpoonBot::BattleMasterLong, 0);
	
	    AI::SetVar(%aiName, spotDist, 301);
	    AI::SetVar(%aiName, seekOff , 1);   // Dunno what this does. Werewolf
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::BattleMasterObject;
	Player::mountItem(%aiId, $SpoonBot::BattleMasterPack, 1);
	}
//=========================================================== Sniper Bot Setup	
	else if(String::findSubStr(%aiName, "Sniper") >= 0)
	{
	   AI::setVar(%aiName, iq, $Spoonbot::IQ );
			$Spoonbot::ArmorWeight[%AiId] = 0.75;
	   	   for(%i = 0; $Spoonbot::SniperGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::SniperGear[%i], $SpoonBot::SniperAmmo[%i]);
		   Player::mountItem(%aiId, $SpoonBot::SniperLong, 0);
		   
	    AI::SetVar(%aiName, spotDist, 301);		// Make 20-20 vision for snipers ;-) Werewolf - Make 301 for >300 but not infinite - Mr. X
	    AI::SetVar(%aiName, seekOff , 1);   // Dunno what this does. Werewolf
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::SniperObject;
	Player::mountItem(%aiId, $SpoonBot::SniperPack, 1);
	}
//=========================================================== Medic Bot Setup
	else if(String::findSubStr(%aiName, "Medic") >= 0)
	{
			$Spoonbot::ArmorWeight[%AiId] = 1.5;
	   AI::setVar(%aiName, iq, $Spoonbot::IQ );
	   	  for(%i = 0; $Spoonbot::MedicGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::MedicGear[%i], $SpoonBot::MedicAmmo[%i]);
	      Player::mountItem(%aiId, $SpoonBot::MedicLong, 0);
			AI::SetVar(%aiName, spotDist, 301);		
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::MedicObject;
	Player::mountItem(%aiId, $SpoonBot::MedicPack, 1);
	}
//=========================================================== Archer Bot Setup
	else if(String::findSubStr(%aiName, "Archer") >= 0)
	{
	   	   AI::setVar(%aiName, iq, $Spoonbot::IQ );
			$Spoonbot::ArmorWeight[%AiId] = 2;
	   	   for(%i = 0; $Spoonbot::ArcherGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::ArcherGear[%i], $SpoonBot::ArcherAmmo[%i]);
	       Player::mountItem(%aiId, $SpoonBot::ArcherLong, 0);
		AI::SetVar(%aiName, spotDist, 301);		
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::ArcherObject;
	Player::mountItem(%aiId, $SpoonBot::ArcherPack, 1);
	}
//=========================================================== Standard Setup	
	else 
	{
	   	   AI::setVar(%aiName, iq, $Spoonbot::IQ );
		$Spoonbot::ArmorWeight[%AiId] = 1;	
	   	   for(%i = 0; %i = ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::StandardGear[%i], $SpoonBot::StandardAmmo[%i]);
	       Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);
		AI::SetVar(%aiName, spotDist, 301);		
	$Spoonbot::DemoObject[%aiId] = $Spoonbot::StandardObject;
	Player::mountItem(%aiId, $SpoonBot::StandardPack, 1);
	}
}


//=========================================================================================================================================
//							AI::periodicWeaponChange()
//=========================================================================================================================================
//modified by Werewolf

function ai::periodicWeaponChange(%aiName)
{
    %aiId = BotFuncs::GetId(%aiName);
if (%aiId==0)
	return;

	if (!BotFuncs::CheckAlive(%aiId))
	{
		return;
	}

//Sanity check. Check if Bot is alive. If not then clear Vars and abort functiom
//----------------------------------------
//Werewolf

if ($Spoonbot::BotStatus[%aiId] == "Dead")
	return;

%player = Client::getOwnedObject(%aiId);

if (Player::isDead(%player))
	{
		BotFuncs::ClearVars(%aiId);
		return;
    }

    %aiName = Client::getName(%aiId);

//The following needs to be done in case
//IsDead doesn't work in this version

    %newId = BotFuncs::GetId(%aiName);
if (%newId==0)
	return;
    if (%newId != %aiId)
    {
		BotFuncs::ClearVars(%aiId);
		return;
    }
//    if(String::findSubStr(%aiName, "Atlas") >= 0)	//Commented out by Mr. X
//    BotFuncs::checkForPaint(%aiName);		//Commented out by Mr. X

//    BotFuncs::checkForFlagrunner(%aiName);
//    BotFuncs::RepairTask(%aiName);

//    %curTarget = ai::getTarget( %aiName );
   
//    if(%curTarget == 0)
//    {
//	%curTarget = $Spoonbot::Target[%aiId];
//    }
//    if(%curTarget == -1)
//    {
//	%curTarget = $Spoonbot::Target[%aiId];
//    }

    %curTarget = BotFuncs::NearestAttacker(%aiId, 300, 6);
    %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
    %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
    %targetDist = Vector::getDistance(%aiLoc, %targLoc);

  if(%targetDist == -1)
    {
	%targetDist = 300;
    }

    if(%targetDist == 0)
    {
	%targetDist = 300;
    }

    if(%targetDist <= 100)
    {
	$Spoonbot::LastAttackerId[%aiId] = $Spoonbot::AttackerId[%aiId];
    	$Spoonbot::AttackerId[%aiId] = %curTarget;
    }
    else
    {
	$Spoonbot::LastAttackerId[%aiId] = $Spoonbot::AttackerId[%aiId];
    	$Spoonbot::AttackerId[%aiId] = -1;
    }
	
	//============================================================================ Mortar Weapons
	if(String::findSubStr(%aiName, "Mortar") >= 0)
	{
		   if(%targetDist > 66)
		   {
		
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::MortarJet, 0);
		         AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
				Player::mountItem(%aiId, $SpoonBot::MortarLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::MortarClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 1 );
		   }
	}


	//============================================================================ Atlas Weapons
	else 
	{
	 if(String::findSubStr(%aiName, "Atlas") >= 0)
	 {
		   if(%targetDist > 66)
		 {
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::AtlasJet, 0);
		         AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
				Player::mountItem(%aiId, $SpoonBot::AtlasLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::AtlasClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.7 );
		   }
	 }
	
	//============================================================================ Panther Weapons
	 else 
	 {
	   if(String::findSubStr(%aiName, "Panther") >= 0)
	   {
		   if(%targetDist > 66)
		   {
		
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::PantherJet, 0);
		         AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
				Player::mountItem(%aiId, $SpoonBot::PantherLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::PantherClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.7 );
		   }
	  }
	
	//============================================================================ BattleMaster Weapons
	  else 
	  {
	   if(String::findSubStr(%aiName, "BattleMaster") >= 0)
	   {
		   if(%targetDist > 66)
		   {
		
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::BattleMasterJet, 0);
		         AI::SetVar(%aiName, triggerPct, 0.5 );
		      }
		      else
		      {
		         Player::mountItem(%aiId, $SpoonBot::BattleMasterLong, 0);
		         AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::BattleMasterClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.7 );
		   }
	   }
	
	//============================================================================ Sniper Weapons
	   else 
	   {
	    if(String::findSubStr(%aiName, "Sniper") >= 0)
	    {
		   Player::setDetectParameters(%aiId, 0.0001, 0.00001);
	
		   if(%targetDist > 66)
		   {
	
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
			        Player::mountItem(%aiId, $SpoonBot::SniperJet, 0);
			        AI::SetVar(%aiName, triggerPct, 0.5 );
		      }
		      else
		      {
					Player::mountItem(%aiId, $SpoonBot::SniperLong, 0);
					AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::SniperClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.7 );
		   }
	    }
	
	//============================================================================ Archer Weapons
	    else 
	    {
	     if(String::findSubStr(%aiName, "Archer") >= 0)
	     {
		   if(%targetDist > 66)
		   {
		
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
		        	Player::mountItem(%aiId, $SpoonBot::ArcherJet, 0);
		        	AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
		        	Player::mountItem(%aiId, $SpoonBot::ArcherLong, 0);  
		        	AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::ArcherClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.7 );
		   }
	     }
	
	//============================================================================ Set Medic Weapons
	     else 
	     {
	      if(String::findSubStr(%aiName, "Medic") >= 0)
	      {
		   if(%targetDist > 20)
		   {
		      if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
		      {	
		         	Player::mountItem(%aiId, $SpoonBot::MedicJet, 0);
		         	AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
		         	Player::mountItem(%aiId, $SpoonBot::MedicLong, 0);  
		         	AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::MedicClose, 0);
		         AI::SetVar(%aiName, triggerPct, 1 );
		   }
	      }
	
	
	
	//============================================================================ Set Standard Weapons If Bot Is Not Any Of The Presets
	else 
	{	
	    if(%targetDist > 66)
	    {
	    	 Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);
	     	 AI::SetVar(%aiName, triggerPct, 0.5 );
	    }   
	    else
	    {
	       if((Player::isJetting(%curTarget))||($Spoonbot::BotJettingHeat[%curTarget] == 1))
	       {	
	          Player::mountItem(%aiId, $SpoonBot::StandardJet, 0);
	          AI::SetVar(%aiName, triggerPct, 0.6 );
	       }
	       else
	       {
	          Player::mountItem(%aiId, $SpoonBot::StandardClose, 0);  
	          AI::SetVar(%aiName, triggerPct, 0.5 );
	       }   
	    }
	}
	      }
	     }
	    }
	   }
	  }
	 }

schedule("ai::periodicWeaponChange(" @ %aiName @ ");", $Spoonbot::ThinkingInterval);

}
//============================================================================================================== End Of Bot Setup Functions
