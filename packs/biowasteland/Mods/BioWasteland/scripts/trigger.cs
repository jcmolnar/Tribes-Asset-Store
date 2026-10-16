//----------------------------------------------------------------------------

TriggerData GroupTrigger
{
	className = "Trigger";
	rate = 1.0;
};

function GroupTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
 		%count = Group::objectCount(%group);
 		for (%i = 0; %i < %count; %i++) 
 			GameBase::virtual(Group::getObject(%group,%i),"onTrigEnter",%object,%this);
	}
}	

function GroupTrigger::onLeave(%this,%object)
{

	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		for (%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigLeave",%object,%this);
	}
}

//-----------------------------------------
//GroupTrigger::onContact()
//-----------------------------------------

function GroupTrigger::onContact(%this, %object)

{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle")
	{
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		for (%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigger",%object,%this);
	}
//=== start of water
	if(%this.num == "h2o")
 	{
		%playerArmor = Player::getArmor(%object);
		if (getObjectType(%object) == "Player") %client = Player::getClient(%object);
		else return;
		if (Player::isDead(%object)) return;
		playSound(SoundSpinUpDisc, GameBase::getPosition(%object));
		if (%object.swim > 40) playSound(SoundHFootLSoft, GameBase::getPosition(%object));
		if (%object.swim > 60 && %object.swim < 70) schedule("playSound(SoundHFootLSoft, GameBase::getPosition("@%object@"));", 0.5, %object);
		if (%object.swim > 70 && %object.swim < 95)
		{
			schedule("playSound(SoundHFootLSoft, GameBase::getPosition("@%object@"));", 0.33, %object);
			schedule("playSound(SoundHFootLSoft, GameBase::getPosition("@%object@"));", 0.66, %object);
		}
		if (%object.swim == 127)
		{
			Player::kill(%client);
			MessageAllExcept(%client, 0, Client::getName(%client) @ " has drowned.");
			systemMessage(%client,1,"You've drowned!");
		}
		else if (%object.swim == 90)
		{
Client::SendMessage(%client,1,"*cough*   *UGH*                            O");
			schedule("systemMessage(" @ %client @ ",0,\"~wButton1.wav\");",0.05);
			schedule("systemMessage(" @ %client @ ",0,\"~wButton1.wav\");",0.1);
		}
		else if (%object.swim == 110)
		{
Client::SendMessage(%client,1,"                    *gulp*   *cough*        0");
			schedule("systemMessage(" @ %client @ ",0,\"~wButton2.wav\");",0.05);
			schedule("systemMessage(" @ %client @ ",0,\"~wButton2.wav\");",0.1);
		}
		else if (%object.swim == 116)
		{
Client::SendMessage(%client,1,"    *gulp*    *cough*          *gulp*        o");
			schedule("systemMessage(" @ %client @ ",0,\"~wButton5.wav\");",0.05);
			schedule("systemMessage(" @ %client @ ",0,\"~wButton5.wav\");",0.1);
		}
		else if (%object.swim == 119)
		{
Client::SendMessage(%client,1,"                   *barf*                     .");
			schedule("systemMessage(" @ %client @ ",0,\"~wButton5.wav\");",0.05);
			schedule("systemMessage(" @ %client @ ",0,\"~wButton3.wav\");",0.1);
		}
		else if (%object.swim == 124)
		{
Client::SendMessage(%client,1,"*gulp*                 *gulp*                .");
			schedule("systemMessage(" @ %client @ ",0,\"~wButton5.wav\");",0.05);
			schedule("systemMessage(" @ %client @ ",0,\"~wButton2.wav\");",0.1);
		}
		else if (%object.swim == 70)
		{
			Client::SendMessage(%client,0,"Bubbles force their way out thru your pursed lips...~wbutton_hard.wav");
			schedule("Client::sendMessage(" @ %client @ ",1,\"                        *cough* ~wbutton_hard.wav\");",0.05);
			schedule("systemMessage(" @ %client @ ",0,\"~wbutton_hard.wav\");",0.1);
		}
		else if (%object.swim == 40) Client::SendMessage(%client,0,"Your lungs are burning for oxygen.");
		else if (%object.swim == 0)
		{
			Client::SendMessage(%client,0,"SPLASH!  You hold your breath under-water.");
			playSound(energyExplosion, GameBase::getPosition(%this));
			playSound(bigExplosion1, GameBase::getPosition(%object));
		}
		%object.swim++;
		%num = %object.swim;
		schedule("waterPlayer(" @ %object @ ", " @ %num @ ");",2,%client);
	}
// end of water
}
function waterPlayer(%player, %oldcount)
{
	if(%player.swim > %oldcount  || %player.swim < 10 || %player.repairRate) {}
	else
	{
		%client = Player::getClient(%player);
		%player.swim = "";
		if (Client::getGender(%client) == "Female") Client::SendMessage(%client,0,"Ahh!~wfemale4.wcolor3.wav");
		else Client::SendMessage(%client,0,"Ahh!~wmale2.wcolor3.wav");
	}
}


function GroupTrigger::onActivate(%this)
{
}

function GroupTrigger::onDeactivate(%this)
{
}

TriggerData EnergyTrigger
{
	className = "Trigger";
	rate = 1.0;
};

function EnergyTrigger::onContact(%this, %object)
{
	%client = Player::getClient(%object);
	if(%client.curse) return;
 	%type = getObjectType(%object);
	if (%type == "Flier") %client = gamebase::getcontrolclient(%object);
	%thisTeam = GameBase::getTeam(%this);
	%teamname = getTeamName(%thisTeam);
	if (GameBase::getTeam(%object) != gamebase::getteam(%this))
	{
		if (%object.charg ==1) messageAll(0, Client::getName(%client) @ " is stealing " @ %teamname @ "'s energy!~wFlag1.wav");
		if (%object.charg <100)
		{
			%object.charg = %object.charg + 1;
			systemMessage(%client,0,"~wturretturn1.wav");
			bottomprint(%client, "<jc><f2>Energy Gathered = " @ %object.charg, 5);
		}
		else if (%object.charg ==100)
		{
			Client::SendMessage(%client,0,"~wAccess_Denied.wav");
			bottomprint(%client, "<jc><f1>Carrying Maximum Energy Capacity: Return this energy to your base's Electric Plant!", 5);
		}
	}
	else if (GameBase::getTeam(%object) == GameBase::getTeam(%this))
	{
		if (%object.charg >1)
			{
			%object.charg = %object.charg -1;
			%client.score = %client.score +1;
			systemMessage(%client,0,"~wbuysellsound.wav");
			bottomprint(%client, "<jc><f3>Energy Carried = " @ %object.charg @ ", Your score = " @ %client.score, 5);
			}
		else if (%object.charg == 1)
		{
			%object.charg = %object.charg -1;
			%client.score = %client.score +1;
 			messageAll(0, Client::getName(%client) @ " has captured " @ %teamname @ "'s Energy!~wflagcapture.wav");
			$flag.caps[Client::getTeam(%client)]++;
			%client.FlagCaps = (%client.FlagCaps + 1);
			$teamscore[Client::getTeam(%client)]++;
			Game::refreshClientScore(%client);
		}
		else
		{
			bottomprint(%client, "<jc><f1>You are carrying no energy to sell.\nGo commandeer energy from the enemy.", 5);
		}
	}
}

TriggerData RaceTrigger
{
	className = "Trigger";
	rate = 1.0;
};

function RaceTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Flier")
	{
		%client = Player::getClient(%object);
		if(!%object.race) %object.race = 0;
		if (%type == "Flier") %client = gamebase::getcontrolclient(%object);
		%name = Client::getName(%client);
		%group = getGroup(%this); 
 		%count = Group::objectCount(%group);
		%legs = getGroup(%group);
  		%legCount = Group::objectCount(%legs);
 		for (%j = 0; %j < %legCount; %j++) 
 		{
			%legobj = Group::getObject(%legs, %j);
			if (%legobj == %group)
			{
				//======found the leg
				if (!%client.race) %client.race = 0;
				if(%client.race == %j)
				{
					//======is at proper leg
					for (%i = 0; %i < %count; %i++) 
					{
						%obj = Group::getObject(%group, %i);
						if (%obj == %this)
						{
							//======found the checkpoint
							if(%object.race == %i)
							{
								//======is at proper checkpoint
								if(%i != (%count-1))
								{
									//======not last ck of leg
									%object.race=%i+1;
									systemMessage(%client,3, "~wflagreturn.wav");
									bottomprint(%client,"<jc>Check Point "@%i+1@".");
									return;
								}
								else
								{
									//======is last ck of leg
									if(%j != (%legCount-1))
									{
										//======not last leg of race
										%object.race=0;
										%client.race=(%client.race)+1;
										systemMessage(%client,3, "~wflagreturn.wav");
										bottomprint(%client, "<jc>Leg " @ %client.race @" complete!");
										%client.leg = %obj;
									}
									else
									{
										//======Finish Line
										if (!$laps || %client.laps+1 == $laps)
										{
//======Winner
%client.score = %client.score + 25;
Game::refreshClientScore(%client);
%client.FlagCaps++;
$teamScore[GameBase::getTeam(%object)]++;
//===looser messages
MessageAllExcept(%client, 1, %name @ " Won!  Oh, which means you lose.~wAccess_Denied.wav");
schedule("MessageAllExcept(" @ %client @ ",0,\"~wmale1.wcolor6.wav\");",0.3);
schedule("MessageAllExcept(" @ %client @ ",0,\"~wfemale2.wcolor7.wav\");",0.6);
schedule("MessageAllExcept(" @ %client @ ",0,\"~wmale3.wdsgst2.wav\");",0.9);
schedule("MessageAllExcept(" @ %client @ ",0,\"~wfemale4.wdsgst5.wav\");",1.2);
centerprintall("                               <Bflag_enemycaptured.bmp>  "@%name@" Won.  <Bflag_enemycaptured.bmp>");
//===Winner messages
Client::sendMessage(%client,3, "You Win!~wflagcapture.wav");
schedule("Client::sendMessage(" @ %client @ ",0,\"~wfemale1.wcheer3.wav\");",0.3);
schedule("Client::sendMessage(" @ %client @ ",0,\"~wmale1.wcheer2.wav\");",0.6);
schedule("Client::sendMessage(" @ %client @ ",0,\"~wmale4.wcheer1.wav\");",0.9);
schedule("Client::sendMessage(" @ %client @ ",0,\"~wfemale3.wcheer2.wav\");",1.2);
centerprint(%client, "                    <Bflag_atbase.bmp>  Winner's Bonus 25 points = " @ %client.score @ " points.  <Bflag_atbase.bmp>");
//=== reset players
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
	%cl.race="wait";
	%cl.elim = "true";
	%cl.laps = 0;
	%pl = Client::GetOwnedObject(%cl);
	GameBase::SetDamageLevel(%pl,1);
	Player::blowUp(%pl);
	schedule("centerprint(" @ %cl @ ",\"<jc><f2>Prepare for another race.\");",5);
	schedule("reeliminate( " @ %cl @ " );", 15);
}
%set = nameToID("MissionCleanup");
for(%i = 0; (%o = Group::getObject(%set, %i)) != -1; %i++)
{
	if (getObjectType(%o) == "Flier")
	{
		Grenade::Plastic_Detonate(%o);
	}
}
										}
										else
										{
//======Lap
%client.laps++;
%object.race="";
%client.score = %client.score + 5;
Game::refreshClientScore(%client);

//===looser messages
if (%client.laps ==1)
{
	MessageAllExcept(%client, 0, %name @ " completed a lap.~wfemale1.wdoh.wav");
	bottomprintall("<jc>"@%name@" completed a lap.",3);
	%inv = "st";
}
else
{
	MessageAllExcept(%client, 0, %name @ " has completed "@%client.laps@" laps.~wfemale3.wdsgst5.wav");
	bottomprintall("<jc>"@%name@" has completed "@%client.laps@" laps.",3);
	if (%client.laps ==2) %inv = "nd";
	else if (%client.laps ==3) %inv = "rd";
	else %inv = "th";
}
systemMessage(%client,3,%client.laps@%inv@" Lap! "@$laps-(%client.laps)@" to go.~wflagcapture.wav");
bottomprint(%client, "<jc><f2>"@%client.laps@%inv@" Lap! "@$laps-(%client.laps)@" to go.",3);
										}
									}
								}
							}
							else
							{
								//======not at proper checkpoint
								systemMessage(%client,1, "Check Point " @ %i+1@": You need Check Point "@%object.race+1@"!~wmale3.wregroup.wav");
								bottomprint(%client,"<jc><f1>Check Point " @ %i+1@": You need Check Point "@%object.race+1@"!");
								return;
							}
						}
					}
				}
				else
				{
					//======not at proper leg
					systemMessage(%client,1, "Leg " @ %j+1@" Check Point: You need Leg "@%client.race+1@"!~wmale3.wregroup.wav");
					bottomprint(%client,"<jc><f1>Leg " @ %j+1@" Check Point: You need Leg "@%client.race+1@"!");
				}
			}
		}
	}
}

function RaceTrigger::onLeave(%this,%object){}
