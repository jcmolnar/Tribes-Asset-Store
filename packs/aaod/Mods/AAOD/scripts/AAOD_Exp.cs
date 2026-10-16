//------------------------------------------------------------------
//							AAOD_EXP.cs File
//	Contains All the AAOD Experience & Experience Related Functions
//------------------------------------------------------------------

$SkillName[$Spd]="Increased Speed";
$SkillName[$Dur]="Durability";
$SkillName[$Flt]="Flight/JetPack";
$SkillName[$Sth]="Stealth/Infiltration";
$SkillName[$Acc]="Accuracy";
$SkillName[$Rgn]="Regeneration";
$SkillName[$Rch]="Faster Energy Recovery";

//***************************************
// Max Levels attainable
//***************************************

$MaxL[$Spd]=2;
$MaxL[$Flt]=2;
$MaxL[$Sth]=2;

//***************************************	
//	Experience Function
//***************************************

	
//------------------------------------------------------
// Returns the Base Class of Armor the Player is Wearing
//    (Eliminates the Need for Multiple ItemMax's)
//------------------------------------------------------
function GetBaseArmor(%player)	
{	%armor=Player::getArmor(%player);
	%arm=String::getSubStr(%armor, 0, 6);
	if (%arm=="lfemal")
			%arm=%arm@"e";
	else if(%arm=="mfemal")
			%arm=%arm@"e";
	return(%arm);
}
//**********************
//	Add Exp to Client
//**********************
function ExpAdd(%client,%exp)
{	if(%client==false||%client==""||%exp<=0)
		return;
	%client.expGain+=%exp;				
	%client.expaqrd+=%exp;				
	if($traceExp) echo( ">EXP: ADD ",%exp," Exp to ",$User[%client],"  EXP : ",%client.expaqrd," TEXP+: ",%client.expGain," TEXP-: ",%client.expLoss);
	if (%client.expaqrd>$MaxExpPts)	%client.expaqrd=$MaxExpPts;
	
	%nextLevel=%client.exlevel+1;

	if(%nextLevel<=$MaxExpLvl)						// If Player is NOT Max Level
	{	if ($Level[%nextLevel]<=%client.expaqrd)	// Check to see if He has gone up a level
		{	%client.exLevel++;						// Increase Players Level
			if($TraceExp) echo(">EXP: ",$User[%client]," IS Level ",%NewLevel);
			centerPrint(%client,"***** Congratulations !!! *****\n You are Now a Level "@%client.exlevel@" player.\nHit TAB & #3 to pick your Special skill",5);
			Client::sendMessage(%client, 0,"~wflagcapture.wav");
		}
		
	}
}
//**********************
//	Add Exp to Team
//**********************
function TExpAdd(%team,%exp)
{	if(%team==false||%team==""||%exp<=0) return;
	if($traceExp) echo(">EXP: ADD ",%exp," to Team ",%team," - ",$Server::teamName[%team]);
	$TeamExp[%team]+=%exp;
}

//**************************
//	Subtract Exp from Client
//**************************
function ExpSub(%client,%exp)
{	if(%client==false||%client==""||%exp<=0)
		return;
	%client.expaqrd-=%exp;
	%client.expLoss+=%exp;
	if (%client.expaqrd<0) 
		%client.expaqrd=0;
	
	if($traceExp) echo(">EXP: SUB ",%exp," Exp from ",$User[%client],"  EXP : ",%client.expaqrd," TEXP+: ",%client.expGain," TEXP-: ",%client.expLoss);
	
	if(%client.expaqrd<$Level[%client.exlevel])	// Client has LOST a Skill Level
	{	for (%i=%client.exLevel;%i>=0;%i--)		// Start at the level he/she was and check down from there
		{	//echo("Checking Level ",%i," Needed ",$Level[%i]," Has ",%client.expaqrd);
			if ($Level[%i]<=%client.expaqrd)	// If The exp required for this level is less that the amount of exp player has
			{	%client.exlevel=%i;
				if($TraceExp) echo(">EXP:",$User[%client]," is Now Level: ",%client.exlevel);
				if(%client.ExpUsed>%client.exLevel) %client.ExpUsed=%i;
				%i=0;
			}
			else
			{	%Skill=%client.skill[%i];
				if(%client.Skill[%i]>0)	// If Player has a Selected Skill for that Level
				{	%NameofSkill=$SkillName[%client.Skill[%i]];
					%client.talent[%client.Skill[%i]]--;
					if (%client.talent[%Skill]<0) %client.talent[%Skill]=0;
					if($traceexp) echo( ">EXP: ",$User[%client]," Has lost a level of ",$SkillName[%client.Skill[%i]]);
					%client.skill[%levela]=0;
					%Msg="\nYou have lost your"@%NameofSkill@" Skill";	
				}

			}
		}
		centerPrint(%client,"<jc>You are now a Level "@%client.exlevel@" player !!!"@%Msg ,5);	
		Client::sendMessage(%client,0,"~wError_Message.wav");
		if (%client.exlevel<%client.expused) %client.expused=%client.exlevel;
	}
	
}

