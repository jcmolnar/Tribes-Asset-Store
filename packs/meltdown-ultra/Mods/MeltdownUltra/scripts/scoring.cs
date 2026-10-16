// this shifter file has been modified by -Defender


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
    else if (%objname == "Remote Shield Node")			%pntval = $Score::ObjGeneratorS;
    else if (%objname == "Enhancement Beacon")			%pntval = $Score::ObjGeneratorS;
    else if (%objname == "Remote Cloaking Node")			%pntval = $Score::ObjGeneratorS;
    //===========  Meltdown Ultra Stuff Added by - Defender  =================================
    else if (%objname == "The Borg Cube")			%pntval = $Score::ObjGeneratorB;
    else if (%objname == "Mini-Base")			%pntval = $Score::ObjGeneratorB;
    else if (%objname == "Mobile Bunker")			%pntval = $Score::ObjGeneratorB;
    //============================================================================= Full Stations
    else if (%objname == "Ammo Supply Unit")	   	%pntval = $Score::ObjStationA;
	else if (%objname == "Station Supply Unit")		%pntval = $Score::ObjStationS;
	else if (%objname == "Command Station")			%pntval = $Score::ObjStationA;
	//============================================================================= Remote Stations
	else if (%objname == "Remote Ammo Unit")		%pntval = $Score::ObjStationR;
	else if (%objname == "Remote Inv Unit")			%pntval = $Score::ObjStationR;
	else if (%objname == "Mobile Command Stn")		%pntval = $Score::ObjStationR;
	//============================================================================= Flier Pad
	else if (%objname == "Station Vehicle Unit")		%pntval = $Score::ObjFlier;
	else if (%objname == "Vehicle Pad")			%pntval = $Score::ObjFlier;	
	//============================================================================= Turrets
    if (%objname == "Remote Mortar Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Ion Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Plasma Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Laser Turret")		%pntval = $Score::ObjTurretS;
    else if (%objname == "1Satchel Charge")			%pntval = $Score::ObjTurretS;
	else if (%objname == "ELF Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "RMT Mortar Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "RMT Rocket Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Camera")				%pntval = $Score::ObjTurretS;
    //===========  Meltdown Ultra Stuff Added by - Defender  =================================
    if (%objname == "EMP Blast Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Tractor Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Disc Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Laser Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Chaingun Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "ELF Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Mitzi Blast Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "AA Battery")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Plasma Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Missile Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Velcro Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Fusion Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "Chaingun Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "SHB Turret")	%pntval = $Score::ObjTurretS;
    else if (%objname == "PBW Turret")	%pntval = $Score::ObjTurretS;
    //============================================================================= Sensor Damage
	if (%objname == "Large Pulse Sensor")		%pntval = $Score::ObjSensorL;
	else if (%objname == "Medium Pulse Sensor")		%pntval = $Score::ObjSensorL;
	else if (%objname == "Motion Sensor")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Pulse Sensor")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Remote Sensor Jammer")		%pntval = $Score::ObjSensorS;
    else if (%objname == "Jammer Beacon")			%pntval = $Score::ObjSensorS;
    //===========  War2002 Stuff Added by - Defender  =================================
    if (%objname == "Mobile Teleporter Pad")      %pntval = $Score::ObjTurretS;
    else if (%objname == "Backup TelePads")       %pntval = $Score::ObjTurretS;
    else if (%objname == "Mobile Inventory Stn")   %pntval = $Score::ObjTurretS;
    else if (%objname == "5x5 Forcefield")   %pntval = $Score::ObjTurretS;
    else if (%objname == "4x8 Forcefield")     %pntval = $Score::ObjTurretS;
    else if (%objname == "Force Field")     %pntval = $Score::ObjTurretS;
    else if (%objname == "Blast Door")     %pntval = $Score::ObjTurretS;
    else if (%objname == "Blast Floor")      %pntval = $Score::ObjTurretS;
    else if (%objname == "Defender Designator")    %pntval = $Score::ObjTurretS;
    //============================================================================= Powered Items
	if (%objname == "Plasma Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
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

    //====================================================================== End Of Point Values
	%item = Player::getMountedItem(%playerClient,$WeaponSlot);
	return %pntval;
}


function Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant)
{
	if ($Shifter::PlrScore == "False"){if ($debug) echo ("Scoring Is Off (Player Kill)");return;}

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
    else if (%killerarmor == "lfemale")	 %dval = 1; //== LightArmor -female
	else if (%killerarmor == "marmor")     %dval = 2; //== Medium
	else if (%killerarmor == "mfemale")	 %dval = 2; //== Medium Armor -female
    else if (%killerarmor == "harmor")	 %dval = 4; //== Heavy -Assault Armor
    else if (%killerarmor == "carmor")	 %dval = 4; //== Combat Armor
	else if (%killerarmor == "fcarmor")	 %dval = 4; //== Combat Armor -female
    else if (%killerarmor == "darmor")	 %dval = 6; //== Battle Mech


	if (%diedarmor == "larmor") 		 %dval = 1; //== LightArmor
	else if (%diedarmor == "lfemale")	 %dval = 1; //== LightArmor -female
	else if (%diedarmor == "marmor")     %dval = 2; //== Medium
	else if (%diedarmor == "mfemale")	 %dval = 2; //== Medium Armor -female
    else if (%diedarmor == "harmor")	 %dval = 4; //== Heavy -Assault Armor
    else if (%diedarmor == "carmor")	 %dval = 4; //== Combat Armor
	else if (%diedarmor == "fcarmor")	 %dval = 4; //== Combat Armor -female
    else if (%diedarmor == "darmor")	 %dval = 6; //== Battle Mech

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
		
    if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType || %damagetype == $RailgunDamageType || %damagetype == $SniperXDamageType || %damagetype == $PBWDamageType) )
	{
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
