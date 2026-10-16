echo ("Executing A.S.S.");

function Scoring::Object(%this)
{
	if ($Shifter::ObjScore == "False"){if ($debug) echo ("Scoring Is Off (Object Destoryed)");return;}

	%destroyerTeam = %this.lastDamageTeam;						//=== Team who destroyed Object.
	%thisTeam = GameBase::getTeam(%this); 						//=== Team whos object belongs.

	if (%this.lastDamageObject < 4000)
	{
		%playerClient = %this.lastDamageObject;  				//=== Player Who Did The Damage.
	}
	else if (%this.lastDamageObject > 4000)
	{
		%playerClient = GameBase::getOwnerClient(%this.lastDamageObject);	//=== Player Who Did The Damage.
	}

	$lastdamageobj[%this] = GameBase::getControlClient(%this.lastDamageObject);

	if(%playerClient != -1 || !%playerClient)					//=== Get The Players Name Who Killed.
		%clientName = Client::getName(%playerClient);

	%objtype = getObjectType(%this);
	%objname = (GameBase::getDataName(%this)).description;

	if ($debug) echo ("Object Detroyed = " @ %objname);

	if (%thisTeam == -1) //=== Doesnt Matter - Not A Team Item
		return;

	//============================================================================= Generators
	if (%objname == "Generator")				%pntval = $Score::ObjGeneratorB;
	else if (%objname == "Solar Panel")			%pntval = $Score::ObjGeneratorS;
	else if (%objname == "Portable Generator")		%pntval = $Score::ObjGeneratorS;
	else if (%objname == "Blast Door")		        %pntval = $Score::ObjGeneratorS;	
	//============================================================================= Turrets
	else if (%objname == "Remote Mortar Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Ion Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Plasma Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Laser Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Point Defense Laser Mine")	%pntval = $Score::ObjTurretS;
	else if (%objname == "Mitzi Blast Turret")			%pntval = $Score::ObjTurretS;
	else if (%objname == "1Satchel Charge")			%pntval = $Score::ObjTurretS;
	else if (%objname == "Deployable Elf Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "PBW Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "EMP Blast Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Chaingun Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Tractor Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Velcro Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Laser Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "HP Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "AF Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Seeking-Disc Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Seeking-Plasma Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Fusion Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Mini-Laser Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Defender Turret")		%pntval = $Score::ObjTurretS;

	
	//============================================================================= Sensor Damage
	else if (%objname == "Large Pulse Sensor")		%pntval = $Score::ObjSensorL;
	else if (%objname == "Medium Pulse Sensor")		%pntval = $Score::ObjSensorL;
	else if (%objname == "Motion Sensor")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Pulse Sensor")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Remote Sensor Jammer")		%pntval = $Score::ObjSensorS;
	else if (%objname == "Arbitor Beacon")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Shield Beacon")			%pntval = $Score::ObjSensorS;
	else if (%objname == "EMP Beacon")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Jammer Beacon")			%pntval = $Score::ObjSensorS;
	//============================================================================= Powered Items
	else if (%objname == "Plasma Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "ELF Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "Rocket Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "Mortar Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "Indoor Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else
	{
		return 0;
	}

	%pntval = %pntval + 1; //=== Minimum Points for destoying something.
	%kpos = gamebase::getposition(%playerClient);
	%dpos = gamebase::getposition(%this); 

	if (%dpos != "0 0 0" || %kpos != "0 0 0")
		%killdist = Vector::getDistance(%dpos,%kpos);
	else
		%killdist = "10";

	if (%killdist > 1200)
	{
		%pntval = (%pntval + ($Score::Kill800Plus * 2));
		if($debug) echo ("*** Plus " @ $Score::Kill800Plus);
		if($debug) echo ("*** Range Bonus Points");				
	}	
	else if (%killdist > 800 && %killdist <= 1200)
	{
		%pntval = (%pntval + ($Score::Kill800Plus + $Score::Kill250Meters));
		if($debug) echo ("*** Plus " @ $Score::Kill800Plus);
		if($debug) echo ("*** Range Bonus Points");				
	}				
	else if (%killdist > 500 && %killdist <= 800)
	{
		%pntval = (%pntval + $Score::Kill800Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill800Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist > 250 && %killdist <= 500)
	{
		%pntval = (%pntval + $Score::Kill500Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill500Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist > 100 && %killdist <= 250)
	{
		%pntval = (%pntval + $Score::Kill250Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill250Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist > 50 && %killdist <= 100)
	{
		%pntval = (%pntval + $Score::Kill100Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill100Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}				
	else if (%killdist > 15 && %killdist <= 50)
	{
		%pntval = (%pntval + $Score::Kill50Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill50Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist <= 15)
	{
		%pntval = (%pntval + $Score::Kill15Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill15Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	if (%playerClient.missilekill)
	{
		%pntval = floor(%pntval * 0.25);
	}

	//====================================================================== End Of Point Values
	%item = Player::getMountedItem(%playerClient,$WeaponSlot);
	return %pntval;
}


function Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant)
{


	//==================================================================================================================== Advanced Scoring
	//== See also in the objectives.cs file for the print out of stats... Currently Stats are printed for all players... 
	//==================================================================================================================== Advanced Scoring

	%score = 0;						//== Reset Scoring
	%killerteam = Client::getTeam(%killerId);		//== Killers Team
	%diedteam = Client::getTeam(%playerId);			//== Died Team
	%killedpos = %playerId.lastkillpos;			//== Killed Pos
	%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
	%killerarmor = Player::getArmor(%killerId);		//== Killers Armor
	%diedarmor = $killedarmor;				//== Died Armor
	%flagpos = ($teamFlag[%killerteam]).originalPosition;	//== Flags Home Pos
	%flagdist = Vector::getDistance(%killedpos,%flagpos);	//== Distance from Killed Player To Enemy
	%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag

	$killedflagcarry = "False";

	%playerId.lastkillpos = -1; //== Reset
	$killedarmor = -1; //== Reset

	//============================================================================================================== Flag Runner Killed Bonus

	if (%killedflag)
	{
		%score = (%score + $Score::FlagKill);
	}

	if (%killerarmor == "larmor") 		  %kval = 1; //== Assassin Armor
	else if (%killerarmor == "lfemale")	  %kval = 1; //== Assassin Armor 
	else if (%killerarmor == "marmor")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "mfemale")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "harmor")	  %kval = 4; //== Heavy 
	else if (%killerarmor == "parmor")        %kval = 0; //== Penis Curse Armor
	else if (%diedarmor == "dmarmor")	 %dval = 2; //== Death Match
	else if (%diedarmor == "dmfemale")	 %dval = 2; //== Death Match
	

	if (%diedarmor == "larmor") 		 %dval = 1; //== Assassin Armor
	else if (%diedarmor == "lfemale")	 %dval = 1; //== Assassin Armor 
	else if (%diedarmor == "marmor")         %dval = 2; //== Medium 
	else if (%diedarmor == "mfemale")	 %dval = 2; //== Medium 
	else if (%diedarmor == "harmor")	 %dval = 4; //== Heavy 
	else if (%diedarmor == "dmarmor")	 %dval = 2; //== Death Match
	else if (%diedarmor == "dmfemale")	 %dval = 2; //== Death Match
	else if (%diedarmor == "parmor")  	 %dval = 0; //== Penis Curse Armor
	
	//=============================================================== Base-Flag Defence Scoring

	if (%flagdist <= 25)
	{
		%score = (%score + $Score::25Meters);
	}
	else if ((%flagdist > 25) && (%flagdist <= 75))
	{
		%score = (%score + $Score::75Meters);
	}
	else if ((%flagdist > 75) && (%flagdist <= 150))
	{
		%score = (%score + $Score::150Meters);
	}
	else if ((%flagdist > 150) && (%flagdist <= 250))
	{
		%score = (%score + $Score::250Meters);
	}
	else
	{
		%score = (%score + 1);
	}

	//=============================================================== Armor Kill Armor Bonuses
	if (%kval < %dval) 
	{
		%armordiff = (%dval - %kval);
		if($debug) echo ("    Kill Armor Diff   = " @ %armordiff);
		%score = (%score + %armordiff);
	}
	//=============================================================== Kill Range Bonus
		
	if (%killdist >= 800)
	{
		%score = (%score + $Score::Kill800Plus);
			
	}				
	else if (%killdist > 500 && %killdist <= 800)
	{
		%score = (%score + $Score::Kill800Meters);
			
	}
	else if (%killdist > 250 && %killdist <= 500)
	{
		%score = (%score + $Score::Kill500Meters);
			
	}
	else if (%killdist > 100 && %killdist <= 250)
	{
		%score = (%score + $Score::Kill250Meters);
			
	}
	else if (%killdist > 50 && %killdist <= 100)
	{
		%score = (%score + $Score::Kill100Meters);
			
	}				
	else if (%killdist > 15 && %killdist <= 50)
	{
		%score = (%score + $Score::Kill50Meters);
			
	}
	else if (%killdist <= 15)
	{
		%score = (%score + $Score::Kill15Meters);
			
	}	

	if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType) )
	{
		bottomprint(%playerId, "<jc><f1> * * *<f2> H E A D  S H O T <f1>* * *");
		%score = %score + $Shifter::HeadShot;
	}

	if (%playerId.driver)
	{
		%score = %score + 3;
	}
	
	if (%damagetype == $NukeTypeDamage)
	{
		%score = %score / 2;
	}

	%killtime = getsimtime();
	%killlife = (%killtime - %killerId.spawntime) - $Shifter::KillTime;

	if (%killlife > 0)
	{
		%killscore = floor(%killlife / 180);
		%score += %killscore;
	}
	
	if ($debug) echo ("Player Killed SCORE " @ %score);
	return %score;
}