//**************************
//	Subtract Exp from Client
//**************************
function TExpSub(%team,%exp)
{	if(%team==false||%team==""||%exp<=0) return;
	if($traceExp) echo(">EXP: SUB ",%exp," from Team ",%team," - ",$Server::teamName[%team]);
	$TeamExp[%team]-=%exp;
}

function ExpCalc(%WTeam,%LTeam,%exp)
{	%numPlayers = getNumClients();
	if(%numPlayers==1)
		if($TestStuff)
			return(%exp*3);
		else
			return(0);

	else if((%WTeam==%LTeam) || %WTeam==-1 || %LTeam==-1)	// If Unknown Team or Same Team
		return (%exp);
	
	if(%WTeam=="" || %LTeam=="")
	{	if(%LTeam=="")
		{	if($trace) echo($Ver,"| Lose Team Undefined");
			if(%WTeam==1) %LTeam=0;
			if(%WTeam==0) %LTeam=1;
		}
		else
		{	if($trace) echo($Ver,"| Win Team Undefined");
			if(%LTeam==1) %WTeam=0;
			if(%LTeam==0) %WTeam=1;
		}
	}
	
	for(%i = 0; %i < 2; %i = %i + 1)
	{	%numTeamPlayers[%i] = 0;
		for(%i = 0; %i < %numPlayers; %i++)
		{	%pl = getClientByIndex(%i);
			%team = Client::getTeam(%pl);
	        %numTeamPlayers[%team]++;
		}
	}
	
	if((%numTeamPlayers[%WTeam]==0 ||%numTeamPlayers[%LTeam]==0)) 
		if($TestStuff)
			return(%exp*3);
		else
			return(0);

	%fac=%numTeamPlayers[%LTeam]/%numTeamPlayers[%WTeam];
	if($traceexp) echo( ">EXP: ExpCalc (Win|Lose|Exp) (",%WTeam,"|",%LTeam,"|",%exp,") #P's= ",%numPLayers," Ratio",%numTeamPlayers[%LTeam],":",%numTeamPlayers[%WTeam]," % = ",%fac," Exp Pts =",%exp*%fac);
	return(%exp*%fac);
}
     
function GetPts(%client)
{	%Levelb=%client.exlevel-%client.expused;
	return(%Levelb);
}

function GetTAwardPts(%killed,%team)	// A Turret or something else deployed or owned by Team has killed an opponent
{	%b=(%Killed.exlevel+1)*$ExpTeamFactor;
	%lteam = Client::getTeam(%Killed);
	return(ExpCalc(%team,%lteam,%b));
}

function GetTPenaltyPts(%killed,%team)	// You Have been killed by a turret or mine or something
{	%b=(%Killed.exlevel+1);
	%pts=%b*$ExpDeathLoss;
	%lteam = Client::getTeam(%killed);
	return(ExpCalc(%team,%lteam,%pts));
}

function GetAwardPts(%Killed,%Killer)
{	%a=%Killer.exlevel+1;
	%b=%Killed.exlevel+1;
	%pts=(%b/%a)*$ExpKill[Player]*%Killed.bounty;
	%lteam = Client::getTeam(%Killed);
	%wteam = Client::getTeam(%Killer);
	%ret=ExpCalc(%wteam,%lteam,%pts);
	return (%ret);
}

function GetPenaltyPts(%Killed,%Killer)
{	%a=%Killer.exlevel+1;
	%b=%Killed.exlevel+1;
	%pts=(%b/%a)*$ExpDeathLoss*%Killed.bounty;
	%lteam = Client::getTeam(%Killed);
	%wteam = Client::getTeam(%Killer);
	%ret=ExpCalc(%wteam,%lteam,%pts);
	return (%ret);
}

function CheckArmor(%client,%armor)
{	%arm=String::getSubStr(%armor, 0, 6);
	if (%arm=="lfemal")
			%arm=%arm@"e";
	else if(%arm=="mfemal")
			%arm=%arm@"e";
	if((%client.talent[$Spd]>0) || (%client.talent[$Flt]>0))	// If Has Speed or Flight 
	{	%arm = %arm@%client.talent[$Spd]@%client.talent[$Flt];
		if ($trace) echo("Check Armor : Player ",%client," has ",%arm);
	}
	return(%arm);
}

function CheckStealth(%client)
{	%player=Client::getOwnedObject(%client);
	if(%client.talent[$Sth]>0)
	{	if(%client.talent[$Sth]==1)
			%rate=4;
		if(%client.talent[$Sth]==2)
			%rate=15;
		if($trace) echo( $ver@"|Stealth Skill for ",$User[%client]," is active ",%rate);
		Player::setSensorSupression(%player,%rate);
	}
}


