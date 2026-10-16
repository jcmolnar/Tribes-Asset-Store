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

function AI::setWeapons(%aiName)
{
	%aiId = AI::getId(%aiName);
    AI::setVar(%aiName, iq, 90 );

	//== In case some moron ignorant mapmaker (just kidding ;-)) forgot to name the bots according to the readme,
	//== they'll spawn with the ugly-useless standard weapons.
	//== by Werewolf

	Player::setItemCount(%aiId, blaster, 1);
	Player::setItemCount(%aiId, disclauncher, 0);
	Player::setItemCount(%aiId, chaingun, 0);
	Player::setItemCount(%aiId, discammo, 0);
	Player::setItemCount(%aiId, bulletAmmo, 0);

	AI::SetVar(%aiName, triggerPct, 0.03 );
	AI::setVar(%aiName, attackMode, 1);
	AI::setAutomaticTargets( %aiName );
	AI::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);

//=========================================================== If Mission Type Death Match, Set Basics And Return

   if(Game::missionType == "DM")
   {	
        Player::setItemCount(%aiId, blaster, 1);
		Player::mountItem(%aiId, blaster, 0);
	    return;
   }
//=========================================================== Guard Bot Set Up
	if(String::findSubStr(%aiName, "Guard") >= 0)
	{
	    AI::setVar(%aiName, iq, 90 );
	   	   for(%i = 0; $Spoonbot::GuardGear[%i] != ""; %i++)
		   {
	 	        Player::setItemCount(%aiId, $Spoonbot::GuardGear[%i], $SpoonBot::GuardAmmo[%i]);
		   }
		   Player::mountItem(%aiId, $SpoonBot::GuardLong, 0);
	}
	
//=========================================================== Demo Bot Setup
	else if(String::findSubStr(%aiName, "Demo") >= 0)
	{
	   		for(%i = 0; $Spoonbot::DemoGear[%i] != ""; %i++)
			{
	 	        Player::setItemCount(%aiId, $Spoonbot::DemoGear[%i], $SpoonBot::DemoAmmo[%i]);
	        }
			Player::mountItem(%aiId, $SpoonBot::DemoLong, 0);
	}
//=========================================================== Painter Bot Setup
	else if(String::findSubStr(%aiName, "Painter") >= 0)
	{
	    AI::setVar(%aiName, iq, 200 );
   		for(%i = 0; $Spoonbot::PainterGear[%i] != ""; %i++)
 	       Player::setItemCount(%aiId, $Spoonbot::PainterGear[%i], $SpoonBot::PainterAmmo[%i]);
        Player::mountItem(%aiId, $SpoonBot::PainterLong, 0);
	
	    AI::SetVar(%aiName, spotDist, 1000);
	    AI::SetVar(%aiName, seekOff , 1);   // Dunno what this does. Werewolf
	}
//=========================================================== Sniper Bot Setup	
	else if(String::findSubStr(%aiName, "Sniper") >= 0)
	{
	   AI::setVar(%aiName, iq, 80 );
	   	   for(%i = 0; $Spoonbot::SniperGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::SniperGear[%i], $SpoonBot::SniperAmmo[%i]);
		   Player::mountItem(%aiId, $SpoonBot::SniperLong, 0);
		   
	       AI::SetVar(%aiName, spotDist, 1000);		// Make 20-20 vision for snipers ;-) Werewolf
	}
//=========================================================== Medic Bot Setup
	else if(String::findSubStr(%aiName, "Medic") >= 0)
	{
	   AI::setVar(%aiName, iq, 70 );
	   	  for(%i = 0; $Spoonbot::MedicGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::MedicGear[%i], $SpoonBot::MedicAmmo[%i]);
	      Player::mountItem(%aiId, $SpoonBot::MedicLong, 0);
	}
//=========================================================== Miner Bot Setup
	else if(String::findSubStr(%aiName, "Miner") >= 0)
	{
	   	   AI::setVar(%aiName, iq, 70 );
	   	   for(%i = 0; $Spoonbot::MinerGear[%i] != ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::MinerGear[%i], $SpoonBot::MinerAmmo[%i]);
	       Player::mountItem(%aiId, $SpoonBot::MinerLong, 0);
	}
//=========================================================== Standard Setup	
	else 
	{
	   	   AI::setVar(%aiName, iq, 50 );
	
	   	   for(%i = 0; %i = ""; %i++)
	 	       Player::setItemCount(%aiId, $Spoonbot::StandardGear[%i], $SpoonBot::StandardAmmo[%i]);
	       Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);
	}
}


//=========================================================================================================================================
//															 AI::periodicWeaponChange()
//=========================================================================================================================================
//modified by Werewolf