function UpdateSkills(%client)
{	if($trace) echo( "Client ",$User[%client]," Updating Skills");
	%armor = Player::getArmor(%client);
	%armor=CheckArmor(%client,%armor);
	Player::setArmor(%client,%armor);
	CheckStealth(%client);
	CheckRegen(%client);
	CheckRecharge(%client);
}

function ShowExp(%client)
{	%NumPts=GetPts(%client);
	if($traceexp) echo(">REQ: ",$User[%client]," Checking EXP Exp: ",%client.expaqrd," Lvl: ",%client.exlvl," Avail SK Pts: ",%NumPts);
	if(%NumPts>0)
	{	%line[5]="** You Have "@%NumPts@" UNUSED Skill Points!! **\n";	
		%Numlines=5;
	}
	else
		%Numlines=4;
	%line[1]="You Have "@%client.expaqrd@" Experience pts";
	%line[2]="Your Current Level is "@%client.exlevel@"";
	%line[3]="You Have used "@%client.expused@" Skills";
	%line[4]="Your Skills Are: ";
	if(%client.talent[$Spd])
		%line[4]=%line[4]@" ( SPEED Lvl "@%client.talent[$Spd]@" )";
	if(%client.talent[$Dur])
		%line[4]=%line[4]@" ( Durability Lvl "@%client.talent[$Dur]@" )";
	if(%client.talent[$Flt])
		%line[4]=%line[4]@" ( FLIGHT Lvl "@%client.talent[$Flt]@" )";
	if(%client.talent[$Acc])
		%line[4]=%line[4]@" ( Accuracy Lvl "@%client.talent[$Acc]@" )";
	if(%client.talent[$Sth])
		%line[4]=%line[4]@" ( STEALTH Lvl "@%client.talent[$Sth]@")";
	if(%client.talent[$Rgn])
		%line[4]=%line[4]@" ( Regeneration Lvl "@%client.talent[$Rgn]@" )";
	if(%client.talent[$Rch])
		%line[4]=%line[4]@" ( Energy Recovery Lvl "@%client.talent[$Rch]@" )";

	
	if(%Numlines)
	{	%messaage="";
		for(%i;%i<=%NumLines;%i++)
		{	%message=%message @ %line[%i] @"\n";}
		BottomPrint(%client,%message,5);
		Client::sendMessage(%client,0,"~wC_BuySell.wav");
	}
}

function Player::onAdd(%this)
{	GameBase::setRechargeRate(%this,8);
}

function CheckRecharge(%client)
{	if(%client.inStasis==true) return;
	%rate=$Recharge[%client.talent[$Rch]];
	%player=Client::getOwnedObject(%client);
	GameBase::setRechargeRate(%player,%rate);
	if($trace) echo( $ver@"|Check Recharge Rate for : ",$User[%client],". Rate is ",%rate," Recharge Skill is ",%client.talent[$Rch]);
}

function startRegen(%client)
{	if (%client.isRegenerating==false)
	{	if($trace) echo("Regeneration Started for ",$User[%client]);
		%client.isRegenerating=true;
		CheckRegen(%client);
	}
	else
	{
		if($trace) echo( $User[%client],"is already regenerating");
	}
}

function CheckRegen(%client)
{	%player=Client::getOwnedObject(%client);
	%damage=GameBase::getDamageLevel(%player);
	
	if(%damage>0)
	{	%client.cycle++;
		%lvl=%client.talent[$Rgn];
		if(%lvl==0)
			return;
		%regen=$Regen[%lvl];
		GameBase::repairDamage(%player,%regen);
		schedule("CheckRegen("@%client@");",2,%player);
		%client.cycle--;
	}
	else
		%client.isRegenerating=false;
	
	if($tracedam) echo( $ver@"|Regeneration of ",$User[%client]," Recover Level :",%player.talent[$Rgn], "Damage Level is ",%damage);
		
}

function ShowAdminExp(%admin,%client)
{	%name=Client::getName(%client);
	%NumPts=GetPts(%client);
	if($traceexp) echo(">REQ: Admin Checking EXP for :",$User[%client]," Exp: ",%client.expaqrd," Lvl: ",%client.exlvl," Avail SK Pts: ",%NumPts);
	if(%NumPts>0)
	{	%line[5]="<jc>** "@%name@" has "@%NumPts@" UNUSED Skill Points!! **";	
		%Numlines=5;
	}
	else
		%Numlines=4;
	%line[1]=%name@" Has "@%client.expaqrd@" Experience pts";
	%line[2]=%name@" is Currently Level "@%client.exlevel@"";
	%line[3]=%name@" Has used "@%client.expused@" Skills";
	%line[4]=%name@" has the following Skills:";
	if(%client.talent[$Spd])
		%line[4]=%line[4]@" ( SPEED Lvl "@%client.talent[$Spd]@" )";
	if(%client.talent[$Dur])
		%line[4]=%line[4]@" ( Durability Lvl "@%client.talent[$Dur]@" )";
	if(%client.talent[$Flt])
		%line[4]=%line[4]@" ( FLIGHT Lvl "@%client.talent[$Flt]@" )";
	if(%client.talent[$Acc])
		%line[4]=%line[4]@" ( Accuracy Lvl "@%client.talent[$Acc]@" )";
	if(%client.talent[$Sth])
		%line[4]=%line[4]@" ( STEALTH Lvl "@%client.talent[$Sth]@")";
	if(%client.talent[$Rgn])
		%line[4]=%line[4]@" ( Regeneration Lvl "@%client.talent[$Rgn]@" )";
	if(%client.talent[$Rch])
		%line[4]=%line[4]@" ( Energy Recovery Lvl "@%client.talent[$Rch]@" )";

	
	if(%Numlines)
	{	%messaage="";
		for(%i;%i<=%NumLines;%i++)
		{	%message=%message @ %line[%i] @"\n";}
		BottomPrint(%admin,%message,5);
		Client::sendMessage(%admin,0,"~wC_BuySell.wav");
	}
}

function AAOD_unused_len(%string)	// PORT: was String::len -- an engine command in 1.50 (same result)
{	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;
	return %length;
}
function DisperseTeamExp(%team)
{	if($traceexp) echo("Dispersing Team Experience for Team ",%team);
	%numPlayers = getNumClients();
	if(ABS($TeamExp[%team])>=%numPlayers)				
	{	%NumT=0;		
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{	%id = getClientByIndex(%i);
			if(Client::getTeam(%id) == %team)
				%NumT++;	
		}
		if($traceexp) echo("Team EXP pts are ",$TeamExp[%team]," allocating to ",%NumT," players");
		if(%NumT!=0)
		{	%expB=$TeamExp[%team]/%NumT;
			for(%i = 0; %i < %numPlayers; %i = %i + 1)
			{	%id = getClientByIndex(%i);
				if(Client::getTeam(%id) == %team)
				if(%expB<0)
					ExpSub(%id,ABS(%expB));
				else
					ExpAdd(%id,%expB);
			}
		}
		$TeamExp[%team]=0;	// Dont forget to reset the Pool
	}
	schedule ("DisperseTeamExp("@%team@");",$CheckExpTime);
}

function processMenuGetSkill(%clientId,%skill)
{	if($traceexp) echo( $User[%clientId]," Earned a Skill! Chose: ",$SkillName[%skill]," Skill");
if(GetPts(%clientId) <= 0 || $SkillName[%skill] == "") return;	// PORT: the menu is only offered with points to spend; the handler did not check
	%clientId.expused++;
	%clientId.skill[%clientId.expused]=%skill;
	
	%clientId.talent[%skill]++;
	if(%clientId.talent[%skill]>$MaxL[%skill])
			%clientId.talent[%skill]=$MaxL[%skill];
	UpdateSkills(%clientId);
}

function processMenuFGetSkill(%clientId,%skill)
{	if($trace) echo( "ADMIN Gave Skill ",$SkillName[%skill]," to ",$User[$GiveSkillto]);
if(!%clientId.isSuperAdmin || $SkillName[%skill] == "") return;	// PORT: admin handler had no admin test; unknown skill codes dropped
	if($GiveSkillto)
	{	$GiveSkillto.talent[%skill]++;
		if($GiveSkillto.talent[%skill]>$MaxL[%skill])
			$GiveSkillto.talent[%skill]=$MaxL[%skill];
		%name=$SkillName[%skill];
		Client::sendMessage($GiveSkillto, 0, "Admin Gave you a Special Skill \n Skill= "@%Name);
		UpdateSkills($GiveSkillto);
	}
}

//********************** AAOD 
function SkillsMenu(%cl)
{	if (!%cl.talent[$Spd])
		Client::addMenuItem(%clientId, "0Increased Speed", 1);
	%DLvl=%cl.talent[$Dur]+1;
	Client::addMenuItem(%clientId, "1Increased Durability Lvl "@%DLvl, 2);
	if (!%cl.talent[$Flt])
		Client::addMenuItem(%clientId, "2Flight", 3);
	if (!%cl.talent[$Sth])
		Client::addMenuItem(%clientId, "3Stealth Ability", 4);
	%ALvl=%cl.talent[$Acc]+1;
	Client::addMenuItem(%clientId, "4Increased Accuracy Lvl "%%ALvl, 5);
	%RLvl=%cl.talent[$Rgn]+1;
	Client::addMenuItem(%clientId, "5Regeneration Lvl"@%RLvl, 6);
}