function ai::periodicWeaponChange(%aiName)
{
    %aiId = AI::getId(%aiName);

    BotFuncs::checkForPaint(%aiName);
    BotFuncs::checkForFlagrunner(%aiName);
    BotFuncs::checkObstacle(%aiId);  //Check if we're stuck somwhere
    BotFuncs::RepairTask(%aiName);

    %curTarget = ai::getTarget( %aiName );
   
    if(%curTarget == -1)
    {
    	return;
    }
    
    %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
    %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
    %targetDist = Vector::getDistance(%aiLoc, %targLoc);

	
	//============================================================================ Guard Weapons
	if(String::findSubStr(%aiName, "Guard") >= 0)
	{
		   if(%targetDist > 50)
		   {
		
		      if(Player::isJetting(%curTarget))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::GuardJet, 0);
		         AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
				Player::mountItem(%aiId, $SpoonBot::GuardLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::GuardShort, 0);  
		         AI::SetVar(%aiName, triggerPct, 1 );
		   }
	}
	
	//============================================================================ Demo Weapons
	else if(String::findSubStr(%aiName, "Demo") >= 0)
	{
		   if(%targetDist > 100)
		   {
		
		      if(Player::isJetting(%curTarget))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::DemoJet, 0);
		         AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
				Player::mountItem(%aiId, $SpoonBot::DemoLong, 0);
				AI::SetVar(%aiName, triggerPct, 0.5 );
		      }   
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::DemoShort, 0);  
		         AI::SetVar(%aiName, triggerPct, 1 );
		   }
	}
	
	//============================================================================ Painter Weapons
	else if(String::findSubStr(%aiName, "Painter") >= 0)
	{
		   if(%targetDist > 20)
		   {
		
		      if(Player::isJetting(%curTarget))
		      {	
		         Player::mountItem(%aiId, $SpoonBot::PainterJet, 0);
		         AI::SetVar(%aiName, triggerPct, 100 );
		      }
		      else
		      {
				 Player::mountItem(%aiId, $SpoonBot::PainterLong, 0);
				 AI::SetVar(%aiName, triggerPct, 100 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::PainterShort, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.6 );
		   }
	}
	
	//============================================================================ Sniper Weapons
	else if(String::findSubStr(%aiName, "Sniper") >= 0)
	{
		   Player::setDetectParameters(%aiId, 0.0001, 0.00001);
	
		   if(%targetDist > 50)
		   {
	
		      if(Player::isJetting(%curTarget))
		      {	
			        Player::mountItem(%aiId, $SpoonBot::SniperJet, 0);
			        AI::SetVar(%aiName, triggerPct, 0.005 );
		      }
		      else
		      {
					Player::mountItem(%aiId, $SpoonBot::SniperLong, 0);
					AI::SetVar(%aiName, triggerPct, 0.005 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::SniperShort, 0);  
		         AI::SetVar(%aiName, triggerPct, 1 );
		   }
	}
	
	//============================================================================ Miner Weapons
	else if(String::findSubStr(%aiName, "Miner") >= 0)
	{
		   if(%targetDist > 100)
		   {
		
		      if(Player::isJetting(%curTarget))
		      {	
		        	Player::mountItem(%aiId, $SpoonBot::MinerJet, 0);
		        	AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
		        	Player::mountItem(%aiId, $SpoonBot::MinerLong, 0);  
		        	AI::SetVar(%aiName, triggerPct, 0.03 );
		      }   
		
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::MinerClose, 0);  
		         AI::SetVar(%aiName, triggerPct, 0.03 );
		   }
	}
	
	//============================================================================ Set Medic Weapons
	else if(String::findSubStr(%aiName, "Medic") >= 0)
	{
		   if(%targetDist > 20)
		   {
		      if(Player::isJetting(%curTarget))
		      {	
		         	Player::mountItem(%aiId, $SpoonBot::MedicJet, 0);
		         	AI::SetVar(%aiName, triggerPct, 0.6 );
		      }
		      else
		      {
		         	Player::mountItem(%aiId, $SpoonBot::MedicLong, 0);  
		         	AI::SetVar(%aiName, triggerPct, 0.03 );
		      }   
		   }   
		   else
		   {
		         Player::mountItem(%aiId, $SpoonBot::MedicShort, 0);
		         Player::useItem(%aiId, repairkit, 0);
		   }
	}
	
	
	
	//============================================================================ Set Standard Weapons If Bot Is Not Any Of The Presets
	else 
	{	
	    if(%targetDist > 100)
	    {
	    	 Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);
	     	 AI::SetVar(%aiName, triggerPct, 0.03 );
	    }   
	    else
	    {
	       if(Player::isJetting(%curTarget))
	       {	
	          Player::mountItem(%aiId, $SpoonBot::StandardJet, 0);
	          AI::SetVar(%aiName, triggerPct, 0.6 );
	       }
	       else
	       {
	          Player::mountItem(%aiId, $SpoonBot::StandardLong, 0);  
	          AI::SetVar(%aiName, triggerPct, 0.03 );
	       }   
	    }
	}
}
//============================================================================================================== End Of Bot Setup Functions