function ResetPlayer(%clientId)
{	// Player Has Spawned a New PLayer Object... 
	// Make sure it inherits all the Special Abilities
	%clientId.inStasis		= false;
	CheckStealth(%clientId);
	CheckRecharge(%clientId);

}

function MakeSkillMenu(%client1,%client2)
{	if($trace) echo("MakeSkillMenu");
	if (%client1.talent[$Spd]<$MaxL[$Spd])
		Client::addMenuItem(%client2, "0Increased Speed Lvl"@(%client1.talent[$Spd]+1), 1);
	if(%client1.talent[$Dur]<$MaxL[$Dur])
		Client::addMenuItem(%client2, "1Increased Durability Lvl "@(%client1.talent[$Dur]+1), 2);
	if (%client1.talent[$Flt]<$MaxL[$Flt])
		Client::addMenuItem(%client2, "2Flight Lvl "@(%client1.talent[$Flt]+1), 3);
	if (%client1.talent[$Sth]<$MaxL[$Sth])
	{	if(%client1.talent[$Sth]==1)
			Client::addMenuItem(%client2, "3Stealth/Infiltration Lvl 2", 4);
		else
			Client::addMenuItem(%client2, "3Stealth Ability Lvl 1", 4);
	}
	if(%client1.talent[$Acc]<$MaxL[$Acc])
		Client::addMenuItem(%client2, "4Increased Accuracy Lvl "@(%client1.talent[$Acc]+1), 5);
	if(%client1.talent[$Rgn]<$MaxL[$Rgn])
		Client::addMenuItem(%client2, "5Regeneration Lvl "@(%client1.talent[$Rgn]+1), 6);
	if(%client1.talent[$Rch]<$MaxL[$Rch])
		Client::addMenuItem(%client2, "6Energy Recovery Lvl "@(%client1.talent[$Rch]+1), 7);
	return;
}

function GetEnemyteam(%team)
{	if(%team==1) return(0);
	else if(%team==0) return(1);
	return (false);
}

function StaticShape::objectiveDestroyed(%this)
{	//	test if it's really an objective
   	//	if(!%this.objectiveLine)
	//	return;

	if(!%this.destroyed)	// If this object is NOT already destroyed.. then
	{	%desc  = GameBase::getDataName(%this);
		%name  = GameBase::getMapName(%this);
		%owner = %this.deployedBy;
		%destroyerTeam = %this.lastDamageTeam;
		%thisTeam = GameBase::getTeam(%this);
		%playerClient = GameBase::getControlClient(%this.lastDamageObject);
		
		%ownerName=getTeamName(%destroyerTeam);
		
		if(%name=="")
			%name=getTeamName(%destroyerTeam)@%desc;

		if(%playerClient != -1)
			%clientName = Client::getName(%playerClient);
		
   		if($trace)
		{	%Msg=%clientName@" Destroyed the "@%ownername@" "@%desc;
			if (%owner) %msg=%msg@" Deployed by "@%ownerName;
			echo(%msg);
		}

		%class=%desc.className;
		%baseExp1=$ExpKill[%class];
		%baseExp2=%baseExp1*%desc.MaxDamage;
		if($traceExp) echo(%class," Kill Base Mod is ",%baseExp1," Max Damage is ",%desc.maxDamage," Base Exp = ",%baseExp2);
		
				
		if(%thisTeam == %destroyerTeam)
   		{	// uh-oh... we killed our own stuff.
   			// award the points to everyone else
   			for(%i = 0; %i < getNumTeams(); %i++)
   			{	if(%i == %thisTeam)
   					continue;
   				$teamScore[%i] += %this.scoreValue;
   			}
			if(%playerClient != -1)
			{	MessageAllExcept(%playerClient, 0, %clientName @ " destroyed your own "@%name@"!!");
      			Client::sendMessage(%playerClient, 0, "You destroyed your own equipment!");
				ExpSub(%playerClient,(%baseExp2*$TKObjPenalty));
				%playerClient.tkObjects++;
				if(%playerClient.tkObjects>=$TKillObjMin)
					TeamKillerCheck(%playerClient);
			}
			MessageAll(1, getTeamName(%destroyerTeam) @ " " @ %name @ " destroyed.");
   		}
   		else
   		{	$teamScore[%destroyerTeam] += %this.scoreValue;
			if(%playerClient != -1)
			{	%playerClient.score+=%baseExp2;
				Game::refreshClientScore(%playerClient);
      			MessageAllExcept(%playerClient, 0, %clientName @ " destroyed the " @ getTeamName(%thisTeam) @ " " @ %name);
      			Client::sendMessage(%playerClient, 0, "You destroyed an objective!");
				%pts=ExpCalc(%destroyerTeam,%thisTeam,%baseExp2);
				ExpAdd(%playerClient,%pts);		// PLayer Get The PTs for the Kill
				TExpSub(%thisteam,%pts);		// Team Takes the Hit for a Loss
			}
			MessageAll(1, getTeamName(%thisTeam) @ " " @ %name @ " has been destroyed.");
   		}
   		%this.destroyerTeam = %destroyerTeam;
   		ObjectiveMission::ObjectiveChanged(%this);
   		ObjectiveMission::checkScoreLimit();
		%this.destroyed = true;
	}
	
}

function TowerSwitch::Exp(%this,%client,%OldTeam,%BaseExp)
{	%pTeam=GameBase::getTeam(%client);
	%pts=ExpCalc(%pTeam,%oldTeam,%BaseExp);
	ExpAdd(%Client,%pts);
	if($TraceExp) echo(">EXP: TOWER SWITCH | ID:",%this," BY: ",$User[%client]," (OldTeam[",%oldTeam,"]|NewTeam[",%NewTeam,"]) EXP:",%Pts);
	if(%OldTeam != -1)													// Was Prev Captured
	{	if($TraceExp) echo("Was Held Buy The Other Team (Held for ",(getSimTime()-%this.switchTime),"Seconds | Limit is ",$ExpObjectiveTime);
		if((getSimTime()-%this.switchTime)<=$ExpObjectiveTime)			// Has Not Been Held Long
			TExpSub(%oldTeam,%pts);										// Penalize Team for Losing it
	}

}

//****************************************************** AAOD Function Tweak **********************
function Client::onKilled(%playerId, %killerId, %damageType)
{	echo($Ver,"|GAME: kill (Killer|player|damagetype)" @ %killerId @ " " @ %playerId @ " " @ %damageType);
	%pteam=Client::getTeam(%playerId);
	%kteam=Client::getTeam(%killerId);

	%playerId.guiLock	= true;
	Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{	%playerGender = "his";}
	else
	{	%playerGender = "her";}

	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);

	if(!%killerId)						// Killed by a Base Turret
	{	if (%pteam==1)
			%kteam=0;
		else if (%pteam==0)
			%kteam=1;
		else
			%kteam=-1;
				
		if(%damageType>21)
		{	%tName=$Server::teamName[%kteam];
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], %tName,%victimName, "their", %playerGender);
		}
		else
			%obitMsg = %victimName@" dies.";
		
		%playerId.scoreDeaths++;
		%aPts=GetTAwardPts(%playerId,%kteam);					// Exp Points to award the victor Team
		%dPts=GetTPenaltyPts(%playerId,%kteam);					// Exp Points to deduct from the loser
		%obitmsg=DisburseExp(%PlayerId,%KillerId,%kTeam,%aPts,%obitmsg);	// Divvy Up the Spoils 
		ExpSub(%playerId,%dpts);								// Reduce the Dead Guys Exp
		messageAll(0, %obitMsg, $DeathMessageMask);
		
	}

	else if(%killerId == %playerId)		// Killed Themselves
	{	%obitMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		%aPts=GetTAwardPts(%playerId,%kteam);					// Exp Points to award the Guys who Damaged this Player Last
		if(%damageType=="")										// Did a control 'K'to avoid losing the EXP
			%dPts=GetTPenaltyPts(%playerId,%kteam)*$ExpSuicide;	// Exp Points to deduct from the player
		else
			%dPts=GetTPenaltyPts(%playerId,%kteam);				// Exp Points to deduct from the player
				
		%obitmsg=DisburseExp(%PlayerId,%KillerId,%kTeam,%aPts,%obitmsg);	// Divvy Up the Spoils 
		ExpSub(%playerId,%dpts);								// Reduce the Dead Guys Exp
		messageAll(0, %obitMsg, $DeathMessageMask);

		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
	}
	else
	{	if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{	%killerGender = "his";}
		else
		{	%killerGender = "her";}
	
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
		{	if(%damageType != $MineDamageType) 
				%obitMsg=strcat(Client::getName(%killerId)," mows down ", %killerGender, " teammate, ", %victimName);
			else 
				%obitMsg=strcat(Client::getName(%killerId)," killed ", %killerGender, " teammate, ", %victimName ," with a mine.");
			messageAll(0, %obitMsg, $DeathMessageMask);

			%killerId.scoreDeaths++;
			ExpSub(%killerId,$TKExpPenalty);
			%killerId.score--;
			%killerId.teamkills++;
			Game::refreshClientScore(%killerId);
			if(%killerId.teamkills>$TeamKillMin)
				TeamKillerCheck(%killerId);
		}
		else
		{	// Standard Death... Killed by Other Team Player
	  		%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
			%aPts=GetAwardPts(%playerId,%killerId);					// AAOD Exp Points to award the victor
			%dPts=GetPenaltyPts(%playerId,%killerId);				// AAOD Exp Points to deduct from the loser
			%obitmsg=DisburseExp(%PlayerId,%KillerId,%kTeam,%aPts,%obitmsg);	// Divvy Up the Spoils 
			ExpSub(%playerId,%dpts);								// Reduce the Dead Guys Exp
			messageAll(0, %obitMsg, $DeathMessageMask);

			%killerId.scoreKills++;
			%KillerId.tKills++;
			%playerId.scoreDeaths++;  // test play mode
			%playerId.tDeaths++;
			%killerId.score++;
			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
   remoteEval(%playerId, "AAODKill","death", %damageType);
   if(%killerId) remoteEval(%killerId, "AAODKill","kill", %damageType);
}

function remoteAAODKill(%KType,%Dtype)
{}

function DisburseExp(%PlayerId,%KillerId,%kTeam,%aPts,%msg)
{	if(%playerId.LastDamBy[2]	!= false)	// More than 1 Player has damaged this Player Recently
	{	ExpAdd(%playerId.LastDamBy[2],(%apts/2));
		ExpAdd(%playerId.LastDamBy[1],(%apts/2));
		if(%playerId==%killerId || !%killerId)
			%msg=%msg@" assisted by "@Client::getName(%PlayerId.LastDamBy[1])@" & "@Client::getName(%PlayerId.LastDamBy[2]);
		else
			%msg=%msg@" assisted by "@Client::getName(%PlayerId.LastDamBy[1]);

	}
	else
	{	if(	%playerId.LastDamBy[1]	!= false)
		{	ExpAdd(%playerId.LastDamBy[1],%apts);
			if(%playerId==%killerId || !%killerId) %msg=%msg@" assisted by "@Client::getName(%PlayerId.LastDamBy[1]);
		}
		else	
			TExpAdd(%kteam,%apts);					// Award Exp to Killers team
	}
	return(%msg);
}

MineData ROverload
{   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Overloaded Repair Pck";
   shapeFile = "armorPack";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 6.0;
	damageValue = 1.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function ROverload::onAdd(%this)
{	echo("ROlverload on Add");
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

//----------------------------------
// Repair Pack EXP Tweaks Etc....
// Ver 1.6C
// Put in to prevent Exp Padding...
//----------------------------------

function RepairBolt::onAcquire(%this, %player, %target)
{	%Tp=Gamebase::getTeam(%player);
	%Tt=GameBase::getTeam(%target);
	%client = Player::getClient(%player);

	if (%Tp!=%Tt && %Tt!=-1)
	{	Client::sendMessage(%client, 0, "REPAIR PACK OVERLOAD!! : This Repair pack is NOT Compatable with this Equipment!!~wError_Message.wav");
		%player.Overloaded=true;
		%Pos=GameBase::getPosition(%player);
		playsound(ForceFieldFeedback,%pos);
		return;
	}

	if (%target == %player) 
	{	%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) 
		{	%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else 
		{	Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{   %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") 
		{	%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		else %player.RDam=GameBase::getDamageLevel(%player.repairTarget);

		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{	if(%player.overloaded==true)
	{	// Drop & Delete Pack....
		if($matchStarted) 
		{	Player::trigger(%player, $WeaponSlot, false);
			%item=Player::getMountedItem(%player,$BackpackSlot);
			%mounted = Player::getMountedItem(%player,$WeaponSlot);
			if (%mounted == RepairGun) 
			{	Player::unmountItem(%player,$WeaponSlot);
			}
			else 
			{	// Remount the existing weapon to make sure the RepairGun
				// is not on the delayed mount "stack".
				Player::mountItem(%player,%mounted,$WeaponSlot);
			}

			Player::decItemCount(%player,%item,1);
			
			// Create a Grenade that looks like a repair pack...
			
			%obj = newObject("","Mine","ROverload");
			addToSet("MissionCleanup", %obj);
			// Drop It.. & Detonate in .2 Second...
			GameBase::throw(%obj,%player,0.5,false);
			%Pts=(%client.ExpAqrd*$ExpPadPenalty);
			ExpSub(%client,%Pts);
		}
		return;
	}

	%object = %player.repairTarget;
	if (%object != -1) 
	{	%client = Player::getClient(%player);
		
		%CDam=%player.RDam-GameBase::getDamageLevel(%object);
		%desc  = GameBase::getDataName(%object);
		%name  = GameBase::getMapName(%object);
		%class=%desc.className;
		%ExpMod1=$ExpKill[%class];
		if(%ExpMod<=0) %ExpMod=1;
		if (GameBase::getDamageLevel(%object) == 0) 
			%ExpPts= %ExpMod*%Cdam*$ExpFullRepair;
		else
			%ExpPts= %ExpMod*%Cdam;

		%Pts=ExpCalc(GameBase::GetTeam(%player),"",%ExpPts);
		if($traceExp) echo(%class," repair! Base Mod is ",%ExpMod1," Repaired ",%CDam," Damage | Exp:",%Pts);
		ExpAdd(%client,%Pts);
		
		%client.repair+=%CDam;
			
		
		if (%object == %player) 
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else 
		{
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
		}
		else 
		{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}	
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if (%object == %player) 
		{	if (GameBase::getDamageLevel(%player) == 0) 
			{	Player::trigger(%player,$WeaponSlot,false);
				%this.destroyed=false;
				return;
			}
		}
		else 
		{	if (GameBase::getDamageLevel(%object) == 0) 
			{	Player::trigger(%player,$WeaponSlot,false);
				%this.destroyed=false;
				return;
			}
		}
	}
}


function SuperRBolt::onAcquire(%this, %player, %target)
{	%Tp=Gamebase::getTeam(%player);
	%Tt=GameBase::getTeam(%target);
	%client = Player::getClient(%player);

	if (%Tp!=%Tt && %Tt!=-1)
	{	Client::sendMessage(%client, 0, "SUPER REPAIR PACK OVERLOAD!! : This Repair pack is NOT Compatable with this Equipment!!~wError_Message.wav");
		%player.Overloaded=true;
		%Pos=GameBase::getPosition(%player);
		playsound(ForceFieldFeedback,%pos);
		return;
	}

	if (%target == %player) 
	{	%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) 
		{	%player.repairRate = 0.1;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else 
		{	Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else 
	{	%player.repairTarget = %target;
		%player.repairRate   = 0.2;
		if (getObjectType(%player.repairTarget) == "Player") 
		{	%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else 
		{	%name = GameBase::getMapName(%target);
			if(%name == "") 
			{	%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{	Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") 
		{	Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SuperRBolt::onRelease(%this, %player)
{	if(%player.overloaded==true)
	{	// Drop & Delete Pack....
		if($matchStarted) 
		{	Player::trigger(%player, $WeaponSlot, false);
			%item=Player::getMountedItem(%player,$BackpackSlot);
			%mounted = Player::getMountedItem(%player,$WeaponSlot);
			if (%mounted == RepairGun) 
			{	Player::unmountItem(%player,$WeaponSlot);
			}
			else 
			{	// Remount the existing weapon to make sure the RepairGun
				// is not on the delayed mount "stack".
				Player::mountItem(%player,%mounted,$WeaponSlot);
			}

			Player::decItemCount(%player,%item,1);
			
			// Create a Grenade that looks like a repair pack...
			
			%obj = newObject("","Mine","ROverload");
			addToSet("MissionCleanup", %obj);
			// Drop It.. & Detonate in .2 Second...
			GameBase::throw(%obj,%player,0.5,false);
			%Pts=(%client.ExpAqrd*$ExpPadPenalty);
			ExpSub(%client,%Pts);
		}
		return;
	}

	%object = %player.repairTarget;
	if (%object != -1) 
	{	%client = Player::getClient(%player);

		%CDam=%player.RDam-GameBase::getDamageLevel(%object);
		%desc  = GameBase::getDataName(%object);
		%name  = GameBase::getMapName(%object);
		%class=%desc.className;
		%ExpMod1=$ExpKill[%class];
		if(%ExpMod<=0) %ExpMod=1;
		if (GameBase::getDamageLevel(%object) == 0) 
			%ExpPts= %ExpMod*%Cdam*$ExpFullRepair;
		else
			%ExpPts= %ExpMod*%Cdam;

		%Pts=ExpCalc(GameBase::GetTeam(%player),"",%ExpPts);
		if($traceExp) echo(%class," repair! Base Mod is ",%ExpMod1," Repaired ",%CDam," Damage | Exp:",%Pts);
		ExpAdd(%client,%Pts);
		%client.repair+=%CDam;
		
		if (%object == %player) 
		{	Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{	if (GameBase::getDamageLevel(%object) == 0) 
			{	Client::sendMessage(%client,0,"Repair Done");
			}
			else 
			{	Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if (%rate < 0)	%rate = 0;
      	GameBase::setAutoRepairRate(%object,%rate);
	}
}

function SuperRBolt::checkDone(%this, %player)
{	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun && %player.repairTarget != -1) 
	{	%object = %player.repairTarget;
		if (%object == %player) 
		{	if (GameBase::getDamageLevel(%player) == 0) 
			{	Player::trigger(%player,$WeaponSlot,false);
				%this.destroyed=false;
				return;
			}
		}
		else 
		{	if (GameBase::getDamageLevel(%object) == 0) 
			{	Player::trigger(%player,$WeaponSlot,false);
				%this.destroyed=false;
				return;
			}
		}
	}
}